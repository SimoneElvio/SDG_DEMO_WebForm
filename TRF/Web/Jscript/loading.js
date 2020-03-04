//Questa funzione serve per nascondere o visualizzare il div che viene visualizzato quando
//una pagina sta caricando qualcosa o salvando.

function displayLoading(val) {   
    if (val == 1)
        top.document.getElementById('divLoading').style.display = 'block';
    else
        top.document.getElementById('divLoading').style.display = 'none';
}