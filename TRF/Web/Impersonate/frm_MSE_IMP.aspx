<%@ Page Language="C#" CodeBehind="frm_MSE_IMP.aspx.cs" Inherits="Web_frm_MSE_IMP" AutoEventWireup="True" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="../Common/Top.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Menu" Src="../Common/Menu.ascx" %>
<%@ Register TagPrefix="uc4" TagName="Script" Src="../Common/Script.ascx" %>

<!DOCTYPE html>
<html lang="en">

<head id="Header" runat="server">
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/images/favicon.png">
    <title></title>
    
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
</head>

<body class="fix-header fix-sidebar card-no-border" id="mainpage">
    
    <!-- ============================================================== -->
    <!-- Preloader - style you can find in spinners.css -->
    <!-- ============================================================== -->
    <div class="preloader">
        <svg class="circular" viewBox="25 25 50 50"><circle class="path" cx="50" cy="50" r="20" fill="none" stroke-width="2" stroke-miterlimit="10" /></svg>
    </div>

    <!-- ============================================================== -->
    <!-- Main wrapper - style you can find in pages.scss -->
    <!-- ============================================================== -->
    <div id="main-wrapper">
        
        <form id="form1" runat="server">
        
        <!-- ============================================================== -->
        <!-- Topbar header -->
        <!-- ============================================================== -->

        <uc1:Top id="Top" runat="server"></uc1:Top>   

        <!-- ============================================================== -->
        <!-- End Topbar header -->
        <!-- ============================================================== -->
        
        <!-- ============================================================== -->
        <!-- Left Sidebar - style you can find in sidebar.scss  -->
        <!-- ============================================================== -->
        
        <uc2:Menu id="Menu" runat="server"></uc2:Menu>        

        <!-- ============================================================== -->
        <!-- End Left Sidebar - style you can find in sidebar.scss  -->
        <!-- ============================================================== -->
        
        <!-- ============================================================== -->
        <!-- Page wrapper  -->
        <!-- ============================================================== -->
        <div class="page-wrapper">
            
            <!-- ============================================================== -->
            <!-- Container fluid  -->
            <!-- ============================================================== -->
            <div class="container-fluid container-big">

                <div class="row page-titles">
                    <div class="col-md-6 col-8 align-self-center">
                        <h3 class="text-themecolor m-b-0 m-t-0" id="LabelTitolo" runat="server"></h3>                        
                    </div>
                </div>

                <!-- ============================================================== -->
                <!-- Start Page Content -->
                <!-- ============================================================== -->

                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div id="pNotaCliente" runat="server" class="card-body">
                                <%--<h4><i class="fa fa-info-circle"></i> ..</h4>--%>
                                <p>In questa pagina &egrave; possibile prendere le sembianze di un qualunque utente presente nel sistema.</p>                                
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">            

                    <div class="col-lg-12">

                        <div class="card">                                
                            <div class="card-body">

                                <asp:Panel id="PanelUpload" runat="server"> 

                                    <div id="div1" runat="server" class="form-group row">
                                        <label id="LabelCliente" class="control-label col-md-3" runat="server"></label>
                                        <div class="col-md-9">
                                            <asp:DropDownList id="txtCliente" runat="server" AutoPostBack="true" CssClass="form-control custom-select"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div id="div2" runat="server" class="form-group row">
                                        <label id="LabelUtente" class="control-label col-md-3" runat="server"></label>
                                        <div class="col-md-9">
                                            <asp:DropDownList id="txtUtente" runat="server" CssClass="form-control custom-select"></asp:DropDownList>
                                        </div>
                                    </div>
       
                                    <asp:Button Text="Salva" ID="btnImpersonaUtente" runat="server" OnClick="btnImpersonaUtente_Click" CssClass="btn btn-success pull-right" />
                                                
                                </asp:Panel>
                            
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!-- ============================================================== -->
            <!-- End Container fluid  -->
            <!-- ============================================================== -->

            <footer class="footer" id="footer" runat="server"></footer>

        </div>
        <!-- ============================================================== -->
        <!-- End Page wrapper  -->
        <!-- ============================================================== -->

        </form>

    </div>
    <!-- ============================================================== -->
    <!-- End Wrapper -->
    <!-- ============================================================== -->
    
    <uc4:Script id="Script" runat="server"></uc4:Script>

</body>

</html>