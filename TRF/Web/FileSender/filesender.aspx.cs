using System;
using System.IO;
using System.Text;
using System.Web;
using SDG.GestioneUtenti.Web;

public partial class Web_RichiestaViaggio_filesender : BasePage
	{
        protected void Page_Load(object sender, System.EventArgs e)
		{
            if (Request.QueryString["FILENAME"] != null)
            {
                string filename = Request.QueryString["FILENAME"];
                StringBuilder sb = new StringBuilder(500);
                if (Request.QueryString["DIR"] != null)
                {
                    sb.Append("/Web/" + Request.QueryString["DIR"].ToString() + "/FileExported/");
                }
                else
                {
                    sb.Append("/Web/RichiestaViaggio/FileExported/");
                }
                sb.Append(filename);
                
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment; filename=" + filename);
                Response.TransmitFile(Server.MapPath(sb.ToString()));
                Response.End();
            }
		}
        
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Page.Load += new EventHandler(Page_Load);
            
		}
		
		#endregion

		
    }	
	

