$(document).ready(function () {
    $(".btnRicerca").click(function () { $(".right-sidebar").slideDown(50), $(".right-sidebar").toggleClass("shw-rside") })
    $("#DropDownListRecordPagina").addClass("custom-select");
});

function openModal(url, acronimo) {
    switch (acronimo) {
        case "UTE":
        case "UTE_CLI":
            $("#iframeEditorModal").attr("height", "700px");
            break;
        case "RUL_UTE":
        case "AUT_UTE":
        case "UTE_AUT":
        case "UTE_WRF":
            $("#iframeEditorModal").attr("height", "350px");
            break;
    }
    $(".modal-dialog").addClass("modal-xl");
    $(".modal-dialog").removeClass("modal-lg");

    $("#iframeEditorModal").attr("src", url);
    $("#iframeEditorModal").show();
}

function toggleAllFrame(iframeId) {

    $('#iFrameRuoli').hide();   //nascondo tutti gli iFrame

    $('#' + iframeId).show();   //visualizzo solo quello cliccato

    $('#iFrameRuoli').attr('src', '../RuoliUtente/frm_MSB_URL.aspx?UTE_ID_UTENTE=' + $('#idRecord').val());    //setto il src
}

function SetCheckCount(IdElement, idRow) {
    var num = Number(document.getElementById("TextCountSel").value);
    var valRow = document.getElementById(IdElement).checked;
    var valHidden = "val_" + idRow + ";";
    if (valRow == true) {
        document.getElementById("TextCountSel").value = (Number(num) + 1);
        document.getElementById("fieldSelected").value += valHidden;
    }
    else {
        document.getElementById("TextCountSel").value = (Number(num) - 1);
        var fieldSel = document.getElementById("fieldSelected").value;
        if (fieldSel.indexOf(valHidden) >= 0) {
            fieldSel = fieldSel.replace(valHidden, "");
            document.getElementById("fieldSelected").value = fieldSel;
        }
    }
}

function ConfirmResetPwd() {
    var num = Number(document.getElementById("TextCountSel").value);
    if (num == 0) {
        alert("Attenzione non ci sono utenti selezionati.");
        return false;
    }
    else {
        if (confirm("Confermi il reset e re-invio delle password per gli utenti selezionati?\nGli utenti selezionati sono: " + num))
            return true;
        else
            return false;
    }
    return false;
}

function viewSubBrowser(acronimo) {
    /// <summary>
    /// Visualizza il subbrowser con iFrame solo di tipo editor (quelli con GridView seguono la gestione classica).
    /// </summary>
    /// <param name="acronimo" type="String">Acronimo della funzionalità</param>

    hideSubBrowser();

    if ($('#hIdUtente').val() != '') {

        var src = '';
        switch (acronimo) {
            case 'TRY':
                $('#ButtonTravelPolicy').addClass('tabSelected');
                $('#ButtonTravelPolicy').removeClass('tabNoSelected');
                src = '../TravelPolicy/frm_MSE_TRY.aspx?ID_TABELLA_PADRE=' + $('#hIdUtente').val() + '&TABELLA_PADRE=UTENTE&CLI_ID_CLIENTE=' + $('#hIdCliente').val() + '&MODALITA=EDIT';
                break;
            case 'PAU':
                $('#ButtonProcessoAutorizzativo').addClass('tabSelected');
                $('#ButtonProcessoAutorizzativo').removeClass('tabNoSelected');
                src = '../ProcessoAutorizzativo/frm_MSE_PAU.aspx?ID_TABELLA_PADRE=' + $('#hIdUtente').val() + '&TABELLA_PADRE=UTENTE&CLI_ID_CLIENTE=' + $('#hIdCliente').val() + '&MODALITA=EDIT';
                break;
        }

        $('#SubBrowser0').attr('src', src);
        $('#SubBrowser0').show();
                
        $('#ButtonRuoli').removeClass('tabSelected');
        $('#ButtonAutorizzatori').removeClass('tabSelected');
        $('#ButtonAutorizzati').removeClass('tabSelected');
        $('#ButtonWorkflowAssociati').removeClass('tabSelected');
        $('#ButtonClientiAssociati').removeClass('tabSelected');
        $('#ButtonCDCPeriodici').removeClass('tabSelected');

        $('#PanelCliAssociati').hide();
        $('#PanelAutorizzatoriUtente').hide();
        $('#PanelAutorizzatiUtente').hide();
        $('#PanelWfAssociati').hide();
        $('#PanelRuoliUtente').hide();
    }
}

function hideSubBrowser() {
    /// <summary>
    /// Svuota e nasconde il pannello SubBrowser0.
    /// Reset dei Tab collegati al SubBrowser0.
    /// </summary>

    $('#SubBrowser0').attr('src', '../blank.html');
    $('#SubBrowser0').hide();

    $('#ButtonTravelPolicy').removeClass('tabSelected');
    $('#ButtonTravelPolicy').addClass('tabNoSelected');

    $('#ButtonProcessoAutorizzativo').removeClass('tabSelected');
    $('#ButtonProcessoAutorizzativo').addClass('tabNoSelected');
}