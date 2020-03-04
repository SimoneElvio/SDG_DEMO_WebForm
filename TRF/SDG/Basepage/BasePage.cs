#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   BasePage.cs
//
// Namespace:   SDG.GestioneUtenti.Web
// Descrizione: Pagina base
//
// Autore:      AR - SDG srl
// Data:        26/06/2008
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using SDG.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Text;
using BusinessObjects;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SDG.ExceptionHandling;
using System.Configuration;

namespace SDG.GestioneUtenti.Web
{
    /// <summary>
    /// Summary description for BasePage.
    /// </summary>
    public class BasePage : BasePageMaster
    {
        #region Web Control Declaration

        /// <summary>
        /// Id assegnato al nuovo record al momento della creazione
        /// </summary>
        public const int idNewRecord = -1;

        /// <summary>
        /// Formattazione per campi importo con 2 decimali - {0:#,0.00}
        /// </summary>
        public static string formatCurrency = "{0:#,0.00}";  //default formato € it

        /// <summary>
        /// Formattazione per campi importo con 3 decimali - {0:#,0.000}
        /// </summary>
        public static string formatCurrency3decimal = "{0:#,0.000}";  //formato € it

        /// <summary>
        /// Formattazione per campi importo con 4 decimali - {0:#,0.0000}
        /// </summary>
        public static string formatCurrency4decimal = "{0:#,0.0000}";  //formato € it

        /// <summary>
        /// Formattazione per campi importo con 6 decimali - {0:#,0.000000}
        /// </summary>
        public static string formatCurrency6decimal = "{0:#,0.000000}";  //formato € it

        /// <summary>
        /// Formattazione per campi data
        /// </summary>
        public static string formatDate = "dd/MM/yyyy";  //default formato it

        /// <summary>
        /// Formattazione per campi data
        /// </summary>
        public static string formatDateHour = "dd/MM/yyyy HH:mm:ss";  //default formato it

        /// <summary>
        /// Costanti per i servizi
        /// </summary>
        public const int C_SRV_AIR = 1;
        public const int C_SRV_HOT = 2;
        public const int C_SRV_CAR = 3;
        public const int C_SRV_RAI = 4;
        public const int C_SRV_OTH = 5;
        public const int C_SRV_NOT = 999; // nota spesa

        /// <summary>
        /// Costanti per funzionalita
        /// </summary>
        public const int funcOperatore = 55;
        public const int funcRichiedente = 58;

        public int idCliente = -1;

        /// <summary>
        /// Costanti per tipologia allegati
        /// </summary>
        public const int C_TIPO_ALLEGATO_PRENOTAZIONE_VIAGGIO = 1;
        public const int C_TIPO_ALLEGATO_NOTA_SPESA = 3;

        #endregion

        #region Definizione Costanti EditorType

        /// <summary>
        /// l'editor non necessita di essere gestito
        /// </summary>
        public const int editRow_NoDefine = 0;

        /// <summary>
        /// l'editor si apre in una popUp (Dialog)
        /// </summary>
        public const int editRow_PopUp = 1;

        /// <summary>
        /// l'editor sostituisce il browser nella stessa pagina
        /// </summary>
        public const int editRow_SubstituteBrowser = 2;

        /// <summary>
        /// edit del record all'interno del browser
        /// </summary>
        public const int editRow_Inline = 3;

        /// <summary>
        /// Si
        /// </summary>
        public const int valueSI = 1;

        /// <summary>
        /// No
        /// </summary>
        public const int valueNO = 0;

        #endregion

        public BasePage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region OnInit
        /// <summary>
        /// Override onInit Base Page: Controllo Sessioni
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            objDictionary = new Dizionario();
            objTestiPagine = new TestiPagine();
            objUtilita = new Utilita(); //Utilizzato per i permessi di accesso

