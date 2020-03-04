// JScript File
// Da includere come ultimo elemento javascript


/// <summary>
/// Costanti per tipologia allegati
/// </summary>
var C_TIPO_ALLEGATO_PRENOTAZIONE_VIAGGIO = 1;
var C_TIPO_ALLEGATO_NOTA_SPESA = 3;

/*
window.onload = function() {

    //disabilita combinazione tasti (CTRL+"n")
    //disableCtrlModifer();

    if (parent.frames.length > 1) {

        //Il controllo sull'esistenza del divLoading è necessario per pagine come l'Help
        if (top.document.getElementById('divLoading')) {
            top.displayLoading(0);
        }

        if (parent.document.getElementById('hViewMenu')) {
            if (parent.document.getElementById('hViewMenu').value == "0") {
                if (document.getElementById('testataViaggiatore') || document.getElementById('dettaglioFatturato') || document.getElementById('testataEvento')) {
                    self.parent.viewHideMenu(0, 0);
                }
                else if (document.getElementById('tblEventi')) {
                    //Questo elseif serve per nascondere il menu e visualizzare la TOP per il profilo eventi.
                }
            }
            else
                self.parent.viewHideMenu(1, 1);
        }

        //Nel caricamento della pagina controllo se sono nella pagina del Report
        if (parent.document.getElementById("divBack")) {
            parent.document.getElementById("divBack").style.display = "none";
        }
    }

    $(document).ready(function() {        
        $('#boxRicercaAvanzata').keypress(function(e) {            
            if (e.keyCode == 13) {
                $('#btnCerca').click();
            }
        });


    });

}
*/

//+----------------------------------------------------------------------------
//
//  Codice eseguito sempre al caricamento della pagina
//
//  Description:    Disabilito Hystory della pagina
//
//-----------------------------------------------------------------------------
window.history.forward(0);

//+----------------------------------------------------------------------------
//
//  Codice eseguito sempre al caricamento della pagina
//
//  Description:    Disabilito tasto destro del mouse
//
//-----------------------------------------------------------------------------
//try
//{
//    $(document).bind("contextmenu",function(e){return false;});
//}
//catch ( e )
//{   
//}

//+----------------------------------------------------------------------------
//
//  disableCtrlModifer
//
//  Description:    Disabilito combinazione tasti
//
//-----------------------------------------------------------------------------
function disableCtrlModifer() {
    $(document).bind('keydown', 'Ctrl+c', function () { alert('copy anyone?'); });
    //$(document).bind('keydown', 'Ctrl+t', false);      //apri nuovo tab
    //$(document).bind('keydown', 'ctrl+n', false);   //apri nuova pagina
}

function trim(str) {
    // Legenda RegExp:
    //(\s = spazio, * = zero o più occorrenze, ^ = inizio input, & = fine input)
    // Il primo replace toglie tutti gli spazi partendo dal primo carattere
    // Il secondo replace toglie poi gli spazi partendo dall'ultimo carattere
    if (str)
        return str.replace(/^\s*/, '').replace(/\s*$/, '');
    else
        return "";
}


function Replace(StringToReplace, StringToChange, StringChangedIn) {
    var re = new RegExp(StringToChange, "ig");
    StringToReplace = StringToReplace.replace(re, StringChangedIn);
    return StringToReplace;
}

function viewHideSearch() {
    if ($('#boxRicercaAvanzata').is(':visible'))
        $("#boxRicercaAvanzata").hide();
    else
        $("#boxRicercaAvanzata").show();
}

//Questa funzione serve per nascondere o visualizzare il div che viene visualizzato quando
//una pagina sta caricando qualcosa o salvando.
function displayLoading(val) {
    if (top.document.getElementById('divLoading')) {
        if (val == 1)
            top.document.getElementById('divLoading').style.display = 'block';
        else
            top.document.getElementById('divLoading').style.display = 'none';
    }
}

//+----------------------------------------------------------------------------
//
//  Function:       base_Js_ApriPopup
//
//  Description:    Funzione che apre una nuova finestra
//
//  Arguments:      
//
//  Returns:        
//                         
//
//-----------------------------------------------------------------------------

var wnd = null;
function Js_ApriPopup(percorso, nomewin, toolbar, location, directories, status, menubar, scrollbars, resizable, left, top, width, height) {
    if (nomewin == "newAddressWindow") {
        uniqueName = new Date();
        nomewin = uniqueName.getTime();
    }
    if (wnd != null) {
        if (wnd.closed || wnd.name != nomewin) {
            wnd = window.open(percorso, nomewin, 'toolbar=' + toolbar + ',location=' + location + ',directories=' + directories + ',status=' + status + ',menubar=' + menubar + ',scrollbars=' + scrollbars + ',resizable=' + resizable + ',left=' + left + ',top=' + top + ',width=' + width + ',height=' + height + '');
        }
        else {
            if (wnd.document.getElementById('fieldChanged').value == 0) {
                wnd.location.href = percorso;
            }
            else {
                //SGA nota: da rendere in lingua... spostare in basepage!
                if (confirm('Dati modificati. \nOK= apri nuova scheda e perdi modifiche \nCancel=apri scheda esistente mantenendo le modifiche')) {
                    wnd.location.href = percorso;
                }
            }
            wnd.focus();
        }
    }
    else {
        wnd = window.open(percorso, nomewin, 'toolbar=' + toolbar + ',location=' + location + ',directories=' + directories + ',status=' + status + ',menubar=' + menubar + ',scrollbars=' + scrollbars + ',resizable=' + resizable + ',left=' + left + ',top=' + top + ',width=' + width + ',height=' + height + '');
    }
}

