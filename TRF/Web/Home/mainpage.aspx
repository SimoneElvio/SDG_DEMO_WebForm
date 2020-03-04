<%@ Page Language="C#" CodeBehind="mainpage.aspx.cs" Inherits="mainpage" AutoEventWireup="True" %>
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
                
                <!-- ============================================================== -->
                <!-- Bread crumb and right sidebar toggle -->
                <!-- ============================================================== -->
                <div class="row page-titles">
                    <div class="col-md-6 col-8 align-self-center">
                        <h3 class="text-themecolor m-b-0 m-t-0">Home</h3>
                    </div>
                </div>
                <!-- ============================================================== -->
                <!-- End Bread crumb and right sidebar toggle -->
                <!-- ============================================================== -->
                <!-- ============================================================== -->
                <!-- Start Page Content -->
                <!-- ============================================================== -->
                
                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div id="pNotaCliente" runat="server" class="card-body">
                                <h4><i class="fa fa-info-circle"></i> <span runat="server" id="message"></span></h4>
                                <p></p>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Row -->
                <div class="row rss">
                    <div class="col-lg-6" id="DivPanelScioperi" runat="server">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title"><i class="fas fa-rss"></i> Feed Scioperi</h4>
                                <div id="DivRssScioperi" runat="server" class="slimScrollDiv"></div>
                                <small id="LbOrigScio" runat="server">Dati reperiti dal <a href="http://scioperi.mit.gov.it/mit2/public/scioperi/rss" target="_blank">Ministero dei Trasporti</a></small>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-6" id="DivPanelNews" runat="server">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title"><i class="fas fa-rss"></i> Feed News</h4>                                    
                                <div id="DivRssNews" runat="server" class="slimScrollDiv"></div>
                                <small id="LbOrigNews" runat="server">Dati reperiti dal <a href="http://www.trasporti.gov.it/" target="_blank">Ministero dei Trasporti</a></small>
                            </div>
                        </div>
                    </div>

                </div>
                <!-- Row -->

                <!-- ============================================================== -->
                <!-- End PAge Content -->
                <!-- ============================================================== -->

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

    <script>
        $(document).ready(function () {
            $('.slimScrollDiv').slimScroll({
                height: '400px'
            });

        });        
    </script>

</body>

</html>