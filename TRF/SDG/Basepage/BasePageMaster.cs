#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   BasePageMaster.cs
//
// Namespace:   SDG.GestioneUtenti.Web
// Descrizione: Pagina base utilizzata come padre della altre basepage
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using SDG.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using System.Data;
using System.Data.SqlTypes;
using System.Xml;
using System.IO;
using SDG.WorkFlow;
using AjaxControlToolkit;

namespace SDG.GestioneUtenti.Web
{
    /// <summary>
    /// Summary description for BasePageMaster.
    /// </summary>
    public class BasePageMaster : System.Web.UI.Page
    {
        #region Costanti

        public const string nazionale = "1";
        public const string internazionale = "2";
        public const string intercontinentale = "3";
        //public const int idUtenteBCD = 147060;
        //public const int cliZAR = 33;
        public const string formazione = "F";
        public const string reception = "R";

        public const string Rimborsabile = "1";
        public const string NonRimborsabile = "2";

        #endregion

        #region Web Control Declaration

        //QSTRING APPLICAZIONE
        protected string qMODALITA;
        public int qNAZ_ID_NAZIONE;
        public string qCultureInfoName;
        public Dictionary<string, string> objDizionarioUI;
        public Dizionario objDictionary;            
        public Dictionary<string, string> objTestiPagineUI;
        public TestiPagine objTestiPagine;               
        public Dictionary<string, int> dizionarioPermessi;
        public int idLoggedUser;
        public string loggedUser;
        protected int idSocieta;
        //protected int idCliente;
        protected int permessoPagina;
        protected bool allowAccess;
        protected bool allowEdit;
        protected bool allowDelete;
        protected Utilita objUtilita;
        protected string pwdAvviso;
        protected Lock objLock;
        protected ScriptManager TAFScriptManager;            
        protected System.Web.UI.HtmlControls.HtmlTitle PageTitle;           
            
        #endregion

        #region Costruttori
            public BasePageMaster()
            {
                //
                // TODO: Add constructor logic here
                //
            }
        #endregion

        #region OnInit

        /// <summary>
        /// Override onInit Base Page
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        #endregion

        #region Page Load

            protected void PageLoad(object sender, System.EventArgs e)
            {
                ReleaseLock();
            }

            /// <summary>
            /// Pulisco la tabella dei Lock dell'utente che è nel sistema.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            protected void ReleaseLock()
            {
            Lock objLock = new Lock();
            //objLock.Ute_id_utente = Convert.ToInt32(Session["UTE_ID_UTENTE"].ToString());
            //SVA(07102011): Riga inserita per gestione dei lock tramite SessionID
            objLock.Lck_id_sessione = SqlGuid.Parse(Session["SESSIONID"].ToString());
            objLock.Delete();
        }

        #endregion

        #region Array

        /// <summary>
            /// Gestione combo in cascata
            /// </summary>
        public class ArrayJs
            {
                private string _value;
                private string _id;

                public ArrayJs()
                { }

                public ArrayJs(string id, string value)
                {
                    this._value = value;
                    this._id = id;
                }

                public string Value
                {
                    get { return _value; }
                    // Set necessario se si vuole usare la serializzazione XML
                    // in alternativa implementare IXmlSerializable
                    set { _value = value; }
                }

                public string Id
                {
                    get { return _id; }
                    set { _value = value; }
                }
            }

        #endregion

        #region Control Access

            /// <summary>
            /// Verifica permessi di accesso alla pagina
            /// </summary>
            /// <param name="acronimoPermesso">Acronimo definito nella funzionalità.</param>
            protected void SetPageControlAccess(string acronimoPermesso)
            {
                try
                {
                    if (dizionarioPermessi.ContainsKey(acronimoPermesso))
                        permessoPagina = dizionarioPermessi[acronimoPermesso];
                    else
                        permessoPagina = objUtilita.AccessNone;

                    allowAccess = (permessoPagina > objUtilita.AccessNone);
                    allowEdit = ((qMODALITA != "VIEW") && (permessoPagina > objUtilita.AccessRead));
                    allowDelete = ((qMODALITA != "VIEW") && (permessoPagina > objUtilita.AccessReadWrite));

                    if (!allowAccess)
                    {
                        //if (Request.UrlReferrer != null && Request.UrlReferrer.AbsoluteUri != null)
                        //    Response.Redirect(Request.UrlReferrer.AbsoluteUri,false);
                        //else
                        Base_Js_CloseWindow();
                        //Base_Alert("Non hai sufficienti privilegi.");
                    }
                }
                catch (Exception ex)
                {
                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Propagate Policy");
                }
            }
        
        #endregion

        #region JScript

            /// <summary>
            /// Script Js closeWindow
            /// </summary>
            /// <returns></returns>
            protected string Base_Js_CloseWindow()
            {
                string js = @"
                                <script>
					            function closeWindow()
					            { 
						            self.close();
					            }
					            </script>";

                return js;
            }

        #endregion

        #region functions
            protected string InseritoAggiornato(SqlInt32 idUtenteIns, SqlDateTime dataIns, SqlInt32 idUtenteUpd, SqlDateTime dataUpd)
            {
                return InseritoAggiornato(idUtenteIns, dataIns, idUtenteUpd, dataUpd, false);
            }

