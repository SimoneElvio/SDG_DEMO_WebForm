#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    SDG_DEMO
// Nome File:   frm_PWD.aspx
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe di CodeBehind  della pagina
//
// Autore:      SE - SDG srl
// Data:        22/11/2017
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
using System.Web.UI.WebControls;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Data.SqlTypes;

public partial class Web_Login_frm_PWD : BasePage
{
    #region Web Form Control declarations

    protected Utente objUtente;
    protected UtenteTrc objUtenteTrc;
    protected Sistema objSistema;

    protected string qSCADUTA;
    protected string oldPassword;
    string errMaxRipetizioni;

    //Validatori
    protected RequiredFieldValidator RFVOldPassword;
    protected RequiredFieldValidator RFVNewPassword;
    protected RequiredFieldValidator RFVNewPasswordConfirm;
    protected CompareValidator CVConfirm;
    protected string pagina = "";
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            qSCADUTA = Request.QueryString["SCADUTA"];
        }
        //else
        //{
        //    if (Request.QueryString["SCADUTA"] == "SI")
        //        qSCADUTA = "NO"; // ho cliccato salva
        //}
        //------------------------------------------
        //Costruzione dei controlli di validazione
        //------------------------------------------
        RFVOldPassword = new RequiredFieldValidator();
        RFVOldPassword.ErrorMessage = GetValueDizionarioUI("VECCHIA_PASSWORD") + ": " + GetValueDizionarioUI("ERR_MSG_CAMPO_OBBLIGATORIO");
        RFVNewPassword = new RequiredFieldValidator();
        RFVNewPassword.ErrorMessage = GetValueDizionarioUI("NUOVA_PASSWORD") + ": " + GetValueDizionarioUI("ERR_MSG_CAMPO_OBBLIGATORIO");
        RFVNewPasswordConfirm = new RequiredFieldValidator();
        RFVNewPasswordConfirm.ErrorMessage = GetValueDizionarioUI("NUOVA_PASSWORD_CONFERMA") + ": " + GetValueDizionarioUI("ERR_MSG_CAMPO_OBBLIGATORIO");
        
        CVConfirm = new CompareValidator();
        CVConfirm.ErrorMessage = GetValueDizionarioUI("ERR_MSG_PASSWORD_NON_UGUALI");

        LabelTitolo.InnerText = "";
        if (qSCADUTA == "SI")
        {
            LabelTitolo.InnerText = GetValueDizionarioUI("PASSWORD_SCADUTA_TITLE") + " ";
            ButtonAnnulla.Visible = false;
        }

        PasswordAlert(false);
        
        if(qSCADUTA == "NO")
        {
            LabelIstruzioni.InnerHtml = pwdAvviso;
        }
        else
            LabelIstruzioni.InnerHtml = GetValueDizionarioUI("PASSWORD_SCADUTA") + " " + pwdAvviso;

        LabelOldPassword.InnerText = GetValueDizionarioUI("VECCHIA_PASSWORD");
        LabelNewPassword.InnerText = GetValueDizionarioUI("NUOVA_PASSWORD");
        LabelNewPasswordConfirm.InnerText = GetValueDizionarioUI("NUOVA_PASSWORD_CONFERMA");
        ButtonChangePassword.Text = GetValueDizionarioUI("SALVA");
        ButtonAnnulla.InnerText = GetValueDizionarioUI("ANNULLA");
        errMaxRipetizioni = GetValueDizionarioUI("ERR_MAX_CONSECUTIVE");

        this.SetRegEx();
    }
    #endregion

    #region RE Control
    private void SetRegEx()
    {
        RFVOldPassword.ID = "OldPassword_VALIDATOR";
        RFVOldPassword.Display = ValidatorDisplay.None;
        RFVOldPassword.ControlToValidate = "InputOldPassword";

        RFVNewPassword.ID = "NewPassword_VALIDATOR";
        RFVNewPassword.Display = ValidatorDisplay.None;
        RFVNewPassword.ControlToValidate = "InputNewPassword";

        RFVNewPasswordConfirm.ID = "NewPasswordConfirm_VALIDATOR";
        RFVNewPasswordConfirm.Display = ValidatorDisplay.None;
        RFVNewPasswordConfirm.ControlToValidate = "InputNewPasswordConfirm";

        CVConfirm.ID = "CV_CONFIRM";
        CVConfirm.Type = ValidationDataType.String;
        CVConfirm.Display = ValidatorDisplay.None;
        CVConfirm.ControlToValidate = "InputNewPasswordConfirm";
        CVConfirm.ControlToCompare = "InputNewPassword";
        CVConfirm.Operator = ValidationCompareOperator.Equal;

        PlaceHolder1.Controls.Add(RFVOldPassword);
        PlaceHolder1.Controls.Add(RFVNewPassword);
        PlaceHolder1.Controls.Add(RFVNewPasswordConfirm);

        PlaceHolder1.Controls.Add(CVConfirm);
    }
    #endregion

    #region OnInit
    override protected void OnInit(EventArgs e)
    {
        InitializeMyComponents();
        objUtente = new Utente();
        objUtenteTrc = new UtenteTrc();
        objSistema = new Sistema();

        objSistema.Read();

        ButtonChangePassword.Click += ButtonChangePassword_Click;
        ButtonAnnulla.ServerClick += new EventHandler(ButtonAnnulla_Click);

        base.OnInit(e);
    }
        
    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_PWD_PreRender);
    }
    #endregion

    #region Web Form Event Handlers

    protected string strERRORE = "";

    private void ButtonChangePassword_Click(object sender, EventArgs e)
    {
        int maxPassword = 1;

        strERRORE = "";
        bool passwordVerified = false;
        bool passwordValid = false;

        try
        {
            objUtente.Ute_id_utente = Convert.ToInt32(Session["UTE_ID_UTENTE"]);
            objUtente.Read();

            if (Session["oldPassword"] == null)
            {
                oldPassword = (string)objUtente.Ute_password;
                Session["oldPassword"] = oldPassword;
            }
            else
            {
                oldPassword = Session["oldPassword"].ToString();
            }

            if (EncryptPwd(InputOldPassword.Text).CompareTo(oldPassword) == 0)
            {
                // Recupero Password
                objUtenteTrc.Ute_id_utente = Convert.ToInt32(Session["UTE_ID_UTENTE"]);
                objUtenteTrc.Ute_password = EncryptPwd(InputNewPassword.Text);

                try
                {
                    if (objSistema.Sis_max_password_consecutive != -1)
                        maxPassword = (int)objSistema.Sis_max_password_consecutive;

                    passwordVerified = objUtenteTrc.CheckPassword(maxPassword);        //objUtente-> in Utente.cs
                    errMaxRipetizioni += " " + maxPassword.ToString() + " password.";
                }
                catch (Exception ex)
                {
                    strERRORE = ex.Message;

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Propagate Policy");
                }

                //Verifica caratteri obbligatori
                passwordValid = PasswordConstraints(InputNewPassword.Text);
                if (!passwordValid)
                {
                    Base_Alert(pwdAvviso);
                }
                else if (!passwordVerified)
                    Base_Alert(errMaxRipetizioni);
                else
                {
                    try
                    {
                        objUtente.Ute_id_utente = Convert.ToInt32(Session["UTE_ID_UTENTE"]);
                        objUtente.Read();
                        objUtente.Ute_password = EncryptPwd(InputNewPassword.Text);

                        if (objSistema.Sis_durata_password != -1)
                        {
                            objUtente.Ute_expiration_date = DateTime.Now.AddMonths((int)objSistema.Sis_durata_password);
                        }
                        else
                            objUtente.Ute_expiration_date = SqlDateTime.Null;

                        objUtente.Update();

                        objUtenteTrc.Ute_id_utente = Convert.ToInt32(Session["UTE_ID_UTENTE"]);
                        objUtenteTrc.Ute_password = EncryptPwd(InputNewPassword.Text);
                        objUtenteTrc.Create();
                        
                        if (objSistema.Sis_flag_visualizza_info_page == 1)
                            pagina = "frm_LGN_2.aspx";
                        else
                            pagina = "../HOME/mainpage.aspx";

                        string js_Redirect = "alert('" + GetValueDizionarioUI("CAMBIO_PWD") + "');document.location.href='" + pagina + "';";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgRedirect", js_Redirect, true);
                    }
                    catch (Exception ex)
                    {
                        // Gestione messaggistica all'utente e trace in DB dell'errore
                        ExceptionPolicy.HandleException(ex, "Propagate Policy");
                    }
                }
            }
            else
                Base_Alert(GetValueDizionarioUI("ERR_MSG_VECCHIA_PWD_ERRATA"));
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }

    }

    protected void ButtonAnnulla_Click(object sender, EventArgs e)
    {
        try
        {
            if (objSistema.Sis_flag_visualizza_info_page == 1)
                Response.Redirect("frm_LGN_2.aspx?CAMBIOPWD=NO", false);
            else
                Response.Redirect("../HOME/mainpage.aspx", false);            
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    #endregion

    #region Functions

    /// <summary>
    /// Verifica caratteri obbligatori
    /// In base ai settaggi nella tabella Sistema, viene verificata la consistenza di una password
    /// SIS_FLAG_PWD_MAIUSCOLE: La password deve contenere obbligatoriamente LETTERE MAIUSCOLE (default 0: no)
    /// SIS_FLAG_PWD_MINUSCOLE: La password deve contenere obbligatoriamente LETTERE MINUSCOLE (default 0: no)
    /// SIS_FLAG_PWD_NUMERI: La password deve contenere obbligatoriamente CARATTERI NUMERICI (default 0: no)
    /// SIS_FLAG_PWD_CARATTERI_SPECIALI: La password deve contenere obbligatoriamente CARATTERI SPECIALI (stampabili) (default 0: no)
    /// SIS_PWD_SET_CARATTERI_SPECIALI: Elenco di tutti i caratteri speciali ammissibili (si considera solo se SIS_FLAG_PWD_CARATTERI_SPECIALI=si)
    /// </summary>
    /// <param name="ThePassword"></param>
    /// <returns></returns>
    public bool PasswordConstraints(string ThePassword)
    {
        PasswordAlert(true);

        int mskValues = 0;
        int mskFound = 0;

        bool pwdOK = false;

        if (objSistema.Sis_flag_pwd_minuscole.Value == 1)
            mskValues |= 1;
        if (objSistema.Sis_flag_pwd_maiuscole.Value == 1)
            mskValues |= 2;
        if (objSistema.Sis_flag_pwd_numeri.Value == 1)
            mskValues |= 4;
        if (objSistema.Sis_flag_pwd_caratteri_speciali.Value == 1)
            mskValues |= 8;
        if (objSistema.Sis_min_password_length.Value != -1)
            mskValues |= 16;
        if (objSistema.Sis_max_password_length.Value != -1)
            mskValues |= 32;

        foreach (char ch in ThePassword)
        {
            if (objSistema.Sis_flag_pwd_minuscole.Value == 1 && Char.IsLower(ch))
                mskFound |= 1;
            if (objSistema.Sis_flag_pwd_maiuscole.Value == 1 && Char.IsUpper(ch))
                mskFound |= 2;
            if (objSistema.Sis_flag_pwd_numeri.Value == 1 && Char.IsDigit(ch))
                mskFound |= 4;
            if (objSistema.Sis_flag_pwd_caratteri_speciali.Value == 1 && objSistema.Sis_pwd_set_caratteri_speciali.Value.Contains(ch.ToString()))
                mskFound |= 8;
            if (objSistema.Sis_min_password_length.Value != -1 && ThePassword.Length >= objSistema.Sis_min_password_length)
                mskFound |= 16;
            if (objSistema.Sis_max_password_length.Value != -1 && ThePassword.Length <= objSistema.Sis_max_password_length)
                mskFound |= 32;
        }

        pwdOK = (mskValues == mskFound);

        if (pwdOK)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isAlert">TRUE: gli a-capo devono essere nel formato Javascript; FALSE: gli a-capo devono essere nel formato HTML</param>
    public void PasswordAlert(bool isAlert)
    {
        string aCapo = string.Empty;
        string locAvviso = "";
        if (isAlert)
            aCapo = "\\n";
        else
            aCapo = "<br />";

        pwdAvviso = "";

        if (objSistema.Sis_flag_pwd_minuscole.Value == 1)
            locAvviso = locAvviso + GetValueDizionarioUI("ERR_MSG_PWD_BASE_MINUS");
        if (objSistema.Sis_flag_pwd_maiuscole.Value == 1)
            locAvviso = locAvviso + GetValueDizionarioUI("ERR_MSG_PWD_BASE_MAIUS");
        if (objSistema.Sis_flag_pwd_numeri.Value == 1)
            locAvviso = locAvviso + GetValueDizionarioUI("ERR_MSG_PWD_BASE_NUMB");
        if (objSistema.Sis_flag_pwd_caratteri_speciali.Value == 1)
        {
            locAvviso = locAvviso + GetValueDizionarioUI("ERR_MSG_PWD_BASE_SPEC");
            if (objSistema.Sis_pwd_set_caratteri_speciali.Value.Length > 0)
            {
                locAvviso = locAvviso.Substring(0, locAvviso.Length - 1);
                locAvviso = locAvviso + ": " + objSistema.Sis_pwd_set_caratteri_speciali.Value;
                locAvviso = locAvviso + ",";
            }
        }

        if (locAvviso.EndsWith(","))
            locAvviso = locAvviso.Substring(0, locAvviso.Length - 1) + " .";

        if (locAvviso.Length != 0)
            pwdAvviso = GetValueDizionarioUI("ERR_MSG_PWD_BASE") + locAvviso;

        if (objSistema.Sis_min_password_length.Value != -1)
            pwdAvviso = pwdAvviso + aCapo + GetValueDizionarioUI("ERR_MSG_PWD_MIN_LEN") + objSistema.Sis_min_password_length.Value.ToString();
        if (objSistema.Sis_max_password_length.Value != -1)
            pwdAvviso = pwdAvviso + aCapo + GetValueDizionarioUI("ERR_MSG_PWD_MAX_LEN") + objSistema.Sis_max_password_length.Value.ToString();
    }

    #endregion

    #region Web Form PreRender
    private void frm_PWD_PreRender(object sender, EventArgs e)
    {
        try
        {            
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion

}
