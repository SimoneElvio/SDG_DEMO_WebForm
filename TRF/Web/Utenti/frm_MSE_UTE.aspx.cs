#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestone Utenti
// Nome File:   frm_MSE_UTE.aspx
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
using System.Data.SqlTypes;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SDG.Utility;
using BusinessObjects;
using System.Net.Mail;
using SDG.WorkFlow;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

public partial class Web_Utenti_frm_MSE_UTE : BasePage
{
    #region Web Form Control declarations
    protected Utente objUtente;
    protected Workflow objWorkflow;
    protected Clienti objClienti;
    //PAGE VARIABLES
    protected int qUTE_ID_UTENTE;

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        // PanelAnagrafica.Visible = true;

        //Ripresa parametri di pagina
        qMODALITA = Request.QueryString["MODALITA"];
        qUTE_ID_UTENTE = Convert.ToInt32(Request.QueryString["UTE_ID_UTENTE"]);

        SetPageControlAccess();

        //Set controlli per i permessi
        //Prima di effettuare eventuali disabilitazioni di altro genere
        BaseEnableControls(Page.Controls, allowEdit);

        divRecordError.Visible = false;

        if (!IsPostBack)
        {
            //Label
            LabelTitolo.InnerText = GetValueDizionarioUI("DETTAGLIO") + " " + GetValueDizionarioUI("UTENTI");
            // TitlePage.Text = LabelTitolo.InnerText;

            LabelNome.InnerText = GetValueDizionarioUI("NOME");
            LabelCognome.InnerText = GetValueDizionarioUI("COGNOME");
            LabelMatricola.InnerText = GetValueDizionarioUI("MATRICOLA");
            LabelUnitaContabile.InnerText = GetValueDizionarioUI("UNITA_CONTABILE");
            LabelCategoria.InnerText = GetValueDizionarioUI("CATEGORIA");
            LabelReparto.InnerText = GetValueDizionarioUI("REPARTO");
            LabelCDCAppartenenza.InnerText = GetValueDizionarioUI("CDC_APPARTENENZA");
            LabelCliente.InnerText = GetValueDizionarioUI("AZIENDA");
            LabelSocieta.InnerText = GetValueDizionarioUI("SOCIETA");
            LabelDescrizione.InnerText = GetValueDizionarioUI("DESCRIZIONE");
            LabelUser.InnerText = GetValueDizionarioUI("UTENTE");
            LabelPassword.InnerText = GetValueDizionarioUI("PASSWORD");
            LabelTelefono.InnerText = GetValueDizionarioUI("TELEFONO");
            LabelFax.InnerText = GetValueDizionarioUI("FAX");
            LabelEmail.InnerText = GetValueDizionarioUI("EMAIL");
            LabelStatoUtente.InnerText = GetValueDizionarioUI("STATO_UTENTE");
            LabelBypassImport.InnerText = GetValueDizionarioUI("BYPASS_IMPORT");
            LabelDataAggiornamento.InnerText = GetValueDizionarioUI("DATA_AGGIORNAMENTO");
            LabelTipoUtente.InnerText = GetValueDizionarioUI("TIPO_UTENTE");
            LabelExpirationDate.InnerText = GetValueDizionarioUI("EXPIRATION_DATE");
            LabelDataUltimoAccesso.InnerText = GetValueDizionarioUI("DATA_ULTIMO_ACCESSO");
            LabelAccessiErrati.InnerText = GetValueDizionarioUI("NRO_ACCESSI_ERRATI");
            LabelAutorizzazioneAutomatica.InnerText = GetValueDizionarioUI("AUTORIZZAZIONE_AUTO");
            LabelWorkflow.InnerText = GetValueDizionarioUI("WORKFLOW");
            LabelAvvisoWorkflow.InnerText = GetValueDizionarioUI("AVVISO_WORKFLOW");
            LabelPwdInviata.InnerText = GetValueDizionarioUI("PASSWORD_INVIATA");
            LabelDataInvioPwd.InnerText = GetValueDizionarioUI("DATA_INVIO_PWD");
            Label_ute_sesso.InnerText = GetValueDizionarioUI("SESSO");
            Label_ute_data_nascita.InnerText = GetValueDizionarioUI("DATA_NASCITA");
            LabelGruppoCliente.InnerText= GetValueDizionarioUI("GRUPPO");

            // Solo ADMIN può vedere tutti gli utenti
            if (dizionarioPermessi["ADM"] == objUtilita.AccessNone)
                DropDownListCDCAppartenenza.DataSource = Centri_di_costo.GetDdlCentroDiCosto(" AND CLI_ID_CLIENTE = " + Session["CLI_ID_CLIENTE"]);
            else
                DropDownListCDCAppartenenza.DataSource = Centri_di_costo.GetDdlCentroDiCosto();

            DropDownListCDCAppartenenza.DataValueField = "CDC_ID_CENTRO_DI_COSTO";
            DropDownListCDCAppartenenza.DataTextField = "codice_descrizione";
            DropDownListCDCAppartenenza.DataBind();
            DropDownListCDCAppartenenza.Items.Insert(0, new ListItem("", ""));

            ute_sesso.Items.Insert(0, new ListItem("", ""));
            ute_sesso.Items.Insert(0, new ListItem(GetValueDizionarioUI("MASCHIO"), Utente.maschio));
            ute_sesso.Items.Insert(0, new ListItem(GetValueDizionarioUI("FEMMINA"), Utente.femmina));


            Clienti objClienti = new Clienti();
            if (dizionarioPermessi["ADM"] == objUtilita.AccessNone)
            {
                if (Session["CLI_ID_CLIENTE"] != null)
                    DropDownListCliente.DataSource = objClienti.getDdlClienti(" WHERE CLIENTI.CLI_ID_CLIENTE = " + Session["CLI_ID_CLIENTE"]);
            }
            else
                DropDownListCliente.DataSource = objClienti.getDdlClienti();

            DropDownListCliente.DataValueField = "CLI_ID_CLIENTE";
            DropDownListCliente.DataTextField = "CLI_RAGIONE_SOCIALE";
            DropDownListCliente.DataBind();
            DropDownListCliente.Items.Insert(0, new ListItem("", ""));

            if (dizionarioPermessi["ADM"] == objUtilita.AccessNone)
            {
                if (Session["CLI_ID_CLIENTE"] != null) {
                    DropDownListCliente.SelectedValue = Session["CLI_ID_CLIENTE"].ToString();
                }
            }
            //

            DropDownListSocieta.DataSource = LookupSocietaCliente.List();
            DropDownListSocieta.DataValueField = "LSL_ID_SOCIETA_CLIENTE";
            DropDownListSocieta.DataTextField = "LSL_DESCRIZIONE";
            DropDownListSocieta.DataBind();
            DropDownListSocieta.Items.Insert(0, new ListItem("", ""));


            CrossGruppiClienteUtenti objCrossGruppiClienteUtenti = new CrossGruppiClienteUtenti();
            DropDownListGruppoCliente.DataSource = objCrossGruppiClienteUtenti.getDdlGruppiCliente(qUTE_ID_UTENTE).Tables[0];

            DropDownListGruppoCliente.DataValueField = "GRC_ID_GRUPPI_CLIENTE";
            DropDownListGruppoCliente.DataTextField = "GRC_NOME";
            DropDownListGruppoCliente.DataBind();
            
            //Button
            ButtonSalva.Text = GetValueDizionarioUI("SALVA");
            ButtonAnnulla.Text = GetValueDizionarioUI("USCITA");
           
            //Lookup

            // DataBinding
            switch (qMODALITA)
            {
                case "NEW":
                    TextMatricola.Value = "N.a";
                    break;
                case "VIEW":
                    BindData();
                    break;
                case "EDIT":
                    BindData();
                    break;
            }

        }

