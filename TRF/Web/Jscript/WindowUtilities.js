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
    //var dialogWindow = $(top.window).find('editorDialog');
    var dialogWindow = $(top).find('editorDialog');
    var dialogFrame = $(top).find('frameEditorDialog');
    //var dialogWindow = top.document.getElementById('editorDialog');

    if (dialogWindow) {
        if (dialogFrame) {
            $('#frameEditorDialog').attr("src", strURL);
        }
        setTimeout("showDialog();", 500);
    }
}


//function openEditor(strURL) {
    
//    var d = new Date();
//    var rs = d.getTime();
//    if (strURL.indexOf("?") != -1) {
//        strURL += "&rs=" + rs;
//    }
//    else {
//        strURL += "?rs=" + rs;
//    }    
//    var dialogWindow = $find('editorDialog');
//    dialogWindow.get_contentPane().set_contentUrl(strURL);    
//    setTimeout("showDialog('editorDialog');", 1);
//    //Chiamo ajax metodo che riempie la variabile 
//    PageMethods.getDizionarioUI("USCITA_SENZA_SALVARE", onCompletegetDizionarioUI);
//}
//SVA:inserita per aprire nella stessa pagina 2 webdialog di diverse dimensioni.
//nel caso capire come passare le dimensioni a una funzione sola e cambiarle.
//function openEditorMedium(strURL) {

//    var d = new Date();
//    var rs = d.getTime();
//    if (strURL.indexOf("?") != -1) {
//        strURL += "&rs=" + rs;
//    }
//    else {
//        strURL += "?rs=" + rs;
//    }
//    var dialogWindow = $find('editorDialogMedium');
//    dialogWindow.get_contentPane().set_contentUrl(strURL);
//    setTimeout("showDialog('editorDialogMedium');", 1);
//    //Chiamo ajax metodo che riempie la variabile 
//    PageMethods.getDizionarioUI("USCITA_SENZA_SALVARE", onCompletegetDizionarioUI);
//}

function showDialog() {
    windowResize();
    $('#editorDialog').dialog("open");
}

//function showDialog(id) {
//    var dialogWindow = $find(id);
//    dialogWindow.show();
//}

//function editorDialog_WindowStateChanging(sender, e) {
//    
//    if (e.get_newWindowState() == 3) {        
//        var objIframe = $find("editorDialog").get_contentPane().get_iframe().contentWindow;       
//        
//        if (objIframe.$("#form2").FormObserve_changedForm()) {
//            e.set_cancel(!confirm(msgConfUscita));
//        }
//        else {            
//                document.location.href = document.location.href;
//        }
//    }
//}




function hideEditorDialog(IdDialog) {
    if (IdDialog == undefined)
        IdDialog = "editorDialog";

    var dialogWindow = $(top).find('editorDialog');
    var dialogFrame = $(top).find('frameEditorDialog');

    if (dialogFrame) {
        alert('tete');
        //$('#frameEditorDialog').attr("src", '../Home/blank.aspx');
        //dialogFrame.attr("src", '../Home/blank.aspx');
        //$('#frameEditorDialog').src = '../Home/blank.aspx';
        //$('#frameEditorDialog').src = '/Web/Home/blank.aspx';
        //dialogFrame.attr("src", 'http://www.google.it');
        //alert($('#frameEditorDialog').style.border);
        if(document.getElementById('frameEditorDialog'))
            alert(document.getElementById('frameEditorDialog').style.border);
    }
    if (dialogWindow) {
        //alert('xxx');
        //$('#editorDialog').dialog("close");
    }
    
}

//function hideEditorDialog(IdDialog) {
//    if (IdDialog == undefined)
//        IdDialog = "editorDialog";

//    var dialogWindow = $(top).find('editorDialog');
//    var dialogFrame = $(top).find('frameEditorDialog');

//    if (dialogWindow) {
//        $('#editorDialog').dialog("close");
//    }
//    if (dialogFrame) {
//        $('#frameEditorDialog').attr("src", '../Home/blank.aspx');
//    }
//}


function windowResize() {

    var newHeight = $("#frameEditorDialog").contents().find("#dialogHeight").val();
    var newWidth = $("#frameEditorDialog").contents().find("#dialogWidth").val();

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
    }
}
