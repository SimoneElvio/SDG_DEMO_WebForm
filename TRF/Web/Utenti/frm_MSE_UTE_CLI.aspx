<%@ Page Language="C#" CodeBehind="frm_MSE_UTE_CLI.aspx.cs" Inherits="Web_Clienti_frm_MSE_UTE_CLI" AutoEventWireup="True" %>

<%@ Register TagPrefix="uc4" TagName="Script" Src="../Common/Script.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head id="headEditor" runat="server">
    <title id="TitlePage" runat="server"></title>
</head>

<body id="mseSrv" runat="server" class="fix-header fix-sidebar card-no-border">

    <div id="main-wrapper">
        <form id="form1" runat="server">
        
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
                                        <asp:Button ID="ButtonAnnulla" CssClass="btn btn-secondary m-l-5 pull-right" runat="server" UseSubmitBehavior="False" OnClientClick="parent.refreshBrowser(); closeParentModal();" />
                                        <asp:Button ID="ButtonSalva" CssClass="btn btn-success m-l-5 pull-right" runat="server" OnClick="ButtonSalva_Click" />
                                    </div>
                                </div>

                                <input type="hidden" id="fieldChanged" runat="server" value="0" />

                                <hr />

                                <div class="card-body">

                                    <div class="row">

                                        <div id="divDropDownListUtente" runat="server" class="col-md-12">
                                            <div class="row form-group">
                                                <label id="LabelUtente" runat="server" class="required control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList id="DropDownListUtente" CssClass="DropWithDisabled form-control" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divDropDownListCliente" runat="server" class="col-md-12">
                                            <div class="row form-group">
                                                <label id="LabelCliente" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList id="DropDownListCliente" CssClass="form-control" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                
                                        <div id="divCheckBoxStatoCliente" runat="server" class="col-md-12">
                                            <div class="row form-group">
                                                <label id="LabelStatoCliente" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:CheckBox ID="CheckBoxStatoCliente" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                
                                        <div id="divTextDataCreazione" runat="server" class="col-md-12">
                                            <div class="row form-group">
                                                <label id="LabelDataCreazione" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextDataCreazione" type="text" runat="server" class="form-control" />
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

        //top.$('#editorDialog').dialog("option", "height", $("#form1").height() + 500);
        //top.$('#editorDialog').dialog("option", "width", 860);
        //top.$('#editorDialog').dialog("option", "position", "center");
        
        $("#form1").validate({
            rules: {
                DropDownListCliente: {
                    required: true
                }
            },
            messages: {
                DropDownListCliente: msgCLIENTE
            }
        });

    });
</script>