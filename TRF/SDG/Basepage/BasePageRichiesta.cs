#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Missyo
// Nome File:   BasePageRichiesta.cs
//
// Namespace:   SDG.Basepage
// Descrizione: Pagina base utilizzata dagli Editor
//
// Autore:      SV - SDG srl
// Data:        17/11/2017
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using BusinessObjects;
using Missyo.BusinessObjects.Utility;
using SDG.GestioneUtenti.Web;
using System;

namespace SDG.Basepage
{
    public class BasePageRichiesta : BasePage
    {
        #region Variabili

        public string C_USER = string.Empty;

        Encrypt objEncrypt = new Encrypt();
        #endregion

        #region OnInit
        /// <summary>
        /// Override onInit Base Page
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            idLoggedUser = Convert.ToInt32(Session["UTE_ID_UTENTE"].ToString());
            C_USER = Session["UTE_COGNOME"].ToString() + " " + Session["UTE_NOME"].ToString();
            base.OnInit(e);
        }

        #endregion
    }
}