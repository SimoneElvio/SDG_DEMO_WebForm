<%@ Page Language="C#" CodeBehind="frm_MSB_UTE_PWD.aspx.cs" Inherits="Web_Utenti_frm_MSB_UTE_PWD" AutoEventWireup="True" %>
<%@ Register TagPrefix="MyAsp" Namespace="MyGridViewLibrary" Assembly="SDG" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="MyLinkButton" Namespace="skmExtendedControls" Assembly="SDG" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server"> 
    <title>Browser Standard</title> 

    <%--<script language="JavaScript" type="text/javascript" id="JSession" src="../Jscript/session.js"></script>--%>
	<!--[if lt IE 7]><link href="../Css/IE6_fix.css" rel="stylesheet" type="text/css" media="screen" /> <![endif]-->
    	
	<script type="text/javascript">
	     function SetCheckCount(IdElement, idRow) {
	         var num = Number(document.getElementById("TextCountSel").value);
	         var valRow = document.getElementById(IdElement).checked;
	         var valHidden = "val_" + idRow + ";";
	         if (valRow == true) {
	             document.getElementById("TextCountSel").value = (Number(num) + 1);
	             document.getElementById("fieldSelected").value += valHidden;
	         }
	         else {
	             document.getElementById("TextCountSel").value = (Number(num) - 1);
	             var fieldSel = document.getElementById("fieldSelected").value;
	             if (fieldSel.indexOf(valHidden) >= 0) {
	                 fieldSel = fieldSel.replace(valHidden, "");
	                 document.getElementById("fieldSelected").value = fieldSel;
	             }
	         }
	     }
        
	     function ConfirmResetPwd() {
	         var num = Number(document.getElementById("TextCountSel").value);
	         //alert(num);
	         if (num == 0) {
	             alert("Attenzione non ci sono utenti selezionati.");
	             return false;
	         }
	         else {
	             if (confirm("Confermi il reset e re-invio delle password per gli utenti selezionati?\nGli utenti selezionati sono: " + num)) {
	                 return true;
	             }
	             else {
	                 return false;
	             }
	         }

	         return false;
	     }	                
    </script>

    <style type="text/css">                
        #boxField label {width:100px;}        
        #boxField {margin-top:0; width:250px}        
        #boxField2 {width:270px; border-left:1px dotted #ccc; border-right:1px dotted #ccc; margin-top:0;}        
        #TextCountSel {width:50px;margin-top:-1px;margin-left:2px;float:left; border:0; font-weight:bold}
        #ButtonInviaResetPwd {background:url(/Web/Images/bkg_button.gif) repeat-x; margin-top:-5px; margin-left:2px; border:0; height:20px}
    </style>