            protected string InseritoAggiornato(SqlInt32 idUtenteIns, SqlDateTime dataIns, SqlInt32 idUtenteUpd, SqlDateTime dataUpd, bool timeVisible)
            {
                StringBuilder result = new StringBuilder(200);
                result.Append("<div class='utenteInserimentoAggiornamento'><strong>");
                result.Append(getDizionarioUI("UTENTE_INSERIMENTO"));
                result.Append(": </strong>");
                Utente utenteIns = new Utente();
                utenteIns.Ute_id_utente = idUtenteIns;
                utenteIns.Read();
                result.Append(utenteIns.Ute_user_id);
                if (!dataIns.IsNull)
                {
                    result.Append(" - <strong>");
                    result.Append(getDizionarioUI("DATA_IL"));
                    result.Append(": </strong>");
                    result.Append(dataIns.Value.ToShortDateString());
                    if (timeVisible)
                    {
                        result.Append(" - ");
                        result.Append(dataIns.Value.ToShortTimeString());
                    }
                }
                if (idUtenteUpd.IsNull)
                {
                    //se non sono ancora stati fatti aggiornamenti ripropongo i dati dell'inserimento
                    result.Append("   <strong>");
                    result.Append(getDizionarioUI("UTENTE_AGGIORNAMENTO"));
                    result.Append(": </strong>");
                    result.Append(utenteIns.Ute_user_id);
                    if (!dataIns.IsNull)
                    {
                        result.Append(" - <strong>");
                        result.Append(getDizionarioUI("DATA_IL"));
                        result.Append(": </strong>");
                        result.Append(dataIns.Value.ToShortDateString());
                        if (timeVisible)
                        {
                            result.Append(" - ");
                            result.Append(dataIns.Value.ToShortTimeString());
                        }
                    }
                }
                else
                {
                    result.Append("   <strong>");
                    result.Append(getDizionarioUI("UTENTE_AGGIORNAMENTO"));
                    result.Append(": </strong>");
                    Utente utenteUpd = new Utente();
                    utenteUpd.Ute_id_utente = idUtenteUpd;
                    utenteUpd.Read();
                    result.Append(utenteUpd.Ute_user_id);
                    if (!dataUpd.IsNull)
                    {
                        result.Append(" - <strong>");
                        result.Append(getDizionarioUI("DATA_IL"));
                        result.Append(": </strong>");
                        result.Append(dataUpd.Value.ToShortDateString());
                        if (timeVisible)
                        {
                            result.Append(" - ");
                            result.Append(dataUpd.Value.ToShortTimeString());
                        }
                    }
                } 
                result.Append("</div>");
                return result.ToString();
            }

            /// <summary>
            /// Translate dataReader to dataTable
            /// </summary>
            /// <param name="_reader"></param>
            /// <returns></returns>
            public System.Data.DataTable GetTable(System.Data.IDataReader _reader)
            {
                System.Data.DataTable _table = _reader.GetSchemaTable();
                System.Data.DataTable _dt = new System.Data.DataTable();
                System.Data.DataColumn _dc;
                System.Data.DataRow _row;
                System.Collections.ArrayList _al = new System.Collections.ArrayList();

                for (int i = 0; i < _table.Rows.Count; i++)
                {
                    _dc = new System.Data.DataColumn();

                    if (!_dt.Columns.Contains(_table.Rows[i]["ColumnName"].ToString()))
                    {
                        _dc.ColumnName = _table.Rows[i]["ColumnName"].ToString();
                        _dc.Unique = Convert.ToBoolean(_table.Rows[i]["IsUnique"]);
                        _dc.AllowDBNull = Convert.ToBoolean(_table.Rows[i]["AllowDBNull"]);
                        _dc.ReadOnly = Convert.ToBoolean(_table.Rows[i]["IsReadOnly"]);
                        _al.Add(_dc.ColumnName);
                        _dt.Columns.Add(_dc);
                    }
                }

                while (_reader.Read())
                {
                    _row = _dt.NewRow();

                    for (int i = 0; i < _al.Count; i++)
                    {

                        _row[((System.String)_al[i])] = _reader[(System.String)_al[i]];

                    }

                    _dt.Rows.Add(_row);
                }
                _reader.Close();

                return _dt;
            }

            public void Base_Alert(string strMessage)
            {
                string strScript = "<script type='text/javascript' language=JavaScript>alert('" + strMessage + "')</script>";

                if (!this.ClientScript.IsStartupScriptRegistered("Alert_JS"))
                {
                    this.ClientScript.RegisterStartupScript(GetType(), "Alert_JS", strScript);
                }
            }

            public void Base_Alert_Update_Panel(string strMessage)
            {
                string strScript = "alert('" + strMessage + "');";
              
                ScriptManager.RegisterStartupScript(Page, this.GetType(), Page.ClientID, strScript, true);
            }

            //AR ATTENZIONE!!!!! Qualsiasi variazione deve essere riportata anche nella BasePage!!!
            // return value will be stored in a password field(varchar) or will be compared against the value in sql.
            public string EncryptPwd(string pwd)
            {
                //return FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5")

                Byte[] pwdToHash = StringToByteArray(pwd);
                byte[] pwdHashValue = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(pwdToHash);

                return BitConverter.ToString(pwdHashValue);
            }

            Byte[] StringToByteArray(String s)
            {
                return (new UnicodeEncoding()).GetBytes(s);
            }
            //AR ATTENZIONE!!!!! Qualsiasi variazione deve essere riportata anche nella BasePage!!!

            /// <summary>
            /// Restituisce il valore dell'oggetto objDizionarioUI con l'indice in input, se trovato, altrimenti restituisce una stringa specifica.
            /// </summary>  
            public string GetValueDizionarioUI(string Key)
            {
                string Value;
                if (!objDizionarioUI.TryGetValue(Key, out Value))
                {
                    Value = "XX"+Key+"XX";
                }
                return Value;
            }

