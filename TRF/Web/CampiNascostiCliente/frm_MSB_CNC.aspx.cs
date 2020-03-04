#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   frm_MSB_UTE.aspx
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe di CodeBehind della pagina
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
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using SDG.GestioneUtenti.Web;
using System.Globalization;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using SDG.Utility;

public partial class Web_CampiNascostiCliente_frm_MSB_CNC : BasePageBrowser
{
    #region Web Control Declaration    

    //PAGE VARIABLES    
    protected CampiNascostiCliente objCampiNascostiCliente;

    protected int permessoDEL;
    protected Int32 idCliente;
    protected DateTimeFormatInfo myDTFI;

    #endregion

    #region Proprieta

    protected string VSortExpression
    {
        get { return (string)(ViewState["VSortExpression"] == null ? "CNC_ID_CAMPO_NASCOSTO" : ViewState["VSortExpression"]); }
        set { ViewState["VSortExpression"] = value; }
    }

    protected string VSortDirection
    {
        get { return (string)(ViewState["VSortDirection"] == null ? "DESC" : ViewState["VSortDirection"]); }
        set { ViewState["VSortDirection"] = value; }
    }

    protected Int32 VPage_Index
    {
        get { return (Int32)(ViewState["VPage_Index"] == null ? 0 : ViewState["VPage_Index"]); }
        set { ViewState["VPage_Index"] = value; }
    }

    protected string VWhereClause
    {
        get { return (string)(ViewState["VWhereClause"] == null ? "" : ViewState["VWhereClause"]); }
        set { ViewState["VWhereClause"] = value; }
    }

    protected Dictionary<string, int> VGridViewColNames
    {
        get { return (Dictionary<string, int>)(ViewState["VGridViewColNames"]); }
        set { ViewState["VGridViewColNames"] = value; }
    }

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            VPage_Index = Convert.ToInt32(Request.QueryString["PAGE_INDEX"]);
            idCliente = Convert.ToInt32(Request.QueryString["IDCLIENTE"]);

            base.PageLoad(sender, e);

            SetPageControlAccess();
            LabelNroRecord.InnerText = "";
            LabelRecPagina.InnerText = GetValueDizionarioUI("RECORD_PAGINA");
            ButtonNuovoCampo.InnerText = GetValueDizionarioUI("AGGIUNGI");

            if (!IsPostBack)
            {
                VGridViewColNames = MapGridViewColumnNames(GridViewCampiNascosti);

                LabelTitolo.InnerText = GetValueDizionarioUI("CAMPI_NASCOSTI");
                GridViewCampiNascosti.Columns[VGridViewColNames["CNC_NOME_CAMPO_NASCOSTO"]].HeaderText = GetValueDizionarioUI("NOME_CAMPO");
                GridViewCampiNascosti.Columns[VGridViewColNames["CNC_PAGINA"]].HeaderText = GetValueDizionarioUI("PAGINA");
                GridViewCampiNascosti.Columns[VGridViewColNames["CNC_TIPO"]].HeaderText = GetValueDizionarioUI("TIPO_CAMPO");
                GridViewCampiNascosti.Columns[VGridViewColNames["CNC_CHIAVE_LABEL"]].HeaderText = GetValueDizionarioUI("CHIAVE_LABEL");

                //DropDownList
                DropDownListRecordPagina.Items.Insert(0, new ListItem("5", "5"));
                DropDownListRecordPagina.Items.Insert(1, new ListItem("10", "10"));
                DropDownListRecordPagina.Items.Insert(2, new ListItem("15", "15"));
                DropDownListRecordPagina.Items.Insert(3, new ListItem("25", "25"));
                DropDownListRecordPagina.Items.Insert(4, new ListItem("35", "35"));
                DropDownListRecordPagina.Items.Insert(5, new ListItem("75", "75"));
                DropDownListRecordPagina.Items.Insert(6, new ListItem("100", "100"));

                GridViewCampiNascosti.PageSize = Convert.ToInt32(DropDownListRecordPagina.Items[0].Value);
                GridViewCampiNascosti.PageIndex = VPage_Index;

                LoadDataSource();
               
                //ButtonNuovoCampo.Attributes["onClick"] = "javascript:parent.parent.openEditor('" + "../CampiNascostiCliente/frm_MSE_CNC.aspx?MODALITA=NEW&ID_CLIENTE=" + idCliente + "');return false;";
                ButtonNuovoCampo.Attributes["onClick"] = "javascript:openModal('" + "../CampiNascostiCliente/frm_MSE_CNC.aspx?MODALITA=NEW&ID_CLIENTE=" + idCliente + "', 'CNC');return false;";
                ButtonNuovoCampo.Attributes["data-toggle"] = "modal";
                ButtonNuovoCampo.Attributes["data-target"] = "#modalPage";
            }
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion

