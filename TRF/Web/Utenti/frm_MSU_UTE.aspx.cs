#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Risolvo
// Nome File:   frm_MSU_UTE.aspx.cs
//
// Namespace:   
// Descrizione: Classe di CodeBehind della pagina
//
// Autore:      SE - SDG srl
// Data:        15/10/2018
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
using System.IO;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using System.Data;
using System.Text;

public partial class Web_frm_MSU_UTE : BasePage
{
    #region Web Form Control declarations
    //protected LogUploadFile objLogUploadFile;
    protected Utente objUtente;
    protected Clienti objClienti;
    protected Ruoli objRuoli;
    protected string CLI_ACRONIMO_CLIENTE = string.Empty;
        
    //private WorkflowManager _workflowManager;
    
    //PAGE VARIABLES
    protected int qLUF_ID_LOG_UPLOAD_FILE;     
    protected int CountCsvRows=0;
    protected string ResultValidazioneDati = string.Empty;

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        //Ripresa parametri di pagina
        qMODALITA = Request.QueryString["MODALITA"];
        
        SetPageControlAccess();

        //Set controlli per i permessi
        //Prima di effettuare eventuali disabilitazioni di altro genere
        BaseEnableControls(Page.Controls, allowEdit);

        if (!IsPostBack)
        {
            LabelTitolo.InnerText = GetValueDizionarioUI("DETTAGLIO");
            LabelFile.InnerText = GetValueDizionarioUI("SELEZ_FILE");
            LabelCliente.InnerText = GetValueDizionarioUI("CLIENTE");

            ButtonSalva.Text = GetValueDizionarioUI("CARICA");
            ButtonAnnulla.Text = GetValueDizionarioUI("USCITA");
            
            // Cliente - se diverso da Admin la tendina visualizza solo il proprio cliente
            string whereClause = "";
            if(Convert.ToInt32(Session["UTE_ID_UTENTE"]) != 1)
            {
                Clienti objClienti = new Clienti();
                objClienti.RicavaClienteUtente(Convert.ToInt32(Session["UTE_ID_UTENTE"]));
                whereClause = " WHERE CLI_ID_CLIENTE = " + objClienti.Cli_id_cliente;
            }
            txtCliente.DataSource = objClienti.getDdlClienti(whereClause);
            txtCliente.DataValueField = "CLI_ID_CLIENTE";
            txtCliente.DataTextField = "CLI_RAGIONE_SOCIALE";
            txtCliente.DataBind();
            txtCliente.SelectedIndex = 0;
        }

        // Campi read-only        

        string js_msgFILE = "var msgFILE = '" + GetValueDizionarioUI("ERR_MSG_CAMPO_OBBLIGATORIO") + "'; ";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgFILE", js_msgFILE, true);

        string js_msgFILE_EXT = "var msgFILE_EXT = '" + GetValueDizionarioUI("ERR_MSG_FILE_EXT_TXT") + "'; ";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgFILE_EXT", js_msgFILE_EXT, true);

        string js_msgCLIENTE = "var msgCLIENTE = '" + GetValueDizionarioUI("ERR_MSG_CAMPO_OBBLIGATORIO") + "'; ";
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

    #endregion

