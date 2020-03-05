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
using System.Web.UI;
using System.Web.UI.WebControls;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SDG.WorkFlow;

public partial class Web_Ruoli_frm_MSE_RUL_UTE : BasePage
{
    #region Web Form Control declarations
    protected Ruoli objRuoli;
    protected Utente objUtente;
    protected RuoliUtente objRuoli_utente;
    protected Workflow objWorkflow;

    //PAGE VARIABLES
    protected int qRUL_ID_RUOLO;
    protected int qUTE_ID_UTENTE;
    protected int qURL_ID_RUOLI_UTENTE;
    protected string qPROVENIENZA;
    protected DataSet dsUtenti;

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            qMODALITA = Request.QueryString["MODALITA"];
            qPROVENIENZA = Request.QueryString["PROVENIENZA"];

            qRUL_ID_RUOLO = Convert.ToInt32(Request.QueryString["RUL_ID_RUOLO"]);
            qUTE_ID_UTENTE = Convert.ToInt32(Request.QueryString["UTE_ID_UTENTE"]);

            if (Request.QueryString["URL_ID_RUOLI_UTENTE"] != null)
                qURL_ID_RUOLI_UTENTE = Convert.ToInt32(Request.QueryString["URL_ID_RUOLI_UTENTE"]);

            SetPageControlAccess();

            //Set controlli per i permessi
            //Prima di effettuare eventuali disabilitazioni di altro genere
            BaseEnableControls(Page.Controls, allowEdit);

            if (!IsPostBack)
            {
                objUtente.Ute_id_utente = qUTE_ID_UTENTE;
                objUtente.Read();

                lblRUL_ID_RUOLO.InnerText = GetValueDizionarioUI("RUOLO");
                lblUTE_ID_UTENTE.InnerText = GetValueDizionarioUI("UTENTE");
                lblURL_DATA_ASSEGNAZIONE.InnerText = GetValueDizionarioUI("DATA_CREAZIONE");
                LabelTitolo.InnerText = GetValueDizionarioUI("RUOLI");
                lblURL_STATO_RUOLO_UTENTE.InnerText = GetValueDizionarioUI("ABILITATO");
                ButtonSalva.Text = GetValueDizionarioUI("SALVA");
                ButtonAnnulla.Text = GetValueDizionarioUI("USCITA");

                //Lookup
                //Non deve essere possibile aggiungere come ruolo ad un utente qualsiasi l'utente admin
                objRuoli.SqlWhereClause = " WHERE RUL_ID_RUOLO <> 1 AND RUL_ID_RUOLO IN(SELECT RUL_ID_RUOLO FROM CROSS_CLIENTE_RUOLI WHERE CLI_ID_CLIENTE=" + objUtente.Cli_id_cliente.Value + ") ";
                objRuoli.SqlWhereClause += " AND  (RUL_ID_RUOLO NOT IN (SELECT RUL_ID_RUOLO FROM RUOLI_UTENTE WHERE UTE_ID_UTENTE = " + qUTE_ID_UTENTE + ") ";
                if (qMODALITA != "NEW")
                    objRuoli.SqlWhereClause += " OR RUL_ID_RUOLO IN(SELECT RUL_ID_RUOLO FROM RUOLI_UTENTE WHERE UTE_ID_UTENTE = " + qUTE_ID_UTENTE + " AND URL_ID_RUOLI_UTENTE = " + qURL_ID_RUOLI_UTENTE + ") ";
                objRuoli.SqlWhereClause += ") ";

                txtRUL_ID_RUOLO.DataSource = objRuoli.getListDropDown();
                txtRUL_ID_RUOLO.DataValueField = "RUL_ID_RUOLO";
                txtRUL_ID_RUOLO.DataTextField = "RUL_RUOLO";
                txtRUL_ID_RUOLO.DataBind();
                txtRUL_ID_RUOLO.Items.Insert(0, new ListItem(" ", ""));
                txtRUL_ID_RUOLO.SelectedIndex = 0;
                if (qRUL_ID_RUOLO != 0 && qRUL_ID_RUOLO!=1)
                {
                    txtRUL_ID_RUOLO.SelectedValue = qRUL_ID_RUOLO.ToString();
                }

                if (qUTE_ID_UTENTE != 0)
                    objUtente.SqlWhereClause = " AND UTE_ID_UTENTE = " + qUTE_ID_UTENTE;

                txtUTE_ID_UTENTE.DataSource = objUtente.getListDropDown();
                txtUTE_ID_UTENTE.DataValueField = "UTE_ID_UTENTE";
                txtUTE_ID_UTENTE.DataTextField = "UTE_COGNOME_NOME";
                txtUTE_ID_UTENTE.DataBind();
                txtUTE_ID_UTENTE.Items.Insert(0, new ListItem(" ", "-1"));
                txtUTE_ID_UTENTE.SelectedIndex = -1;
                if (qUTE_ID_UTENTE != 0)
                    txtUTE_ID_UTENTE.SelectedValue = qUTE_ID_UTENTE.ToString();

                //Funzione che nasconde i campi che per questo determinato cliente non devono essere visibili.                
                showHideFields("MSE_RUL_UTE");

                // DataBinding
                switch (qMODALITA)
                {
                    case "NEW":
                        txtURL_STATO_RUOLO_UTENTE.Checked = true;
                        txtURL_STATO_RUOLO_UTENTE.Enabled = false;
                        break;
                    case "VIEW":
                        BindData();
                        ButtonAnnulla.Enabled = true;
                        break;
                    case "EDIT":
                        BindData();
                        break;
                }
            }

