using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using SDG.GestioneUtenti;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.IO.Compression;


namespace GestioneUtenti
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }


        protected void Application_Error(Object sender, EventArgs e)
        {
            
            string ErrorMessage = Server.GetLastError().GetBaseException().Message;
            string StackTrace = "";
            StackTrace = Server.GetLastError().GetBaseException().StackTrace.Replace("\r\n", "");
            Server.ClearError();
            string path = "/CustomErrorMessage.aspx?ERROR_MESSAGE=" + ErrorMessage + "&STACK_TRACE=" + StackTrace;
            Response.Redirect(path, true);
           
        }

        protected void Global_Error(Object sender, EventArgs e)
        {
            
            string ErrorMessage = Server.GetLastError().GetBaseException().Message;
            string StackTrace = "";
            StackTrace = Server.GetLastError().GetBaseException().StackTrace.Replace("\r\n", "");
            Server.ClearError();
            string path = "/CustomErrorMessage.aspx?ERROR_MESSAGE=" + ErrorMessage + "&STACK_TRACE=" + StackTrace;
            Response.Redirect(path, false);
            
        }

      

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("it-IT");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }



        
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["SESSIONID"] = Guid.NewGuid();
        }


        protected void Session_End(object sender, EventArgs e)
        {
            Audit objAudit = new Audit();
            Utente objUtente = new Utente();

            objAudit.Ute_id_utente = Convert.ToInt32(Session["UTE_ID_UTENTE"]);
            objAudit.Aud_ip_address = Convert.ToString(Session["IP_ADDRESS"]);
            objAudit.TraceAction("Logout");

            objUtente.Ute_id_utente = Convert.ToInt32(Session["UTE_ID_UTENTE"]);
            objUtente.Login_Logout("Logout");

            Session.Contents.RemoveAll();

            Session["CLOSING"] = "SI";
        }


        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null && System.Configuration.ConfigurationManager.AppSettings.Get("CompressAspx") == "true" && app.Context.CurrentHandler.ToString().ToLower().IndexOf("webformtestwscwt") <= 0)
            {
                string acceptEncoding = app.Request.Headers["Accept-Encoding"];

                if ((app.Context.CurrentHandler != null && !(app.Context.CurrentHandler is System.Web.UI.Page ||
                    app.Context.CurrentHandler.GetType().Name == "SyncSessionlessHandler")) ||
                    app.Request["HTTP_X_MICROSOFTAJAX"] != null)
                    return;
                if (app.Request.Headers["Content-Type"] == "application/x-www-form-urlencoded")
                    return;

                if (acceptEncoding == null || acceptEncoding.Length == 0)
                    return;

                acceptEncoding = acceptEncoding.ToLower();

                if (acceptEncoding.Contains("deflate") || acceptEncoding == "*")
                {
                    // defalte
                    app.Response.Filter = new DeflateStream(app.Response.Filter,
                        CompressionMode.Compress);
                    app.Response.AppendHeader("Content-Encoding", "deflate");
                }
                else if (acceptEncoding.Contains("gzip"))
                {
                    // gzip
                    app.Response.Filter = new GZipStream(app.Response.Filter,
                        CompressionMode.Compress);
                    app.Response.AppendHeader("Content-Encoding", "gzip");
                }
            }
        }

    }
}