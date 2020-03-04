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

public partial class Web_Clienti_frm_MSE_UTE_CLI : BasePage
{
    #region Web Form Control declarations
    protected Clienti objClienti;
    protected Utente objUtente;
    protected CrossUtenteCliente objCrossUtenteCliente;
   
    //PAGE VARIABLES
    protected int qCLI_ID_CLIENTE;
    protected int qCUC_ID_CROSS_UTENTE_CLIENTE;
    protected int qUTE_ID_UTENTE;
    protected string qPROVENIENZA;
    protected DataSet dsUtenti;

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //Ripresa parametri di pagina
        qMODALITA = Request.QueryString["MODALITA"];
        qPROVENIENZA = Request.QueryString["PROVENIENZA"];

        qCLI_ID_CLIENTE = Convert.ToInt32(Request.QueryString["CLI_ID_CLIENTE"]);
        qUTE_ID_UTENTE = Convert.ToInt32(Request.QueryString["UTE_ID_UTENTE"]);
        qCUC_ID_CROSS_UTENTE_CLIENTE = Convert.ToInt32(Request.QueryString["CUC_ID_CROSS_UTENTE_CLIENTE"]);

        SetPageControlAccess();

        //Set controlli per i permessi
        //Prima di effettuare eventuali disabilitazioni di altro genere
        BaseEnableControls(Page.Controls, allowEdit);

        if (!IsPostBack)
        {
            LabelCliente.InnerText = GetValueDizionarioUI("CLIENTE");
            LabelUtente.InnerText = GetValueDizionarioUI("UTENTE");
            LabelDataCreazione.InnerText = GetValueDizionarioUI("DATA_CREAZIONE");
            LabelTitolo.InnerText = GetValueDizionarioUI("CLIENTI_ASSOCIATI");
            LabelStatoCliente.InnerText = GetValueDizionarioUI("STATO");
            ButtonSalva.Text = GetValueDizionarioUI("SALVA");
            ButtonAnnulla.Text = GetValueDizionarioUI("USCITA");

            //Lookup
            Clienti objClienti = new Clienti();
            DropDownListCliente.DataSource = objClienti.getDdlClienti(" WHERE CLIENTI.CLI_FLAG_STATO = 1");
            DropDownListCliente.DataValueField = "CLI_ID_CLIENTE";
            DropDownListCliente.DataTextField = "CLI_RAGIONE_SOCIALE";
            DropDownListCliente.DataBind();
            DropDownListCliente.Items.Insert(0, new ListItem(" ", "-1"));
            DropDownListCliente.SelectedIndex = 0;
            if (qCLI_ID_CLIENTE != 0)
            {
                DropDownListCliente.SelectedValue = qCLI_ID_CLIENTE.ToString();
            }

            DropDownListUtente.DataSource = objUtente.getListDropDown();
            DropDownListUtente.DataValueField = "UTE_ID_UTENTE";
            DropDownListUtente.DataTextField = "UTE_COGNOME_NOME";
            DropDownListUtente.DataBind();
            DropDownListUtente.Items.Insert(0, new ListItem(" ", "-1"));
            DropDownListUtente.SelectedIndex = 0;
            if (qUTE_ID_UTENTE != 0)
            {
                DropDownListUtente.SelectedValue = qUTE_ID_UTENTE.ToString();                
            }

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
        }

        /*
        dsUtenti = objUtente.getListDropDownAbil();
        for (int i = 0; i < DropDownListUtente.Items.Count; i++)
        {
            foreach (DataRow dr in dsUtenti.Tables[0].Rows)
            {
                if (DropDownListUtente.Items[i].Value.CompareTo(Convert.ToString(dr["UTE_ID_UTENTE"])) == 0)
                {
                    if (!Convert.ToBoolean(dr["UTE_STATO_UTENTE"]))
                        DropDownListUtente.Items[i].Attributes["disabled"] = "disabled";
                }
            }
        }
        */
        // Campi read-only
        TextDataCreazione.Disabled = true;
        DropDownListUtente.Enabled = false;

        string js_msgCLIENTE = "var msgCLIENTE = '" + GetValueDizionarioUI("ERR_MSG_CAMPO_OBBLIGATORIO") + "';";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgCLIENTE", js_msgCLIENTE, true);

        if (!this.ClientScript.IsStartupScriptRegistered("ButtonAnnulla_Js"))
        {
            this.ClientScript.RegisterStartupScript(GetType(), "ButtonAnnulla_Js", this.ButtonAnnulla_Js());
        }

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
            
            objCrossUtenteCliente.Read(qCUC_ID_CROSS_UTENTE_CLIENTE);
            //GetValues();

            //Lookup
            if (!objCrossUtenteCliente.Cli_id_cliente.IsNull)
            {
                DropDownListCliente.SelectedValue = objCrossUtenteCliente.Cli_id_cliente.ToString();
            }

            if (!objCrossUtenteCliente.Ute_id_utente.IsNull)
            {
                DropDownListUtente.SelectedValue = objCrossUtenteCliente.Ute_id_utente.ToString();
            }