//AR Funzioni per gestione popup Report
//  Script Js ApriReport
var winReport = null;
function apriReport(percorso) {
    percorso = percorso.replace(/\xA3/gi, "\'");
    percorso = percorso.replace(/\xE7/gi, "\\");
    winReport = window.open(percorso, 'newreport', 'toolbar=0,location=0,directories=0,status=1,menubar=1,scrollbars=1,resizable=1,left=0, top=0,width=1020,height=700');
    //Aspetta e poi chiude la maschera del report
    //////////AR commentato per test remoto setTimeout(chiudiReport, 100);
    return false;
}

function chiudiReport() {
    if (winReport.document.body) {
        //winReport.document.body.style.border='10px solid green';
        winReport.document.onmouseover = function () { winReport.close(); };
        //winReport.close()
    }
    else {
        setTimeout(chiudiReport, 100);
    }
}

//Aggiunta da SVA per test.
function pausecomp(millis) {
    var date = new Date();
    var curDate = null;

    do { curDate = new Date(); }
    while (curDate - date < millis);
}

function viewPages(idName, objLink) {
    var elArr = getElementsByClassName("panel");

    //Pulisco gli attributi 'selected' su tutto il menu
    var menuArr = getElementsByClassName("menuItem");
    for (var i = 0; i < menuArr.length; i++) {
        menuArr[i].className = menuArr[i].className.replace("selected", "");
    }

    //Metto l'attributo 'selected' sul link relativo al div visualizzato
    for (var i = 0; i < elArr.length; i++) {
        with (elArr[i]) {
            var id = elArr[i].id;
            if (id == idName) {
                document.getElementById(id).style.display = "block";
                objLink.className += " selected";
                document.getElementById("panelName").value = id;
            }
            else {
                document.getElementById(id).style.display = "none";
            }
        }
    }
}


/*
	Developed by Robert Nyman, http://www.robertnyman.com
	Code/licensing: http://code.google.com/p/getelementsbyclassname/
	
    PARAMETERS

    className: 
    One or several class names, separated by space. 
    Multiple class names demands that each match have 
    all of the classes specified. Mandatory.
    
    tag:
    Specifies the tag name of the elements to match. Optional.
    
    elm: 
    Reference to a DOM element to look amongst its children 
    for matches. Recommended for better performance in 
    larger documents. Optional.

    CALL EXAMPLES

    ---To get all elements in the document with a “info-links” class---
    getElementsByClassName("info-links");
    
    ---To get all div elements within the element named “container”, with a “col” class---
    getElementsByClassName("col", "div", document.getElementById("container")); 

    ---To get all elements within in the document with a “click-me” and a “sure-thang” class---
    getElementsByClassName("click-me sure-thang"); 

*/
var getElementsByClassName = function (className, tag, elm) {
    if (document.getElementsByClassName) {
        getElementsByClassName = function (className, tag, elm) {
            elm = elm || document;
            var elements = elm.getElementsByClassName(className),
				nodeName = (tag) ? new RegExp("\\b" + tag + "\\b", "i") : null,
				returnElements = [],
				current;
            for (var i = 0, il = elements.length; i < il; i += 1) {
                current = elements[i];
                if (!nodeName || nodeName.test(current.nodeName)) {
                    returnElements.push(current);
                }
            }
            return returnElements;
        };
    }
    else if (document.evaluate) {
        getElementsByClassName = function (className, tag, elm) {
            tag = tag || "*";
            elm = elm || document;
            var classes = className.split(" "),
				classesToCheck = "",
				xhtmlNamespace = "http://www.w3.org/1999/xhtml",
				namespaceResolver = (document.documentElement.namespaceURI === xhtmlNamespace) ? xhtmlNamespace : null,
				returnElements = [],
				elements,
				node;
            for (var j = 0, jl = classes.length; j < jl; j += 1) {
                classesToCheck += "[contains(concat(' ', @class, ' '), ' " + classes[j] + " ')]";
            }
            try {
                elements = document.evaluate(".//" + tag + classesToCheck, elm, namespaceResolver, 0, null);
            }
            catch (e) {
                elements = document.evaluate(".//" + tag + classesToCheck, elm, null, 0, null);
            }
            while ((node = elements.iterateNext())) {
                returnElements.push(node);
            }
            return returnElements;
        };
    }
    else {
        getElementsByClassName = function (className, tag, elm) {
            tag = tag || "*";
            elm = elm || document;
            var classes = className.split(" "),
				classesToCheck = [],
				elements = (tag === "*" && elm.all) ? elm.all : elm.getElementsByTagName(tag),
				current,
				returnElements = [],
				match;
            for (var k = 0, kl = classes.length; k < kl; k += 1) {
                classesToCheck.push(new RegExp("(^|\\s)" + classes[k] + "(\\s|$)"));
            }
            for (var l = 0, ll = elements.length; l < ll; l += 1) {
                current = elements[l];
                match = false;
                for (var m = 0, ml = classesToCheck.length; m < ml; m += 1) {
                    match = classesToCheck[m].test(current.className);
                    if (!match) {
                        break;
                    }
                }
                if (match) {
                    returnElements.push(current);
                }
            }
            return returnElements;
        };
    }
    return getElementsByClassName(className, tag, elm);
};



/* Funzioni di base (originariamente nella BasePage) */

//+----------------------------------------------------------------------------
//
//  Function:       base_Js_ShowErrorMessage
//
//  Description:    Apertura popup per messaggio errore
//
//  Arguments:      message = messaggio da visualizzare
//
//  Returns:        
//
//-----------------------------------------------------------------------------
function ShowErrorMessage(message) {
    alert(message);
}


//+----------------------------------------------------------------------------
//
//  Function:       closeWindowOpenerRefresh
//
//  Description:    Effettua il refresh della maschera chiamante e chiude la finestra corrente
//
//  Arguments:
//
//  Returns:        
//
//-----------------------------------------------------------------------------
function closeWindowOpenerRefresh() {
    window.opener.location.reload(true);
    self.close();
}