            if (qUTE_ID_UTENTE != 0)
                objUtente.SqlWhereClause = " WHERE UTE_ID_UTENTE = " + qUTE_ID_UTENTE;

            dsUtenti = objUtente.getListDropDownAbil();
            for (int i = 0; i < txtUTE_ID_UTENTE.Items.Count; i++)
            {
                if(txtUTE_ID_UTENTE.Items[i].Value!="-1")
                {
                    DataRow[] r = dsUtenti.Tables[0].Select(" UTE_ID_UTENTE=" + txtUTE_ID_UTENTE.Items[i].Value);
                    if (r != null)
                    {
                        if (r[0]["UTE_STATO_UTENTE"].ToString() == "False")
                        {
                            txtUTE_ID_UTENTE.Items[i].Attributes["disabled"] = "disabled";
                        }
                    }
                }
            }

            // Campi read-only
            txtURL_DATA_ASSEGNAZIONE.Disabled = true;

            switch (qPROVENIENZA)
            {
                case "RUL":
                    txtRUL_ID_RUOLO.Enabled = false;
                    if (qUTE_ID_UTENTE != 0) txtUTE_ID_UTENTE.Enabled = false;
                    break;
                case "UTE":
                    txtUTE_ID_UTENTE.Enabled = false;
                    if (qRUL_ID_RUOLO != 0) txtRUL_ID_RUOLO.Enabled = false;
                    break;
            }

