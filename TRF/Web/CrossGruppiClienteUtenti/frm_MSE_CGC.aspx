<%@ Page Language="C#" Inherits="Web_CrossGruppiClienteUtenti_frm_MSE_CGC" CodeBehind="frm_MSE_CGC.aspx.cs" AutoEventWireup="True" %>
<%@ Register TagPrefix="uc4" TagName="Script" Src="../Common/Script.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head id="headEditor" runat="server">
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/images/favicon.png">
    <title>Editor Utenti Gruppi Cliente</title>

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

                    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" EnablePageMethods="true" ScriptMode="Release" LoadScriptsBeforeUI="false"></asp:ScriptManager>

                    <div class="row">

                        <div class="col-lg-12">

                            <div class="card">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h3 runat="server" id="LabelTitolo"></h3>
                                    </div>
                                    <div class="col-md-6">

                                        <asp:Button ID="ButtonAnnulla" CssClass="btn btn-secondary m-l-5 pull-right" runat="server" UseSubmitBehavior="False" OnClientClick="parent.document.location=parent.document.location;" />
                                        <asp:Button ID="ButtonSalva" CssClass="btn btn-success m-l-5 pull-right" runat="server" OnClick="ButtonSalva_Click" />
                                    </div>
                                </div>

                                <input type="hidden" id="fieldChanged" runat="server" value="0" />
                                <input type="hidden" id="hidCliente" runat="server" />

                                <hr />

                                <div class="card-body">

                                    <div class="row">

                                        <div id="divUTE_ID_UTENTE" runat="server" class="col-md-12">
                                            <div class="row form-group">
                                                <label id="LabelUTE_ID_UTENTE" runat="server" class="control-label col-md-4"></label>    
                                                <div class="col-md-8">
                                                    <div class="controls">            
                                                        <asp:DropDownList id="txtUTE_ID_UTENTE" runat="server" CssClass="form-control required" />
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


        //$('#form1').validate({
        //    // Override generation of error label
        //    errorPlacement: function (error, element) { },
        //    highlight: function (element) { $(element).addClass("validatorError"); },
        //    unhighlight: function (element) { $(element).removeClass("validatorError"); },

        //    rules: {
        //        txtNomeCampo: {
        //            required: true
        //        },
        //        txtPagina: {
        //            required: true
        //        },
        //        txtTipo: {
        //            required: true
        //        },
        //        txtChiaveDizionario: {
        //            required: true
        //        }
        //    }
        //});

        //$("#form1").FormObserve({
        //    changeClass: "changed"
        //});
    });
</script>