//+----------------------------------------------------------------------------
//
//  Function:       closeWindowOpenerSubmit
//
//  Description:    Effettua il submit del form della maschera chiamante e chiude la finestra corrente
//
//  Arguments:
//
//  Returns:        
//
//-----------------------------------------------------------------------------
function closeWindowOpenerSubmit() {
    window.opener.document.form1.submit();
    self.close();
}

//+----------------------------------------------------------------------------
//
//  Function:       windowOpenerSubmit
//
//  Description:    Effettua il submit del form della maschera chiamante
//
//  Arguments:
//
//  Returns:        
//
//-----------------------------------------------------------------------------
function windowOpenerSubmit() {
    window.opener.document.form1.submit();
}

//+----------------------------------------------------------------------------
//
//  Function:       closeWindowConRefresh
//
//  Description:    Chiude il Thickbox ricaricando la pagina chiamante (chiamare da Thickbox)
//                  ATTENZIONE! Assicurarsi che la pagina chiamante abbia form1!!!!!!
//  Arguments:      percorso = percorso della maschera chiamante relativo alla pagina corrente
//
//  Returns:        
//
//-----------------------------------------------------------------------------
function closeWindowConRefresh(percorso) {
    //self.parent.document.location.href = percorso;
    self.parent.document.form1.submit();
}

//+----------------------------------------------------------------------------
//
//  Function:       windowRefresh
//
//  Description:    Ricarica la pagina corrente (chiamare da Thickbox)
//
//  Arguments:      percorso = percorso della maschera corrente
//
//  Returns:        
//
//-----------------------------------------------------------------------------
function windowRefresh(percorso) {
    //window.location.href=percorso;
    self.document.location.href = percorso;
}

//+----------------------------------------------------------------------------
//
//  Function:       closeThickBoxConRefresh
//
//  Description:    Chiude il Thickbox ricaricando la pagina chiamante (chiamare da Thickbox)
//                  ATTENZIONE! Assicurarsi che la pagina chiamante abbia form1!!!!!!
//  Arguments:      percorso = percorso della maschera chiamante relativo alla pagina corrente
//
//  Returns:        
//
//-----------------------------------------------------------------------------
function closeThickBoxConRefresh(percorso) {
    self.parent.document.location.href = percorso;
    //self.parent.document.form1.submit();    
}

//+----------------------------------------------------------------------------
//
//  Function:       ativaOptionsDisabled
//
//  Description:    Visualizza i campi disabilitati dei DropDown in colore diverso e ne impedisce la selezione all'onChange()
//
//  Arguments:
//
//  Returns:        
//
// P.S. Aggiungere nella head della pagina contenente combobox contenente anche elementi disabilitati il seguente codice javascript
//
//    <!--[if lte IE 7]>
//    addEvent(window, 'load', ativaOptionsDisabled);
//    <![endif]-->
// P.S. 2 Se si tratta di una pagina caricata con ThickBox, il codice sopra non funziona; basta aggiungere 
// $(document).ready(function(){
//    ativaOptionsDisabled()
// });
//-----------------------------------------------------------------------------
function ativaOptionsDisabled() {
    var sels = document.getElementsByTagName('select');

    for (var i = 0; i < sels.length; i++) {
        // AR Ci sono problemi ad aggiungere l'onchange a tutti i combo (si cancellano gli altri eventi onchange)
        // Per il momento ci si limita a considerare solo i combo che possono avere campi disabilitati e ad imporre
        // questo solo evento onchange. In futuro indagare su una soluzione definitiva.
        if (sels[i].className.indexOf("DropWithDisabled") != -1) {
            sels[i].onchange = function () {
                if (this.options[this.selectedIndex].disabled) {
                    // AR Decommentando questo codice, quando viene selezionato un valore disabilitato, 
                    // viene selezionato il primo valore non disabilitato fra quelli successivi al selezionato
                    //                var initial_index = this.selectedIndex;
                    //                var found = false;
                    //                while (this.selectedIndex < this.options.length - 1) {
                    //                    this.selectedIndex++;
                    //                    if (!this.options[this.selectedIndex].disabled) {
                    //                        found = true;
                    //                        break;
                    //                    }
                    //                }
                    //                if (!found) {
                    //                    this.selectedIndex = initial_index;
                    //                    while (this.selectedIndex > 0) {
                    //                        this.selectedIndex--;
                    //                        if (!this.options[this.selectedIndex].disabled) {
                    //                            found = true;
                    //                            break;
                    //                        }
                    //                    }
                    //                }
                    //                if (!found)
                    // AR Se ci si muove su un valore disabilitato, va selezionato il primo (vuoto)
                    this.selectedIndex = -1;
                }
            }
        }

        if (sels[i].options[sels[i].selectedIndex].disabled) {
            //se l'item selezionato è disabilitato, chiamo onchange() - AR non deve fare nulla
            //sels[i].onchange();
        }
        for (var j = 0; j < sels[i].options.length; j++) {
            if (sels[i].options[j].disabled) {
                sels[i].options[j].style.color = '#888';
            }
        }
    }
}

//
//Script che evita che l'utente clicchi più volte su un bottone
//

var __oldDoPostBack = null;
try {
    __oldDoPostBack = __doPostBack;
    __doPostBack = newDoPostback;
}
catch (e) {
    //donothing
}
var postbacking = false;
var submitting = false;
var oldSubmit = null;
if (document.forms[0] != null) {
    oldSubmit = document.forms[0].onsubmit;
    document.forms[0].onsubmit = NewSubmit;
}
function NewSubmit() {
    if (submitting) {
        return false;
    }
    else {
        submitting = true;
        if (oldSubmit != null) {
            window.setTimeout(freePostbackAndSubmit, 1000);
            return oldSubmit();
        }
        else {
            return true;
        }
    }
}


function newDoPostback(eventTarget, eventArgument) {
    if (postbacking) {
        return false;
    }
    else {
        postbacking = true;
        window.setTimeout(freePostbackAndSubmit, 1000);
        return __oldDoPostBack(eventTarget, eventArgument);
    }
}
function freePostbackAndSubmit() {
    postbacking = false;
    submitting = false;
}