            try
            {
                //Controllo se l'utente è autenticato                
                if (!User.Identity.IsAuthenticated)
                {
                    Exception ex = new Exception("Unauthenticated user. Please log in.");
                    throw ex;
                }
                
                //Controllo se ci sono delle variabili in Session
                if (Session.Count == 0)
                {
                    Exception ex = new Exception("Session Timed Out. Please log in again.");
                    throw ex;
                }
                idLoggedUser = Convert.ToInt32(Session["UTE_ID_UTENTE"]);                
            }
            catch (Exception ecc)
            {
                string strERROR = ecc.Message.Replace("'", "");
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ecc, "Propagate Policy");
                Response.Write(@"<script type='text/javascript'>
                                    try
                                    {
                                        if(window.opener)
                                        {   
                                            if(window.opener.parent.frames)
                                                window.opener.parent.frames.document.location.href='../Login/frm_LGN.aspx?ERROR=" + strERROR + @"';                                                                                                          
                                            else
                                                window.opener.document.location.href='../Login/frm_LGN.aspx?ERROR=" + strERROR + @"';   
                                                             self.close();
                                        }
                                        else
                                        {
                                           if(parent.frames)
                                                parent.frames.document.location.href='../Login/frm_LGN.aspx?ERROR=" + strERROR + @"';
                                           else
                                                document.location.href='../Login/frm_LGN.aspx?ERROR=" + strERROR + @"';     
                                        }
                                    }
                                    catch(e)
                                    {
                                       self.close();                  
                                    }
                              </script>");
                Response.End();
            }

            //Spostato da PageLoad INIZIO ----------------------
            if (Session["NAZ_ID_NAZIONE"] != null)
            {
                qNAZ_ID_NAZIONE = Convert.ToInt32(Session["NAZ_ID_NAZIONE"]);
            }
            else
            {
                qNAZ_ID_NAZIONE = Convert.ToInt32(Request.QueryString["NAZ_ID_NAZIONE"]);
            }
            switch (qNAZ_ID_NAZIONE)
            {
                case 1:
                    qCultureInfoName = "it";
                    break;
                case 3:
                    qCultureInfoName = "en";
                    break;
                default:
                    qCultureInfoName = "it";
                    break;
            }
            dizionarioPermessi = (Dictionary<string, int>)Session["dizionarioPermessi"];
           
            objDizionarioUI = objDictionary.GetDictionary(qNAZ_ID_NAZIONE);

            objTestiPagineUI = objTestiPagine.GetTestipagina(Page.GetType().BaseType.Name, qNAZ_ID_NAZIONE);

            objUtilita.Naz_id_nazione = qNAZ_ID_NAZIONE;
            getCulture();
	    
            if (Page.Header != null)
        	    this.Title = GetValueDizionarioUI("NOME_APPLICAZIONE");

            base.OnInit(e);

        }
        #endregion

        /// <summary>
        /// Permette di utilizzare un metodo (istanziato dalla pagina che sta utilizzando la Basepage) attraverso la Reflection
        /// </summary>
        /// <param name="methodName">Nome del metodo istanziato dalla pagina</param>
        /// <param name="parameters">Eventuali altri parametri richiesti dal metodo</param>
        /// <returns></returns>
        public object callContentFunction(string methodName, params object[] parameters)
        {
            Type contentType = this.Page.GetType();
            System.Reflection.MethodInfo mi = contentType.GetMethod(methodName);
            if (mi == null) return null;

            if (parameters.Length > 0)
            {
                if (parameters[0].ToString() == string.Empty)
                    return mi.Invoke((this.Page), null);
                else
                    return mi.Invoke((this.Page), parameters);
            }
            else
                return mi.Invoke((this.Page), null);
        }

        /// <summary>
        /// Gestione formattazione ad hoc.
        /// </summary>
        /// <param name="valore">valore del campo</param>
        /// <param name="tipo">Tipo di conversione che si vuole applicare</param>
        /// <returns></returns>
        public static string formatValue(object valore, string tipo)
        {
            string valoreFormattato = string.Empty;

            if (valore.ToString() != "")
            {
                switch (tipo)
                {
                    case "data":
                        valoreFormattato = Convert.ToDateTime(valore).ToShortDateString();
                        break;
                    case "longDate":
                        valoreFormattato = Convert.ToDateTime(valore).ToShortDateString() + " " + Convert.ToDateTime(valore).ToLongTimeString();
                        break;
                    case "importo2dec":
                        valoreFormattato = string.Format(formatCurrency, Convert.ToDecimal(valore));
                        break;
                    case "importo3dec":
                        valoreFormattato = string.Format(formatCurrency3decimal, Convert.ToDecimal(valore));
                        break;
                    case "importo4dec":
                        valoreFormattato = string.Format(formatCurrency4decimal, Convert.ToDecimal(valore));
                        break;
                    case "importo6dec":
                        valoreFormattato = string.Format(formatCurrency6decimal, Convert.ToDecimal(valore));
                        break;
                }
            }
            return valoreFormattato;
        }

