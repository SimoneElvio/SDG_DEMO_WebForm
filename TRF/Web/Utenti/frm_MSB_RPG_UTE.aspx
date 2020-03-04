<%@ Page Language="C#" CodeBehind="frm_MSB_RPG_UTE.aspx.cs" Inherits="Web_RiepilogoUtenti_frm_MSB_RPG_UTE" AutoEventWireup="True" %>
<%@ Register TagPrefix="MyAsp" Namespace="MyGridViewLibrary" Assembly="SDG" %>
<%@ Register TagPrefix="MyLinkButton" Namespace="skmExtendedControls" Assembly="SDG" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Browser Standard</title>                                           
    <!--[if lt IE 7]><link href="../Css/IE6_fix.css" rel="stylesheet" type="text/css" media="screen" /><![endif]-->                                                
    <style type="text/css">
        table tr td{cursor:default;}
        #LabelTitolo{padding-left:10px}
    </style>
    
    <script type="text/javascript">
        $(document).ready(function () {
            top.$('#editorDialog').dialog("option", "height", 500);
            top.$('#editorDialog').dialog("option", "width", 700);
            top.$('#editorDialog').dialog("option", "position", "center");
                     
            if (getParameterByName("ASSOCIA") != '') {
                $('#txtUtente').val($('#txtDescrizioneViaggiatore', parent.frames['frameContent'].document).val());
                $('#btnCerca').click();
            }
        });

        function associaViaggiatore(id) {
            parent.frames['frameContent'].getTravellerInformation(id);
            self.parent.hideEditorDialog();
        }
 
    </script>
</head>
<body runat="server">
<div id="wrap">
    <div id="page_height">
    <form id="form1" runat="server" >    
        <div id="content" runat="server" style="padding:0">
        <cc1:ToolkitScriptManager ID="CustomScriptManager" runat="server"></cc1:ToolkitScriptManager>                     
           <div id="headerBrowser" runat="server"> 
                <h1 runat="server" id="LabelTitolo"></h1>

                <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList id="DropDownListRecordPagina" runat="server" AutoPostBack="true" />
                        <label id="LabelRecPagina" runat="server" for="DropDownListRecordPagina"></label>
                        <label runat="server" id="LabelNroRecord"></label>
                
                        <div id="intestazioneBrowser" runat="server">
                            <div id="toolbar" runat="server">                        
                                <img id="imgViewSearch" src="../Images/search.gif" onclick="viewHideSearch()" alt="Visualizza Ricerca Avanzata" />                        
                                <span id="spanButton"><asp:Button ID="ButtonExit" runat="server" OnClientClick="self.parent.hideEditorDialog();" CssClass="btnBrowser" /></span>    
                            </div>
                        </div>
                
                 
                        <div id="boxRicercaAvanzata" runat="server">
                            <div id="boxField">                                                                
                                <label id="LabelUtente" runat="server"></label><input type="text" id="txtUtente" name="txtUtente" runat="server" /><br />                                                
                                <label id="LabelCDC" runat="server"></label><input type="text" id="txtCDC" name="txtCDC" runat="server" /><br />                        
                            </div>
                            <%--<div id="boxField2">
                                <label id="LabelCodiceIndividuale" runat="server"></label><input type="text" id="txtCodiceIndividuale" name="txtCodiceIndividuale" runat="server" /><br />
                                <label id="LabelEmail" runat="server"></label><input type="text" id="txtEmail" name="txtEmail" runat="server" /><br />
                                <label id="LabelOnline" runat="server"></label><input type="checkbox" id="chkOnline" runat="server" /><br />
                                <label id="LabelUserId" runat="server"></label><input type="text" id="txtUserId" name="txtUserId" runat="server" /><br />
                                <label id="LabelCliente" runat="server"></label><asp:DropDownList id="txtCliente" runat="server"></asp:DropDownList>                                                     
                            </div>                                  --%>
                            <asp:Button id="btnCerca" runat="server" ></asp:Button>                    
                            <br class="clear" />
                        </div>             
                        <MyAsp:MyGridView ID="GridViewRpgUtenti" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="tableBrowser" EnableViewState="True">
                            <Columns>                                                                                          
                                <asp:BoundField DataField="UTE_ID_UTENTE" SortExpression="UTE_ID_UTENTE" Visible="false" HeaderStyle-CssClass = "testataTabelle" />
                                <asp:BoundField DataField="UTENTE" SortExpression="UTENTE" HeaderStyle-CssClass = "testataTabelle" ItemStyle-CssClass="capitalize" />                    
                                <asp:BoundField DataField="UTE_MATRICOLA" SortExpression="UTE_MATRICOLA" HeaderStyle-CssClass = "testataTabelle" ItemStyle-CssClass="capitalize" />                    
                                <asp:BoundField DataField="UTE_EMAIL" SortExpression="UTE_EMAIL" HeaderStyle-CssClass = "testataTabelle" ItemStyle-CssClass="capitalize" />                    
                            </Columns>
                            <SelectedRowStyle CssClass="selectedRowGridView" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle CssClass="GridViewPaginationLink" HorizontalAlign="Right"  />                                    
                        </MyAsp:MyGridView>            
                </ContentTemplate>
            </asp:UpdatePanel>
          </div>
        </div>        
    </form>
    </div>
    </div>    
</body>
</html>
