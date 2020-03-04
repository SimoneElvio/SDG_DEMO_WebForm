<%@ Page Language="C#" CodeBehind="frm_PWD.aspx.cs" Inherits="Web_Login_frm_PWD" AutoEventWireup="True" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html>
<html lang="en">

<head id="Header" runat="server">

    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/images/favicon.png">
    <title>SDG_DEMO</title>
    <!-- Bootstrap Core CSS -->
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="../css/style.css" rel="stylesheet">
    <!-- You can change the theme colors from here -->
    <link href="../css/colors/blue.css" id="theme" rel="stylesheet">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
    
    <style>
        
    </style>

    <script>

        $(document).ready(function () {
            
            $("#ButtonChangePassword").addClass("btn btn-info btn-block text-uppercase waves-effect waves-light");

        });
        
    </script>

</head>

<body>
    
    <!-- ============================================================== -->
    <!-- Main wrapper - style you can find in pages.scss -->
    <!-- ============================================================== -->
    <section id="wrapper">

        <div class="login-register" style=" background-image:url(../Images/Background/8.jpg);">
            
            <div class="login-box card">

                <div class="card-body">
                    <form id="form1" method="post" runat="server" class="form-horizontal form-material">

                        <div style="margin: 0 auto 20px; width:90px;"><img src="../assets/images/logo.jpg" id="logo" alt="logo" style="width:90px;" /></div>
		                <h3 ID="LabelTitolo" runat="server" ></h3>
                        
                        <div class="alert alert-warning">
		                    <small ID="LabelIstruzioni" runat="server"></small>
		                </div>

                        <div class="form-group">
                            <label id="LabelOldPassword" runat="server" for="InputOldPassword" class="control-label"></label>
                            <asp:textbox id="InputOldPassword" tabIndex="1" runat="server" TextMode="Password" CssClass="form-control"></asp:textbox>
                        </div>

                        <div class="form-group">
                            <label id="LabelNewPassword" runat="server" for="InputNewPassword" class="control-label"></label>
                            <asp:textbox id="InputNewPassword" tabIndex="2" runat="server" TextMode="Password" CssClass="form-control"></asp:textbox>
                        </div>

                        <div class="form-group">                
                            <label id="LabelNewPasswordConfirm" runat="server" for="InputNewPasswordConfirm" class="control-label"></label>
                            <asp:textbox id="InputNewPasswordConfirm" tabIndex="3" runat="server" TextMode="Password" CssClass="form-control"></asp:textbox>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button ID="ButtonChangePassword" runat="server" />
                            </div>
                            <div class="col-md-6">    
                                <button id="ButtonAnnulla" CausesValidation="false" tabIndex="5" runat="server" class="btn btn-secondary btn-block btn-lg text-uppercase waves-effect waves-light"></button>
                            </div>
                        </div>

                        <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
                        <asp:validationsummary id="valSum" runat="server" ShowSummary="False" ShowMessageBox="true" DisplayMode="BulletList"></asp:validationsummary>

                    </form>
                </div>

          </div>
        </div>

    </section>
    <!-- ============================================================== -->
    <!-- End Wrapper -->
    <!-- ============================================================== -->
    <!-- ============================================================== -->
    <!-- All Jquery -->
    <!-- ============================================================== -->
    <script src="../assets/plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap tether Core JavaScript -->
    <script src="../assets/plugins/bootstrap/js/popper.min.js"></script>
    <script src="../assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <!-- slimscrollbar scrollbar JavaScript -->
    <script src="../Jscript/jquery.slimscroll.js"></script>
    <!--Wave Effects -->
    <script src="../Jscript/waves.js"></script>
    <!--Menu sidebar -->
    <script src="../Jscript/sidebarmenu.js"></script>
    <!--stickey kit -->
    <script src="../assets/plugins/sticky-kit-master/dist/sticky-kit.min.js"></script>
    <!--Custom JavaScript -->
    <script src="../Jscript/custom.min.js"></script>

</body>

</html>
