#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   BasePageNoLogin.cs
//
// Namespace:   SDG.GestioneUtenti.Web
// Descrizione: Pagina base
//
// Autore:      AR - SDG srl
// Data:        26/06/2008
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using SDG.GestioneUtenti;
using SDG.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace SDG.GestioneUtenti.Web
{
    /// <summary>
    /// Summary description for BasePageNoLogin.
    /// </summary>
    public class BasePageNoLogin : BasePageMaster
    {
        #region Web Control Declaration

        #endregion

        public BasePageNoLogin()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region OnInit
        /// <summary>
        /// Override onInit Base Page: Setto di dafault It
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            objDictionary = new Dizionario();
            objTestiPagine = new TestiPagine();
            objUtilita = new Utilita();

            qNAZ_ID_NAZIONE = 1;//it
            Session["NAZ_ID_NAZIONE"] = 1;

            switch (qNAZ_ID_NAZIONE)
            {
                case 1:
                    qCultureInfoName = "it";
                    break;
                case 3:
                    qCultureInfoName = "en";
                    break;
                default:
                    qCultureInfoName = "it";
                    break;
            }

            objDizionarioUI = objDictionary.GetDictionary(qNAZ_ID_NAZIONE);
            objTestiPagineUI = objTestiPagine.GetTestipagina(Page.GetType().BaseType.Name, qNAZ_ID_NAZIONE);

            objUtilita.Naz_id_nazione = qNAZ_ID_NAZIONE;
            getCulture();

            //objSistema.Read();
	        if (Page.Header != null)
        	    this.Title = GetValueDizionarioUI("NOME_APPLICAZIONE");

            base.OnInit(e);
        }
        #endregion

        #region Web Form PreRender
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
        #endregion
	
    }
}