</head>
<body runat="server">
<div id="wrap">
    <div id="page_height">

    <form id="form1" runat="server">

        <cc1:ToolkitScriptManager ID="CustomScriptManager" runat="server" EnablePartialRendering="true" EnablePageMethods="true" LoadScriptsBeforeUI="True" CombineScripts="True"></cc1:ToolkitScriptManager>        
        
        <div id="content" runat="server">
            <input id="EffettuaRefresh" type="hidden" runat="server" />
            <input id="hPanelToRefresh" type="hidden" runat="server" />            
            <input id="hWhereClause" type="hidden" runat="server" />
            <input id="fieldSelected" type="hidden" runat="server" value="" />
            
                <div id="headerBrowser">
              
                    <h1 runat="server" id="LabelTitolo"></h1>
                    
                    <asp:DropDownList id="DropDownListRecordPagina" runat="server" />
                    <label id="LabelRecPagina" runat="server" for="DropDownListRecordPagina"></label>
                    <label runat="server" id="LabelNroRecord"></label>
                    
                    <div id="intestazioneBrowser" runat="server"> 
                        <span id="spanButton">
                            <asp:Button ID="ButtonFiltroUtente" runat="server" Text="Filtro" Visible="false" />                        
                            <asp:Button ID="ButtonExportUtenti" runat="server" Text="Export" CssClass="btnBrowser" />
                            <img id="imgViewSearch" src="../Images/search.gif" onclick="viewHideSearch()" alt="Visualizza Ricerca Avanzata" />
                        </span>
                    </div>
 
                </div>
 
                <div id="boxRicercaAvanzata" runat="server">
                    <div id="boxField">
                        <label id="LabelCognome" runat="server"></label><input type="text" id="txtCognome" name="txtCognome" runat="server" /><br />
                        <label id="LabelNome" runat="server"></label><input type="text" id="txtNome" name="txtNome" runat="server" /><br />
                        <label id="LabelCDC" runat="server"></label><input type="text" id="txtCDC" name="txtCDC" runat="server" /><br />
                        <label id="LabelPwdInviata" runat="server"></label><asp:DropDownList id="txtPwdInviata" runat="server"></asp:DropDownList>
                        
                    </div>
                    <div id="boxField2">
                        <label id="LabelCodiceIndividuale" runat="server"></label><input type="text" id="txtCodiceIndividuale" name="txtCodiceIndividuale" runat="server" /><br />
                        <label id="LabelEmail" runat="server"></label><input type="text" id="txtEmail" name="txtEmail" runat="server" /><br />
                        <label id="LabelOnline" runat="server"></label><input type="checkbox" id="chkOnline" runat="server" /><br />
                        <label id="LabelUserId" runat="server"></label><input type="text" id="txtUserId" name="txtUserId" runat="server" /><br />
                        <label id="LabelCliente" runat="server"></label><asp:DropDownList id="txtCliente" runat="server"></asp:DropDownList>
                    </div>                    
                    <asp:Button ToolTip="Cerca" id="btnCerca" runat="server" onClick="ButtonCerca_Click" OnClientClick="javascript://top.displayLoading(1);"></asp:Button>
                </div>

                <div>                    
                    <label ID="LabelElemSel" runat="server" style="font-size:0.9em;float:left;" ></label>                                
                    <input type="text" runat="server" id="TextCountSel" value="0" readonly="readonly" />
                    <asp:Button ID="ButtonInviaResetPwd" runat="server" Text="Reset/Invia Password" OnClick="ButtonInviaResetPwd_Click" OnClientClick="javascript:if(ConfirmResetPwd()){return true;}else{return false;}" />
                </div>
                                        
                <MyAsp:MyGridView ID="GridViewUtenti" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CssClass="tableBrowser" ColorMouseOverRow="" >
                    <Columns>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="ButtonEditUtenti" CssClass="buttonRowBrowser" runat="server" />
                            </ItemTemplate>
                            <ItemStyle cssclass="itemIconeBrowser" />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="UTE_ID_UTENTE" SortExpression="UTE_ID_UTENTE" Visible="false" />
                        <asp:BoundField DataField="UTE_STATO_UTENTE" SortExpression="UTE_STATO_UTENTE" Visible="false"/>
                        
                        <asp:TemplateField>                            
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckBoxSelAll"  runat="server" AutoPostBack="true" OnCheckedChanged="CheckBoxSelAll_OnCheckedChanged" />
                            </HeaderTemplate>
                            
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxSelezioneUtente"  runat="server" Enabled="True" />
                            </ItemTemplate>                        
                            <ItemStyle cssclass="itemIconeBrowser" />
                        </asp:TemplateField>
                        
                       
                        <asp:TemplateField HeaderStyle-ForeColor="#CC0000" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Image ID="imgStatoUtente"  runat="server" />
                            </ItemTemplate>                            
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="UTE_COGNOME" SortExpression="UTE_COGNOME" HeaderStyle-ForeColor="#CC0000" ItemStyle-CssClass="capitalize" />
                        <asp:BoundField DataField="UTE_NOME" SortExpression="UTE_NOME" HeaderStyle-ForeColor="#CC0000" ItemStyle-CssClass="capitalize" />
                        <asp:BoundField DataField="UTE_USER_ID" SortExpression="UTE_USER_ID" HeaderStyle-ForeColor="#CC0000" />
                        <asp:BoundField DataField="UTE_EMAIL" SortExpression="UTE_EMAIL" HeaderStyle-ForeColor="#CC0000" />
                        <%--<asp:BoundField DataField="CDC_CODICE_CENTRO_DI_COSTO" SortExpression="CDC_CODICE_CENTRO_DI_COSTO" HeaderStyle-ForeColor="#CC0000" />
                        <asp:BoundField DataField="UTE_ULTIMO_ACCESSO" SortExpression="UTE_ULTIMO_ACCESSO" HeaderStyle-ForeColor="#CC0000" />--%>
                        <asp:BoundField DataField="CLI_RAGIONE_SOCIALE" SortExpression="CLI_RAGIONE_SOCIALE" HeaderStyle-ForeColor="#CC0000" />
                        
                        <asp:TemplateField HeaderStyle-ForeColor="#CC0000" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Image ID="imgOnline"  runat="server" />
                            </ItemTemplate>                            
                        </asp:TemplateField>
                        
                    </Columns>

                    <SelectedRowStyle CssClass="selectedRowGridView" />
                    <PagerSettings Mode="NumericFirstLast" />
                    <PagerStyle CssClass="GridViewPaginationLink" />

                </MyAsp:MyGridView>

                <asp:ObjectDataSource ID="ObjectDataSourceUtenti" runat="server">
                </asp:ObjectDataSource>                
                <asp:UpdatePanel UpdateMode="Conditional" runat="server">
                <ContentTemplate></ContentTemplate>
                </asp:UpdatePanel>   
                                 
        </div>
       
    </form>

    </div>
</div>    
</body>
</html>