function safeParam(param) {

    /// <summary>
    /// Utilizzata per l'utilizzo della funzione SyncPageMethod per le variabili stringa
    /// </summary>
    /// <param name="param" type="string"></param>    

    if (param != null) {
        param = param.replace(/\\/g, "/#");
        param = param.replace(/'/g, "\\'");
    }
    return param;
}

//+----------------------------------------------------------------------------
//
//  Function:       SyncPageMethod
//
//  Description:    Funzione che utilizza ajax per chiamare un webmetod in modo sincrono
//
//  Arguments:      methodName, dataParameters, pageName
//                  dataParameters format: "{chiave:'valore',secondachiave:'secondoValore'}"
//  Returns:        string -- "OK" o messaggio di errore
//
//-----------------------------------------------------------------------------
function SyncPageMethod(methodName, dataParameters, pageName) {
    var path = document.location.pathname;
    if (pageName != undefined) {
        path = pageName;
    }
    var rval = $.ajax({
        type: "POST",
        url: path + "/" + methodName,
        data: dataParameters,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false
    });
    try {
        var response = eval('(' + rval.responseText + ')');
        if (response.hasOwnProperty("d"))
            return response.d;
        else
            return response;
    }
    catch (err) {
        //document.write("<script type='text/javascript'>" + rval.responseText + "<\script>");
        document.write(rval.responseText);
        document.location.href = document.location.href;
        return "OK";
    }
}

//+----------------------------------------------------------------------------
//
//  getParameterByName
//
//  Description:    Legge la QueryString "name" 
//
//
//-----------------------------------------------------------------------------
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return results[1];
}


/* 
WindowUtilities File
Da includere nella head delle pagine che utilizzano WebDialogWindow
14/01/2011 : SVA
*/


//+----------------------------------------------------------------------------
//
//  openDefaultEditor
//
//  Description:    open editor in new mode
//
//-----------------------------------------------------------------------------
function openDefaultEditor() {
    var strURL = "?MODALITA=NEW";
    if (document.location.href.lastIndexOf("?") != -1) {
        strURL = document.location.href.substring(document.location.href.lastIndexOf("/") + 1, document.location.href.lastIndexOf("?")).replace("_MSB_", "_MSE_") + strURL;
    }
    else {
        strURL = document.location.href.substr(document.location.href.lastIndexOf("/") + 1).replace("_MSB_", "_MSE_") + strURL;
    }
    openEditor(strURL);
}

//+----------------------------------------------------------------------------
//
//  openDefaultEditor
//
//  Description:    open editor in Edit mode
//
//-----------------------------------------------------------------------------
var msgConfUscita = "";

function onCompletegetDizionarioUI(result) {
    msgConfUscita = result;
}

function openEditor(strURL, IdDialog) {

    //Verifico se la URL ha già la redirezione. Dovrebbe succedere solo per:
    //1) Chiamata dal pulsante "M" - modifica dei Browser
    //2) Chiamata da un browser secondario della maschera (struttura Master/Detail)
    if (strURL.indexOf("../") == -1) {
        //estraggo il nome della cartella contenente Browser/Editor
        var pathEditor = top.frames['frameContent'].document.location.href;
        var col_array = pathEditor.split("/");
        var strFolder = col_array[col_array.length - 2];

        strURL = "../" + strFolder + "/" + strURL
    }

    var d = new Date();
    var rs = d.getTime();
    if (strURL.indexOf("?") != -1) {
        strURL += "&rs=" + rs;
    }
    else {
        strURL += "?rs=" + rs;
    }

    var dialogWindow = $(top).find('editorDialog');
    var dialogFrame = $(top).find('frameEditorDialog');

    if (dialogWindow) {
        if (dialogFrame) {
            $('#frameEditorDialog').attr("src", strURL);
        }

        $('#editorDialog').dialog("option", "height", 400);
        $('#editorDialog').dialog("option", "width", 600);
        $("#editorDialog").dialog("option", "closeOnEscape", false);
        $('#editorDialog').dialog("open");
    }
}


//function showDialog() {
//    windowResize();
//    $('#editorDialog').dialog("open");
//}

function hideEditorDialog(IdDialog) {
    if (IdDialog == undefined)
        IdDialog = "editorDialog";

    var dialogWindow = $(top).find('editorDialog');
    var dialogFrame = $(top).find('frameEditorDialog');

    if (dialogFrame) {
        $('#frameEditorDialog').attr("src", "/Web/Home/blank.aspx");
    }
    if (dialogWindow) {
        $('#editorDialog').dialog("close");
    }
}

function windowResize(newWidth, newHeight) {

    //var newHeight = $("#frameEditorDialog").contents().find("#dialogHeight").val();
    //var newWidth = $("#frameEditorDialog").contents().find("#dialogWidth").val();

    //Nel caso che risulti "undefined" metto un default
    if (newHeight == undefined)
        newHeight = 500
    if (newWidth == undefined)
        newWidth = 600

    var dialog = $(top).find("editorDialog");
    if (dialog != null) {
        $('#editorDialog').dialog("option", "height", newHeight);
        $('#editorDialog').dialog("option", "width", newWidth);
        $('#editorDialog').dialog("option", "position", "center");
        $("#editorDialog").dialog("option", "closeOnEscape", false);
    }
}

//Questa parte di codice serve per gestire il refresh dei browser.
function refreshBrowser() {
    $('#btnRefresh').click();
}


