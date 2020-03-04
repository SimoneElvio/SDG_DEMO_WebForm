<%@ Page Language="C#" CodeBehind="frm_MSE_UTE.aspx.cs" Inherits="Web_Utenti_frm_MSE_UTE" %>
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
    <script src="../JScript/date.js" type="text/javascript"></script>    <script src="../assets/plugins/jqueryui/jquery-ui.min.js" type="text/javascript"></script>        <script src="../assets/plugins/jqueryui/datepicker-it.js" type="text/javascript"></script>    
    <script src="../assets/plugins/jquery-mask/jquery.mask.js"></script>

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
                
                    <!-- ============================================================== -->
                    <!-- Start Page Content -->
                    <!-- ============================================================== -->
                    
                    <%--<asp:ScriptManager ID="CustomScriptManager" runat="server" EnablePartialRendering="false" LoadScriptsBeforeUI="true" EnablePageMethods="true" CombineScripts="false"></asp:ScriptManager>--%>


                    <cc1:ToolkitScriptManager ID="CustomScriptManager" runat="server" EnablePartialRendering="true" EnablePageMethods="true" LoadScriptsBeforeUI="True" CombineScripts="True"></cc1:ToolkitScriptManager>        

                    <asp:HiddenField ID="hExistDominio" runat="server" />
                    <asp:HiddenField ID="hDominio" runat="server" />

                    <div class="row">            

                        <div class="col-lg-12">

                            <div class="card">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h3 runat="server" id="LabelTitolo"></h3>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="ButtonAnnulla" CssClass="btn btn-secondary m-l-5 pull-right" runat="server" UseSubmitBehavior="False" OnClientClick="parent.refreshBrowser();" />
                                        <asp:Button ID="ButtonSalva" CssClass="btn btn-success m-l-5 pull-right" runat="server" OnClick="ButtonSalva_Click" />
                                        <asp:Button ID="ButtonInviaPwd" CssClass="btn btn-info m-l-5 pull-right" runat="server" OnClick="ButtonInviaPwd_Click" />
                                    </div>
                                </div>

                                <hr />

                                <div class="card-body">
                                                                                              
                                    <div class="row">

                                        <div class="col-md-12" runat="server" visible="false" id="divRecordError">
                                            <div class="alert alert-danger mb-2">
                                                <small runat="server" id="lblMessaggioError"></small>
                                            </div>
                                        </div>

                                        <div id="divNome" runat="server" class="col-md-6">
                                            <div class="row form-group">                               
                                                <label id="LabelNome" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextNome" type="text" runat="server" class="form-control required" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divCognome" runat="server" class="col-md-6">
                                            <div class="row form-group">                               
                                                <label id="LabelCognome" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextCognome" type="text" runat="server" class="form-control required" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="div_ute_data_nascita" runat="server" class="col-md-6">
                                            <div class="row form-group">                               
                                                <label id="Label_ute_data_nascita" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:TextBox runat="server" ID="ute_data_nascita" CssClass="form-control datepicker  col-sm-8"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="div_ute_sesso" runat="server" class="col-md-6">
                                            <div class="row form-group">                               
                                                <label id="Label_ute_sesso" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                         <asp:DropDownList id="ute_sesso" runat="server" class="form-control custom-select required">
                                                         </asp:DropDownList>   
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divMatricola" runat="server" class="col-md-6">
                                            <div class="row form-group">                     
                                                <label id="LabelMatricola" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextMatricola" type="text" runat="server" class="form-control required" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divUnitaContabile" runat="server" class="col-md-6">
                                            <div class="row form-group" id="spanUnitaContabile" runat="server"> 
                                                <label id="LabelUnitaContabile" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList id="DropDownListUnitaContabile" runat="server" class="form-control custom-select" />        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divCategoria" runat="server" class="col-md-6">
                                            <div class="row form-group" id="spanCategoria" runat="server">
                                                <label id="LabelCategoria" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList id="DropDownListCategoria" runat="server" class="form-control custom-select" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divReparto" runat="server" class="col-md-6">
                                            <div id="spanReparto" class="box" runat="server">
                                                <div class="row form-group">
                                                    <label id="LabelReparto" runat="server" class="control-label col-md-4"></label>
                                                    <div class="col-md-8">
                                                        <div class="controls">
                                                            <asp:DropDownList id="DropDownListReparto" runat="server" class="form-control custom-select" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divCliente" runat="server" class="col-md-6">
                                            <div class="row form-group" id="spanCliente" runat="server">
                                                <label id="LabelCliente" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList id="DropDownListCliente" onchange="changeCliente(this.options[this.selectedIndex].value)" runat="server" AutoPostBack="true" CssClass="form-control custom-select required" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">

                                        <div id="divSocieta" runat="server" class="col-md-6">
                                            <div class="row form-group">
                                                <label id="LabelSocieta" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList id="DropDownListSocieta" runat="server" CssClass="form-control custom-select required" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divCDC" runat="server" class="col-md-6">

                                        <asp:UpdatePanel ID="UpdatePanelCDC" UpdateMode="Conditional" runat="server" >        
                                        <Triggers><asp:AsyncPostBackTrigger ControlID="DropDownListCliente" /></Triggers> 
                                        <ContentTemplate>

                                            <div class="row form-group" id="spanCDCAppartenenza" runat="server">
                                                <label id="LabelCDCAppartenenza" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList id="DropDownListCDCAppartenenza" runat="server" CssClass="form-control custom-select" />
                                                    </div>
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                        </asp:UpdatePanel>

                                        </div>

                                        <div id="divGruppoCliente" runat="server" class="col-md-6">
                                            <div class="row form-group">
                                                <label id="LabelGruppoCliente" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList id="DropDownListGruppoCliente" runat="server" CssClass="form-control custom-select" disabled="disabled" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divDescrizione" runat="server" class="col-md-6">
                                            <div class="row form-group">        
                                            <label id="LabelDescrizione" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <textarea id="TextAreaDescrizione" rows="2" runat="server" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">

                                        <div id="divUser" runat="server" class="col-md-6">
                                            <div class="row form-group">
                                                <label id="LabelUser" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextUser" type="text" runat="server" class="form-control required" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divPassword" runat="server" class="col-md-6">
                                            <div class="row form-group">        
                                                <label id="LabelPassword" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextPassword" type="text" runat="server" maxlength="30" class="form-control" readonly="readonly" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divPwdInviata" runat="server" class="col-md-6">
                                            <div class="row form-group">        
                                                <label id="LabelPwdInviata" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:CheckBox ID="CheckBoxPwdInviata" runat="server" disabled="disabled" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divDataInvioPwd" runat="server" class="col-md-6">
                                            <div class="row form-group">        
                                                <label id="LabelDataInvioPwd" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextDataInvioPwd" type="text" runat="server" class="form-control" disabled="disabled" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divExpirationDate" runat="server" class="col-md-6">
                                            <div class="row form-group">
                                                <label id="LabelExpirationDate" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextExpirationDate" type="text" runat="server" class="form-control datepicker" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divTelefono" runat="server" class="col-md-6">
                                            <div class="row form-group"> 
                                                <label id="LabelTelefono" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextTelefono" type="text" runat="server" maxlength="25" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divFax" runat="server" class="col-md-6" visible="false">
                                            <div class="row form-group" id="spanFax" runat="server">
                                                <label id="LabelFax" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextFax" type="text" runat="server" maxlength="25" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divEmail" runat="server" class="col-md-6">
                                            <div class="row form-group">
                                                <label id="LabelEmail" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextEmail" type="text" runat="server" maxlength="100" class="form-control required" style="width:150px;float:left" /><div id="divDominioEmail" runat="server" style="margin-top:3px"></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divAutorizzazioneAutomatica" runat="server" class="col-md-6">
                                            <div class="row form-group"> 
                                                <label id="LabelAutorizzazioneAutomatica" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:CheckBox ID="CheckBoxAutorizzazioneAutomatica" runat="server" />     
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divAvvisoWorkflow" runat="server" class="col-md-6">
                                            <div class="row form-group" id="spanWf" runat="server">        
                                                <label id="LabelWorkflow" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:DropDownList id="DropDownListWorkflow" runat="server" class="form-control custom-select" />
                                                        <small id="LabelAvvisoWorkflow" runat="server" style="color:red;" class="control-label"></small>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divStatoUtente" runat="server" class="col-md-6">
                                            <div class="row form-group">        
                                                <label id="LabelStatoUtente" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:CheckBox ID="CheckBoxStatoUtente" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divBypassImport" runat="server" class="col-md-6" visible="false">
                                            <div class="row form-group">
                                                <label id="LabelBypassImport" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <asp:CheckBox ID="CheckBoxBypassImport" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divAccessiErrati" runat="server" class="col-md-6" visible="false">
                                            <div class="row form-group">
                                                <label id="LabelAccessiErrati" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextAccessiErrati" type="text" runat="server" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divTipoUtente" runat="server" class="col-md-6">
                                            <div class="row form-group">        
                                                <label id="LabelTipoUtente" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextTipoUtente" type="text" runat="server" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div id="divDataUltimoAccesso" runat="server" class="col-md-6">
                                            <div class="row form-group">
                                                <label id="LabelDataUltimoAccesso" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextDataUltimoAccesso" type="text" runat="server" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divDataAggiornamento" runat="server" class="col-md-6">
                                            <div class="row form-group">        
                                                <label id="LabelDataAggiornamento" runat="server" class="control-label col-md-4"></label>
                                                <div class="col-md-8">
                                                    <div class="controls">
                                                        <input id="TextDataAggiornamento" type="text" runat="server" class="form-control" />
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

