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
using SDG.GestioneUtenti;

public partial class Web_RiepilogoUtenti_frm_MSB_RPG_UTE : BasePageBrowser
{
    #region Web Control Declaration    

    //PAGE VARIABLES    
    protected Utente objUtente;    
         
    protected int permessoDEL;    
    protected Int32 idCliente;
    protected DateTimeFormatInfo myDTFI;
    protected bool primoAccesso = true;

    #endregion

    #region Proprieta

    protected string VSortExpression
    {
        get { return (string)(ViewState["VSortExpression"] == null ? "UTENTE" : ViewState["VSortExpression"]); }
        set { ViewState["VSortExpression"] = value; }
    }

    protected string VSortDirection
    {
        get { return (string)(ViewState["VSortDirection"] == null ? "ASC" : ViewState["VSortDirection"]); }
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

    //protected Dictionary<string, int> VGridViewColNames
    //{
    //    get { return (Dictionary<string, int>)(ViewState["VGridViewColNames"]); }
    //    set { ViewState["VGridViewColNames"] = value; }
    //}

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

            if (!IsPostBack)
            {
                VGridViewColNames = MapGridViewColumnNames(GridViewRpgUtenti);

                LabelTitolo.InnerText = GetValueDizionarioUI("UTENTI");
                LabelUtente.InnerText = GetValueDizionarioUI("UTENTE");
                LabelCDC.InnerText = GetValueDizionarioUI("CENTRO_DI_COSTO");
                btnCerca.Text = GetValueDizionarioUI("CERCA");
                GridViewRpgUtenti.Columns[VGridViewColNames["UTE_ID_UTENTE"]].HeaderText = GetValueDizionarioUI("ID_UTENTE");
                GridViewRpgUtenti.Columns[VGridViewColNames["UTENTE"]].HeaderText = GetValueDizionarioUI("UTENTE");
                GridViewRpgUtenti.Columns[VGridViewColNames["UTE_MATRICOLA"]].HeaderText = GetValueDizionarioUI("MATRICOLA");
                GridViewRpgUtenti.Columns[VGridViewColNames["UTE_EMAIL"]].HeaderText = GetValueDizionarioUI("EMAIL");
                ButtonExit.Text = GetValueDizionarioUI("USCITA");

                //DropDownList
                DropDownListRecordPagina.Items.Insert(0, new ListItem("5", "5"));
                DropDownListRecordPagina.Items.Insert(1, new ListItem("10", "10"));
                DropDownListRecordPagina.Items.Insert(2, new ListItem("15", "15"));
                DropDownListRecordPagina.Items.Insert(3, new ListItem("25", "25"));
                DropDownListRecordPagina.Items.Insert(4, new ListItem("35", "35"));
                DropDownListRecordPagina.Items.Insert(5, new ListItem("75", "75"));
                DropDownListRecordPagina.Items.Insert(6, new ListItem("100", "100"));

                GridViewRpgUtenti.PageSize = Convert.ToInt32(DropDownListRecordPagina.Items[0].Value);
                GridViewRpgUtenti.PageIndex = VPage_Index;                               
                
                LoadDataSource();                
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
            SetPageControlAccess("MSB_RIV");
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
        objUtente = new Utente();
        string[] UtenteDataKeys = { "UTE_ID_UTENTE" , "UTENTE", "UTE_COGNOME" , "UTE_NOME" , "CDC_CODICE_CENTRO_DI_COSTO" };

        GridViewRpgUtenti.DataKeyNames = UtenteDataKeys;
        GridViewRpgUtenti.DataBound += new EventHandler(GridViewRpgUtenti_DataBound);
        GridViewRpgUtenti.PageIndexChanging += new GridViewPageEventHandler(GridViewRpgUtenti_PageIndexChanging);
        GridViewRpgUtenti.Sorting += new GridViewSortEventHandler(GridViewRpgUtenti_Sorting);        
        DropDownListRecordPagina.SelectedIndexChanged += new EventHandler(DropDownListRecordPagina_SelectedIndexChanged);
        btnCerca.Click += new EventHandler(btnCerca_Click);
    }

         
    #endregion

    #region Web Form Event Handler
    
    protected void LoadDataSource()
    {
        try
        {            
            VWhereClause = "WHERE UTENTE.CLI_ID_CLIENTE = " + idCliente + " AND UTE_FLAG_ELIMINATO = 0 ";
            if (txtUtente.Value != "")
                VWhereClause += " AND COALESCE(UTE_COGNOME + ' ' + UTE_NOME,UTE_COGNOME) LIKE '%" + Utilita.safeParamSql(txtUtente.Value) + "%'";

            VWhereClause += " ORDER BY UTE_COGNOME ASC,UTE_NOME ASC" ;

            if (primoAccesso)
                VWhereClause = "WHERE 1=2 ";

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
            objUtente.SqlWhereClause = VWhereClause;
            dt = objUtente.ListDropDownViaggiatore().Tables[0];
            GridViewRpgUtenti.DataSource = dt;
            GridViewRpgUtenti.DataBind();
            LabelNroRecord.InnerText = GetValueDizionarioUI("UTENTI") + " : " + dt.Rows.Count.ToString();
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");         
        }
    }

    protected void GridViewRpgUtenti_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Si perde la riga selezionata
        primoAccesso = false;
        VPage_Index = e.NewPageIndex;
        GridViewRpgUtenti.PageIndex = e.NewPageIndex;
        LoadDataSource(); 
    }

    protected void GridViewRpgUtenti_Sorting(object sender, GridViewSortEventArgs e)
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
       GridViewRpgUtenti.VSortExpression = e.SortExpression;
       GridViewRpgUtenti.VSortDirection = VSortDirection; 
       LoadDataSource(); 
    }

    protected void GridViewRpgUtenti_DataBound(object sender, EventArgs e)
    {
        try
        {           
            string percorso = string.Empty;
            string chiamata = string.Empty;
            foreach (GridViewRow row in GridViewRpgUtenti.Rows)
                {
                    chiamata = "associaViaggiatore('" + GridViewRpgUtenti.DataKeys[row.RowIndex].Values["UTE_ID_UTENTE"].ToString() + "')";
                    row.Attributes["onClick"] = chiamata;                     
                }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
  
    protected void DropDownListRecordPagina_SelectedIndexChanged(object sender, EventArgs e)
    {
        primoAccesso = false;
        GridViewRpgUtenti.PageSize = Convert.ToInt32(DropDownListRecordPagina.SelectedValue);
        LoadDataSource(); 
    }

    protected void btnCerca_Click(object sender, EventArgs e)
    {
        try
        {
            primoAccesso = false;
            LoadDataSource();
        }

        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }

    }
    
    #endregion
   
}