//+----------------------------------------------------------------------------
//
//  openDefaultEditor
//
//  Description:    open editor in Edit mode
//
//-----------------------------------------------------------------------------
function AutomaticRowSave(e) {

    var targ;
    if (!e) var e = window.event;
    if (e.target) targ = e.target;
    else if (e.srcElement) targ = e.srcElement;
    if (targ)
        if (targ.nodeType == 3) // defeat Safari bug
            targ = targ.parentNode;
    //          targ rappresenta l'oggetto che ha scatenato l'evento        
    var idtxt = targ.id;
    var idBtn = String(idtxt).replace('dummy', 'btnUpd');
    document.getElementById(idBtn).click();
}

//+----------------------------------------------------------------------------
//
//  EndRequestHandler
//
//  Description:    utilizzata nei browser con Update Panel e ToolkitScriptManager
//
//-----------------------------------------------------------------------------
function EndRequestHandler(sender, e) {
    if (e.get_error()) {
        e.set_errorHandled(true);
    }
}

//+----------------------------------------------------------------------------
//  Name: openHelp
//  Description:    apre il contenuto dell'Help in una nuova finestra
//                  La soluzione con iFrame è stata scartata per evitare problemi con gli Editor
//-----------------------------------------------------------------------------
function openHelp(pagina) {
    pagina = "/Web/Help/frm_HLP.aspx?PAGINA=" + pagina;
    window.open(pagina);
}

//+----------------------------------------------------------------------------
//  Name: loadIframeDetail
//  Description:    apre il contenuto del dettaglio Browser in un iFrame ed eseguo lo scroll della pagina.
//-----------------------------------------------------------------------------
function loadIframeDetail(pagina) {
    //Carico iFrame
    $("#boxBrowserDetail").html("<iframe frameborder='0' name='iframeBrowserDetail' id='iframeBrowserDetail' src='" + pagina + "'></iframe>");

    //Scroll dela pagina fino alla posizione del "boxBrowserDetail"
    var destination = $("#boxBrowserDetail").offset().top;
    $("html:not(:animated)").animate({ scrollTop: destination }, 500);
}

//+----------------------------------------------------------------------------
//  Name: closeHelp
//  Description:    nascondo l'Help
//-----------------------------------------------------------------------------
function closeHelp() {
    parent.document.getElementById('boxHelp').innerHTML = '';
}

//+----------------------------------------------------------------------------
//  Name: PrintPage
//  Description:    
//-----------------------------------------------------------------------------
function PrintPage() {
    window.print();
}

//---
//  Name: addRowInMyGridView
//  Description: alla pressione del pulsante Nuovo nella toolbar dei browser,
//  effettuo il click sul pulsante New presente nella prima riga della MyGridView.
//  Per identificarlo utilizzo la classe che deve essere ".btnAdd".
//---
function addRowInMyGridView() {
    $('.btnAdd').click();
}

//---
//  Name: openPopUp
//  Description: 
//---
function openPopUp(idRiga) {
    parent.parent.openEditor(percorsoEdit + idRiga);
}

//---
//  Name: openPopUpNewRecord
//  Description: apro la popUp in modalità NEW
//---
function openPopUpNewRecord() {
    parent.parent.openEditor(percorsoNew);
}

//---
//  Name: substituteBrowser
//  Description: 
//---
function substituteBrowser(idRiga) {
    document.location.href = percorsoEdit + idRiga;
}

//---
//  Name: substituteBrowserNewRecord
//  Description: apro il record in modalità NEW sostituendo la pagina
//---
function substituteBrowserNewRecord() {
    document.location.href = percorsoNew;
}
//---
//  Name: closeSubstituteEditor
//  Description: chiude l'editor nel caso di SubstituteBrowser
//---
function closeSubstituteEditor(percorso) {
    document.location.href = percorso;
}

//-----------------------------------------------------------------------------
//
//  Function:       GetFromDictionary
//  Description:    Funzione che restituisce il testo di una chiave del dizionario
//  Arguments:      chiave
//  Returns:        string
//
//-----------------------------------------------------------------------------
function GetFromDictionary(chiave) {
    var rval = $.ajax({
        type: "POST",
        url: document.location.pathname + "/getDizionarioUI",
        data: "{key:'" + chiave + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false
    });
    var response = eval('(' + rval.responseText + ')');
    if (response.hasOwnProperty("d"))
        return response.d;
    else
        return response;

}

//---
//
// Funzioni per Allegati
//
//---

function GetAllegati(idRichiesta, idServizio, tipoAllegato) {

    /// <summary>
    /// Recupera gli allegati della pratica nel momento in cui apro la richiesta viaggio.
    /// </summary>
    /// <param name="idRichiesta" type="Int">Id richiesta</param>
    /// <param name="idServizio" type="Int">Id prenotazione nota spesa o altro tipo di servizio</param>
    /// <param name="tipoAllegato" type="String">Tipo allegato</param>

    var paramIdRichiesta = idRichiesta;
    if (idServizio != "")
        paramIdRichiesta = idServizio;

    var r = SyncPageMethod("getAllegati", "{idRichiesta:" + paramIdRichiesta + ", tipoAllegato:" + tipoAllegato + "}", "../WebServices/WSAllegati.asmx");

    if (tipoAllegato == C_TIPO_ALLEGATO_NOTA_SPESA) {
        var idCliente = $("#hIdCliente", parent.document).val();
        for (var i = 0; i < r.length; i++) {
            // Produzione
            $("#imgScontrino").attr("src", "../../images_fatture/" + idCliente + "/" + idRichiesta + "/" + idServizio + "/" + r[i].Value);

            // Test locale
            //$("#imgScontrino").attr("src", "C:\\tmp\\" + idCliente + "\\" + idRichiesta + "\\" + r[i].Value);
        }
    }
    else {
        var strHTML = "<div class='tblEditorRichiesta' id='tblRiepilogoAllegati'>";

        var nomeFile = "";
        var idCliente = 1;

        for (var i = 0; i < r.length; i++) {

            nomeFile = r[i].Value;

            strHTML += "<div class='mt-1'>";
            strHTML += "<i class='btn btn-secondary btn-sm fa fa-times' title='Elimina file' data-toggle='tooltip' id='span" + r[i].Id + "' onclick='javascript:if (confirm(\"Sei sicuro di voler eliminare il file selezionato?\")){DeleteFile(" + r[i].Id + ",\"" + nomeFile + "\", " + idRichiesta + "," + idCliente + ");GetAllegati(" + idRichiesta + "," + idRichiesta + "," + tipoAllegato + ");}'></i> ";
            strHTML += "<a href='#' title='Scarica file' data-toggle='tooltip' onclick='downloadFile(\"" + r[i].Value + "\");'><small>" + r[i].Value + "</small></a>";
            strHTML += "</div>";
        }
        strHTML += "</div>";

        $("#divAllegati_" + tipoAllegato).html(strHTML);
    }
}