<script type="text/javascript" src="../Jscript/jquery.formobserver.js"></script>	
<script type="text/javascript" src="../Jscript/jquery.validate.js"></script>

<script type="text/javascript">

$(document).ready(function() {
    
    documentReadyEditorBO();

    // Mask
    $(".datepicker").mask("99/99/9999", { placeholder: 'gg/mm/aaaa' });
    $(".datepicker").blur(function () { checkYear($(this).attr("id")); });

    $.validator.addClassRules({ "datepicker": { dateMaskedITA: true } });
    $.validator.addClassRules({ "time": { minuteMaskedITA: true } });
    $.validator.addClassRules({ "consecutiveDate": { validConsecutiveDate: true } });

    $.validator.methods.validConsecutiveDate = function (value, element, param) { return compareConsecutiveDate(element); };

    $('.datepicker').datepicker({
        showOn: 'button',
        buttonImage: "../Images/calendar.gif",
        buttonImageOnly: false
    });

    $(".ui-datepicker-trigger").addClass("fa fa-calendar-alt");
    //
    
 	$("#form1").validate({
 	    rules: {
 	        TextNome: {
 	            required: true,
 	            maxlength: 100
 	        },
 	        TextCognome: {
 	            required: true,
 	            maxlength: 100
 	        },
 	        TextUser: {
 	            required: true,
 	            maxlength: 100
 	        },
 	        TextEmail: {
 	            required: true,
 	            maxlength: 100
 	        },
 	        TextMatricola: {
 	            required: true,
 	            maxlength: 100
 	        },
 	        TextCodiceIndividuale: {
 	            required: true,
 	            maxlength: 100
 	        },
 	        DropDownListCliente: {
 	            required: true
 	        }
 	    },
 	    messages: {
 	        TextNome: {
 	            required: msgOBBLIGATORIO,
 	            maxlength: msgLUNGHEZZA_MAX + "100"
 	        },
 	        TextCognome: {
 	            required: msgOBBLIGATORIO,
 	            maxlength: msgLUNGHEZZA_MAX + "100"
 	        },
 	        TextUser: {
 	            required: msgOBBLIGATORIO,
 	            maxlength: msgLUNGHEZZA_MAX + "100"
 	        },
 	        TextEmail: {
 	            required: msgOBBLIGATORIO,
 	            maxlength: msgLUNGHEZZA_MAX + "100"
 	        },
 	        TextMatricola: {
 	            required: msgOBBLIGATORIO,
 	            maxlength: msgLUNGHEZZA_MAX + "100"
 	        },
 	        TextCodiceIndividuale: {
 	            required: msgOBBLIGATORIO,
 	            maxlength: msgLUNGHEZZA_MAX + "100"
 	        },
 	        DropDownListCliente: {
 	            required: msgOBBLIGATORIO

 	        }
 	    }
 	});
 	$('#form1').FormObserve({
 	    changeClass: "changed"
 	});
});


function changeCliente(idCliente) {
    if (idCliente != "") {
        var r = SyncPageMethod("getDominioMailCliente", "{idCliente:" + idCliente + "}");
        if (r != "") {
            document.getElementById("divDominioEmail").innerHTML = r;
            document.getElementById("hExistDominio").value = 1;
            document.getElementById("hDominio").value = r;
        }
        else {
            document.getElementById("divDominioEmail").innerHTML = "Nessun dominio.";
            document.getElementById("hExistDominio").value = 0;
            document.getElementById("hDominio").value = "Nessun dominio.";
        }
    }
    else {
        document.getElementById("divDominioEmail").innerHTML = "Nessun dominio.";
        document.getElementById("hExistDominio").value = 0;
        document.getElementById("hDominio").value = "Nessun dominio.";
    }
}
         
</script>

