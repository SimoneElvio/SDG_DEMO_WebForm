<%@ Page Language="C#" CodeBehind="frm_MSB_UTE.aspx.cs" Inherits="Web_Utenti_frm_MSB_UTE" AutoEventWireup="True" %>

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
                        <div class="col-md-6">
                            <h3 runat="server" id="LabelTitolo"></h3>
                        </div>
                        <div class="col-md-6">

                            <asp:Button ID="btnExport" runat="server" CssClass="hide" UseSubmitBehavior="false" />

                            <div id="toolbar" runat="server" class="pull-right">

                                <span title="Visualizza Ricerca Avanzata" class="btn btnRicerca btn-info pull-right" id="imgViewSearch" runat="server"><i class="fa fa-search"></i></span>

                                <div class="btn-group pull-right mr-2">
                                    <button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="ti-settings"></i>
                                    </button>
                                    <div class="dropdown-menu">
                                        <asp:Button ID="ButtonDisconnectAll" runat="server" Text="Disconnetti Tutti" CssClass="dropdown-item" OnClick="ButtonDisconnectAll_Click" OnClientClick="if(confirm('Sei sicuro di voler disconnettere tutti gli utenti collegati?')){return true;}else{return false;}" UseSubmitBehavior="false" />
                                        <asp:Button ID="ButtonFiltroUtente" runat="server" Text="Filtro" Visible="false" UseSubmitBehavior="false" />
                                        <asp:Button ID="ButtonUploadUtenti" runat="server" Text="Upload Utenti" CssClass="dropdown-item" UseSubmitBehavior="false" />
                                        <asp:Button ID="ButtonExportUtenti" runat="server" Text="Export" CssClass="dropdown-item" UseSubmitBehavior="false" />
                                        <asp:Button ID="ButtonInviaResetPwd" runat="server" CssClass="dropdown-item" UseSubmitBehavior="false" OnClick="ButtonInviaResetPwd_Click" OnClientClick="javascript:if(!ConfirmResetPwd()){return false;}" />
                                    </div>
                                </div>

                                <button data-toggle='modal' data-target='#modalServizio' title="nuovo" class="btn btn-success pull-right mr-2 btnFaNuovo" id="ButtonNuovoUtente" runat="server"></button>
                                <asp:Button ID="btnRefresh" OnClick="btnRefresh_Click" runat="server" Style="display: none" />
                            </div>

                        </div>
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
                                            | 
                                        <label id="LabelElemSel" runat="server"></label>
                                            :
                                        <input type="text" runat="server" id="TextCountSel" value="0" class="b-0" readonly="readonly" />
                                        </div>
                                        <div class="col-lg-6">
                                            <label runat="server" id="LabelNroRecord" class="pull-right"></label>
                                        </div>

                                    </div>

                                    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" EnablePageMethods="true" ScriptMode="Release" LoadScriptsBeforeUI="false"></asp:ScriptManager>

                                    <input id="EffettuaRefresh" type="hidden" runat="server" />
                                    <input id="hPanelToRefresh" type="hidden" runat="server" />
                                    <input id="hWhereClause" type="hidden" runat="server" />
                                    <input id="fieldSelected" type="hidden" runat="server" value="" />
                                    <input type="submit" id="btnSubmit" style="display: none" />

                                    <MyAsp:MyGridView ID="GridViewUtenti" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                        CssClass="table table-hover table-bordered table-striped color-table success-table" EnableViewState="True"
                                        OnPreRender="GridView_PreRender">

                                        <Columns>

                                            <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                <ItemTemplate>
                                                    <MyLinkButton:skmLinkButton ID="ButtonDeleteUtenti" runat="server" CommandName="DELETE_COMMAND" ConfirmMessage="DELETE RECORD?" ShowConfirm="True" StatusBarText="Deleting record" CausesValidation="False"></MyLinkButton:skmLinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="ButtonEditUtenti" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="UTE_ID_UTENTE" SortExpression="UTE_ID_UTENTE" Visible="false" />
                                            <asp:BoundField DataField="UTE_STATO_UTENTE" SortExpression="UTE_STATO_UTENTE" Visible="false" />

                                            <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="CheckBoxSelAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBoxSelAll_OnCheckedChanged" />
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxSelezioneUtente" runat="server" Enabled="True" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <i id="imgStatoUtente" runat="server"></i>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="UTE_COGNOME" SortExpression="UTE_COGNOME" />
                                            <asp:BoundField DataField="UTE_NOME" SortExpression="UTE_NOME" />
                                            <asp:BoundField DataField="UTE_USER_ID" SortExpression="UTE_USER_ID" />
                                            <asp:BoundField DataField="UTE_EMAIL" SortExpression="UTE_EMAIL" />
                                            <asp:BoundField DataField="CDC_DESCRIZIONE" SortExpression="CDC_DESCRIZIONE" />
                                            <asp:BoundField DataField="UTE_ULTIMO_ACCESSO" SortExpression="UTE_ULTIMO_ACCESSO" />
                                            <asp:BoundField DataField="CLI_RAGIONE_SOCIALE" SortExpression="CLI_RAGIONE_SOCIALE" />

                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <i id="imgOnline" runat="server"></i>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>

                                        <SelectedRowStyle CssClass="selectedRowGridView" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle CssClass="GridViewPaginationLink" HorizontalAlign="Right" />

                                    </MyAsp:MyGridView>

                                    <asp:ObjectDataSource ID="ObjectDataSourceUtenti" runat="server"></asp:ObjectDataSource>

                                    <asp:UpdatePanel UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>

                                            <input type="hidden" runat="server" id="hIdCliente" />
                                            <input type="hidden" runat="server" id="hIdUtente" />

                                            <div id="tabPanel">
                                                <asp:Button CssClass="tabDisabled" ID="ButtonRuoli" runat="server" OnClientClick="hideSubBrowser();" OnClick="ButtonRuoli_Click" UseSubmitBehavior="false"></asp:Button>
                                                <asp:Button CssClass="tabDisabled" ID="ButtonProcessoAutorizzativo" runat="server" OnClientClick="viewSubBrowser('PAU');return false;" ></asp:Button>
                                            </div>

                                            <!-- Pannello Ruoli Utente -->

                                            <asp:Panel ID="PanelRuoliUtente" runat="server" Visible="true">

                                                <div class="row m-t-15 m-b-15">
                                                    <div class="col-md-6">
                                                        <h3 id="LabelTitoloRuoloUtente" runat="server"></h3>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Button ID="ButtonFiltroRuoloUtente" runat="server" Text="Filtro" Visible="false" UseSubmitBehavior="false" CssClass="btn pull-right" />
                                                        <asp:Button ID="ButtonNuovoRuoloUtente" runat="server" Text="Nuovo" Visible="false" UseSubmitBehavior="false" CssClass="btn btn-success pull-right" />
                                                    </div>
                                                </div>

                                                <div class="row headerBrowser">
                                                    <div class="col-md-12">
                                                        <span runat="server" id="nroRecordRuoliUtente"></span>
                                                        <asp:DropDownList ID="DropDownListRecPaginaRuoloUtente" runat="server" AutoPostBack="true" CssClass="custom-select" />
                                                        <label id="LabelRecPaginaRuoloUtente" runat="server" for="DropDownListRecPagina"></label>
                                                    </div>
                                                </div>

                                                <MyAsp:MyGridView ID="GridViewRuoliUtente" runat="server" AllowPaging="True" AllowSorting="True"
                                                    CssClass="table table-hover table-bordered table-striped color-table success-table"
                                                    AutoGenerateColumns="False" ColorMouseOverRow="">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <MyLinkButton:skmLinkButton CssClass="buttonRowBrowser" ID="ButtonDeleteRuoliUtenti" Text="X" runat="server" CommandName="DELETE_COMMAND" ConfirmMessage="DELETE RECORD?" ShowConfirm="True" StatusBarText="Deleting record" CausesValidation="False">
                                                                </MyLinkButton:skmLinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="ButtonEditRuoliUtente" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="URL_ID_RUOLI_UTENTE" SortExpression="URL_ID_RUOLI_UTENTE" Visible="false" />
                                                        <asp:BoundField DataField="RUL_RUOLO" SortExpression="RUL_RUOLO" />
                                                        <asp:BoundField DataField="URL_DATA_ASSEGNAZIONE" SortExpression="URL_DATA_ASSEGNAZIONE" />
                                                        <asp:BoundField DataField="URL_DATA_DISABILITAZIONE" SortExpression="URL_DATA_DISABILITAZIONE" />
                                                        <asp:BoundField DataField="URL_STATO_RUOLO_UTENTE" SortExpression="URL_STATO_RUOLO_UTENTE" Visible="false" />

                                                        <asp:TemplateField HeaderText="URL_STATO_RUOLO_UTENTE" HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBoxStatoRuolo" runat="server" Enabled="False" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                    <SelectedRowStyle CssClass="selectedRowGridView" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <PagerStyle CssClass="GridViewPaginationLink" />

                                                </MyAsp:MyGridView>

                                                <asp:ObjectDataSource ID="ObjectDataSourceRuoliUtente" runat="server"></asp:ObjectDataSource>

                                            </asp:Panel>

                                            <asp:Panel ID="PanelAutorizzatiUtente" runat="server" Visible="false">

                                                <div class="row m-t-15 m-b-15">
                                                    <div class="col-md-6">
                                                        <h3 id="LabelTitoloAutorizzati" runat="server"></h3>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Button ID="ButtonFiltroAutorizzati" runat="server" Text="Filtro" Visible="false" CssClass="btn pull-right" />
                                                        <asp:Button ID="ButtonNuovoAutorizzati" runat="server" Text="Nuovo" Visible="false" CssClass="btn btn-success pull-right" />
                                                    </div>
                                                </div>

                                                <div class="row headerBrowser">
                                                    <div class="col-md-12">
                                                        <span runat="server" id="nroRecordAutorizzati"></span>
                                                        <asp:DropDownList ID="DropDownListRecPaginaAutorizzati" runat="server" AutoPostBack="True" CssClass="custom-select" />
                                                        <label id="LabelRecPaginaAutorizzati" runat="server" for="DropDownListRecPaginaAutorizzati"></label>
                                                    </div>
                                                </div>

                                                <MyAsp:MyGridView ID="GridViewAutorizzati" runat="server" AllowPaging="True" AllowSorting="True"
                                                    CssClass="table table-hover table-bordered table-striped color-table success-table"
                                                    AutoGenerateColumns="False" ColorMouseOverRow="">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <MyLinkButton:skmLinkButton CssClass="buttonRowBrowser" ID="ButtonDeleteAutorizzati" Text="Cancella" runat="server" CommandName="DELETE_COMMAND" ConfirmMessage="DELETE RECORD?" ShowConfirm="True" StatusBarText="Deleting record" CausesValidation="False">
                                                                </MyLinkButton:skmLinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="UTENTE_AUTORIZZATO" SortExpression="UTENTE_AUTORIZZATO" />
                                                        <asp:BoundField DataField="TIPO_AUTORIZZAZIONE" SortExpression="TIPO_AUTORIZZAZIONE" />
                                                        <asp:BoundField DataField="LIVELLO" SortExpression="LIVELLO" />
                                                        <asp:BoundField DataField="CENTRO_DI_COSTO" SortExpression="CENTRO_DI_COSTO" />
                                                        <asp:BoundField DataField="AUI_FLAG_AUTORIZZATORE_PRINC" SortExpression="AUI_FLAG_AUTORIZZATORE_PRINC" Visible="false" />

                                                        <asp:TemplateField HeaderText="CRP_FLAG_AUTORIZZATI_PRINC" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBoxPrincipale" runat="server" Enabled="False" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                    </Columns>

                                                    <SelectedRowStyle CssClass="selectedRowGridView" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <PagerStyle CssClass="GridViewPaginationLink" />

                                                </MyAsp:MyGridView>

                                                <asp:ObjectDataSource ID="ObjectDataSourceAutorizzati" runat="server"></asp:ObjectDataSource>

                                            </asp:Panel>

                                            <!-- Pannello Workflow Associati Utente -->

                                            <asp:Panel ID="PanelWfAssociati" runat="server" Visible="false">

                                                <div class="row m-t-15 m-b-15">
                                                    <div class="col-md-6">
                                                        <h3 id="labelTitoloWfAssociati" runat="server"></h3>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Button ID="ButtonFiltroWfAssociati" runat="server" Text="Filtro" Visible="false" CssClass="btn pull-right" />
                                                        <asp:Button ID="ButtonNuovoWfAssociato" runat="server" Text="Nuovo" Visible="false" CssClass="btn btn-success pull-right" />
                                                    </div>
                                                </div>

                                                <div class="row headerBrowser">
                                                    <div class="col-md-12">
                                                        <span runat="server" id="nroRecordWfAssociati"></span>
                                                        <asp:DropDownList ID="DropDownListRecPaginaWfAssociati" runat="server" AutoPostBack="True" CssClass="custom-select" />
                                                        <label id="LabelRecPaginaWfAssociati" runat="server" for="DropDownListRecPaginaWfAssociati"></label>
                                                    </div>
                                                </div>

                                                <MyAsp:MyGridView ID="GridViewWfAssociati" runat="server" AllowPaging="True" AllowSorting="True"
                                                    CssClass="table table-hover table-bordered table-striped color-table success-table"
                                                    AutoGenerateColumns="False" ColorMouseOverRow="">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <MyLinkButton:skmLinkButton CssClass="buttonRowBrowser" ID="ButtonDeleteWfAssociati" Text="Cancella" runat="server" CommandName="DELETE_COMMAND" ConfirmMessage="DELETE RECORD?" ShowConfirm="True" StatusBarText="Deleting record" CausesValidation="False">
                                                                </MyLinkButton:skmLinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="WRF_CODICE" SortExpression="WRF_CODICE" />
                                                        <asp:BoundField DataField="WRF_DESCRIZIONE" SortExpression="WRF_DESCRIZIONE" />
                                                    </Columns>
                                                    <SelectedRowStyle CssClass="selectedRowGridView" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <PagerStyle CssClass="GridViewPaginationLink" />
                                                </MyAsp:MyGridView>

                                                <asp:ObjectDataSource ID="ObjectDataSourceWfAssociati" runat="server"></asp:ObjectDataSource>

                                            </asp:Panel>

                                            <!-- Pannello Clienti Associati Utente -->

                                            <asp:Panel ID="PanelCliAssociati" runat="server" Visible="false">

                                                <div class="row m-t-15 m-b-15">
                                                    <div class="col-md-6">
                                                        <h3 id="labelTitoloCliAssociati" runat="server"></h3>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Button ID="ButtonFiltroCliAssociati" runat="server" Text="Filtro" Visible="false" CssClass="btn pull-right" />
                                                        <asp:Button ID="ButtonNuovoCliAssociato" runat="server" Text="Nuovo" Visible="false" CssClass="btn btn-success pull-right" />
                                                    </div>
                                                </div>


                                                <div class="row headerBrowser">
                                                    <div class="col-md-12">
                                                        <span runat="server" id="nroRecordCliAssociati"></span>
                                                        <label id="LabelRecPaginaCliAssociati" runat="server" for="DropDownListRecPaginaCliAssociati"></label>
                                                        <asp:DropDownList ID="DropDownListRecPaginaCliAssociati" runat="server" AutoPostBack="True" CssClass="custom-select" />
                                                    </div>
                                                </div>

                                                <asp:GridView ID="GridViewCliAssociati" runat="server" AllowPaging="True" AllowSorting="True"
                                                    CssClass="table table-hover table-bordered table-striped color-table success-table"
                                                    AutoGenerateColumns="False" ColorMouseOverRow="">
                                                    <EmptyDataTemplate>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <MyLinkButton:skmLinkButton CssClass="buttonRowBrowser" ID="ButtonDeleteCliAssociati" Text="Cancella" runat="server" CommandName="DELETE_COMMAND" ConfirmMessage="DELETE RECORD?" ShowConfirm="True" StatusBarText="Deleting record" CausesValidation="False">
                                                                </MyLinkButton:skmLinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="ButtonEditClientiAssociati" CssClass="buttonRowBrowser" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="CLI_RAGIONE_SOCIALE" SortExpression="CLI_RAGIONE_SOCIALE" />
                                                        <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBoxStatoCliente" runat="server" Enabled="False" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <SelectedRowStyle CssClass="selectedRowGridView" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <PagerStyle CssClass="GridViewPaginationLink" />
                                                </asp:GridView>

                                                <asp:ObjectDataSource ID="ObjectDataSourceCliAssociati" runat="server"></asp:ObjectDataSource>

                                            </asp:Panel>

                                            <!-- Pannello Centri di Costo Periodici Utente -->

                                            <asp:Panel ID="PanelCDCPeriodici" runat="server" Visible="false">

                                                <div class="row m-t-15 m-b-15">
                                                    <div class="col-md-6">
                                                        <h3 id="labelTitoloCDCPeriodici" runat="server"></h3>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Button ID="ButtonFiltroCDCPeriodici" runat="server" Text="Filtro" Visible="false" CssClass="btn pull-right" />
                                                        <asp:Button ID="ButtonNuovoCDCPeriodico" runat="server" Text="Nuovo" Visible="false" CssClass="btn btn-success pull-right" />
                                                    </div>
                                                </div>

                                                <div class="row headerBrowser">
                                                    <div class="col-md-12">
                                                        <span runat="server" id="nroRecordCDCPeriodici"></span>
                                                        <label id="LabelRecPaginaCDCPeriodici" runat="server" for="DropDownListRecPaginaCDCPeriodici"></label>
                                                        <asp:DropDownList ID="DropDownListRecPaginaCDCPeriodici" runat="server" AutoPostBack="True" />
                                                    </div>
                                                </div>

                                                <asp:GridView ID="GridViewCDCPeriodici" runat="server" AllowPaging="True" AllowSorting="True"
                                                    CssClass="table table-hover table-bordered table-striped color-table success-table"
                                                    AutoGenerateColumns="False" ColorMouseOverRow="">
                                                    <EmptyDataTemplate>
                                                    </EmptyDataTemplate>

                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <MyLinkButton:skmLinkButton CssClass="buttonRowBrowser" ID="ButtonDeleteCDCPeriodico" Text="Cancella" runat="server" CommandName="DELETE_COMMAND" ConfirmMessage="DELETE RECORD?" ShowConfirm="True" StatusBarText="Deleting record" CausesValidation="False">
                                                                </MyLinkButton:skmLinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-CssClass="colBtn">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="ButtonEditCDCPeriodico" CssClass="buttonRowBrowser" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="CDP_ANNO" SortExpression="CDP_ANNO" />
                                                        <asp:BoundField DataField="CDP_MESE" SortExpression="CDP_MESE" />
                                                        <asp:BoundField DataField="CDP_CODICE_CDC" SortExpression="CDP_CODICE_CDC" />

                                                    </Columns>
                                                    <SelectedRowStyle CssClass="selectedRowGridView" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <PagerStyle CssClass="GridViewPaginationLink" />
                                                </asp:GridView>

                                                <asp:ObjectDataSource ID="ObjectDataSourceCDCPeriodici" runat="server"></asp:ObjectDataSource>

                                            </asp:Panel>


                                            <iframe id="SubBrowser0" frameborder="0" width="100%" height="550" style="display: none" runat="server"></iframe>

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
                        <div class="slimscrollright">
                            <div class="rpanel-title"><i class="fa fa-search"></i> Ricerca <span><i class="ti-close right-side-toggle"></i></span></div>
                            <div class="r-panel-body">

                                <div id="boxRicercaAvanzata" runat="server" class="form-body">

                                    <div class="col-md-12">

                                        <h4></h4>

                                        <label id="LabelCognome" runat="server" visible="false"></label>
                                        <input type="text" class="form-control" id="txtCognome" name="txtCognome" runat="server" placeholder="Cognome" />
                                        <label id="LabelNome" runat="server" visible="false"></label>
                                        <input type="text" class="form-control" id="txtNome" name="txtNome" runat="server" placeholder="Nome" />
                                        <label id="LabelCodiceIndividuale" runat="server" visible="false"></label>
                                        <input type="text" class="form-control" id="txtCodiceIndividuale" name="txtCodiceIndividuale" runat="server" placeholder="Codice individuale" />
                                        <label id="LabelEmail" runat="server" visible="false"></label>
                                        <input type="text" class="form-control" id="txtEmail" name="txtEmail" runat="server" placeholder="Email" />
                                        <label id="LabelUserId" runat="server" visible="false"></label>
                                        <input type="text" class="form-control" id="txtUserId" name="txtUserId" runat="server" placeholder="User id" />
                                        <label id="LabelPwdInviata" runat="server"></label>
                                        <asp:DropDownList ID="txtPwdInviata" class="form-control" runat="server"></asp:DropDownList>
                                        <label id="LabelCliente" runat="server"></label>
                                        <asp:DropDownList ID="txtCliente" class="form-control" runat="server"></asp:DropDownList>

                                        <div class="bt-switch">
                                            <input type="checkbox" data-on-color="info" data-size="small" runat="server" id="chkOnline" />
                                            <label id="LabelOnline" runat="server"></label>
                                            <br />
                                        </div>

                                        <br />
                                        <asp:Button runat="server" ID="btnCerca" OnClick="ButtonCerca_Click" OnClientClick="$('#hCerca').val('1');" CssClass="btn btn-info btn-block" />

                                    </div>

                                </div>
                            </div>
                        </div>
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
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h3 class="modal-title text-themecolor ml-5"><i></i><span id="testataModalServizio" runat="server"></span></h3>

                            <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseModal">
                                <span aria-hidden="true">&times;</span>
                            </button>--%>
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

    <script src="frm_MSB_UTE.js" type="text/javascript"></script>

</body>

</html>