function DeleteFile(idAllegato, fileName, idRichiesta, idCliente) {

    /// <summary>
    /// Eliminazione file allegato
    /// </summary>
    /// <param name="idAllegato" type="Int">Id allegato</param>
    /// <param name="fileName" type="String">Nome file</param>
    /// <param name="idRichiesta" type="String">Id Richiesta</param>
    /// <param name="idCliente" type="String">Id Cliente</param>

    var stato = document.getElementById("hIdStato").value;

    if (stato == "")
        return false;
    else
        var r = SyncPageMethod("DeleteAllegato", "{idAllegato:" + idAllegato + ",nomeFile:'" + fileName + "',idRichiesta:" + idRichiesta + ",idCliente:" + idCliente + "}", "../WebServices/WSAllegati.asmx");

    if (r != "1")
        alert("Ci sono stati dei problemi durante l'eliminazione del file.");
    else
        alert("Eliminazione completata.");
}

function downloadFile(fileName) {

    /// <summary>
    /// Scarico il file allegato
    /// </summary>
    /// <param name="fileName" type="String">Nome file</param>

    $("#hFileToDownload").val(fileName);

    // Nel caso di mobile apro una nuova finestra per non perdere la navigazione.
    if ($("#hMobile").val() == "1") {
        var idCliente = $("#hIdCliente").val();
        var idRichiesta = $("#hIdRichiesta").val();
        window.open("../AllegaFile/Download.aspx?FILENAME=" + fileName + "&CLI=" + idCliente + "&REQ=" + idRichiesta);
        return false;
    }
    else {
        $("#btnDownload").click();
    }
}

function SendFile(idAllegato) {
    /// <summary>
    /// Invio il File Allegato via email.
    /// </summary>

    var r = SyncPageMethod("SendAllegato", "{idAllegato:" + idAllegato + "}", "../WebServices/WSAllegati.asmx");

    if (r != "1")
        alert("Ci sono stati dei problemi durante l'invio del file, riprovare più tardi.");
    else
        alert("Allegato inviato correttamente.");
}

function checkRequiredField(idGriglia) {
    /// <summary>
    /// Controllare i campi obbligatori delle griglie senza il MaskeEditValidator.
    /// </summary>

    var elements = $('#' + idGriglia + ' .required');
    var canSave = true;

    elements.each(function () {
        id = String($(this).attr("id"));
        if ($("#" + id).val() == "") {
            $("#" + id).addClass("MaskedEditError");
            canSave = false;
        }
    });
    return canSave;
}

function enableField(obj, setFocus) {
    /// <summary>
    /// Abilita un campo di Tipo data. Funzione centralizzata per evitare problemi con versioni diverse di Jquery o Cross-Browser.
    /// Valido per classi (es: ".class input"), tag (es: "input"), id ("es: "#id").
    /// </summary>
    /// <param name="obj" type="String">Identificativo del campo</param>
    /// <param name="setFocus" type="Bool">True:passa il focus al campo / False:non passa il focus</param>

    if (!$(obj).hasClass("accessoRead")) {
        $(obj).removeAttr('disabled');
        if (setFocus)
            $(obj).focus();
    }
}

function disableField(obj) {

    /// <summary>
    /// Disabilita un campo. Funzione centralizzata per evitare problemi con versioni diverse di Jquery o Cross-Browser
    /// Valido per classi (es: ".class input"), tag (es: "input"), id ("es: "#id").
    /// </summary>
    /// <param name="obj" type="String">Oggetto da modificare</param>    
    $(obj).attr("disabled", true);
}

function writeError(e, pageJs, functionName) {

    /// <summary>
    /// 30/01/2017 - test gestione errore JS
    /// 
    /// Reference: http://www.w3schools.com/js/js_errors.asp
    /// -----------------------------------------------------------------
    /// Error Name	    |   Description
    /// -----------------------------------------------------------------
    /// EvalError	    |   An error has occurred in the eval() function
    /// RangeError      |   An number out of range error has occurred
    /// ReferenceError	|   An illegal reference has occurred
    /// SyntaxError	    |   A syntax error has occurred
    /// TypeError	    |   A type error has occurred
    /// URIError	    |   An error in encodeURI() has occurred
    /// -----------------------------------------------------------------
    /// 
    /// </summary>
    /// <param name="e" type="Object">Oggetto errore</param>
    /// <param name="pageJs" type="String">Nome del file .js</param>
    /// <param name="functionName" type="String">Nome della function</param>

    // Recupera il messaggio dei web Method se valorizzato
    if (e.Message != "") { e.message = e.Message; }

    if (pageJs == undefined)
        pageJs = "";

    if (functionName == undefined)
        functionName = "";

    alert(GetFromDictionary("ERR_MSG_ERROR_JS"));

    // Visualizzazione errore nella console del browser.
    console.error;
    console.log(e.message); // https://developer.mozilla.org/en-US/docs/Web/API/Console

    var browser = window.navigator.userAgent;

    // Registrazione errore nel DB.
    var url = location.href;
    //////////////var r = SyncPageMethod("writeError", "{message:'" + e.message + "', name:'" + e.name + "', url:'" + url + "', urljs:'" + pageJs + "', functionName:'" + functionName + "', browser:'" + browser + "'}", "../WebServices/WSErrori.asmx");
    //////////////if (r.hasOwnProperty("Message") || r.toString() == "") {
    //////////////    alert(GetFromDictionary("ERR_MSG_WEB_METHOD") + r.Message);
    //////////////}
}