    #region Access Control
    private void SetPageControlAccess()
    {
        try
        {
            SetPageControlAccess("CLINEW");
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
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
        myDTFI = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name, false).DateTimeFormat;
        objCampiNascostiCliente = new CampiNascostiCliente();
        string[] weekdayDataKeys = { "CNC_ID_CAMPO_NASCOSTO", "CLI_ID_CLIENTE" };

        GridViewCampiNascosti.DataKeyNames = weekdayDataKeys;
        GridViewCampiNascosti.DataBound += new EventHandler(GridViewCampiNascosti_DataBound);
        GridViewCampiNascosti.PageIndexChanging += new GridViewPageEventHandler(GridViewCampiNascosti_PageIndexChanging);
        GridViewCampiNascosti.Sorting += new GridViewSortEventHandler(GridViewCampiNascosti_Sorting);
        //GridViewCampiNascosti.RowCreated += new GridViewRowEventHandler(GridViewCampiNascosti.MyGridViewRowCreated);        
        GridViewCampiNascosti.RowCommand += new GridViewCommandEventHandler(GridViewCampiNascosti_RowCommand);
        DropDownListRecordPagina.SelectedIndexChanged += new EventHandler(DropDownListRecordPagina_SelectedIndexChanged);
    }


    #endregion

    #region Web Form Event Handler

    protected void LoadDataSource()
    {
        try
        {
            VWhereClause = "WHERE CLI_ID_CLIENTE = " + idCliente + " ORDER BY " + VSortExpression + " " + VSortDirection;
            AccessData();
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void AccessData()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = CampiNascostiCliente.List(VWhereClause).Tables[0];
            GridViewCampiNascosti.DataSource = dt;
            GridViewCampiNascosti.DataBind();
            LabelNroRecord.InnerText = GetValueDizionarioUI("CAMPI_NASCOSTI") + " : " + dt.Rows.Count.ToString();
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void GridViewCampiNascosti_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Si perde la riga selezionata
        VPage_Index = e.NewPageIndex;
        GridViewCampiNascosti.PageIndex = e.NewPageIndex;
        LoadDataSource();
    }

    protected void GridViewCampiNascosti_Sorting(object sender, GridViewSortEventArgs e)
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
        GridViewCampiNascosti.VSortExpression = e.SortExpression;
        GridViewCampiNascosti.VSortDirection = VSortDirection;
        LoadDataSource();
    }

    protected void GridViewCampiNascosti_DataBound(object sender, EventArgs e)
    {
        try
        {
            string percorso = string.Empty;
            string chiamata = string.Empty;
            foreach (GridViewRow row in GridViewCampiNascosti.Rows)
            {
                LinkButton btnEdit = (LinkButton)row.FindControl("ButtonEditCampiNascosti");
                btnEdit.Text = "<i class='fas fa-pencil-alt' data-toggle='modal' data-target='#modalPage'></i>";
                if (allowEdit)
                {
                    percorso = @"../CampiNascostiCliente/frm_MSE_CNC.aspx?MODALITA=EDIT&ID_CLIENTE=" + GridViewCampiNascosti.DataKeys[row.RowIndex].Values["CLI_ID_CLIENTE"] + "&CNC_ID_CAMPO=" + GridViewCampiNascosti.DataKeys[row.RowIndex].Values["CNC_ID_CAMPO_NASCOSTO"];
                    //chiamata = "javascript:parent.parent.openEditor('" + percorso + "');return false;";
                    chiamata = "javascript:openModal('" + percorso + "', 'CNC');return false;";
                    row.Cells[1].Attributes["onClick"] = chiamata;

                    skmExtendedControls.skmLinkButton btnDelete = ((skmExtendedControls.skmLinkButton)row.FindControl("ButtonDeleteCampiNascosti"));
                    if (btnDelete != null)
                    {
                        if (btnDelete.CommandName == "DELETE_COMMAND")
                        {
                            //btnDelete.Attributes["onclick"] = "if(confirmDelete()){return true;}else{return false;}";
                            btnDelete.CommandArgument = Convert.ToInt64(GridViewCampiNascosti.DataKeys[row.RowIndex].Values["CNC_ID_CAMPO_NASCOSTO"]).ToString();
                            btnDelete.ConfirmMessage = GetValueDizionarioUI("CONFIRM_DELETION");
                            btnDelete.Text = "<i class='fa fa-times'></i>";
                        }
                    }
                }
                else
                {
                    skmExtendedControls.skmLinkButton btnDelete = (skmExtendedControls.skmLinkButton)row.FindControl("ButtonDeleteCampiNascosti");
                    btnDelete.Visible = false;
                }
                
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void GridViewCampiNascosti_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_COMMAND")
        {
            int chiave = Convert.ToInt32(e.CommandArgument);
            try
            {
                CampiNascostiCliente objCampiNascostiCliente = new CampiNascostiCliente();
                CampiNascostiCliente.Delete(chiave);
                LoadDataSource();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }
    }

    protected void DropDownListRecordPagina_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewCampiNascosti.PageSize = Convert.ToInt32(DropDownListRecordPagina.SelectedValue);
        LoadDataSource();
    }

    #endregion

}
