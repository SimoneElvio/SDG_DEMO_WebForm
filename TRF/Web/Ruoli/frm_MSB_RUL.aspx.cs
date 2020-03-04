#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   frm_MSB_RUL.aspx
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe di CodeBehind  della pagina
//
// Autore:      AR - SDG srl
// Data:        27/06/2008
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:  
// Data:     
// Motivo:   
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;


public partial class Web_Ruoli_frm_MSB_RUL : BasePageBrowser
{
    #region Web Control Declaration
    protected PermessoAccesso objPermesso_accesso;
    protected string WhereClause = string.Empty;

    //PAGE VARIABLES
    protected int qID_MODALITA_ACCESSO;
    protected string qTIPO;
    protected string qSTATUS;
    protected string qPANEL;
    protected int qRUL_ID_RUOLO;

    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //Ripresa parametri di pagina
        qPANEL = Convert.ToString(Request.QueryString["PANEL"]);
        if (qPANEL == null)
            qPANEL = "";

        string id_ruolo = Request.QueryString["RUL_ID_RUOLO"];
        if (id_ruolo == null)
            qRUL_ID_RUOLO = 0;
        else
        {
            qRUL_ID_RUOLO = Convert.ToInt32(Request.QueryString["RUL_ID_RUOLO"]);
        }

        //Per ora viene valorizzata solo dalle Relazioni.
        qTIPO = ""; // Request.QueryString["TIPO"];
        qSTATUS = ""; // Request.QueryString["STATUS"];

        

        if (!IsPostBack)
        {

            GridViewRuoli.Columns[GridIndexOfByName(GridViewRuoli, "RUL_RUOLO")].HeaderText = GetValueDizionarioUI("RUOLO");
            GridViewRuoli.Columns[GridIndexOfByName(GridViewRuoli, "RUL_DATA_CREAZIONE")].HeaderText = GetValueDizionarioUI("DATA_CREAZIONE");

            GridViewUtentiRuolo.Columns[GridIndexOfByName(GridViewUtentiRuolo, "UTE_NOME")].HeaderText = GetValueDizionarioUI("NOME");
            GridViewUtentiRuolo.Columns[GridIndexOfByName(GridViewUtentiRuolo, "UTE_COGNOME")].HeaderText = GetValueDizionarioUI("COGNOME");
            GridViewUtentiRuolo.Columns[GridIndexOfByName(GridViewUtentiRuolo, "UTE_ALIAS")].HeaderText = GetValueDizionarioUI("ALIAS");
            GridViewUtentiRuolo.Columns[GridIndexOfByName(GridViewUtentiRuolo, "UTE_SIGLA")].HeaderText = GetValueDizionarioUI("SIGLA");
            GridViewUtentiRuolo.Columns[GridIndexOfByName(GridViewUtentiRuolo, "UTE_USER_ID")].HeaderText = GetValueDizionarioUI("USER_ID");
            GridViewUtentiRuolo.Columns[GetIndexByHeaderText(GridViewUtentiRuolo, "URL_STATO_RUOLO_UTENTE")].HeaderText = GetValueDizionarioUI("STATO");

            ObjectDataSourceUtentiRuolo.SelectParameters.Clear();
            ControlParameter cpUtentiRuolo = new ControlParameter("myParRulIdRuolo", TypeCode.Int32, "GridViewRuoli", "SelectedValue");
            ObjectDataSourceUtentiRuolo.SelectParameters.Add(cpUtentiRuolo);

            GridViewFunzionalita.Columns[GridIndexOfByName(GridViewFunzionalita, "FNT_ACRONIMO_FUNZIONALITA")].HeaderText = GetValueDizionarioUI("ACRONIMO");
            GridViewFunzionalita.Columns[GridIndexOfByName(GridViewFunzionalita, "FNT_DESCRIZIONE")].HeaderText = GetValueDizionarioUI("DESCRIZIONE");

            //GridViewFunzionalita.Columns[GridIndexOfByName(GridViewFunzionalita, "PMS_DESCRIZIONE")].HeaderText = GetValueDizionarioUI("AUTORIZZAZIOZIONI");
            ObjectDataSourceFunzionalita.SelectParameters.Clear();
            ControlParameter cpFunzionalita1 = new ControlParameter("myParRulIdRuolo", TypeCode.Int32, "GridViewRuoli", "SelectedValue");
            ControlParameter cpFunzionalita2 = new ControlParameter("qCultureInfoName", TypeCode.String, "GridViewRuoli", "SelectedValue");
            ObjectDataSourceFunzionalita.SelectParameters.Add(cpFunzionalita1);
            ObjectDataSourceFunzionalita.SelectParameters.Add(cpFunzionalita2);

            //Label
            LabelTitolo.InnerText = GetValueDizionarioUI("RUOLI");
            LabelRecPagina.InnerText = GetValueDizionarioUI("RECORD_PAGINA");
            LabelRecPaginaUtentiRuolo.InnerText = GetValueDizionarioUI("RECORD_PAGINA");
            LabelRecPaginaFunzionalita.InnerText = GetValueDizionarioUI("RECORD_PAGINA");
            
            GridViewFunzionalita.Columns[GetIndexByHeaderText(GridViewFunzionalita, "PERMESSO_ACCESSO")].HeaderText = GetValueDizionarioUI("PERMESSO");
            //DropDownList
            DropDownListRecordPagina.Items.Insert(0, new ListItem("5", "5"));
            DropDownListRecordPagina.Items.Insert(1, new ListItem("10", "10"));
            DropDownListRecordPagina.Items.Insert(2, new ListItem("15", "15"));
            DropDownListRecordPagina.Items.Insert(3, new ListItem("25", "25"));
            DropDownListRecordPagina.Items.Insert(4, new ListItem("35", "35"));
            DropDownListRecordPagina.Items.Insert(5, new ListItem("75", "75"));
            DropDownListRecordPagina.Items.Insert(6, new ListItem("100", "100"));
            DropDownListRecordPagina.SelectedIndex = 4;

            DropDownListRecPaginaUtentiRuolo.Items.Insert(0, new ListItem("10", "10"));
            DropDownListRecPaginaUtentiRuolo.Items.Insert(1, new ListItem("25", "25"));
            DropDownListRecPaginaUtentiRuolo.Items.Insert(2, new ListItem("50", "50"));
            DropDownListRecPaginaUtentiRuolo.Items.Insert(3, new ListItem("75", "75"));
            DropDownListRecPaginaUtentiRuolo.Items.Insert(4, new ListItem("100", "100"));

            DropDownListRecPaginaFunzionalita.Items.Insert(0, new ListItem("10", "10"));
            DropDownListRecPaginaFunzionalita.Items.Insert(1, new ListItem("25", "25"));
            DropDownListRecPaginaFunzionalita.Items.Insert(2, new ListItem("50", "50"));
            DropDownListRecPaginaFunzionalita.Items.Insert(3, new ListItem("75", "75"));
            DropDownListRecPaginaFunzionalita.Items.Insert(4, new ListItem("100", "100"));
            DropDownListRecPaginaFunzionalita.SelectedIndex = 4;
        }