function documentReadyEditorBO() {

    $("#ButtonAnnulla").click(function (e) {
        $("#iframeEditorModal", parent.document).attr("src", "");
        $("#btnCloseModal", parent.document).click();
        return false;
    });

    $("#ButtonSalva").click(function (e) {
        if (!$('#form1').valid()) {
            return false;
        }
    });

    $('#form1').FormObserve({
        changeClass: "changed"
    });

    $('#form1').validate({
        errorPlacement: function (error, element) { }
    });

    ////////////////// ????? SE: serve??????  coomentata con SV: ativaOptionsDisabled();
}

function genericDocumentReady() {

    $(".bt-switch input[type='checkbox'], .bt-switch input[type='radio']").bootstrapSwitch();

    $(".btnClose").click(function (e) {
        $("#iframeNewService", parent.document).attr("src", "");
        if ($("#hMobile").val() != "1") {
            $("#btnCloseServizio", parent.document).click(); // chiudo la modal
        }
        return false;
    });

    $("#btnPreSalva").click(function (e) {
        save();
    });

    // Mask
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
    $('.time').mask('00:00');

    $(".datepicker").mask("99/99/9999", { placeholder: 'gg/mm/aaaa' });
    $(".datepicker").blur(function () { checkYear($(this).attr("id")); });

    //$(".datepicker").datepicker($.datepicker.regional["it"]);
    $.validator.addClassRules({ "datepicker": { dateMaskedITA: true } });
    $.validator.addClassRules({ "time": { minuteMaskedITA: true } });
    $.validator.addClassRules({ "consecutiveDate": { validConsecutiveDate: true } });

    $.validator.methods.validConsecutiveDate = function (value, element, param) { return compareConsecutiveDate(element); };

    $('form').validate({
        errorPlacement: function (error, element) { }
    });

    $("#form1").FormObserve({ changeClass: "changed" });


    !function ($) {
        "use strict";
        var SweetAlert = function () { };
        SweetAlert.prototype.init = function () { },
        //init
        $.SweetAlert = new SweetAlert, $.SweetAlert.Constructor = SweetAlert
    }(window.jQuery),

    //initializing 
    function ($) {
        "use strict";
        $.SweetAlert.init()
    }(window.jQuery);


    $('.datepicker').datepicker({
        showOn: 'button',
        buttonImage: "../Images/calendar.gif",
        buttonImageOnly: false
    });

    $(".ui-datepicker-trigger").addClass("fa fa-calendar-alt");

}

function closeParentModal() {
    /// <summary>
    /// Chiude la finestra modale. Utilizzata principalmente nei sottobrower del backoffice.
    /// </summary>

    parent.$('#modalPage').modal('toggle');
}

function clearSearchSelectedAPI(str, table, id) {

    /// <summary>
    /// Rimozione tag di formattazione.
    /// </summary>
    /// <param name="str" type="String">Stringa da aggiornare</param>

    try {

        if (str != "" && str != undefined) {
            if (str.length > 0) {

                str = str.replace(/<b>/g, "");
                str = str.replace(/<\/b>/g, "");
            }
        }
        return str;
    }
    catch (e) {
        writeError(e, "JScript.js", "clearSearchSelectedAPI-" + table);
    }
}

function loadSearchAPI(id, table, character) {

    /// <summary>
    /// Carica la tendina con i primi 5 risultati caricati dall'API in funzione della ricerca .
    /// </summary>
    /// <param name="id" type="Int">Id servizio</param>

    try {
        var idDiv = "#search-" + id;
        var pathAPI = "";

        if (character.which == 40 && character.which == 38 && character.which == 13)
            alert(character.which);

        if (character.which != 40 && character.which != 38 && character.which != 13) {
            if ($("#" + id).val().length) {
                $(idDiv).show();
                if (table == "LoadAirportSearch") {
                    pathAPI = $("#hPathAPI").val() + 'airport/autofill?designator=' + safeParam($("#" + id).val()) + '&api-version=1.0';
                    var r = SyncPageMethod("callAPI", "{path:'" + pathAPI + "'}", "../WebServices/WSApiSearch.asmx");
                }

                else if (table == "LoadRailSearch") {
                    if ($("#" + id).val().length > 2) {
                        pathAPI = $("#hPathAPI").val() + 'railstation/autofill?stationName=' + safeParam($("#" + id).val()) + '&api-version=1.0';
                        var r = SyncPageMethod("callAPI", "{path:'" + pathAPI + "'}", "../WebServices/WSApiSearch.asmx");
                    }
                    else return false;
                }
                else if (table == "LoadHotelSearch") {
                    if ($("#" + id).val().length > 2) {
                        pathAPI = $("#hPathAPI").val() + 'hotellocation/autofill?designator=' + safeParam($("#" + id).val()) + '&api-version=1.0';
                        var r = SyncPageMethod("callAPI", "{path:'" + pathAPI + "'}", "../WebServices/WSApiSearch.asmx");
                    }
                    else return false;
                }


                if (r.hasOwnProperty("Message")) {
                    alert(r.toString());
                }
                else {

                    var data = JSON.stringify(r.toString());
                    var n = SyncPageMethod(table, "{json:" + data + "}", "../WebServices/WSApiSearch.asmx");

                    if (n.hasOwnProperty("Message")) {
                        alert(n.toString());
                    }
                    else {
                        $(idDiv).html(n.toString());
                    }
                }

                $(idDiv + " li").click(function () {
                    var idLi = $(this).attr('id');
                    var idLiVal = $("#" + idLi.toString() + " .ddlId").html();
                    var idLiText = $("#" + idLi + " .ddlText").html();

                    //setto il codice iata per la ricerca dei voli nel campo hidden
                    setAirIataCode(id, idLiVal);

                    $("#" + id).val(clearSearchSelectedAPI(idLiText, table, idLiVal));
                    $("#h" + id).val(idLiVal);
                    $(idDiv).hide();
                });

            }
            else {
                $(idDiv).hide();
            }
        }
        else if (character.which == 40)//freccia in giù
        {

            if ($(idDiv + " li.selected").length == 0) {
                $(idDiv + " li").first().addClass("selected");
            }
            else {

                var idSelectedLi = $(idDiv + " li.selected").attr("id");
                if ($("#" + idSelectedLi).next().length > 0) {
                    $("#" + idSelectedLi).next().addClass("selected");
                    $("#" + idSelectedLi).removeClass("selected");
                }
            }
        }
        else if (character.which == 38)//freccia in su 
        {
            if ($(idDiv + " li.selected").length == 0) {
                $(idDiv + " li").first().addClass("selected");
            }
            else {
                var idSelectedLi = $(idDiv + " li.selected").attr("id");
                if ($("#" + idSelectedLi).prev().length > 0) {
                    $("#" + idSelectedLi).prev().addClass("selected");
                    $("#" + idSelectedLi).removeClass("selected");
                }
            }
        }
        else if (character.which == 13)//Invio 
        {
            $(idDiv + " li.selected").click();
        }

    }
    catch (e) {
        writeError(e, "JScript.js", "loadSearchAPI-" + table);
    }
}

