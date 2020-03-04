<%@ Page Language="C#" CodeBehind="frm_MSU_UTE.aspx.cs" Inherits="Web_frm_MSU_UTE" AutoEventWireup="True" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="uc4" TagName="Script" Src="../Common/Script.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head id="headEditor" runat="server">
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/images/favicon.png">
    <title>Editor Utente</title>
    
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    	    
</head>
		
<body id="mseSrv" runat="server" class="fix-header fix-sidebar card-no-border">
    <div id="main-wrapper">

        <form id="form1" runat="server" submitdisabledcontrols="true" novalidate autocomplete="off">

            <!-- ============================================================== -->
            <!-- Page wrapper  -->
            <!-- ============================================================== -->
            <div class="page-wrapper">
            
                <!-- ============================================================== -->
                <!-- Container fluid  -->
                <!-- ============================================================== -->
                <div class="container-fluid container-big">
                
                    <!-- ============================================================== -->
                    <!-- Start Page Content -->
                    <!-- ============================================================== -->
                    
                    <cc1:ToolkitScriptManager ID="CustomScriptManager" runat="server" EnablePartialRendering="true" EnablePageMethods="true" LoadScriptsBeforeUI="True" CombineScripts="True"></cc1:ToolkitScriptManager>        

                    <input type="hidden" id="fieldChanged" runat="server" value="0" /> 

                    <div class="row">            

                        <div class="col-lg-12">

                            <div class="card">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h3 runat="server" id="LabelTitolo"></h3>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="ButtonAnnulla" CssClass="btn btn-secondary m-l-5 pull-right" runat="server" UseSubmitBehavior="False" OnClientClick="parent.refreshBrowser();" />
                                        <asp:Button ID="ButtonSalva" CssClass="btn btn-success m-l-5 pull-right" runat="server" OnClick="ButtonSalva_Click" OnClientClick="spinner();" />
                                        <i class="fa fa-spinner fa-spin fa-2x pull-right m-r-5 hide" id="idSpinner"></i>
                                    </div>
                                </div>

                                <hr />

                                <div class="card-body">
                                                                            
                                    <div class="row">
                                                                                
                                        <div id="divNome" runat="server" class="col-md-12">
                                            <div class="row form-group">                               
                                                <label id="LabelCliente" runat="server" class="control-label col-md-3"></label>
                                                <div class="col-md-9">
                                                    <div class="controls">
                                                        <asp:DropDownList id="txtCliente" runat="server" class="form-control required"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divFile" runat="server" class="col-md-12">
                                            <div class="row form-group">
                                                <label id="LabelFile" runat="server" class="control-label col-md-3"></label>
                                                <div class="col-md-9">
                                                    <div class="controls">
                                                        <asp:FileUpload ID="FileUploadUtente" runat="server" class="form-control-file required" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="LabelResult" runat="server"></div>
                                        
                                    </div>                                                       

                                </div>                                                                                                                                                            		      	
                            </div>
                        </div>

                    </div>

                    <!-- ============================================================== -->
                    <!-- End PAge Content -->
                    <!-- ============================================================== -->

                </div>
                <!-- ============================================================== -->
                <!-- End Container fluid  -->
                <!-- ============================================================== -->

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

<script type="text/javascript" src="../Jscript/jquery.formobserver.js"></script>	
<script type="text/javascript" src="../Jscript/jquery.validate.js"></script>

<script type="text/javascript">
 	$(document).ready(function () {
 	    
 	    $('form').validate({
 	        errorPlacement: function (error, element) { }
 	    });

 	    $('#form1').FormObserve({
 	        changeClass: "changed"
 	    });
 	});

 	function spinner() {

 	    if (!$('#form1').valid()) { return false;}

 	    $('#ButtonSalva').hide();
 	    $('#idSpinner').show();
 	    
 	}
</script>