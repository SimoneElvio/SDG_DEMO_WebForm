using System;

namespace GestioneUtenti
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "Web/Login/frm_LGN.aspx";
            Response.Redirect(url, false);
        }
    }
}
