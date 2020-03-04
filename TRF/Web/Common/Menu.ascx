<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="GestioneUtenti.Web.Common.Menu" %>

<div id="menu">   
   
    <asp:PlaceHolder ID="MenuEventi" runat="server"></asp:PlaceHolder>
    
<%--    <div>
        <img src="" id="logoVersione" class="logoVersione" alt="" runat="server" visible="false" style="text-align:center" />
    </div>--%>
   
</div>

<aside class="left-sidebar">
    <!-- Sidebar scroll-->
    <div class="scroll-sidebar">
        <!-- Sidebar navigation-->
        <nav class="sidebar-nav">

            <ul id="sidebarnav" class="col-md-8 pull-left" runat="server"></ul>
            <div class="col-md-4 pull-right p-0 m-t-15">
                <%--<img src="" id="logoCliente" class="logoCliente pull-right" alt="Logo" title="" runat="server" />--%>
                <div id="divButtonMenu" runat="server"></div>
            </div>

        </nav>
        <!-- End Sidebar navigation -->
    </div>
    <!-- End Sidebar scroll-->
</aside>

