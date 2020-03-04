#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   AbcPrenotazioniAeree.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per ABCPRENOTAZIONIAEREE
//
// Autore:      AR - SDG srl
// Data:        09/02/2010
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using System;
using System.Web;
using System.IO;

// handler per un'intera estensione
public class ProtectedContentHandler : IHttpHandler
{
    // processa la richiesta corrente
    public void ProcessRequest(HttpContext ctx)
    {
        HttpResponse Response = ctx.Response;
        HttpRequest Request = ctx.Request;

        if (ctx.Request.FilePath.Contains("userfiles") || ctx.Request.FilePath.Contains("allegati"))
        {
            // se non è autenticato, rimando alla pagina di login
            if (!Request.IsAuthenticated)
            {
                Response.StatusCode = 401;
                Response.End();
            }
        }
        // il contenuto arriva al browser
        Response.Clear();

        int dotPosition = ctx.Request.FilePath.LastIndexOf(".");
        string fileExtension = ctx.Request.FilePath.Substring(dotPosition + 1, ctx.Request.FilePath.Length - dotPosition - 1);

        switch (fileExtension)
        {
            case "msg":
                Response.ContentType = "application/vnd.ms-outlook";
                break;

            case "zip":
                Response.ContentType = "application/x-zip-compressed";
                break;

            case "xlsx":
            case "xls":
                Response.ContentType = "application/ms-excel";
                break;

            case "pdf":
                Response.ContentType = "application/pdf";
                break;

            case "ppt":
            case "pptx":
                Response.ContentType = "application/vnd.ms-powerpoint";
                break;

            case "doc":
            case "docx":
                Response.ContentType = "application/ms-word";
                break;

            case "png":
                Response.ContentType = "image/png";
                break;

            case "jpg":
                Response.ContentType = "image/jpg";
                break;

            case "txt":
                Response.ContentType = "text/plain";
                break;           
        }
        Response.WriteFile(Request.Path);        
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

}

