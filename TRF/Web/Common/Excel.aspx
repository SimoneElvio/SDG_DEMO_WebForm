<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Excel.aspx.cs" Inherits="GestioneUtenti.Web.Common.Excel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	
    <title runat="server" id="PageTitle"></title>

	<script type="text/javascript">
		$(document).ready(function() {
		    //alert(top.frames['frameContent'].document.form1.hWhereClause.value);
		    $('#hCallerWhereClause').val(top.frames['frameContent'].document.form1.hWhereClause.value);
		});
    </script>
</head>

<body runat="server">

<div id="wrap">
    <div id="page_height">
    
        <form id="form1" runat="server">
        
        <input id="hCallerWhereClause" type="hidden" runat="server" />
        
            <div id="content" runat="server">
            
                <asp:PlaceHolder ID="phMessage" runat="server"></asp:PlaceHolder>

                <div id="headerBrowser">
                    <h1 runat="server" id="LabelTitolo"></h1>
                    <div id="intestazioneBrowser" runat="server">
                        <div id="toolbar" runat="server"></div>
                    </div>
                </div>

                <asp:CheckBoxList runat="server" ID="chkFields" 
                DataTextField="Column_name" DataValueField="Column_value" 
                CellPadding="5" CellSpacing="5" RepeatColumns="3" 
                RepeatDirection="Vertical" RepeatLayout="Table" />
                
            </div>
        
        </form>
    
    </div>
</div>

</body>
</html>