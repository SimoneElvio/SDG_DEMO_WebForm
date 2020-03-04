<%@ Page Language="C#" CodeBehind="frm_MSB_RUL.aspx.cs" Inherits="Web_Ruoli_frm_MSB_RUL" %>

<%@ Register TagPrefix="MyAsp" Namespace="MyGridViewLibrary" Assembly="SDG" %>
<%@ Register TagPrefix="MyLinkButton" Namespace="skmExtendedControls" Assembly="SDG" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="../Common/Top.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Menu" Src="../Common/Menu.ascx" %>
<%@ Register TagPrefix="uc4" TagName="Script" Src="../Common/Script.ascx" %>

<!DOCTYPE html>
<html lang="en">

<head id="Header" runat="server">
    <title></title>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->

    <style type="text/css">
        #boxField label {
            width: 100px;
        }

        #boxField {
            margin-top: 0;
            width: 250px;
        }

        #boxField2 {
            width: 270px;
            border-left: 1px dotted #ccc;
            border-right: 1px dotted #ccc;
            margin-top: 0;
        }

         #TextCountSel {
            margin-top: -1px;
            margin-left: 2px;
            font-weight: bold;
        }

        #tabPanel {
            border-bottom: 1px solid #ddd;
        }

            #tabPanel input {
                border: 0;
                background: none;
                padding: 15px 20px;
                color: #495057;
                cursor: pointer;
            }

                #tabPanel input.tabSelected {
                    border-bottom: 2px solid #009efb;
                    color: #009efb;
                }
    </style>


</head>


