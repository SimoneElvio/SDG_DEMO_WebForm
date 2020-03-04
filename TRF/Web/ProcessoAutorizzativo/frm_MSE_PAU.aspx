<%@ Page Language="C#" Inherits="Web_ProcessoAutorizzativo_frm_MSE_PAU" CodeBehind="frm_MSE_PAU.aspx.cs" AutoEventWireup="True" %>
<%@ Register TagPrefix="uc4" TagName="Script" Src="../Common/Script.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head id="headEditor" runat="server">
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/images/favicon.png">
    <title>Editor Processo Autorizzativo</title>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

    <style>
        .page-wrapper {padding:0;}
        .container-fluid {max-width:100%;}
    </style>

</head>

<body id="mseTry" runat="server" class="fix-header fix-sidebar card-no-border">
    <div id="main-wrapper">
        <form id="form1" runat="server" submitdisabledcontrols="true" novalidate autocomplete="off">

            <!-- ============================================================== -->
            <!-- Page wrapper  -->
            <!-- ============================================================== -->
            <div class="page-wrapper">

                <!-- ============================================================== -->
                <!-- Container fluid  -->
                <!-- ============================================================== -->
                <div class="container-fluid">

                    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" EnablePageMethods="true" ScriptMode="Release" LoadScriptsBeforeUI="false"></asp:ScriptManager>

                    <div class="row">

                        <div class="col-lg-12">

                            <div class="card">
                                
                                <input type="hidden" id="hidCliente" runat="server" />
                                <input type="hidden" id="hIdProcessoAutorizzativo" runat="server" />

                                <div class="row m-t-15 m-b-15">
                                    <div class="col-md-6">
                                        <h3 id="LabelTitolo" runat="server"></h3>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="ButtonAnnulla" CssClass="btn btn-secondary m-l-5 pull-right" runat="server" UseSubmitBehavior="False" Visible="false" OnClientClick="viewBrowserGruppiCliente();return false;" />
                                        <asp:Button ID="ButtonSalva" CssClass="btn btn-success m-l-5 pull-right" runat="server" OnClick="ButtonSalva_Click" />
                                    </div>
                                </div>

                                <div class="row m-t-30">

                                    <div id="divUTE_PROCESSO_AUTORIZZATIVO_LIV_1" class="col-md-12 ">
                                        <div class="row form-group pull-left">
                                            <div class="bt-switch">
                                                <div class="form-check">
                                                    <%--<label class="custom-control custom-radio">
                                                        <input id="radio1" name="radio" type="radio" checked class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Free</span>
                                                    </label>
                                                    <label class="custom-control custom-radio">
                                                        <input id="radio2" name="radio" type="radio" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Paid</span>
                                                    </label>--%>

                                                    <div id="radioButton_liv_1">

                                                        <label class="custom-control">
                                                            <input id="radio1" name="radio_liv_1" type="radio" value="1" runat="server">
                                                            <span class="custom-control-indicator"></span>
                                                            <span class="custom-control-description">Prenotazione senza approvazione</span>
                                                        </label>
                                                        <label class="custom-control">
                                                            <input id="radio2" name="radio_liv_1" type="radio" value="2" runat="server">
                                                            <span class="custom-control-indicator"></span>
                                                            <span class="custom-control-description">Richiesta approvazione</span>
                                                        </label>

                                                    </div>

                                                    <div id="radioButton_liv_2" style="margin-left:30px;">

                                                        <label class="custom-control">
                                                            <input id="radio3" name="radio_liv_2" type="radio" value="3" runat="server">
                                                            <span class="custom-control-indicator"></span>
                                                            <span class="custom-control-description">Solo se fuori policy</span>
                                                        </label>
                                                        <label class="custom-control">
                                                            <input id="radio4" name="radio_liv_2" type="radio" value="4" runat="server">
                                                            <span class="custom-control-indicator"></span>
                                                            <span class="custom-control-description">Sempre</span>
                                                        </label>
                                                    
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

        $('#radioButton_liv_1 input[type=radio]').change(function () {
            if ($(this).val() == 1) {
                $("#radioButton_liv_2 input[type=radio]").prop("checked", false);
                $("#radioButton_liv_2").hide();
            }

            if ($(this).val() == 2) {
                $("#radioButton_liv_2 input[type=radio][value=3]").prop("checked", true);
                $("#radioButton_liv_2").show();
            }

        })

    });
</script>