        string js_msgOBBLIGATORIO = "var msgOBBLIGATORIO = '" + GetValueDizionarioUI("ERR_MSG_CAMPO_OBBLIGATORIO") + "';";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgOBBLIGATORIO", js_msgOBBLIGATORIO, true);

        string js_msgLUNGHEZZA_MAX = "var msgLUNGHEZZA_MAX = '" + GetValueDizionarioUI("ERR_MSG_LUNGHEZZA_MAX") + "';";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgLUNGHEZZA_MAX", js_msgLUNGHEZZA_MAX, true);

        // Campi read-only
        TextDataAggiornamento.Disabled = true;
        TextDataUltimoAccesso.Disabled = true;
        
    }
    #endregion

    #region Access Control
    private void SetPageControlAccess()
    {
        SetPageControlAccess("UTE");
    }
    #endregion 

    #region DataBinding
    private void BindData()
    {
        try
        {
            objUtente.Ute_id_utente = qUTE_ID_UTENTE;
            objUtente.Read();
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
        objUtente = new Utente();
        objWorkflow = new Workflow();
        objClienti = new Clienti();
        objUtilita = new Utilita();

        base.OnInit(e);
    }
    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_MSE_UTE_PreRender);
        DropDownListCliente.SelectedIndexChanged += new EventHandler(DropDownListCliente_SelectedIndexChanged);
    }

    #endregion

    #region Web Form GET & SET Values

    /// <summary>
    /// Scrive i valori recuperati dal form negli attributi di classe
    /// </summary>
    private void SetValues()
    {
        //Rileggo il record da DB
        objUtente.Ute_id_utente = qUTE_ID_UTENTE;
        objUtente.Read();

        if (DropDownListCliente.SelectedValue != "")
            objUtente.Cli_id_cliente = Convert.ToInt32(DropDownListCliente.SelectedValue);
        else
            objUtente.Cli_id_cliente = SqlInt32.Null;

        //Se il codice individuale o la matricola sono settati a N.a, quindi che non si sa il loro valore,
        //automaticamente metto questi valori uguali all'indirizzo mail (unico campo univoco).        
        if (TextMatricola.Value.ToLower() == "n.a")
            objUtente.Ute_matricola = objUtente.Ute_email;
        else
            objUtente.Ute_matricola = TextMatricola.Value;

        objUtente.Ute_id_utente = qUTE_ID_UTENTE;
        objUtente.Ute_user_id = TextUser.Value;

        if (hExistDominio.Value == "1")
        {
            if (!TextEmail.Value.Contains("@"))
                objUtente.Ute_email = TextEmail.Value + hDominio.Value;
            else
                objUtente.Ute_email = TextEmail.Value;
        }
        else
            objUtente.Ute_email = TextEmail.Value;

        // Testi, date e importi
        objUtente.Ute_nome = TextNome.Value;
        objUtente.Ute_cognome = TextCognome.Value;                                

        objUtente.Ute_telefono = TextTelefono.Value;
        objUtente.Ute_fax = TextFax.Value;

        if (DropDownListSocieta.SelectedValue != "")
            objUtente.Lsl_id_societa_cliente = Convert.ToInt32(DropDownListSocieta.SelectedValue);
        else
            objUtente.Lsl_id_societa_cliente = SqlInt32.Null;

        if (DropDownListWorkflow.SelectedValue != "")
            objUtente.Wrf_id_workflow = Convert.ToInt32(DropDownListWorkflow.SelectedValue);
        else
            objUtente.Wrf_id_workflow = SqlInt32.Null;
        
        if (DropDownListCDCAppartenenza.SelectedValue != "")
            objUtente.Cdc_id_centro_di_costo = Convert.ToInt32(DropDownListCDCAppartenenza.SelectedValue);
        else
            objUtente.Cdc_id_centro_di_costo = SqlInt32.Null;

        if (objUtente.Ute_password.CompareTo(TextPassword.Value) != 0)
        {
            objUtente.Ute_ultimo_accesso = SqlDateTime.Null;
        }
                        
        if (objUtente.Ute_password.CompareTo(TextPassword.Value) != 0)
        {
            objUtente.Ute_password = EncryptPwd(TextPassword.Value);
        }

        if (CheckBoxStatoUtente.Checked)
            objUtente.Ute_accessi_errati = SqlInt32.Null;
        else
        {
            objUtente.Ute_accessi_errati = TextAccessiErrati.Value == string.Empty ? 0 : Convert.ToInt32(TextAccessiErrati.Value);
        }
        objUtente.Ute_tipo_utente = (TextTipoUtente.Value.ToString().Length == 0) ? (SqlString.Null) : (TextTipoUtente.Value);
        
        //TextArea
        objUtente.Ute_descrizione = TextAreaDescrizione.InnerText;

        //Flag
        objUtente.Ute_stato_utente = (CheckBoxStatoUtente.Checked) ? (true) : (false);
        objUtente.Ute_flag_bypass_import = (CheckBoxBypassImport.Checked) ? (1) : (0);
        objUtente.Ute_flag_autorizzazione_automatica = (CheckBoxAutorizzazioneAutomatica.Checked) ? (true) : (false);
        
        objUtente.Ute_expiration_date = (TextExpirationDate.Value == string.Empty) ? (SqlDateTime.Null) : Convert.ToDateTime(TextExpirationDate.Value);

        objUtente.Ute_sesso = ute_sesso.SelectedValue;
        objUtente.Ute_data_nascita =  (ute_data_nascita.Text != string.Empty) ? (Convert.ToDateTime(ute_data_nascita.Text)) : (SqlDateTime.Null);

        // Valori di default per processo autorizzativo (da parametrizzare)
        objUtente.Ute_processo_autorizzativo_liv_1 = 2;
        objUtente.Ute_processo_autorizzativo_liv_2 = 3;
    }

    /// <summary>
    /// Ripresa valori da classe per visualizzazione in form maschera
    /// </summary>
    private void GetValues()
    {
        try
        {            
            // Testi
            TextNome.Value = (objUtente.Ute_nome.IsNull) ? ("") : ((string)objUtente.Ute_nome);
            TextCognome.Value = (objUtente.Ute_cognome.IsNull) ? ("") : ((string)objUtente.Ute_cognome);            
            TextMatricola.Value = (objUtente.Ute_matricola.IsNull) ? ("") : ((string)objUtente.Ute_matricola);
            //DropDownlist        
            DropDownListSocieta.SelectedValue = (objUtente.Lsl_id_societa_cliente.IsNull) ? ("") : (Convert.ToString(objUtente.Lsl_id_societa_cliente.Value));
            DropDownListCliente.SelectedValue = (objUtente.Cli_id_cliente.IsNull) ? ("") : (Convert.ToString(objUtente.Cli_id_cliente.Value));
            DropDownListWorkflow.SelectedValue = (objUtente.Wrf_id_workflow.IsNull) ? ("") : (Convert.ToString(objUtente.Wrf_id_workflow.Value));
            divDominioEmail.InnerText = (objUtente.Cli_dominio_mail.IsNull) ? ("") : (Convert.ToString(objUtente.Cli_dominio_mail.Value));
            TextUser.Value = (objUtente.Ute_user_id.IsNull) ? ("") : ((string)objUtente.Ute_user_id);            
            
            if (qMODALITA != "VIEW")
            {
                TextPassword.Value = (objUtente.Ute_password.IsNull) ? ("") : ((string)objUtente.Ute_password);
            }

            TextTelefono.Value = (objUtente.Ute_telefono.IsNull) ? ("") : ((string)objUtente.Ute_telefono);
            TextFax.Value = (objUtente.Ute_fax.IsNull) ? ("") : ((string)objUtente.Ute_fax);
            if (!objUtente.Ute_email.IsNull && objUtente.Ute_email.ToString() != "")
            {
                if (objUtente.Ute_email.ToString().IndexOf("@") > 0)
                {
                    TextEmail.Value = objUtente.Ute_email.ToString().Substring(0, objUtente.Ute_email.ToString().IndexOf("@"));
                    divDominioEmail.InnerText = objUtente.Ute_email.ToString().Substring(objUtente.Ute_email.ToString().IndexOf("@"), objUtente.Ute_email.ToString().Length - objUtente.Ute_email.ToString().IndexOf("@"));
                    hDominio.Value = objUtente.Ute_email.ToString().Substring(objUtente.Ute_email.ToString().IndexOf("@"), objUtente.Ute_email.ToString().Length - objUtente.Ute_email.ToString().IndexOf("@"));
                    hExistDominio.Value = "1";

                }
                else
                {
                    TextEmail.Value = objUtente.Ute_email.ToString();
                    divDominioEmail.InnerText = "Nessun dominio.";
                    hDominio.Value = "Nessun dominio.";
                    hExistDominio.Value = "0";
                }
            }
            else
            {
                TextEmail.Value = objUtente.Ute_email.ToString();
                divDominioEmail.InnerText = "Nessun dominio.";
                hDominio.Value = "Nessun dominio.";
                hExistDominio.Value = "0";
            }
            TextDataAggiornamento.Value = (objUtente.Ute_data_aggiornamento.IsNull) ? ("") : (objUtente.Ute_data_aggiornamento.ToString());
            TextExpirationDate.Value = (objUtente.Ute_expiration_date.IsNull) ? ("") : (objUtente.Ute_expiration_date.ToString());
            TextDataUltimoAccesso.Value = (objUtente.Ute_ultimo_accesso.IsNull) ? ("") : (objUtente.Ute_ultimo_accesso.ToString());
            TextDataInvioPwd.Value = (objUtente.Ute_data_invio_pwd.IsNull) ? ("") : (objUtente.Ute_data_invio_pwd.ToString());
            TextAccessiErrati.Value = (objUtente.Ute_accessi_errati.IsNull) ? ("") : (objUtente.Ute_accessi_errati.ToString());
            TextTipoUtente.Value = (objUtente.Ute_tipo_utente.IsNull) ? ("") : (objUtente.Ute_tipo_utente.ToString());
            ute_data_nascita.Text = (objUtente.Ute_data_nascita.IsNull) ? string.Empty : objUtente.Ute_data_nascita.Value.ToString("dd/MM/yyyy");

            //TextArea
            TextAreaDescrizione.Value = (objUtente.Ute_descrizione.IsNull) ? ("") : ((string)objUtente.Ute_descrizione);

            //Flag
            CheckBoxStatoUtente.Checked = (objUtente.Ute_stato_utente.IsNull) ? (false) : (objUtente.Ute_stato_utente.Value);
            CheckBoxPwdInviata.Checked = (objUtente.Ute_flag_pwd_inviata.IsNull) ? (false) : (Convert.ToBoolean(objUtente.Ute_flag_pwd_inviata.Value));
            CheckBoxAutorizzazioneAutomatica.Checked = (objUtente.Ute_flag_autorizzazione_automatica.IsNull) ? (false) : (objUtente.Ute_flag_autorizzazione_automatica.Value);
            CheckBoxBypassImport.Checked = (objUtente.Ute_flag_bypass_import.IsNull) ? (false) : (Convert.ToBoolean(objUtente.Ute_flag_bypass_import.Value));
            TextPassword.Disabled = true;

            //In base al cliente che c'è selezionato quando entro nella pagina, filtro i CDC, visualizzando solo quelli del cliente relativo.
            DropDownListCDCAppartenenza.DataSource = Centri_di_costo.GetDdlCentroDiCosto(" AND CLI_ID_CLIENTE = " + objUtente.Cli_id_cliente.Value);
            DropDownListCDCAppartenenza.DataValueField = "CDC_ID_CENTRO_DI_COSTO";
            DropDownListCDCAppartenenza.DataTextField = "codice_descrizione"; // "CDC_CODICE_CENTRO_DI_COSTO";
            DropDownListCDCAppartenenza.DataBind();
            DropDownListCDCAppartenenza.Items.Insert(0, new ListItem("", ""));
            //Dopo aver ricavato i CDC filtrati, seleziono quello memorizzato nel DB
            DropDownListCDCAppartenenza.SelectedValue = (objUtente.Cdc_id_centro_di_costo.IsNull) ? ("") : (Convert.ToString(objUtente.Cdc_id_centro_di_costo.Value));

            ute_sesso.SelectedValue = (objUtente.Ute_sesso.IsNull) ? ("") : (Convert.ToString(objUtente.Ute_sesso.Value));
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

        if (objUtente.existUser() != 0)
        {
            lblMessaggioError.InnerText = getDizionarioUI("ERR_UTE_VALORI_DUPLICATI");
            divRecordError.Visible = true;
        }
        else
        {
            string PwdResetNotExist = getDizionarioUI("PWD_RESET_NOT_EXIST");

            switch (qMODALITA)
            {
                case "NEW":
                    try
                    {
                        //Ricavo dal cliente la password di default per settarla        
                        objClienti.Read(Convert.ToInt32(DropDownListCliente.SelectedValue), qCultureInfoName);
                        if (objClienti.Cli_password_reset.ToString() != "" && !objClienti.Cli_password_reset.IsNull)
                        {
                            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                            DbConnection c = db.CreateConnection();
                            DbTransaction t = null;

                            try
                            {
                                c.Open();
                                t = c.BeginTransaction();

                                objUtente.Ute_password = EncryptPwd(objClienti.Cli_password_reset.ToString());
                                objUtente.Ute_creato_da = base.idLoggedUser;
                                objUtente.Create(db, t);

                                RuoliUtente objRuoliUtente = new RuoliUtente();
                                objRuoliUtente.Ute_id_utente = objUtente.Ute_id_utente;
                                objRuoliUtente.CreateByDefaultCliente(Convert.ToInt32(DropDownListCliente.SelectedValue), db, t);

                                CrossUtenteWorkflow objCrossUtenteWorkflow = new CrossUtenteWorkflow();
                                objCrossUtenteWorkflow.Ute_id_utente = objUtente.Ute_id_utente;
                                objCrossUtenteWorkflow.CreateByDefaultCliente(Convert.ToInt32(DropDownListCliente.SelectedValue), db, t);

                                t.Commit();
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    t.Rollback();
                                }
                                catch (Exception ex2)
                                {
                                    ex2.Data.Add("Class.Method", "frm_MSE_UTE.ButtonSalva.Rollback");
                                    ex2.Data.Add("SQL", "Rollback error");
                                }

                                if (ex != null)
                                {
                                    ex.Data["Class.Method"] += "frm_MSE_UTE.ButtonSalva";
                                    ex.Data.Add("SQL", ex.Message);
                                    throw ex;
                                }
                            }
                            finally
                            {
                                c.Close();
                            }

                            Response.Redirect("frm_MSE_UTE.aspx?MODALITA=EDIT&UTE_ID_UTENTE=" + objUtente.Ute_id_utente, false);
                        }
                        else
                        {
                            string strScript = @"<script type='text/javascript'>
                                alert('" + PwdResetNotExist + @"');                                
                                </script>";

                            if (!this.ClientScript.IsStartupScriptRegistered("Alert_JS"))
                            {
                                this.ClientScript.RegisterStartupScript(GetType(), "Alert_JS", strScript);
                            }

                        }


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
                        objUtente.Ute_aggiornato_da = base.idLoggedUser;
                        objUtente.Ute_id_utente = qUTE_ID_UTENTE;
                        objUtente.Update();
                        Response.Redirect("frm_MSE_UTE.aspx?MODALITA=EDIT&UTE_ID_UTENTE=" + objUtente.Ute_id_utente, false);
                    }
                    catch (Exception ex)
                    {
                        // Gestione messaggistica all'utente e trace in DB dell'errore
                        ExceptionPolicy.HandleException(ex, "Propagate Policy");
                    }
                    break;
            }

            GetValues();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "varMODALITA", "$('#modalPage', parent.document).modal('hide');", true);
        }
    }

    void DropDownListCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //In base al cliente che c'è selezionato quando entro nella pagina, filtro i CDC, visualizzando solo quelli del cliente relativo.
            DropDownListCDCAppartenenza.DataSource = Centri_di_costo.GetDdlCentroDiCosto(" AND CLI_ID_CLIENTE = " + DropDownListCliente.SelectedValue);
            DropDownListCDCAppartenenza.DataValueField = "CDC_ID_CENTRO_DI_COSTO";
            DropDownListCDCAppartenenza.DataTextField = "codice_descrizione";
            DropDownListCDCAppartenenza.DataBind();
            DropDownListCDCAppartenenza.Items.Insert(0, new ListItem("", ""));
            //Dopo aver ricavato i CDC filtrati, seleziono quello memorizzato nel DB
            DropDownListCDCAppartenenza.SelectedValue = "";           
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    #endregion

    #region Ajax
    [System.Web.Services.WebMethod()]
    public static string getDominioMailCliente(int idCliente)
    {
        string dominioMail = string.Empty;
        try
        {
            Clienti objClienti = new Clienti();
            objClienti.Read(Convert.ToInt32(idCliente), "it"); //Metto it perchè tanto la lingua in questo caso non incide per le informazioni che mi servono
            
            if (!objClienti.Cli_dominio_mail.IsNull)
                dominioMail = objClienti.Cli_dominio_mail.ToString();
            else
                dominioMail = "";

            return dominioMail;
        }
        catch (Exception ex)
        {
            return ex.Message;
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
        string percorso = @"frm_MSB_UTE.aspx";
        return percorso;        
    }

    #endregion
    
    #region Web Form PreRender
    private void frm_MSE_UTE_PreRender(object sender, EventArgs e)
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
