ButtonDisconnectAll#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   frm_MSB_UTE.aspx
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe di CodeBehind della pagina
//
// Autore:      SE - SDG srl
// Data:        20/03/2018
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
using System.Web.UI.WebControls;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using System.Net.Mail;
using System.Threading;
using SDG.Utility;
using System.Web.UI.HtmlControls;

public partial class Web_Utenti_frm_MSB_UTE : BasePageBrowser
{
    #region Web Control Declaration
    protected string WhereClause = "";
    protected int permessoDEL;

    //PAGE VARIABLES
    protected string qTIPO;
    protected string qSTATUS;
    protected string qPANEL;
    protected int qUTE_ID_UTENTE;
    protected Utente objUtente;
    protected CrossUtenteWorkflow objCrossUtenteWorkflow;
    protected CrossUtenteCliente objCrossUtenteCliente;
    protected Clienti objClienti;
    protected bool allowAccessRul;
    protected bool allowDeleteRul;
    protected bool allowEditRul;
    
    
    //DIMENSIONI EDITOR
    protected string widthUtente = "500";
    protected string heightUtente = "600";

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        //Ripresa parametri di pagina
        qPANEL = Convert.ToString(Request.QueryString["PANEL"]);
        if (qPANEL == null)
            qPANEL = "";

        string id_utente = Request.QueryString["UTE_ID_UTENTE"];
        if (id_utente == null)
            qUTE_ID_UTENTE = 0;
        else
        {
            qUTE_ID_UTENTE = Convert.ToInt32(Request.QueryString["UTE_ID_UTENTE"]);
        }        

        SetPageControlAccess();
        
        // Solo ADMIN può vedere tutti gli utenti
        if (dizionarioPermessi["ADM"] == objUtilita.AccessNone)
            WhereClause = " AND UTENTE.CLI_ID_CLIENTE = " + Session["CLI_ID_CLIENTE"] + " ";
        
        ObjectDataSourceUtenti.TypeName = "SDG.GestioneUtenti.Utente";
        ObjectDataSourceUtenti.SelectMethod = "List";
        ObjectDataSourceUtenti.ObjectCreated += new ObjectDataSourceObjectEventHandler(ObjectDataSourceUtenti_SetProperties);
        ObjectDataSourceUtenti.Selected += new ObjectDataSourceStatusEventHandler(ObjectDataSourceUtenti_Selected);

        /////////////

        GridViewUtenti.PageSize = Convert.ToInt32(DropDownListRecordPagina.SelectedValue);
        
