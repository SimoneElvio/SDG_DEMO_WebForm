#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   frm_MSE_RUL_UTE.aspx
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
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SDG.Utility;
using BusinessObjects;
using SDG.WorkFlow;

public partial class Web_Workflow_frm_MSE_UTE_WRF : BasePage
{
    #region Web Form Control declarations
    protected Workflow objWorkflow;
    protected Utente objUtente;
    protected CrossUtenteWorkflow objCrossUtenteWorkflow;
   
    //PAGE VARIABLES
    protected int qWRF_ID_WORKFLOW;
    protected int qUTE_ID_UTENTE;
    protected string qPROVENIENZA;
    protected DataSet dsUtenti;

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        //PanelRuoloUtente.Visible = true;

        //Ripresa parametri di pagina
        qMODALITA = Request.QueryString["MODALITA"];
        qPROVENIENZA = Request.QueryString["PROVENIENZA"];

        qWRF_ID_WORKFLOW = Convert.ToInt32(Request.QueryString["WRF_ID_WORKFLOW"]);
        qUTE_ID_UTENTE = Convert.ToInt32(Request.QueryString["UTE_ID_UTENTE"]);

        SetPageControlAccess();

        //Set controlli per i permessi
        //Prima di effettuare eventuali disabilitazioni di altro genere
        BaseEnableControls(Page.Controls, allowEdit);

        if (!IsPostBack)
        {
            LabelWorkflow.InnerText = GetValueDizionarioUI("WORKFLOW");
            LabelUtente.InnerText = GetValueDizionarioUI("UTENTE");
            LabelDataCreazione.InnerText = GetValueDizionarioUI("DATA_CREAZIONE");
            LabelTitolo.InnerText = GetValueDizionarioUI("WF_ASSOCIATI");            
            ButtonSalva.Text = GetValueDizionarioUI("SALVA");
            ButtonAnnulla.Text = GetValueDizionarioUI("USCITA");

            objUtente.Ute_id_utente = qUTE_ID_UTENTE;
            objUtente.Read();


            string sqlWhereClause = " WHERE  WRF_ID_WORKFLOW IN(SELECT WRF_ID_WORKFLOW FROM CROSS_CLIENTE_WORKFLOW WHERE CLI_ID_CLIENTE=" + objUtente.Cli_id_cliente.Value + ") ";
            sqlWhereClause += " AND  (WRF_ID_WORKFLOW NOT IN (SELECT WRF_ID_WORKFLOW FROM CROSS_UTENTE_WORKFLOW WHERE UTE_ID_UTENTE = " + qUTE_ID_UTENTE + ") ";
            //if (qMODALITA != "NEW")
            //    sqlWhereClause += " OR WRF_ID_WORKFLOW IN(SELECT WRF_ID_WORKFLOW FROM CROSS_UTENTE_WORKFLOW WHERE UTE_ID_UTENTE = " + qUTE_ID_UTENTE + " AND cuw_id_utente_workflow = " + q + ") ";
            sqlWhereClause += ") ";

            //Lookup
            txtWorkflow.DataSource = Workflow.List(sqlWhereClause);
            txtWorkflow.DataValueField = "WRF_ID_WORKFLOW";
            txtWorkflow.DataTextField = "WRF_DESCRIZIONE";
            txtWorkflow.DataBind();
            //txtWorkflow.Items.Insert(0, new ListItem(" ", "-1"));
            txtWorkflow.SelectedIndex = 0;
            if (qWRF_ID_WORKFLOW != 0)
            {
                txtWorkflow.SelectedValue = qWRF_ID_WORKFLOW.ToString();
            }
            

            txtUtente.DataSource = objUtente.getListDropDown();
            txtUtente.DataValueField = "UTE_ID_UTENTE";
            txtUtente.DataTextField = "UTE_COGNOME_NOME";
            txtUtente.DataBind();
            txtUtente.Items.Insert(0, new ListItem(" ", "-1"));
            txtUtente.SelectedIndex = 0;
            if (qUTE_ID_UTENTE != 0)
            {
                txtUtente.SelectedValue = qUTE_ID_UTENTE.ToString();                
            }

            //Funzione che nasconde i campi che per questo determinato cliente non devono essere visibili.                
            showHideFields("MSE_UTE_WRF");

            // DataBinding
            switch (qMODALITA)
            {
                case "NEW":
                    break;
                case "VIEW":
                    BindData();
                    break;
                case "EDIT":
                    BindData();
                    break;
            }


            //Registrazioni javascript                
            Page.ClientScript.RegisterStartupScript(this.GetType(), "varMODALITA", "var modalita = '" + qMODALITA + "';", true);
        }

        /*
        dsUtenti = objUtente.getListDropDownAbil();
        for (int i = 0; i < txtUtente.Items.Count; i++)
        {
            foreach (DataRow dr in dsUtenti.Tables[0].Rows)
            {
                if (txtUtente.Items[i].Value.CompareTo(Convert.ToString(dr["UTE_ID_UTENTE"])) == 0)
                {
                    if (!Convert.ToBoolean(dr["UTE_STATO_UTENTE"]))
                        txtUtente.Items[i].Attributes["disabled"] = "disabled";
                }
            }
        }
        */
        // Campi read-only
        txtDataCreazione.Disabled = true;
        txtUtente.Enabled = false;

