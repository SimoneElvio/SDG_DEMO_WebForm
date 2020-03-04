using System;
using System.Data;
using System.Web.UI.HtmlControls;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using BusinessObjects;
using System.Text;

namespace GestioneUtenti.Web.Common
{
    public partial class Menu : System.Web.UI.UserControl
    {
        #region Web Control Declaration

        protected PermessoAccesso objPermesso_accesso;
        protected BasePage p;
        protected Utente objUtente = new Utente();
        protected Clienti objClienti = new Clienti();
        protected const int C_VERSIONE_BASE = 1;
        protected const int C_VERSIONE_SILVER = 2;
        protected const int C_VERSIONE_GOLD = 3;
        int permessoNone;

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            if ((Session["RIV_ID_RICHIESTA"].ToString() == "0") || ((mainpage)Page).MenuVisible)
                PopulateNodes();
            //}
        }

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            objPermesso_accesso = new PermessoAccesso();
            p = this.Page as BasePage;
            base.OnInit(e);
        }
        #endregion

        #region Tree Binding At Once

        /// <summary>
        /// Popolamento nodi padre.
        /// </summary>
        void PopulateNodes()
        {
            //Il codice html del menu viene generato secondo questa modalità:
            //  <ul>
            //    <li>padre</li>
            //      <ul>
            //        <li>figlio</li>
            //        <li>figlio</li>
            //      </ul>
            //  </ul>
            
            //Utente Admin non cancellabile
            //AR Non veniva gestito (ora si), quindi era cablato solo sul ruolo Admin. Introdotto nuovo metodo.
            //IDataReader datareaderFunzionalities = objPermesso_accesso.ListPermessiAccessoByRuolo("1", "1");
            objPermesso_accesso.getPermessoFromName("None");
            permessoNone = (int)objPermesso_accesso.Pms_id_modalita_accesso;
            IDataReader datareaderFunzionalities = objPermesso_accesso.ListPermessiAccessoByUtente(p.idLoggedUser.ToString(), "1", p.qCultureInfoName);
            DataTable dataFunzionalities = p.GetTable(datareaderFunzionalities);
            DataView viewFathers = GetFathers(dataFunzionalities);

            foreach (DataRowView row in viewFathers)
            {
                //AR Corretto. Visualizzo solo quelli che hanno permesso di accesso > None
                if (row["FNT_FLAG_VISIBILITA_MENU"].ToString() == "True" && Convert.ToInt32(row["MODALITA_ACCESSO"]) > permessoNone)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    HtmlGenericControl href = new HtmlGenericControl("a");
                    HtmlGenericControl icona = new HtmlGenericControl("img");

                    //concateno l'immagine (se presente) per le voci di menù Padre
                    if (row["FNT_ICONA_MENU"].ToString() != string.Empty)
                    {
                        // icona.Attributes["src"] = "/Web/Images/" + row["FNT_ICONA_MENU"].ToString();
                        // li.Controls.Add(icona);
                    }

                    li.ID = row["FNT_ID_FUNZIONALITA"].ToString();
                    // li.Attributes["class"] = "liFather";
                    
                    href.InnerHtml = "<span class='hide-menu'>" + "<i class='" + row["FNT_ICONA_MENU"] + "'></i> " + row["DIZ_DESCRIZIONE"].ToString() + "</span>";

                    href.Attributes["href"] = (row["FNT_PAGINA_ASP"].ToString() == string.Empty) ? ("#") : (row["FNT_PAGINA_ASP"].ToString());

                    href.Attributes["class"] = "has-arrow";
                    href.Attributes["aria-expanded"] = "false";

                    //li.Controls.Add(href);

                    //Le voci di menù Padre dovrebbero essere utilizzate solo come macro voce per visualizzare le voci figlie.
                    //Potrebbe però capitare che la voce Padre venga utilizzata come link diretto.
                    //Se il flag apri in nuova pagina è TRUE setto il target in una nuova pagina (_blank)
                    //bool apriNuova = Convert.ToBoolean(row["FNT_FLAG_APRI_NUOVA"]);
                    //if (!apriNuova)
                    //    href.Attributes["onclick"] = "openChild(" + li.ID + ");";
                    //else
                    //    href.Attributes["onclick"] = "apriLink(" + li.ID + ",'" + row["FNT_PAGINA_ASP"].ToString() + "','_blank',false)";

                    li.Controls.Add(href);

                    sidebarnav.Controls.Add(li);

                    //Verifico la presenza di figli
                    AddSubNodeMenuList(dataFunzionalities, li);
                }
            }
        }

        DataView GetFathers(DataTable dataFunzionalities)
        {
            DataView view = new DataView(dataFunzionalities);
            view.RowFilter = "FUN_FNT_ID_FUNZIONALITA=1";
            return view;
        }

        /// <summary>
        /// Popolamento nodi figlio.
        /// </summary>
        void AddSubNodeMenuList(DataTable dataFunzionalities, HtmlGenericControl li)
        {
            DataView subnodes = GetSubNodesMenuList(dataFunzionalities, li.ID);
            //HtmlGenericControl liContainer = new HtmlGenericControl("li");
            HtmlGenericControl ulChild = new HtmlGenericControl("ul");

            ulChild.Attributes["aria-expanded"] = "false";
            ulChild.Attributes["class"] = "collapse";
                        
            ulChild.ID = "ulChild_" + li.ID;
            //liContainer.Attributes["class"] = "liChildContainer";
            foreach (DataRowView row in subnodes)
            {
                //AR Corretto. Visualizzo solo quelli che hanno permesso di accesso > None
                if (row["FNT_FLAG_VISIBILITA_MENU"].ToString() == "True" && Convert.ToInt32(row["MODALITA_ACCESSO"]) > permessoNone)
                {
                    HtmlGenericControl liChild = new HtmlGenericControl("li");
                    HtmlGenericControl href = new HtmlGenericControl("a");

                    liChild.ID = row["FNT_ID_FUNZIONALITA"].ToString();
                    // liChild.Attributes["class"] = "liChild";
                    href.InnerHtml = row["DIZ_DESCRIZIONE"].ToString();
                    href.Attributes["href"] = row["FNT_PAGINA_ASP"].ToString();
                    
                    //**Controllo se il flag apri in nuova pagina è TRUE, se lo è setto il target in una nuova pagina
                    bool apriNuova = Convert.ToBoolean(row["FNT_FLAG_APRI_NUOVA"]);
                    if (!apriNuova)
                    {
                        // href.Attributes["onclick"] = "apriLink(this,'" + row["FNT_PAGINA_ASP"].ToString() + "','frameContent',true)";
                        // href.Attributes["target"] = "frameContent";
                    }
                    else
                    {
                        // href.Attributes["onclick"] = "apriLink(this,'" + row["FNT_PAGINA_ASP"].ToString() + "','_blank',false)";
                        href.Attributes["target"] = "_blank";
                    }

                    liChild.Controls.Add(href);
                    ulChild.Controls.Add(liChild);

                    //Ciclo per eventuali altri figli.
                    //AddSubNode(dataFunzionalities, subNode);
                    
                }
                //liContainer.Controls.Add(ulChild);

                li.Controls.Add(ulChild); // liContainer);
            }
        }

        DataView GetSubNodesMenuList(DataTable dataFunzionalities, string funzID)
        {
            DataView view = new DataView(dataFunzionalities);
            view.RowFilter = "FUN_FNT_ID_FUNZIONALITA=" + funzID;
            return view;
        }

        #endregion
    }
}