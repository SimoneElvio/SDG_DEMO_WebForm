<%@ Page Language="C#" CodeBehind="frm_MSE_UTE_WRF.aspx.cs" Inherits="Web_Workflow_frm_MSE_UTE_WRF" AutoEventWireup="True" EnableEventValidation="false" %>

<%@ Register TagPrefix="uc4" TagName="Script" Src="../Common/Script.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head id="headEditor" runat="server">
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/images/favicon.png">
    <title>Editor Workflow</title>

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
            <asp:HiddenField ID="hImportantFieldModified" runat="server" />

            <!-- ============================================================== -->
            <!-- Page wrapper  -->
            <!-- ============================================================== -->
            <div class="page-wrapper">

                <!-- ============================================================== -->
                <!-- Container fluid  -->
                <!-- ============================================================== -->
                <div class="container-fluid container-big">

                    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" EnablePageMethods="true" ScriptMode="Release" LoadScriptsBeforeUI="false"></asp:ScriptManager>

                    <div class="row">

                        <div class="col-lg-12">

                            <div class="card">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h3 runat="server" id="LabelTitolo"></h3>
                                    </div>
                                    <div class="col-md-6">

                                        <asp:Button ID="ButtonAnnulla" CssClass="btn btn-secondary m-l-5 pull-right" runat="server" UseSubmitBehavior="False" OnClientClick="parent.$('#ButtonWorkflowAssociati').click();" />
                                        <asp:Button ID="ButtonSalva" CssClass="btn btn-success m-l-5 pull-right" runat="server" OnClick="ButtonSalva_Click" />
                                    </div>
                                </div>

                                <input type="hidden" id="fieldChanged" runat="server" value="0" />

                                <hr />

                                <div class="card-body">

                                    <div class="row">

                                        <div id="divUtente" runat="server" class="col-md-6">
                                            <div class="row form-group">
                                                <label id="LabelUtente" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList ID="txtUtente" CssClass="DropWithDisabled form-control custom-select" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                         <div id="divWorkflow" runat="server" class="col-md-6">
                                            <div class="row form-group">
                                                <label id="LabelWorkflow" runat="server" class="required control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList ID="txtWorkflow" CssClass="DropWithDisabled form-control custom-select" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divDataCreazione" runat="server" class="col-md-6">
                                            <div class="row form-group">
                                                <label id="LabelDataCreazione" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="txtDataCreazione" type="text" runat="server" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
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
    <uc4:Script ID="Script" runat="server"></uc4:Script>

</body>
</html>

<script type="text/javascript" src="../Jscript/jquery.formobserver.js"></script>
<script type="text/javascript" src="../Jscript/jquery.validate.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
       
        documentReadyEditorBO();

        //ativaOptionsDisabled();
    });

</script>