        /// <summary>
        /// GenerateLookupDropDownList
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="ddl"></param>
        /// <param name="addEmptyItem"></param>
        public void GenerateLookupDropDownList(DataSet dataSource, DropDownList ddl, bool addEmptyItem)
        {
            if (ddl != null && dataSource != null && dataSource.Tables[0].Rows.Count > 0)
            {
                
                foreach(DataRow dr in dataSource.Tables[0].Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = dr["value"].ToString();
                    li.Value = dr["key"].ToString();

                    ddl.Items.Add(li);
                }                                

                if (addEmptyItem)
                    ddl.Items.Insert(0, new ListItem("", ""));

                if (ddl.Items.Count > 0)
                    ddl.SelectedIndex = 0;
            }
        }


        #region Web Form PreRender

        /// <summary>
        /// Renderizza il footer comune a tutte le pagine.
        /// </summary>
        /// <returns></returns>
        public string renderFooter()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='footerSDG'>&copy; SDG " + DateTime.Today.Year + "</div>");

            #region Logo

            Utente objUtente = new Utente();
            Clienti objClienti = new Clienti();

            int versione = 0;
            objUtente.Ute_id_utente = Convert.ToInt32(Session["UTE_ID_UTENTE"]);
            objUtente.Read();

            objClienti.Read(objUtente.Cli_id_cliente.ToSqlInt16(), "it");
            versione = objClienti.Cli_versione_reporting.Value;

            if (!objClienti.Cli_logo_cliente.IsNull && objClienti.Cli_logo_cliente.ToString() != "" && !isMobile())
            {
                sb.Append("<div class='footerCliente'><img src='../Images/Loghi/" + objClienti.Cli_logo_cliente.ToString() + "' alt='" + objClienti.Cli_ragione_sociale.ToString() + "' /></div>");
            }

            #endregion

            return sb.ToString();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Page.Header.DataBind();

            //DEFINIZIONE JSCRIPT STANDARD

            //HtmlGenericControl jQueryLink = new HtmlGenericControl("script");
            //jQueryLink.Attributes.Add("src", "/Web/assets/plugins/jquery/jquery.min.js");
            // jQueryLink.Attributes.Add("type", "text/javascript");            

            //DEFINIZIONE META TAG STANDARD

            //Autore dell'applicazione
            HtmlGenericControl metaTagAuthor = new HtmlGenericControl("meta");
            metaTagAuthor.Attributes.Add("content", "SDG Italy - www.sdgitaly.it");
            metaTagAuthor.Attributes.Add("name", "author");

            //Codifica caratteri UTF-8 // <meta charset="utf-8">
            HtmlGenericControl metaTagContentType = new HtmlGenericControl("meta");
            metaTagContentType.Attributes.Add("http-equiv", "Content-Type");
            metaTagContentType.Attributes.Add("content", "utf-8");

            //Compatibilità
            HtmlGenericControl metaTagCompatibility= new HtmlGenericControl("meta");
            metaTagCompatibility.Attributes.Add("http-equiv", "X-UA-Compatible");
            metaTagCompatibility.Attributes.Add("content", "IE=edge");

            //Viewport
            HtmlGenericControl metaTagViewport = new HtmlGenericControl("meta");
            metaTagViewport.Attributes.Add("name", "viewport");
            metaTagViewport.Attributes.Add("content", "width=device-width, initial-scale=1");

            //Robots
            HtmlGenericControl metaTagRobots = new HtmlGenericControl("meta");
            metaTagRobots.Attributes.Add("name", "robots");
            metaTagRobots.Attributes.Add("content", "noindex, nofollow");

            //Telephone
            HtmlGenericControl metaTagTelephone = new HtmlGenericControl("meta");
            metaTagTelephone.Attributes.Add("name", "format-detection");
            metaTagTelephone.Attributes.Add("content", "telephone=no");