function setSearchDefaultAPI(id, table) {

    /// <summary>
    /// Creazione nuovo servizio.
    /// Il timeout serve per non escludere l'evento click che arriverebbe sempre dopo il blur.
    /// </summary>
    /// <param name="id" type="Int">Id servizio</param>

    try {
        setTimeout(function () {

            var idDiv = "#search-" + id;

            if ($(idDiv).is(":visible")) {
                var liVal = ($(idDiv + " li.selected").length > 0) ? $(idDiv + " li.selected .ddlText").html() : $(idDiv + " li .ddlText").first().html();
                var liId = ($(idDiv + " li.selected").length > 0) ? $(idDiv + " li.selected .ddlId").html() : $(idDiv + " li .ddlId").first().html();

                //setto il codice iata per la ricerca dei voli nel campo hidden (solo per la pagina AIR)
                setAirIataCode(id, liId);

                if (liVal != undefined) {
                    $("#" + id).val(clearSearchSelectedAPI(liVal, table, liId));
                    if (id == "txtEVT_AEROPORTO_DA" || id == "txtEVT_AEROPORTO_A")
                        $("#h" + id).val(liVal);
                    else
                        $("#h" + id).val(liId);
                    $(idDiv).hide();
                }
                else
                    $(idDiv).hide();
            }
        }, 200);
    }
    catch (e) {
        writeError(e, "JScript.js", "setSearchDefaultAPI-" + table);
    }

}

function setAirIataCode(id, value) {
    ///<summary>
    ///setto il codice itala per la ricerca dei voli nel campo hidden
    ///</summary>

    if (id == "txtPRA_DA")
        $("#hPra_da_code").val(value);
    else if (id == "txtPRA_A")
        $("#hPra_a_code").val(value);
    else if (id == "txtPRH_CITTA")
        $("#htxtPRH_CITTA").val(value);
}

function selezionaStelle(number, idAcrn) {
    ///<summary>
    /// Faccio il show del numero di stelle che mi arriva e nascondo le altre
    /// idAcrn serve per generalizzare il metodo aggiungendo un accronimo (nel caso si volessero utilizzare le stelle nella stessa pagina)
    ///</summary>
    ///<param name="id" type="Int">numero della stella selezionata</param>
    ///<param name="id" type="String">Accronimo della pagina dalla quale si chiama il metodo</param>

    //idAcr == 'Hot' -> Filtro iniziale di ricerca
    //idAcr == 'Try' -> Filtro iniziale di ricerca della pagina frm_mse_try

    var stella1Select = "#1StellaSelect" + idAcrn;
    var stella2Select = "#2StellaSelect" + idAcrn;
    var stella3Select = "#3StellaSelect" + idAcrn;
    var stella4Select = "#4StellaSelect" + idAcrn;
    var stella5Select = "#5StellaSelect" + idAcrn;
    var stella1 = "#1Stella" + idAcrn;
    var stella2 = "#2Stella" + idAcrn;
    var stella3 = "#3Stella" + idAcrn;
    var stella4 = "#4Stella" + idAcrn;
    var stella5 = "#5Stella" + idAcrn;
    // default
    $(stella1Select).show(); // sempre visibile
    $(stella2Select).hide();
    $(stella3Select).hide();
    $(stella4Select).hide();
    $(stella5Select).hide();
    $(stella1).hide();
    $(stella2).hide();
    $(stella3).hide();
    $(stella4).hide();
    $(stella5).hide();

    if(typeof number == 'number')
        number = number.toString();

    switch (number) {
        case '1':
            $(stella2).show();
            $(stella3).show();
            $(stella4).show();
            $(stella5).show();

            break;
        case '2':
            $(stella2Select).show();
            $(stella3).show();
            $(stella4).show();
            $(stella5).show();
            break;
        case '3':
            $(stella2Select).show();
            $(stella3Select).show();
            $(stella4).show();
            $(stella4).show();
            break;
        case '4':
            $(stella2Select).show();
            $(stella3Select).show();
            $(stella4Select).show();
            $(stella5).show();
            break;
        case '5':
            $(stella2Select).show();
            $(stella3Select).show();
            $(stella4Select).show();
            $(stella5Select).show();
            break;
    }

    $("#hStelleMassime").val(number);
}