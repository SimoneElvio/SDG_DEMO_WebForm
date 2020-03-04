//+----------------------------------------------------------------------------
//
//  Function:       checkLogout()
//
//  Description:    Apre una maschera che verifica se l'opener è chiuso (l'utente ha
//                  premuto il tasto X). In tal caso, chiama la maschera che effettua
//                  la chiusura della sessione (con tutte le attività collegate)
//
//  Arguments:
//
//  Returns:        
//
//-----------------------------------------------------------------------------
function checkLogout()
{
    Js_ApriPopup('../Home/XListener.html', 'XListener', 0,0,0,1,0,1,1,0,0,1,1);
}


//function sayByeBye()
//{
//    self.location.href("../Home/CloseSession.aspx");
//}

window.onload = function(e){
    if (self.attachEvent)
    {
        //self.attachEvent('onunload',sayByeBye);
        self.attachEvent('onunload',checkLogout);
    }
    else if (self.addEventListener) 
    {
        //self.addEventListener('onunload',sayByeBye,true);
        self.addEventListener('onunload',checkLogout,true); 
    }
}