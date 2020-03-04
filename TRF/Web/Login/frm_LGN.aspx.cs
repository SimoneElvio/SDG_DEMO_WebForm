#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   frm_LGN.aspx
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
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using SDG.Utility;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Web_Login_frm_LGN : BasePageNoLogin
{

    #region Web Form Control declarations
    
    protected string errMessage;
    protected string errDisabledUser;
    protected string strERRORE = string.Empty;
    protected string idMailClick = string.Empty;
    protected Utente objUtente;
    //protected CrossClienteRuoli objCrossClienteRuoli;
    //protected CrossClienteWorkflow objCrossClienteWorkflow;
    protected Clienti objClienti;
    protected Centri_di_costo objCentriDiCosto;
    protected RuoliUtente objRuoliUtente;
    protected CrossUtenteWorkflow objCrossUtenteWorkflow;
    protected Errori objErrori;
    protected Sistema objSistema;
    protected SessioniUtenti objSessioniUtenti;

    protected int idCliente;
    protected string qToken = string.Empty;

    string autoLoginId;
    bool autoLoginKerberosVerified = true; // impostazione di default valida per tutte le installazioni.

    protected int idLingua
    {
        get { return (int)(ViewState["idLingua"] = 1); }
        set { ViewState["idLingua"] = value; }
    }
    protected string vInfoBrowser
    {
        get { return (string)(ViewState["vInfoBrowser"]); }
        set { ViewState["vInfoBrowser"] = value; }
    }

    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {   

#if DEBUG
        infoCompilationMode.InnerText = "MODALITA' DEBUG";
        infoCompilationMode.Visible = true;
#endif

        // Visualizza l'ultima data di compilazione della dll
        DateTime cd = File.GetCreationTime(GetType().Assembly.Location);
        lastBuild.InnerText = GetValueDizionarioUI("LOGIN_LAST_RELEASE_DATE") + " " + cd.Day.ToString().PadLeft(2, '0') + "/" + cd.Month.ToString().PadLeft(2, '0') + "/" + cd.Year.ToString() + " " + cd.Hour.ToString().PadLeft(2, '0') + ":" + cd.Minute.ToString().PadLeft(2, '0');

        strERRORE = Request.QueryString["ERROR"];
        idMailClick = Request.QueryString["idMailClick"];

        if (IsMobile())
        {
            Session["isMobile"] = "1";
            bodyLgn.Attributes["class"] += "mobile";
        }
        else
            Session["isMobile"] = "0";


        //AAAAAAAAAAAAAAAAAAAAAAAA
        //AAAAAAAAAAAAAAAAAAAAAAAA
        //AAAAAAAAAAAAAAAAAAAAAAAA
        // Session["isMobile"] = "1";
        //AAAAAAAAAAAAAAAAAAAAAAAA
        //AAAAAAAAAAAAAAAAAAAAAAAA
        //AAAAAAAAAAAAAAAAAAAAAAAA
        
        isMobile.Value = Session["isMobile"].ToString();

        //Questo pezzo di codice mi serve per bypassare il login nel caso provengo da un link alla richiesta presente nella mail.
        if (idMailClick != "" && idMailClick != "ERRORE" && idMailClick != null)
        {
            ByPassLogin(idMailClick);
        }

        if (strERRORE != "" && strERRORE != null)
        {
            LabelMessage.InnerHtml = strERRORE;
            divLoginMessage.Visible = true;
        }

        if (!IsPostBack)
        {
            BusinessObjects.ConfigurationSetting objConfigurationSetting = new BusinessObjects.ConfigurationSetting();
            string EnableAutoLoginKerberos = objConfigurationSetting.getValue("EnableAutoLoginKerberos").ToString();

            if (!String.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) && EnableAutoLoginKerberos == "True")
            {
                autoLoginKerberosVerified = false;

                autoLoginId = HttpContext.Current.User.Identity.Name;                
                autoLoginId = autoLoginId.Substring(autoLoginId.LastIndexOf("\\") + 1);

                if (HttpContext.Current.Request.UrlReferrer == null && (ConfigurationManager.AppSettings.Get("Maintenance") != "true"))
                {
                    ButtonLogin_Click(sender, e);
                }
            }
        }

        isMobile.Value = Session["isMobile"].ToString();

        //Questo pezzo di codice mi serve per bypassare il login nel caso provengo da un link alla richiesta presente nella mail.
        if (idMailClick != "" && idMailClick != "ERRORE" && idMailClick != null)
        {
            ByPassLogin(idMailClick);
        }

        if (strERRORE != "" && strERRORE != null)
        {
            LabelMessage.InnerHtml = strERRORE;
            divLoginMessage.Visible = true;
        }

        if (!IsPostBack)
        {
            hLingua.SelectedValue = objSistema.Naz_id_nazione.ToString();
            idLingua = (objSistema.Naz_id_nazione.IsNull) ? (1) : (Convert.ToInt32(objSistema.Naz_id_nazione.ToString()));
        }

        errMessage = GetValueDizionarioUI("ERRORE_LOGIN");
        errDisabledUser = GetValueDizionarioUI("LOGIN_USER_DISABLED");
        infoProject.InnerText = GetValueDizionarioUI("MSG_INFO_PROJECT");
    }

    /// <summary>
    /// Restituisce True se nell'agent viene trovata la parola "mobile".
    /// NOTA:
    /// dalla versione 13 di Safari è stata introdotta una nuova impostazione che apre i siti sempre in modalità desktop:
    /// Impostazioni > Safari > Impostazioni Siti Web > Richiedi sito desktop su > Tutti i siti web
    /// Disattivando questa impostazione i siti vengono identificati come mobile.
    /// </summary>
    /// <returns></returns>
    public bool IsMobile()
    {
        try
        {
            string str = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToString().ToLower();
            if (str.Contains("mobile"))
                return true;
            else
            {
                return false;

                /* TEST MOBILE */
                // return true;
            }
        }
        catch (Exception e)
        {
            string foo = e.Message;
            return false;
        }
    }