            //Telephone
            HtmlGenericControl metaTagExpires = new HtmlGenericControl("meta");
            metaTagExpires.Attributes.Add("name", "Expires");
            metaTagExpires.Attributes.Add("content", "0");

            //Telephone
            HtmlGenericControl metaTagPragma = new HtmlGenericControl("meta");
            metaTagPragma.Attributes.Add("name", "Pragma");
            metaTagPragma.Attributes.Add("content", "no-cache");
            
            //DEFINIZIONE CSS STANDARD

            // Bootstrap Core CSS
            HtmlLink cssBootstrap = new HtmlLink();
            //cssBootstrap.Href = BundleHelper.InsertFile("../assets/plugins/bootstrap/css/bootstrap.min.css");
            cssBootstrap.Href = "../assets/plugins/bootstrap/css/bootstrap.css?v=" + DateTime.Now.Ticks;
            cssBootstrap.Attributes.Add("rel", "stylesheet");

            HtmlLink cssStyle = new HtmlLink();
            //cssStyle.Href = BundleHelper.InsertFile("../css/style.css");
            cssStyle.Href = "../css/style.css?v=" + DateTime.Now.Ticks;
            cssStyle.Attributes.Add("rel", "stylesheet");

            HtmlLink cssStyleCustom = new HtmlLink();
            //cssStyleCustom.Href = BundleHelper.InsertFile("../css/style-custom.css");
            cssStyleCustom.Href = "../css/style-custom.css?v=" + DateTime.Now.Ticks;
            cssStyleCustom.Attributes.Add("rel", "stylesheet");

            HtmlLink cssColorTheme = new HtmlLink();
            cssColorTheme.Href = "../css/colors/blue.css?v=" + DateTime.Now.Ticks;
            //cssColorTheme.Href = BundleHelper.InsertFile("../css/colors/blue.css");
            cssColorTheme.Attributes.Add("rel", "stylesheet");


            HtmlGenericControl customLink = new HtmlGenericControl("script");
            customLink.Attributes.Add("src", "../JScript/custom.min.js?v=" + DateTime.Now.Ticks);
            customLink.Attributes.Add("type", "text/javascript");

            HtmlGenericControl costantiLink = new HtmlGenericControl("script");
            costantiLink.Attributes.Add("src", "../JScript/Costanti.js?v=" + DateTime.Now.Ticks);
            costantiLink.Attributes.Add("type", "text/javascript");

            HtmlGenericControl formObserveLink = new HtmlGenericControl("script");
            formObserveLink.Attributes.Add("src", "../JScript/jquery.formobserver.js?v=" + DateTime.Now.Ticks);
            formObserveLink.Attributes.Add("type", "text/javascript");

            HtmlGenericControl dateLink = new HtmlGenericControl("script");
            dateLink.Attributes.Add("src", "../JScript/date.js?v=" + DateTime.Now.Ticks);
            dateLink.Attributes.Add("type", "text/javascript");

            HtmlGenericControl datePickerITLink = new HtmlGenericControl("script");
            datePickerITLink.Attributes.Add("src", "../assets/plugins/jqueryui/datepicker-it.js?v=" + DateTime.Now.Ticks);
            datePickerITLink.Attributes.Add("type", "text/javascript");

            HtmlGenericControl jQueryLink = new HtmlGenericControl("script");
            jQueryLink.Attributes.Add("src", "../assets/plugins/jquery/jquery.min.js?v=" + DateTime.Now.Ticks);
            jQueryLink.Attributes.Add("type", "text/javascript");

            HtmlGenericControl jQueryUILink = new HtmlGenericControl("script");
            jQueryUILink.Attributes.Add("src", "../assets/plugins/jqueryui/jquery-ui.min.js?v=" + DateTime.Now.Ticks);
            jQueryUILink.Attributes.Add("type", "text/javascript");

            HtmlGenericControl jScriptLink = new HtmlGenericControl("script");
            jScriptLink.Attributes.Add("src", "../JScript/JScript.js?v=" + DateTime.Now.Ticks);
            jScriptLink.Attributes.Add("type", "text/javascript");

