<%@ Page Language="C#" ValidateRequest="false" CodeBehind="Errors.aspx.cs" Inherits="Web_Common_Errors" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Error Page</title>

    <link href="../Css/master.css" rel="stylesheet" type="text/css" />
    <link href="../Css/screen.css" rel="stylesheet" type="text/css" />
	<!--[if lt IE 7]><link href="../Css/IE6_fix.css" rel="stylesheet" type="text/css" media="screen" /> <![endif]-->
</head>
<body>
<div id="wrapError">
    <form id="form1" runat="server">

        <h1>titolo</h1>
        <label id="lbErrorCategory" runat="server"></label>
        <p id="lbErrorMessage" runat="server"></p>
        <input type="button" id="btn_OK" runat="server" value="OK" />
        <input type="button" id="btn_Chiudi" runat="server" value="Chiudi" />

    </form>
</div>
</body>
</html>
