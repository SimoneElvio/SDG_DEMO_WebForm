#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Errori.aspx
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
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Web_Common_Errors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string errorMessage = Request.QueryString["strErr"];
        string messageToDisplay = errorMessage.Replace("$", "'");
        string errorCategory = Request.QueryString["strCat"];
        if (errorMessage != null)
        {
            lbErrorMessage.InnerHtml = messageToDisplay.ToString();
        }
        if (errorCategory != null)
        {
            lbErrorCategory.InnerHtml = errorCategory.ToString();
        }
        if (!this.ClientScript.IsStartupScriptRegistered("Test_Js"))
        {
            this.ClientScript.RegisterStartupScript(GetType(), "Test_Js", this.Test_Js());
        }
    }
    protected override void OnPreRender(EventArgs e)
    {
        btn_OK.Visible = false;
        btn_OK.Attributes["onClick"] = "javascript:test();return false;";
        btn_Chiudi.Attributes["onClick"] = "javascript:self.close();";
        base.OnPreRender(e);
    }

    #region Web Form JScriptFunctions
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string Test_Js()
    {
        string js = @"
                <script type='text/javascript' >
                function test()
                { 
	               window.opener.document.form1.submit();
                }
				</script>";
        return js;
    }
    #endregion
}