#endregion

#region OnInit
    protected override void OnInit(EventArgs e)
    {
        try
        {
            ButtonReset.ServerClick += new EventHandler(ButtonReset_Click);

            objSessioniUtenti = new SessioniUtenti();

#region Login with WS

            objUtente = new Utente();
            objClienti = new Clienti();
            objCentriDiCosto = new Centri_di_costo();
            objDictionary = new Dizionario();
            objSistema = new Sistema();
            objErrori = new Errori();
            objRuoliUtente = new RuoliUtente();
            objCrossUtenteWorkflow = new CrossUtenteWorkflow();
            objUtilita = new Utilita();

            string acronimoCliente = string.Empty;
            string UrlReferrer = string.Empty;
            objSistema.Read();

            //Questa parte di codice serve per gestire il fatto di non andare in eccezione se il certificato
            //SSl è scaduto.
            ServicePointManager.ServerCertificateValidationCallback =
            new RemoteCertificateValidationCallback(
            delegate (
            object sender2,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
            {
                return true;
            });
            //Fine


            if (hLingua.SelectedValue != "")
                objDizionarioUI = objDictionary.GetDictionary((int)Convert.ToInt32(hLingua.SelectedValue));
            else
                objDizionarioUI = objDictionary.GetDictionary((int)objSistema.Naz_id_nazione);

#endregion

            ButtonLogin.ServerClick += new EventHandler(ButtonLogin_Click);

            this.PreRender += new System.EventHandler(this.frm_LGN_PreRender);

            base.OnInit(e);
        }
        catch (Exception ex)

        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
#endregion

#region SendMail

    protected string FormattaEmail(string msg, string link)
    {
        string strBody = string.Empty;
        string pathLogin = ConfigurationManager.AppSettings["pathLogin"];


        strBody += "<!DOCTYPE html><html><body>";

        strBody += "<div style='font-family:verdana,arial; background-color:#ddd;font-size:12px;color:#000;padding:20px 0;'>";

        strBody += "<div style='background-color:#fff;width:500px; border:1px solid #666;margin:auto; padding:10px;border-radius:4px;'>";
        strBody += "<div style='text-align:center'><img src='" + link + "/Web/Images/logoMail.jpg'></img></div>";

        strBody += "<br /><br />Il link per accedere all'applicazione &egrave;: <strong><a href='" + link + "' style='color:#009efb; text-decoration:none;'>" + link + "</a></strong><br /><br />";
        if (msg != "")
            strBody += "La sua nuova password &egrave;: <strong>" + msg + "</strong>";

        strBody += "<br /><br /><br /><br />";
        strBody += "<center><a href='" + link + "' style='display:block; width:200px; height:30px; background:#009efb; padding:10px; border-radius:4px; color:#fff; font-family:Arial; font-size:18px; font-weight:400; text-decoration:none;'>ENTRA</a></center>";
        strBody += "<br /><br /><br /><br />";

        if (link.Contains("tickets"))
            strBody += "<small>ATTENZIONE<br />Questo messaggio di notifica &egrave; generato automaticamente dal sistema Tickets, si invita a non rispondere.</small>";
        else
            strBody += "<small>ATTENZIONE<br />Questo messaggio di notifica &egrave; generato automaticamente dal sistema, si invita a non rispondere.</small>";

        if (link.Contains("tickets"))
        {
            strBody += "<br /><br />Distinti saluti<br />SDG S.r.l.<br />";
            strBody += "<div style='text-align:right;font-size:10px'>tickets by SDG 2011</div>";
        }
        else
        {
            strBody += "<br /><br />Distinti saluti<br />SDG Srl<br /><br />";
            strBody += "<img src='" + link + "/Web/Images/logoMailSdg.jpg' style='width:90px;' />";
        }

        strBody += "</div></div></body></html>";

        return strBody;
    }

    /// <summary>
    /// Invio mail
    /// </summary>
    /// <param name="email"></param>
    void SendEmail(MailMessage email)
    {
        BusinessObjects.ConfigurationSetting objConfigurationSetting = new BusinessObjects.ConfigurationSetting();
        string SmtpServer = objConfigurationSetting.getValue("SmtpServer");

        string smtpUserName = string.Empty;
        string smtpPassword = string.Empty;
        string smtpHost = string.Empty;
        string smtpEnableSsl = string.Empty;
        string smtpPort = string.Empty;

        try
        {
            SmtpClient Smtp = new SmtpClient();
            Smtp.Host = SmtpServer;

            smtpUserName = objConfigurationSetting.getValue("SmtpUserName");
            smtpPassword = objConfigurationSetting.getValue("SmtpPassword");
            smtpEnableSsl = objConfigurationSetting.getValue("SmtpEnableSsl");
            smtpPort = objConfigurationSetting.getValue("SmtpPort");

            if (smtpPort != string.Empty)
                Smtp.Port = Convert.ToInt32(smtpPort);

            if (smtpEnableSsl == "true")
                Smtp.EnableSsl = true;

            // Add credentials if the SMTP server requires them.
            if (smtpUserName != string.Empty && smtpPassword != string.Empty && SmtpServer != "localhost")
            {
                Smtp.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPassword);
            }
            else
            {
                Smtp.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            }

            Smtp.Send(email);

            // Clean up.
            email.Dispose();
        }
        catch (Exception ex)
        {
            if (email != null)
                ((IDisposable)email).Dispose();

            ex.Data.Add("Class.Method", "frm_LGN.SendEmail.");
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");

        }

    }

#endregion

#region Web Form Event Handlers

    //E' presente anche nella Default.aspx
    //public bool IsMobile()
    //{
    //    bool retValue = false;

    //    try //try , because sometimes user agent is empty
    //    {
    //        string ua = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToString().ToLower();            
    //        string[] uaArray = { "android", "maui", "ppc", "opera mobi", "symbian", "series", "nokia", "mot-", "motorola", "lg-", "lge", "nec-", "lg/", "samsung", "sie-", "sec-", "sgh-", "sonyericsson", "sharp", "windows ce", "portalmmm", "o2-", "docomo", "philips", "panasonic", "sagem", "smartphone", "up.browser", "up.link", "googlebot-mobile", "googlebot-image", "slurp", "spring", "alcatel", "sendo", "blackberry", "opera mini", "opera 2", "netfront", "mobilephone mm", "vodafone", "avantgo", "palmsource", "siemens", "toshiba", "i-mobile", "asus", "kwc", "htc", "softbank", "playstation", "nitro", "ipod", "google wireless transcoder", "t-mobile", "obigo", "brew" }; //"ice",

    //        bool foundInArray = false;
    //        foreach (string s in uaArray)
    //        {
    //            if (ua.IndexOf(s) > -1)
    //            {
    //                foundInArray = true;
    //                break;
    //            }
    //        }

    //        if (foundInArray == true || HttpContext.Current.Request.Browser.IsMobileDevice || HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT"].Contains("application/vnd.wap.xhtml+xml"))
    //            retValue = true;
    //    }
    //    catch (Exception e)
    //    {
    //        string foo = e.Message;
    //    }

    //    return retValue;
    //}

    void ByPassLogin(string idMailClick)
    {
        string idRichiesta = string.Empty;
        string wrfCodice = string.Empty;
        bool loginVerified = false;

        Audit objAudit = new Audit();
        Utente objUtente = new Utente();
        objUtente.Mac_codice_univoco = idMailClick;
        loginVerified = objUtente.CheckByPassLogin();
        idRichiesta = objUtente.Riv_id_richiesta.ToString();
        wrfCodice = objUtente.Ioa_wrf_codice.ToString();

        //Pensare di centralizzare questo controllo.
        Session["UTE_ID_UTENTE"] = objUtente.Ute_id_utente.Value;
        Session["UTE_SIGLA"] = (objUtente.Ute_sigla.IsNull) ? (string.Empty) : (objUtente.Ute_sigla.Value);
        Session["IP_ADDRESS"] = Convert.ToString(Request.ServerVariables["REMOTE_ADDR"]);
        Session["UTE_COGNOME"] = objUtente.Ute_cognome.Value;
        Session["UTE_NOME"] = objUtente.Ute_nome.Value;
        Session["CLI_ID_CLIENTE"] = objUtente.Cli_id_cliente.Value;

        if (objUtente.Tpi_acronimo.Value != "")
        {
            Session["ACRONIMO_INSTALLAZIONE"] = objUtente.Tpi_acronimo.Value;
        }
        else
        {
            Session["ACRONIMO_INSTALLAZIONE"] = "";
        }
        Response.Write(Session["UTE_ID_UTENTE"].ToString());

        try
        {
            objAudit.Ute_id_utente = objUtente.Ute_id_utente;
            objAudit.Aud_ip_address = Convert.ToString(Session["IP_ADDRESS"]);
            objAudit.TraceAction("Login");
            Session["AUD_ID_AUDIT"] = objAudit.Aud_id_audit;

            Dictionary<string, int> dizionarioPermessi = objUtente.BuildPermissions();
            Session["dizionarioPermessi"] = dizionarioPermessi;

            // Create the authentication ticket
            FormsAuthenticationTicket authTicket = new
            FormsAuthenticationTicket(1,            // version
            InputUser.Text,                         // user name
            DateTime.Now,                           // creation
            DateTime.Now.AddHours(10),          // Expiration
            false,                                  // Persistent
            "");                                    // User data

            // Now encrypt the ticket.
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            // Create a cookie and add the encrypted
            // cookie as data.
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            // Add the cookie to the outgoing cookies
            Response.Cookies.Add(authCookie);

            int naz_id_nazione = 1;//Convert.ToInt32(RadioButtonLingua.SelectedItem.Value);
            Session["NAZ_ID_NAZIONE"] = naz_id_nazione;
            Session["CULTURE_INFO_NAME"] = "it";

            //SVA(07102011): Una volta che mi loggo inserisco nella tabella delle Sessioni le informazioni
            //relative all'utente che si è loggato.
            setSessionId();
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
        //*****************************************
        if (idRichiesta != null)
            Response.Redirect("../HOME/mainpage.aspx?ID_RICHIESTA=" + idRichiesta + "&CODICE_WORKFLOW=" + wrfCodice, false);
    }

    /// <summary>
    /// Reset della password. Viene inviata una mail all'utente con la nuova password.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonReset_Click(object sender, EventArgs e)
    {
        try
        {
            string emailDestinatario = string.Empty;

            BusinessObjects.ConfigurationSetting objConfigurationSetting = new BusinessObjects.ConfigurationSetting();
            string emailMittente = objConfigurationSetting.getValue("EmailNoReply");

            string idDestinatario = string.Empty;
            string Password = objUtilita.GenerateRandomPassword();
            Utente objUtente = new Utente();
            Clienti objClienti = new Clienti();
            objUtente.ReadByUser(InputUser.Text);
            emailDestinatario = objUtente.Ute_email.ToString();
            
            objClienti.Read(objUtente.Cli_id_cliente, qCultureInfoName);

            if (objUtente.Ute_id_utente.IsNull)
                idDestinatario = "";
            else
                idDestinatario = objUtente.Ute_id_utente.ToString();

            MailMessage email = new MailMessage();
            MailAddress oFrom = new MailAddress(emailMittente);
            email.From = oFrom;
            //Devo prima cancellare i valori precedenti.
            email.To.Clear();
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            email.Subject = "Invio / Reset password di accesso";
            email.Body = FormattaEmail(Password, objClienti.Cli_link_taf.ToString());

            if (idDestinatario == "")
            {
                divLoginMessage.Visible = true;
                LabelMessage.InnerText = "Errore durante il reset della password User Id non presente o errato.";
                LabelMessage.Style.Add("color", "red");
            }
            else
            {
                objUtente.Ute_id_utente = Convert.ToInt32(idDestinatario);
                objUtente.Read();

                email.To.Add(emailDestinatario);
                SendEmail(email);

                objUtente.Ute_password = EncryptPwd(Password);
                objUtente.Ute_expiration_date = DateTime.Now.AddDays(-1);

                objUtente.Update();

                divLoginMessage.Visible = true;
                LabelMessage.InnerText = "Password resettata correttamente, controllare la casella di posta elettronica.";
            }
        }
        catch (Exception ex)
        {
            strERRORE = ex.Message;
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        Utente objUtente = new Utente();
        Audit objAudit = new Audit();

        int naz_id_nazione;
        bool passwordVerified = false;
        bool macAddressVerified = false;
        string pagina = string.Empty;
        int nroMaxSessioni = 0;
        int nroSessioniAttive = 0;

        //Ricavo informazioni sul browser dell'utente che si collega.
        vInfoBrowser = "Impostazioni Browser" + Environment.NewLine
                  + "Type = " + Request.Browser.Type + Environment.NewLine
                  + "Name = " + Request.Browser.Browser + Environment.NewLine
                  + "Version = " + Request.Browser.Version + Environment.NewLine
                  + "Major Version = " + Request.Browser.MajorVersion + Environment.NewLine
                  + "Minor Version = " + Request.Browser.MinorVersion + Environment.NewLine
                  + "Platform = " + Request.Browser.Platform + Environment.NewLine
                  + "Is Beta = " + Request.Browser.Beta + Environment.NewLine
                  + "Is Crawler = " + Request.Browser.Crawler + Environment.NewLine
                  + "Is AOL = " + Request.Browser.AOL + Environment.NewLine
                  + "Is Win32 = " + Request.Browser.Win32 + Environment.NewLine
                  + "Supports Frames = " + Request.Browser.Frames + Environment.NewLine
                  + "Supports Tables = " + Request.Browser.Tables + Environment.NewLine
                  + "Supports Cookies = " + Request.Browser.Cookies + Environment.NewLine
                  + "Supports VBScript = " + Request.Browser.VBScript + Environment.NewLine
                  + "Supports JavaScript = " + Request.Browser.EcmaScriptVersion.ToString() + Environment.NewLine
                  + "Supports Java Applets = " + Request.Browser.JavaApplets + Environment.NewLine
                  + "Supports ActiveX Controls = " + Request.Browser.ActiveXControls + Environment.NewLine
                  + "Supports Callback = " + Request.Browser.SupportsCallback + Environment.NewLine
                  + "User Agent = " + HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToString().ToLower();

        divLoginMessage.Visible = false;
        strERRORE = "";

        try
        {
            objUtente.Ute_user_id = InputUser.Text;
            objUtente.Ute_password = EncryptPwd(InputPassword.Text);

            if (!IsPostBack)
            {
                objUtente.Ute_user_id = autoLoginId;
                passwordVerified = objUtente.CheckLogin(false);

                if (passwordVerified)
                    autoLoginKerberosVerified = true;
            }
            else
            {
                passwordVerified = objUtente.CheckLogin(true);        //objUtente-> in Utente.cs            
            }

            //Ricavo il nro massimo delle sessioni disponibili per l'utente corrente
            //e il nro di sessioni effettivamente attive per l'utente corrente
            if (passwordVerified)
            {
                nroMaxSessioni = objUtente.Ute_nro_max_sessioni.Value;
                nroSessioniAttive = objSessioniUtenti.CountSessioni(objUtente.Ute_id_utente.Value);
            }
            else
            {
                //Messi dei valori di comodo per farlo entrare nel successivo IF della password errata.
                nroMaxSessioni = 1;
                nroSessioniAttive = 0;
            }

            //********************************************************************************
            // Commentare DA QUI per creare dll che non controlla il mac address
            //********************************************************************************
            /*
            byte[] defaultParameters = { 99, 99, 99 };
            JsonTextReader readerMacAddress = MacAddress.GetArrayMacAddress();
            Utilita objUtilita = new Utilita();
            byte[] microsoftAdvertisingClass = objUtilita.getMicrosoftAdvertisingClass();
            string macAddressCheck = string.Empty;

            while (readerMacAddress.Read() && passwordVerified)
            {
                if (readerMacAddress.TokenType.ToString() == "String" && !macAddressVerified)
                {
                    defaultParameters = Encoding.ASCII.GetBytes(readerMacAddress.Value.ToString());
                    int z = 0;
                    foreach (string val in readerMacAddress.Value.ToString().Split(','))
                    {
                        defaultParameters[z] = Convert.ToByte(val);
                        z++;
                    }
                    //logger.Log(" -> defaultParameters -> " + readerMacAddress.Value.ToString());
                    int i = 0;
                    int countCheck = 0;
                    foreach (byte b in microsoftAdvertisingClass)
                    {
                        macAddressCheck += b + ",";
                        if (b == defaultParameters[i])
                        {
                            //logger.Log(" -> mcAddressVerified -> true");
                            countCheck++;
                            if (countCheck == 15)
                            {
                                macAddressVerified = true;
                                break;
                            }
                        }
                        else
                        {
                            //logger.Log(" -> mcAddressVerified -> false -> bity:" + b.ToString() + " defaultParameters["+i.ToString()+"]-> " + defaultParameters[i].ToString());
                            macAddressVerified = false;
                        }
                        i++;
                    }
                }
            }
            */
            //********************************************************************************
            // Commentare FIN QUI per creare dll che non controlla il mac address
            //********************************************************************************

            Session["RIV_ID_RICHIESTA"] = 0;

            //********************************************************************************

            if (nroSessioniAttive >= nroMaxSessioni)
            {
                errMessage = GetValueDizionarioUI("ERR_MSG_MAX_SESSIONI_ATTIVE");
                LabelMessage.InnerText = errMessage;
                LabelMessage.Style.Add("color", "red");
                divLoginMessage.Visible = true;
            }
            else if (passwordVerified)
            {
                Session["UTE_ID_UTENTE"] = objUtente.Ute_id_utente.Value;
                Session["UTE_SIGLA"] = (objUtente.Ute_sigla.IsNull) ? (string.Empty) : (objUtente.Ute_sigla.Value);
                Session["IP_ADDRESS"] = Convert.ToString(Request.ServerVariables["REMOTE_ADDR"]);
                Session["UTE_COGNOME"] = objUtente.Ute_cognome.Value;
                Session["UTE_NOME"] = objUtente.Ute_nome.Value;
                Session["CLI_ID_CLIENTE"] = objUtente.Cli_id_cliente.Value;
                Session["IS_GESTIONE_GRUPPO"] = objUtente.Ute_gestione_gruppo.Value;

                if (objUtente.Tpi_acronimo.Value != "")
                {
                    Session["ACRONIMO_INSTALLAZIONE"] = objUtente.Tpi_acronimo.Value;
                }
                else
                {
                    Session["ACRONIMO_INSTALLAZIONE"] = "";
                }
                Response.Write(Session["UTE_ID_UTENTE"].ToString());

                try
                {
                    objAudit.Ute_id_utente = objUtente.Ute_id_utente;
                    objAudit.Aud_ip_address = Convert.ToString(Session["IP_ADDRESS"]);
                    objAudit.Aud_device = vInfoBrowser; //HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToString().ToLower();
                    objAudit.TraceAction("Login");

                    Session["AUD_ID_AUDIT"] = objAudit.Aud_id_audit;

                    Dictionary<string, int> dizionarioPermessi = objUtente.BuildPermissions();
                    Session["dizionarioPermessi"] = dizionarioPermessi;
                    
                    // Create the authentication ticket
                    FormsAuthenticationTicket authTicket = new
                    FormsAuthenticationTicket(1,            // version
                    InputUser.Text,                         // user name
                    DateTime.Now,                           // creation
                    DateTime.Now.AddHours(10),              // Expiration
                    false,                                  // Persistent
                    "");                                    // User data

                    // Now encrypt the ticket.
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    // Create a cookie and add the encrypted
                    // cookie as data.
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    // Add the cookie to the outgoing cookies
                    Response.Cookies.Add(authCookie);

                    if (hLingua.SelectedValue != "")
                        naz_id_nazione = Convert.ToInt32(hLingua.SelectedValue);
                    else
                        naz_id_nazione = idLingua;

                    Session["NAZ_ID_NAZIONE"] = naz_id_nazione;
                    // La Culture Info deve sempre essere IT in quanto non devo cambiare formato di date e numeri
                    Session["CULTURE_INFO_NAME"] = "it";
                    Session["SIGLA_LINGUA"] = hSiglaLingua.Value;
                    
                    setSessionId();

                    //Faccio la read del cliente per acronimo del cliente per andare alle richieste viaggio corrispondenti
                    objClienti.Read(objUtente.Cli_id_cliente, qCultureInfoName);

                    pagina = "../HOME/mainpage.aspx";

                    if (objUtente.Ute_id_utente != 1) // Admin
                    {
                        pagina = "../RichiestaViaggio_" + objClienti.Cli_acronimo.Value + "/frm_MSB_RIV.aspx?MENU=1";
                    }


                    if (objSistema.Sis_flag_pwd_cambia_primo_accesso == 1 && objUtente.Ute_ultimo_accesso.IsNull)
                    {
                        //Ogni login è l'ultimo Accesso Utente
                        objUtente.UltimoAccesso();
                        objUtente.Login_Logout("Login");
                        Response.Redirect("../LOGIN/frm_PWD.aspx?SCADUTA=SI", false);
                    }
                    else if (objSistema.Sis_flag_pwd_cambia == 1)
                    {
                        if (objUtente.Ute_expiration_date.IsNull)
                        {
                            if (objSistema.Sis_flag_visualizza_info_page == 1)

                                Response.Redirect("frm_LGN_2.aspx", false);
                            else
                            {
                                //Ogni login è l'ultimo Accesso Utente
                                objUtente.UltimoAccesso();
                                Response.Redirect(pagina, false);
                            }
                        }
                        else if (Convert.ToDateTime(objUtente.Ute_expiration_date.Value) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                        {
                            //Ogni login è l'ultimo Accesso Utente
                            objUtente.UltimoAccesso();
                            objUtente.Login_Logout("Login");
                            Response.Redirect("../LOGIN/frm_PWD.aspx?SCADUTA=SI", false);
                        }
                        else
                        {
                            if (objSistema.Sis_flag_visualizza_info_page == 1)
                                Response.Redirect("frm_LGN_2.aspx", false);
                            else
                            {
                                //Ogni login è l'ultimo Accesso Utente
                                objUtente.UltimoAccesso();
                                objUtente.Login_Logout("Login");
                                Response.Redirect(pagina, false);
                            }
                        }
                    }
                    else
                    {
                        if (objSistema.Sis_flag_visualizza_info_page == 1)
                            Response.Redirect("frm_LGN_2.aspx", false);
                        else
                        {
                            //Ogni login è l'ultimo Accesso Utente
                            objUtente.UltimoAccesso();
                            objUtente.Login_Logout("Login");
                            Response.Redirect(pagina, false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    strERRORE = ex.Message;
                    ExceptionPolicy.HandleException(ex, "Propagate Policy");
                    Response.Redirect("../Login/frm_LGN.aspx", false);
                }
            }
            else
            {
                if (!autoLoginKerberosVerified)
                {
                    divLoginMessage.Visible = true;
                    LabelMessage.InnerText = "Utente non presente nel sistema di autenticazione.";
                    LabelMessage.Style.Add("color", "red");
                    InputUser.Text = autoLoginId;
                }
                else if (!passwordVerified)
                {
                    divLoginMessage.Visible = true;
                    LabelMessage.InnerText = "Password non valida.";
                    LabelMessage.Style.Add("color", "red");

                    if (objSistema.Sis_max_tentativi_password != -1)
                    {
                        objUtente.Ute_user_id = InputUser.Text;
                        if (objUtente.AccessoErrato() == 1)
                        {
                            objUtente.SqlWhereClause = " WHERE UTE_USER_ID = '" + InputUser.Text + "' ";
                            objUtente.DisattivaUserID();
                            LabelMessage.InnerHtml = errDisabledUser;
                            LabelMessage.Style.Add("color", "red");
                        }
                    }
                }
                else if (!macAddressVerified)
                {
                    divLoginMessage.Visible = true;
                    LabelMessage.InnerText = "Mac Address non valido. Contattare l'amministratore di sistema."; // + macAddressCheck;
                    LabelMessage.Style.Add("color", "red");
                }
                else
                {
                    if (objUtente.CheckUser())
                    {
                        objAudit.Ute_id_utente = objUtente.Ute_id_utente;
                        objAudit.Aud_ip_address = Convert.ToString(Session["IP_ADDRESS"]);
                        objAudit.TraceAction("LoginFailed");
                    }

                    LabelMessage.InnerText = errMessage;
                    LabelMessage.Style.Add("color", "red");

                    divLoginMessage.Visible = true;
                    strERRORE = errMessage;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    protected void HideLogin()
    {
        MessageAccess.Visible = true;
        MessageAccess.InnerText = GetValueDizionarioUI("ACCESSO_NON_RIUSCITO");
    }

    /// <summary>
    /// Inserisce nella tabella Sessioni Utenti le informazioni relative all'utente che si è loggato.
    /// </summary>
    void setSessionId()
    {
        try
        {
            objSessioniUtenti.Ssu_id_sessione = SqlGuid.Parse(Session["SESSIONID"].ToString());
            objSessioniUtenti.Ute_id_utente = (Session["UTE_ID_UTENTE"].ToString() != string.Empty) ? Convert.ToInt32(Session["UTE_ID_UTENTE"].ToString()) : SqlInt32.Null;
            objSessioniUtenti.Create();
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }

    }

#endregion

#region Web Form PreRender

    private void frm_LGN_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (Session["isMobile"] == "1")
            {
                HtmlLink cssMobile = new HtmlLink();
                cssMobile.Href = "../css/style-mobile.css";
                cssMobile.Attributes.Add("rel", "stylesheet");
                this.Page.Header.Controls.AddAt(10, cssMobile);
            }
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

#endregion

}

