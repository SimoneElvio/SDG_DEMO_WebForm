#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    SDG_DEMO
// Nome File:   mainpage.aspx
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe di CodeBehind  della pagina
//
// Autore:      SE - SDG srl
// Data:        08/11/2017
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:  
// Data:     
// Motivo:   
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Web;
using SDG.GestioneUtenti.Web;
using SDG.Utility;
using SDG.GestioneUtenti;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using BusinessObjects;
using System.Globalization;
using System.Threading;

public partial class mainpage : BasePage
{
    #region Web Control Declaration

    //PAGE VARIABLES
    string ID_RICHIESTA = string.Empty;
    string CODICE_WORKFLOW = string.Empty;
    string percorso = string.Empty;
    public bool MenuVisible = true;

    protected Clienti objClienti;
    protected Sistema objSistema;
    protected string QSIS_LINK_RSS_SCIOPERI;
    protected string QSIS_LINK_RSS_NEWS;
    protected bool isMobile = false; // recuperare da login

    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.PageLoad(sender, e);

            ID_RICHIESTA = Request.QueryString["ID_RICHIESTA"];
            CODICE_WORKFLOW = Request.QueryString["CODICE_WORKFLOW"];

            message.InnerText = GetValueDizionarioUI("MESSAGE_HOME"); 
           
            if (Session["isMobile"] != null)
            {
                if (Session["isMobile"].ToString() == "1")
                {
                    isMobile = true;
                }
            }

            if (!isMobile)
            {
                footer.InnerHtml = base.renderFooter();
            }

            SetPageControlAccess();

            #region RSS

            objSistema.Read();
            QSIS_LINK_RSS_SCIOPERI = (objSistema.Sis_link_rss_scioperi.IsNull) ? (string.Empty) : (objSistema.Sis_link_rss_scioperi.Value);
            QSIS_LINK_RSS_NEWS = (objSistema.Sis_link_rss_news.IsNull) ? (string.Empty) : (objSistema.Sis_link_rss_news.Value);

            SetPageControlAccess();

            if (!IsPostBack)
            {
                LbOrigScio.InnerHtml = GetValueDizionarioUI("LB_ORIG_FEED_SCIOP");
                LbOrigNews.InnerHtml = GetValueDizionarioUI("LB_ORIG_FEED_NEWS");
                if (QSIS_LINK_RSS_SCIOPERI != string.Empty)
                {
                    BindDataRssScioperi();
                }
                else
                {
                    DivPanelScioperi.Visible = false;
                }
                if (QSIS_LINK_RSS_NEWS != string.Empty)
                {
                    BindDataRssNews();
                }
                else
                {
                    DivPanelNews.Visible = false;
                }
                BindNotaCliente();
            }

