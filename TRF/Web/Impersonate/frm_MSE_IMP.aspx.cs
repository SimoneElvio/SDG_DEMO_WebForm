#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    SDG_DEMO
// Nome File:   frm_MSE_IMP.aspx.cs
//
// Namespace:   
// Descrizione: Classe di CodeBehind della pagina
//
// Autore:      SE - SDG srl
// Data:        02/03/2018
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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using System.Collections.Generic;

public partial class Web_frm_MSE_IMP : BasePage
{
    #region Web Form Control declarations
    
    protected Utente objUtente;
    protected Clienti objClienti;
    public int idCliente;
    public string whereClause = string.Empty;

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        PanelUpload.Visible = true;                
        SetPageControlAccess();

        BaseEnableControls(Page.Controls, allowEdit);

        if (!IsPostBack)
        {
            LabelTitolo.InnerText = GetValueDizionarioUI("IMPERSONATE");
            LabelCliente.InnerText = GetValueDizionarioUI("CLIENTE");
            LabelUtente.InnerText = GetValueDizionarioUI("UTENTE");
            
            //Se sono amministratore posso filtrare per tutti i clienti, altrimenti filtro solo per il cliente di appartenenza
            if (dizionarioPermessi["ADM"] < objUtilita.AccessDelete)
            {
                whereClause = " WHERE CLI_ID_CLIENTE = " + Convert.ToInt32(Session["CLI_ID_CLIENTE"].ToString());
                txtCliente.Enabled = false;                
            }

            Clienti objClienti = new Clienti();
            txtCliente.DataSource = objClienti.getDdlClienti(whereClause);
            txtCliente.DataValueField = "CLI_ID_CLIENTE";
            txtCliente.DataTextField = "CLI_RAGIONE_SOCIALE";
            txtCliente.DataBind();
            txtCliente.SelectedIndex = 0;
            txtCliente_SelectedIndexChanged(null, null);            
        }        

        string js_msgCLIENTE = "var msgCLIENTE = '" + GetValueDizionarioUI("ERR_MSG_CAMPO_OBBLIGATORIO") + "'; ";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgCLIENTE", js_msgCLIENTE, true);
    }
    #endregion

    #region Access Control
    private void SetPageControlAccess()
    {
        SetPageControlAccess("IMP");
    }
    #endregion   

    #region OnInit
    override protected void OnInit(EventArgs e)
    {
        InitializeMyComponents();        
        objUtente = new Utente();
        objClienti = new Clienti();
        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        txtCliente.SelectedIndexChanged += new EventHandler(txtCliente_SelectedIndexChanged);
    }
   
    #endregion  

    #region Web Form Event Handler  

    void txtCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            objUtente.SqlWhereClause = " WHERE UTE_STATO_UTENTE = 1 AND UTE_FLAG_ELIMINATO = 0 AND CLI_ID_CLIENTE = " + txtCliente.SelectedValue;
            txtUtente.DataSource = objUtente.getListDropDownAbil();
            txtUtente.DataValueField = "UTE_ID_UTENTE";
            txtUtente.DataTextField = "UTENTE";
            txtUtente.DataBind();
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            if (!ex.Data.Contains("Class.Method"))
            {
                ex.Data.Add("Class.Method", "Web_frm_MSE_IMP.OnSelectedIndexChanged.");
            }
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    /// <summary>
    /// Alla conferma recupero le informazioni dell'utente impersonato e rimando l'utente alla Dashboard.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnImpersonaUtente_Click(object sender, EventArgs e)
    {
        try
        {
            //Memorizzo in questa sessione l'id dell'utente che sta eseguendo l'impersonate
            Session["UTE_ID_UTENTE_LAST"] = Session["UTE_ID_UTENTE"];

            //Ricavo i dati per l'impersonificazione
            objUtente.Read(" WHERE UTE_ID_UTENTE = " + txtUtente.SelectedValue);
            Session["UTE_ID_UTENTE"] = objUtente.Ute_id_utente.ToString();
            Session["UTE_COGNOME"] = objUtente.Ute_cognome.ToString();
            Session["UTE_NOME"] = objUtente.Ute_nome.ToString();
            Session["UTE_SIGLA"] = objUtente.Ute_sigla.ToString();
            Session["CLI_ID_CLIENTE"] = objUtente.Cli_id_cliente.ToString();
            Session["IS_GESTIONE_GRUPPO"] = objUtente.Ute_gestione_gruppo.Value;
            Session["IMPERSONATE"] = "1";

            Dictionary<string, int> dizionarioPermessi = objUtente.BuildPermissions();
            Session["dizionarioPermessi"] = dizionarioPermessi;

            string strScript = @"<script type='text/javascript'>                                                                                                
                                    // self.parent.location.reload();
                                    document.location.href='../Home/mainpage.aspx';
                                </script>";

            if (!this.ClientScript.IsStartupScriptRegistered("Alert_JS"))
            {
                this.ClientScript.RegisterStartupScript(GetType(), "Alert_JS", strScript);
            }
        }
        catch (Exception ex)
        {            
            // Gestione messaggistica all'utente e trace in DB dell'errore
            if (!ex.Data.Contains("Class.Method"))
            {
                ex.Data.Add("Class.Method", "Web_frm_MSE_IMP.ButtonSalva_Click.");
            }
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    #endregion
   
}

