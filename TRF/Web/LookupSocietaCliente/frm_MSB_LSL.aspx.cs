#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Ruoli Cliente
// Nome File:   frm_MSB_CCR.aspx
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
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using SDG.GestioneUtenti.Web;
using System.Globalization;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using SDG.Utility;
using SDG.GestioneUtenti;

public partial class Web_LookupSocietaCliente_frm_MSB_LSL : BasePageBrowser
{
    #region Web Control Declaration    

    //PAGE VARIABLES    
    protected LookupSocietaCliente objLookupSocietaCliente;

    protected int permessoDEL;
    protected Int32 idCliente;
    protected DateTimeFormatInfo myDTFI;

    #endregion

    #region Proprieta

    protected string VSortExpression
    {
        get { return (string)(ViewState["VSortExpression"] == null ? "LSL_ID_SOCIETA_CLIENTE" : ViewState["VSortExpression"]); }
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
            CreateNewRecord.InnerText = GetValueDizionarioUI("AGGIUNGI");

            if (!IsPostBack)
            {


                LabelTitolo.InnerText = GetValueDizionarioUI("SOCIETA");
                GridViewClientiSocieta.Columns[GridIndexOfByName(GridViewClientiSocieta, "LSL_DESCRIZIONE")].HeaderText = GetValueDizionarioUI("DESCRIZIONE");
                GridViewClientiSocieta.Columns[GridIndexOfByName(GridViewClientiSocieta, "LSL_SIGLA")].HeaderText = GetValueDizionarioUI("SIGLA");
                GridViewClientiSocieta.Columns[6].HeaderText = GetValueDizionarioUI("ELIMINATA");
                

                //DropDownList
                DropDownListRecordPagina.Items.Insert(0, new ListItem("5", "5"));
                DropDownListRecordPagina.Items.Insert(1, new ListItem("10", "10"));
                DropDownListRecordPagina.Items.Insert(2, new ListItem("15", "15"));
                DropDownListRecordPagina.Items.Insert(3, new ListItem("25", "25"));
                DropDownListRecordPagina.Items.Insert(4, new ListItem("35", "35"));
                DropDownListRecordPagina.Items.Insert(5, new ListItem("75", "75"));
                DropDownListRecordPagina.Items.Insert(6, new ListItem("100", "100"));

                GridViewClientiSocieta.PageSize = Convert.ToInt32(DropDownListRecordPagina.Items[0].Value);
                GridViewClientiSocieta.PageIndex = VPage_Index;

                LoadDataSource();

                //ButtonNuovoCampo.Attributes["onClick"] = "javascript:parent.parent.openEditor('" + "../LookupSocietaCliente/frm_MSE_CNC.aspx?MODALITA=NEW&ID_CLIENTE=" + idCliente + "');return false;";
                CreateNewRecord.Attributes["onClick"] = "javascript:openModal('" + "../LookupSocietaCliente/frm_MSE_LSL.aspx?MODALITA=NEW&ID_CLIENTE=" + idCliente + "', 'LSL');return false;";
                CreateNewRecord.Attributes["data-toggle"] = "modal";
                CreateNewRecord.Attributes["data-target"] = "#modalPage";
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
            SetPageControlAccess("LSL");
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

        objLookupSocietaCliente = new LookupSocietaCliente();
        string[] societaClienteDataKeys = { "LSL_ID_SOCIETA_CLIENTE", "CLI_ID_CLIENTE"};

        GridViewClientiSocieta.DataKeyNames = societaClienteDataKeys;
        GridViewClientiSocieta.DataBound += new EventHandler(GridViewClientiSocieta_DataBound);
        GridViewClientiSocieta.PageIndexChanging += new GridViewPageEventHandler(GridViewClientiSocieta_PageIndexChanging);
        GridViewClientiSocieta.Sorting += new GridViewSortEventHandler(GridViewClientiSocieta_Sorting);
        //GridViewCampiNascosti.RowCreated += new GridViewRowEventHandler(GridViewCampiNascosti.MyGridViewRowCreated);        
        GridViewClientiSocieta.RowCommand += new GridViewCommandEventHandler(GridViewClientiSocieta_RowCommand);
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
            dt = LookupSocietaCliente.List(VWhereClause).Tables[0];
            GridViewClientiSocieta.DataSource = dt;
            GridViewClientiSocieta.DataBind();
            LabelNroRecord.InnerText = GetValueDizionarioUI("SOCIETA") + " : " + dt.Rows.Count.ToString();
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void GridViewClientiSocieta_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Si perde la riga selezionata
        VPage_Index = e.NewPageIndex;
        GridViewClientiSocieta.PageIndex = e.NewPageIndex;
        LoadDataSource();
    }

    protected void GridViewClientiSocieta_Sorting(object sender, GridViewSortEventArgs e)
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
        GridViewClientiSocieta.VSortExpression = e.SortExpression;
        GridViewClientiSocieta.VSortDirection = VSortDirection;
        LoadDataSource();
    }

    protected void GridViewClientiSocieta_DataBound(object sender, EventArgs e)
    {
        try
        {
            string percorso = string.Empty;
            string chiamata = string.Empty;
            foreach (GridViewRow row in GridViewClientiSocieta.Rows)
            {
                LinkButton btnEdit = (LinkButton)row.FindControl("ButtonEditRowItem");
                btnEdit.Text = "<i class='fas fa-pencil-alt' data-toggle='modal' data-target='#modalPage'></i>";
                if (allowEdit)
                {
                    percorso = @"../LookupSocietaCliente/frm_MSE_LSL.aspx?MODALITA=EDIT&ID_CLIENTE=" + GridViewClientiSocieta.DataKeys[row.RowIndex].Values["CLI_ID_CLIENTE"] + "&LSL_ID_SOCIETA_CLIENTE=" + GridViewClientiSocieta.DataKeys[row.RowIndex].Values["LSL_ID_SOCIETA_CLIENTE"];
                    //chiamata = "javascript:parent.parent.openEditor('" + percorso + "');return false;";
                    chiamata = "javascript:openModal('" + percorso + "', 'LSL');return false;";
                    row.Cells[1].Attributes["onClick"] = chiamata;

                    skmExtendedControls.skmLinkButton btnDelete = ((skmExtendedControls.skmLinkButton)row.FindControl("ButtonDeleteRowItem"));
                    if (btnDelete != null)
                    {
                        if (btnDelete.CommandName == "DELETE_COMMAND")
                        {
                            //btnDelete.Attributes["onclick"] = "if(confirmDelete()){return true;}else{return false;}";
                            btnDelete.CommandArgument = Convert.ToInt64(GridViewClientiSocieta.DataKeys[row.RowIndex].Values["LSL_ID_SOCIETA_CLIENTE"]).ToString();
                            btnDelete.ConfirmMessage = GetValueDizionarioUI("CONFIRM_DELETION");
                            btnDelete.Text = "<i class='fa fa-times'></i>";
                        }
                    }
                }
                else
                {
                    skmExtendedControls.skmLinkButton btnDelete = (skmExtendedControls.skmLinkButton)row.FindControl("ButtonDeleteRowItem");
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

    protected void GridViewClientiSocieta_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_COMMAND")
        {
            int chiave = Convert.ToInt32(e.CommandArgument);
            try
            {
                LookupSocietaCliente objLookupSocietaCliente = new LookupSocietaCliente();
                LookupSocietaCliente.Delete(chiave,idLoggedUser);
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
        GridViewClientiSocieta.PageSize = Convert.ToInt32(DropDownListRecordPagina.SelectedValue);
        LoadDataSource();
    }

    #endregion

}