        //string js_msgWORKFLOW = "var msgWORKFLOW = '" + GetValueDizionarioUI("ERR_MSG_CAMPO_OBBLIGATORIO") + "';";
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "msgWORKFLOW", js_msgWORKFLOW, true);

        //if (!this.ClientScript.IsStartupScriptRegistered("ButtonAnnulla_Js"))
        //{
        //    this.ClientScript.RegisterStartupScript(GetType(), "ButtonAnnulla_Js", this.ButtonAnnulla_Js());
        //}

    }
    #endregion

    #region Access Control
    private void SetPageControlAccess()
    {
        SetPageControlAccess("UTE");
    }
    #endregion 

    #region DataBinding
    private void BindData()
    {
        try
        {
            
            //if (qUTE_ID_UTENTE != 0) objCrossUtenteWorkflow.Ute_id_utente = qUTE_ID_UTENTE;
            //objCrossUtenteWorkflow.Read();
            //GetValues();

            //Lookup
            if (!objCrossUtenteWorkflow.Wrf_id_workflow.IsNull)
            {
                txtWorkflow.SelectedValue = objCrossUtenteWorkflow.Wrf_id_workflow.ToString();
            }

            if (!objCrossUtenteWorkflow.Ute_id_utente.IsNull)
            {
                txtUtente.SelectedValue = objCrossUtenteWorkflow.Ute_id_utente.ToString();
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion

    #region OnInit
    override protected void OnInit(EventArgs e)
    {
        InitializeMyComponents();
        objWorkflow = new Workflow();
        objUtente = new Utente();
        objCrossUtenteWorkflow = new CrossUtenteWorkflow();

        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_MSE_UTE_WRF_PreRender);
    }
    #endregion

    #region Web Form GET & SET Values
    /// <summary>
    /// Scrive i valori recuperati dal form negli attributi di classe
    /// </summary>
    private void SetValues()
    {
        //Lookup
        if (txtWorkflow.SelectedValue != "")
        {
            objCrossUtenteWorkflow.Wrf_id_workflow = Convert.ToInt32(txtWorkflow.SelectedValue);
        }

        if (txtUtente.SelectedValue != "")
        {
            objCrossUtenteWorkflow.Ute_id_utente = Convert.ToInt32(txtUtente.SelectedValue);
        }

        objCrossUtenteWorkflow.Ute_aggiornato_da = Convert.ToInt32(Session["UTE_ID_UTENTE"].ToString());
        objCrossUtenteWorkflow.Ute_creato_da = Convert.ToInt32(Session["UTE_ID_UTENTE"].ToString());
    }

    /// <summary>
    /// Ripresa valori da classe per visualizzazione in form maschera
    /// </summary>
    private void GetValues()
    {        
    }
    #endregion

    #region Web Form Event Handler

    protected void ButtonSalva_Click(object sender, EventArgs e)
    {
        SetValues();
        switch (qMODALITA)
        {
            case "NEW":
                try
                {
                    //Creazione record relations
                    objCrossUtenteWorkflow.Create();
                    //Response.Redirect("frm_MSE_RUL_UTE.aspx?MODALITA=EDIT&PROVENIENZA=" + qPROVENIENZA + "&UTE_ID_UTENTE=" + objRuoli_utente.Ute_id_utente + "&RUL_ID_RUOLO=" + objRuoli_utente.Rul_id_ruolo, false);
                }
                catch (Exception ex)
                {
                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Propagate Policy");
                } 
                break;
           
        }
        //if (!this.ClientScript.IsStartupScriptRegistered("CloseDialog_Js"))
        //{
        //    this.ClientScript.RegisterStartupScript(GetType(), "CloseDialog_Js", this.CloseDialog_Js());
        //}
        // Serve per risettare l'abi/disabi del Verso Divisa
        //GetValues(); 

    }
    #endregion

    #region Web Form Menu JScriptFunctions
    /// <summary>
    /// Per refresh chiamante
    /// </summary>
    /// <returns></returns>
  
    //public string ButtonAnnulla_Js()
    //{
    //    string MsgUscita = GetValueDizionarioUI("USCITA_SENZA_SALVARE");

    //    //Uscita con controllo sul salvataggio dei dati cambiati
    //    string js = @"
    //            <script type='text/javascript'>
				//function buttonAnnulla()
				//{ 
    //               if ($('#form2').FormObserve_changedForm()) 
    //               {    
    //                    if (confirm('" + @MsgUscita + @"'))
    //                    {                                                           
    //                        self.parent.hideEditorDialog();                        
    //                    }
    //                    else{
    //                        return false;
    //                    }
    //               } 
    //               else 
    //               {                            
    //                    self.parent.hideEditorDialog();                       
    //                    parent.frames['frameContent'].refreshBrowser();
    //               }
    //               return true;
				//}
				//</script>";

    //    return js;
    //}

    //public string CloseDialog_Js()
    //{
    //    string js = @"
    //            <script type='text/javascript'>                    
				//    self.parent.hideEditorDialog();                                                          
    //                parent.frames['frameContent'].document.getElementById('EffettuaRefresh').value = 1;
    //                parent.frames['frameContent'].document.getElementById('hPanelToRefresh').value = 'WORKFLOW_ASSOCIATI';
    //                parent.frames['frameContent'].refreshBrowser();                          
				//</script>";
    //    return js;
    //}

    #endregion

    #region Web Form PreRender
    private void frm_MSE_UTE_WRF_PreRender(object sender, EventArgs e)
    {
        try
        {
            //ButtonAnnulla.Attributes["onClick"] = "javascript:return buttonAnnulla()";
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion
}
