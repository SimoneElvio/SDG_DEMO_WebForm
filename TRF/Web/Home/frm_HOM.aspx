<%@ Page Language="C#" CodeBehind="frm_HOM.aspx.cs" Inherits="Web_Home_frm_HOM" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="../Common/Top.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Menu" Src="../Common/Menu.ascx" %>
<%@ Register TagPrefix="uc3" TagName="Footer" Src="../Common/Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Home Page</title>

    <meta name="author" content="SDG Italy S.r.l. www.sdgitaly.it" />
    <meta http-equiv="Content-type" content="text/html;charset=utf-8" />    
    <meta name="reply-to" content="info&#064;sdgitaly.it" />
    <meta name="keywords" content="[insert keyword for search engine]" />
    <meta name="description" content="[insert description for search engine]" />
    <meta name="copyright" content="TAF - SDG Italy &copy;" />
    <meta http-equiv="Content-Language" content="it" />
    <meta http-equiv="Content-Script-Type" content="text/javascript" />
    <meta http-equiv="Content-Style-Type" content="text/css" />

    <link href="../Css/master.css" rel="stylesheet" type="text/css" />
    <link href="../Css/screen.css" rel="stylesheet" type="text/css" />

    <!--[if lt IE 7]><link href="../Css/IE6_fix.css" rel="stylesheet" type="text/css" media="screen" /> <![endif]-->
   
    <style type="text/css">
        p {font-size:14px;background:#CDE0FD;border-bottom:2px solid #758FBE;border-top:2px solid #758FBE;color:#44608C;font-style:oblique;padding:10px;}    
    </style>
</head>
    <body>
    <div id="wrap">
    <div id="page_height">
        <form id="form1" runat="server">



            <div id="content" runat="server">
            
                <h1 id="LabelTitolo" runat="server">SDG_DEMO</h1>
                <br class="clear" />
                <p id="pNotaCliente" runat="server"></p>
                <br />                
                <div id="DivPanelScioperi" runat="server">                
                    <img src="../Images/rss.gif" alt="rss"  style="margin-right:5px;" /><span id="spanFeedSciop" runat="server" ></span><br/>
                    <div id="DivRssScioperi" class="newsticker-jcarousellite" runat="server" >
                    </div>                
                    <small id="LbOrigScio" runat="server">Dati reperiti dal <a href="http://scioperi.mit.gov.it/mit2/public/scioperi/rss" target="_blank">Ministero dei Trasporti</a></small><br/>                             
                    <br /><br />
                </div> 
                <div id="DivPanelNews" runat="server">       
                    <img src="../Images/rss.gif" alt="rss" style="margin-right:5px;" /><span id="spanFeedNews" runat="server"></span><br/>
                    <div id="DivRssNews" class="newsticker-jcarousellite" runat="server" >
                    </div>                
                    <small id="LbOrigNews" runat="server">Dati reperiti dal <a href="http://www.trasporti.gov.it/" target="_blank">Ministero dei Trasporti</a></small><br/>                             
                </div>
            </div>

        </form>
   </div>
</div>


</body>
</html>
