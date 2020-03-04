#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    SDG_DEMO
// Nome File:   frm_MSE_PAU.aspx
//
// Descrizione: Classe di CodeBehind della pagina
//
// Autore:      SE - SDG srl
// Data:        15/05/2019
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
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using System.Web.UI.HtmlControls;

public partial class Web_ProcessoAutorizzativo_frm_MSE_PAU : BasePage
{
    #region Web Form Control declarations    

    protected Utente objUtente;

    //PAGE VARIABLES    
    protected int qID_TABELLA_PADRE;
    protected string qTABELLA_PADRE;
    protected int qTRY_ID_TRAVEL_POLICY;

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        //Ripresa parametri di pagina
        qMODALITA = Request.QueryString["MODALITA"];
        qID_TABELLA_PADRE = Convert.ToInt32(Request.QueryString["ID_TABELLA_PADRE"]);
        qTABELLA_PADRE = Request.QueryString["TABELLA_PADRE"];
        qTRY_ID_TRAVEL_POLICY = Convert.ToInt32(Request.QueryString["TRY_ID_TRAVEL_POLICY"]);

        if (qTABELLA_PADRE == "CLIENTI")
        {
            idCliente = qID_TABELLA_PADRE;
            hidCliente.Value = qID_TABELLA_PADRE.ToString();
        }
        else
        {
            idCliente = Convert.ToInt32(Request.QueryString["CLI_ID_CLIENTE"]);
            hidCliente.Value = idCliente.ToString();
        }


        SetPageControlAccess();
        //Set controlli per i permessi
        //Prima di effettuare eventuali disabilitazioni di altro genere
        BaseEnableControls(Page.Controls, allowEdit);

        if (!IsPostBack)
        {
            ButtonSalva.Text = GetValueDizionarioUI("SALVA");
            ButtonAnnulla.Text = GetValueDizionarioUI("USCITA");
            
            //Funzione che nasconde i campi che per questo determinato cliente non devono essere visibili.                
            showHideFields("MSE_PAU");

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

            LabelTitolo.InnerText = GetValueDizionarioUI("PROCESSO_AUTORIZZATIVO") + ": " + objUtente.Ute_cognome.ToString() + " " + objUtente.Ute_nome.ToString();
        }

        //Registrazioni javascript                
        Page.ClientScript.RegisterStartupScript(this.GetType(), "varMODALITA", "var modalita = '" + qMODALITA + "';", true);
    }
    #endregion

    #region Access Control
    private void SetPageControlAccess()
    {
        SetPageControlAccess("PAU");
    }
    #endregion 

    #region DataBinding
    private void BindData()
    {
        try
        {
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
        objUtente = new Utente();
        
        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_MSE_PAU_PreRender);
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
            if (radio1.Checked == true)
            {
                objUtente.Ute_processo_autorizzativo_liv_1 = Convert.ToInt32(radio1.Value);
                objUtente.Ute_processo_autorizzativo_liv_2 = 0;
            }

            if (radio2.Checked == true)
            {
                objUtente.Ute_processo_autorizzativo_liv_1 = Convert.ToInt32(radio2.Value);
                if (radio3.Checked == true)
                {
                    objUtente.Ute_processo_autorizzativo_liv_2 = Convert.ToInt32(radio3.Value);
                }
                if (radio4.Checked == true)
                {
                    objUtente.Ute_processo_autorizzativo_liv_2 = Convert.ToInt32(radio4.Value);
                }
            }
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
            objUtente.Ute_id_utente = qID_TABELLA_PADRE;
            objUtente.ReadProcessoAutorizzativo();

            if(objUtente.Ute_processo_autorizzativo_liv_1 == 1)
                radio1.Checked = true;
            if (objUtente.Ute_processo_autorizzativo_liv_1 == 2)
                radio2.Checked = true;
            
            if (objUtente.Ute_processo_autorizzativo_liv_2 == 3)
                radio3.Checked = true;
            if (objUtente.Ute_processo_autorizzativo_liv_2 == 4)
                radio4.Checked = true;

            // hStelleMassime.Value = (objUtente.Try_stelle_massime_hotel.IsNull) ? string.Empty : objUtente.Try_stelle_massime_hotel.Value.ToString();
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
            case "EDIT":
                try
                {
                    objUtente.Ute_aggiornato_da = idLoggedUser;
                    objUtente.Ute_id_utente = qID_TABELLA_PADRE;
                    objUtente.UpdateProcessoAutorizzativo();                    
                }
                catch (Exception ex)
                {
                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Propagate Policy");
                }
                break;

        }
    }

    #endregion

    #region method ajax

    [System.Web.Services.WebMethod()]
    public static int checkProcessoAutorizzativo(int idUtente)
    {
        int returnValue = 0;
        Utente objUtente = new Utente();
        try
        {
            objUtente.Ute_id_utente = idUtente;
            objUtente.ReadProcessoAutorizzativo();

            if (objUtente.Ute_processo_autorizzativo_liv_1 == 1)
                returnValue = 1;
            else if(objUtente.Ute_processo_autorizzativo_liv_1 == 2)
            {
                if (objUtente.Ute_processo_autorizzativo_liv_2 == 3)
                    returnValue = 3;
                else if (objUtente.Ute_processo_autorizzativo_liv_2 == 4)
                    returnValue = 4;
            }            
        }
        catch (Exception ex)
        {
            string foo = ex.Message;
        }
        return returnValue;
    }

    #endregion region

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
    private void frm_MSE_PAU_PreRender(object sender, EventArgs e)
    {
        try
        {
            //HtmlGenericControl jScriptServizi = new HtmlGenericControl("script");
            //jScriptServizi.Attributes.Add("type", "text/javascript");
            //jScriptServizi.Attributes.Add("src", BundleHelper.InsertFile("../TravelPolicy/frm_MSE_TRY.js"));
            //this.Page.FindControl("Script$scriptJS").Controls.Add(jScriptServizi);


            HtmlGenericControl jScriptJqueryMask = new HtmlGenericControl("script");
            jScriptJqueryMask.Attributes.Add("type", "text/javascript");
            jScriptJqueryMask.Attributes.Add("src", BundleHelper.InsertFile("../assets/plugins/jquery-mask/jquery.mask.js"));
            this.Page.FindControl("Script$scriptJS").Controls.Add(jScriptJqueryMask);


            HtmlGenericControl jScriptValidation = new HtmlGenericControl("script");
            jScriptValidation.Attributes.Add("type", "text/javascript");
            jScriptValidation.Attributes.Add("src", BundleHelper.InsertFile("../JScript/jquery.validate.js"));
            this.Page.FindControl("Script$scriptJS").Controls.Add(jScriptValidation);
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion

    #region WebMethod

    #endregion

}
