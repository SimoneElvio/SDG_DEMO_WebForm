<%@ Page Language="C#" CodeBehind="frm_MSB_CGC.aspx.cs" Inherits="Web_CrossGruppiClienteUtentii_frm_MSB_CGC" AutoEventWireup="True" %>

<%@ Register TagPrefix="MyAsp" Namespace="MyGridViewLibrary" Assembly="SDG" %>
<%@ Register TagPrefix="MyLinkButton" Namespace="skmExtendedControls" Assembly="SDG" %>
<%@ Register TagPrefix="uc4" TagName="Script" Src="../Common/Script.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Browser Standard</title>
    <!--[if lt IE 7]><link href="../Css/IE6_fix.css" rel="stylesheet" type="text/css" media="screen" /><![endif]-->
    <style type="text/css">
       
    </style>

    <script type="text/javascript">
        function confirmDelete() {
            if (confirm('Sei sicuro di cancellare il record selezionato?'))
                return true;
            else
                return false;
        }

    </script>
</head>
<body class="fix-header fix-sidebar card-no-border" id="msbCnc">
    <!-- ============================================================== -->
    <!-- Main wrapper - style you can find in pages.scss -->
    <!-- ============================================================== -->
    <div id="main-wrapper">
        <form id="form1" runat="server">
            <!-- ============================================================== -->
            <!-- Page wrapper  -->
            <!-- ============================================================== -->
            <div class="page-wrapper" style="padding-top:0px;padding-bottom:0px">
                <!-- ============================================================== -->
                <!-- Container fluid  -->
                <!-- ============================================================== -->
                <div class="container-fluid container-big" style="max-width: 100%;">
                    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" EnablePageMethods="true" ScriptMode="Release" LoadScriptsBeforeUI="false"></asp:ScriptManager>

                    <div class="row page-titles">
                        <div class="col-md-6 col-xs-12 align-self-center">
                            <h3 class="text-themecolor m-b-0 m-t-0" runat="server" id="LabelTitolo"></h3>
                        </div>
                        <div class="col-md-6 col-xs-12">

                            <asp:Button ID="btnExport" runat="server" CssClass="hide" UseSubmitBehavior="false" />

                            <div id="toolbar" runat="server" class="pull-right">
                                <button data-toggle='modal' data-target='#modalServizio' title="nuovo" class="btn btn-success pull-right mr-2 btnFaNuovo" id="CreateNewRecord" runat="server"></button>
                            </div>

                        </div>

                    </div>

                    <!-- ============================================================== -->
                    <!-- Start Page Content -->
                    <!-- ============================================================== -->
                    <div class="row">

                        <div class="col-lg-12">
                            <div class="card">
                                <div class="card-body">

                                    <input type="hidden" runat="server" id="hCerca" />

                                    <div class="row" id="headerBrowser" runat="server">

                                        <div class="col-lg-6">
                                            <asp:DropDownList ID="DropDownListRecordPagina" runat="server" AutoPostBack="true" CssClass="custom-select" />
                                            <label id="LabelRecPagina" runat="server" for="DropDownListRecordPagina"></label>
                                        </div>
                                        <div class="col-lg-6">
                                            <label runat="server" id="LabelNroRecord" class="pull-right"></label>
                                        </div>

                                    </div>

                                    <MyAsp:MyGridView ID="GridViewGruppiClienteUtenti" runat="server" AllowPaging="True" AllowSorting="True"
                                        CssClass="table table-hover table-bordered table-striped color-table success-table"
                                        AutoGenerateColumns="False" GridLines="Horizontal">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                <ItemTemplate>
                                                     <MyLinkButton:skmLinkButton ID="ButtonDeleteGruppiClienteUtenti" runat="server" CommandName="DELETE_COMMAND" ConfirmMessage="DELETE RECORD?" ShowConfirm="True" StatusBarText="Deleting record" CausesValidation="False"></MyLinkButton:skmLinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-CssClass="colBtn" Visible="false">
                                                <ItemTemplate>
                                                     <asp:LinkButton ID="ButtonEditGruppiClienteUtenti" class="buttonRowBrowser" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="CGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI" SortExpression="CGC_ID_CROSS_GRUPPI_CLIENTE_UTENTI" Visible="false"  />
                                            <asp:BoundField DataField="UTENTE" SortExpression="UTENTE"  />
                                         
                                           
                                        </Columns>
                                        <SelectedRowStyle CssClass="selectedRowGridView" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle CssClass="GridViewPaginationLink" HorizontalAlign="Right" />
                                    </MyAsp:MyGridView>
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

            <!-- ============================================================== -->
            <!-- MODALE Servizi -->
            <!-- ============================================================== -->

            <div class="modal" id="modalPage">
                <div class="modal-dialog modal-xl" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h3 class="modal-title text-themecolor ml-5"><i></i><span id="testataModalServizio" runat="server"></span></h3>

                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseModal">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body" id="modalServizioBody">
                            <iframe id="iframeEditorModal" style="width: 100%; border: 0;"></iframe>
                        </div>
                        <div class="modal-footer d-none">
                            <button type="button" data-dismiss="modal" id="btnCloseServizio">Close</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Fine Modal file -->
        </form>
    </div>
     <uc4:Script ID="Script" runat="server"></uc4:Script>

    <script type="text/javascript">

        $(document).ready(function () {
            //$(".btnRicerca").click(function () { $(".right-sidebar").slideDown(50), $(".right-sidebar").toggleClass("shw-rside") })
            $("#DropDownListRecordPagina").addClass("custom-select");
        });


        function openModal(url, acronimo) {

            switch (acronimo) {
                case "CGC":
                    $("#iframeEditorModal").attr("height", "350px");
                    $(".modal-dialog").addClass("modal-lg");
                    $(".modal-dialog").removeClass("modal-xl");
                    break;
            }

            $("#iframeEditorModal").attr("src", url);
            $("#iframeEditorModal").show();
        }

    </script>
</body>
</html>