            //Se esiste l’oggetto objTestiPagineUI:
            /// <summary>
            /// Restituisce il valore dell'oggetto objTestiPagineUI con l'indice in input, se trovato, altrimenti restituisce string vuota.
            /// </summary>  
            public string GetValueTestiPagineUI(string Key)
            {
                string Value;
                if (!objTestiPagineUI.TryGetValue(Key, out Value))
                {
                    Value = String.Empty;
                }
                return Value;
            }

            /// <summary>
            /// Recupero della cultura in base a Naz_id_nazione
            /// </summary>
            public void getCulture()
            {
                switch (qNAZ_ID_NAZIONE)
                {
                    case 1:
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");
                        return;
                    case 3:
                        //Commentata questa riga perchè altrimenti tutte le date utilizzate nel sistema venivano rappresentate
                        //nel formato inglese mm/gg/aaaa ma nel nostro caso ci serve avere solo i testi (label) in inglese che sono
                        //gtestiti in un modo indipendente rispetto alla CurrentCulture.
                        //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");
                        return;
                }
            }

            private void Page_Error(object sender, System.EventArgs e)
            {
                Exception ex = Server.GetLastError();
                ex.Data.Add("SQL", ex.StackTrace);
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
                Server.ClearError();
                Response.Flush();
            }

            /// <summary>
            /// Gestione messaggistica all'utente e trace in DB dell'errore  
            /// </summary>
            /// <param name="ex"></param>
            public void handleUpdatePanelException(Exception ex)
            {
                string messaggio = ex.Message;
                ViewMessage(messaggio);
            
                ex.Data.Add("UpdatePanel", "True");
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }

            /// <summary>
            /// Visualizzo il messaggio di lock nel "divErrori" concatenando il nome dell'utente che blocca il record
            /// </summary>
            /// <param name="message"></param>
            /// <param name="utente"></param>
            public void ViewLockMessage(string message, string utente)
            {
                string str = message + " " + utente;
                ViewMessage(str);
            }

            /// <summary>
            /// Visualizzo il messaggio di errore nel "divErrori"
            /// </summary>
            /// <param name="message">Messaggio da visualizzare</param>
            /// <returns></returns>
            public void ViewMessage(string message)
            {
                HtmlGenericControl content = this.Page.Form.FindControl("content") as HtmlGenericControl;
                HtmlGenericControl divErrori = new HtmlGenericControl("div");
                divErrori.ID = "divErrori";
                divErrori.InnerHtml = "<p id='pErrori'></p>";

                PlaceHolder phMessage = this.Page.Form.FindControl("phMessage") as PlaceHolder;

                if (phMessage != null)
                {
                    phMessage.Controls.Add(divErrori);
                }
                else if (content != null)
                {
                    content.Controls.Add(divErrori);
                }                
                string strScript = @"                            
                            $('#pErrori').html("" " + message + @" "");
                            $('#divErrori').css('display','block');
                            document.location.href='#divErrori';";

                ScriptManager.RegisterStartupScript(Page, this.GetType(), Page.ClientID, strScript, true);
            }

        #endregion

        #region helper
        
            /// <summary>
            /// ...
            /// </summary>
            protected void BaseEnableControls(ControlCollection controlCollection, bool isUserEnabled)
            {
                foreach (Control control in controlCollection)
                {
                    //il controllo è di tipo CheckBox
                    if (control is CheckBox)			 
                    {
                        ((CheckBox)control).Enabled = isUserEnabled;
                    }
                    //il controllo è di tipo TextBox
                    if (control is TextBox)			
                    {
                        ((TextBox)control).ReadOnly = !isUserEnabled;
                    }
                    //il controllo è di tipo HtmlCheckBox
                    if (control is HtmlInputCheckBox)			
                    {
                        ((HtmlInputCheckBox)control).Disabled = !isUserEnabled;
                    }
                    //il controllo è di tipo HtmlInputText
                    if (control is HtmlInputText)    
                    {
                        if (!isUserEnabled)
                        {
                            ((HtmlInputText)control).Attributes.Add("readOnly", "");
                            //((HtmlInputText)control).Attributes.Remove("onClick");
                            //((HtmlInputText)control).Attributes.Remove("onChange");
                            //((HtmlInputText)control).Attributes.Remove("onKeyup");
                            //((HtmlInputText)control).Attributes.Remove("onKeydown");
                            //((HtmlInputText)control).Attributes.Remove("onBlur");
                            //((HtmlInputText)control).Attributes.Remove("onFocus");
                        }
                    }
                    //il controllo è di tipo HtmlTextArea
                    if (control is HtmlTextArea)
                    {
                        ((HtmlTextArea)control).Disabled = !isUserEnabled;
                    }

                    //il controllo è di tipo DropDownList
                    if (control is DropDownList)   
                    {
                        ((DropDownList)control).Enabled = isUserEnabled;
                    }
                    //il controllo è di tipo HtmlInputButton
                    if (control is HtmlInputButton)			
                    {
                        //si controlla che l'ID del controllo contenga la stringa CONFERMA o NEW
                        //int ctl_to_find = (control.ID.ToString().ToUpper().IndexOf("BUTTONPREVIOUS"));
                        //int ctl_to_find2 = (control.ID.ToString().ToUpper().IndexOf("BUTTONNEXT"));

                        //if (ctl_to_find != -1 | ctl_to_find2 != -1)
                        //{
                            ((HtmlInputButton)control).Disabled = !isUserEnabled;
                        //}
                    }
                    //il controllo è di tipo Button
                    if (control is Button)			
                    {
                        //si controlla che l'ID del controllo non contenga la stringa ANNULLA o HELP
                        //int ctl_to_find = (control.ID.ToString().ToUpper().IndexOf("ANNULLA"));
                        //int ctl_to_find2 = (control.ID.ToString().ToUpper().IndexOf("HELP"));
                        //Il pulsante ButtonGeneraCodiceUnivoco non viene toccato
                        //int ctl_to_find3 = (control.ID.ToString().ToUpper().IndexOf("BUTTONGENERACODICEUNIVOCO"));

                        //if (ctl_to_find == -1 && ctl_to_find2 == -1 && ctl_to_find3 == -1)
                        //{
                            ((Button)control).Enabled = isUserEnabled;
                        //}
                    }
                    
                    //loop nested controls
                    if (control.Controls != null)
                    {
                        BaseEnableControls(control.Controls, isUserEnabled);
                    }
                }
            }

