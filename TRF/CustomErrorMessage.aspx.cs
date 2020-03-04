using System;
using System.Web.UI;

public partial class _CustomErrorMessage : System.Web.UI.Page 
{

    protected override void OnInit(EventArgs e)
    {
        int ErrorCode = 0;//Generic Error
        if (Request.QueryString["ErrorCode"] != null)
        {
            ErrorCode = Convert.ToInt32(Request.QueryString["ErrorCode"]);
        }

        string Error_message = string.Empty;
        if (Request.QueryString["ERROR_MESSAGE"] != null)
        {
            Error_message = Request.QueryString["ERROR_MESSAGE"];
        }

        //LabelError.InnerText = ErrorCode.ToString();


        switch (ErrorCode)
        {
            case 0://Generic Error
                LabelError.InnerHtml = DateTime.Now.ToLongDateString() + " - " + DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes + ":" + DateTime.Now.TimeOfDay.Seconds + "<br />" + Error_message; // "Generic Error. Please close and Log in.";
                Page.Title = "Generic Error";
                break;
            case 403://Unauthorized access
                LabelError.InnerText = "Unauthorized access to the resource. Please Log in.";
                Page.Title = "Access Denied";
                break;
            case 404://FileNotFound
                LabelError.InnerText = "Unauthorized access to the resource. Please Log in.";
                Page.Title = "Access Denied";
                break;
            case 500:
                LabelError.InnerHtml = "Errore generico.<br /><br />" + Error_message;
                Page.Title = "Errore generico";
                break;
        }
        
        base.OnInit(e);
    }
   
}