        //Pulsanti
        ButtonUtenti.Text = GetValueDizionarioUI("UTENTI");
        ButtonFunzionalita.Text = GetValueDizionarioUI("FUNZIONALITA");
        //ButtonFiltroRuolo.Text = GetValueDizionarioUI("FILTRO");
        ButtonNuovoRuolo.InnerText = GetValueDizionarioUI("NUOVO");        
        ButtonNuovoUtenteRuolo.Text = GetValueDizionarioUI("AGGIUNGI");
        ButtonSalvaFunzionalita.Text = GetValueDizionarioUI("SALVA");        
        ButtonNuovoFunzionalita.Text = GetValueDizionarioUI("NUOVO");        

        //-------------------------
        //REGISTRAZIONE JSCRIPT CLIENT
        //-------------------------
        //if (!this.ClientScript.IsStartupScriptRegistered("ChangeDropDownStatus_Js"))
        //{
        //    this.ClientScript.RegisterStartupScript(GetType(), "ChangeDropDownStatus_Js", this.ChangeDropDownStatus_Js());
        //}

        if (!this.ClientScript.IsStartupScriptRegistered("PageChangeFNT_Js"))
        {
            this.ClientScript.RegisterStartupScript(GetType(), "PageChangeFNT_Js", this.PageChangeFNT_Js());
        }

        SetPageControlAccess();

        if (allowAccess == false)
        {
            WhereClause = " WHERE 1=2 ";
        }

        //Modifico il nro di record per pagina
        GridViewRuoli.PageSize = Convert.ToInt32(DropDownListRecordPagina.SelectedValue);
        GridViewUtentiRuolo.PageSize = Convert.ToInt32(DropDownListRecPaginaUtentiRuolo.SelectedValue);
        GridViewFunzionalita.PageSize = Convert.ToInt32(DropDownListRecPaginaFunzionalita.SelectedValue);

