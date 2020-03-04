using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using SDG.GestioneUtenti;
using System.Web.Security;

namespace TRF.Web.Login
{
    public partial class frm_BYP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utente objUtente = new Utente();
            
            //string userId = (Request.Form["STR_USERID"].ToString() != null)?Request.Form["STR_USERID"].ToString():"giorgio.belloni";
            //Response.Write(userId);
            string userId = Request.Form["STR_USERID"].ToString();

            if (userId.ToLower() != "admin")
            {
                objUtente.Read(" WHERE UTE_USER_ID = '" + userId.Replace("'","''") + "'");
                Session["UTE_ID_UTENTE"] = objUtente.Ute_id_utente.ToString();
                Session["UTE_COGNOME"] = objUtente.Ute_cognome.ToString();
                Session["UTE_NOME"] = objUtente.Ute_nome.ToString();
                Session["UTE_SIGLA"] = objUtente.Ute_sigla.ToString();
                Session["CLI_ID_CLIENTE"] = objUtente.Cli_id_cliente.ToString();
                Session["NAZ_ID_NAZIONE"] = 1;
                Session["CULTURE_INFO_NAME"] = "it";
                Session["RIV_ID_RICHIESTA"] = 0;

                objUtente.UltimoAccesso();

                Dictionary<string, int> dizionarioPermessi = objUtente.BuildPermissions();
                Session["dizionarioPermessi"] = dizionarioPermessi;


                //Faccio l'autenticazione senza fare il login
                FormsAuthenticationTicket authTicket = new
                    FormsAuthenticationTicket(1,			// version
                    userId,							// user name
                    DateTime.Now,							// creation
                    DateTime.Now.AddHours(10),			// Expiration
                    false,									// Persistent
                    "");									// User data

                // Now encrypt the ticket.
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                // Create a cookie and add the encrypted
                // cookie as data.
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                // Add the cookie to the outgoing cookies
                Response.Cookies.Add(authCookie);
                //Fine autenticazione                       

                Response.Redirect("../HOME/mainpage.aspx", false);
            }
        }
    }
}