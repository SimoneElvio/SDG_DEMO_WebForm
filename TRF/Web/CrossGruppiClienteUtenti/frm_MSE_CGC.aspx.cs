#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti Gruppi Cliente
// Nome File:   frm_MSE_CGC.aspx
//
// Descrizione: Classe di CodeBehind della pagina
//
// Autore:      FB - SDG srl
// Data:        14/02/2019
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

public partial class Web_CrossGruppiClienteUtenti_frm_MSE_CGC : BasePage
{
    #region Web Form Control declarations    
    
    protected CrossGruppiClienteUtenti objCrossGruppiClienteUtenti;
    protected Utente objUtente;

    //PAGE VARIABLES    
    protected int qID_GRUPPO_CLIENTI;
    protected int qCGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI;
    protected int qCLI_ID_CLIENTE;

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        //PanelRuoloUtente.Visible = true;

        //Ripresa parametri di pagina
        qMODALITA = Request.QueryString["MODALITA"];
        qID_GRUPPO_CLIENTI = Convert.ToInt32(Request.QueryString["ID_GRUPPO_CLIENTI"]);
        qCGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI = Convert.ToInt32(Request.QueryString["CGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI"]);
        qCLI_ID_CLIENTE = Convert.ToInt32(Request.QueryString["CLI_ID_CLIENTE"]);

        SetPageControlAccess();
        //Set controlli per i permessi
        //Prima di effettuare eventuali disabilitazioni di altro genere
        BaseEnableControls(Page.Controls, allowEdit);

        if (!IsPostBack)
        {
            LabelTitolo.InnerText = GetValueDizionarioUI("DETTAGLIO_UTENTE");
            LabelUTE_ID_UTENTE.InnerText = GetValueDizionarioUI("UTENTE");

            objUtente.SqlWhereClause = @" AND CLI_ID_CLIENTE=" + qCLI_ID_CLIENTE + " AND ( UTE_ID_UTENTE  NOT IN (SELECT UTE_ID_UTENTE FROM CROSS_GRUPPI_CLIENTE_UTENTI WHERE GRC_ID_GRUPPI_CLIENTE = " + qID_GRUPPO_CLIENTI + ") "; 
            if(qMODALITA!="NEW")
                objUtente.SqlWhereClause+= " OR UTE_ID_UTENTE IN(SELECT UTE_ID_UTENTE FROM CROSS_GRUPPI_CLIENTE_UTENTI WHERE GRC_ID_GRUPPI_CLIENTE = " + qID_GRUPPO_CLIENTI + " AND CGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI = " + qCGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI + ")  ";

            objUtente.SqlWhereClause += ") ";

            txtUTE_ID_UTENTE.DataSource = objUtente.getListDropDown();
            txtUTE_ID_UTENTE.DataValueField = "UTE_ID_UTENTE";
            txtUTE_ID_UTENTE.DataTextField = "UTE_COGNOME_NOME";
            txtUTE_ID_UTENTE.DataBind();
            txtUTE_ID_UTENTE.Items.Insert(0, new ListItem(" ", ""));
            txtUTE_ID_UTENTE.SelectedIndex = 0;
            //if (qRUL_ID_RUOLO != 0 && qRUL_ID_RUOLO != 1)
            //{
            //    txtRUL_ID_RUOLO.SelectedValue = qRUL_ID_RUOLO.ToString();
            //}

            ButtonSalva.Text = GetValueDizionarioUI("SALVA");
            ButtonAnnulla.Text = GetValueDizionarioUI("USCITA");

            //Funzione che nasconde i campi che per questo determinato cliente non devono essere visibili.                
            showHideFields("MSE_CGC");

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
        SetPageControlAccess("CGC");
    }
    #endregion 

    #region DataBinding
    private void BindData()
    {
        try
        {
            objCrossGruppiClienteUtenti.Read(qCGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI);
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
        objCrossGruppiClienteUtenti = new CrossGruppiClienteUtenti();
        objUtente = new Utente();
        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_MSE_CGC_PreRender);
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
            objCrossGruppiClienteUtenti.Read(qCGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI);
            objCrossGruppiClienteUtenti.Grc_id_gruppi_cliente = qID_GRUPPO_CLIENTI;
            objCrossGruppiClienteUtenti.Ute_id_utente = txtUTE_ID_UTENTE.SelectedValue != string.Empty ? Convert.ToInt32(txtUTE_ID_UTENTE.SelectedValue) : SqlInt32.Null;
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
            txtUTE_ID_UTENTE.SelectedValue = (objCrossGruppiClienteUtenti.Ute_id_utente.IsNull) ? (string.Empty) : (objCrossGruppiClienteUtenti.Ute_id_utente.Value.ToString());
            
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
                    objCrossGruppiClienteUtenti.Cgc_creato_da = idLoggedUser;
                    objCrossGruppiClienteUtenti.Cgc_flag_eliminato = 0;
                    objCrossGruppiClienteUtenti.Create();
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
                    objCrossGruppiClienteUtenti.Cgc_aggiornato_da = idLoggedUser;
                    objCrossGruppiClienteUtenti.Cgc_flag_eliminato = 0;
                    objCrossGruppiClienteUtenti.Update(qCGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI);
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
    private void frm_MSE_CGC_PreRender(object sender, EventArgs e)
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