<body class="fix-header fix-sidebar card-no-border" id="msbRiv">

    <!-- ============================================================== -->
    <!-- Main wrapper - style you can find in pages.scss -->
    <!-- ============================================================== -->
    <div id="main-wrapper">

        <form id="form1" runat="server">

            <!-- ============================================================== -->
            <!-- Topbar header -->
            <!-- ============================================================== -->

            <uc1:Top ID="Top" runat="server"></uc1:Top>

            <!-- ============================================================== -->
            <!-- End Topbar header -->
            <!-- ============================================================== -->

            <!-- ============================================================== -->
            <!-- Left Sidebar - style you can find in sidebar.scss  -->
            <!-- ============================================================== -->

            <uc2:Menu ID="Menu" runat="server"></uc2:Menu>

            <!-- ============================================================== -->
            <!-- End Left Sidebar - style you can find in sidebar.scss  -->
            <!-- ============================================================== -->

            <!-- ============================================================== -->
            <!-- Page wrapper  -->
            <!-- ============================================================== -->
            <div class="page-wrapper">

                <!-- ============================================================== -->
                <!-- Container fluid  -->
                <!-- ============================================================== -->
                <div class="container-fluid container-big">

                    <!-- ============================================================== -->
                    <!-- Bread crumb and right sidebar toggle -->
                    <!-- ============================================================== -->
                    <div class="row page-titles">
                        <div class="col-md-6 col-xs-12 align-self-center">
                            <h3 class="text-themecolor m-b-0 m-t-0" runat="server" id="LabelTitolo"></h3>
                        </div>
                        <div class="col-md-6 col-xs-12">

                            <asp:Button ID="btnExport" runat="server" CssClass="hide" UseSubmitBehavior="false" />

                            <div id="toolbar" runat="server" class="pull-right">

                                <div class="btn-group pull-right mr-2">

                                    <input id="EffettuaRefresh" type="hidden" runat="server" />
                                    <input id="hPanelToRefresh" type="hidden" runat="server" />
                                    <input type="hidden" id="fieldChangedFNT" runat="server" value="0" />
                                    <input type="hidden" id="saveFNTPage" runat="server" value="0" />

                                </div>

                                <button data-toggle='modal' data-target='#modalServizio' title="nuovo" class="btn btn-success pull-right mr-2 btnFaNuovo" id="ButtonNuovoRuolo" runat="server"></button>
                                <asp:Button id="btnRefresh" OnClick="btnRefresh_Click" runat="server" style="display:none"  />
                            </div>

                        </div>
                        <!--
                    <div class="col-md-6 col-4 align-self-center">
                        <button class="right-side-toggle waves-effect waves-light btn-info btn-circle btn-sm pull-right m-l-10"><i class="ti-settings text-white"></i></button>
                        <button class="btn pull-right hidden-sm-down btn-success"><i class="mdi mdi-plus-circle"></i> Create</button>                        
                    </div>
                    -->
                    </div>
                    <!-- ============================================================== -->
                    <!-- End Bread crumb and right sidebar toggle -->
                    <!-- ============================================================== -->
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

                                    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" EnablePageMethods="true" ScriptMode="Release" LoadScriptsBeforeUI="false"></asp:ScriptManager>

                                    <MyAsp:MyGridView ID="GridViewRuoli" runat="server" AllowPaging="True" AllowSorting="True"
                                        CssClass="table table-hover table-bordered table-striped color-table success-table"
                                        AutoGenerateColumns="False" GridLines="Horizontal" ColorMouseOverRow="">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                <ItemTemplate>
                                                    <MyLinkButton:skmLinkButton ID="ButtonDeleteRuoli" CssClass="buttonRowBrowser" runat="server" CommandName="DELETE_COMMAND" ConfirmMessage="DELETE RECORD?" ShowConfirm="True" StatusBarText="Deleting record" CausesValidation="False">
                                                    </MyLinkButton:skmLinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="ButtonEditRuoli" class="buttonRowBrowser" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="RUL_RUOLO" SortExpression="RUL_RUOLO" />
                                            <asp:BoundField DataField="RUL_DATA_CREAZIONE" SortExpression="RUL_DATA_CREAZIONE" />

                                        </Columns>
                                        <SelectedRowStyle CssClass="selectedRowGridView" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle CssClass="GridViewPaginationLink" />

                                    </MyAsp:MyGridView>
                                    
                                    <asp:ObjectDataSource ID="ObjectDataSourceRuoli" runat="server"></asp:ObjectDataSource>

                                    <asp:UpdatePanel UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>

                                            <div id="tabPanel">
                                                <asp:Button CssClass="tabDisabled" ID="ButtonUtenti" runat="server" OnClick="ButtonUtenti_Click" UseSubmitBehavior="false"></asp:Button>
                                                <asp:Button CssClass="tabDisabled" ID="ButtonFunzionalita" runat="server" OnClick="ButtonFunzionalita_Click" UseSubmitBehavior="false"></asp:Button>
                                            </div>

                                            <!-- Pannello Utenti Ruolo -->

                                            <asp:Panel ID="PanelUtentiRuolo" runat="server" Visible="true">

                                                <div class="row m-t-15 m-b-15">
                                                    <div class="col-md-6">
                                                        <h3 id="LabelTitoloUtentiRuolo" runat="server"></h3>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Button ID="ButtonNuovoUtenteRuolo" runat="server" Text="Nuovo"  UseSubmitBehavior="false" CssClass="btn btn-success pull-right" />
                                                    </div>
                                                </div>

                                                <div class="row headerBrowser">
                                                    <div class="col-md-6">
                                                        <span runat="server" id="nroRecordUtentiRuolo"></span>
                                                        <asp:DropDownList ID="DropDownListRecPaginaUtentiRuolo" runat="server" AutoPostBack="true" CssClass="custom-select" />
                                                        <label id="LabelRecPaginaUtentiRuolo" runat="server" for="DropDownListRecPaginaUtentiRuolo"></label>
                                                    </div>
                                                </div>


                                                <MyAsp:MyGridView ID="GridViewUtentiRuolo" 
                                                                  runat ="server" 
                                                                  AllowPaging="True" 
                                                                  AllowSorting="True"
                                                                  CssClass="table table-hover table-bordered table-striped color-table success-table"
                                                                  AutoGenerateColumns="False">
                                                    <Columns>


                                                        <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="ButtonEditRuoliUtente" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="URL_ID_RUOLI_UTENTE" Visible="false"  />
                                                        <asp:BoundField DataField="UTE_NOME" SortExpression="UTE_NOME"  />
                                                        <asp:BoundField DataField="UTE_COGNOME" SortExpression="UTE_COGNOME"  />
                                                        <asp:BoundField DataField="UTE_ALIAS" SortExpression="UTE_ALIAS"  Visible="false" />
                                                        <asp:BoundField DataField="UTE_SIGLA" SortExpression="UTE_SIGLA"  />
                                                        <asp:BoundField DataField="UTE_USER_ID" SortExpression="UTE_USER_ID"  />
                                                        <asp:BoundField DataField="URL_STATO_RUOLO_UTENTE" SortExpression="URL_STATO_RUOLO_UTENTE" Visible="false" />

                                                        <asp:TemplateField HeaderText="URL_STATO_RUOLO_UTENTE"   HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBoxStatoRuolo" runat="server" Enabled="False" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                    <SelectedRowStyle CssClass="selectedRowGridView" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <PagerStyle CssClass="GridViewPaginationLink" />

                                                </MyAsp:MyGridView>
                                                <asp:ObjectDataSource ID="ObjectDataSourceUtentiRuolo" runat="server"></asp:ObjectDataSource>

                                            </asp:Panel>

                                            <!-- Pannello Funzionalità -->

                                            <asp:Panel ID="PanelFunzionalita" runat="server" Visible="false">

                                                <div class="row m-t-15 m-b-15">
                                                    <div class="col-md-6">
                                                        <h3 id="LabelFunzionalita" runat="server"></h3>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Button ID="ButtonSalvaFunzionalita" runat="server" Text="Salva"  OnClick="ButtonSalvaFunzionalita_Click" CssClass="btn btn-success m-l-5 pull-right" />
                                                        <asp:Button ID="ButtonNuovoFunzionalita" runat="server" Text="Nuovo" Visible="false" UseSubmitBehavior="false" CssClass="btn btn-success m-l-5 pull-right" />
                                                    </div>
                                                </div>

                                                <div class="row headerBrowser">
                                                    <div class="col-md-6">
                                                        <span runat="server" id="Span1"></span>
                                                        <asp:DropDownList ID="DropDownListRecPaginaFunzionalita" runat="server" AutoPostBack="true" CssClass="custom-select" />
                                                        <label id="LabelRecPaginaFunzionalita" runat="server" for="DropDownListRecPagina"></label>
                                                    </div>
                                                </div>


                                                <MyAsp:MyGridView ID="GridViewFunzionalita" 
                                                     runat ="server" 
                                                     AllowPaging="True" 
                                                     AllowSorting="True"
                                                     CssClass="table table-hover table-bordered table-striped color-table success-table"
                                                     AutoGenerateColumns="False">
                                                    <Columns>

                                                        <asp:BoundField DataField="FNT_ACRONIMO_FUNZIONALITA" SortExpression="FNT_ACRONIMO_FUNZIONALITA"  />
                                                        <asp:BoundField DataField="FNT_DESCRIZIONE" SortExpression="FNT_DESCRIZIONE"  />
                                                        <asp:BoundField DataField="PMS_ID_MODALITA_ACCESSO" SortExpression="PMS_ID_MODALITA_ACCESSO" Visible="false"  />
                                                        <asp:BoundField DataField="FNT_ID_FUNZIONALITA" SortExpression="FNT_ID_FUNZIONALITA" Visible="false"  />
                                                        <asp:BoundField DataField="RUL_ID_RUOLO" SortExpression="RUL_ID_RUOLO" Visible="false"  />
                                                        <asp:BoundField DataField="PMS_DESCRIZIONE" SortExpression="PMS_DESCRIZIONE" Visible="false"  />

                                                        <asp:TemplateField HeaderText="PERMESSO_ACCESSO" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="DropDownListPermessi" DataSource='<%# ObjectDataSourcePermessi %>' DataTextField="PMS_DESCRIZIONE" DataValueField="PMS_ID_MODALITA_ACCESSO" runat="server" CssClass="dropWidthSmall"></asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>

                                                    <SelectedRowStyle CssClass="selectedRowGridView" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <PagerStyle CssClass="GridViewPaginationLink" />

                                                </MyAsp:MyGridView>

                                                <asp:ObjectDataSource ID="ObjectDataSourceFunzionalita" runat="server"></asp:ObjectDataSource>

                                                <asp:ObjectDataSource ID="ObjectDataSourcePermessi" runat="server"></asp:ObjectDataSource>

                                            </asp:Panel>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                        </div>

                    </div>

                    <!-- ============================================================== -->
                    <!-- End PAge Content -->
                    <!-- ============================================================== -->

                    <!-- ============================================================== -->
                    <!-- Right sidebar -->
                    <!-- ============================================================== -->
                    <!-- .right-sidebar -->
                    <div class="right-sidebar">

                    </div>
                    <!-- ============================================================== -->
                    <!-- End Right sidebar -->
                    <!-- ============================================================== -->

                </div>
                <!-- ============================================================== -->
                <!-- End Container fluid  -->
                <!-- ============================================================== -->

                <footer class="footer" id="footer" runat="server"></footer>

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
            <!-- Fine Modal allega file -->

        </form>

    </div>
    <!-- ============================================================== -->
    <!-- End Wrapper -->
    <!-- ============================================================== -->

    <uc4:Script ID="Script" runat="server"></uc4:Script>

    <script>

        $(document).ready(function () {
            //$(".btnRicerca").click(function () { $(".right-sidebar").slideDown(50), $(".right-sidebar").toggleClass("shw-rside") })
            $("#DropDownListRecordPagina").addClass("custom-select");
        });


        function openModal(url, acronimo) {
            switch (acronimo) {
                case "RUL":
                    $("#iframeEditorModal").attr("height", "400px");
                    $(".modal-dialog").addClass("modal-lg");
                    $(".modal-dialog").removeClass("modal-xl");
                    break;
                case "RUL_UTE":
                    $("#iframeEditorModal").attr("height", "700px");
                    break;
            }

            $("#iframeEditorModal").attr("src", url);
            $("#iframeEditorModal").show();
        }

    </script>

</body>

</html>
