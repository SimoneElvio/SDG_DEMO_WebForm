<%@ Page Language="C#" CodeBehind="frm_LGN_2.aspx.cs" Inherits="Web_Login_frm_LGN_2" %>
<?xml version="1.0" encoding="iso-8859-1" ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="it">
<head runat="server">
    <title>Info Login</title>

    <meta name="author" content="SDG Italy S.r.l. www.sdgitaly.it" />
    <meta http-equiv="Content-type" content="text/html;charset=utf-8" />
    <meta name="author" content="SDG Italy S.r.l. www.sdgitaly.it" />
    <meta name="reply-to" content="info&#064;sdgitaly.it" />
    <meta name="keywords" content="[insert keyword for search engine]" />
    <meta name="description" content="[insert description for search engine]" />
    <meta name="copyright" content="CMS - SDG Italy &copy;" />
    <meta http-equiv="Content-Language" content="it" />
    <meta http-equiv="Content-Script-Type" content="text/javascript" />
    <meta http-equiv="Content-Style-Type" content="text/css" />

    <link href="../../Web/Css/master.css" rel="stylesheet" type="text/css" />
    <link href="../../Web/Css/login_change_pwd.css" rel="stylesheet" type="text/css" />

    <!--[if lt IE 7]><link href="../../Web/Css/login_fixIE6.css" rel="stylesheet" type="text/css" media="screen" /> <![endif]-->  
    <script type="text/javascript">
        //window.onload=function(){DimScreen(1024,765);};
    </script>
</head>
<body>
<!--[if lt IE 5.5]><p>Please upgrade to Internet Explorer version 6 or greater.</p><![endif]-->
    <div id="wrap">
        <h1>TAF</h1>
        <div id="loginInfoPage">
	        <form id="form1" runat="server">
	            <h2>gestione utenti</h2>
	            <label id="LabelBenvenuto" runat="server"></label>
		        			
		        <asp:button id="ButtonProsegui" runat="server" Text="prosegui" ToolTip="prosegui" CssClass="buttonSubmit" OnClick="ButtonLogin_Click" TabIndex="100"></asp:button>
		        <asp:button id="ButtonCambiaPassword" runat="server" Text="cambia password" ToolTip="cambia password" CssClass="buttonSubmit" OnClick="ButtonCambiaPassword_Click" TabIndex="110"></asp:button>
		        
                <%--<p><asp:Label ID="LabelNoUtente" runat="server" ></asp:Label><a id="AnchorLogin" href="frm_LGN.aspx" runat="server"></a>.</p>--%>
	        </form>
        </div>
    </div>
</body>
</html>