            //Registrazioni javascript                
            Page.ClientScript.RegisterStartupScript(this.GetType(), "varMODALITA", "var modalita = '" + qMODALITA + "';", true);
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }

    }
    #endregion

    #region Access Control
    private void SetPageControlAccess()
    {
        SetPageControlAccess("UTERUL");
    }
    #endregion 

    #region DataBinding
    private void BindData()
    {
        try
        {
            if (qRUL_ID_RUOLO != 0) objRuoli_utente.Rul_id_ruolo = qRUL_ID_RUOLO;
            if (qUTE_ID_UTENTE != 0) objRuoli_utente.Ute_id_utente = qUTE_ID_UTENTE;
            if (qURL_ID_RUOLI_UTENTE != 0) objRuoli_utente.Url_id_ruoli_utente = qURL_ID_RUOLI_UTENTE;
            objRuoli_utente.Read();
            GetValues();

            //Lookup
            if (!objRuoli_utente.Rul_id_ruolo.IsNull)
            {
                txtRUL_ID_RUOLO.SelectedValue = objRuoli_utente.Rul_id_ruolo.ToString();
            }

            if (!objRuoli_utente.Ute_id_utente.IsNull)
            {
                txtUTE_ID_UTENTE.SelectedValue = objRuoli_utente.Ute_id_utente.ToString();
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
        objRuoli = new Ruoli();
        objUtente = new Utente();
        objRuoli_utente = new RuoliUtente();
        objWorkflow = new Workflow();

        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_MSE_RUL_UTE_PreRender);
    }
    #endregion

    #region Web Form GET & SET Values
    /// <summary>
    /// Scrive i valori recuperati dal form negli attributi di classe
    /// </summary>
    private void SetValues()
    {
        //Lookup
        if (txtRUL_ID_RUOLO.SelectedValue != "")
        {
            objRuoli_utente.Rul_id_ruolo = Convert.ToInt32(txtRUL_ID_RUOLO.SelectedValue);
        }

        if (txtUTE_ID_UTENTE.SelectedValue != "")
        {
            objRuoli_utente.Ute_id_utente = Convert.ToInt32(txtUTE_ID_UTENTE.SelectedValue);
        }

        objRuoli_utente.Url_stato_ruolo_utente = (txtURL_STATO_RUOLO_UTENTE.Checked) ? (true) : (false);
        objRuoli_utente.Ute_id_utente_aggiornato = Convert.ToInt32(Session["UTE_ID_UTENTE"].ToString());
        objRuoli_utente.Ute_id_utente_creato = Convert.ToInt32(Session["UTE_ID_UTENTE"].ToString());
        if (qURL_ID_RUOLI_UTENTE != 0) objRuoli_utente.Url_id_ruoli_utente = qURL_ID_RUOLI_UTENTE;
    }

    /// <summary>
    /// Ripresa valori da classe per visualizzazione in form maschera
    /// </summary>
    private void GetValues()
    {
        // Testi
        txtURL_DATA_ASSEGNAZIONE.Value = (objRuoli_utente.Url_data_assegnazione.IsNull) ? ("") : (objRuoli_utente.Url_data_assegnazione.ToString());
        txtURL_STATO_RUOLO_UTENTE.Checked = (objRuoli_utente.Url_stato_ruolo_utente.IsNull) ? (false) : (objRuoli_utente.Url_stato_ruolo_utente.Value);
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
                    objRuoli_utente.Url_data_assegnazione = DateTime.Now;
                    objRuoli_utente.Create();
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
                    if (!txtURL_STATO_RUOLO_UTENTE.Checked)
                        objRuoli_utente.Url_data_disabilitazione = DateTime.Now;

                    objRuoli_utente.Update();
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

    }

    #endregion

    #region Web Form Menu JScriptFunctions
    /// <summary>
    /// Per refresh chiamante
    /// </summary>
    /// <returns></returns>
    public string strChiamante()
    {
        string percorso = "";

        switch (qPROVENIENZA)
        {
            case "RUL":
                percorso = @"frm_MSB_RUL.aspx?PANEL=PanelUtentiRuolo&RUL_ID_RUOLO=" + qRUL_ID_RUOLO.ToString();
                break;
            case "UTE":
                percorso = @"../Utenti/frm_MSB_UTE.aspx?PANEL=PanelRuoliUtente&UTE_ID_UTENTE=" + qUTE_ID_UTENTE.ToString();
                break;
        }

        return percorso;
    }

    public string CloseDialog_Js()
    {
        string js = @"
                <script type='text/javascript'>                    
				    self.parent.hideEditorDialog();                                                          
                    $('#ButtonRuoli',parent.frames['frameContent'].document).click();
				</script>";
        return js;
    }

    #endregion

    #region Web Form PreRender
    private void frm_MSE_RUL_UTE_PreRender(object sender, EventArgs e)
    {
        try
        {
            // ...
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion
}
