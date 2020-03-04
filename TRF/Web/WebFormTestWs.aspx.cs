using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SDG_DEMO.TRFws;
using System.Net;
using BusinessObjects;
using SDG.Utility;
using System.Configuration;

namespace TRF.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ButtonOk.ServerClick += new EventHandler(ButtonOk_ServerClick);
            DdlMetodo.SelectedIndexChanged += new EventHandler(DdlMetodo_SelectedIndexChanged);
            if (!IsPostBack)
            {
                DdlMetodo.Items.Add(new ListItem("WsNuovaRichiesta", "0"));
                DdlMetodo.Items.Add(new ListItem("WsAnnullaRichiesta", "1"));
                DdlMetodo.Items.Add(new ListItem("WsSbloccaRichiesta", "2"));
                DdlMetodo.Items.Add(new ListItem("WsVisualizzaRichiesta", "3"));
                DdlMetodo.Items.Add(new ListItem("WsModificaRichiesta", "4"));
                DdlMetodo.Items.Add(new ListItem("WsRichiestaFruita", "5"));
                DdlMetodo.Items.Add(new ListItem("WsRichiestaNonFruita", "6"));
                DdlMetodo.Items.Add(new ListItem("WsNotificaRichieste", "7"));       

                if (DdlMetodo.SelectedValue == "0")
                {
                    DdlEvento.Items.Add(new ListItem("Processo terminato con successo.", "0"));
                    DdlEvento.Items.Add(new ListItem("Il DataSet in input non contiene tutte le tabelle necessarie", "1"));
                    DdlEvento.Items.Add(new ListItem("IdMissione non presente nel ds", "2"));
                    DdlEvento.Items.Add(new ListItem("Il DataSet deve contenere almeno un dettaglio di prenotazione", "3"));
                }
            }            
        }

        void DdlMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            divUser_Dominio.Visible = false;
            DdlEvento.Items.Clear();
            if (DdlMetodo.SelectedValue == "0")
            {                
                DdlEvento.Items.Add(new ListItem("Processo terminato con successo.", "0"));
                DdlEvento.Items.Add(new ListItem("Il DataSet in input non contiene tutte le tabelle necessarie", "1"));
                DdlEvento.Items.Add(new ListItem("IdMissione non presente nel ds", "2"));
                DdlEvento.Items.Add(new ListItem("Il DataSet deve contenere almeno un dettaglio di prenotazione", "3"));           
            }
            if (DdlMetodo.SelectedValue == "7"){
                divUser_Dominio.Visible = true;
            }
        }
        
        void ButtonOk_ServerClick(object sender, EventArgs e)
        {
            wsTRFRichiesta ws = new wsTRFRichiesta();
            //ws.Credentials = new System.Net.NetworkCredential("wsMps", "Password03");
            //string test = RichiestaViaggio.List().GetXml();
            string serverWs = Convert.ToString(ConfigurationManager.AppSettings["ApplicationPath"]);
            ws.Credentials = CredentialCache.DefaultNetworkCredentials;//(currently logged on user)
            DataSet dsInput = new DataSet();
            DataSet dsOutput = new DataSet();

            if (DdlMetodo.SelectedValue == "0")
            {
                if (DdlEvento.SelectedValue == "0")
                {
                    dsInput.ReadXmlSchema(serverWs + @"XmlData\TRF_Schema.xsd");
                    dsInput.ReadXml(serverWs + @"XmlData\DatiRichiesta.xml");
                } 
                else if (DdlEvento.SelectedValue == "1")
                {
                    dsInput.ReadXmlSchema(serverWs + @"XmlData\TRF_Schema.xsd");
                    dsInput.ReadXml(serverWs + @"XmlData\DatiRichiestaErrore1.xml");                
                }
                else if (DdlEvento.SelectedValue == "2")
                {
                    dsInput.ReadXmlSchema(serverWs + @"XmlData\TRF_Schema.xsd");
                }
                else if (DdlEvento.SelectedValue == "3")
                {
                    dsInput.ReadXmlSchema(serverWs + @"XmlData\TRF_Schema.xsd");
                    dsInput.ReadXml(serverWs + @"XmlData\DatiRichiestaErrore3.xml");
                }
                
                if (TextIdMissione.Value != string.Empty)
                {
                    if (dsInput.Tables.Contains("Richiesta"))
                        if (dsInput.Tables["Richiesta"].Rows.Count>0)
                            dsInput.Tables["Richiesta"].Rows[0]["IdMissione"] = TextIdMissione.Value;
                }
                dsOutput = ws.WsNuovaRichiesta(dsInput);
            }
            if (DdlMetodo.SelectedValue == "1")
            {
                dsOutput = ws.WsAnnullaRichiesta(TextIdMissione.Value);
            }
            if (DdlMetodo.SelectedValue == "2")
            {
                dsOutput = ws.WsSbloccaRichiesta(TextIdMissione.Value);
            }
            if (DdlMetodo.SelectedValue == "3")
            {
                dsOutput = ws.WsVisualizzaRichiesta(TextIdMissione.Value);
            }
            if (DdlMetodo.SelectedValue == "4")
            {
                dsInput.ReadXmlSchema(serverWs + @"XmlData\TRF_Schema.xsd");
                dsInput.ReadXml(serverWs + @"XmlData\DatiRichiestaModifica.xml");

                if (TextIdMissione.Value != string.Empty)
                {
                    if (dsInput.Tables.Contains("Richiesta"))
                        if (dsInput.Tables["Richiesta"].Rows.Count > 0)
                            dsInput.Tables["Richiesta"].Rows[0]["IdMissione"] = TextIdMissione.Value;
                }

                dsOutput = ws.WsModificaRichiesta(dsInput);
            } 
            if (DdlMetodo.SelectedValue == "5")
            {
                dsOutput = ws.WsRichiestaFruita(TextIdMissione.Value);
            } 
            if (DdlMetodo.SelectedValue == "6")
            {
                dsOutput = ws.WsRichiestaFruita(TextIdMissione.Value);
            }
            if (DdlMetodo.SelectedValue == "7")
            {
                dsOutput = ws.WsNotificaRichieste(TextUserName.Value, TextDomain.Value);
            }
            TextAreaResultData.InnerText = dsOutput.GetXml();
            TextAreaResultSchema.InnerText = dsOutput.GetXmlSchema();
        }
    }
}
