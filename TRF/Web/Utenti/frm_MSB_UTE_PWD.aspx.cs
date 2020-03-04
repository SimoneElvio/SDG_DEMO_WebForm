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
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using System.Net.Mail;
using System.Threading;

public partial class Web_Utenti_frm_MSB_UTE_PWD : BasePageBrowser
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
     
        GridViewUtenti.PageSize = Convert.ToInt32(DropDownListRecordPagina.SelectedValue);
        
        if (!IsPostBack)
        {
            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "UTE_NOME")].HeaderText = GetValueDizionarioUI("NOME");            
            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "UTE_COGNOME")].HeaderText = GetValueDizionarioUI("COGNOME");
            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "UTE_USER_ID")].HeaderText = GetValueDizionarioUI("USER_ID");
            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "UTE_EMAIL")].HeaderText = GetValueDizionarioUI("EMAIL");
            GridViewUtenti.Columns[GridIndexOfByName(GridViewUtenti, "CLI_RAGIONE_SOCIALE")].HeaderText = GetValueDizionarioUI("AZIENDA");            
           
            //Label
            LabelTitolo.InnerText = GetValueDizionarioUI("UTENTI");
            LabelRecPagina.InnerText = GetValueDizionarioUI("RECORD_PAGINA");
            LabelElemSel.InnerText = GetValueDizionarioUI("ELEMENTI_SELEZIONATI");
            //Pulsanti
            ButtonFiltroUtente.Text = GetValueDizionarioUI("FILTRO");
            btnCerca.Text = GetValueDizionarioUI("CERCA");
            LabelCognome.InnerText = GetValueDizionarioUI("COGNOME");
            LabelNome.InnerText = GetValueDizionarioUI("NOME");
            LabelCodiceIndividuale.InnerText = GetValueDizionarioUI("CODICE_INDIVIDUALE");
            LabelEmail.InnerText = GetValueDizionarioUI("EMAIL");
            LabelCDC.InnerText = GetValueDizionarioUI("CODICE_CDC");
            LabelOnline.InnerText = GetValueDizionarioUI("SOLO_UTENTI_ONLINE");
            LabelUserId.InnerText = GetValueDizionarioUI("USER_ID");
            LabelCliente.InnerText = GetValueDizionarioUI("AZIENDA");
            LabelPwdInviata.InnerText = GetValueDizionarioUI("PASSWORD_INVIATA");

            Clienti objClienti = new Clienti();
            txtCliente.DataSource = objClienti.getDdlClienti();
            txtCliente.DataValueField = "CLI_ID_CLIENTE";
            txtCliente.DataTextField = "CLI_RAGIONE_SOCIALE";
            txtCliente.DataBind();
            txtCliente.Items.Insert(0, new ListItem("", ""));

            txtPwdInviata.Items.Insert(0, new ListItem("", ""));
            txtPwdInviata.Items.Insert(1, new ListItem("No", "0"));
            txtPwdInviata.Items.Insert(2, new ListItem("Sì", "1"));
           
            GridViewUtenti.DataBind();
        }        
        
      
        permessoDEL = dizionarioPermessi["UTE"];

        if (allowAccess == false)
        {
            WhereClause = " WHERE 1=2 ";
        }
                
    }
    #endregion

    #region Access Control
    private void SetPageControlAccess()
    {
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

        GridViewUtenti.DataSourceID = "ObjectDataSourceUtenti";
        string[] utentiDataKeys = { "UTE_ID_UTENTE" ,"UTE_STATO_UTENTE","ISONLINE" };
        GridViewUtenti.DataKeyNames = utentiDataKeys;
        GridViewUtenti.RowCreated += new GridViewRowEventHandler(GridViewUtenti.MyGridViewRowCreated);
        GridViewUtenti.RowDataBound += new GridViewRowEventHandler(GridViewUtenti.MyGridViewDataBound);        
        GridViewUtenti.SelectedIndexChanged += new EventHandler(GridViewUtenti_SelectedIndexChanged);
        GridViewUtenti.PageIndexChanged += new EventHandler(GridViewUtenti_PageIndexChanged);
        GridViewUtenti.RowCommand += new GridViewCommandEventHandler(GridViewUtenti_RowCommand);
        GridViewUtenti.DataBound += new EventHandler(GridViewUtenti_DataBound);
                    
        ObjectDataSourceUtenti.TypeName = "SDG.GestioneUtenti.Utente";        
        ObjectDataSourceUtenti.SelectMethod = "List";
        ObjectDataSourceUtenti.ObjectCreated += new ObjectDataSourceObjectEventHandler(ObjectDataSourceUtenti_SetProperties);
        ObjectDataSourceUtenti.Selected += new ObjectDataSourceStatusEventHandler(ObjectDataSourceUtenti_Selected);
        
        ButtonExportUtenti.Click += new EventHandler(ButtonExportUtenti_Click);

        //DropDownList
        DropDownListRecordPagina.Items.Insert(0, new ListItem("5", "5"));
        DropDownListRecordPagina.Items.Insert(1, new ListItem("10", "10"));
        DropDownListRecordPagina.Items.Insert(2, new ListItem("15", "15"));
        DropDownListRecordPagina.Items.Insert(3, new ListItem("25", "25"));
        DropDownListRecordPagina.Items.Insert(4, new ListItem("35", "35"));
        DropDownListRecordPagina.Items.Insert(5, new ListItem("75", "75"));
        DropDownListRecordPagina.Items.Insert(6, new ListItem("100", "100"));

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
        
    #endregion

    #region Web Form Event Handler


    protected void ObjectDataSourceUtenti_SetProperties(object sender, ObjectDataSourceEventArgs e)
    {
        Utente objUtenti = e.ObjectInstance as Utente;        
        if (WhereClause == "" || WhereClause == null)
            WhereClause = hWhereClause.Value;
        objUtenti.SqlWhereClause = WhereClause;
    }

    protected void GridViewUtenti_RowCommand(object sender, GridViewCommandEventArgs e)
    {       
    }
    
    protected void CheckBoxSelAll_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox)GridViewUtenti.HeaderRow.FindControl("CheckBoxSelAll");
        
        if (cb.Checked)
        {
            fieldSelected.Value = "hdr;";
            TextCountSel.Value = "0";            
            //foreach (DataRow dr in ((DataTable)ViewState["dvUte"]).Rows)
            //{
            //    fieldSelected.Value += "val_" + Convert.ToString(dr["UTE_ID_UTENTE"]) + ";";
            //    TextCountSel.Value = Convert.ToString(Convert.ToInt32(TextCountSel.Value) + 1);
            //}
            int[] test = (int[])ViewState["dvUte"];
            for (int i = 0; i < test.Length;i++)
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
            //ViewState["dvUte"] = dv.Table;
            int[] test = new int[dv.Table.Rows.Count];

            int i=0;
            foreach (DataRow dr in dv.Table.Rows)
            {
                test[i] = Convert.ToInt32(dr[0].ToString());
                i++;
            }
            ViewState["dvUte"] = test;
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
            //Response.End();
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
            //GridViewStd_InitializeLayout(GridViewUtenti,"");         
            foreach (GridViewRow row in GridViewUtenti.Rows)
            {           
                //Gestione immagine che indica lo stato dell'utente.
                Image imgStatoUtente = (Image)row.FindControl("imgStatoUtente");
                if (imgStatoUtente != null)
                {
                    if (Convert.ToBoolean(GridViewUtenti.DataKeys[contatore].Values["UTE_STATO_UTENTE"]) == true)
                    {
                        imgStatoUtente.ImageUrl = "../Images/userEnabled.gif";
                        imgStatoUtente.AlternateText = GetValueDizionarioUI("ABILITATO");
                    }
                    else
                    {
                        imgStatoUtente.ImageUrl = "../Images/userDisabled.gif";
                        imgStatoUtente.AlternateText = GetValueDizionarioUI("DISABILITATO");
                    }
                }

                //Gestione immagine che indica gli utenti online.
                Image imgOnline = (Image)row.FindControl("imgOnline");
                if (imgOnline != null)
                {
                    if (Convert.ToString(GridViewUtenti.DataKeys[contatore].Values["ISONLINE"]) == "1")
                        imgOnline.ImageUrl = "../Images/Online.png";
                    else                            
                        imgOnline.Visible = false;
                }
               

                LinkButton btnEdit = (LinkButton)row.FindControl("ButtonEditUtenti");
                btnEdit.Text = GetValueDizionarioUI("BUTTON_MODIFICA");
                //if (allowEdit)
                //{
                //    percorso = @"frm_MSE_UTE.aspx?MODALITA=EDIT&UTE_ID_UTENTE=" + GridViewUtenti.DataKeys[contatore].Values["UTE_ID_UTENTE"];
                //    chiamata = "javascript:parent.openEditor('" + percorso + "');return false;";                                                        
                //    row.Cells[1].Attributes["onClick"] = chiamata;
                //}
                //else //Deve entrare solo se in MODALITA=VIEW
                //{
                percorso = @"frm_MSE_UTE.aspx?MODALITA=VIEW&UTE_ID_UTENTE=" + GridViewUtenti.DataKeys[contatore].Values["UTE_ID_UTENTE"];
                chiamata = "javascript:parent.openEditor('" + percorso + "');return false;";                            
                row.Cells[0].Attributes["onClick"] = chiamata;
                //Cambiare icona
                btnEdit.Text = GetValueDizionarioUI("BUTTON_VISUALIZZA");
                //}

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
                //*************************************************Fine***********************************************                
                contatore++;
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
        }                                
    }

      
    protected void ButtonCerca_Click(object sender, EventArgs e)
    {
        try
        {
            BuildWhereClause();
            hWhereClause.Value = WhereClause;
            GridViewUtenti.SelectedIndex = -1;
            GridViewUtenti.DataBind();            
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

        if (txtCDC.Value != "")
        {
            WhereClause = WhereClause + " AND CDC_CODICE_CENTRO_DI_COSTO LIKE '" + txtCDC.Value + "%'";
        }

        if (txtEmail.Value != "")
        {
            WhereClause = WhereClause + " AND UTE_EMAIL LIKE '" + txtEmail.Value + "%'";
        }
        if (chkOnline.Checked)
        {
            WhereClause = WhereClause + " AND DATEDIFF(minute, UTENTE.UTE_LAST_PING, getdate()) < 2 ";
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
                    for (int i = 0; i < arrFieldSelected.Length; i++)
                    {

                        objUtente.Ute_id_utente = Convert.ToInt32(arrFieldSelected[contatoreUtentiSelez].Replace("val_", ""));
                        objUtente.Read();
                        objClienti.Read(Convert.ToInt32(objUtente.Cli_id_cliente), qCultureInfoName);

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

    

    #region Web Form PreRender
    private void frm_MSB_UTE_PreRender(object sender, EventArgs e)
    {
        try
        {            
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion

}
