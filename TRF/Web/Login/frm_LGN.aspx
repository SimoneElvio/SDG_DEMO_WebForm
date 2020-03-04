<%@ Page Language="C#" CodeBehind="frm_LGN.aspx.cs" Inherits="Web_Login_frm_LGN" AutoEventWireup="True" %>
<!DOCTYPE html>
<html lang="en">

<head id="Header" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta name="robots" content="noindex, nofollow">
           
    <meta name="msapplication-TileColor" content="#ffffff">
    <meta name="theme-color" content="#ffffff">
    
    <title>SDG - DEMO</title>
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
    
    <link href="../scss/icons/fontawesome-free-5.7.2-web/css/all.css" rel="stylesheet" />

    <style>
        #ButtonReset {border:0; background-color:transparent; margin-top:20px; cursor:pointer; float:right; font-size:0.8rem;}
        #introMobile {background-color:transparent; margin: 200px auto;  border:5px solid #fff; border-radius:5px; height:100%;  text-align:center;}
    </style>

</head>

<body id="bodyLgn" runat="server" style="background:#ccc;">
        
    <!-- ============================================================== -->
    <!-- Main wrapper - style you can find in pages.scss -->
    <!-- ============================================================== -->
    
    <div id="introMobile">
        <img src="../assets/images/logo.jpg" id="logo" alt="logo" style="width:30%;" />
    </div>
    
    <section id="wrapper">

        <div class="login-register">
            
            <div class="login-box card">
            <div class="card-body">
                <form class="form-horizontal form-material" id="loginform" method="post" runat="server">
			        
                    <input type="hidden" id="isMobile" runat="server" />

                    <h3 class="box-title m-b-20 d-none">Sign In</h3>
                    
		            <asp:Panel id="divLoginMessage" runat="server" Visible="false" CssClass="row alert alert-danger">
                        <i class="fas fa-exclamation-triangle pull-left"></i> <small id="LabelMessage" runat="server" class=""></small>
		            </asp:Panel>

                    <div class="form-group ">
                        <div class="col-xs-12"> 
                            <asp:textbox id="InputUser" tabIndex="1" runat="server" Text="" CssClass="form-control" placeholder="e-mail"></asp:textbox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12">
					        <asp:textbox id="InputPassword" tabIndex="2" runat="server" TextMode="Password" CssClass="form-control" placeholder="password"></asp:textbox>
                        </div>
                    </div>
                    <div class="form-group hide">
                        
                        <asp:HiddenField ID="hSiglaLingua" runat="server" Value="it" />
				        <label id="lb_lingua" runat="server" visible="false">lingua</label>
                        <asp:DropDownList id="hLingua" runat="server" CssClass="form-control custom-select">
                            <asp:ListItem Value="1" Text="italiano"></asp:ListItem>
                            <asp:ListItem Value="2" Text="english"></asp:ListItem>
                        </asp:DropDownList>

                    </div>

                    <div class="form-group text-center m-t-20">
                        <div class="col-xs-12">
                            <input type="button" runat="server" id="ButtonLogin" Class="btn btn-info btn-lg btn-block text-uppercase " value="Log In" />
                            <input type="button" id="ButtonReset" runat="server" class="text-dark pull-right text-info" value="reset password" />
                        </div>
                    </div>

                    <div class="form-group text-center m-t-20 text-info">
                        <h4 class="text-info" id="infoProject" runat="server"></h4>
                        <h1 runat="server" id="infoCompilationMode" class="text-danger" visible="false"></h1>
                        <small runat="server" id="lastBuild" class="text-secondary"></small>
                    </div>
                    
                    <p id="MessageAccess" runat="server" visible="false"></p>
                </form>

            </div>
          </div>
        </div>
        <%--<div id="footer" runat="server"><a href="#" title="">credits SDG</a> | copyright &copy; SDG 2009 - 2017 | version 1.0.0</div>--%>
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
    <!-- ============================================================== -->
    <!-- Style switcher -->
    <!-- ============================================================== -->
        
    <script type="text/javascript">

        $(window).on('load', function () {
            // insert code here            
        });
        
        $(document).ready(function () {
            if ($("#isMobile").val() == "1") {
                $("#introMobile").show();
                $("#wrapper").hide();
                setTimeout(function () {
                    $("#introMobile").hide();
                    $("#wrapper").show();
                }, 2000);
            }
            else {
                $("#introMobile").hide();
                $("#wrapper").show();
            }
        });

    </script>
</body>

</html>