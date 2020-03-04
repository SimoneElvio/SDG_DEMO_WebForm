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
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace GestioneUtenti.Web.Home
{
    public partial class CloseSession : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                Response.Redirect("../Login/frm_LGN.aspx",false);
                Response.End();
            }
            catch (Exception ex)
            {
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }

        }
    }
}
