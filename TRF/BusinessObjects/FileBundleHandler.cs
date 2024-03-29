﻿using System;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;
using Microsoft.Ajax.Utilities;

/// <summary>
/// Summary description for JavaScriptBundleHandler
/// </summary>
public class FileBundleHandler : IHttpHandler
{

	private static readonly Regex version = new Regex("(v_[0-9]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
	private static readonly StringDictionary allowedFileTypes = new StringDictionary()
	{
		{".js", "text/javascript"},
		{".css", "text/css"}
	};

	public bool IsReusable
	{
		get
		{
			return false;
		}
	}

	public void ProcessRequest(HttpContext context)
	{
		string extension = Path.GetExtension(context.Request.PhysicalPath).ToLowerInvariant();

		if (!allowedFileTypes.ContainsKey(extension))
		{
			throw new HttpException(403, "File type not supported");
		}

		string path = version.Replace(context.Request.PhysicalPath, string.Empty);
        FileInfo[] files = BundleHelper.FindFiles(path);
		string content = ReadContent(files);
        string result = content;
#if !DEBUG
        //Se il path che sto esaminando è sotto la cartella di fckEditor, non applico la compressione, in quanto
        //introduce alcuni errori javascript.
        if (!path.Contains("ckeditor") && !path.Contains("ckfinder"))
        {
            if (ConfigurationManager.AppSettings.Get("MinifyCssJs") == "true")
            {
                result = Minify(content, extension);
            }
            if (ConfigurationManager.AppSettings.Get("CompressCssJs") == "true" && context.Request.Headers["Accept-encoding"] != null)
            {
                if (context.Request.Headers["Accept-encoding"].ToLower().Contains("deflate"))
                {
                    context.Response.Filter = new DeflateStream(context.Response.Filter, CompressionMode.Compress, true);
                    context.Response.AppendHeader("Content-encoding", "deflate");
                }
                else if (context.Request.Headers["Accept-encoding"].ToLower().Contains("gzip"))
                {
                    context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress, true);
                    context.Response.AppendHeader("Content-encoding", "gzip");
                }
            }
        }
#endif       
        context.Response.Write(result);
        SetHeaders(context, files, allowedFileTypes[extension]);
	}

	private string ReadContent(FileInfo[] files)
	{
		StringBuilder sb = new StringBuilder(1024);
		Array.ForEach(files, f => sb.AppendLine(File.ReadAllText(f.FullName)));
		return sb.ToString();
	}

	private static string Minify(string content, string extension)
	{
		if (extension == ".js")
		{
			CodeSettings settings = new CodeSettings();
			settings.MinifyCode = true;
			settings.LocalRenaming = LocalRenaming.CrunchAll;
			settings.RemoveFunctionExpressionNames = true;
			settings.EvalTreatment = EvalTreatment.MakeAllSafe;
            Minifier cruncher = new Minifier();
			return cruncher.MinifyJavaScript(content, settings);
		}
		else if (extension == ".css")
		{
			Minifier cruncher = new Minifier();
			return cruncher.MinifyStyleSheet(content);
		}

		return content;
	}
    
	private void SetHeaders(HttpContext context, FileInfo[] files, string mimeType)
	{
		DateTime lastModified = files.Max(f => f.LastWriteTime);
        context.Response.AddFileDependencies(files.Select(f => f.FullName).ToArray());
		context.Response.ContentType = mimeType;
        context.Response.Cache.SetLastModified(lastModified);
		context.Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
		context.Response.Cache.SetExpires(DateTime.Now.AddYears(1));
		context.Response.Cache.SetOmitVaryStar(true);
		context.Response.Cache.SetValidUntilExpires(true);
	}
}

public static class BundleHelper
{
	internal static FileInfo[] FindFiles(string absoluteFileName)
	{
		// Is file
		if (File.Exists(absoluteFileName))
		{
			return new[] { new FileInfo(absoluteFileName) };
		}

		// Is directory
		string dir = absoluteFileName.Replace(Path.GetExtension(absoluteFileName), string.Empty);
		return new DirectoryInfo(dir).GetFiles("*" + Path.GetExtension(absoluteFileName));
	}

	public static string InsertFile(string relativePath)
	{
		if (HttpContext.Current.Cache[relativePath] == null)
		{
            if (!relativePath.StartsWith("/", StringComparison.Ordinal) && !relativePath.StartsWith("~", StringComparison.Ordinal) && !relativePath.StartsWith("..", StringComparison.Ordinal))
            {
                relativePath = "/" + relativePath;
            }
			//string absolutePath = HostingEnvironment.MapPath(relativePath);
            string absolutePath = HttpContext.Current.Server.MapPath(relativePath);
			FileInfo[] files = FindFiles(absolutePath);
			DateTime lastModified = files.Max(f => f.LastWriteTime);

			int index = relativePath.LastIndexOf('/') + 1;
			string newPath = relativePath.Insert(index, "v_" + lastModified.Ticks + "/");
			string dependency = files.Length > 1 ? files[0].DirectoryName : files[0].FullName;
			HttpContext.Current.Cache.Insert(relativePath, newPath, new CacheDependency(dependency));
		}

		return (string)HttpContext.Current.Cache[relativePath];
	}
}