            /// <summary>
            /// Disabilita tutti i campi tranne i bottoni
            /// </summary>
            protected void BaseEnableControlsNoButton(ControlCollection controlCollection, bool isUserEnabled)
            {
                foreach (Control control in controlCollection)
                {                    
                    //il controllo è di tipo CheckBox
                    if (control is CheckBox)
                    {
                        ((CheckBox)control).Enabled = isUserEnabled;
                    }
                    //il controllo è di tipo TextBox
                    if (control is TextBox)
                    {                        
                        ((TextBox)control).ReadOnly = !isUserEnabled;
                    }
                    //il controllo è di tipo HtmlCheckBox
                    if (control is HtmlInputCheckBox)
                    {
                        ((HtmlInputCheckBox)control).Disabled = !isUserEnabled;
                    }
                    //il controllo è di tipo HtmlInputText
                    if (control is HtmlInputText)
                    {
                        if (!isUserEnabled)
                        {
                            ((HtmlInputText)control).Attributes.Add("readOnly", "");
                            //((HtmlInputText)control).Attributes.Remove("onClick");
                            //((HtmlInputText)control).Attributes.Remove("onChange");
                            //((HtmlInputText)control).Attributes.Remove("onKeyup");
                            //((HtmlInputText)control).Attributes.Remove("onKeydown");
                            //((HtmlInputText)control).Attributes.Remove("onBlur");
                            //((HtmlInputText)control).Attributes.Remove("onFocus");
                        }
                    }
                    //il controllo è di tipo HtmlTextArea
                    if (control is HtmlTextArea)
                    {
                        ((HtmlTextArea)control).Disabled = !isUserEnabled;
                    }

                    //il controllo è di tipo DropDownList
                    if (control is DropDownList)
                    {
                        ((DropDownList)control).Enabled = isUserEnabled;
                    }
                    //il controllo è di tipo HtmlInputButton
                    
                    if (control is HtmlInputButton)
                    {                   
                        ((HtmlInputButton)control).Disabled = false;                   
                    }
                    //il controllo è di tipo Button
                    if (control is Button)
                    {
                       ((Button)control).Enabled = true;                   
                    }

                    if (control is HtmlImage)
                    {
                        ((HtmlImage)control).Disabled = !isUserEnabled;
                    }
                    /*
                    //il controllo è di tipo TextBox Infragistics Currency
                    if (control is Infragistics.WebUI.WebDataInput.WebCurrencyEdit)
                    {
                        ((Infragistics.WebUI.WebDataInput.WebCurrencyEdit)control).ReadOnly = !isUserEnabled;
                    }
                    //il controllo è di tipo TextBox Infragistics Numeric
                    if (control is Infragistics.WebUI.WebDataInput.WebNumericEdit)
                    {
                        ((Infragistics.WebUI.WebDataInput.WebNumericEdit)control).ReadOnly = !isUserEnabled;
                    }
                    //il controllo è di tipo Data Infragistics
                    if (control is Infragistics.WebUI.WebDataInput.WebDateTimeEdit)
                    {
                        ((Infragistics.WebUI.WebDataInput.WebDateTimeEdit)control).ReadOnly = !isUserEnabled;
                    }
                    //il controllo è di tipo DateChooser Infragistics
                    if (control is Infragistics.WebUI.WebSchedule.WebDateChooser)
                    {
                        ((Infragistics.WebUI.WebSchedule.WebDateChooser)control).ReadOnly = !isUserEnabled;
                    }
                    */
                    //loop nested controls
                    if (control.Controls != null)
                    {
                        BaseEnableControlsNoButton(control.Controls, isUserEnabled);
                    }
                }
            }

            /// <summary>
            /// ...
            /// </summary>
            protected void BaseGestioneTestiPagina(ControlCollection controlCollection)
            {
                string idDiv;
                string strScript;
                foreach (Control control in controlCollection)
                {                
                    //il controllo è di tipo HtmlGenericControl
                    if (control is HtmlGenericControl && control.ID != null)
                    {
                        idDiv = control.ID;                    
                        if (idDiv.IndexOf("divTesto") >= 0 || idDiv.IndexOf("divContentHelp") >= 0)
                        {                        

                            strScript = "javascript:window.open('../TestiPagine/frm_MSE_TPG.aspx?TPG_PAGINA=";
                            strScript += Page.GetType().BaseType.Name + "&TPG_POSIZIONE=" + idDiv + "','EditorTesti','toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,left=0,top=0,width=1024,height=768');return false; ";
                            ((HtmlGenericControl)control).Attributes["onclick"] = strScript;
                            ((HtmlGenericControl)control).Attributes["class"] = "contenitoreDivTesto";
                        }                
                    }

                    //loop nested controls
                    if (control.Controls != null)
                    {
                        BaseGestioneTestiPagina(control.Controls);
                    }
                }
            }

