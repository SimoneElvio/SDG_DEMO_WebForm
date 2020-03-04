#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   frm_MSE_RUL.aspx
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

public partial class Web_Ruoli_frm_MSE_RUL : BasePage
{
    #region Web Form Control declarations
    protected Ruoli objRuoli;
    protected Utente objUtente;
    
    
    //PAGE VARIABLES
    protected int qRUL_ID_RUOLO;

    //Validatori
    protected RequiredFieldValidator RFVRuolo;

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        //PanelRuolo.Visible = true;
        //PanelDettaglioAzienda.Visible = false;

        //Ripresa parametri di pagina
        qMODALITA = Request.QueryString["MODALITA"];
        qRUL_ID_RUOLO = Convert.ToInt32(Request.QueryString["RUL_ID_RUOLO"]);

        SetPageControlAccess();

        //Set controlli per i permessi
        //Prima di effettuare eventuali disabilitazioni di altro genere
        BaseEnableControls(Page.Controls, allowEdit);

        if (!IsPostBack)
        {
            LabelTitolo.InnerText = GetValueDizionarioUI("DETTAGLIO") + " " + GetValueDizionarioUI("RUOLO");
            LabelTextRuolo.InnerText = GetValueDizionarioUI("RUOLO");
            LabelDataCreazione.InnerText = GetValueDizionarioUI("DATA_CREAZIONE");
            LabelDescrizione.InnerText = GetValueDizionarioUI("DESCRIZIONE");
            LabelNroMaxElementi.InnerText = GetValueDizionarioUI("NRO_MAX_ELEMENTI");

            ButtonSalva.Text = GetValueDizionarioUI("SALVA");
            ButtonAnnulla.Text = GetValueDizionarioUI("USCITA");


            //Funzione che nasconde i campi che per questo determinato cliente non devono essere visibili.                
            showHideFields("MSE_RUL");

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

        // Campi read-only
        TextDataCreazione.Disabled = true;
    }
    #endregion

    #region Access Control
    private void SetPageControlAccess()
    {
        SetPageControlAccess("RUL");
    }
    #endregion 

    #region DataBinding
    private void BindData()
    {
        try
        {
            objRuoli.Rul_id_ruolo = qRUL_ID_RUOLO;
            objRuoli.Read();
            //objDati_sensibili.Rel_id_relazione = objRelations.Rel_id_relazione;
            //objDati_sensibili.Read();
            GetValues();

            //Lookup

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
        objRuoli = new Ruoli();
        objUtente = new Utente();
       
        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_MSE_RUL_PreRender);
    }
    #endregion

    #region Web Form GET & SET Values
    /// <summary>
    /// Scrive i valori recuperati dal form negli attributi di classe
    /// </summary>
    private void SetValues()
    {
        // Testi, date e importi
        objRuoli.Rul_ruolo = txtTextRuolo.Text;
        objRuoli.Rul_assegnazione_predefinita = false;
        objRuoli.Rul_descrizione_estesa = TextAreaDescrizione.Value; 
        if(TextNroMaxElementi.Value == "")
            objRuoli.Rul_nro_max_elementi = 0;
        else
            objRuoli.Rul_nro_max_elementi = Convert.ToInt32(TextNroMaxElementi.Value);
    }

    /// <summary>
    /// Ripresa valori da classe per visualizzazione in form maschera
    /// </summary>
    private void GetValues()
    {
        // Testi
        txtTextRuolo.Text = (objRuoli.Rul_ruolo.IsNull) ? ("") : ((string)objRuoli.Rul_ruolo);
        TextAreaDescrizione.Value = (objRuoli.Rul_descrizione_estesa.IsNull) ? ("") : ((string)objRuoli.Rul_descrizione_estesa);
        TextDataCreazione.Value = (objRuoli.Rul_data_creazione.IsNull) ? ("0") : (objRuoli.Rul_data_creazione.ToString());
        TextNroMaxElementi.Value = (objRuoli.Rul_nro_max_elementi.IsNull) ? ("0") : (objRuoli.Rul_nro_max_elementi.ToString());        
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
                    objRuoli.Create();
                    Response.Redirect("frm_MSE_RUL.aspx?MODALITA=EDIT&RUL_ID_RUOLO=" + objRuoli.Rul_id_ruolo, false);
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
                    //Update record relations
                    objRuoli.Rul_id_ruolo = qRUL_ID_RUOLO;
                    objRuoli.Update();
                    Response.Redirect("frm_MSE_RUL.aspx?MODALITA=EDIT&RUL_ID_RUOLO=" + objRuoli.Rul_id_ruolo, false);
                }
                catch (Exception ex)
                {
                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Propagate Policy");
                } 
                break;
        }
        // Serve per risettare l'abi/disabi del Verso Divisa
        GetValues(); 

    }
    #endregion

    #region Web Form Menu JScriptFunctions
    /// <summary>
    /// Per refresh chiamante
    /// </summary>
    /// <returns></returns>
    public string strChiamante()
    {
        string percorso = @"frm_MSB_RUL.aspx";
        return percorso;
    }

    
    #endregion

    #region Web Form PreRender
    private void frm_MSE_RUL_PreRender(object sender, EventArgs e)
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
