#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    SDG_DEMO
// Nome File:   BasePageBrowser.cs
//
// Namespace:   SDG.GestioneUtenti.Web
// Descrizione: Pagina base utilizzata dagli Editor
//
// Autore:      SE - SDG srl
// Data:        11/10/2011
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SDG.GestioneUtenti.Web
{
    /// <summary>
    /// Contiene funzioni e metodi utilizzati solo dagli editor.
    /// In cascata eredita da BasePage e BasePageMaster
    /// </summary>
    public class BasePageEditor : BasePage
    {
        #region OnInit
        /// <summary>
        /// Override onInit Base Page
        /// </summary>
        /// <param name="e"></param>
        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //}

        #endregion

        #region Web Control Declaration

        //PULSANTI STANDARD
        protected Button SaveButton;
        protected Button CloseButton;
        protected Button PrintButton;
        protected Button HelpButton;
        //protected Button SearchButton;
        
        #endregion

        #region Standard_Button


        /// <summary>
        /// Genera pulsantiera standard per gli Editor di tipo SubstituteBrowser
        /// </summary>
        /// <param name="percorso">Percorso del browser di ritorno</param>
        protected void GenerateStandardEditorButtons_SubstituteBrowser(string percorso)
        {
            GenerateStandardEditorButtons(editRow_SubstituteBrowser, percorso, true, true, true, true, false);
        }

        /// <summary>
        /// Genera pulsantiera standard per gli Editor di tipo PopUp (Dialog)
        /// </summary>
        protected void GenerateStandardEditorButtons_PopUp()
        {
            GenerateStandardEditorButtons(editRow_PopUp, null, true, true, true, true, false);
        }

        /// <summary>
        /// Genera pulsantiera standard per gli Editor. Richiede la presenza del div "toolbar"
        /// </summary>
        /// <param name="editorType">Tipologia dell'editor (substitute, popUp)</param>
        /// <param name="percorso">Percorso del browser di ritorno (valorizzato solo nel caso di SubstituteBrowser)</param>
        /// <param name="enableSave"></param>
        /// <param name="enableClose"></param>
        /// <param name="enablePrint"></param>
        /// <param name="enableExport"></param>
        /// <param name="enableNew"></param>
        /// <param name="enableHelp"></param>
        /// <param name="enableSearch"></param>
        protected void GenerateStandardEditorButtons(int editorType, string percorso, bool enableSave, bool enableClose, bool enablePrint, bool enableHelp, bool enableSearch)
        {
            GenerateStandardEditorButtons(editorType, percorso, "toolbar", enableSave, enableClose, enablePrint, enableHelp, enableSearch);
        }

        /// <summary>
        /// Genera pulsantiera standard per gli Editor. Può essere definito un div differente da "toolbar"
        /// </summary>
        /// <param name="editorType">Tipologia dell'editor (substitute, popUp)</param>
        /// <param name="percorso">Percorso del browser di ritorno (valorizzato solo nel caso di SubstituteBrowser)</param>
        /// <param name="idPlaceHolder">Id del placeholder nel caso fosse diverso da "toolbar"</param>
        /// <param name="enableSave"></param>
        /// <param name="enableClose"></param>
        /// <param name="enablePrint"></param>
        /// <param name="enableExport"></param>
        /// <param name="enableNew"></param>
        /// <param name="enableHelp"></param>
        /// <param name="enableSearch"></param>
        protected void GenerateStandardEditorButtons(int editorType, string percorso, string idPlaceHolder, bool enableSave, bool enableClose, bool enablePrint, bool enableHelp, bool enableSearch)
        {
                Control toolbarPlaceHolder = null;
                if (this.Page.Form != null)
                {
                    toolbarPlaceHolder = this.Page.Form.FindControl(idPlaceHolder);
                }
                if (toolbarPlaceHolder != null)
                {
                    HtmlGenericControl span;

                    if (enableHelp)
                    {
                        span = new HtmlGenericControl("span");
                        HelpButton = new Button();
                        HelpButton.ID = "HelpButton";
                        HelpButton.ToolTip = GetValueDizionarioUI("HELP");

                        string className = this.Page.GetType().BaseType.Name;
                        HelpButton.OnClientClick = "openHelp('" + className + "');return false;";

                        span.Controls.Add(HelpButton);
                        toolbarPlaceHolder.Controls.AddAt(0, span);
                    }

                    if (enablePrint)
                    {
                        span = new HtmlGenericControl("span");
                        PrintButton = new Button();
                        PrintButton.ID = "PrintButton";
                        PrintButton.OnClientClick = "PrintPage();return false;";
                        PrintButton.ToolTip = GetValueDizionarioUI("STAMPA");
                        span.Controls.Add(PrintButton);
                        toolbarPlaceHolder.Controls.AddAt(0, span);
                    }

                    if (enableClose)
                    {
                        span = new HtmlGenericControl("span");
                        CloseButton = new Button();
                        CloseButton.ID = "CloseButton";

                        switch (editorType)
                        {
                            case editRow_PopUp:

                                CloseButton.OnClientClick = "buttonAnnulla();return false;";
                                break;

                            case editRow_SubstituteBrowser:
                                
                                CloseSubstituteEditor(percorso);
                                break;
                        }

                        CloseButton.UseSubmitBehavior = false;
                        CloseButton.ToolTip = GetValueDizionarioUI("USCITA");
                        span.Controls.Add(CloseButton);
                        toolbarPlaceHolder.Controls.AddAt(0, span);
                    }

                    if (enableSave)
                    {
                        span = new HtmlGenericControl("span");
                        SaveButton = new Button();
                        SaveButton.ID = "SaveButton";
                        SaveButton.ToolTip = GetValueDizionarioUI("BTN_CONFERMA");

                        span.Controls.Add(SaveButton);
                        toolbarPlaceHolder.Controls.AddAt(0, span);
                    }
                }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        protected void RegisterScriptClosePopUpEditor()
        {
            if (!this.ClientScript.IsStartupScriptRegistered("CloseDialog_Js"))
            {
                this.ClientScript.RegisterStartupScript(GetType(), "CloseDialog_Js", this.CloseDialog_Js());
            }
        }

        /// <summary>
        /// Chiudo la Editor Dialog
        /// </summary>
        /// <returns></returns>
        public string CloseDialog_Js()
        {
            string js = @"
                <script type='text/javascript'>                    
				    self.parent.hideEditorDialog();                                                          
                    parent.frames['frameContent'].refreshBrowser(); 
				</script>";
            return js;
        }

        /// <summary>
        /// Chiudo l'Editor nel caso SubstituteBrowser. Viene effettuato un Redirect al Browser
        /// </summary>
        /// <param name="percorso">Nome del Browser di destinazione</param>
        protected void CloseSubstituteEditor(string percorso)
        {
            CloseButton.Attributes["onClick"] = "closeSubstituteEditor('" + percorso + "');return false;";
        }

        /// <summary>
        /// Registrazione chiamata per pulsante Chiudi
        /// </summary>
        protected void RegisterScriptButtonAnnulla()
        {
            if (!this.ClientScript.IsStartupScriptRegistered("ButtonAnnulla_Js"))
            {
                this.ClientScript.RegisterStartupScript(GetType(), "ButtonAnnulla_Js", this.ButtonAnnulla_Js());
            }
        }

        public string ButtonAnnulla_Js()
        {
            string MsgUscita = GetValueDizionarioUI("USCITA_SENZA_SALVARE");

            //Uscita con controllo sul salvataggio dei dati cambiati
            string js = @"
                <script type='text/javascript'>
				function buttonAnnulla()
				{                       
                    if ($('#form2').FormObserve_changedForm()) 
                    { 
                        if (confirm('" + @MsgUscita + @"'))
                        {                                                           
                            self.parent.hideEditorDialog(); 
                            parent.frames['frameContent'].refreshBrowser();                       
                        }
                        else{
                            return false;
                        }   
                    }
                    else
                        self.parent.hideEditorDialog(); 
        
                    return true;                
				}	
				</script>";

            return js;
        }
    }
}