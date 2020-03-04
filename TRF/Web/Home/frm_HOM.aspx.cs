#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   frm_HOM.aspx
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
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BusinessObjects;
using System.Xml;
using System.IO;
using System.Text;
using System.Net;
using System.Globalization;
using System.Threading;
using SDG.Utility;

public partial class Web_Home_frm_HOM : BasePage
{
    #region Web Control Declaration

    //protected Sistema objSistema;
    protected Clienti objClienti;
    protected Sistema objSistema;
    
    //Page variables
    protected string QSIS_LINK_RSS_SCIOPERI;
    protected string QSIS_LINK_RSS_NEWS;
    

    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {       
        
        objSistema.Read();
        QSIS_LINK_RSS_SCIOPERI = (objSistema.Sis_link_rss_scioperi.IsNull) ? (string.Empty) : (objSistema.Sis_link_rss_scioperi.Value);
        QSIS_LINK_RSS_NEWS = (objSistema.Sis_link_rss_news.IsNull) ? (string.Empty) : (objSistema.Sis_link_rss_news.Value);
        
        SetPageControlAccess();

        if (!IsPostBack)
        {
            LabelTitolo.InnerText = GetValueDizionarioUI("NOME_APPLICAZIONE");
            spanFeedSciop.InnerText =  GetValueDizionarioUI("LB_FEED_SCIOP");
            spanFeedNews.InnerText = GetValueDizionarioUI("LB_FEED_NEWS");
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

    }
    #endregion

    #region OnInit
    protected override void OnInit(EventArgs e)
    {
        InitializeMyComponents();
        objSistema = new Sistema();
        objClienti = new Clienti();

        base.OnInit(e);
    }

    private void InitializeMyComponents()
    {
        this.PreRender += new System.EventHandler(this.frm_HOM_PreRender);
    }
    #endregion

    #region Access Control

    private void SetPageControlAccess()
    {
        SetPageControlAccess("DEF");
    }
    #endregion

    #region DataBinding

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

                //rssDetail = rssItems.Item(i).SelectSingleNode("pubDate");                
                //if (rssDetail != null)
                //{
                //    pubDate = Convert.ToDateTime(rssDetail.InnerText).ToString(myDateTime.ShortDatePattern);
                //    //pubDate = string.Empty;
                //}
                //else
                //{
                //    pubDate = string.Empty;
                //}


                //non ci sono rss
                if (rssItems.Count == 0)
                {
                    DivPanelScioperi.Visible = false;
                }
                else
                {
                    if (i == 0)//Sono al primo
                    {
                        strTagRssScioperi.Append("<ul>");
                    }

                    strTagRssScioperi.Append("<li><div class='titolo'>");
                    strTagRssScioperi.Append("<span><a target=\"new\" href=\"" + link + "\">\n");
                    strTagRssScioperi.Append(title + "</a></span></div>");

                    strTagRssScioperi.Append("<br/>");
                    strTagRssScioperi.Append("<div class='descr'><span>");
                    strTagRssScioperi.Append(description + "</span></div>");
                    strTagRssScioperi.Append("<br/><br/><br/></li>");

                    if (i == rssItems.Count - 1)//Sono arrivato alla fine
                    {
                        strTagRssScioperi.Append("</ul>");

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
                DivRssScioperi.InnerHtml = "<ul><li>"+GetValueDizionarioUI("MSG_ERR_RSS_TIMEOUT")+"</li></ul>";
            }
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }        
    }

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

                //rssDetail = rssItems.Item(i).SelectSingleNode("pubDate");
                //if (rssDetail != null)
                //{
                //    pubDate = Convert.ToDateTime(rssDetail.InnerText).ToString(myDateTime.ShortDatePattern);
                //}
                //else
                //{
                //    pubDate = string.Empty;
                //}


                //non ci sono rss
                if (rssItems.Count == 0)
                {
                    DivPanelNews.Visible = false;
                }
                else
                {
                    if (i == 0)//Sono al primo
                    {
                        strTagRssNews.Append("<ul>");
                    }

                    strTagRssNews.Append("<li><div class='titolo'>");
                    strTagRssNews.Append("<span><a target=\"new\" href=\"" + link + "\">\n");
                    strTagRssNews.Append(title + "</a></span></div>");

                    strTagRssNews.Append("<br/>");
                    strTagRssNews.Append("<div class='descr'><span>");
                    strTagRssNews.Append(description + "</span></div>");
                    strTagRssNews.Append("<br/><br/><br/></li>");

                    if (i == rssItems.Count - 1)//Sono arrivato alla fine
                    {
                        strTagRssNews.Append("</ul>");

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
                DivRssNews.InnerHtml = "<ul><li>"+GetValueDizionarioUI("MSG_ERR_RSS_TIMEOUT")+"</li></ul>";
            }
        }
        catch (Exception ex)
        {                        
            // Gestione messaggistica all'utente e trace in DB dell'errore
            //ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    private void BindNotaCliente()
    {
        try
        {
            int idCliente = Convert.ToInt32(Session["CLI_ID_CLIENTE"].ToString());
            objClienti.Read(idCliente,qCultureInfoName);
            if (!objClienti.Cli_nota_home.IsNull && objClienti.Cli_nota_home.Value != "")
                pNotaCliente.InnerHtml = objClienti.Cli_nota_home.Value.Replace(Environment.NewLine, "<br />");
            else
                pNotaCliente.Visible = false;
        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    #endregion

    #region Web Form Menu JScriptFunctions

    #endregion

    #region Web Form Event Handlers

    #endregion

    #region Web Form PreRender
    private void frm_HOM_PreRender(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            // Gestione messaggistica all'utente e trace in DB dell'errore
            ExceptionPolicy.HandleException(ex, "Propagate Policy");
        }
    }

    #endregion

}