            if (this.Page != null && this.Page.Header != null)
            {
                //Verifico se sono nella Mainpage
                HtmlHead headMainpage = this.Page.FindControl("headMainpage") as HtmlHead;

                //Verifico se sono in un editor
                HtmlHead headEditor = this.Page.FindControl("headEditor") as HtmlHead;

                //Meta Tag standard
                this.Page.Header.Controls.AddAt(1, metaTagContentType);
                this.Page.Header.Controls.AddAt(2, metaTagCompatibility);
                this.Page.Header.Controls.AddAt(3, metaTagViewport);
                this.Page.Header.Controls.AddAt(4, metaTagAuthor);
                this.Page.Header.Controls.AddAt(5, metaTagRobots);
                this.Page.Header.Controls.AddAt(6, metaTagTelephone);
                this.Page.Header.Controls.AddAt(7, metaTagExpires);
                this.Page.Header.Controls.AddAt(8, metaTagPragma);
                //JScript standard


                //Css standard
                // this.Page.Header.Controls.AddAt(8, cssMaster);                

                this.Page.Header.Controls.AddAt(9, jQueryLink);
                this.Page.Header.Controls.AddAt(10, customLink);
                this.Page.Header.Controls.AddAt(11, costantiLink);
                this.Page.Header.Controls.AddAt(12, dateLink);
                
                this.Page.Header.Controls.AddAt(13, jQueryUILink);
                this.Page.Header.Controls.AddAt(14, formObserveLink);
                this.Page.Header.Controls.AddAt(15, datePickerITLink);
                this.Page.Header.Controls.AddAt(16, jScriptLink);

                //Css standard
                this.Page.Header.Controls.AddAt(17, cssBootstrap);
                this.Page.Header.Controls.AddAt(18, cssStyle);
                this.Page.Header.Controls.AddAt(19, cssStyleCustom);
                this.Page.Header.Controls.AddAt(20, cssColorTheme);

                //Css Skin
                //this.Page.Header.Controls.AddAt(10, cssSkin);
                //////////////this.Page.Header.Controls.AddAt(12, jQueryMaskedInput);

                //JScript solo per gli Editor
                //if (headEditor != null)
                //{
                //    this.Page.Header.Controls.AddAt(10, jQueryValidate);
                //    this.Page.Header.Controls.AddAt(11, jQueryFormObserver);

                //}  
                if (isMobile())
                {
                    HtmlLink cssMobile = new HtmlLink();
                    cssMobile.Href = "../css/style-mobile.css?v=" + DateTime.Now.Ticks;
                    cssMobile.Attributes.Add("rel", "stylesheet");
                    this.Page.Header.Controls.AddAt(21, cssMobile);
                }
            }
        }

        /// <summary>
        /// Nasconde o Visualizza i campi del form cosi come da configurazione in tabella
        /// </summary>
        /// <param name="pagina"></param>
        public void showHideFields(string pagina)
        {
            DataSet DsFields = new DataSet();
            string nomeCampoLabel = string.Empty;
            string nomeCampoText = string.Empty;
            string tipoCampo = string.Empty;
            string fieldContainer = string.Empty;
            bool flagRequired = false;
            bool flagVisibile = false;
            bool flagImportant = false;

            try
            {
                DsFields = RichiestaViaggio.showHideFields(idCliente, pagina);
                foreach (DataRow ElencoRighe in DsFields.Tables["CAMPI_NASCOSTI_CLIENTE"].Rows)
                {
                    nomeCampoLabel = "lbl" + ElencoRighe["cnc_nome_campo_nascosto"].ToString();
                    nomeCampoText = "txt" + ElencoRighe["cnc_nome_campo_nascosto"].ToString();
                    tipoCampo = ElencoRighe["cnc_tipo"].ToString();
                    fieldContainer = "div" + ElencoRighe["cnc_nome_campo_nascosto"].ToString();
                    flagVisibile = Convert.ToBoolean(ElencoRighe["cnc_flag_visibile"].ToString());
                    flagRequired = Convert.ToBoolean(ElencoRighe["cnc_flag_required"].ToString());
                    flagImportant = Convert.ToBoolean(ElencoRighe["cnc_flag_important"].ToString());

                    Control genericLbl = new Control();
                    genericLbl = Page.FindControl(nomeCampoLabel);

                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div = (HtmlGenericControl)Page.FindControl(fieldContainer);

                    TextBox genericTxt = new TextBox();
                    if (tipoCampo == "textbox" || tipoCampo == "textarea")
                        genericTxt = (TextBox)Page.FindControl(nomeCampoText);

                    DropDownList genericDdl = new DropDownList();
                    if (tipoCampo == "dropdownlist")
                        genericDdl = (DropDownList)Page.FindControl(nomeCampoText);

                    HtmlInputCheckBox genericChk = new HtmlInputCheckBox();
                    if (tipoCampo == "checkbox")
                        genericChk = (HtmlInputCheckBox)Page.FindControl(nomeCampoText);

                    HtmlInputGenericControl genericHtmlControl = new HtmlInputGenericControl();
                    if (tipoCampo == "htmlinputgenericcontrol")
                        genericHtmlControl = (HtmlInputGenericControl)Page.FindControl(nomeCampoText);

                    //Verifico se il container deve essere visibile o meno
                    if (div != null)
                        div.Visible = flagVisibile;

                    //Verifico se la Label deve essere visibile o meno
                    if (genericLbl != null)
                    {
                        genericLbl.Visible = flagVisibile;
                        ((HtmlGenericControl)genericLbl).InnerText = GetValueDizionarioUI(ElencoRighe["cnc_chiave_label"].ToString());
                    }

                    //Verifico se il campo Textbox deve essere visibile o meno
                    if (genericTxt != null)
                    {
                        genericTxt.Visible = flagVisibile;

                        if (flagRequired)
                        {
                            ((TextBox)genericTxt).CssClass += " required";
                        }

                        if (flagImportant)
                        {
                            ((TextBox)genericTxt).CssClass += " missyoImportant";
                        }
                    }

                    //Verifico se il campo DropDown deve essere visibile o meno
                    if (genericDdl != null)
                    {
                        genericDdl.Visible = flagVisibile;
                        if (flagRequired)
                        {
                            ((DropDownList)genericDdl).CssClass += " required";
                        }

                        if (flagImportant)
                        {
                            ((DropDownList)genericDdl).CssClass += " missyoImportant";
                        }
                    }

                    //Verifico se il campo HtmlGenericControl deve essere visibile o meno
                    if (genericHtmlControl != null)
                    {
                        genericHtmlControl.Visible = flagVisibile;

                        if (flagRequired)
                        {
                            ((HtmlInputGenericControl)genericHtmlControl).Attributes["class"] = ((HtmlInputGenericControl)genericHtmlControl).Attributes["class"] + " required";
                        }

                        if (flagImportant)
                        {
                            ((HtmlInputGenericControl)genericHtmlControl).Attributes.Add("class", " missyoImportant");
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }

        #endregion

        /// <summary>
        /// Se modalità "mobile" restituisce TRUE, altrimenti FALSE.
        /// </summary>
        /// <returns></returns>
        public bool isMobile()
        {
            if (Session["isMobile"] != null)
            {
                if (Session["isMobile"].ToString() == "1")
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Metodo creato ad hoc per ricavare un datareader che chiude la connessione con il DB.
        /// </summary>
        /// <param name="sqlCommand">Sql da eseguire per la Read</param>
        /// <param name="parameterCollection">Collezione di tutti i parametri da passare al metodo</param>
        /// <param name="method">Nome del metodo chiamante per gestire l'errore in caso di eccezione</param>
        public static SqlDataReader getReader(string sqlCommand, SqlParameterCollection parameterCollection, string method)
        {
            SqlCommand dbCommand = new SqlCommand();
            SqlConnection dbConnection = new SqlConnection();
            SqlDataReader reader = null;

            try
            {
                dbConnection.ConnectionString = ConfigurationManager.ConnectionStrings["CONNECTION_STRING"].ToString();
                dbCommand.CommandText = sqlCommand;
                dbCommand.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["QueryCommandTimeout"]);
                dbCommand.Connection = dbConnection;
                dbCommand.Connection.Open();

                foreach (SqlParameter p in parameterCollection)
                {
                    dbCommand.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
                }
                reader = dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", method);
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));
                throw ex;
            }
            return reader;
        }
    }
}