    #region OnInit
    override protected void OnInit(EventArgs e)
    {
        InitializeMyComponents();        
        objUtente = new Utente();
        objClienti = new Clienti();
        objRuoli = new Ruoli();
        objUtente.getAcronimoInstallazioneUtente(Convert.ToInt32(Session["UTE_ID_UTENTE"].ToString()));
        Session["ACRONIMO_INSTALLAZIONE"] = objUtente.Tpi_acronimo.ToString();
        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_PreRender);
    }
    #endregion

    #region Web Form GET & SET Values
    /// <summary>
    /// Scrive i valori recuperati dal form negli attributi di classe
    /// </summary>
    private void SetValues()
    {
        // Testi, date e importi
        //objRuoli.Rul_ruolo = TextRuolo.Value;
        //objRuoli.Rul_assegnazione_predefinita = false;

        //TextArea
        //Flag
        //Lookup

    }

    /// <summary>
    /// Ripresa valori da classe per visualizzazione in form maschera
    /// </summary>
    private void GetValues()
    {
        // Testi
        //TextRuolo.Value = (objRuoli.Rul_ruolo.IsNull) ? ("") : ((string)objRuoli.Rul_ruolo);
        //TextDataCreazione.Value = (objRuoli.Rul_data_creazione.IsNull) ? ("0") : (objRuoli.Rul_data_creazione.ToString());
    }
    #endregion

    #region Web Form Event Handler
   
    protected void ButtonSalva_Click(object sender, EventArgs e)
    {        
        try
        {
            if (FileUploadUtente.HasFile)
            {
                string fileExt = System.IO.Path.GetExtension(FileUploadUtente.FileName).ToLower();
                string fileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(FileUploadUtente.FileName);
                string dirPath = Page.Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Web\Utenti\Files\";
                string percorso = dirPath + fileNameWithoutExt + fileExt;
                
                //Controllo se esiste già un file con questo nome. Se esiste lo elimino.
                if (File.Exists(percorso))
                {
                    File.Delete(percorso);
                }
                
                FileUploadUtente.SaveAs(percorso);
                
                //Chiamo la stored procedure che fa il match degli utenti importati con gli utenti del sistema.                
                objUtente.Cli_id_cliente = Convert.ToInt32(txtCliente.SelectedValue);
                objUtente.spUpload_Utenti(Convert.ToInt32(Session["UTE_ID_UTENTE"]));
                
                if (objUtente.StrReturn.ToString() == "ERR")
                {
                    DataSet DsData;
                    DsData = objUtente.ListError(Convert.ToInt32(Session["UTE_ID_UTENTE"]));

                    StringBuilder sbErr = new StringBuilder();

                    foreach (DataRow ElencoRighe in DsData.Tables["UTENTI_IMPORT_LOG"].Rows)
                    {
                        sbErr.Append(ElencoRighe["COGNOME"].ToString() + " " + ElencoRighe["NOME"].ToString() + " - " + ElencoRighe["ERRORE"].ToString() + "<br />");
                    }
                    LabelResult.InnerHtml = sbErr.ToString();
                    LabelResult.Attributes["class"] = "col-md-12 alert alert-danger";
                }
                else
                {
                    LabelResult.InnerHtml = "File <b>'" + fileNameWithoutExt + "'</b> caricato con successo.<br>Dimensione file: " + FileUploadUtente.PostedFile.ContentLength + " byte.";
                    LabelResult.Attributes["class"] = "col-md-12 alert alert-success";
                }                

                // Rimuovo il file dal server
                if (File.Exists(percorso))
                {
                    File.Delete(percorso);
                }
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.IndexOf("Riga") != -1)
            {
                LabelResult.InnerHtml = getDizionarioUI("ERR_MSG_FILE_NOT_IMPORTED") + "<br/><br/>" + ex.Message;
                LabelResult.Attributes["class"] = "col-md-12 alert alert-danger";
            }
            else
            {
                // Gestione messaggistica all'utente e trace in DB dell'errore
                if (!ex.Data.Contains("Class.Method"))
                {
                    ex.Data.Add("Class.Method", "Web_frm_MSU_UTE.ButtonSalva_Click.");
                }
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }
    }
    
    #endregion
    
    #region Web Form Menu JScriptFunctions
    /// <summary>
    /// Per refresh chiamante
    /// </summary>
    /// <returns></returns>
    public string strChiamante()
    {
        string percorso = @"frm_MSU_UTE.aspx";
        return percorso;
    }

    public string ButtonAnnulla_Js()
    {
        string MsgUscita = GetValueDizionarioUI("USCITA_SENZA_SALVARE");

        //Uscita con controllo sul salvataggio dei dati cambiati
        string js = @"
                <script type='text/javascript' >
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
                        $('#hPanelToRefresh',parent.frames['frameContent'].document).val('UTENTE');
                        $('#btnSubmit',parent.frames['frameContent'].document).click();      
                   }
                   return true;
				}
				</script>";

        return js;
    }

    #endregion

    #region Web Form PreRender
    private void frm_PreRender(object sender, EventArgs e)
    {
        try
        {
            ButtonAnnulla.Attributes["onClick"] = "javascript:return buttonAnnulla();return false;";
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion
}