            /// <summary>
            /// ...
            /// </summary>
            protected void BaseGestioneTestiPagina(ControlCollection controlCollection, string nomePagina)
            {
                string idDiv;
                string strScript;
                foreach (Control control in controlCollection)
                {
                    //il controllo è di tipo HtmlGenericControl
                    if (control is HtmlGenericControl && control.ID != null)
                    {
                        idDiv = control.ID;
                        if (idDiv.IndexOf("divContentHelp") >= 0)
                        {

                            strScript = "javascript:window.open('../TestiPagine/frm_MSE_TPG.aspx?TPG_PAGINA=";
                            strScript += nomePagina + "&TPG_POSIZIONE=" + idDiv + "','EditorTesti','toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,left=0,top=0,width=1024,height=768');return false; ";
                            ((HtmlGenericControl)control).Attributes["onclick"] = strScript;
                            ((HtmlGenericControl)control).Attributes["class"] = "contenitoreDivTesto";
                        }
                    }

                    //loop nested controls
                    if (control.Controls != null)
                    {
                        BaseGestioneTestiPagina(control.Controls, nomePagina);
                    }
                }
            }

        #endregion

        #region LockRecord

            protected void SetLockRecord(Int32 id_record, string tabella, Int32 ute_id_utente)
            {
                try
                {
                    objLock = new Lock();
                    objLock.Lck_id_record = id_record;
                    objLock.Lck_tabella = tabella;
                    objLock.Ute_id_utente = ute_id_utente;
                    //SVA(07102011): Riga inserita per gestione dei lock tramite SessionID
                    objLock.Lck_id_sessione = SqlGuid.Parse(Session["SESSIONID"].ToString());
                    objLock.Create();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            protected bool GetLockRecord(Int32 id_record, string tabella)
            {
                try
                {
                    objLock = new Lock();
                    objLock.Lck_id_record = id_record;
                    objLock.Lck_tabella = tabella;
                    bool isLocked = objLock.ReadLock();
                    Session["LCK_UTENTE"] = objLock.Lck_utente.Value;
                    Session["LCK_UTENTE_CONTATTI"] = objLock.Lck_utente_contatti.Value;
                    return isLocked;
                }
                catch (Exception ex)
                {
                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Propagate Policy");

                    return true;
                }
            }
           
        #endregion

        #region ExportExcel

            public void DataSetToExcel(IEnumerable tables, string fileName)
            {
                DataSetToExcel(tables, fileName, "", false);
            }

            public void DataSetToExcel(IEnumerable tables, string fileName, bool reportTime)
            {
                DataSetToExcel(tables, fileName, "", reportTime);
            }

            /// <summary>
            /// DataSetToExcel - Esporta in Excel il contenuto di un DataSet
            /// </summary>
            /// <param name="tables">Le Tables contenute nel dataset (ottenute con DataSet.Tables)</param>
            /// <param name="fileName">Stringa che identifica il file Excel</param>
            /// <param name="filterExpression">Filtro da applicare al Dataset</param>
            /// <param name="reportTime">flag che indica alla funzione se i datetime vanno esportati nel formato "data ora" (=true) o solo data (=false)</param>
            public void DataSetToExcel(IEnumerable tables, string fileName, string filterExpression, bool reportTime)
            {
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".xls");

                using (XmlTextWriter x = new XmlTextWriter(Response.OutputStream, Encoding.UTF8))
                {
                    int sheetNumber = 0;
                    x.WriteRaw("<?xml version=\"1.0\"?><?mso-application progid=\"Excel.Sheet\"?>");
                    x.WriteRaw("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" ");
                    x.WriteRaw("xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
                    x.WriteRaw("xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                    x.WriteRaw("<Styles>");
                    x.WriteRaw("<Style ss:ID='sText'><NumberFormat ss:Format='@'/></Style>");
                    //x.WriteRaw("<Style ss:ID='sDate'><NumberFormat ss:Format='[$-409]dd/mm/yyyy;@'/></Style>");
                    //AR Permettiamo opzionalemnte di visualizzare anche l'ora
                    string strTime = "";
                    if (reportTime)
                        strTime = " HH:mm.ss";
                    //AR proviamo a renderizzare le date in base alla lingua
                    string cultureID = String.Format("{0:X}", CultureInfo.CurrentCulture.LCID);
                    switch (qCultureInfoName.ToLower())
                    {
                        case "it":
                            x.WriteRaw("<Style ss:ID='sDate'><NumberFormat ss:Format='[$-" + cultureID + "]dd/mm/yyyy" + strTime + ";@'/></Style>");
                            break;
                        case "en":
                            x.WriteRaw("<Style ss:ID='sDate'><NumberFormat ss:Format='[$-" + cultureID + "]mm/dd/yyyy" + strTime + ";@'/></Style>");
                            break;
                        default:
                            x.WriteRaw("<Style ss:ID='sDate'><NumberFormat ss:Format='[$-" + cultureID + "]dd/mm/yyyy" + strTime + ";@'/></Style>");
                            break;
                    }
                    x.WriteRaw("<Style ss:ID='sDecimal'><NumberFormat ss:Format='#,##0.00'/></Style>");
                    x.WriteRaw("</Styles>");
                    foreach (DataTable dt in tables)
                    {
                        //dt.DefaultView.RowFilter = filterExpression;

                        sheetNumber++;
                        string sheetName = !string.IsNullOrEmpty(dt.TableName) ?
                               dt.TableName : "Sheet" + sheetNumber.ToString();
                        x.WriteRaw("<Worksheet ss:Name='" + sheetName + "'>");
                        x.WriteRaw("<Table>");
                        string[] columnTypes = new string[dt.Columns.Count];
                        //AR Introduco anche un array styleTypes per distinguere le varie colonne di tipo "Number" e "String"
                        string[] styleTypes = new string[dt.Columns.Count];

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string colType = dt.Columns[i].DataType.ToString().ToLower();

                            if (colType.Contains("datetime"))
                            {
                                columnTypes[i] = "DateTime";
                                styleTypes[i] = "DateTime";
                                x.WriteRaw("<Column ss:StyleID='sDate'/>");

                            }
                            else if (colType.Contains("string"))
                            {
                                columnTypes[i] = "String";
                                styleTypes[i] = "String";
                                x.WriteRaw("<Column ss:StyleID='sText'/>");

                            }
                            else if (colType.Contains("decimal"))
                            {
                                columnTypes[i] = "Number";
                                styleTypes[i] = "Decimal";
                                x.WriteRaw("<Column ss:StyleID='sDecimal'/>");
                            }
                            else
                            {
                                x.WriteRaw("<Column />");

                                if (colType.Contains("boolean"))
                                {
                                    //Renderizziamo i boolean come stringhe SI/NO
                                    columnTypes[i] = "String";
                                    styleTypes[i] = "Boolean";
                                }
                                else
                                {
                                    //default is some kind of number.
                                    columnTypes[i] = "Number";
                                    styleTypes[i] = "Number";
                                }

                            }
                        }
                        //column headers
                        x.WriteRaw("<Row>");
                        foreach (DataColumn col in dt.Columns)
                        {
                            x.WriteRaw("<Cell ss:StyleID='sText'><Data ss:Type='String'>");
                            if (!getDizionarioUI(col.ColumnName).StartsWith("XX"))
                                x.WriteRaw(getDizionarioUI(col.ColumnName));
                            else
                                x.WriteRaw(col.ColumnName);
                            x.WriteRaw("</Data></Cell>");
                        }
                        x.WriteRaw("</Row>");
                        //data
                        bool missedNullColumn = false;
                        foreach (DataRow row in dt.Rows)
                        {
                            x.WriteRaw("<Row>");
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                if (!row.IsNull(i))
                                {
                                    if (missedNullColumn)
                                    {
                                        int displayIndex = i + 1;
                                        x.WriteRaw("<Cell ss:Index='" + displayIndex.ToString() +
                                                   "'><Data ss:Type='" +
                                                   columnTypes[i] + "'>");
                                        missedNullColumn = false;
                                    }
                                    else
                                    {
                                        x.WriteRaw("<Cell><Data ss:Type='" +
                                                   columnTypes[i] + "'>");
                                    }

                                    //switch (columnTypes[i])
                                    switch (styleTypes[i])
                                    {
                                        case "DateTime":
                                            x.WriteRaw(((DateTime)row[i]).ToString("s"));
                                            break;
                                        case "Boolean":
                                            //    x.WriteRaw(((bool)row[i]) ? "1" : "0");
                                            //Leggiamo dal dizionario le stringhe che identificano "SI" e "NO"
                                            //Se non trova nulla, mette "1" e "0" rispettivamente (si può modificare cambiando le stringhe nella riga sotto)
                                            x.WriteRaw(((bool)row[i]) ? (getDizionarioUI("FLAG_YES").StartsWith("XX") ? "1" : getDizionarioUI("FLAG_YES")) : (getDizionarioUI("FLAG_NO").StartsWith("XX") ? "0" : getDizionarioUI("FLAG_NO")));
                                            break;
                                        case "String":
                                            x.WriteString(row[i].ToString());
                                            break;
                                        case "Decimal":
                                            x.WriteValue(Convert.ToDecimal(row[i]));
                                            break;
                                        case "Number":
                                            x.WriteValue(row[i]);
                                            break;
                                        default:
                                            x.WriteString(row[i].ToString());
                                            break;
                                    }

                                    x.WriteRaw("</Data></Cell>");
                                }
                                else
                                {
                                    missedNullColumn = true;
                                }
                            }
                            x.WriteRaw("</Row>");
                        }
                        x.WriteRaw("</Table></Worksheet>");
                    }
                    x.WriteRaw("</Workbook>");
                }
                Response.End();
            }

        #endregion

        #region ExportCSV
        
            /// <summary>
            /// Crea un file CSV partendo da un datatable e il nome del file. Il separatore tra i campi è ";".
            /// Potrebbe anche essere personalizzata aggiungendo come parametro di ingresso il separatore desiderato.
            /// </summary>
            /// <param name="dt">Nome della tabella</param>
            /// <param name="strFilePath">Percorso del file</param>
            /// <param name="intestazioniRiga">Inserisci intestazione riga</param>
            public void CreateCSVFile(DataTable dt, string strFilePath, bool intestazioniRiga)
            {
                // Create the CSV file to which grid data will be exported.
                StreamWriter sw = new StreamWriter(strFilePath, false);

                int iColCount = dt.Columns.Count;

                if (intestazioniRiga == true)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        sw.Write(dt.Columns[i].ColumnName);
                        if (i < iColCount - 1)
                        {
                            sw.Write(";");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                // Now write all the rows.
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write(";");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
            }

        #endregion

        #region ToolkitScriptManager

            /// <summary>
            /// Configurazione standard del ToolkitScriptManager
            /// </summary>
            protected void ConfigToolkitScriptManager()
            {
                ConfigToolkitScriptManager("CustomScriptManager");
            }

            /// <summary>
            /// Configurazione standard del ToolkitScriptManager
            /// </summary>
            /// <param name="ToolkitScriptManager">ID dell'oggetto ToolkitScriptManager se diverso da "CustomScriptManager"</param>
            protected void ConfigToolkitScriptManager(string ToolkitScriptManager)
            {
                if (this.Page.Form != null)
                {
                    ToolkitScriptManager tsm = (ToolkitScriptManager)this.Page.Form.FindControl(ToolkitScriptManager);
                    if (tsm != null)
                    {
                        tsm.EnablePartialRendering = true;
                        tsm.EnablePageMethods = true;
                        tsm.CombineScripts = false;
                    }
                }    
            }

        #endregion

        /// <summary>
        /// Ricalcola le figure nella objectowner
        /// </summary>
        /// <param name="idUtente"></param>
        protected void ReCalculateObjectOwner(int idUtente,int idCliente)
        {
            try
            {
                Workflow objWorkflow;
                objWorkflow = new Workflow();
                objWorkflow.UpdateObjectOwner(idUtente,idCliente);           
            }
            catch (Exception ex)
            {
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }

        }

        /// <summary>
        /// SendContent - Manda al web browser il contenuto di un file  
        /// </summary>
        /// <param name="fileContent">Array associato al MemoryStream che contiene il contenuto del file</param>
        /// <param name="outFileName">Nome con cui il file viene aperto (non necessariamente è il path vero del file)</param>
        /// <param name="outFileContentType">MIME content type del file</param>
        /// <param name="forceDownload">Switch per forzare (cioé senza chiedere all'utente) il download </param>
        protected void SendContent(byte[] fileContent, string outFileName, string outFileContentType, bool forceDownload)
        {
            try
            {
                HttpContext.Current.Response.ClearContent();

                if (forceDownload)
                    HttpContext.Current.Response.AddHeader("Content-Type", "application/octet-stream");                    
                else
                    HttpContext.Current.Response.AddHeader("Content-Type", outFileContentType);

                //HttpContext.Current.Response.ContentType = ;

                // LINE1: Add the file name and attachment, which will force the open/cance/save dialog to show, to the header
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", outFileName.Replace(" ", "_")));                

                // Add the file size into the response header
                HttpContext.Current.Response.AddHeader("Content-Length", fileContent.Length.ToString());

                // Write the file into the response 
                HttpContext.Current.Response.OutputStream.Write(fileContent, 0, fileContent.Length);


                // to fix this kind of error we can use Response.IsClientConnected property to check whether client is connected or not and then we can flush and end response from client.

                if (Response.IsClientConnected)
                {

                    HttpContext.Current.Response.Flush();

                    //End the response
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    HttpContext.Current.Response.End();
                }

            }
            catch (ThreadAbortException ex1)
            {
                //Do nothing
                string msgExc = ex1.Message;
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }

        }

        /// <summary>
        /// Funzione utile a ricavare il content-type dei file che si sta cercando di scaricare
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        protected string getFileContentType(string filename)
        {
            int dotPosition = filename.LastIndexOf(".");
            string fileExtension = filename.Substring(dotPosition + 1, filename.Length - dotPosition - 1);
            string returnValue = string.Empty;

            try
            {
                switch (fileExtension)
                {

                    case "eml":
                        returnValue = "application/force-download";
                        break;


                    case "mht":
                        returnValue = "application/force-download";
                        break;

                    case "msg":
                        returnValue = "application/vnd.ms-outlook";
                        break;

                    case "zip":
                        returnValue = "application/x-zip-compressed";
                        break;

                    case "xlsx":
                    case "xls":
                        returnValue = "application/ms-excel";
                        break;

                    case "pdf":
                        returnValue = "application/pdf";
                        break;

                    case "ppt":
                    case "pptx":
                        returnValue = "application/vnd.ms-powerpoint";
                        break;

                    case "doc":
                    case "docx":
                        returnValue = "application/ms-word";
                        break;

                    case "png":
                        returnValue = "image/png";
                        break;

                    case "jpg":
                        returnValue = "image/jpg";
                        break;

                    case "txt":
                        returnValue = "text/plain";
                        break;          
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

    #region AJAX

    [System.Web.Services.WebMethod]
    //public void wsLogout(int ute_id_utente)
    public static string wsLogout()
    {
        try
        {
            SessioniUtenti objSessioniUtenti = new SessioniUtenti();
            Audit objAudit = new Audit();
            objAudit.Ute_id_utente = Convert.ToInt32(HttpContext.Current.Session["UTE_ID_UTENTE"]);
            objAudit.TraceAction("Logout");

            //objUtente.Ute_id_utente = ute_id_utente;
            //objUtente.Login_Logout("Logout");
            Lock objLock = new Lock();        
            //Int32 id_utente = Convert.ToInt32(HttpContext.Current.Session["UTE_ID_UTENTE"]);
            //objLock.Ute_id_utente = id_utente;

            //SVA(07102011):In caso di LogOut elimino dalla tabella dei lock tutti i lock della sessione corrente
            objLock.Lck_id_sessione = SqlGuid.Parse(HttpContext.Current.Session["SESSIONID"].ToString());
            objLock.Delete();

            //SVA(07102011):In caso di LogOut elimino dalla tabella delle sessioni attiva la sessione corrente
            objSessioniUtenti.Ssu_id_sessione = SqlGuid.Parse(HttpContext.Current.Session["SESSIONID"].ToString());
            objSessioniUtenti.Delete();
            HttpContext.Current.Session.Abandon();            

            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    [System.Web.Services.WebMethod]
    public static string moveNode(int destNodeDataKey, int sourceNodeDataKey)
    {
        // Aggiorna, sul nodo spostato, l'ID Padre (si mette il nuovo padre)
        // e il livello (LivelloPadre+1)
        try
        {
            //Leggo i dati del Padre
            Funzionalita objFntPadre = new Funzionalita();
            objFntPadre.Fnt_id_funzionalita = destNodeDataKey;
            objFntPadre.Read();

            //Leggo i dati del Figlio
            Funzionalita objFntFiglio = new Funzionalita();
            objFntFiglio.Fnt_id_funzionalita = sourceNodeDataKey;
            objFntFiglio.Read();

            int oldLevel = (int)objFntFiglio.Fnt_livello;

            //Aggiorno il Figlio
            Funzionalita objUpdFntFiglio = new Funzionalita();
            objUpdFntFiglio.Fnt_id_funzionalita = sourceNodeDataKey;
            objUpdFntFiglio.Read();

            objUpdFntFiglio.Fun_fnt_id_funzionalita = destNodeDataKey;

            int newLevel = (int)objFntPadre.Fnt_livello + 1;
            objUpdFntFiglio.Fnt_livello = newLevel;

            objUpdFntFiglio.Update();

            objUpdFntFiglio.aggFigli(newLevel - oldLevel);

            //Non serve più la chiamata a questa procedura
            //objUpdFntFiglio.treeReorder();

            objUpdFntFiglio.Read();

            return Convert.ToString(objUpdFntFiglio.Fnt_descrizione_ita);
        }
        catch (Exception ex)
        {
            return "Errore: " + ex.Message;
        }
    }

    /// <summary>
    /// Metodo utilizzato tramite ajax che restituisce dal dizionario una stringa nella lingua corrente
    /// </summary>
    /// <param name="key">chiave del dizionario</param>
    /// <returns>valore tradotto</returns>
    [System.Web.Services.WebMethod]
    public static string getDizionarioUI(string key)
    {
        string Value;
        Dizionario objDiz = new Dizionario();
        Dictionary<string, string> dizUI;
        //Dictionary<string, string> dizPermessi = (Dictionary<string, string>)HttpContext.Current.Session["dizionarioPermessi"];

        dizUI = objDiz.GetDictionary(Convert.ToInt32(HttpContext.Current.Session["NAZ_ID_NAZIONE"]));

        if (!dizUI.TryGetValue(key, out Value))
        {
            Value = "XX" + key + "XX";
        }
        return Value;
    }

        #endregion

        /// <summary>
        /// Registrazione chiamata per adattamento dimensioni iFrame contenente un Browser.
        /// </summary>
        /// <param name="idIframe">id dell'Iframe del quale bisogna cambiare l'altezza</param>
        /// <param name="idOggetto">id dell'Oggetto del quale prendere l'altezza di ridimensionamento</param>
        protected void RegisterScriptResizeIframe(string idIframe, string idOggetto)
        {
            RegisterScriptResizeIframe(idIframe, idOggetto, 110);
        }

        /// <summary>
        /// Registrazione chiamata per adattamento dimensioni iFrame contenente un Browser.
        /// </summary>
        /// <param name="idIframe">id dell'Iframe del quale bisogna cambiare l'altezza</param>
        /// <param name="idOggetto">id dell'Oggetto del quale prendere l'altezza di ridimensionamento</param>
        /// <param name="heightToAdd">altezza in px da sommare a quella che si vuole dare all'Iframe </param>
        protected void RegisterScriptResizeIframe(string idIframe, string idOggetto, int heightToAdd)
        {
            if (!this.ClientScript.IsStartupScriptRegistered("ResizeIframe_Js"))
            {
                this.ClientScript.RegisterStartupScript(GetType(), "ResizeIframe_Js", this.ResizeIframe_Js(idIframe, idOggetto, heightToAdd));
            }
        }

        /// <summary>
        /// Per gestire le dimensioni degli iFrame, nel caso di pannelli chiusi, sono state introdotte:
        /// - resizeHeightIframeClosed(): vedi file jscript.js. Ricalcola la dimensione dell'iframe quando si clicca sul titolo del Panel.
        /// oppure
        /// - vedi document.ready in "DettaglioPolizza/frm_MSB_DTP.aspx"
        /// </summary>
        /// <param name="idIframe"></param>
        /// <param name="idOggetto"></param>
        /// <param name="heightToAdd"></param>
        /// <returns></returns>
        public string ResizeIframe_Js(string idIframe, string idOggetto, int heightToAdd)
        {
            string js = @"
                <script type='text/javascript'>
                    function resizeHeightIframe()
                    {                                          
                        var objectHeight = $('#" + idOggetto + @"').height() + " + heightToAdd + @";                        
                        $('#" + idIframe + @"',parent.document).height(objectHeight);
                    }
				</script>";
            return js;
        }
    }
}
