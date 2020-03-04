#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti Gruppi Cliente
// Nome File:   frm_MSB_CGC.aspx
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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using SDG.GestioneUtenti.Web;
using System.Globalization;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using SDG.Utility;

public partial class Web_CrossGruppiClienteUtentii_frm_MSB_CGC : BasePageBrowser
{
    #region Web Control Declaration    

    //PAGE VARIABLES    
    protected CrossGruppiClienteUtenti objCrossGruppiClienteUtenti;

    protected int permessoDEL;
    protected Int32 idGruppoClienti;
    protected DateTimeFormatInfo myDTFI;
    protected int qCLI_ID_CLIENTE;

    #endregion

    #region Proprieta

    protected string VSortExpression
    {
        get { return (string)(ViewState["VSortExpression"] == null ? "cgc_id_cross_gruppi_cliente_utenti" : ViewState["VSortExpression"]); }
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
            idGruppoClienti = Convert.ToInt32(Request.QueryString["ID_GRUPPO_CLIENTI"]);
            qCLI_ID_CLIENTE = Convert.ToInt32(Request.QueryString["CLI_ID_CLIENTE"]);

            base.PageLoad(sender, e);

            SetPageControlAccess();
            LabelNroRecord.InnerText = "";
            LabelRecPagina.InnerText = GetValueDizionarioUI("RECORD_PAGINA");
            CreateNewRecord.InnerText = GetValueDizionarioUI("AGGIUNGI");

            if (!IsPostBack)
            {
                VGridViewColNames = MapGridViewColumnNames(GridViewGruppiClienteUtenti);

                LabelTitolo.InnerText = GetValueDizionarioUI("UTENTI");
                GridViewGruppiClienteUtenti.Columns[GridIndexOfByName(GridViewGruppiClienteUtenti, "UTENTE")].HeaderText = GetValueDizionarioUI("UTENTE");

                

                //DropDownList
                DropDownListRecordPagina.Items.Insert(0, new ListItem("5", "5"));
                DropDownListRecordPagina.Items.Insert(1, new ListItem("10", "10"));
                DropDownListRecordPagina.Items.Insert(2, new ListItem("15", "15"));
                DropDownListRecordPagina.Items.Insert(3, new ListItem("25", "25"));
                DropDownListRecordPagina.Items.Insert(4, new ListItem("35", "35"));
                DropDownListRecordPagina.Items.Insert(5, new ListItem("75", "75"));
                DropDownListRecordPagina.Items.Insert(6, new ListItem("100", "100"));

                GridViewGruppiClienteUtenti.PageSize = Convert.ToInt32(DropDownListRecordPagina.Items[0].Value);
                GridViewGruppiClienteUtenti.PageIndex = VPage_Index;

                LoadDataSource();

                //ButtonNuovoCampo.Attributes["onClick"] = "javascript:parent.parent.openEditor('" + "../CrossGruppiClienteUtenti/frm_MSE_CNC.aspx?MODALITA=NEW&ID_CLIENTE=" + idCliente + "');return false;";
                CreateNewRecord.Attributes["onClick"] = "javascript:openModal('" + "../CrossGruppiClienteUtenti/frm_MSE_CGC.aspx?MODALITA=NEW&ID_GRUPPO_CLIENTI=" + idGruppoClienti + "&CLI_ID_CLIENTE=" + qCLI_ID_CLIENTE + "', 'CGC');return false;";
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
            SetPageControlAccess("CGC");
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

        objCrossGruppiClienteUtenti = new CrossGruppiClienteUtenti();
        string[] dataKeys = { "cgc_id_cross_gruppi_cliente_utenti"};

        GridViewGruppiClienteUtenti.DataKeyNames = dataKeys;
        GridViewGruppiClienteUtenti.DataBound += new EventHandler(GridViewGruppiClienteUtenti_DataBound);
        GridViewGruppiClienteUtenti.PageIndexChanging += new GridViewPageEventHandler(GridViewGruppiClienteUtenti_PageIndexChanging);
        GridViewGruppiClienteUtenti.Sorting += new GridViewSortEventHandler(GridViewGruppiClienteUtenti_Sorting);
        //GridViewCampiNascosti.RowCreated += new GridViewRowEventHandler(GridViewCampiNascosti.MyGridViewRowCreated);        
        GridViewGruppiClienteUtenti.RowCommand += new GridViewCommandEventHandler(GridViewGruppiClienteUtenti_RowCommand);
        DropDownListRecordPagina.SelectedIndexChanged += new EventHandler(DropDownListRecordPagina_SelectedIndexChanged);
    }


    #endregion

    #region Web Form Event Handler

    protected void LoadDataSource()
    {
        try
        {
            VWhereClause = " ORDER BY " + VSortExpression + " " + VSortDirection;
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
            dt = objCrossGruppiClienteUtenti.List(idGruppoClienti, VWhereClause).Tables[0];
            GridViewGruppiClienteUtenti.DataSource = dt;
            GridViewGruppiClienteUtenti.DataBind();
            LabelNroRecord.InnerText = GetValueDizionarioUI("UTENTI") + " : " + dt.Rows.Count.ToString();
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void GridViewGruppiClienteUtenti_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Si perde la riga selezionata
        VPage_Index = e.NewPageIndex;
        GridViewGruppiClienteUtenti.PageIndex = e.NewPageIndex;
        LoadDataSource();
    }

    protected void GridViewGruppiClienteUtenti_Sorting(object sender, GridViewSortEventArgs e)
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
        GridViewGruppiClienteUtenti.VSortExpression = e.SortExpression;
        GridViewGruppiClienteUtenti.VSortDirection = VSortDirection;
        LoadDataSource();
    }

    protected void GridViewGruppiClienteUtenti_DataBound(object sender, EventArgs e)
    {
        try
        {
            string percorso = "";
            string chiamata = "";
            int contatore = 0;
            //Griglia contenente dati
            if (GridViewGruppiClienteUtenti.Rows.Count > 0)
            {
                // Use the Count property to determine whether the
                // DataKeys collection contains any items.
                if (GridViewGruppiClienteUtenti.DataKeys.Count > 0)
                {
                    IEnumerator keyEnumerator = GridViewGruppiClienteUtenti.DataKeys.GetEnumerator();
                    while (keyEnumerator.MoveNext())
                    {
                        DataKey key = (DataKey)keyEnumerator.Current;

                        if (allowDelete)
                        {
                            skmExtendedControls.skmLinkButton btnExtended = (skmExtendedControls.skmLinkButton)GridViewGruppiClienteUtenti.Rows[contatore].FindControl("ButtonDeleteGruppiClienteUtenti");
                            if (btnExtended != null)
                            {
                                if (btnExtended.CommandName == "DELETE_COMMAND")
                                {
                                    btnExtended.CommandArgument = Convert.ToInt64(key.Value).ToString();
                                    btnExtended.ConfirmMessage = GetValueDizionarioUI("CONFIRM_DELETION");
                                    //btnExtended.Text = objDizionarioUI["BUTTON_CANCELLA"];
                                    btnExtended.Text = "<i class='fa fa-times'></i>";
                                }
                            }
                        }
                        else
                        {
                            skmExtendedControls.skmLinkButton btnExtended = (skmExtendedControls.skmLinkButton)GridViewGruppiClienteUtenti.Rows[contatore].FindControl("ButtonDeleteGruppiClienteUtenti");
                            btnExtended.Enabled = false;
                        }

                        LinkButton btnEdit = (LinkButton)GridViewGruppiClienteUtenti.Rows[contatore].FindControl("ButtonEditGruppiClienteUtenti");
                        //btnEdit.Text = GetValueDizionarioUI("BUTTON_MODIFICA");
                        btnEdit.Text = "<i class='fas fa-pencil-alt' data-toggle='modal' data-target='#modalPage'></i>";
                        if (allowEdit)
                        {
                            percorso = @"frm_MSE_CGC.aspx?MODALITA=EDIT&CGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI=" + GridViewGruppiClienteUtenti.DataKeys[contatore].Value + "&ID_GRUPPO_CLIENTI=" + idGruppoClienti;
                            //chiamata = "javascript:parent.openEditor('" + percorso + "');return false;";
                            chiamata = "javascript:openModal('" + percorso + "', 'CGC');return false;";
                            GridViewGruppiClienteUtenti.Rows[contatore].Cells[1].Attributes["onClick"] = chiamata;
                        }
                        else
                        {
                            percorso = @"frm_MSE_CGC.aspx?MODALITA=VIEW&CGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI=" + GridViewGruppiClienteUtenti.DataKeys[contatore].Value + "&ID_GRUPPO_CLIENTI=" + idGruppoClienti;
                            //chiamata = "javascript:parent.openEditor('" + percorso + "');return false;";
                            chiamata = "javascript:openModal('" + percorso + "', 'CGC');return false;";
                            GridViewGruppiClienteUtenti.Rows[contatore].Cells[1].Attributes["onClick"] = chiamata;
                            //Cambiare icona 
                            btnEdit.Text = "<i class='fa fa-eye' data-toggle='modal' data-target='#modalPage'></i>";
                        }
                        contatore++;
                    }
                }
                else
                {
                    throw new System.Exception("GridViewGruppiClienteUtenti:no DataKey objects.");
                }
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void GridViewGruppiClienteUtenti_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_COMMAND")
        {
            int chiave = Convert.ToInt32(e.CommandArgument);
            try
            {
                CrossGruppiClienteUtenti objCrossGruppiClienteUtenti = new CrossGruppiClienteUtenti();
                objCrossGruppiClienteUtenti.Delete(chiave);
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
        GridViewGruppiClienteUtenti.PageSize = Convert.ToInt32(DropDownListRecordPagina.SelectedValue);
        LoadDataSource();
    }

    #endregion

}