        if (!IsPostBack)
        {
            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "UTE_NOME")].HeaderText = GetValueDizionarioUI("NOME");            

            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "UTE_COGNOME")].HeaderText = GetValueDizionarioUI("COGNOME");
            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "UTE_USER_ID")].HeaderText = GetValueDizionarioUI("USER_ID");
            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "UTE_EMAIL")].HeaderText = GetValueDizionarioUI("EMAIL");
            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "CDC_DESCRIZIONE")].HeaderText = GetValueDizionarioUI("CODICE_CDC");
            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "UTE_ULTIMO_ACCESSO")].HeaderText = GetValueDizionarioUI("DATA_LOGIN");
            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "CLI_RAGIONE_SOCIALE")].HeaderText = GetValueDizionarioUI("AZIENDA");

            GridViewRuoliUtente.Columns[GridIndexOfByName(GridViewRuoliUtente, "RUL_RUOLO")].HeaderText = GetValueDizionarioUI("RUOLO");
            GridViewRuoliUtente.Columns[GridIndexOfByName(GridViewRuoliUtente, "URL_DATA_ASSEGNAZIONE")].HeaderText = GetValueDizionarioUI("DATA_ASSEGNAZIONE");
            GridViewRuoliUtente.Columns[GridIndexOfByName(GridViewRuoliUtente, "URL_DATA_DISABILITAZIONE")].HeaderText = GetValueDizionarioUI("DATA_DISABILITAZIONE");
            GridViewRuoliUtente.Columns[GetIndexByHeaderText(GridViewRuoliUtente, "URL_STATO_RUOLO_UTENTE")].HeaderText = GetValueDizionarioUI("ABILITATO");

            //Griglia degli Utente che può autorizzare l'utente selezionato.
            GridViewAutorizzati.Columns[GridIndexOfByName(GridViewAutorizzati, "UTENTE_AUTORIZZATO")].HeaderText = GetValueDizionarioUI("AUTORIZZATI");
            GridViewAutorizzati.Columns[GridIndexOfByName(GridViewAutorizzati, "LIVELLO")].HeaderText = GetValueDizionarioUI("LIVELLO");
            GridViewAutorizzati.Columns[GridIndexOfByName(GridViewAutorizzati, "CENTRO_DI_COSTO")].HeaderText = GetValueDizionarioUI("CENTRO_DI_COSTO");
            GridViewAutorizzati.Columns[GetIndexByHeaderText(GridViewAutorizzati, "CRP_FLAG_AUTORIZZATI_PRINC")].HeaderText = GetValueDizionarioUI("PRINCIPALE");

            //Griglia dei Workflow associati all'utente.
            GridViewWfAssociati.Columns[GridIndexOfByName(GridViewWfAssociati, "WRF_CODICE")].HeaderText = GetValueDizionarioUI("WORKFLOW");
            GridViewWfAssociati.Columns[GridIndexOfByName(GridViewWfAssociati, "WRF_DESCRIZIONE")].HeaderText = GetValueDizionarioUI("DESCRIZIONE_WORKFLOW");

            //Griglia dei Clienti associati all'utente.
            GridViewCliAssociati.Columns[GridIndexOfByName(GridViewCliAssociati, "CLI_RAGIONE_SOCIALE")].HeaderText = GetValueDizionarioUI("AZIENDA");

            //Label
            LabelTitolo.InnerText = GetValueDizionarioUI("UTENTI");
            LabelElemSel.InnerText = GetValueDizionarioUI("ELEMENTI_SELEZIONATI");
            LabelRecPagina.InnerText = GetValueDizionarioUI("RECORD_PAGINA");
            LabelRecPaginaRuoloUtente.InnerText = GetValueDizionarioUI("RECORD_PAGINA");
            LabelRecPaginaAutorizzati.InnerText = GetValueDizionarioUI("RECORD_PAGINA");
            LabelRecPaginaWfAssociati.InnerText = GetValueDizionarioUI("RECORD_PAGINA");
            LabelRecPaginaCliAssociati.InnerText = GetValueDizionarioUI("RECORD_PAGINA");

            //Pulsanti
            ButtonRuoli.Text = GetValueDizionarioUI("RUOLI");
            ButtonFiltroUtente.Text = GetValueDizionarioUI("FILTRO");
            ButtonNuovoUtente.InnerHtml = GetValueDizionarioUI("NUOVO");

            ButtonUploadUtenti.Text = GetValueDizionarioUI("CARICAMENTO_UTENTI");
            ButtonFiltroRuoloUtente.Text = GetValueDizionarioUI("FILTRO");
            ButtonNuovoRuoloUtente.Text = GetValueDizionarioUI("AGGIUNGI");
            ButtonFiltroAutorizzati.Text = GetValueDizionarioUI("FILTRO");
            ButtonNuovoAutorizzati.Text = GetValueDizionarioUI("AGGIUNGI");
            ButtonFiltroWfAssociati.Text = GetValueDizionarioUI("FILTRO");
            ButtonNuovoWfAssociato.Text = GetValueDizionarioUI("AGGIUNGI");
            ButtonFiltroCliAssociati.Text = GetValueDizionarioUI("FILTRO");
            ButtonNuovoCliAssociato.Text = GetValueDizionarioUI("AGGIUNGI");

            btnCerca.Text = GetValueDizionarioUI("CERCA");
            LabelCognome.InnerText = GetValueDizionarioUI("COGNOME");
            LabelNome.InnerText = GetValueDizionarioUI("NOME");
            LabelCodiceIndividuale.InnerText = GetValueDizionarioUI("CODICE_INDIVIDUALE");
            LabelEmail.InnerText = GetValueDizionarioUI("EMAIL");
            LabelOnline.InnerText = GetValueDizionarioUI("SOLO_UTENTI_ONLINE");
            LabelUserId.InnerText = GetValueDizionarioUI("USER_ID");
            LabelCliente.InnerText = GetValueDizionarioUI("AZIENDA");
            LabelPwdInviata.InnerText = GetValueDizionarioUI("PASSWORD_INVIATA");
            ButtonInviaResetPwd.Text = GetValueDizionarioUI("INVIA_PASSWORD");
            ButtonDisconnectAll.Text = GetValueDizionarioUI("DISCONNETTI_TUTTI");
            ButtonProcessoAutorizzativo.Text = GetValueDizionarioUI("PROCESSO_AUTORIZZATIVO");
            ButtonProcessoAutorizzativo.ToolTip = GetValueDizionarioUI("PROCESSO_AUTORIZZATIVO");

            Clienti objClienti = new Clienti();
            if (dizionarioPermessi["ADM"] == objUtilita.AccessNone)
            {
                if (Session["CLI_ID_CLIENTE"] != null)
                    txtCliente.DataSource = objClienti.getDdlClienti(" WHERE CLIENTI.CLI_FLAG_STATO = 1 AND CLIENTI.CLI_ID_CLIENTE = " + Session["CLI_ID_CLIENTE"]);
            }
            else
                txtCliente.DataSource = objClienti.getDdlClienti();

            txtCliente.DataValueField = "CLI_ID_CLIENTE";
            txtCliente.DataTextField = "CLI_RAGIONE_SOCIALE";
            txtCliente.DataBind();
            txtCliente.Items.Insert(0, new ListItem("", ""));

            txtPwdInviata.Items.Insert(0, new ListItem("", ""));
            txtPwdInviata.Items.Insert(1, new ListItem("No", "0"));
            txtPwdInviata.Items.Insert(2, new ListItem("Sì", "1"));

            //Modifico il nro di record per pagina
            GridViewRuoliUtente.PageSize = Convert.ToInt32(DropDownListRecPaginaRuoloUtente.SelectedValue);
            GridViewAutorizzati.PageSize = Convert.ToInt32(DropDownListRecPaginaAutorizzati.SelectedValue);
            GridViewWfAssociati.PageSize = Convert.ToInt32(DropDownListRecPaginaWfAssociati.SelectedValue);
            GridViewCliAssociati.PageSize = Convert.ToInt32(DropDownListRecPaginaCliAssociati.SelectedValue);

            GridViewUtenti.DataBind();
        }        

        //Con questo controllo posso ricaricare i pannelli con le informazioni aggiornate senza perdere i filtri.
        if (hPanelToRefresh.Value == "CLIENTI_ASSOCIATI")
            GridViewCliAssociati.DataBind();
        if (hPanelToRefresh.Value == "RUOLI_UTENTE")
            GridViewRuoliUtente.DataBind();
        if (hPanelToRefresh.Value == "WORKFLOW_ASSOCIATI")
        {
            GridViewWfAssociati.DataBind();
            if (GridViewWfAssociati.Rows.Count > 0)
            {
                ButtonNuovoWfAssociato.Visible = false;
            }
            else
            {
                ButtonNuovoWfAssociato.Visible = true;
            }
        }
            
        if (hPanelToRefresh.Value == "UTENTI_AUTORIZZATI")
            GridViewAutorizzati.DataBind();
        if (hPanelToRefresh.Value == "UTENTE")
            GridViewUtenti.DataBind();
        //**********************************************FINE*****************************************************

        permessoDEL = dizionarioPermessi["UTE"];

        //Se non ho i permessi di accesso sulla funzionalità UTENTE RUOLI disabilito il pannello
        if (dizionarioPermessi["UTERUL"] == objUtilita.AccessNone)        
            ButtonRuoli.Visible = false;

        if (allowAccess == false)
        {
            WhereClause = " WHERE 1=2 ";
        }
                
    }
    #endregion

    #region Access Control
    private void SetPageControlAccess()
    {
        //Ricavo e memorizzo i permessi di accesso dei ruoli
        SetPageControlAccess("UTERUL");
        allowAccessRul = allowAccess;
        allowDeleteRul = allowDelete;
        allowEditRul = allowEdit;
        //**********************Fine************************

        SetPageControlAccess("UTE");
    }
    #endregion 

    #region OnInit
    protected override void OnInit(EventArgs e)
    {
        InitializeMyComponents();
        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {                
        this.PreRender += new System.EventHandler(this.frm_MSB_UTE_PreRender);
        objUtente = new Utente();
        objCrossUtenteWorkflow = new CrossUtenteWorkflow();
        objCrossUtenteCliente = new CrossUtenteCliente();
        objClienti = new Clienti();
        objUtilita = new Utilita();
        objLock = new Lock();

        GridViewUtenti.DataSourceID = "ObjectDataSourceUtenti";
        string[] utentiDataKeys = { "UTE_ID_UTENTE" ,"UTE_STATO_UTENTE","ISONLINE","CLI_ID_CLIENTE" };
        GridViewUtenti.DataKeyNames = utentiDataKeys;
        GridViewUtenti.RowDataBound += new GridViewRowEventHandler(GridViewUtenti.MyGridViewDataBound);        
        GridViewUtenti.SelectedIndexChanged += new EventHandler(GridViewUtenti_SelectedIndexChanged);
        GridViewUtenti.PageIndexChanged += new EventHandler(GridViewUtenti_PageIndexChanged);
        GridViewUtenti.RowCommand += new GridViewCommandEventHandler(GridViewUtenti_RowCommand);
        GridViewUtenti.DataBound += new EventHandler(GridViewUtenti_DataBound);
        GridViewUtenti.Sorting        += new GridViewSortEventHandler(GridViewUtenti_Sorting);

        GridViewRuoliUtente.DataSourceID = "ObjectDataSourceRuoliUtente";
        string[] ruoliDataKeys = { "RUL_ID_RUOLO", "UTE_ID_UTENTE", "URL_STATO_RUOLO_UTENTE", "URL_ID_RUOLI_UTENTE" };
        GridViewRuoliUtente.DataKeyNames = ruoliDataKeys;
        GridViewRuoliUtente.RowCreated += new GridViewRowEventHandler(GridViewRuoliUtente.MyGridViewRowCreated);
        GridViewRuoliUtente.RowDataBound += new GridViewRowEventHandler(GridViewRuoliUtente.MyGridViewDataBound);
        GridViewRuoliUtente.DataBound += new EventHandler(GridViewRuoliUtente_DataBound);
        GridViewRuoliUtente.RowCommand += new GridViewCommandEventHandler(GridViewRuoliUtente_RowCommand);
        ControlParameter cpRuoliUtente = new ControlParameter("myParUteIdUtente", TypeCode.Int32, "GridViewUtenti", "SelectedValue");
        ObjectDataSourceRuoliUtente.SelectParameters.Add(cpRuoliUtente);

        GridViewAutorizzati.DataSourceID = "ObjectDataSourceAutorizzati";
        string[] AutorizzatiDataKeys = { "UTE_ID_UTENTE", "UTE_ID_UTENTE_AUTORIZZATORE", "AUI_FLAG_AUTORIZZATORE_PRINC","TIPO_AUTORIZZAZIONE" };
        GridViewAutorizzati.DataKeyNames = AutorizzatiDataKeys;
        GridViewAutorizzati.RowCreated += new GridViewRowEventHandler(GridViewAutorizzati.MyGridViewRowCreated);
        GridViewAutorizzati.RowDataBound += new GridViewRowEventHandler(GridViewAutorizzati.MyGridViewDataBound);
        GridViewAutorizzati.RowCommand += new GridViewCommandEventHandler(GridViewAutorizzati_RowCommand);
        GridViewAutorizzati.DataBound += new EventHandler(GridViewAutorizzati_DataBound);
        ControlParameter cpAutorizzatiUtente = new ControlParameter("myParUteIdUtente", TypeCode.Int32, "GridViewUtenti", "SelectedValue");
        ObjectDataSourceAutorizzati.SelectParameters.Add(cpAutorizzatiUtente);

        GridViewWfAssociati.DataSourceID = "ObjectDataSourceWfAssociati";
        string[] WfAssociatiDataKeys = { "UTE_ID_UTENTE", "CUW_ID_UTENTE_WORKFLOW" };
        GridViewWfAssociati.DataKeyNames = WfAssociatiDataKeys;
        GridViewWfAssociati.RowCreated += new GridViewRowEventHandler(GridViewWfAssociati.MyGridViewRowCreated);
        GridViewWfAssociati.RowDataBound += new GridViewRowEventHandler(GridViewWfAssociati.MyGridViewDataBound);
        GridViewWfAssociati.RowCommand += new GridViewCommandEventHandler(GridViewWfAssociati_RowCommand);
        GridViewWfAssociati.DataBound += new EventHandler(GridViewWfAssociati_DataBound);
        ControlParameter cpWorkflowUtente = new ControlParameter("myParUteIdUtente", TypeCode.Int32, "GridViewUtenti", "SelectedValue");
        ObjectDataSourceWfAssociati.SelectParameters.Add(cpWorkflowUtente);

        GridViewCliAssociati.DataSourceID = "ObjectDataSourceCliAssociati";
        string[] CliAssociatiDataKeys = { "UTE_ID_UTENTE", "CUC_ID_CROSS_UTENTE_CLIENTE" , "CUC_FLAG_STATO" , "CLI_ID_CLIENTE" };
        GridViewCliAssociati.DataKeyNames = CliAssociatiDataKeys;
        GridViewCliAssociati.RowDataBound += new GridViewRowEventHandler(GridViewCliAssociati_DataBound);
        GridViewCliAssociati.RowCommand += new GridViewCommandEventHandler(GridViewCliAssociati_RowCommand);
        ControlParameter cpClienteUtente = new ControlParameter("myParUteIdUtente", TypeCode.Int32, "GridViewUtenti", "SelectedValue");
        ObjectDataSourceCliAssociati.SelectParameters.Add(cpClienteUtente);        
        ObjectDataSourceCliAssociati.SelectParameters.Add("subWhereClause", TypeCode.String,"");

        ObjectDataSourceRuoliUtente.TypeName = "SDG.GestioneUtenti.RuoliUtente";
        ObjectDataSourceRuoliUtente.SelectMethod = "ListRuoliByUtente";
        ObjectDataSourceRuoliUtente.Selected += new ObjectDataSourceStatusEventHandler(ObjectDataSourceRuoliUtente_Selected);

        ObjectDataSourceAutorizzati.TypeName = "SDG.GestioneUtenti.Utente";
        ObjectDataSourceAutorizzati.SelectMethod = "ListUtentiByAutorizzatore";
        ObjectDataSourceAutorizzati.Selected += new ObjectDataSourceStatusEventHandler(ObjectDataSourceAutorizzati_Selected);

        ObjectDataSourceWfAssociati.TypeName = "BusinessObjects.CrossUtenteWorkflow";
        ObjectDataSourceWfAssociati.SelectMethod = "List";
        ObjectDataSourceWfAssociati.Selected += new ObjectDataSourceStatusEventHandler(ObjectDataSourceWfAssociati_Selected);

        ObjectDataSourceCliAssociati.TypeName = "BusinessObjects.CrossUtenteCliente";
        ObjectDataSourceCliAssociati.SelectMethod = "List";
        ObjectDataSourceCliAssociati.Selected += new ObjectDataSourceStatusEventHandler(ObjectDataSourceCliAssociati_Selected);

        ButtonExportUtenti.Click += new EventHandler(ButtonExportUtenti_Click);
        btnRefresh.Click += new EventHandler(btnRefresh_Click);

        //DropDownList
        GenerateDropDownListRecordPagina();
        GenerateDropDownListRecordPagina("DropDownListRecPaginaRuoloUtente");
        GenerateDropDownListRecordPagina("DropDownListRecPaginaAutorizzatori");
        GenerateDropDownListRecordPagina("DropDownListRecPaginaAutorizzati");
        GenerateDropDownListRecordPagina("DropDownListRecPaginaWfAssociati");
        GenerateDropDownListRecordPagina("DropDownListRecPaginaCliAssociati");
    }

    void ButtonExportUtenti_Click(object sender, EventArgs e)
    {
        try 
        {
            BuildWhereClause();
            DataSet ds = Utente.ListForExport(WhereClause);
            base.DataSetToExcel(ds.Tables, "UTENTE",true);
        }

        catch (ThreadAbortException exThread)
        {
            string thError = exThread.Message;
        }

        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    new void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewUtenti.DataBind();
        }

        catch (ThreadAbortException exThread)
        {
            string thError = exThread.Message;
        }

        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    

    #endregion

    #region Web Form Event Handler

    protected void GridViewUtenti_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewUtenti.MyGridViewSorting(sender, e);
    }

    protected void ObjectDataSourceUtenti_SetProperties(object sender, ObjectDataSourceEventArgs e)
    {
        Utente objUtenti = e.ObjectInstance as Utente;        
        if (WhereClause == "" || WhereClause == null)
            WhereClause = hWhereClause.Value;
        objUtenti.SqlWhereClause = WhereClause;
    }

    protected void GridViewAutorizzatori_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_COMMAND")
        {
            try
            {
                string argument = e.CommandArgument.ToString();
                string[] parametri = argument.Split(',');
                int chiave1 = Convert.ToInt32(parametri[0]);
                int chiave2 = Convert.ToInt32(parametri[1]);
                int chiave3 = Convert.ToInt32(parametri[2]);

                Utente objUtenti = new Utente();
                objUtenti.Ute_id_utente = chiave1;
                objUtenti.Ute_id_utente_autorizzatore = chiave2;
                objUtenti.Aui_id_autorizzazione = chiave3;
                objUtenti.DeleteAutorizzatoriIndividuali();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }
    }

    protected void GridViewAutorizzati_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_COMMAND")
        {
            try
            {
                string argument = e.CommandArgument.ToString();
                int chiave1 = Convert.ToInt32(argument.Substring(0, argument.IndexOf(',')));
                int chiave2 = Convert.ToInt32(argument.Substring(argument.IndexOf(',') + 1));

                Utente objUtenti = new Utente();
                objUtenti.Ute_id_utente = chiave1;
                objUtenti.Ute_id_utente_autorizzatore = chiave2;
                objUtenti.DeleteAutorizzatiIndividuali();                
                GridViewAutorizzati.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }
    }

    protected void GridViewWfAssociati_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_COMMAND")
        {
            try
            {
                string argument = e.CommandArgument.ToString();
                int chiave1 = Convert.ToInt32(argument.Substring(0, argument.IndexOf(',')));
                int chiave2 = Convert.ToInt32(argument.Substring(argument.IndexOf(',') + 1));

                CrossUtenteWorkflow objCrossUtenteWorkflow = new CrossUtenteWorkflow();
                objCrossUtenteWorkflow.Delete(chiave2);
                GridViewWfAssociati.DataBind();

                if (GridViewWfAssociati.Rows.Count > 0)
                {
                    ButtonNuovoWfAssociato.Visible = false;
                }
                else
                {
                    ButtonNuovoWfAssociato.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }
    }

    protected void GridViewCliAssociati_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_COMMAND")
        {
            try
            {
                
                string[] argument = e.CommandArgument.ToString().Split(',');

                int chiave1 = Convert.ToInt32(argument[0].ToString());
                int chiave2 = Convert.ToInt32(argument[1].ToString());
                int chiave3 = Convert.ToInt32(argument[2].ToString());

                CrossUtenteCliente objCrossUtenteCliente = new CrossUtenteCliente();
                objCrossUtenteCliente.Delete(chiave2);
                GridViewCliAssociati.DataBind();
                
                //Ricalcolo l'object Owner
                ReCalculateObjectOwner(Convert.ToInt32(qUTE_ID_UTENTE), chiave3);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }
    }
    
    protected void GridViewUtenti_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_COMMAND")
        {
            int chiave = Convert.ToInt32(e.CommandArgument);
            try
            {
                Utente objUtente = new Utente();
                objUtente.Ute_id_utente = chiave;
                objUtente.Delete();
                GridViewUtenti.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }

        }
    }
        
    protected void GridViewUtenti_PageIndexChanged(object sender, EventArgs e)
    {
        //Si perde la riga selezionata
        GridViewUtenti.SelectedIndex = -1;           
    }

    protected void ObjectDataSourceUtenti_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        try
        {
            //Così va bene anche con i filtri
            LabelNroRecord.InnerText = ((DataSet)e.ReturnValue).Tables[0].Rows.Count.ToString() + " record";
            DataView dv = new DataView(((DataSet)e.ReturnValue).Tables["UTENTE_ID"], ObjectDataSourceUtenti.FilterExpression, "", DataViewRowState.CurrentRows);

            int[] idUte = new int[dv.Table.Rows.Count];

            int i = 0;
            foreach (DataRow dr in dv.Table.Rows)
            {
                idUte[i] = Convert.ToInt32(dr[0].ToString());
                i++;
            }
            ViewState["dvUte"] = idUte;

        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void ObjectDataSourceRuoliUtente_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void ObjectDataSourceAutorizzati_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        try
        {
            //Così va bene anche con i filtri
            DataView dv = new DataView(((DataSet)e.ReturnValue).Tables["AUTORIZZATORI_INDIVIDUALI"], ObjectDataSourceAutorizzati.FilterExpression, "", DataViewRowState.CurrentRows);
            e.AffectedRows = dv.Count;
            nroRecordAutorizzati.InnerText = e.AffectedRows.ToString() + " record";
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void ObjectDataSourceWfAssociati_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        try
        {
            //Così va bene anche con i filtri
            DataView dv = new DataView(((DataSet)e.ReturnValue).Tables["CROSS_UTENTE_WORKFLOW"], ObjectDataSourceWfAssociati.FilterExpression, "", DataViewRowState.CurrentRows);
            e.AffectedRows = dv.Count;
            nroRecordWfAssociati.InnerText = e.AffectedRows.ToString() + " record";
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void ObjectDataSourceCliAssociati_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        try
        {
            //Così va bene anche con i filtri
            DataView dv = new DataView(((DataSet)e.ReturnValue).Tables["CROSS_UTENTE_CLIENTE"], ObjectDataSourceCliAssociati.FilterExpression, "", DataViewRowState.CurrentRows);
            e.AffectedRows = dv.Count;
            nroRecordCliAssociati.InnerText = e.AffectedRows.ToString() + " record";
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void CheckBoxSelAll_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox)GridViewUtenti.HeaderRow.FindControl("CheckBoxSelAll");

        if (cb.Checked)
        {
            fieldSelected.Value = "hdr;";
            TextCountSel.Value = "0";           
            int[] test = (int[])ViewState["dvUte"];
            for (int i = 0; i < test.Length; i++)
            {
                fieldSelected.Value += "val_" + Convert.ToString(test[i]) + ";";
                TextCountSel.Value = Convert.ToString(Convert.ToInt32(TextCountSel.Value) + 1);
            }
            GridViewUtenti.DataBind();
        }
        else
        {
            fieldSelected.Value = "";
            TextCountSel.Value = "0";
            GridViewUtenti.DataBind();
        }
    }

    void GridViewUtenti_DataBound(object sender, EventArgs e)
    {
        try
        {
            string percorso = "";
            string chiamata;
            int contatore = 0;

            CheckBox ChkSelAll = (CheckBox)GridViewUtenti.HeaderRow.FindControl("CheckBoxSelAll");
            if (this.fieldSelected.Value.IndexOf("hdr;") >= 0)
            {
                ChkSelAll.Checked = true;
            }
                   
            foreach (GridViewRow row in GridViewUtenti.Rows)
            {           
                //Gestione immagine che indica lo stato dell'utente.
                HtmlGenericControl imgStatoUtente = (HtmlGenericControl)row.FindControl("imgStatoUtente");

                if (imgStatoUtente != null)
                {
                    if (Convert.ToBoolean(GridViewUtenti.DataKeys[contatore].Values["UTE_STATO_UTENTE"]) == true)
                    {
                        imgStatoUtente.Attributes["class"] = "fa fa-check verde";
                    }
                    else
                    {
                        imgStatoUtente.Visible = false;
                    }
                }

                //Gestione immagine che indica gli utenti online.
                HtmlGenericControl imgOnline = (HtmlGenericControl)row.FindControl("imgOnline");
                if (imgOnline != null)
                {
                    if (Convert.ToString(GridViewUtenti.DataKeys[contatore].Values["ISONLINE"]) == "1")
                    {
                        imgOnline.Attributes["class"] = "fa fa-check verde";
                    }
                    else
                        imgOnline.Visible = false;
                }

                if (allowDelete)
                {
                    //Visualizzo il pulsante per l'eliminazione di un utente solo se quell'utente non è admin
                    if (GridViewUtenti.DataKeys[contatore].Values["UTE_ID_UTENTE"].ToString() != "1")
                    {
                        skmExtendedControls.skmLinkButton btnExtended = (skmExtendedControls.skmLinkButton)row.FindControl("ButtonDeleteUtenti");
                        if (btnExtended != null)
                        {
                            if (btnExtended.CommandName == "DELETE_COMMAND")
                            {
                                btnExtended.CommandArgument = Convert.ToInt64(GridViewUtenti.DataKeys[contatore].Values["UTE_ID_UTENTE"]).ToString();
                                btnExtended.ConfirmMessage = GetValueDizionarioUI("CONFIRM_DELETION");
                                btnExtended.Text = "<i class='fa fa-times'></i>";
                            }
                        }
                    }
                    else
                    {
                        skmExtendedControls.skmLinkButton btnExtended = (skmExtendedControls.skmLinkButton)row.FindControl("ButtonDeleteUtenti");
                        btnExtended.Visible = false;
                    }
                }
                else
                {
                    skmExtendedControls.skmLinkButton btnExtended = (skmExtendedControls.skmLinkButton)row.FindControl("ButtonDeleteUtenti");
                    btnExtended.Enabled = false;
                }

                LinkButton btnEdit = (LinkButton)row.FindControl("ButtonEditUtenti");
                btnEdit.Text = "<i class='fas fa-pencil-alt' data-toggle='modal' data-target='#modalPage'></i>"; // GetValueDizionarioUI("BUTTON_MODIFICA");
                if (allowEdit)
                {
                    percorso = @"frm_MSE_UTE.aspx?MODALITA=EDIT&UTE_ID_UTENTE=" + GridViewUtenti.DataKeys[contatore].Values["UTE_ID_UTENTE"];
                }
                else //Deve entrare solo se in MODALITA=VIEW
                {
                    percorso = @"frm_MSE_UTE.aspx?MODALITA=VIEW&UTE_ID_UTENTE=" + GridViewUtenti.DataKeys[contatore].Values["UTE_ID_UTENTE"];
                    //Cambiare icona
                    btnEdit.Text = "<i class='fas fa-pencil-alt' ></i>"; // GetValueDizionarioUI("BUTTON_VISUALIZZA");                    
                }
                chiamata = "javascript:openModal('" + percorso + "', 'UTE');return false;";
                row.Cells[1].Attributes["onClick"] = chiamata;

                //Questa parte di codice serve per gestire la selezione degli utenti per l'invio/reset della password
                CheckBox ChkSelezione = (System.Web.UI.WebControls.CheckBox)row.FindControl("CheckBoxSelezioneUtente");


                if (ChkSelezione != null)
                {
                    //Apri file
                    string ute_id_utente = Convert.ToString(GridViewUtenti.DataKeys[contatore].Values["UTE_ID_UTENTE"]);
                    chiamata = "javascript:SetCheckCount(this.id , '" + ute_id_utente + "');";
                    ChkSelezione.Attributes.Add("onclick", chiamata);
                    ChkSelezione.Enabled = true;

                    if (this.fieldSelected.Value.IndexOf("val_" + ute_id_utente + ";") >= 0)
                    {
                        ChkSelezione.Checked = true;
                    }
                }         

                contatore++;
            }            
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    void GridViewRuoliUtente_DataBound(object sender, EventArgs e)
    {
        try
        {
            string percorso = "";
            string chiamata;
            int contatore = 0;
            //Griglia contenente dati
            if (GridViewRuoliUtente.Rows.Count > 0)
            {
                // Use the Count property to determine whether the
                // DataKeys collection contains any items.
                if (GridViewRuoliUtente.DataKeys.Count > 0)
                {
                    IEnumerator keyEnumerator = GridViewRuoliUtente.DataKeys.GetEnumerator();
                    while (keyEnumerator.MoveNext())
                    {
                        DataKey key = (DataKey)keyEnumerator.Current;

                        ((CheckBox)GridViewRuoliUtente.Rows[contatore].FindControl("CheckBoxStatoRuolo")).Checked = Convert.ToBoolean((GridViewRuoliUtente.DataKeys[contatore].Values["URL_STATO_RUOLO_UTENTE"]));

                        //Introduzione bottone MODIFICA RUOLO
                        LinkButton btnEdit = (LinkButton)GridViewRuoliUtente.Rows[contatore].FindControl("ButtonEditRuoliUtente");
                        if (allowEditRul && Convert.ToBoolean(GridViewRuoliUtente.DataKeys[contatore].Values["URL_STATO_RUOLO_UTENTE"].ToString()))
                        {
                            btnEdit.Text = "<i class='fas fa-pencil-alt' data-toggle='modal' data-target='#modalPage'></i>";
                            percorso = @"../Ruoli/frm_MSE_RUL_UTE.aspx?PROVENIENZA=UTE&MODALITA=EDIT&URL_ID_RUOLI_UTENTE=" + GridViewRuoliUtente.DataKeys[contatore].Values["URL_ID_RUOLI_UTENTE"] + "&UTE_ID_UTENTE=" + GridViewUtenti.SelectedDataKey.Values["UTE_ID_UTENTE"] + "&RUL_ID_RUOLO=" + GridViewRuoliUtente.DataKeys[contatore].Values["RUL_ID_RUOLO"];
                        }
                        else
                        {
                            btnEdit.Text = GetValueDizionarioUI("BUTTON_VISUALIZZA");
                            percorso = @"../Ruoli/frm_MSE_RUL_UTE.aspx?PROVENIENZA=UTE&MODALITA=VIEW&URL_ID_RUOLI_UTENTE=" + GridViewRuoliUtente.DataKeys[contatore].Values["URL_ID_RUOLI_UTENTE"] + "&UTE_ID_UTENTE=" + GridViewUtenti.SelectedDataKey.Values["UTE_ID_UTENTE"] + "&RUL_ID_RUOLO=" + GridViewRuoliUtente.DataKeys[contatore].Values["RUL_ID_RUOLO"];
                        }
                        chiamata = "javascript:openModal('" + percorso + "', 'RUL_UTE');return false;";
                        GridViewRuoliUtente.Rows[contatore].Cells[1].Attributes["onClick"] = chiamata;


                        skmExtendedControls.skmLinkButton btnDelete = ((skmExtendedControls.skmLinkButton)GridViewRuoliUtente.Rows[contatore].FindControl("ButtonDeleteRuoliUtenti"));
                        if (btnDelete != null)
                        {
                            if (btnDelete.CommandName == "DELETE_COMMAND")
                            {
                                btnDelete.CommandArgument = Convert.ToInt64(GridViewRuoliUtente.DataKeys[contatore].Values["URL_ID_RUOLI_UTENTE"]).ToString();
                                btnDelete.ConfirmMessage = GetValueDizionarioUI("CONFIRM_DELETION");
                                btnDelete.Text = "<i class='fa fa-times'></i>";
                            }
                        }

                        contatore++;
                    }
                }
                else
                {
                    throw new System.Exception("GridViewRuoliUtente:no DataKey objects.");
                }
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }


    protected void GridViewRuoliUtente_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_COMMAND")
        {
            int chiave = Convert.ToInt32(e.CommandArgument);
            try
            {
                RuoliUtente objRuoliUtente = new RuoliUtente();
                objRuoliUtente.Url_id_ruoli_utente = chiave;
                objRuoliUtente.Delete();
                GridViewRuoliUtente.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }

        }
    }

    void GridViewAutorizzati_DataBound(object sender, EventArgs e)
    {
        try
        {
            int contatore = 0;
            int HideButtonDelete = 0;
            //Griglia contenente dati
            if (GridViewAutorizzati.Rows.Count > 0)
            {
                // Use the Count property to determine whether the
                // DataKeys collection contains any items.
                if (GridViewAutorizzati.DataKeys.Count > 0)
                {
                    IEnumerator keyEnumerator = GridViewAutorizzati.DataKeys.GetEnumerator();
                    while (keyEnumerator.MoveNext())
                    {
                        DataKey key = (DataKey)keyEnumerator.Current;

                        ((CheckBox)GridViewAutorizzati.Rows[contatore].FindControl("CheckBoxPrincipale")).Checked = Convert.ToBoolean((GridViewAutorizzati.DataKeys[contatore].Values["AUI_FLAG_AUTORIZZATORE_PRINC"]));

                        //SGA: parametrizzare i permesi sulla singola tabella?
                        if (allowDelete)
                        {
                            if (Convert.ToString(GridViewAutorizzati.DataKeys[contatore].Values["TIPO_AUTORIZZAZIONE"]) != "Centro di Costo")
                            {
                                if (Convert.ToString(GridViewAutorizzati.DataKeys[contatore].Values["TIPO_AUTORIZZAZIONE"]) == "Codice Individuale" && Convert.ToBoolean(GridViewAutorizzati.DataKeys[contatore].Values["AUI_FLAG_AUTORIZZATORE_PRINC"]) == false)
                                {
                                    skmExtendedControls.skmLinkButton btnExtended = (skmExtendedControls.skmLinkButton)GridViewAutorizzati.Rows[contatore].FindControl("ButtonDeleteAutorizzati");
                                    if (btnExtended != null)
                                    {
                                        if (btnExtended.CommandName == "DELETE_COMMAND")
                                        {
                                            btnExtended.CommandArgument = Convert.ToInt64(key.Values[0]).ToString() + "," + Convert.ToInt64(key.Values[1]).ToString();
                                            btnExtended.ConfirmMessage = GetValueDizionarioUI("CONFIRM_DELETION");
                                            //btnExtended.Text = objDizionarioUI["BUTTON_CANCELLA"];
                                            btnExtended.Text = "<i class='fa fa-times'></i>";
                                            HideButtonDelete = 0;
                                        }
                                    }
                                }
                                else
                                    HideButtonDelete = 1;
                            }
                            else
                                HideButtonDelete = 1;
                        }
                        else
                            HideButtonDelete = 1;

                        if (HideButtonDelete == 1)
                        {
                            skmExtendedControls.skmLinkButton btnExtended = (skmExtendedControls.skmLinkButton)GridViewAutorizzati.Rows[contatore].FindControl("ButtonDeleteAutorizzati");
                            btnExtended.Enabled = false;
                            btnExtended.Visible = false;
                        }                                                                       
                        contatore++;
                    }
                }
                else
                {
                    throw new System.Exception("GridViewAutorizzati:no DataKey objects.");
                }
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    void GridViewWfAssociati_DataBound(object sender, EventArgs e)
    {
        try
        {
            int contatore = 0;
            int HideButtonDelete = 0;
            //Griglia contenente dati
            if (GridViewWfAssociati.Rows.Count > 0)
            {
                // Use the Count property to determine whether the
                // DataKeys collection contains any items.
                if (GridViewWfAssociati.DataKeys.Count > 0)
                {
                    IEnumerator keyEnumerator = GridViewWfAssociati.DataKeys.GetEnumerator();
                    while (keyEnumerator.MoveNext())
                    {
                        DataKey key = (DataKey)keyEnumerator.Current;
                        //SGA: parametrizzare i permesi sulla singola tabella?
                        if (allowDelete)
                        {
                            skmExtendedControls.skmLinkButton btnExtended = (skmExtendedControls.skmLinkButton)GridViewWfAssociati.Rows[contatore].FindControl("ButtonDeleteWfAssociati");
                            if (btnExtended != null)
                            {
                                if (btnExtended.CommandName == "DELETE_COMMAND")
                                {
                                    btnExtended.CommandArgument = Convert.ToInt64(key.Values[0]).ToString() + "," + Convert.ToInt64(key.Values[1]).ToString();
                                    btnExtended.ConfirmMessage = GetValueDizionarioUI("CONFIRM_DELETION");
                                    //btnExtended.Text = objDizionarioUI["BUTTON_CANCELLA"];
                                    btnExtended.Text = "<i class='fa fa-times'></i>";
                                    HideButtonDelete = 0;
                                }
                            }                         
                        }
                        else
                            HideButtonDelete = 1;

                        if (HideButtonDelete == 1)
                        {
                            skmExtendedControls.skmLinkButton btnExtended = (skmExtendedControls.skmLinkButton)GridViewWfAssociati.Rows[contatore].FindControl("ButtonDeleteWfAssociati");
                            btnExtended.Enabled = false;
                            btnExtended.Visible = false;
                        }

                        contatore++;
                    }
                }
                else
                {
                    throw new System.Exception("GridViewWfAssociati:no DataKey objects.");
                }
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    void GridViewCliAssociati_DataBound(object sender, EventArgs e)
    {
        try
        {
            int contatore = 0;
            string percorso = string.Empty;
            string chiamata = string.Empty;
            
            if (GridViewCliAssociati.Rows.Count > 0)
            {
                // Use the Count property to determine whether the
                // DataKeys collection contains any items.
                if (GridViewCliAssociati.DataKeys.Count > 0)
                {
                    IEnumerator keyEnumerator = GridViewCliAssociati.DataKeys.GetEnumerator();
                    while (keyEnumerator.MoveNext())
                    {
                        DataKey key = (DataKey)keyEnumerator.Current;
                        
                        ((CheckBox)GridViewCliAssociati.Rows[contatore].FindControl("CheckBoxStatoCliente")).Checked = Convert.ToBoolean((GridViewCliAssociati.DataKeys[contatore].Values["CUC_FLAG_STATO"]));
                        
                        //Introduzione bottone MODIFICA RUOLO
                        LinkButton btnEdit = (LinkButton)GridViewCliAssociati.Rows[contatore].FindControl("ButtonEditClientiAssociati");
                        if (allowEdit)
                        {
                            btnEdit.Text = "<i class='fas fa-pencil-alt' data-toggle='modal' data-target='#modalPage'></i>";
                            percorso = @"frm_MSE_UTE_CLI.aspx?MODALITA=EDIT&CUC_ID_CROSS_UTENTE_CLIENTE=" + GridViewCliAssociati.DataKeys[contatore].Values["CUC_ID_CROSS_UTENTE_CLIENTE"];
                        }
                        else
                        {
                            btnEdit.Text = GetValueDizionarioUI("BUTTON_VISUALIZZA");
                            percorso = @"frm_MSE_UTE_CLI.aspx?MODALITA=VIEW&CUC_ID_CROSS_UTENTE_CLIENTE=" + GridViewCliAssociati.DataKeys[contatore].Values["CUC_ID_CROSS_UTENTE_CLIENTE"];
                        }
                        chiamata = "javascript:openModal('" + percorso + "', 'RUL_UTE');return false;";
                        GridViewCliAssociati.Rows[contatore].Cells[1].Attributes["onClick"] = chiamata;


                        skmExtendedControls.skmLinkButton btnDelete = ((skmExtendedControls.skmLinkButton)GridViewCliAssociati.Rows[contatore].FindControl("ButtonDeleteCliAssociati"));
                        if (btnDelete != null)
                        {
                            if (btnDelete.CommandName == "DELETE_COMMAND")
                            {
                                btnDelete.CommandArgument = Convert.ToInt64(GridViewRuoliUtente.DataKeys[contatore].Values["URL_ID_RUOLI_UTENTE"]).ToString();
                                btnDelete.ConfirmMessage = GetValueDizionarioUI("CONFIRM_DELETION");
                                btnDelete.Text = "<i class='fa fa-times'></i>";
                            }
                        }

                        contatore++;
                    }
                }
                else
                {
                    throw new System.Exception("GridViewRuoliUtente:no DataKey objects.");
                }
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void GridViewUtenti_SelectedIndexChanged(object sender, EventArgs e)
    {        

        if (GridViewUtenti.SelectedIndex != -1)
        {
            LabelTitoloRuoloUtente.InnerText = GetValueDizionarioUI("RUOLI") + ": " + GridViewUtenti.SelectedRow.Cells[GridIndexOfByName(GridViewUtenti, "UTE_COGNOME")].Text.ToString() + " " + GridViewUtenti.SelectedRow.Cells[GridIndexOfByName(GridViewUtenti, "UTE_NOME")].Text.ToString();
            LabelTitoloAutorizzati.InnerText = GetValueDizionarioUI("AUTORIZZATI_DA") + ": " + GridViewUtenti.SelectedRow.Cells[GridIndexOfByName(GridViewUtenti, "UTE_COGNOME")].Text.ToString() + " " + GridViewUtenti.SelectedRow.Cells[GridIndexOfByName(GridViewUtenti, "UTE_NOME")].Text.ToString();
            labelTitoloWfAssociati.InnerText = GetValueDizionarioUI("WORKFLOW_ASSOCIATI") + ": " + GridViewUtenti.SelectedRow.Cells[GridIndexOfByName(GridViewUtenti, "UTE_COGNOME")].Text.ToString() + " " + GridViewUtenti.SelectedRow.Cells[GridIndexOfByName(GridViewUtenti, "UTE_NOME")].Text.ToString();
            labelTitoloCliAssociati.InnerText = GetValueDizionarioUI("CLIENTI_ASSOCIATI") + ": " + GridViewUtenti.SelectedRow.Cells[GridIndexOfByName(GridViewUtenti, "UTE_COGNOME")].Text.ToString() + " " + GridViewUtenti.SelectedRow.Cells[GridIndexOfByName(GridViewUtenti, "UTE_NOME")].Text.ToString();

            hIdCliente.Value = GridViewUtenti.DataKeys[GridViewUtenti.SelectedIndex].Values["CLI_ID_CLIENTE"].ToString();
            hIdUtente.Value = GridViewUtenti.DataKeys[GridViewUtenti.SelectedIndex].Values["UTE_ID_UTENTE"].ToString();

            //Rendo visibili tutti i pulsanti Nuovo
            ButtonNuovoRuoloUtente.Visible = true;
        }                        
        
    }
          
    protected void ButtonCerca_Click(object sender, EventArgs e)
    {
        try
        {
            BuildWhereClause();
            if (qUTE_ID_UTENTE != Convert.ToInt32(Session["UTE_ID_UTENTE"]))
            {
                WhereClause += " AND UTENTE.ute_id_utente <> 1 ";
            }
            hWhereClause.Value = WhereClause;
            GridViewUtenti.SelectedIndex = -1;                       
            LabelTitoloAutorizzati.InnerText = "";
            GridViewUtenti.DataBind();
            ButtonNuovoAutorizzati.Visible = false;
        }

        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }

    }

    protected void ButtonDisconnectAll_Click(object sender, EventArgs e)
    {
        try
        {
            objLock.disconnectAllUsers();
        }

        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }

    }

    protected void BuildWhereClause()
    {
        WhereClause = "";
        if (txtCognome.Value != "")
        {
            WhereClause = " AND UTE_COGNOME LIKE '" + txtCognome.Value.Replace("'", "''") + "%'";
        }

        if (txtUserId.Value != "")
        {
            WhereClause = WhereClause + " AND UTE_USER_ID LIKE '" + txtUserId.Value + "%'";
        }

        if (txtCliente.SelectedValue != "")
        {
            WhereClause = WhereClause + " AND UTENTE.CLI_ID_CLIENTE = " + txtCliente.SelectedValue;
        }

        if (txtPwdInviata.SelectedValue != "")
        {
            WhereClause = WhereClause + " AND UTENTE.UTE_FLAG_PWD_INVIATA = " + txtPwdInviata.SelectedValue;
        }

        if (txtNome.Value != "")
        {
            WhereClause = WhereClause + " AND UTE_NOME LIKE '" + txtNome.Value + "%'";
        }

        if (txtCodiceIndividuale.Value != "")
        {
            WhereClause = WhereClause + " AND UTE_CODICE_INDIVIDUALE LIKE '" + txtCodiceIndividuale.Value + "%'";
        }

        if (txtEmail.Value != "")
        {
            WhereClause = WhereClause + " AND UTE_EMAIL LIKE '" + txtEmail.Value + "%'";
        }
        if (chkOnline.Checked)
        {
            WhereClause = WhereClause + " AND DATEDIFF(minute, SESSIONI_UTENTI.SSU_DATA_LAST_PING, getdate()) < 2 ";
        }
    }

    protected void ButtonRuoli_Click(object sender, EventArgs e)
    {
        showRuoli();
    }
    
    protected void resetPanelVisibility()
    {
        ButtonRuoli.CssClass = "";

        PanelRuoliUtente.Visible = false;

        //Pannello Autorizzati
        PanelAutorizzatiUtente.Visible = false;
        ButtonNuovoAutorizzati.Visible = false;
        LabelTitoloAutorizzati.Visible = false;

        //Pannello Wf Associati
        PanelWfAssociati.Visible = false;
        ButtonNuovoWfAssociato.Visible = false;
        labelTitoloWfAssociati.Visible = false;

        //Pannello Clienti Associati
        PanelCliAssociati.Visible = false;
        ButtonNuovoCliAssociato.Visible = false;
        labelTitoloCliAssociati.Visible = false;        
    }

    protected void showRuoli()
    {
        resetPanelVisibility();

        ButtonRuoli.CssClass = "tabSelected";

        //Pannello Ruoli
        PanelRuoliUtente.Visible = true;                

        //Controllo che un utente sia selezionato prima di far vedere il pulsante nuovo.
        if (GridViewUtenti.SelectedIndex != -1)
        {
            ButtonNuovoRuoloUtente.Visible = true;
            LabelTitoloRuoloUtente.Visible = true;
            // Aggiornamento griglie DEVE essere rifatto
            GridViewRuoliUtente.DataBind();
            GridViewRuoliUtente.Visible = true;
        }
    }

    protected void showAutorizzati()
    {
        resetPanelVisibility();
        
        //Pannello Autorizzati
        PanelAutorizzatiUtente.Visible = true;               

        //Controllo che un utente sia selezionato prima di far vedere il pulsante nuovo.
        if (GridViewUtenti.SelectedIndex != -1)
        {
            ButtonNuovoAutorizzati.Visible = true;
            LabelTitoloAutorizzati.Visible = true;
            //Aggiornamento griglie DEVE essere rifatto 
            GridViewAutorizzati.DataBind();
            GridViewAutorizzati.Visible = true;
        }
    }

    protected void ButtonInviaResetPwd_Click(object sender, EventArgs e)
    {
        try
        {
            string valore = "";
            int contatoreUtentiSelez = 0;
            string emailAddress = string.Empty;
            string password = string.Empty;
            string msg = string.Empty;
            string strChangePwdOK = GetValueDizionarioUI("PWD_INVIATE_OK");
            string strChangePwdKO = GetValueDizionarioUI("PWD_INVIATE_KO");
            char[] charSeparators = new char[] { ';' };

            if (this.fieldSelected.Value != "")
            {
                //Creo nuova riga nella hystory
                valore = fieldSelected.Value;
                string[] arrFieldSelected;
                arrFieldSelected = valore.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                string emailMittente = ConfigurationManager.AppSettings["EmailMittente"];

                if (arrFieldSelected.Length > 0)
                {

                    if (arrFieldSelected[0].ToString() != "hdr")
                    {
                        for (int i = 0; i < arrFieldSelected.Length; i++)
                        {

                            objUtente.Ute_id_utente = Convert.ToInt32(arrFieldSelected[contatoreUtentiSelez].Replace("val_", ""));
                            objUtente.Read();
                            objClienti.Read(objUtente.Cli_id_cliente, qCultureInfoName);

                            emailAddress = (objUtente.Ute_email.IsNull) ? ("") : (objUtente.Ute_email.ToString());


                            MailMessage email = new MailMessage();
                            MailAddress oFrom = new MailAddress(emailMittente);
                            email.From = oFrom;
                            email.IsBodyHtml = true;
                            email.Priority = MailPriority.Normal;
                            email.Subject = "Invio Password";
                            email.To.Clear();
                            email.To.Add(emailAddress);
                            email.Body = string.Empty;

                            if (emailAddress != "")
                            {
                                password = objUtilita.GenerateRandomPassword();
                                msg = "<p>Il link per accedere all'applicazione &egrave; : <strong><a href='" + objClienti.Cli_link_taf.ToString() + "'>" + objClienti.Cli_link_taf.ToString() + "</a></strong></p>";
                                msg += "<p>La sua UserId &egrave; : <strong>" + objUtente.Ute_user_id.ToString() + "</strong></p>";
                                msg += "<p>La sua Password &egrave; : <strong>" + password + "</strong></p>";
                                email.Body = Sistema.FormattaEmailPwd(msg);
                                Sistema.SendEmail(email);
                                objUtente.Ute_password = EncryptPwd(password);
                                objUtente.Ute_flag_pwd_inviata = 1;
                                objUtente.Ute_data_invio_pwd = DateTime.Now;
                                objUtente.Ute_expiration_date = DateTime.Today.AddDays(-1);
                                objUtente.Update();
                                string strScript = @"<script type='text/javascript'>
                                alert('" + strChangePwdOK + @"');
                                </script>";

                                if (!this.ClientScript.IsStartupScriptRegistered("Alert_JS"))
                                {
                                    this.ClientScript.RegisterStartupScript(GetType(), "Alert_JS", strScript);
                                }
                            }
                            contatoreUtentiSelez++;
                        }
                    }
                }
            }
            else
            {
                string strScript = "<script type='text/javascript'>alert('" + strChangePwdKO + "')</script>";
                if (!this.ClientScript.IsStartupScriptRegistered("Alert_JS"))
                {
                    this.ClientScript.RegisterStartupScript(GetType(), "Alert_JS", strScript);
                }
                throw new System.Exception("GridViewFatture:no DataKey objects Selected.");
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
            Response.End();
        }
    }
    
    #endregion

    #region Web Form Menu JScriptFunctions

    #endregion

    #region Web Form PreRender
    private void frm_MSB_UTE_PreRender(object sender, EventArgs e)
    {
        string percorso="";
        string chiamata;
        try
        {
            if (allowEdit)
            {
                //Nuovo Utente
                percorso = @"frm_MSE_UTE.aspx?MODALITA=NEW";
                chiamata = "javascript:openModal('" + percorso + "', 'UTE');return false;";
                ButtonNuovoUtente.Attributes["onClick"] = chiamata;
                ButtonNuovoUtente.Attributes["data-toggle"] = "modal";
                ButtonNuovoUtente.Attributes["data-target"] = "#modalPage";

                //Upload Utente
                percorso = @"frm_MSU_UTE.aspx?MODALITA=UPLOAD";
                chiamata = "javascript:openModal('" + percorso + "', 'UTE');return false;";
                ButtonUploadUtenti.Attributes["onClick"] = chiamata;
                ButtonUploadUtenti.Attributes["data-toggle"] = "modal";
                ButtonUploadUtenti.Attributes["data-target"] = "#modalPage";
            }

            //Nuova Cross Ruolo Utente

            if (allowEdit)
            {
                //Recupero l'ID della riga selezionata nella griglia Utente.
                //Se esiste allora creo il path da passare ai pulsanti del Browser di dettaglio.
                int indexRowSelected = GridViewUtenti.SelectedIndex;
                if (indexRowSelected > -1)
                    percorso = @"../Ruoli/frm_MSE_RUL_UTE.aspx?MODALITA=NEW&PROVENIENZA=UTE&UTE_ID_UTENTE=" + (GridViewUtenti.DataKeys[indexRowSelected].Values["UTE_ID_UTENTE"]);

                chiamata = "javascript:openModal('" + percorso + "','RUL_UTE');return false;";
                ButtonNuovoRuoloUtente.Attributes["onClick"] = chiamata;
                ButtonNuovoRuoloUtente.Attributes["data-toggle"] = "modal";
                ButtonNuovoRuoloUtente.Attributes["data-target"] = "#modalPage";
            }

            if (allowEdit)
            {
                //Recupero l'ID della riga selezionata nella griglia Utente.
                //Se esiste allora creo il path da passare ai pulsanti del Browser di dettaglio.
                int indexRowSelected = GridViewUtenti.SelectedIndex;
                if (indexRowSelected > -1)
                    percorso = @"frm_MSE_UTE_AUT.aspx?MODALITA=NEW&UTE_ID_UTENTE=" + (GridViewUtenti.DataKeys[indexRowSelected].Values["UTE_ID_UTENTE"]);

                chiamata = "javascript:openModal('" + percorso + "','UTE_AUT');return false;"; 
                ButtonNuovoAutorizzati.Attributes["onClick"] = chiamata;
                ButtonNuovoAutorizzati.Attributes["data-toggle"] = "modal";
                ButtonNuovoAutorizzati.Attributes["data-target"] = "#modalPage";
            }

            if (allowEdit)
            {
                //Recupero l'ID della riga selezionata nella griglia Utente.
                //Se esiste allora creo il path da passare ai pulsanti del Browser di dettaglio.
                int indexRowSelected = GridViewUtenti.SelectedIndex;
                if (indexRowSelected > -1)
                    percorso = @"frm_MSE_UTE_WRF.aspx?MODALITA=NEW&UTE_ID_UTENTE=" + (GridViewUtenti.DataKeys[indexRowSelected].Values["UTE_ID_UTENTE"]);

                chiamata = "javascript:openModal('" + percorso + "','UTE_WRF');return false;";
                ButtonNuovoWfAssociato.Attributes["onClick"] = chiamata;
                ButtonNuovoWfAssociato.Attributes["data-toggle"] = "modal";
                ButtonNuovoWfAssociato.Attributes["data-target"] = "#modalPage";
            }

            if (allowEdit)
            {
                //Recupero l'ID della riga selezionata nella griglia Utente.
                //Se esiste allora creo il path da passare ai pulsanti del Browser di dettaglio.
                int indexRowSelected = GridViewUtenti.SelectedIndex;
                if (indexRowSelected > -1)
                    percorso = @"frm_MSE_UTE_CLI.aspx?MODALITA=NEW&UTE_ID_UTENTE=" + (GridViewUtenti.DataKeys[indexRowSelected].Values["UTE_ID_UTENTE"]);

                chiamata = "javascript:openModal('" + percorso + "','UTE_CLI');return false;";
                ButtonNuovoCliAssociato.Attributes["onClick"] = chiamata;
                ButtonNuovoCliAssociato.Attributes["data-toggle"] = "modal";
                ButtonNuovoCliAssociato.Attributes["data-target"] = "#modalPage";
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion

    protected void btnCerca_Click(object sender, EventArgs e)
    {
    }

    protected void GridView_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;
               
        //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
        gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        //}
        if (gv.ShowFooter == true && gv.Rows.Count > 0)
        {
            //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
            gv.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

}
