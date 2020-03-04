#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Ruoli Cliente
// Nome File:   frm_MSE_CCR.aspx
//
// Descrizione: Classe di CodeBehind della pagina
//
// Autore:      FB - SDG srl
// Data:        19/09/2018
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:  
// Data:     
// Motivo:   
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using System.Data.SqlTypes;

public partial class Web_LookupSocietaCliente_frm_MSE_LSL : BasePage
{
    #region Web Form Control declarations    
    
    protected LookupSocietaCliente objLookupSocietaCliente;
    protected Ruoli objRuoli;

    //PAGE VARIABLES    
    protected int qCLI_ID_CLIENTE;
    protected int qLSL_ID_SOCIETA_CLIENTE;    

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        //PanelRuoloUtente.Visible = true;

        //Ripresa parametri di pagina
        qMODALITA = Request.QueryString["MODALITA"];                
        qCLI_ID_CLIENTE = Convert.ToInt32(Request.QueryString["ID_CLIENTE"]);
        qLSL_ID_SOCIETA_CLIENTE = Convert.ToInt32(Request.QueryString["LSL_ID_SOCIETA_CLIENTE"]);

        SetPageControlAccess();
        //Set controlli per i permessi
        //Prima di effettuare eventuali disabilitazioni di altro genere
        BaseEnableControls(Page.Controls, allowEdit);

        if (!IsPostBack)
        {
            LabelTitolo.InnerText = GetValueDizionarioUI("DETTAGLIO_SOCIETA_CLIENTE");
            LabelDescrizione.InnerText = GetValueDizionarioUI("DESCRIZIONE");
            LabelFlagEliminato.InnerText = GetValueDizionarioUI("ELIMINATA");
            LabelSigla.InnerText = GetValueDizionarioUI("SIGLA");


            //objRuoli.SqlWhereClause = @" WHERE RUL_ID_RUOLO <> 1 AND RUL_ID_RUOLO NOT IN (SELECT RUL_ID_RUOLO FROM CROSS_CLIENTE_RUOLI WHERE CLI_ID_CLIENTE = " + qCLI_ID_CLIENTE + ") "; 
            //if(qMODALITA!="NEW")
            //    objRuoli.SqlWhereClause+= " OR RUL_ID_RUOLO IN(SELECT RUL_ID_RUOLO FROM CROSS_CLIENTE_RUOLI WHERE CLI_ID_CLIENTE = " + qCLI_ID_CLIENTE + " AND LSL_ID_SOCIETA_CLIENTE = " + qLSL_ID_SOCIETA_CLIENTE + ") ";

            //txtRUL_ID_RUOLO.DataSource = objRuoli.getListDropDown();
            //txtRUL_ID_RUOLO.DataValueField = "RUL_ID_RUOLO";
            //txtRUL_ID_RUOLO.DataTextField = "RUL_RUOLO";
            //txtRUL_ID_RUOLO.DataBind();
            //txtRUL_ID_RUOLO.Items.Insert(0, new ListItem(" ", ""));
            //txtRUL_ID_RUOLO.SelectedIndex = 0;
            //if (qRUL_ID_RUOLO != 0 && qRUL_ID_RUOLO != 1)
            //{
            //    txtRUL_ID_RUOLO.SelectedValue = qRUL_ID_RUOLO.ToString();
            //}

            ButtonSalva.Text = GetValueDizionarioUI("SALVA");
            ButtonAnnulla.Text = GetValueDizionarioUI("USCITA");

            //Funzione che nasconde i campi che per questo determinato cliente non devono essere visibili.                
            showHideFields("MSE_CCR");

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

        //Registrazioni javascript                
        Page.ClientScript.RegisterStartupScript(this.GetType(), "varMODALITA", "var modalita = '" + qMODALITA + "';", true);
    }
    #endregion

    #region Access Control
    private void SetPageControlAccess()
    {
        SetPageControlAccess("LSL");
    }
    #endregion 

    #region DataBinding
    private void BindData()
    {
        try
        {
            objLookupSocietaCliente.Read(qLSL_ID_SOCIETA_CLIENTE);
            GetValues();                       
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
        objLookupSocietaCliente = new LookupSocietaCliente();
        objRuoli = new Ruoli();
        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_MSE_LSL_PreRender);
        //Qui mi serve avere il tipo.        
    }
    #endregion

    #region Web Form GET & SET Values
    /// <summary>
    /// Scrive i valori recuperati dal form negli attributi di classe
    /// </summary>
    private void SetValues()
    {
        try
        {
            objLookupSocietaCliente.Read(qLSL_ID_SOCIETA_CLIENTE);
            objLookupSocietaCliente.Cli_id_cliente = qCLI_ID_CLIENTE;
            objLookupSocietaCliente.Lsl_descrizione = txtDescrizione.Value != string.Empty ? txtDescrizione.Value : SqlString.Null;
            objLookupSocietaCliente.Lsl_sigla= txtSigla.Value != string.Empty ? txtSigla.Value : SqlString.Null;
            objLookupSocietaCliente.Lsl_flag_eliminato = txtFlagEliminato.Checked?1:0;
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }

    }

    /// <summary>
    /// Ripresa valori da classe per visualizzazione in form maschera
    /// </summary>
    private void GetValues()
    {
        try
        {
            // Testi       
            txtDescrizione.Value = (objLookupSocietaCliente.Lsl_descrizione.IsNull) ? (string.Empty) : (objLookupSocietaCliente.Lsl_descrizione.Value.ToString());
            txtSigla.Value = (objLookupSocietaCliente.Lsl_sigla.IsNull) ? (string.Empty) : (objLookupSocietaCliente.Lsl_sigla.Value.ToString());
            txtFlagEliminato.Checked = (objLookupSocietaCliente.Lsl_flag_eliminato.Value == 1) ? (true) : (false);
            
       }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
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
                    objLookupSocietaCliente.Lsl_id_creato_da = idLoggedUser;
                    objLookupSocietaCliente.Create();
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
                    objLookupSocietaCliente.Lsl_id_aggiornato_da = idLoggedUser;
                    objLookupSocietaCliente.Update(qLSL_ID_SOCIETA_CLIENTE);
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
    }    

    #endregion

    #region Web Form Menu JScriptFunctions    

    //public string ButtonAnnulla_Js()
    //{
    //    string MsgUscita = GetValueDizionarioUI("USCITA_SENZA_SALVARE");

    //    //Uscita con controllo sul salvataggio dei dati cambiati
    //    string js = @"
    //            <script type='text/javascript'>
				//function buttonAnnulla()
				//{                       
    //                if ($('#form2').FormObserve_changedForm()) 
    //                { 
    //                    if (confirm('" + @MsgUscita + @"'))
    //                    {                                                           
    //                        self.parent.hideEditorDialog(); 
    //                        parent.frames['frameContent'].refreshBrowser();                       
    //                    }
    //                    else{
    //                        return false;
    //                    }   
    //                }
    //                else
    //                    self.parent.hideEditorDialog(); 
        
    //                return true;                
				//}	
				//</script>";

    //    return js;
    //}

    //public string CloseDialog_Js()
    //{
    //    string js = @"
    //            <script type='text/javascript'>                    
				//    self.parent.hideEditorDialog();                                                          
    //                parent.frames['frameContent'].refreshBrowser();
				//</script>";
    //    return js;
    //}

    #endregion

    #region Web Form PreRender
    private void frm_MSE_LSL_PreRender(object sender, EventArgs e)
    {
        try
        {
            //ButtonAnnulla.Attributes["onClick"] = "javascript:buttonAnnulla()";
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion
}
