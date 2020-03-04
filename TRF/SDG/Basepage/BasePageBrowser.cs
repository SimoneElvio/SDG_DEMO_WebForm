#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    SDG_DEMO
// Nome File:   BasePageBrowser.cs
//
// Namespace:   SDG.GestioneUtenti.Web
// Descrizione: Pagina base utilizzata dai Browser
//
// Autore:      SE - SDG srl
// Data:        26/09/2011
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SDG.Utility;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SDG.GestioneUtenti.Web
{
    /// <summary>
    /// Contiene funzioni e metodi utilizzati solo dai browser.
    /// In cascata eredita da BasePage e BasePageMaster
    /// </summary>
    public class BasePageBrowser : BasePage
    {
        #region OnInit
        /// <summary>
        /// Override onInit Base Page: configurazione TollkitScriptManager, utile per l'esecuzione dei pageMethod
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            ConfigToolkitScriptManager();
            base.OnInit(e);
        }

        #endregion

        #region Web Control Declaration

            protected Int32 VPage_Index
            {
                get { return (Int32)(ViewState["VPage_Index"] == null ? 0 : ViewState["VPage_Index"]); }
                set { ViewState["VPage_Index"] = value; }
            }

            protected Dictionary<string, int> VGridViewColNames
            {
                get { return (Dictionary<string, int>)(ViewState["VGridViewColNames"]); }
                set { ViewState["VGridViewColNames"] = value; }
            }

            protected string VSortExpression
            {
                get { return (string)(ViewState["VSortExpression"] == null ? "BIR_ID_REPORT" : ViewState["VSortExpression"]); }
                set { ViewState["VSortExpression"] = value; }
            }

            protected string VSortDirection
            {
                get { return (string)(ViewState["VSortDirection"] == null ? "DESC" : ViewState["VSortDirection"]); }
                set { ViewState["VSortDirection"] = value; }
            }

            //PULSANTI STANDARD
            protected Button SaveButton;
            protected Button CloseButton;
            protected Button PrintButton;
            protected Button ExportButton;
            protected Button NewButton;
            protected Button HelpButton;
            // protected Button SearchButton;
            protected Button RefreshButton;

        #endregion
        
        #region MyGridView_Render_Functions

        /// <summary>
        /// Genera MyGridView con la configurazione standard: griglia GridView, record per pagina e totale record
        /// </summary>
        protected void GenerateStardardMyGridView()
        {
            GenerateStardardMyGridView("GridView", true, true);
        }

        /// <summary>
        /// Genera MyGridView con la configurazione standard ma utilizzando una MyGridView differente
        /// </summary>
        /// <param name="MyGridView">Id della MyGridView se differente da "GridView"</param>
        protected void GenerateStardardMyGridView(string MyGridView)
        {
            GenerateStardardMyGridView(MyGridView, true, true);
        }

        /// <summary>
        /// Genera MyGridView
        /// </summary>
        /// <param name="gridView">Id MyGridView</param>
        /// <param name="booViewRecordPagina">Flag per visualizzare/nascondere la DropDownList Record per Pagina</param>
        /// <param name="booViewTotaleRecordPagina">Flag per visualizzare il totale Record Pagina</param>
        protected void GenerateStardardMyGridView(string MyGridView, bool booViewTotaleRecordPagina, bool booViewRecordPagina)
        {

            if (this.Page.Form != null)
            {
                MyGridViewLibrary.MyGridView gridView = this.Page.Form.FindControl(MyGridView) as MyGridViewLibrary.MyGridView;

                if (gridView != null)
                {
                    if (booViewRecordPagina)
                    {
                        DropDownList dropDownListRecordPagina = this.Page.Form.FindControl("DropDownListRecordPagina") as DropDownList;
                        GenerateDropDownListRecordPagina();

                        HtmlGenericControl LabelRecordPagina = this.Page.Form.FindControl("LabelRecPagina") as HtmlGenericControl;
                        if (LabelRecordPagina != null)
                            LabelRecordPagina.InnerText = GetValueDizionarioUI("RECORD_PAGINA");
                    }

                    gridView.AllowPaging = true;
                    gridView.AllowSorting = true;
                    gridView.AutoGenerateColumns = false;
                    gridView.EnableViewState = true;
                    gridView.AutoGenerateEditButton = false;
                    gridView.PagerSettings.Mode = PagerButtons.NumericFirstLast;
                    //gridView.PagerSettings.Visible = true;
                    gridView.AlternatingRowStyle.CssClass = "ars";

                    DropDownList recordPagina = this.Page.Form.FindControl("DropDownListRecordPagina") as DropDownList;
                    gridView.PageSize = Convert.ToInt32(recordPagina.Items[0].Value);

                    VPage_Index = Convert.ToInt32(Request.QueryString["PAGE_INDEX"]);
                    gridView.PageIndex = VPage_Index;

                    //assegnazione Css
                    gridView.CssClass = "tableBrowser";
                    gridView.HeaderStyle.CssClass = "testataTabelle";
                    gridView.PagerStyle.CssClass = "GridViewPaginationLink";
                    gridView.SelectedRowStyle.CssClass = "selectedRowGridView";
                    //gridView.FooterRow.CssClass = "GridViewFooter";

                    //gridView.SelectedRowStyle.BackColor = "White";
                    //gridView.AlternatingRowStyle.BackColor = "White";
                    //gridView.BackColor = "White";

                    VGridViewColNames = MapGridViewColumnNames(gridView);

                    if (booViewTotaleRecordPagina)
                    {
                        Label LabelNroRecord = this.Page.Form.FindControl("LabelNroRecord") as Label;
                        if (LabelNroRecord != null)
                            LabelNroRecord.Text = "";
                    }
                }
            }

        }

        /// <summary>
        /// Inizializzazione DropDownListRecordPagina
        /// </summary>
        //protected void GenerateDropDownListRecordPagina()
        //{
        //    if (this.Page.Form != null)
        //    {
        //        DropDownList recordPagina = this.Page.Form.FindControl("DropDownListRecordPagina") as DropDownList;

        //        if (recordPagina != null)
        //        {
        //            GenerateDropDownListRecordPagina(recordPagina);
        //        }
        //    }
        //}

        /// <summary>
        /// Configurazione standard DropDownListRecordPagina
        /// <param name="recordPagina">Nome della DropDownList se diverso da "DropDownListRecordPagina"</param>
        /// </summary>
        protected void GenerateDropDownListRecordPagina(DropDownList recordPagina)
        {
            recordPagina.Items.Insert(0, new ListItem("5", "5"));
            recordPagina.Items.Insert(1, new ListItem("10", "10"));
            recordPagina.Items.Insert(2, new ListItem("15", "15"));
            recordPagina.Items.Insert(3, new ListItem("25", "25"));
            recordPagina.Items.Insert(4, new ListItem("35", "35"));
            recordPagina.Items.Insert(5, new ListItem("75", "75"));
            recordPagina.Items.Insert(6, new ListItem("100", "100"));
            recordPagina.AutoPostBack = true;
            recordPagina.SelectedIndex = 1;
        }


        /// <summary>
        /// Inizializzazione DropDownListRecordPagina di default. Utilizzata quando ne ho una sola nel browser.
        /// </summary>
        protected void GenerateDropDownListRecordPagina()
        {
            GenerateDropDownListRecordPagina("DropDownListRecordPagina");
        }

        /// <summary>
        /// Inizializzazione DropDownListRecordPagina
        /// </summary>
        protected void GenerateDropDownListRecordPagina(string idDropDownList)
        {
            if (this.Page.Form != null)
            {
                DropDownList recordPagina = this.Page.Form.FindControl(idDropDownList) as DropDownList;

                if (recordPagina != null)
                {
                    GenerateDropDownListRecordPagina(recordPagina);
                }
            }
        }

        #endregion

        #region MyGridView_Functions

        /// <summary>
        /// 
        /// </summary> 
        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (NoGridViewEditing())
            {
                //Si perde la riga selezionata
                VPage_Index = e.NewPageIndex;

                if (this.Page.Form != null)
                {
                    MyGridViewLibrary.MyGridView gridView = this.Page.Form.FindControl("GridView") as MyGridViewLibrary.MyGridView;

                    if (gridView != null)
                    {
                        gridView.PageIndex = e.NewPageIndex;

                        callContentFunction("LoadDataSource");
                    }
                }
            }
        }

        

        protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                if (this.Page.Form != null)
                {
                    MyGridViewLibrary.MyGridView gridView = this.Page.Form.FindControl("GridView") as MyGridViewLibrary.MyGridView;

                    if (gridView != null)
                    {
                        gridView.EditIndex = -1;

                        base.ReleaseLock();

                        callContentFunction("LoadDataSource");
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }

        protected void GridViewBusinessIntelligence_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                /*
                if (NoGridViewEditing())
                {
                    GridViewPrenotazioniAeree.EditIndex = e.NewEditIndex;
                    PrenotazioniAereeDataBind();
                    GridViewPrenotazioniAeree.Rows[e.NewEditIndex].Attributes["onclick"] = "";
                    GridViewRow row = GridViewPrenotazioniAeree.Rows[e.NewEditIndex];
                    row.FindControl("GRD_PRA_DATA").Focus();
                    DisableButton(e.NewEditIndex, "btnEdit", GridViewPrenotazioniAeree);
                    setReadonlyInGrid("PRENOTAZIONI_AEREE", row);
                }
                */
            }
            catch (Exception ex)
            {
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }

        protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (NoGridViewEditing())
            {
                if (this.Page.Form != null)
                {
                    MyGridViewLibrary.MyGridView gridView = this.Page.Form.FindControl("GridView") as MyGridViewLibrary.MyGridView;

                    if (gridView != null)
                    {

                        if (e.SortExpression == VSortExpression)
                        {
                            if (VSortDirection == "ASC")
                            {
                                VSortDirection = "DESC";
                            }
                            else
                            {
                                VSortDirection = "ASC";
                            }
                        }
                        else
                        {
                            VSortDirection = "ASC";
                        }

                        VSortExpression = e.SortExpression;

                        gridView.VSortExpression = e.SortExpression;
                        gridView.VSortDirection = VSortDirection;

                        callContentFunction("LoadDataSource");
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Visualizzazione di un messaggio che avvisa l'utente corrente che la richiesta è già in uso
        /// </summary>
        /// <param name="tableKey">Chiave della tabella</param>
        /// <param name="tableName">Nome della tabella</param>
        public Boolean isLocked(int tableKey, string tableName)
        {
            Boolean RetValue = true;

            if (GetLockRecord(tableKey, tableName))
            {
                qMODALITA = "VIEW";
            }
            else
            {
                SetLockRecord(tableKey, tableName, Convert.ToInt32(Session["UTE_ID_UTENTE"]));
                RetValue = false;
            }
            return RetValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="tableKey">Chiave riga da utilizzare per il lock</param>
        /// <param name="tableName">Tabella da utilizzare per il lock</param>
        /// <param name="focusField">Campo che riceve il focus</param>
        /// <param name="editorType">Tipologia di editor (popUp, inline, substitute)</param>
        protected void GridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e, int tableKey, string tableName, int editorType, string focusField)
        {
            if (this.Page.Form != null)
            {
                MyGridViewLibrary.MyGridView gridView = this.Page.Form.FindControl("GridView") as MyGridViewLibrary.MyGridView;

                if (gridView != null)
                {
                    try
                    {
                        int indiceRiga;

                        if (NoGridViewEditing())
                        {
                            if (!isLocked(tableKey, tableName))
                            {
                                switch (editorType)
                                {
                                    case editRow_Inline:

                                        indiceRiga = e.NewSelectedIndex + 1;
                                        gridView.EditIndex = e.NewSelectedIndex;
                                        callContentFunction("LoadDataSource");
                                        DisableButton(e.NewSelectedIndex, "btnEdit", gridView);
                                        gridView.Rows[e.NewSelectedIndex].Attributes["onclick"] = "";
                                        GridViewRow row = gridView.Rows[e.NewSelectedIndex];
                                        row.FindControl(focusField).Focus();

                                        break;

                                    case editRow_PopUp:
                                        
                                        //Configurato nella GridView_RowDataBound
                                        break;

                                    case editRow_SubstituteBrowser:

                                        //Configurato nella GridView_RowDataBound
                                        break;
                                }
                            }
                            else
                            {
                                ViewMessage(GetValueDizionarioUI("LOCK_MESSAGE"));
                            }
                        }
                        else
                            e.Cancel = true;
                    }
                    catch (Exception ex)
                    {
                        // Gestione messaggistica all'utente e trace in DB dell'errore
                        //ExceptionPolicy.HandleException(ex, "Propagate Policy");
                        e.Cancel = true;
                        handleUpdatePanelException(ex);
                    }
                }
            }
        }

         /// <summary>
        /// Verifica se l'utente è in EDIT su una riga della MyGridView.
        /// </summary>
        /// <returns></returns>
        Boolean NoGridViewEditing()
        {
            Boolean RetValue = true;

            if (this.Page.Form != null)
            {
                MyGridViewLibrary.MyGridView gridView = this.Page.Form.FindControl("GridView") as MyGridViewLibrary.MyGridView;

                if (gridView != null)
                {
                    try
                    {
                        if (gridView.EditIndex != -1)
                        {
                            //RetValue = GridViewMessages(GetValueDizionarioUI("MESSAGGIO_ERR_AIR"));
                            ViewMessage(GetValueDizionarioUI("MESSAGGIO_ERR_AIR"));
                            RetValue = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Gestione messaggistica all'utente e trace in DB dell'errore
                        ExceptionPolicy.HandleException(ex, "Propagate Policy");
                    }
                }
            }
            return RetValue;
        }

        /// <summary>
        /// Gestione abilitazione button della griglia in funzione del button cliccato
        /// </summary>
        /// <param name="rowIndex">Index della riga che si sta cercando di modificare</param>
        /// <param name="clickedButton">Button cliccato</param>
        /// <param name="grid">Nome della MyGridView</param>
        protected void DisableButton(Int32 rowIndex, string clickedButton, MyGridViewLibrary.MyGridView grid)
        {
            try
            {
                if (clickedButton == "btnEdit")
                {
                    grid.Rows[rowIndex].FindControl("btnEdit").Visible = false;
                    grid.Rows[rowIndex].FindControl("btnUpd").Visible = true;
                    grid.Rows[rowIndex].FindControl("btnCan").Visible = true;
                    grid.Rows[rowIndex].FindControl("btnDel").Visible = false;

                    //nascondo dropdown Record per Pagina
                    DropDownList dropDownListRecordPagina = this.Page.Form.FindControl("DropDownListRecordPagina") as DropDownList;
                    if (dropDownListRecordPagina != null)
                        dropDownListRecordPagina.Visible = false;
                    
                    //nascondo la pulsantiera
                    HtmlGenericControl toolbar = this.Page.Form.FindControl("toolbar") as HtmlGenericControl;
                    if (toolbar != null)
                        toolbar.Disabled = true;
                }
            }
            catch (Exception ex)
            {
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }

        /// <summary>
        /// GridView_RowDataBound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="editorType">Tipologia di visualizzazione editor</param>
        /// <param name="keyName">Chiave della tabella</param>
        /// <param name="enableViewDetail">Visualizza browser di dettaglio</param>
        /// <param name="srcBrowserDetail">Src dell'iframe che contiene il browser di dettaglio</param>
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e, int editorType, string keyName, bool enableViewDetail, string srcBrowserDetail)
        {
            if (this.Page.Form != null)
            {
                MyGridViewLibrary.MyGridView gridView = this.Page.Form.FindControl("GridView") as MyGridViewLibrary.MyGridView;

                if (gridView != null)
                {
                    try
                    {
                        //Nella riga dedicata alla creazione di una nuova tratta sostituisco l'icona del MODIFICA
                        //con l'icona dell'aggiungi.
                        Button btnEdit = (Button)e.Row.FindControl("btnEdit");
                        //ImageButton btnDelete = (ImageButton)e.Row.FindControl("btnDel");
                        Button btnDelete = (Button)e.Row.FindControl("btnDel");
                        Button btnDetail = (Button)e.Row.FindControl("btnDetail");
                        Button btnUpdate = (Button)e.Row.FindControl("btnUpd");
                        Button btnCancel = (Button)e.Row.FindControl("btnCan");
                        Button btnSelect = (Button)e.Row.FindControl("btnSel");
                        
                        if (e.Row.RowIndex != -1)
                        {
                            Int32 idRiga = Convert.ToInt32(gridView.DataKeys[e.Row.RowIndex].Values[keyName]);

                            btnDelete.ToolTip = GetValueDizionarioUI("ELIMINA");
                            btnDelete.CssClass = "buttonRowBrowser buttonDimension btnDel";
                            btnDelete.CommandName = "Delete";
                            btnDelete.CausesValidation = false;
                            btnDelete.OnClientClick = "if(confirm('" + GetValueDizionarioUI("ELIMINA_RECORD") + "')){return true;}else{return false;}";

                            btnCancel.ToolTip = GetValueDizionarioUI("ANNULLA_MODIFICHE");
                            btnCancel.CssClass = "buttonRowBrowser buttonDimension btnCan";
                            btnCancel.CommandName = "Cancel";
                            btnCancel.Visible = false;
                            btnCancel.CausesValidation = false;

                            btnUpdate.ToolTip = GetValueDizionarioUI("SALVA");
                            btnUpdate.CssClass = "buttonRowBrowser buttonDimension btnUpd";
                            btnUpdate.CommandName = "Update";
                            btnUpdate.Visible = false;
                            btnUpdate.OnClientClick = "//if(checkImporto($('#hIDFieldImportoAir').val(),'#pErroriAIR','#divErroriAIR','#hErrorAirFormatField')){return true;}else{return false;}";

                            btnEdit.ToolTip = GetValueDizionarioUI("MODIFICA");
                            btnEdit.CssClass = "buttonRowBrowser buttonDimension btnEdit";
                            btnEdit.Visible = false;
                            btnEdit.CommandName = "Edit";
                            btnEdit.CausesValidation = false;

                            btnSelect.ToolTip = GetValueDizionarioUI("SELECT");
                            btnSelect.CssClass = "HiddenColumn";
                            btnSelect.CommandName = "Select";
                            btnSelect.Visible = true;

                            btnDetail.ToolTip = GetValueDizionarioUI("DETTAGLIO_RECORD");
                            btnDetail.CssClass = "buttonRowBrowser buttonDimension btnDetail";
                            btnDetail.CausesValidation = false;
                            btnDetail.Visible = false;

                            if (gridView.DataKeys[e.Row.RowIndex].Values[0].ToString() == "-1")
                            {
                                if (btnEdit != null)
                                {
                                    btnEdit.ToolTip = GetValueDizionarioUI("AGGIUNGI");
                                    btnEdit.CssClass = "buttonRowBrowser buttonDimension btnAdd";
                                    ((Button)e.Row.FindControl("btnEdit")).Visible = true;
                                    //Messa questa riga per far si che cliccando sul pulsante AGGIUNGI non faccia il doppio postback
                                    //uno dovuto dal click sul pulsante e l'altro dovuto dal click sulla riga.
                                    btnEdit.OnClientClick = "return false;";
                                    btnEdit.Focus();

                                    //Nascondo la riga per l'inserimento nuovo record. Verrà visualizzata al click sul pulsante NewButton.
                                    if ((gridView.EditIndex == -1) || (gridView.EditIndex > 0))
                                        e.Row.CssClass = "displayNone";
                                }
                                if (btnDelete != null)
                                    btnDelete.Visible = false;
                            }
                            else
                            {
                                if (enableViewDetail)
                                {
                                    btnDetail.Visible = true;
                                    btnDetail.OnClientClick = "loadIframeDetail('" + srcBrowserDetail + idRiga + "');return false;";
                                }                                
                                
                            }

                            e.Row.Attributes.CssStyle.Add("cursor", "pointer");

                            switch (editorType)
                            {
                                case editRow_PopUp:
                                    //Collego la funzione a tutte le celle con id > 0.
                                    //La cella con id=0 è quella che contiene i pulsanti e gli eventuali checkbox.
                                    for (int i = 1; i < e.Row.Cells.Count; i++)
                                    {
                                        e.Row.Cells[i].Attributes["onclick"] = "openPopUp('" + idRiga + "');";
                                    }
                                    break;

                                case editRow_Inline:
                                    e.Row.Attributes["onclick"] = "document.getElementById('" + e.Row.FindControl("btnSel").ClientID.ToString() + "').click();";
                                    break;

                                case editRow_SubstituteBrowser:
                                    for (int i = 1; i < e.Row.Cells.Count; i++)
                                    {
                                        e.Row.Cells[i].Attributes["onclick"] = "substituteBrowser('" + idRiga + "');";
                                    }
                                    break;
                            }
                        }

                        //Se BlockGrid è True vuol dire che non posso operare sulle griglie.
                        if (BlockGrid() || qMODALITA == "VIEW")
                        {
                            if (btnDelete != null)
                                btnDelete.Visible = false;

                            if (btnEdit != null)
                                btnEdit.Visible = false;

                            e.Row.Attributes["onclick"] = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        //Gestione messaggistica all'utente e trace in DB dell'errore
                        ExceptionPolicy.HandleException(ex, "Propagate Policy");
                    }
                }
            }
        }

        protected void DropDownListRecPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NoGridViewEditing())
            {
                if (this.Page.Form != null)
                {
                    MyGridViewLibrary.MyGridView gridView = this.Page.Form.FindControl("GridView") as MyGridViewLibrary.MyGridView;
                    DropDownList dropDownListRecordPagina = this.Page.Form.FindControl("DropDownListRecordPagina") as DropDownList;

                    if (gridView != null)
                    {
                        gridView.PageSize = Convert.ToInt32(dropDownListRecordPagina.SelectedValue);
                        callContentFunction("LoadDataSource");
                    }
                }
            }
        }


        /// <summary>
        /// Questa funzione è stata creata per far funzionare il numero di record per pagina in quei browser dove ci sono
        /// più dropdown diverse (quindi più browser nella stessa pagina) è per le pagine vecchie, non per quelle nuove.
        /// </summary>
        /// <param name="idGridView"></param>
        /// <param name="idDropDownList"></param>
        protected void DropDownListRecPagina_SelectedIndexChanged(string idGridView,string idDropDownList)
        {
            if (this.Page.Form != null)
            {
                MyGridViewLibrary.MyGridView gridView = this.Page.Form.FindControl(idGridView) as MyGridViewLibrary.MyGridView;
                DropDownList dropDownListRecordPagina = this.Page.Form.FindControl(idDropDownList) as DropDownList;

                if (gridView != null)
                {
                    gridView.PageSize = Convert.ToInt32(dropDownListRecordPagina.SelectedValue);
                    gridView.DataBind();
                }
            }            
        }

        /// <summary>
        /// In una gridview ricava l'indice di una colonna dall'headerText
        /// </summary>	
        public int GetIndexByHeaderText(GridView gv, string headerText)
        {
            if (gv == null)
            {
                return -1;
            }
            // Loop through each column in the grid.
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                if (gv.Columns[i].HeaderText == headerText)
                {
                    return i;
                }
            }
            // No column found by header text.
            return -1;
        }

        /// <summary>
        /// In una gridview ricava l'indice di una colonna boundfield di nome dato
        /// </summary>
        public int GridIndexOfByName(System.Web.UI.WebControls.GridView myGridView, string colName)
        {
            int index = -1;
            foreach (DataControlField field in myGridView.Columns)
            {
                //BoundField
                if (field.GetType().ToString() == "System.Web.UI.WebControls.BoundField")
                {
                    BoundField bf = (BoundField)field;
                    if (bf.DataField == colName)
                    {
                        index = myGridView.Columns.IndexOf(field);
                        break;
                    }
                }
                //TemplateField
                else if (field.GetType().ToString() == "System.Web.UI.WebControls.TemplateField")
                {
                    TemplateField tf = (TemplateField)field;
                    if (tf.ItemTemplate.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                    {
                        System.Web.UI.WebControls.DropDownList dropdownField = (System.Web.UI.WebControls.DropDownList)tf.ItemTemplate;
                        if (dropdownField.ID.ToString() == colName)
                        {
                            index = myGridView.Columns.IndexOf(field);
                            break;
                        }
                    }
                    else if (tf.ItemTemplate.GetType().ToString() == "System.Web.UI.CompiledBindableTemplateBuilder")
                    {

                        //Questo ramo non funziona ...!!!
                        System.Web.UI.CompiledBindableTemplateBuilder compiledBindableTemplateBuilder = (System.Web.UI.CompiledBindableTemplateBuilder)tf.ItemTemplate;

                        if (compiledBindableTemplateBuilder.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                        {
                            //System.Web.UI.WebControls.TextBox textBox = (System.Web.UI.WebControls.TextBox)compiledBindableTemplateBuilder.tf.ItemTemplate;
                            //if (dropdownField.ID.ToString() == colName)
                            //{
                            //    index = myGridView.Columns.IndexOf(field);
                            //    break;
                            //}
                        }

                        if (compiledBindableTemplateBuilder.GetType().ToString() == colName)
                        {
                            index = myGridView.Columns.IndexOf(field);
                            break;
                        }
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// Mappa in una HashTable i nomi delle colonne di una GridView con i rispettivi indici delle celle
        /// </summary>
        /// <param name="gv">GridView da esaminare</param>
        /// <param name="dic">HashTable da riempire con le coppie (indice, nome)</param>
        public static Dictionary<string, int> MapGridViewColumnNames(GridView gv)
        {
            Dictionary<string, int> colNames = new Dictionary<string, int>();
            if (gv != null)
            {

                for (int i = 0; i < gv.Columns.Count; i++)
                {
                    DataControlField field = gv.Columns[i];
                    BoundField bfield = field as BoundField;

                    if (gv.Columns[i].HeaderText != "")
                        colNames.Add(gv.Columns[i].HeaderText, i);
                    else
                        if (bfield != null)
                            colNames.Add(bfield.DataField, i);
                }
            }
            return colNames;
        }

        /// <summary>
        /// Cerca nella GridView data l'indice della riga corrispondente alla DataKey data.
        /// Restituisce l'indice, se trovato, altrimenti restituisce -1.
        /// </summary>	
        protected int findRowByDataKey(GridView gv, DataKey key)
        {
            foreach (GridViewRow gvrdett in gv.Rows)
            {
                DataKey index = (DataKey)gv.DataKeys[gvrdett.RowIndex];

                if (index.Value == key.Value)
                    return gvrdett.RowIndex;
            }
            return -1;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            callContentFunction("LoadDataSource");
        }

        /// <summary>
        /// Registrazione script per dichiarazione variabile "percorso" utilizzata per apertura dell'editor. Lo script di default si chiama "openEditor_JS".
        /// </summary>
        /// <param name="percorso">Percorso dell'Editor da visualizzare nella popUp</param>
        protected void RegisterScriptPercorsoEditor(string percorsoEdit, string percorsoNew)
        {
            RegisterScriptPercorsoEditor("openEditor_JS", percorsoEdit, percorsoNew);
        }

        /// <summary>
        /// Registrazione script per dichiarazione variabile "percorso" utilizzata per apertura dell'editor
        /// </summary>
        /// <param name="scriptName">Nome dello Script da registrare</param>
        /// <param name="percorso">Percorso dell'Editor da visualizzare nella popUp</param>
        protected void RegisterScriptPercorsoEditor(string scriptName, string percorsoEdit, string percorsoNew)
        {
            string strScript = @"<script type='text/javascript'>
                                var percorsoEdit = '" + percorsoEdit + @"';
                                var percorsoNew = '" + percorsoNew + @"';
                                </script>";

            if (!this.ClientScript.IsStartupScriptRegistered(scriptName))
            {
                this.ClientScript.RegisterStartupScript(GetType(), scriptName, strScript);
            }

        }

        /// <summary>
        /// Blocco le funzionalità di editing della griglia. Se TRUE l'utente può solo visualizzare i dati.
        /// </summary>
        /// <returns></returns>
        Boolean BlockGrid()
        {
            Boolean RetValue = false;

            if (!allowEdit && !allowDelete)
            {
                RetValue = true;
            }

            return RetValue;
        }

        #endregion

        #region Standard_Button
        
            /// <summary>
            /// Genera pulsantiera standard per i browser.
            /// Nel codice della pagina deve essere presente il tag div "toolbar".
            /// </summary>
            protected void GenerateStandardBrowserButtons(int editorType)
            {
                GenerateStandardBrowserButtons(false, false, true, true, true, true, true, editorType);
            }

            /// <summary>
            /// Genera pulsantiera standard per i browser, definendo i pulsanti necessari nella singola pagina.
            /// Nel codice della pagina deve essere presente il tag div "toolbar".
            /// </summary>
            /// <param name="enableSave">Abilita pulsante Salva</param>
            /// <param name="enableClose">Abilita pulsante Chiudi maschera</param>
            /// <param name="enablePrint">Abilita pulsante Stampa</param>
            /// <param name="enableExport">Abilita pulsante Export (XLS, CSV, ...)</param>
            /// <param name="enableNew">Abilita pulsante Nuovo</param>
            /// <param name="enablePopUpNewRecord">Abilita pop up per creazione Nuovo record</param>
            /// <param name="enableHelp">Abilita pulsante Help</param>
            /// <param name="enableSearch">Abilita pulsante Ricerca</param>
            protected void GenerateStandardBrowserButtons(bool enableSave, bool enableClose, bool enablePrint, bool enableExport, bool enableNew, bool enableHelp, bool enableSearch, int editorType)
            {
                GenerateStandardBrowserButtons("toolbar", enableSave, enableClose, enablePrint, enableExport, enableNew, enableHelp, enableSearch, editorType);
            }

            /// <summary>
            /// Genera pulsantiera standard per i browser, definendo il div che conterrà la pulsantiera e i pulsanti necessari nella singola pagina.
            /// </summary>
            /// <param name="idPlaceHolder">Id div che contiene la pulsantiera</param>
            /// <param name="enableSave">Abilita pulsante Salva</param>
            /// <param name="enableClose">Abilita pulsante Chiudi maschera</param>
            /// <param name="enablePrint">Abilita pulsante Stampa</param>
            /// <param name="enableExportXls">Abilita pulsante Export XLS</param>
            /// <param name="enableExportCsv">Abilita pulsante Export CSV</param>
            /// <param name="enableNew">Abilita pulsante Nuovo record</param>
            /// <param name="enableHelp">Abilita pulsante Help</param>
            /// <param name="enableSearch">Abilita pulsante Ricerca</param>
            protected void GenerateStandardBrowserButtons(string idPlaceHolder, bool enableSave, bool enableClose, bool enablePrint, bool enableExport, bool enableNew, bool enableHelp, bool enableSearch, int editorType)
            {
                Control toolbarPlaceHolder = null;
                if (this.Page.Form != null)
                {
                    toolbarPlaceHolder = this.Page.Form.FindControl(idPlaceHolder);
                }
                if (toolbarPlaceHolder != null)
                {
                    HtmlGenericControl span;
                
                    if (enableHelp)
                    {
                        span = new HtmlGenericControl("span");
                        HelpButton = new Button();
                        HelpButton.ID = "HelpButton";
                        HelpButton.ToolTip = GetValueDizionarioUI("HELP");

                        string className = this.Page.GetType().BaseType.Name;
                        HelpButton.OnClientClick = "openHelp('" + className + "');return false;";

                        span.Controls.Add(HelpButton);
                        toolbarPlaceHolder.Controls.AddAt(0, span);
                    }
                    if (enableExport)
                    {
                        span = new HtmlGenericControl("span");
                        ExportButton = new Button();
                        ExportButton.ID = "ExportButton";
                        ExportButton.ToolTip = GetValueDizionarioUI("EXPORTXLS");
                        span.Controls.Add(ExportButton);
                        toolbarPlaceHolder.Controls.AddAt(0, span);
                    }
                    if (enablePrint)
                    {
                        span = new HtmlGenericControl("span");
                        PrintButton = new Button();
                        PrintButton.ID = "PrintButton";
                        PrintButton.OnClientClick = "PrintPage();return false;";
                        PrintButton.ToolTip = GetValueDizionarioUI("STAMPA");
                        span.Controls.Add(PrintButton);
                        toolbarPlaceHolder.Controls.AddAt(0, span);
                    }
                    if (enableNew)
                    {
                        span = new HtmlGenericControl("span");
                        NewButton = new Button();
                        NewButton.ID = "NewButton";
                        NewButton.ToolTip = GetValueDizionarioUI("NUOVO");
                        NewButton.UseSubmitBehavior = false;

                        switch (editorType)
                        {
                            case editRow_PopUp:
                                NewButton.OnClientClick = "openPopUpNewRecord();return false;";
                                break;
                            case editRow_SubstituteBrowser:
                                NewButton.OnClientClick = "substituteBrowserNewRecord();return false;";
                                break;
                            case editRow_Inline:
                                NewButton.OnClientClick = "addRowInMyGridView();return false;";
                                break;
                        }

                        span.Controls.Add(NewButton);
                        toolbarPlaceHolder.Controls.AddAt(0, span);
                    }
                    if (enableSave)
                    {
                        span = new HtmlGenericControl("span");
                        SaveButton = new Button();
                        SaveButton.ID = "SaveButton";
                        SaveButton.ToolTip = GetValueDizionarioUI("BTN_CONFERMA");
                        span.Controls.Add(SaveButton);
                        toolbarPlaceHolder.Controls.AddAt(0, span);
                    }
                    if (enableClose)
                    {
                        span = new HtmlGenericControl("span");
                        CloseButton = new Button();
                        CloseButton.ID = "CloseButton";
                        CloseButton.OnClientClick = "hideEditorDialog('editorDialog');return false;";
                        CloseButton.UseSubmitBehavior = false;
                        CloseButton.ToolTip = GetValueDizionarioUI("CHIUDI");
                        span.Controls.Add(CloseButton);
                        toolbarPlaceHolder.Controls.AddAt(0, span);
                    }

                    span = new HtmlGenericControl("span");
                    RefreshButton = new Button();
                    RefreshButton.ID = "btnRefresh";
                    // Di default il pulsante è nascosto, tranne per alcuni browser.
                    RefreshButton.CssClass = "displayNone";
                    RefreshButton.UseSubmitBehavior = false;
                    RefreshButton.Click += new EventHandler(RefreshButton_Click);
                    span.Controls.Add(RefreshButton);
                    toolbarPlaceHolder.Controls.AddAt(0, span);
                }
            }

            void RefreshButton_Click(object sender, EventArgs e)
            {
                callContentFunction("LoadDataSource");
            }

            /// <summary>
            /// Genera la chiamata standard da assegnare al pulsante con id ExportXlsButton per estrarre il file XLS.
            /// </summary>
            /// <param name="className">Nome della classe</param>
            /// <param name="classMethod">Nome del metodo</param>
            /// <param name="reportTime">Flag per visualizzare l'ora accanto alla data</param>
            protected void GenerateStandardXls(string className, string classMethod, bool reportTime)
            {
                //editRow_PopUp è inteso come standard (per la retro compatibilità)
                GenerateStandardXls(className, classMethod, reportTime, editRow_PopUp);
            }

            /// <summary>
            /// Genera la chiamata standard da assegnare al pulsante con id ExportXlsButton per estrarre il file XLS.
            /// </summary>
            /// <param name="className">Nome della classe</param>
            /// <param name="classMethod">Nome del metodo</param>
            /// <param name="reportTime">Flag per visualizzare l'ora accanto alla data</param>
            protected void GenerateStandardXls(string className, string classMethod, bool reportTime, int editorType)
            {
                HtmlButton exportXlsButton = this.Page.Form.FindControl("ExportXlsButton") as HtmlButton; 
                if (ExportButton != null)
                {
                    string percorso = @"../Common/Excel.aspx?EDITOR_TYPE=" + editorType + "&className=" + className + "&classMethod=" + classMethod;

                    //reportTime lo concateno solo se vale TRUE
                    if (reportTime)
                        percorso += "&reportTime=SI";

                    string chiamata = "javascript:self.parent.openEditor('" + percorso + "'); return false;";
                    ExportButton.Attributes["onClick"] = chiamata;
                }
            }

        #endregion
        
    }
}