<%@ Page Language="C#" CodeBehind="frm_MSE_RUL_UTE.aspx.cs" Inherits="Web_Ruoli_frm_MSE_RUL_UTE" AutoEventWireup="True" EnableEventValidation="false" %>

<%@ Register TagPrefix="uc4" TagName="Script" Src="../Common/Script.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head id="headEditor" runat="server">
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/images/favicon.png">
    <title>Editor Ruolo</title>
    
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    	    
</head>

<body id="mseSrv" class="fix-header fix-sidebar card-no-border">
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
                    
                    <%--<asp:ScriptManager ID="CustomScriptManager" runat="server" EnablePartialRendering="false" LoadScriptsBeforeUI="true" EnablePageMethods="true" CombineScripts="false"></asp:ScriptManager>--%>


                   <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" EnablePageMethods="true" ScriptMode="Release" LoadScriptsBeforeUI="false"></asp:ScriptManager>

                    <div class="row">            

                        <div class="col-lg-12">

                            <div class="card">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h3 runat="server" id="LabelTitolo"></h3>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="ButtonAnnulla" CssClass="btn btn-secondary m-l-5 pull-right" runat="server" UseSubmitBehavior="False" OnClientClick="parent.$('#ButtonRuoli').click();parent.$('#ButtonUtenti').click(); closeParentModal();" />
                                        <asp:Button ID="ButtonSalva" CssClass="btn btn-success pull-right" runat="server" OnClick="ButtonSalva_Click" />
                                    </div>
                                </div>

                                <hr />

                                <div class="card-body">
                                    
                                    <div class="row">
                                        <div id="divUtente" runat="server" class="col-md-12">
                                            <div class="row form-group">
                                                <label id="lblUTE_ID_UTENTE" runat="server" class="required control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList id="txtUTE_ID_UTENTE" CssClass="form-control custom-select" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div id="divRUL_ID_RUOLO" runat="server" class="col-md-12">
                                            <div class="row form-group">
                                                <label id="lblRUL_ID_RUOLO" runat="server" class="control-label col-md-4"></label>    
                                                <div class="col-md-8">
                                                    <div class="controls">            
                                                        <asp:DropDownList id="txtRUL_ID_RUOLO" runat="server" CssClass="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">

                                        <div id="divStatoRuolo" runat="server" class="col-md-12">
                                            <div class="row form-group">
                                                <label id="lblURL_STATO_RUOLO_UTENTE" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:CheckBox ID="txtURL_STATO_RUOLO_UTENTE" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">

                                        <div id="divDataCreazione" runat="server" class="col-md-12">
                                            <div class="row form-group">        
                                                <label id="lblURL_DATA_ASSEGNAZIONE" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="txtURL_DATA_ASSEGNAZIONE" type="text" runat="server" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                          
                                        <input type="hidden" id="fieldChanged" runat="server" value="0" />
            
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

<script type="text/javascript" src="../Jscript/jquery.validate.js"></script>
<script type="text/javascript" src="../Jscript/jquery.formobserver.js"></script>	
    
<script type="text/javascript">

    $(document).ready(function () {

        documentReadyEditorBO();

        //$('#form1').validate({
        //    errorPlacement: function (error, element) { }
        //});

        //$('#form1').FormObserve({
        //    changeClass: "changed"
        //});


    });
    

</script>

