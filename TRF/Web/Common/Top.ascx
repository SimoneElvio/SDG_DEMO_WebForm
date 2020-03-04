<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="Top.ascx.cs" Inherits="GestioneUtenti.Web.Common.Top" %>        
    
        
<%--        <div id="divManutenzione" style="display:none">
            <label>MANUTENZIONE STRAORDINARIA!!</label>
            <br />        
            <label>19/10/2011 DALLE ORE 18.00 ALLE ORE 18.30</label>
            <br />
            <label>NON UTILIZZARE DURANTE QUESTO INTERVALLO DI TEMPO. GRAZIE</label>
        </div>
        --%>

<%--<asp:LinkButton id="ButtonHelpTop" runat="server" Visible="false"></asp:LinkButton>--%>

<header class="topbar">
    <nav class="navbar top-navbar navbar-expand-md navbar-light">
        <!-- ============================================================== -->
        <!-- Logo -->
        <!-- ============================================================== -->
        
        <h6 id="h1TitoloApplicazione" runat="server" style="display:none;"></h6>

        <div class="navbar-header" runat="server" id="navbarHeader">
            <a class="navbar-brand" href="../Home/mainpage.aspx">
                <!-- Logo icon -->
                <b>
                    <div id="logo" runat="server" style="display:none;"></div>
                    <!--You can put here icon as well // <i class="wi wi-sunset"></i> //-->
                    <!-- Dark Logo icon -->
                    <%--<img src="../assets/images/logo-icon.png" alt="homepage" class="dark-logo" />--%>
                    <!-- Light Logo icon -->
                    <%--<img src="../assets/images/logo-light-icon.png" alt="homepage" class="light-logo" />--%>
                </b>
                <!--End Logo icon -->
                <!-- Logo text -->
                    <span>
                    <!-- dark Logo text -->
                    <%--<img src="../assets/images/logo-text.png" alt="homepage" class="dark-logo" />--%>
                    <!-- Light Logo text -->    
                    <%--<img src="../assets/images/logo-light-text.png" class="light-logo" alt="homepage" />--%>
                    </span>
            </a>
        </div>
        <!-- ============================================================== -->
        <!-- End Logo -->
        <!-- ============================================================== -->
        <div class="navbar-collapse">
            <!-- ============================================================== -->
            <!-- toggle and nav items -->
            <!-- ============================================================== -->
            <ul class="navbar-nav mr-auto mt-md-0 ">
                <li class="nav-item"> <a class="nav-link nav-toggler hidden-md-up text-muted waves-effect waves-dark" href="javascript:void(0)"><i class="ti-menu"></i></a> </li>
            </ul>
            
            <div class="text-center" id="divTitleMobile" runat="server"><h4 runat="server" id="h4TitleMobile"></h4></div>

            <div class="col-md-2 pull-right p-0 m-t-15 noMobile">                
            </div>

            <!-- ============================================================== -->
            <!-- User profile and search -->
            <!-- ============================================================== -->
            <ul class="navbar-nav my-lg-0">
                
                <%--<li class="nav-item hidden-sm-down">
                    <form class="app-search">
                        <input type="text" class="form-control" placeholder="Search for..."> <a class="srh-btn"><i class="ti-search"></i></a> </form>
                </li>--%>
                
                <li class="nav-item dropdown">
                    
                    <a class="nav-link dropdown-toggle text-muted waves-effect waves-dark" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><img src="../assets/images/users/3.png" alt="user" class="profile-pic" /></a>
                    <div class="dropdown-menu dropdown-menu-right animated flipInY">
                        <ul class="dropdown-user">
                            <li><asp:LinkButton ID="LinkBackAdmin" CssClass="utenteCollegato" runat="server" OnClick="LinkBackAdmin_Click" Visible="false"></asp:LinkButton></li>
                            <li role="separator" class="divider"></li>
                            <li><asp:LinkButton ID="ultimoAccesso" CssClass="ultimoAccesso" runat="server" OnClientClick="return false;"></asp:LinkButton></li>
                            <li role="separator" class="divider"></li>
                            <li><asp:LinkButton ID="UtenteCollegato" CssClass="utenteCollegato" runat="server" OnClientClick="return false;"></asp:LinkButton></li>
                            <li role="separator" class="divider"></li>
                            <li runat="server" id="liCambioPassword"><asp:LinkButton ID="LinkCambioPassword" ToolTip="Cambio password" runat="server" OnClick="LinkCambioPassword_Click" CausesValidation="False"></asp:LinkButton></li>
                            <li runat="server" id="liCambioPasswordSeparator" role="separator" class="divider"></li>
                            <li runat="server" id="liLogout"><asp:LinkButton ID="LinkLogout" ToolTip="Esci" runat="server" CausesValidation="False" OnClick="LinkLogout_Click"></asp:LinkButton></li>
                        </ul>
                    </div>
                </li>
                <li class="nav-item dropdown" runat="server" id="ddlLanguage" visible="false">
                    <a class="nav-link dropdown-toggle text-muted waves-effect waves-dark" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"> <i class="flag-icon flag-icon-it"></i></a>
                    <div class="dropdown-menu  dropdown-menu-right animated bounceInDown"> 
                        <a class="dropdown-item" href="#"><i class="flag-icon flag-icon-it"></i> Italia</a>
                    </div>
                </li>
            </ul>

        </div>
    </nav>
    
    <div style="height:45px;" id="divButtonMobile" runat="server"></div>
    <div id="divButtonSaveMobile" runat="server"></div>
</header>