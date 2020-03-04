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
using System.Web.UI;
using System.Web.UI.WebControls;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;

public partial class Web_CampiNascosti_frm_MSE_CNC : BasePage
{
    #region Web Form Control declarations    
    
    protected CampiNascostiCliente objCampiNascostiCliente;    
    //PAGE VARIABLES    
    protected int qCLI_ID_CLIENTE;
    protected int qCNC_ID_CAMPO;    

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        //PanelRuoloUtente.Visible = true;

        //Ripresa parametri di pagina
        qMODALITA = Request.QueryString["MODALITA"];                
        qCLI_ID_CLIENTE = Convert.ToInt32(Request.QueryString["ID_CLIENTE"]);
        qCNC_ID_CAMPO = Convert.ToInt32(Request.QueryString["CNC_ID_CAMPO"]);

        SetPageControlAccess();
        //Set controlli per i permessi
        //Prima di effettuare eventuali disabilitazioni di altro genere
        BaseEnableControls(Page.Controls, allowEdit);

        if (!IsPostBack)
        {
            LabelTitolo.InnerText = GetValueDizionarioUI("DETTAGLIO_CAMPO_NASCOSTO");
            lblNomeCampo.InnerText = GetValueDizionarioUI("NOME_CAMPO");
            lblPagina.InnerText = GetValueDizionarioUI("PAGINA");
            lblTipo.InnerText = GetValueDizionarioUI("TIPO_CAMPO");
            lblChiaveDizionario.InnerText = GetValueDizionarioUI("CHIAVE_LABEL");
            lblVisibile.InnerText = GetValueDizionarioUI("VISIBILE");
            lblObbligatorio.InnerText = GetValueDizionarioUI("OBBLIGATORIO");
            
            ButtonSalva.Text = GetValueDizionarioUI("SALVA");
            ButtonAnnulla.Text = GetValueDizionarioUI("USCITA");

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
        
        //if (!this.ClientScript.IsStartupScriptRegistered("ButtonAnnulla_Js"))
        //{
        //    this.ClientScript.RegisterStartupScript(GetType(), "ButtonAnnulla_Js", this.ButtonAnnulla_Js());
        //}        
    }
    #endregion

    #region Access Control
    private void SetPageControlAccess()
    {
        SetPageControlAccess("CLINEW");
    }
    #endregion 

    #region DataBinding
    private void BindData()
    {
        try
        {
            objCampiNascostiCliente.Read(qCNC_ID_CAMPO);
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
        objCampiNascostiCliente = new CampiNascostiCliente();
        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_MSE_CNC_PreRender);
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
            objCampiNascostiCliente.Read(qCNC_ID_CAMPO);
            objCampiNascostiCliente.Cli_id_cliente = qCLI_ID_CLIENTE;
            objCampiNascostiCliente.Cnc_nome_campo_nascosto = txtNomeCampo.Value;
            objCampiNascostiCliente.Cnc_pagina = txtPagina.Value;
            objCampiNascostiCliente.Cnc_tipo = txtTipo.Value;
            objCampiNascostiCliente.Cnc_chiave_label = txtChiaveDizionario.Value;

            if(txtVisibile.Checked)
                objCampiNascostiCliente.Cnc_flag_visibile = 1;
            else
                objCampiNascostiCliente.Cnc_flag_visibile = 0;

            if (txtObbligatorio.Checked)
                objCampiNascostiCliente.Cnc_flag_required = 1;
            else
                objCampiNascostiCliente.Cnc_flag_required = 0;

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
            txtNomeCampo.Value = (objCampiNascostiCliente.Cnc_nome_campo_nascosto.IsNull) ? (string.Empty) : (objCampiNascostiCliente.Cnc_nome_campo_nascosto.Value.ToString());
            txtPagina.Value = (objCampiNascostiCliente.Cnc_pagina.IsNull) ? (string.Empty) : (objCampiNascostiCliente.Cnc_pagina.Value.ToString());
            txtTipo.Value = (objCampiNascostiCliente.Cnc_tipo.IsNull) ? (string.Empty) : (objCampiNascostiCliente.Cnc_tipo.Value.ToString());
            txtChiaveDizionario.Value = (objCampiNascostiCliente.Cnc_chiave_label.IsNull) ? (string.Empty) : (objCampiNascostiCliente.Cnc_chiave_label.Value.ToString());
            txtVisibile.Checked = (objCampiNascostiCliente.Cnc_flag_visibile.Value == 1) ? (true) : (false);
            txtObbligatorio.Checked = (objCampiNascostiCliente.Cnc_flag_required.Value == 1) ? (true) : (false);
            
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
                    objCampiNascostiCliente.Create();
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
                    objCampiNascostiCliente.Update(qCNC_ID_CAMPO);
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
    private void frm_MSE_CNC_PreRender(object sender, EventArgs e)
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