        //Refresh griglie
        if (EffettuaRefresh.Value == "1")
        {
            ObjectDataSourceRuoli.Select();
            ObjectDataSourceRuoli.DataBind();
            GridViewRuoli.DataBind();

            ObjectDataSourceUtentiRuolo.Select();
            ObjectDataSourceUtentiRuolo.DataBind();
            GridViewUtentiRuolo.DataBind();

            EffettuaRefresh.Value = "0";
        }        

    }
    #endregion

    #region Access Control

    private void SetPageControlAccess()
    {
        SetPageControlAccess("RUL");
    }
    #endregion 

    #region OnInit
    protected override void OnInit(EventArgs e)
    {
        InitializeMyComponents();
        objPermesso_accesso = new PermessoAccesso();
        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        
        this.PreRender += new System.EventHandler(this.frm_MSB_RUL_PreRender);

        GridViewRuoli.DataSourceID = "ObjectDataSourceRuoli";
        string[] ruoliDataKeys = { "RUL_ID_RUOLO" };
        GridViewRuoli.DataKeyNames = ruoliDataKeys;
        GridViewRuoli.DataBound += new EventHandler(GridViewRuoli_DataBound);
        GridViewRuoli.PageIndexChanged += new EventHandler(GridViewRuoli_PageIndexChanged);
        GridViewRuoli.RowCreated += new GridViewRowEventHandler(GridViewRuoli.MyGridViewRowCreated);
        GridViewRuoli.RowDataBound += new GridViewRowEventHandler(GridViewRuoli.MyGridViewDataBound);
        GridViewRuoli.SelectedIndexChanged += new EventHandler(GridViewRuoli_SelectedIndexChanged);
        GridViewRuoli.RowCommand += new GridViewCommandEventHandler(GridViewRuoli_RowCommand);
        ObjectDataSourceRuoli.TypeName = "SDG.GestioneUtenti.Ruoli";
        ObjectDataSourceRuoli.SelectMethod = "List";
        ObjectDataSourceRuoli.ObjectCreated += new ObjectDataSourceObjectEventHandler(ObjectDataSourceRuoli_SetProperties);
        ObjectDataSourceRuoli.Selected += new ObjectDataSourceStatusEventHandler(ObjectDataSourceRuoli_Selected);

        GridViewUtentiRuolo.DataSourceID = "ObjectDataSourceUtentiRuolo";
        string[] utentiRuoloDataKeys = { "RUL_ID_RUOLO","UTE_ID_UTENTE","URL_STATO_RUOLO_UTENTE","URL_ID_RUOLI_UTENTE" };
        GridViewUtentiRuolo.DataKeyNames = utentiRuoloDataKeys;
        GridViewUtentiRuolo.DataBound += new EventHandler(GridViewUtentiRuolo_DataBound);
        GridViewUtentiRuolo.RowCreated += new GridViewRowEventHandler(GridViewUtentiRuolo.MyGridViewRowCreated);
        GridViewUtentiRuolo.RowDataBound += new GridViewRowEventHandler(GridViewUtentiRuolo.MyGridViewDataBound);
        GridViewUtentiRuolo.RowCommand += new GridViewCommandEventHandler(GridViewUtentiRuolo_RowCommand);
        ObjectDataSourceUtentiRuolo.TypeName = "SDG.GestioneUtenti.RuoliUtente";
        ObjectDataSourceUtentiRuolo.SelectMethod = "ListUtentiByRuolo";
        ObjectDataSourceUtentiRuolo.Selected += new ObjectDataSourceStatusEventHandler(ObjectDataSourceUtentiRuolo_Selected);

        GridViewFunzionalita.DataSourceID = "ObjectDataSourceFunzionalita";
        string[] funzionalitaDataKeys = { "FNT_ID_FUNZIONALITA", "PMS_ID_MODALITA_ACCESSO", "RUL_ID_RUOLO", "FNT_ACRONIMO_FUNZIONALITA" };
        GridViewFunzionalita.DataKeyNames = funzionalitaDataKeys;
        GridViewFunzionalita.DataBound += new EventHandler(GridViewFunzionalita_DataBound);
        GridViewFunzionalita.SelectedIndexChanged += new EventHandler(GridViewFunzionalita_SelectedIndexChanged);
        GridViewFunzionalita.PageIndexChanging += new GridViewPageEventHandler(GridViewFunzionalita_PageIndexChanging);
        GridViewFunzionalita.PageIndexChanged += new EventHandler(GridViewFunzionalita_PageIndexChanged);
        GridViewFunzionalita.RowCreated += new GridViewRowEventHandler(GridViewFunzionalita.MyGridViewRowCreated);
        ObjectDataSourceFunzionalita.TypeName = "SDG.GestioneUtenti.Funzionalita";
        ObjectDataSourceFunzionalita.SelectMethod = "ListFunzionalitaByRuolo";

        ObjectDataSourcePermessi.TypeName = "SDG.GestioneUtenti.PermessoAccesso";
        ObjectDataSourcePermessi.SelectMethod = "getDsLookupPermessi";

        btnRefresh.Click += new EventHandler(btnRefresh_Click);

        //DropDownListRecordPagina.SelectedIndexChanged += new EventHandler(DropDownListRecordPagina_SelectedIndexChanged);


    }

    //void DropDownListRecordPagina_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownListRecPagina_SelectedIndexChanged("GridViewRuoli","DropDownListRecordPagina");
    //}
    #endregion

    #region Web Form Event Handler
    protected void ObjectDataSourceRuoli_SetProperties(object sender, ObjectDataSourceEventArgs e)
    {
        Ruoli objRuoli = e.ObjectInstance as Ruoli;
        if (dizionarioPermessi["ADM"] != objUtilita.AccessDelete)
        {
            if(WhereClause == string.Empty)
                WhereClause += " WHERE RUL_ID_RUOLO <> 1 ";
            else
                WhereClause += " AND RUL_ID_RUOLO <> 1 ";
        }
        objRuoli.SqlWhereClause = WhereClause;
    }

    protected void GridViewFunzionalita_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (saveFNTPage.Value == "1")
        {
            for (int index = 0; index < GridViewFunzionalita.Rows.Count; index++)
            {
                objPermesso_accesso.Fnt_id_funzionalita = Convert.ToInt32(GridViewFunzionalita.DataKeys[index].Values["FNT_ID_FUNZIONALITA"]);
                if (GridViewFunzionalita.DataKeys[index].Values["RUL_ID_RUOLO"].ToString().Length > 0)
                {
                    objPermesso_accesso.Rul_id_ruolo = Convert.ToInt32(GridViewFunzionalita.DataKeys[index].Values["RUL_ID_RUOLO"]);
                }
                else
                {
                    objPermesso_accesso.Rul_id_ruolo = Convert.ToInt32(GridViewRuoli.SelectedDataKey["RUL_ID_RUOLO"]);
                }

                if (((DropDownList)GridViewFunzionalita.Rows[index].FindControl("DropDownListPermessi")).SelectedValue != "")
                    qID_MODALITA_ACCESSO = Convert.ToInt32(((DropDownList)GridViewFunzionalita.Rows[index].FindControl("DropDownListPermessi")).SelectedValue);
                else
                    qID_MODALITA_ACCESSO = Convert.ToInt32("1");

                objPermesso_accesso.Pms_id_modalita_accesso = qID_MODALITA_ACCESSO;

                if (GridViewFunzionalita.DataKeys[index].Values["RUL_ID_RUOLO"].ToString().Length == 0)
                {
                    if (objPermesso_accesso.TestExist() != 1)
                    {
                        objPermesso_accesso.Create();
                    }
                    else
                    {
                        objPermesso_accesso.Update();
                    }
                }
                else
                {
                    objPermesso_accesso.Update();
                }
            }
        }
    }

    protected void GridViewFunzionalita_PageIndexChanged(object sender, EventArgs e)
    {
        //Si perde la riga selezionata
        GridViewFunzionalita.SelectedIndex = -1;
        //Ad ogni cambio pagina si resetta il campo (non ci sono ancora cambiamenti in pagina)
        fieldChangedFNT.Value = "0";
    }

    void GridViewFunzionalita_DataBound(object sender, EventArgs e)
    {
        try
        {
            int contatore = 0;
            //Griglia contenente dati
            MyGridViewLibrary.MyGridView appoggio;
            appoggio = (MyGridViewLibrary.MyGridView)sender;
            if (GridViewFunzionalita.Rows.Count > 0)
            {
                // Use the Count property to determine whether the
                // DataKeys collection contains any items.
                if (GridViewFunzionalita.DataKeys.Count > 0)
                {
                    IEnumerator keyEnumerator = GridViewFunzionalita.DataKeys.GetEnumerator();
                    while (keyEnumerator.MoveNext())
                    {
                        DataKey key = (DataKey)keyEnumerator.Current;

                        if (GridViewFunzionalita.DataKeys[contatore].Values["PMS_ID_MODALITA_ACCESSO"].ToString().Length != 0)
                        {
                            ((DropDownList)GridViewFunzionalita.Rows[contatore].FindControl("DropDownListPermessi")).SelectedIndex = (Convert.ToInt32(GridViewFunzionalita.DataKeys[contatore].Values["PMS_ID_MODALITA_ACCESSO"])) - 1;
                        }
                        else
                        {
                            ((DropDownList)GridViewFunzionalita.Rows[contatore].FindControl("DropDownListPermessi")).SelectedIndex = -1;
                        }
                        
                        if (allowEdit)
                        {
                            ((DropDownList)GridViewFunzionalita.Rows[contatore].FindControl("DropDownListPermessi")).Enabled = true;
                            ((DropDownList)GridViewFunzionalita.Rows[contatore].FindControl("DropDownListPermessi")).Attributes["onChange"] = "$('#fieldChangedFNT').value = 1;";
                        }
                        else
                        {
                            ((DropDownList)GridViewFunzionalita.Rows[contatore].FindControl("DropDownListPermessi")).Enabled = false;
                        }

                        //Se sono sull'acronimo ADMINISTRATOR, disabilito la possibilià di assegnargli un livello diverso da None se non sono administrator
                        if(dizionarioPermessi["ADM"] != objUtilita.AccessDelete)
                        {
                            if (GridViewFunzionalita.DataKeys[contatore].Values["FNT_ACRONIMO_FUNZIONALITA"].ToString() == "ADM")
                            {
                                ((DropDownList)GridViewFunzionalita.Rows[contatore].FindControl("DropDownListPermessi")).SelectedIndex = objUtilita.AccessNone-1;//Access None vale 1 , io sottraggo uno perchè l'indice parte da 0 come livello più basso
                                ((DropDownList)GridViewFunzionalita.Rows[contatore].FindControl("DropDownListPermessi")).Enabled = false;
                            }
                        }

                        //Se il livellod ella funzionalita è diverso da NONE visualizzo in verde la riga
                        if (Convert.ToInt32(((DropDownList)GridViewFunzionalita.Rows[contatore].FindControl("DropDownListPermessi")).SelectedValue) != objUtilita.AccessNone)
                        {
                            GridViewFunzionalita.Rows[contatore].Style.Add("background-color", "#99FF99");
                        }
                        contatore++;
                    }
 
                    //Al cambio pagina si chiede se salvare i dati della pagina
                    this.GridViewFunzionalita.BottomPagerRow.Attributes["onClick"] = "javascript:pageChangeFNT()";
                }
                else
                {
                    throw new System.Exception("GridViewFunzionalita:no DataKey objects.");
                }
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void GridViewUtentiRuolo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "DELETE_COMMAND")
        //{
        //    try
        //    {
        //        string argument = e.CommandArgument.ToString();
        //        int chiave1 = Convert.ToInt32(argument.Substring(0, argument.IndexOf(',')));
        //        int chiave2 = Convert.ToInt32(argument.Substring(argument.IndexOf(',') + 1));

        //        RuoliUtente objRuoliUtente = new RuoliUtente();
        //        objRuoliUtente.Rul_id_ruolo = chiave1;
        //        objRuoliUtente.Ute_id_utente = chiave2;
        //        objRuoliUtente.Delete();
        //        GridViewUtentiRuolo.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        bool rethrow = ExceptionPolicy.HandleException(ex, "Propagate Policy");
        //        Response.End();
        //    }
        //}
    }

    protected void GridViewRuoli_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_COMMAND")
        {
            int chiave = Convert.ToInt32(e.CommandArgument);
            try
            {
                Ruoli objRuoli = new Ruoli();
                objRuoli.Rul_id_ruolo = chiave;
                objRuoli.Delete();
                GridViewRuoli.DataBind();
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, "Propagate Policy");
                Response.End();
            }

        }
    }


    new void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRuoli.DataBind();
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void ObjectDataSourceRuoli_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //Così va bene anche con i filtri
        DataView dv = new DataView(((DataSet)e.ReturnValue).Tables["RUOLI"], ObjectDataSourceRuoli.FilterExpression, "", DataViewRowState.CurrentRows);
        e.AffectedRows = dv.Count;
        LabelNroRecord.InnerText = e.AffectedRows.ToString() + " record";
    }

    protected void ObjectDataSourceUtentiRuolo_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //Così va bene anche con i filtri
        DataView dv = new DataView(((DataSet)e.ReturnValue).Tables["RUOLI_UTENTE"], ObjectDataSourceUtentiRuolo.FilterExpression, "", DataViewRowState.CurrentRows);
        e.AffectedRows = dv.Count;
        nroRecordUtentiRuolo.InnerText = e.AffectedRows.ToString() + " record";
    }

    void GridViewRuoli_DataBound(object sender, EventArgs e)
    {
        try
        {
            string percorso = "";
            string chiamata = "";
            int contatore = 0;
            //Griglia contenente dati
            if (GridViewRuoli.Rows.Count > 0)
            {
                // Use the Count property to determine whether the
                // DataKeys collection contains any items.
                if (GridViewRuoli.DataKeys.Count > 0)
                {
                    IEnumerator keyEnumerator = GridViewRuoli.DataKeys.GetEnumerator();
                    while (keyEnumerator.MoveNext())
                    {
                        DataKey key = (DataKey)keyEnumerator.Current;
                        
                        if (qRUL_ID_RUOLO != 0)
                            if ((int)GridViewRuoli.DataKeys[contatore].Value == qRUL_ID_RUOLO)
                            {
                                GridViewRuoli.SelectedIndex = findRowByDataKey(GridViewRuoli, key);
                                if (qPANEL == "PanelUtentiRuolo")
                                    showUtenti();
                            }
                        
                        if (allowDelete)
                        {
                            skmExtendedControls.skmLinkButton btnExtended = (skmExtendedControls.skmLinkButton)GridViewRuoli.Rows[contatore].FindControl("ButtonDeleteRuoli");
                            if (btnExtended != null)
                            {
                                if (btnExtended.CommandName == "DELETE_COMMAND")
                                {
                                    btnExtended.CommandArgument = Convert.ToInt64(key.Value).ToString();
                                    btnExtended.ConfirmMessage = GetValueDizionarioUI("CONFIRM_DELETION");
                                    //btnExtended.Text = objDizionarioUI["BUTTON_CANCELLA"];
                                    btnExtended.Text = "<i class='fa fa-times'></i>";
                                }                                                                                                
                            }
                        }
                        else
                        {
                            skmExtendedControls.skmLinkButton btnExtended = (skmExtendedControls.skmLinkButton)GridViewRuoli.Rows[contatore].FindControl("ButtonDeleteRuoli");
                            btnExtended.Enabled = false;
                        }

                        LinkButton btnEdit = (LinkButton)GridViewRuoli.Rows[contatore].FindControl("ButtonEditRuoli");
                        //btnEdit.Text = GetValueDizionarioUI("BUTTON_MODIFICA");
                        btnEdit.Text = "<i class='fas fa-pencil-alt' data-toggle='modal' data-target='#modalPage'></i>";
                        if (allowEdit)
                        {
                            percorso = @"frm_MSE_RUL.aspx?MODALITA=EDIT&RUL_ID_RUOLO=" + GridViewRuoli.DataKeys[contatore].Value;
                            //chiamata = "javascript:parent.openEditor('" + percorso + "');return false;";
                            chiamata = "javascript:openModal('" + percorso + "', 'RUL');return false;";
                            GridViewRuoli.Rows[contatore].Cells[1].Attributes["onClick"] = chiamata;
                        }
                        else
                        {
                            percorso = @"frm_MSE_RUL.aspx?MODALITA=VIEW&RUL_ID_RUOLO=" + GridViewRuoli.DataKeys[contatore].Value;
                            //chiamata = "javascript:parent.openEditor('" + percorso + "');return false;";
                            chiamata = "javascript:openModal('" + percorso + "', 'RUL');return false;";
                            GridViewRuoli.Rows[contatore].Cells[1].Attributes["onClick"] = chiamata;
                            //Cambiare icona 
                            btnEdit.Text = GetValueDizionarioUI("BUTTON_VISUALIZZA");
                        }
                        contatore++;
                    }
                }
                else
                {
                    throw new System.Exception("GridViewRuoli:no DataKey objects.");
                }
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    void GridViewUtentiRuolo_DataBound(object sender, EventArgs e)
    {
        try
        {
            int contatore = 0;
            string percorso = "";
            string chiamata;
            //Griglia contenente dati
            if (GridViewUtentiRuolo.Rows.Count > 0)
            {
                // Use the Count property to determine whether the
                // DataKeys collection contains any items.
                if (GridViewUtentiRuolo.DataKeys.Count > 0)
                {
                    IEnumerator keyEnumerator = GridViewUtentiRuolo.DataKeys.GetEnumerator();
                    while (keyEnumerator.MoveNext())
                    {
                        DataKey key = (DataKey)keyEnumerator.Current;

                        ((CheckBox)GridViewUtentiRuolo.Rows[contatore].FindControl("CheckBoxStatoRuolo")).Checked = Convert.ToBoolean((GridViewUtentiRuolo.DataKeys[contatore].Values["URL_STATO_RUOLO_UTENTE"]));
                                               
                        LinkButton btnEdit = (LinkButton)GridViewUtentiRuolo.Rows[contatore].FindControl("ButtonEditRuoliUtente");
                        //btnEdit.Text = GetValueDizionarioUI("BUTTON_MODIFICA");
                        btnEdit.Text = "<i class='fas fa-pencil-alt' data-toggle='modal' data-target='#modalPage'></i>";
                        if (allowEdit)
                        {
                            percorso = @"frm_MSE_RUL_UTE.aspx?PROVENIENZA=UTE&MODALITA=EDIT&RUL_ID_RUOLO=" + GridViewUtentiRuolo.DataKeys[contatore].Values["RUL_ID_RUOLO"] + "&UTE_ID_UTENTE=" + GridViewUtentiRuolo.DataKeys[contatore].Values["UTE_ID_UTENTE"] + "&URL_ID_RUOLI_UTENTE=" + GridViewUtentiRuolo.DataKeys[contatore].Values["URL_ID_RUOLI_UTENTE"] ;
                            //chiamata = "javascript:self.parent.openEditor('" + percorso + "');return false;";
                            chiamata = "javascript:openModal('" + percorso + "', 'RUL_UTE');return false;";
                            GridViewUtentiRuolo.Rows[contatore].Cells[0].Attributes["onClick"] = chiamata;
                        }

                        contatore++;
                    }
                }
                else
                {
                    throw new System.Exception("GridViewUtentiRuolo:no DataKey objects.");
                }
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void GridViewRuoli_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GridViewRuoli.SelectedIndex != -1)
        {
            LabelTitoloUtentiRuolo.InnerHtml = (GetValueDizionarioUI("UTENTI")) + " : " + (GetValueDizionarioUI("RUOLO")) + " " + GridViewRuoli.SelectedRow.Cells[GridIndexOfByName(GridViewRuoli, "RUL_RUOLO")].Text.ToString();
            LabelFunzionalita.InnerHtml = (GetValueDizionarioUI("FUNZIONALITA")) + " : " + (GetValueDizionarioUI("RUOLO")) + " " + GridViewRuoli.SelectedRow.Cells[GridIndexOfByName(GridViewRuoli, "RUL_RUOLO")].Text.ToString();
        }
    }

    protected void GridViewRuoli_PageIndexChanged(object sender, EventArgs e)
    {
        //Si perde la riga selezionata
        GridViewRuoli.SelectedIndex = -1;
        //Aggiornamento griglie DEVE essere rifatto 
        AggiornaSubBrowser();
    }

    private void AggiornaSubBrowser()
    {
        try
        {
            if (ButtonUtenti.CssClass == "buttonDettaglioSelect")
            {
                ObjectDataSourceUtentiRuolo.Select();
                ObjectDataSourceUtentiRuolo.DataBind();
                GridViewUtentiRuolo.DataBind();
            }
            if (ButtonFunzionalita.CssClass == "buttonDettaglioSelect")
            {
                ObjectDataSourceFunzionalita.Select();
                ObjectDataSourceFunzionalita.DataBind();
                GridViewFunzionalita.DataBind();
            } 
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
            //Response.End();
        }
    }


    //Sga: verificare se questa gestione pannelli può generare lentezza 
    //in caso di molti pannelli e molti record ...
    //Eventualmente si può filtrare ulteriormente il riempimento dei controls gridview
    //in base anche al pulsante pannello premuto? Investigare meglio!
    protected void ButtonUtenti_Click(object sender, EventArgs e)
    {
        showUtenti();
    }

    protected void ButtonFunzionalita_Click(object sender, EventArgs e)
    {
        showFunzionalita();
    }

    protected void GridViewFunzionalita_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewFunzionalita.SelectedIndex != -1)
            {
                //...
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }

    }

    protected void ButtonSalvaFunzionalita_Click(object sender, EventArgs e)
    {
        if (allowEdit)
        {
            objPermesso_accesso = new PermessoAccesso();

            for (int index = 0; index < GridViewFunzionalita.Rows.Count; index++)
            {
                int KeysCount = GridViewFunzionalita.DataKeys.Count;
                if (GridViewFunzionalita.Rows.Count == GridViewFunzionalita.DataKeys.Count)
                {
                    try
                    {
                        objPermesso_accesso.Fnt_id_funzionalita = Convert.ToInt32(GridViewFunzionalita.DataKeys[index].Values["FNT_ID_FUNZIONALITA"]);
                        if (GridViewFunzionalita.DataKeys[index].Values["RUL_ID_RUOLO"].ToString().Length > 0)
                        {
                            objPermesso_accesso.Rul_id_ruolo = Convert.ToInt32(GridViewFunzionalita.DataKeys[index].Values["RUL_ID_RUOLO"]);
                        }
                        else
                        {
                            objPermesso_accesso.Rul_id_ruolo = Convert.ToInt32(GridViewRuoli.SelectedDataKey["RUL_ID_RUOLO"]);
                        }

                        if (((DropDownList)GridViewFunzionalita.Rows[index].FindControl("DropDownListPermessi")).SelectedValue != "")
                            qID_MODALITA_ACCESSO = Convert.ToInt32(((DropDownList)GridViewFunzionalita.Rows[index].FindControl("DropDownListPermessi")).SelectedValue);
                        else
                            qID_MODALITA_ACCESSO = Convert.ToInt32("1");

                        objPermesso_accesso.Pms_id_modalita_accesso = qID_MODALITA_ACCESSO;

                        if (GridViewFunzionalita.DataKeys[index].Values["RUL_ID_RUOLO"].ToString().Length == 0)
                        {
                            if (objPermesso_accesso.TestExist() != 1)
                            {
                                objPermesso_accesso.Create();
                            }
                            else
                            {
                                objPermesso_accesso.Update();
                            }
                        }
                        else
                        {
                            objPermesso_accesso.Update();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Gestione messaggistica all'utente e trace in DB dell'errore
                        ExceptionPolicy.HandleException(ex, "Propagate Policy");
                    }
                }
            }
        }
    }

    protected void showUtenti()
    {
        //Pulsanti navigazione
        ButtonUtenti.CssClass = "tabSelected";
        ButtonFunzionalita.CssClass = "tabNoSelected";

        //Pannello Utenti
        PanelUtentiRuolo.Visible = true;        
        ButtonNuovoUtenteRuolo.Visible = true;
        LabelTitoloUtentiRuolo.Visible = true;

        //Aggiornamento griglie DEVE essere rifatto 
        ObjectDataSourceUtentiRuolo.Select();
        ObjectDataSourceUtentiRuolo.DataBind();
        GridViewUtentiRuolo.DataBind();
        GridViewUtentiRuolo.Visible = true;

        //Pannello Funzionalita
        PanelFunzionalita.Visible = false;
        ButtonNuovoFunzionalita.Visible = false;
        ButtonSalvaFunzionalita.Visible = false;
        //ButtonFiltroFunzionalita.Visible = false;
        GridViewFunzionalita.Visible = false;
        LabelFunzionalita.Visible = false;
    }


   

    protected void showFunzionalita()
    {
        //GridViewFunzionalita.Columns[GridIndexOfByName(GridViewFunzionalita, "DropDownListPermessi")].HeaderText = GetValueDizionarioUI("AUTORIZZAZIONI");

        //Pulsanti navigazione
        ButtonUtenti.CssClass = "tabNoSelected";
        ButtonFunzionalita.CssClass = "tabSelected";

        //Pannello Utenti
        ButtonNuovoUtenteRuolo.Visible = false;
        LabelTitoloUtentiRuolo.Visible = false;
        GridViewUtentiRuolo.Visible = false;

        //Pannello Funzionalita
        PanelFunzionalita.Visible = true;
        //ButtonNuovoFunzionalita.Visible = true;
        ButtonSalvaFunzionalita.Visible = true;
        //ButtonFiltroFunzionalita.Visible = true;

        PanelUtentiRuolo.Visible = false;        
        ButtonNuovoUtenteRuolo.Visible = false;
        LabelTitoloUtentiRuolo.Visible = false;

        //Aggiornamento griglie DEVE essere rifatto 
        //ObjectDataSourcePermessi.Select();
        //ObjectDataSourcePermessi.DataBind();
        ObjectDataSourceFunzionalita.Select();
        ObjectDataSourceFunzionalita.DataBind();
        GridViewFunzionalita.DataBind();
        GridViewFunzionalita.Visible = true;
        LabelFunzionalita.Visible = true;
    }

    #endregion

    #region DataBinding
    private void BindData()
    {
        try
        {
            objPermesso_accesso.Pms_id_modalita_accesso = qID_MODALITA_ACCESSO;
            objPermesso_accesso.Read();
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion

    #region Tree Binding
    void PopulateNodes()
    {
        //TreeViewFunzionalitaRuolo.Nodes.Clear();

        objPermesso_accesso = new PermessoAccesso();

        IDataReader datareaderFunzionalities = objPermesso_accesso.ListPermessiAccessoByRuolo(GridViewRuoli.SelectedDataKey.Value.ToString(), "1");

        DataTable dataFunzionalities = this.GetTable(datareaderFunzionalities);

        DataView viewFathers = GetFathers(dataFunzionalities);
        foreach (DataRowView row in viewFathers)
        {
            TreeNode fatherNode = new TreeNode();
            switch (qCultureInfoName)
            {
                case "it":
                    fatherNode.Text = row["FNT_DESCRIZIONE_ITA"].ToString();

                    //fatherNode.Text += "<asp:DropDownList ID=/"DropDownList1/" runat=/"server/">";
                    //fatherNode.Text += "<asp:ListItem Value=/"1/"> AA </asp:ListItem>";
                    //fatherNode.Text += "<asp:ListItem Value=/"2/"> BB </asp:ListItem>";
                    //fatherNode.Text += "</asp:DropDownList>";

                    break;
                case "en":
                    fatherNode.Text = row["FNT_DESCRIZIONE_ENG"].ToString();
                    break;
                default:
                    fatherNode.Text = row["FNT_DESCRIZIONE_ITA"].ToString();
                    break;
            }
            fatherNode.Value = row["FNT_ID_FUNZIONALITA"].ToString();
            //TreeViewFunzionalitaRuolo.Nodes.Add(fatherNode);
            AddSubNode(dataFunzionalities, fatherNode);
        }

        // TreeViewFunzionalitaRuolo.ExpandAll();
    }

    DataView GetFathers(DataTable dataFunzionalities)
    {
        DataView view = new DataView(dataFunzionalities);
        view.RowFilter = "FUN_FNT_ID_FUNZIONALITA=1";
        return view;
    }

    void AddSubNode(DataTable dataFunzionalities, TreeNode node)
    {
        DataView subnodes = GetSubNodes(dataFunzionalities, node.Value);
        foreach (DataRowView row in subnodes)
        {
            TreeNode subNode = new TreeNode();
            switch (qCultureInfoName)
            {
                case "it":
                    subNode.Text = row["FNT_DESCRIZIONE_ITA"].ToString();
                    break;
                case "en":
                    subNode.Text = row["FNT_DESCRIZIONE_ENG"].ToString();
                    break;
                default:
                    subNode.Text = row["FNT_DESCRIZIONE_ITA"].ToString();
                    break;
            }
            subNode.Value = row["FNT_ID_FUNZIONALITA"].ToString();
            node.ChildNodes.Add(subNode);
            AddSubNode(dataFunzionalities, subNode);
        }
    }

    DataView GetSubNodes(DataTable dataFunzionalities, string funzID)
    {
        DataView view = new DataView(dataFunzionalities);
        view.RowFilter = "FUN_FNT_ID_FUNZIONALITA=" + funzID;
        return view;
    }

    #endregion

    #region Web Form Menu JScriptFunctions

    public string PageChangeFNT_Js()
    {
        string MsgChangePage = GetValueDizionarioUI("CAMBIO_PAG_FUNZIONALITA");

        //Uscita con controllo sul salvataggio dei dati cambiati
        string js = @"
                <script type='text/javascript'>
				function pageChangeFNT()
				{ 
                   if (document.getElementById('fieldChangedFNT').value==1) 
                   {    
                       if (confirm('" + MsgChangePage + @"'))
                       {
                           document.getElementById('saveFNTPage').value=1;
                       }
                       else
                       {
                           document.getElementById('saveFNTPage').value=0;
                       }
                   }
                   else
                   {
                       document.getElementById('saveFNTPage').value=0;
                   }
                }
				</script>";

        return js;
    }

    #endregion

    #region Web Form PreRender
    private void frm_MSB_RUL_PreRender(object sender, EventArgs e)
    {
        string percorso = "";
        string chiamata;
        try
        {
            if (allowEdit)
            {
                //Nuovo Ruolo
                percorso = @"frm_MSE_RUL.aspx?MODALITA=NEW";
                //chiamata = "javascript:self.parent.openEditor('" + percorso + "');return false;";
                chiamata = "javascript:openModal('" + percorso + "', 'RUL');return false;";
                ButtonNuovoRuolo.Attributes["onClick"] = chiamata;
                ButtonNuovoRuolo.Attributes["data-toggle"] = "modal";
                ButtonNuovoRuolo.Attributes["data-target"] = "#modalPage";
            }

            if (allowEdit)
            {
                //Recupero l'ID della riga selezionata nella griglia Ruoli.
                //Se esiste allora creo il path da passare ai pulsanti del Browser di dettaglio.
                int indexRowSelected = GridViewRuoli.SelectedIndex;
                if (indexRowSelected > -1)
                    percorso = @"frm_MSE_RUL_UTE.aspx?MODALITA=NEW&PROVENIENZA=RUL&RUL_ID_RUOLO=" + (GridViewRuoli.DataKeys[indexRowSelected].Values["RUL_ID_RUOLO"]);

                //chiamata = "javascript:self.parent.openEditor('" + percorso + "');return false;";
                chiamata = "javascript:openModal('" + percorso + "', 'RUL_UTE');return false;";
                ButtonNuovoUtenteRuolo.Attributes["onClick"] = chiamata;
                ButtonNuovoUtenteRuolo.Attributes["data-toggle"] = "modal";
                ButtonNuovoUtenteRuolo.Attributes["data-target"] = "#modalPage";
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion
}