            #endregion
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }
    #endregion

    #region Access Control

    private void SetPageControlAccess()
    {
        //SetPageControlAccess("DEF");
    }
    #endregion

    #region OnInit
    protected override void OnInit(EventArgs e)
    {
        objSistema = new Sistema();
        objClienti = new Clienti();

        base.OnInit(e);
    }

    #endregion

    #region Method Ajax

    [System.Web.Services.WebMethod()]
    public static bool getDizionarioPermessiDTF()
    {
        Utilita objUtilita = new Utilita();
        Dictionary<string, int> dizionarioPermessi = (Dictionary<string, int>)HttpContext.Current.Session["dizionarioPermessi"];

        if (dizionarioPermessi.ContainsKey("DTF"))
        {
            if (dizionarioPermessi["DTF"] == objUtilita.AccessDelete)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }     
    }


    [System.Web.Services.WebMethod()]
    public static bool checkIsTickets()
    {
        bool returnValue = false;
        Sistema objIsTickets = new Sistema();        
        try
        {
            returnValue = objIsTickets.checkIsTickets();            
        }
        catch (Exception ex)
        {
            string foo = ex.Message;
        }
        return returnValue;
    }

    #endregion

    #region DataBinding

    /// <summary>
    /// Rss Scioperi
    /// </summary>
    private void BindDataRssScioperi()
    {
        try
        {
            StringBuilder strTagRssScioperi = new StringBuilder();
            DateTimeFormatInfo myDateTime = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name, false).DateTimeFormat;

            //Download xml
            WebRequest myRequest = WebRequest.Create(QSIS_LINK_RSS_SCIOPERI);
            myRequest.Timeout = 10000;
            myRequest.Credentials = CredentialCache.DefaultCredentials;
            myRequest.PreAuthenticate = true;
            WebResponse myResponse = myRequest.GetResponse();
            Stream rssStream = myResponse.GetResponseStream();
            XmlDocument rssDoc = new XmlDocument();
            XmlReader reader = XmlReader.Create(new StreamReader(rssStream, Encoding.UTF8));
            rssDoc.Load(reader);

            rssStream.Flush();
            rssStream.Close();
            myResponse.Close();

            XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");

            string title = string.Empty;
            string link = string.Empty;
            string description = string.Empty;
            //string image = string.Empty;
            string pubDate = string.Empty;

            for (int i = 0; i < rssItems.Count; i++)
            {
                XmlNode rssDetail;

                rssDetail = rssItems.Item(i).SelectSingleNode("title");
                if (rssDetail != null)
                {
                    title = Utilita.StripHTML(rssDetail.InnerText);
                }
                else
                {
                    title = string.Empty; ;
                }

                rssDetail = rssItems.Item(i).SelectSingleNode("link");
                if (rssDetail != null)
                {
                    link = rssDetail.InnerText;
                }
                else
                {
                    link = string.Empty; ;
                }

                rssDetail = rssItems.Item(i).SelectSingleNode("description");
                if (rssDetail != null)
                {
                    description = rssDetail.InnerText;// Utilita.pulisciTesto(Utilita.StripHTML(rssDetail.InnerText)); 
                    if (description.Trim() == string.Empty)
                        description = getDizionarioUI("LB_RSS_DESCR_EMPTY");
                }
                else
                {
                    description = string.Empty;
                }
                
                if (rssItems.Count == 0)
                {
                    // Non ci sono rss
                    DivPanelScioperi.Visible = false;
                }
                else
                {
                    strTagRssScioperi.Append("<a target=\"new\" href=\"" + link + "\">");
                    strTagRssScioperi.Append(title + "");
                    strTagRssScioperi.Append("</a><p>");
                    strTagRssScioperi.Append(description);
                    strTagRssScioperi.Append("</p>");

                    if (i == rssItems.Count - 1) // Sono arrivato alla fine
                    {
                        DivRssScioperi.InnerHtml = strTagRssScioperi.ToString();
                    }

                }
            }
        }
        catch (WebException ex)
        {
            if (ex.Status.ToString() != "Timeout")
            {
                // Gestione messaggistica all'utente e trace in DB dell'errore
                //ExceptionPolicy.HandleException(ex, "Propagate Policy");                
            }
            else
            {
                DivRssScioperi.InnerHtml = "<ul><li>" + GetValueDizionarioUI("MSG_ERR_RSS_TIMEOUT") + "</li></ul>";
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            //ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    /// <summary>
    /// Rss News
    /// </summary>
    private void BindDataRssNews()
    {
        try
        {
            StringBuilder strTagRssNews = new StringBuilder();

            DateTimeFormatInfo myDateTime = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name, false).DateTimeFormat;

            //Download xml
            WebRequest myRequest = WebRequest.Create(QSIS_LINK_RSS_NEWS);
            myRequest.Timeout = 2000;
            WebResponse myResponse = myRequest.GetResponse();

            Stream rssStream = myResponse.GetResponseStream();
            XmlDocument rssDoc = new XmlDocument();

            rssDoc.Load(rssStream);

            rssStream.Flush();
            rssStream.Close();
            myResponse.Close();
            XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");

            string title = string.Empty;
            string link = string.Empty;
            string description = string.Empty;
            //string image = string.Empty;
            string pubDate = string.Empty;

            for (int i = 0; i < rssItems.Count; i++)
            {
                XmlNode rssDetail;

                rssDetail = rssItems.Item(i).SelectSingleNode("title");
                if (rssDetail != null)
                {
                    title = Utilita.StripHTML(rssDetail.InnerText);
                }
                else
                {
                    title = string.Empty;
                }

                rssDetail = rssItems.Item(i).SelectSingleNode("link");
                if (rssDetail != null)
                {
                    link = rssDetail.InnerText;
                }
                else
                {
                    link = string.Empty;
                }

                rssDetail = rssItems.Item(i).SelectSingleNode("description");
                if (rssDetail != null)
                {
                    description = rssDetail.InnerText;// Utilita.pulisciTesto(Utilita.StripHTML(rssDetail.InnerText)); 
                    if (description.Trim() == string.Empty)
                        description = getDizionarioUI("LB_RSS_DESCR_EMPTY");
                }
                else
                {
                    description = string.Empty;
                }
                
                if (rssItems.Count == 0)
                {
                    // Non ci sono rss
                    DivPanelNews.Visible = false;
                }
                else
                {
                    strTagRssNews.Append("<a target=\"new\" href=\"" + link + "\">");
                    strTagRssNews.Append(title + "");
                    strTagRssNews.Append("</a><p>");
                    strTagRssNews.Append(description);
                    strTagRssNews.Append("</p>");

                    if (i == rssItems.Count - 1)//Sono arrivato alla fine
                    {
                        DivRssNews.InnerHtml = strTagRssNews.ToString();
                    }
                }
            }

        }
        catch (WebException ex)
        {
            if (ex.Status.ToString() != "Timeout")
            {
                // Gestione messaggistica all'utente e trace in DB dell'errore
                //ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
            else
            {
                DivRssNews.InnerHtml = "<ul><li>" + GetValueDizionarioUI("MSG_ERR_RSS_TIMEOUT") + "</li></ul>";
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            //ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    /// <summary>
    /// Nota da visualizzare al cliente
    /// </summary>
    private void BindNotaCliente()
    {
        try
        {
            int idCliente = Convert.ToInt32(Session["CLI_ID_CLIENTE"].ToString());
            objClienti.Read(idCliente, qCultureInfoName);
            //if (!objClienti.Cli_nota_home.IsNull && objClienti.Cli_nota_home.Value != "")
            //    pNotaCliente.InnerHtml = objClienti.Cli_nota_home.Value.Replace(Environment.NewLine, "<br />");
            //else
            //    pNotaCliente.Visible = false;
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    #endregion

}