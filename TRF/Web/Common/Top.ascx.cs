#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    SDG_DEMO
// Nome File:   Top.ascx
//
// Namespace:   SDG_DEMO
// Descrizione: Classe di CodeBehind  della pagina
//
// Autore:      SE - SDG srl
// Data:        01/01/2019
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:  
// Data:     
// Motivo:   
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using BusinessObjects;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using SDG.Utility;
using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace GestioneUtenti.Web.Common
{
    /// <summary>
    ///		Componente per banda in alto delle pagine.
    /// </summary>

    /// <summary>
    ///		Componente per banda in alto delle pagine.
    /// </summary>
    public partial class Top : System.Web.UI.UserControl
    {
        #region Web Control Declaration

        protected Utente objUtente;
        protected Sistema objSistema;
        protected Clienti objClienti;
        protected Utilita objUtilita;
        protected BasePage p;

        protected Dictionary<string, int> dizionarioPermessiTop;

        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isMobile"] == "1")
            {
                navbarHeader.Visible = false;
                ddlLanguage.Visible = false;
                divTitleMobile.Visible = true;
                divButtonMobile.Visible = true;
            }
            else
            {
                divButtonMobile.Visible = false;
                divTitleMobile.Visible = false;
            }
            
            h1TitoloApplicazione.InnerHtml = BasePage.getDizionarioUI("NOME_APPLICAZIONE");
            logo.Attributes["title"] = BasePage.getDizionarioUI("TORNA_HOME_PAGE");

            if (Session["IMPERSONATE"] != null)
            {
                if (Session["IMPERSONATE"].ToString() == "1")
                    LinkBackAdmin.Visible = true;
            }
            
            dizionarioPermessiTop = (Dictionary<string, int>)Session["dizionarioPermessi"];            
        }
        #endregion

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            InitializeMyComponents();

            p = this.Page as BasePage;
            objUtente = new Utente();
            objSistema = new Sistema();
            objClienti = new Clienti();
            objUtilita = new Utilita();

            base.OnInit(e);
        }

        private void InitializeMyComponents()
        {
            this.PreRender += new System.EventHandler(this.frm_TOP_PreRender);
        }
        #endregion

        #region Web Form Event Handlers

        protected void LinkLogout_Click(object sender, EventArgs e)
        {            
            BasePageMaster.wsLogout();
            //Remove form authentication ticket.
            //Delete the users auth cookie and sign out
            FormsAuthentication.SignOut();
            Response.Redirect("../Login/frm_LGN.aspx", false);
        }

        /// <summary>
        /// Link al form di cambio password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkCambioPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login/frm_PWD.aspx?SCADUTA=NO", false);
        }

        protected void LinkBackAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                objUtente.Read(" WHERE UTE_ID_UTENTE = " + Convert.ToInt32(Session["UTE_ID_UTENTE_LAST"].ToString()));
                Session["UTE_ID_UTENTE"] = objUtente.Ute_id_utente.ToString();
                Session["UTE_COGNOME"] = objUtente.Ute_cognome.ToString();
                Session["UTE_NOME"] = objUtente.Ute_nome.ToString();
                Session["UTE_SIGLA"] = objUtente.Ute_sigla.ToString();
                Session["CLI_ID_CLIENTE"] = objUtente.Cli_id_cliente.ToString();
                Session["IMPERSONATE"] = "0";

                Dictionary<string, int> dizionarioPermessi = objUtente.BuildPermissions();
                Session["dizionarioPermessi"] = dizionarioPermessi;
                
                string strScript = @"<script type='text/javascript'>
                                        self.location.href='/Web/Home/mainpage.aspx';
                                     </script>";

                if (!Page.ClientScript.IsClientScriptBlockRegistered("Alert_JS"))
                {
                   Page.ClientScript.RegisterClientScriptBlock(GetType(), "Alert_JS", strScript);
                }
                
            }
            catch (Exception ex)
            {
                // Gestione messaggistica all'utente e trace in DB dell'errore
                if (!ex.Data.Contains("Class.Method"))
                {
                    ex.Data.Add("Class.Method", "Web_frm_MSU_CDC.ButtonSalva_Click.");
                }
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }
        #endregion

        #region Web Form PreRender
        private void frm_TOP_PreRender(object sender, EventArgs e)
        {
            try
            {
                objUtente.Ute_id_utente = Convert.ToInt32(Session["UTE_ID_UTENTE"]);
                objUtente.Read();
                UtenteCollegato.Text = "<i class='ti-user'></i> " + objUtente.Ute_cognome.ToString() + " " + objUtente.Ute_nome.ToString();
                LinkLogout.Text = "<i class='fa fa-power-off'></i> Logout";
                LinkCambioPassword.Text = "<i class='fa fa-refresh'></i> Cambio Password";
                ultimoAccesso.Text = "<i class='fa fa-calendar-alt'></i> " + objUtente.Ute_ultimo_accesso.ToString();
                LinkBackAdmin.Text = "<i class='fa fa-exchange'></i> Torna Utente Originale";

                #region Button Help
                //string chiamata;
                ////Bottone Help
                //StringBuilder helpHref = new StringBuilder(300);
                //helpHref.Append("../help/frm_HLP.aspx?PAGINA=");
                //helpHref.Append(this.Page.GetType().BaseType.Name);
                //helpHref.Append("&NAZ_ID_NAZIONE=" + p.qNAZ_ID_NAZIONE.ToString());
                //helpHref.Append("&KeepThis=true&TB_iframe=true&height=600&width=800&modal=true");
                //ButtonHelp.Text = p.GetValueDizionarioUI("BTN_HELP");
                //ButtonHelp.ToolTip = p.GetValueDizionarioUI("BTN_HELP");
                //chiamata = "javascript:tb_show('','" + helpHref.ToString() + "', undefined, '' );return false;";
                //ButtonHelp.Attributes["onClick"] = chiamata;

                //ButtonHelpTop.Attributes["onClick"] = chiamata;
                //ButtonHelpTop.ToolTip = p.GetValueDizionarioUI("BTN_HELP");
                //ButtonHelpTop.Text = p.GetValueDizionarioUI("BTN_HELP");
                #endregion
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }

        #endregion
    }
}