            CheckBoxStatoCliente.Checked = (objCrossUtenteCliente.Cuc_flag_stato.IsNull) ? (false) : (Convert.ToBoolean(objCrossUtenteCliente.Cuc_flag_stato.Value));
       
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
        objClienti = new Clienti();
        objUtente = new Utente();
        objCrossUtenteCliente = new CrossUtenteCliente();

        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_MSE_UTE_CLI_PreRender);
    }
    #endregion

    #region Web Form GET & SET Values
    /// <summary>
    /// Scrive i valori recuperati dal form negli attributi di classe
    /// </summary>
    private void SetValues()
    {
        //Lookup
        if (DropDownListCliente.SelectedValue != "")
        {
            objCrossUtenteCliente.Cli_id_cliente = Convert.ToInt32(DropDownListCliente.SelectedValue);
        }

        if (DropDownListUtente.SelectedValue != "")
        {
            objCrossUtenteCliente.Ute_id_utente = Convert.ToInt32(DropDownListUtente.SelectedValue);
        }

        objCrossUtenteCliente.Cuc_flag_stato = (CheckBoxStatoCliente.Checked) ? (1) : (0);        
        objCrossUtenteCliente.Ute_aggiornato_da = Convert.ToInt32(Session["UTE_ID_UTENTE"].ToString());
        objCrossUtenteCliente.Ute_creato_da = Convert.ToInt32(Session["UTE_ID_UTENTE"].ToString());
    }

    /// <summary>
    /// Ripresa valori da classe per visualizzazione in form maschera
    /// </summary>
    private void GetValues()
    {
        DropDownListCliente.SelectedValue = (objUtente.Cli_id_cliente.IsNull) ? ("") : (Convert.ToString(objUtente.Cli_id_cliente.Value));
        CheckBoxStatoCliente.Checked = (objCrossUtenteCliente.Cuc_flag_stato.IsNull) ? (false) : (Convert.ToBoolean(objCrossUtenteCliente.Cuc_flag_stato.Value));  
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
                    objCrossUtenteCliente.Create();
                    ReCalculateObjectOwner(objCrossUtenteCliente.Ute_id_utente.Value,objCrossUtenteCliente.Cli_id_cliente.Value);
                    //Response.Redirect("frm_MSE_RUL_UTE.aspx?MODALITA=EDIT&PROVENIENZA=" + qPROVENIENZA + "&UTE_ID_UTENTE=" + objRuoli_utente.Ute_id_utente + "&RUL_ID_RUOLO=" + objRuoli_utente.Rul_id_ruolo, false);
                }
                catch (Exception ex)
                {
                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Propagate Policy");
                } 
                break;

            case "EDIT":
                try
                {
                    //Creazione record relations
                    objCrossUtenteCliente.Update(qCUC_ID_CROSS_UTENTE_CLIENTE);
                    ReCalculateObjectOwner(objCrossUtenteCliente.Ute_id_utente.Value,objCrossUtenteCliente.Cli_id_cliente.Value);                                        
                }
                catch (Exception ex)
                {
                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Propagate Policy");
                }
                break;
           
        }
        if (!this.ClientScript.IsStartupScriptRegistered("CloseDialog_Js"))
        {
            this.ClientScript.RegisterStartupScript(GetType(), "CloseDialog_Js", this.CloseDialog_Js());
        }
        // Serve per risettare l'abi/disabi del Verso Divisa
        //GetValues(); 

    }
    #endregion

    #region Web Form Menu JScriptFunctions
    /// <summary>
    /// Per refresh chiamante
    /// </summary>
    /// <returns></returns>
  
    public string ButtonAnnulla_Js()
    {
        string MsgUscita = GetValueDizionarioUI("USCITA_SENZA_SALVARE");

        //Uscita con controllo sul salvataggio dei dati cambiati
        string js = @"
                <script type='text/javascript'>
				function buttonAnnulla()
				{ 
                   if ($('#form2').FormObserve_changedForm()) 
                   {    
                        if (confirm('" + @MsgUscita + @"'))
                        {                                                           
                            self.parent.hideEditorDialog();                        
                        }
                        else{
                            return false;
                        }
                   } 
                   else 
                   {                            
                        self.parent.hideEditorDialog();                                               
                        $('#ButtonClientiAssociati',parent.frames['frameContent'].document).click();                 
                   }
                   return true;
				}
				</script>";

        return js;
    }

    public string CloseDialog_Js()
    {
        string js = @"
                <script type='text/javascript'>                    
				   self.parent.hideEditorDialog();                                                          
                   $('#ButtonClientiAssociati',parent.frames['frameContent'].document).click();
				</script>";
        return js;
    }

    #endregion

    #region Web Form PreRender
    private void frm_MSE_UTE_CLI_PreRender(object sender, EventArgs e)
    {
        try
        {
            ButtonAnnulla.Attributes["onClick"] = "javascript:return buttonAnnulla()";
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion
}
