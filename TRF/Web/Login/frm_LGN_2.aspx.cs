#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   frm_LGN_2.aspx
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe di CodeBehind  della pagina
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

using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Web_Login_frm_LGN_2 : BasePage
{
    
    protected Utente objUtente;
    protected Audit objAudit;
    protected Sistema objSistema;

    protected int qUTE_ID_UTENTE;
    protected string qCAMBIAPWD;
    
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UTE_ID_UTENTE"] != null)
        {
            qUTE_ID_UTENTE = Convert.ToInt32(Session["UTE_ID_UTENTE"]);
        }
        if (qUTE_ID_UTENTE <= 0)
        {
            Response.Redirect("../LOGIN/frm_LGN.aspx",false);
        }

        qCAMBIAPWD = Request.QueryString["CAMBIOPWD"];
                      
        objUtente.Ute_id_utente = qUTE_ID_UTENTE;
        objUtente.Read();
        
        StringBuilder sb = new StringBuilder(100);
        sb.Append(GetValueDizionarioUI("BUONGIORNO"));
        sb.Append(" ");
        sb.Append(objUtente.Ute_nome.Value);
        sb.Append(" ");
        sb.Append(objUtente.Ute_cognome.Value);
        sb.Append(".<br /><br /><br />");
        if (!objUtente.Ute_session_id.IsNull && qCAMBIAPWD == "")
        {
            sb.Append(GetValueDizionarioUI("MSG_SESSIONE_ATTIVA"));
            sb.Append("<br /><br />");
        }
        if (!objUtente.Ute_ultimo_accesso.IsNull)
        {
            sb.Append(GetValueDizionarioUI("MSG_ULT_ACCESSO"));
            sb.Append(" ");
            sb.Append(objUtente.Ute_ultimo_accesso.Value);
            sb.Append(".<br />");
        }
        if (qCAMBIAPWD == "SI")
        {
            sb.Append("La password è stata cambiata con successo");
            sb.Append(".<br />");
        }

        LabelBenvenuto.InnerHtml = sb.ToString();

        if (objSistema.Sis_flag_pwd_cambia != 1)
            ButtonCambiaPassword.Visible = false;

        //Ogni login è l'ultimo Accesso Utente
        objUtente.UltimoAccesso();
        objUtente.Login_Logout("Login");

        //sb = new StringBuilder(100);

        //sb.Append(GetValueDizionarioUI("NON_SEI"));
        //sb.Append(" ");
        //sb.Append(objUtente.Ute_nome.Value);
        //sb.Append(" ");
        //sb.Append(objUtente.Ute_cognome.Value);
        //sb.Append("? ");
        //LabelNoUtente.Text = sb.ToString();

        //AnchorLogin.InnerHtml = GetValueDizionarioUI("CLICCA_QUI");
    }
    #endregion

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();

        objUtente = new Utente();
        objAudit = new Audit();

        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {        
        //this.PreRender += new System.EventHandler(this.frm_MSB_PreRender);
    }
    #endregion

    #region Web Form Event Handlers   

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        try
        {
            //AR Sbagliato. Ha già tracciato in LGN!
            //objAudit.Ute_id_utente = objUtente.Ute_id_utente;
            //objAudit.TraceAction("Login");
            //Ogni login è l'ultimo Accesso Utente
            objUtente.UltimoAccesso();

            Response.Redirect("../HOME/mainpage.aspx", false);

        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }


    protected void ButtonCambiaPassword_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("../LOGIN/frm_PWD.aspx?SCADUTA=NO", false);
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }


    #endregion

}
