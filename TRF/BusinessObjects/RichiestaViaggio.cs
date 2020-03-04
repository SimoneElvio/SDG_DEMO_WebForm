#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   RichiestaViaggio.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per RICHIESTAVIAGGIO
//
// Autore:      AR - SDG srl
// Data:        07/09/2009
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SDG.ExceptionHandling;
using SDG.Basepage;
//using AutoMapper;

namespace BusinessObjects
{
    /// <summary>
    /// Tabella RICHIESTA_VIAGGIO 
    /// </summary>
    public class RichiestaViaggio
    {
        #region attributi e variabili

        private SqlInt32 riv_id_richiesta = SqlInt32.Null;
        private SqlInt32 ute_id_utente = SqlInt32.Null;
        private SqlInt32 ute_id_utente_da_assegnare = SqlInt32.Null;
        private SqlInt32 lkt_id_tipologia = SqlInt32.Null;
        private SqlInt32 ute_ute_id_utente = SqlInt32.Null;
        private SqlInt32 lsr_id_stato_richiesta = SqlInt32.Null;
        private SqlInt32 lkp_id_pagamento = SqlInt32.Null;
        private SqlInt32 lkb_id_biglietto = SqlInt32.Null;
        private SqlInt32 lke_id_tipo_aereo = SqlInt32.Null;
        private SqlString riv_id_missione_cliente = SqlString.Null;
        private SqlString riv_destinazione_primaria = SqlString.Null;
        private SqlDateTime riv_data_pred_biglietti = SqlDateTime.Null;
        private SqlString riv_motivo_trasferta = SqlString.Null;
        private SqlInt32 riv_flag_ospite = SqlInt32.Null;
        private SqlInt32 riv_durata = SqlInt32.Null;
        private SqlInt32 riv_flag_anticipo_spese = SqlInt32.Null;
        private SqlDecimal riv_totale_viaggio = SqlDecimal.Null;
        private SqlString riv_motivo_biglietto_cartaceo = SqlString.Null;
        private SqlString riv_motivo_volo_normale = SqlString.Null;        
        private SqlInt32 riv_flag_eliminata = SqlInt32.Null;
        private SqlString via_cognome = SqlString.Null;
        private SqlString via_nome = SqlString.Null;
        private SqlString ric_nome = SqlString.Null;
        private SqlString ric_cognome = SqlString.Null;
        private SqlString ric_telefono = SqlString.Null;
        private SqlString ric_fax = SqlString.Null;
        private SqlString ric_email = SqlString.Null;
        private SqlDateTime ric_data_consegna_titoli = SqlDateTime.Null;
        private SqlString ric_presso = SqlString.Null;
        private SqlString ric_email_invio_titoli = SqlString.Null;
        private SqlString lsr_descrizione = SqlString.Null;
        private SqlString trr_nome_cognome_utente = SqlString.Null;
        private SqlDateTime trr_data_ora = SqlDateTime.Null;
        private SqlString trr_note = SqlString.Null;        
        private SqlString ric_operatore = SqlString.Null;
        private SqlDateTime riv_data_assegnazione = SqlDateTime.Null;
        private SqlString riv_data_prima_scadenza = SqlString.Null;        
        private SqlInt32 cdc_id_centro_di_costo = SqlInt32.Null;
        private SqlString cdc_codice_centro_di_costo = SqlString.Null;        
        private SqlInt32 idViaggiatore = SqlInt32.Null;
        private SqlInt32 idRichiedente = SqlInt32.Null;
        private SqlInt32 idAutorizzatore = SqlInt32.Null;        
        private SqlString viaggiatore = SqlString.Null;
        private SqlString autorizzatore = SqlString.Null;
        private SqlString cdc_addebito = SqlString.Null;
        private SqlInt32 riv_flag_pernottamento = SqlInt32.Null;
        private SqlInt32 riv_flag_norma = SqlInt32.Null;
        private SqlInt32 riv_flag_estero = SqlInt32.Null;
        private SqlInt32 ute_ute_id_utente2 = SqlInt32.Null;        
        private SqlString autorizzatore2 = SqlString.Null;        
        private SqlDateTime riv_data_richiesta = SqlDateTime.Null;
        private SqlDateTime riv_data_conferma = SqlDateTime.Null;
        private SqlInt32 ltm_id_tipo_modulo = SqlInt32.Null;
        private SqlString riv_nro_ordine = SqlString.Null;
        private SqlString riv_autorizzatori_bck = SqlString.Null;
        private SqlString riv_cli_ragione_sociale = SqlString.Null;
        private SqlInt32 riv_flag_autorizzazione_richiesta = SqlInt32.Null;
        private SqlInt32 riv_flag_autorizzazione_forzata = SqlInt32.Null;
        private SqlInt32 riv_flag_aut_policy = SqlInt32.Null;
        private SqlInt32 riv_flag_aut_chargeable = SqlInt32.Null;
        private SqlInt32 riv_flag_altro_cdc = SqlInt32.Null;
        private SqlInt32 riv_mese_cdc = SqlInt32.Null;
        private SqlString riv_tmp_wrf_codice = SqlString.Null;
        private SqlDateTime riv_data_prima_scadenza_riv = SqlDateTime.Null;
        private SqlDateTime riv_data_arrivo = SqlDateTime.Null;
        private SqlInt32 riv_flag_invio_notifica = SqlInt32.Null;
        private SqlString lsr_chiave_dizionario = SqlString.Null;
        private SqlInt32 crc_id_reason_code = SqlInt32.Null;
        private SqlInt32 crc_flag_aut = SqlInt32.Null;
        private SqlString ric_matricola = SqlString.Null;
        private SqlInt32 riv_last_user_funzionalita = SqlInt32.Null;
        private SqlString riv_gruppo = SqlString.Null;
        private SqlString riv_societa_cliente_rifatturazione = SqlString.Null;
        private SqlString riv_nome_richiesta = SqlString.Null;   
		private SqlString riv_motivo_rifatturazione = SqlString.Null;     

        //Campi dinamici
        private SqlString riv_aux1 = SqlString.Null;
        private SqlString riv_aux2 = SqlString.Null;
        private SqlString riv_aux3 = SqlString.Null;
        private SqlInt32 riv_aux4 = SqlInt32.Null;
        private SqlInt32 riv_aux5 = SqlInt32.Null;
        private SqlString riv_aux6 = SqlString.Null;        
        private SqlInt32 riv_aux7 = SqlInt32.Null;
        private SqlInt32 riv_aux8 = SqlInt32.Null;
        private SqlInt32 riv_aux9 = SqlInt32.Null;
        private SqlString riv_aux10 = SqlString.Null;
        private SqlInt32 riv_aux11 = SqlInt32.Null;
        private SqlInt32 riv_aux12 = SqlInt32.Null;
        private SqlString riv_nro_telefono_viaggiatore = SqlString.Null;
        private SqlString riv_email_viaggiatore = SqlString.Null;
        private SqlInt32 riv_flag_invio_documenti_viaggiatore = SqlInt32.Null;
        private SqlDecimal riv_proposto_air = SqlDecimal.Null;
        private SqlDecimal riv_proposto_hotel = SqlDecimal.Null;
        private SqlDecimal riv_proposto_treni = SqlDecimal.Null;
        private SqlDecimal riv_proposto_auto = SqlDecimal.Null;
        private SqlDecimal riv_proposto_altro = SqlDecimal.Null;
        private SqlDecimal riv_venduto_air = SqlDecimal.Null;
        private SqlDecimal riv_venduto_hotel = SqlDecimal.Null;
        private SqlDecimal riv_venduto_treni = SqlDecimal.Null;
        private SqlDecimal riv_venduto_auto = SqlDecimal.Null;
        private SqlDecimal riv_venduto_altro = SqlDecimal.Null;
        private SqlInt32 riv_flag_out_of_policy_air = SqlInt32.Null;
        private SqlInt32 riv_flag_out_of_policy_hotel = SqlInt32.Null;
        private SqlInt32 cco_id_cross_out_of_policy = SqlInt32.Null;
        private SqlInt32 cco_cco_id_cross_out_of_policy = SqlInt32.Null;
        private SqlString riv_pagina_editor = SqlString.Null;        
        private SqlString cdc_richiedente = SqlString.Null;
        private SqlString cdc_viaggiatore = SqlString.Null;
        private SqlString riv_nro_riferimento_preventivo = SqlString.Null;
        private SqlInt32 id_societa = SqlInt32.Null;
        private SqlInt32 riv_flag_ws_status = SqlInt32.Null;
        private SqlString crc_descrizione_it = SqlString.Null;
        private SqlString lst_descrizione = SqlString.Null;        
        private SqlInt32 lsa_id_stato_autorizzazione = SqlInt32.Null;
        private SqlInt32 lsa_id_stato_autorizzazione2 = SqlInt32.Null;                
        private SqlInt32 cli_id_cliente = SqlInt32.Null;
        private SqlInt32 ric_id_utente = SqlInt32.Null;          
        private SqlString richiedente = SqlString.Null;
        private SqlInt32 lsl_id_societa_cliente = SqlInt32.Null;
        private SqlInt32 lsl_id_societa_cliente_rifatturazione = SqlInt32.Null;
        private SqlInt32 riv_flag_rifatturazione = SqlInt32.Null;
        private SqlInt32 days = SqlInt32.Null;
        private SqlInt32 riv_riv_id_richiesta = SqlInt32.Null;
        private SqlDateTime riv_data_dal = SqlDateTime.Null;
        private SqlDateTime riv_data_al = SqlDateTime.Null;

        // Export XLS
        private SqlDateTime riv_data_export_da = SqlDateTime.Null;
        private SqlDateTime riv_data_export_a = SqlDateTime.Null;

        private string sqlWhereClause = "";

        private int IdUtenteWs = Convert.ToInt32(ConfigurationManager.AppSettings["IdUtenteWs"]);

        #endregion

        #region Proprieta

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_id_richiesta
        {
            get { return riv_id_richiesta; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 IdViaggiatore
        {
            get { return idViaggiatore; }
            set { idViaggiatore = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cli_id_cliente
        {
            get { return cli_id_cliente; }
            set { cli_id_cliente = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Days
        {
            get { return days; }
            set { days = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_flag_invio_notifica
        {
            get { return riv_flag_invio_notifica; }
            set { riv_flag_invio_notifica = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_flag_ws_status
        {
            get { return riv_flag_ws_status; }
            set { riv_flag_ws_status = value; }
        }
        
        /// <value>
        /// 
        /// </value>
        public SqlString Riv_tmp_wrf_codice
        {
            get { return riv_tmp_wrf_codice; }
            set { riv_tmp_wrf_codice = value; }
        }

        /// <value>
        /// Id Utente operatore
        /// </value>
        public SqlInt32 Ute_id_utente
        {
            get { return ute_id_utente; }
            set { ute_id_utente = value; }
        }

        /// <value>
        /// Id Utente operatore desiderato per la pratica
        /// </value>
        public SqlInt32 Ute_id_utente_da_assegnare
        {
            get { return ute_id_utente_da_assegnare; }
            set { ute_id_utente_da_assegnare = value; }
        }

        /// <value>
        /// funzionalità ultimo utente che ha salvato
        /// </value>
        public SqlInt32 Riv_last_user_funzionalita
        {
            get { return riv_last_user_funzionalita; }
            set { riv_last_user_funzionalita = value; }
        }

        /// <value>
        /// Id Richiedente
        /// </value>
        public SqlInt32 Ric_id_utente
        {
            get { return ric_id_utente; }
            set { ric_id_utente = value; }
        }

        /// <value>
        /// Id Utente Autorizzatore2.
        /// </value>
        public SqlInt32 Ute_ute_id_utente2
        {
            get { return ute_ute_id_utente2; }
            set { ute_ute_id_utente2 = value; }
        }
         
        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Ute_ute_id_utente
        {
            get { return ute_ute_id_utente; }
            set { ute_ute_id_utente = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsr_id_stato_richiesta
        {
            get { return lsr_id_stato_richiesta; }
            set { lsr_id_stato_richiesta = value; }
        }
      
        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsa_id_stato_autorizzazione
        {
            get { return lsa_id_stato_autorizzazione; }
            set { lsa_id_stato_autorizzazione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsa_id_stato_autorizzazione2
        {
            get { return lsa_id_stato_autorizzazione2; }
            set { lsa_id_stato_autorizzazione2 = value; }
        }
        
        /// <value>
        /// Numero univoco della richiesta di missione del cliente : Data - ora - pa20090831-123233-xxxxxxxxxdove xxxxxxxx  è la pa del dipendente
        /// </value>
        public SqlString Riv_id_missione_cliente
        {
            get { return riv_id_missione_cliente; }
            set { riv_id_missione_cliente = value; }
        }

        /// <value>
        /// Numero univoco della richiesta di missione del cliente : Data - ora - pa20090831-123233-xxxxxxxxxdove xxxxxxxx  è la pa del dipendente
        /// </value>
        public SqlString Riv_cli_ragione_sociale
        {
            get { return riv_cli_ragione_sociale; }
            set { riv_cli_ragione_sociale = value; }
        }

        /// <value>
        /// data predisposizione biglietti
        /// </value>
        public SqlDateTime Riv_data_richiesta
        {
            get { return riv_data_richiesta; }
            set { riv_data_richiesta = value; }
        }

        /// <value>
        /// data prima scadenza, nominata cosi perchè ce n'è un altra per i moduli ABC di un altro tipo di dato
        /// </value>
        public SqlDateTime Riv_data_prima_scadenza_riv
        {
            get { return riv_data_prima_scadenza_riv; }
            set { riv_data_prima_scadenza_riv = value; }
        }
      
        /// <value>
        /// 
        /// </value>
        public SqlString Autorizzatore
        {
            get { return autorizzatore; }
            set { autorizzatore = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_motivo_trasferta
        {
            get { return riv_motivo_trasferta; }
            set { riv_motivo_trasferta = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Autorizzatore2
        {
            get { return autorizzatore2; }
            set { autorizzatore2 = value; }
        }

        /// <value>
        /// Indica se ospite o meno
        /// </value>
        public SqlInt32 Riv_flag_ospite
        {
            get { return riv_flag_ospite; }
            set { riv_flag_ospite = value; }
        }


        /// <value>
        /// o luogo missione
        /// </value>
        public SqlString Lsr_chiave_dizionario
        {
            get { return lsr_chiave_dizionario; }
            set { lsr_chiave_dizionario = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Via_cognome
        {
            get { return via_cognome; }
            set { via_cognome = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Via_nome
        {
            get { return via_nome; }
            set { via_nome = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Viaggiatore
        {
            get { return viaggiatore; }
            set { viaggiatore = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ric_nome
        {
            get { return ric_nome; }
            set { ric_nome = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ric_cognome
        {
            get { return ric_cognome; }
            set { ric_cognome = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ric_telefono
        {
            get { return ric_telefono; }
            set { ric_telefono = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ric_email
        {
            get { return ric_email; }
            set { ric_email = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ric_email_invio_titoli
        {
            get { return ric_email_invio_titoli; }
            set { ric_email_invio_titoli = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlDateTime Trr_data_ora
        {
            get { return trr_data_ora; }
            set { trr_data_ora = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cdc_id_centro_di_costo
        {
            get { return cdc_id_centro_di_costo; }
            set { cdc_id_centro_di_costo = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Trr_nome_cognome_utente
        {
            get { return trr_nome_cognome_utente; }
            set { trr_nome_cognome_utente = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ric_operatore
        {
            get { return ric_operatore; }
            set { ric_operatore = value; }
        }

        /// <value>
        /// data assegnazione
        /// </value>
        public SqlDateTime Riv_data_assegnazione
        {
            get { return riv_data_assegnazione; }
            set { riv_data_assegnazione = value; }
        }

        /// <value>
        /// o luogo missione
        /// </value>
        public SqlString Riv_data_prima_scadenza
        {
            get { return riv_data_prima_scadenza; }
            set { riv_data_prima_scadenza = value; }
        }
 
        /// <value>
        /// o luogo missione
        /// </value>
        public SqlDateTime Riv_data_conferma
        {
            get { return riv_data_conferma; }
            set { riv_data_conferma = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlInt32 Ltm_id_tipo_modulo
        {
            get { return ltm_id_tipo_modulo; }
            set { ltm_id_tipo_modulo = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_aux1
        {
            get { return riv_aux1; }
            set { riv_aux1 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_aux2
        {
            get { return riv_aux2; }
            set { riv_aux2 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_aux3
        {
            get { return riv_aux3; }
            set { riv_aux3 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_aux4
        {
            get { return riv_aux4; }
            set { riv_aux4 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_aux5
        {
            get { return riv_aux5; }
            set { riv_aux5 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_aux6
        {
            get { return riv_aux6; }
            set { riv_aux6 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_gruppo
        {
            get { return riv_gruppo; }
            set { riv_gruppo = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_aux7
        {
            get { return riv_aux7; }
            set { riv_aux7 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_aux8
        {
            get { return riv_aux8; }
            set { riv_aux8 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_aux9
        {
            get { return riv_aux9; }
            set { riv_aux9 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_aux10
        {
            get { return riv_aux10; }
            set { riv_aux10 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_aux11
        {
            get { return riv_aux11; }
            set { riv_aux11 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_aux12
        {
            get { return riv_aux12; }
            set { riv_aux12 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_nro_telefono_viaggiatore
        {
            get { return riv_nro_telefono_viaggiatore; }
            set { riv_nro_telefono_viaggiatore = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_email_viaggiatore
        {
            get { return riv_email_viaggiatore; }
            set { riv_email_viaggiatore = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_flag_autorizzazione_richiesta
        {
            get { return riv_flag_autorizzazione_richiesta; }
            set { riv_flag_autorizzazione_richiesta = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_flag_autorizzazione_forzata
        {
            get { return riv_flag_autorizzazione_forzata; }
            set { riv_flag_autorizzazione_forzata = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Riv_flag_rifatturazione
        {
            get { return riv_flag_rifatturazione; }
            set { riv_flag_rifatturazione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_societa_cliente_rifatturazione
        {
            get { return riv_societa_cliente_rifatturazione; }
            set { riv_societa_cliente_rifatturazione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_motivo_rifatturazione
        {
            get { return riv_motivo_rifatturazione; }
            set { riv_motivo_rifatturazione = value; }
        }        

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsl_id_societa_cliente_rifatturazione
        {
            get { return lsl_id_societa_cliente_rifatturazione; }
            set { lsl_id_societa_cliente_rifatturazione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsl_id_societa_cliente
        {
            get { return lsl_id_societa_cliente; }
            set { lsl_id_societa_cliente = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_pagina_editor
        {
            get { return riv_pagina_editor; }
            set { riv_pagina_editor = value; }
        }

        public SqlString Richiedente
        {
            get { return richiedente; }
            set { richiedente = value; }
        }

        /// <summary>
        /// Export XLS
        /// </summary>
        public SqlDateTime Riv_data_export_da
        {
            get { return riv_data_export_da; }
            set { riv_data_export_da = value; }
        }

        /// <summary>
        /// Export XLS
        /// </summary>
        public SqlDateTime Riv_data_export_a
        {
            get { return riv_data_export_a; }
            set { riv_data_export_a = value; }
        }

        public SqlInt32 Riv_riv_id_richiesta
        {
            get { return riv_riv_id_richiesta; }
            set { riv_riv_id_richiesta = value; }
        }
        
        public SqlDateTime Riv_data_dal
        {
            get { return riv_data_dal; }
            set { riv_data_dal = value; }
        }

        public SqlDateTime Riv_data_al
        {
            get { return riv_data_al; }
            set { riv_data_al = value; }
        }

        public SqlString Riv_nome_richiesta
        {
            get { return riv_nome_richiesta; }
            set { riv_nome_richiesta = value; }
        }

        public string SqlWhereClause
        {
            get { return sqlWhereClause; }
            set { sqlWhereClause = value; }
        }
        #endregion

        #region Costruttori

        /// <summary>
        /// Costruttore standard
        /// </summary>
        public RichiestaViaggio()
        {

        }

        #endregion
        
        #region Metodi Richiesta Viaggio

        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        /// <param name="p_riv_id_richiesta">Id richiesta</param>
        public void Read(SqlInt32 p_riv_id_richiesta)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 RICHIESTA_VIAGGIO.riv_id_richiesta, 
					 RICHIESTA_VIAGGIO.ute_id_utente, 
					 RICHIESTA_VIAGGIO.ute_ute_id_utente, 
					 RICHIESTA_VIAGGIO.lsr_id_stato_richiesta, 
					 RICHIESTA_VIAGGIO.riv_id_missione_cliente, 					 
					 RICHIESTA_VIAGGIO.riv_flag_ospite, 
					 VIAGGIATORI.via_cognome,
                     VIAGGIATORI.via_nome,
                     RICHIEDENTE.ric_cognome,
                     RICHIEDENTE.ric_nome,
                     RICHIEDENTE.ric_telefono,
                     RICHIEDENTE.ric_fax,
                     RICHIEDENTE.ric_email,
                     RICHIEDENTE.ric_email_invio_titoli,
                     LOOKUP_STATO_RICHIESTA.LSR_DESCRIZIONE,                     
                     TRANSAZIONI_RICHIESTA.TRR_DATA_ORA,
                     TRANSAZIONI_RICHIESTA.TRR_NOTE,
                     TRANSAZIONI_RICHIESTA.LSR_ID_STATO_RICHIESTA,
                     COALESCE(UTENTE.UTE_COGNOME + ' ' + UTENTE.UTE_NOME,UTENTE.UTE_COGNOME) AS OPERATORE,
                     RICHIESTA_VIAGGIO.RIV_DATA_ASSEGNAZIONE,
                     VIAGGIATORI.ute_id_utente,
                     COALESCE(VIAGGIATORI.VIA_COGNOME + ' ' + VIAGGIATORI.VIA_NOME,VIAGGIATORI.VIA_COGNOME) AS VIAGGIATORE,
                     COALESCE(AUTORIZZATORE.UTE_COGNOME + ' ' + AUTORIZZATORE.UTE_NOME,AUTORIZZATORE.UTE_COGNOME) AS AUTORIZZATORE,                     
                     RICHIESTA_VIAGGIO.riv_id_missione_cliente,                     
                     RICHIESTA_VIAGGIO.ute_ute_id_utente2,
                     COALESCE(AUTORIZZATORE2.UTE_COGNOME + ' ' + AUTORIZZATORE2.UTE_NOME,AUTORIZZATORE2.UTE_COGNOME) AS AUTORIZZATORE2,
                     RICHIEDENTE.UTE_ID_UTENTE,
                     RICHIESTA_VIAGGIO.RIV_AUX1,
                     RICHIESTA_VIAGGIO.RIV_AUX2,
                     RICHIESTA_VIAGGIO.RIV_AUX3,
                     RICHIESTA_VIAGGIO.RIV_AUX4,
                     RICHIESTA_VIAGGIO.RIV_AUX5,
                     RICHIESTA_VIAGGIO.LSA_ID_STATO_AUTORIZZAZIONE,
                     RICHIESTA_VIAGGIO.LSA_ID_STATO_AUTORIZZAZIONE2,
                     RICHIESTA_VIAGGIO.riv_pagina_editor,
                     RICHIESTA_VIAGGIO.riv_flag_autorizzazione_richiesta,
                     RICHIESTA_VIAGGIO.riv_tmp_wrf_codice,
                     RICHIESTA_VIAGGIO.cli_id_cliente,
                     RICHIEDENTE.ute_id_utente,
                     RICHIESTA_VIAGGIO.riv_cli_ragione_sociale,
                     RICHIESTA_VIAGGIO.riv_data_prima_scadenza,
                     COALESCE(RICHIEDENTE.RIC_COGNOME + ' ' + RICHIEDENTE.RIC_NOME,RICHIEDENTE.RIC_COGNOME) AS RICHIEDENTE,
                     LOOKUP_STATO_RICHIESTA.LSR_CHIAVE_DIZIONARIO,
                     RICHIESTA_VIAGGIO.RIV_AUX6,
                     RICHIESTA_VIAGGIO.riv_aux7,
                     RICHIESTA_VIAGGIO.riv_aux8,
                     RICHIESTA_VIAGGIO.riv_aux9,
                     RICHIESTA_VIAGGIO.riv_aux10,
                     RICHIESTA_VIAGGIO.riv_nro_telefono_viaggiatore,
                     RICHIESTA_VIAGGIO.riv_email_viaggiatore,
                     RICHIESTA_VIAGGIO.riv_aux11,
                     RICHIESTA_VIAGGIO.riv_aux12,
                     RICHIESTA_VIAGGIO.RIV_DATA_RICHIESTA,
                     CASE WHEN VIAGGIATORI.UTE_ID_UTENTE IS NULL THEN UTE_RIC.LSL_ID_SOCIETA_CLIENTE ELSE UTE_VIA.LSL_ID_SOCIETA_CLIENTE END AS ID_SOCIETA,
                     RICHIESTA_VIAGGIO.RIV_FLAG_WS_STATUS,
                     RICHIESTA_VIAGGIO.RIV_DATA_ARRIVO,
                     LST_DESCRIZIONE,
                     RICHIESTA_VIAGGIO.LSL_ID_SOCIETA_CLIENTE,
                     RICHIESTA_VIAGGIO.RIV_FLAG_RIFATTURAZIONE,
                     RICHIESTA_VIAGGIO.LSL_ID_SOCIETA_CLIENTE_RIFATTURAZIONE,
                     RICHIESTA_VIAGGIO.CDC_ID_CENTRO_DI_COSTO,
                     RICHIESTA_VIAGGIO.riv_flag_autorizzazione_forzata,
                     RICHIESTA_VIAGGIO.RIV_GRUPPO,
                     RICHIESTA_VIAGGIO.RIV_MOTIVO_TRASFERTA,
                     RICHIESTA_VIAGGIO.RIV_SOCIETA_CLIENTE_RIFATTURAZIONE,
                     RICHIESTA_VIAGGIO.riv_riv_id_richiesta,
                     RICHIESTA_VIAGGIO.riv_data_dal,
                     RICHIESTA_VIAGGIO.riv_data_al,
                     RICHIESTA_VIAGGIO.riv_nome_richiesta


                     FROM RICHIESTA_VIAGGIO 
				 	 INNER JOIN TRANSAZIONI_RICHIESTA ON RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = TRANSAZIONI_RICHIESTA.RIV_ID_RICHIESTA AND TRR_FLAG_LAST_INDICATOR = 1
                     INNER JOIN LOOKUP_STATO_RICHIESTA ON TRANSAZIONI_RICHIESTA.LSR_ID_STATO_RICHIESTA = LOOKUP_STATO_RICHIESTA.LSR_ID_STATO_RICHIESTA
                     LEFT JOIN VIAGGIATORI ON RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = VIAGGIATORI.RIV_ID_RICHIESTA
                     LEFT JOIN RICHIEDENTE ON RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = RICHIEDENTE.RIV_ID_RICHIESTA
                     LEFT JOIN UTENTE ON RICHIESTA_VIAGGIO.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE
                     LEFT JOIN UTENTE AUTORIZZATORE ON RICHIESTA_VIAGGIO.UTE_UTE_ID_UTENTE = AUTORIZZATORE.UTE_ID_UTENTE
                     LEFT JOIN UTENTE AUTORIZZATORE2 ON RICHIESTA_VIAGGIO.UTE_UTE_ID_UTENTE2 = AUTORIZZATORE2.UTE_ID_UTENTE                     
                     LEFT JOIN CROSS_CLIENTE_TRASFERTA ON CROSS_CLIENTE_TRASFERTA.CCT_ID_CLIENTE_TRASFERTA = RICHIESTA_VIAGGIO.RIV_AUX4
                     LEFT JOIN LOOKUP_SCOPO_TRASFERTA ON CROSS_CLIENTE_TRASFERTA.LST_ID_SCOPO_TRASFERTA = LOOKUP_SCOPO_TRASFERTA.LST_ID_SCOPO_TRASFERTA
                     LEFT JOIN UTENTE UTE_RIC ON RICHIEDENTE.UTE_ID_UTENTE = UTE_RIC.UTE_ID_UTENTE
                     LEFT JOIN UTENTE UTE_VIA ON VIAGGIATORI.UTE_ID_UTENTE = UTE_VIA.UTE_ID_UTENTE
                     LEFT JOIN PRENOTAZIONI_NOTA_SPESA ON PRENOTAZIONI_NOTA_SPESA.riv_id_richiesta = RICHIESTA_VIAGGIO.riv_riv_id_richiesta
                     
                     WHERE 
                     (RICHIESTA_VIAGGIO.riv_id_richiesta = @riv_id_richiesta) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    int i = 0;

                    riv_id_richiesta = reader.GetSqlInt32(i++);
                    ute_id_utente = reader.GetSqlInt32(i++);
                    ute_ute_id_utente = reader.GetSqlInt32(i++);
                    lsr_id_stato_richiesta = reader.GetSqlInt32(i++);
                    riv_id_missione_cliente = reader.GetSqlString(i++);
                    riv_flag_ospite = reader.GetSqlInt32(i++);
                    via_cognome = reader.GetSqlString(i++);
                    via_nome = reader.GetSqlString(i++);
                    ric_cognome = reader.GetSqlString(i++);
                    ric_nome = reader.GetSqlString(i++);
                    ric_telefono = reader.GetSqlString(i++);
                    ric_fax = reader.GetSqlString(i++);
                    ric_email = reader.GetSqlString(i++);
                    ric_email_invio_titoli = reader.GetSqlString(i++);
                    lsr_descrizione = reader.GetSqlString(i++);
                    trr_data_ora = reader.GetSqlDateTime(i++);
                    trr_note = reader.GetSqlString(i++);
                    lsr_id_stato_richiesta = reader.GetSqlInt32(i++);
                    ric_operatore = reader.GetSqlString(i++);
                    riv_data_assegnazione = reader.GetSqlDateTime(i++);
                    idViaggiatore = reader.GetSqlInt32(i++);
                    Viaggiatore = reader.GetSqlString(i++);
                    Autorizzatore = reader.GetSqlString(i++);
                    riv_id_missione_cliente = reader.GetSqlString(i++);
                    ute_ute_id_utente2 = reader.GetSqlInt32(i++);
                    Autorizzatore2 = reader.GetSqlString(i++);
                    idRichiedente = reader.GetSqlInt32(i++);
                    riv_aux1 = reader.GetSqlString(i++);
                    riv_aux2 = reader.GetSqlString(i++);
                    riv_aux3 = reader.GetSqlString(i++);
                    riv_aux4 = reader.GetSqlInt32(i++);
                    riv_aux5 = reader.GetSqlInt32(i++);
                    lsa_id_stato_autorizzazione = reader.GetSqlInt32(i++);
                    lsa_id_stato_autorizzazione2 = reader.GetSqlInt32(i++);
                    riv_pagina_editor = reader.GetSqlString(i++);
                    riv_flag_autorizzazione_richiesta = reader.GetSqlInt32(i++);
                    riv_tmp_wrf_codice = reader.GetSqlString(i++);
                    cli_id_cliente = reader.GetSqlInt32(i++);
                    ric_id_utente = reader.GetSqlInt32(i++);
                    riv_cli_ragione_sociale = reader.GetSqlString(i++);
                    riv_data_prima_scadenza_riv = reader.GetSqlDateTime(i++);
                    richiedente = reader.GetSqlString(i++);
                    lsr_chiave_dizionario = reader.GetSqlString(i++);
                    riv_aux6 = reader.GetSqlString(i++);
                    riv_aux7 = reader.GetSqlInt32(i++);
                    riv_aux8 = reader.GetSqlInt32(i++);
                    riv_aux9 = reader.GetSqlInt32(i++);
                    riv_aux10 = reader.GetSqlString(i++);
                    riv_nro_telefono_viaggiatore = reader.GetSqlString(i++);
                    riv_email_viaggiatore = reader.GetSqlString(i++);
                    riv_aux11 = reader.GetSqlInt32(i++);
                    riv_aux12 = reader.GetSqlInt32(i++);
                    riv_data_richiesta = reader.GetSqlDateTime(i++);
                    id_societa = reader.GetSqlInt32(i++);
                    riv_flag_ws_status = reader.GetSqlInt32(i++);
                    riv_data_arrivo = reader.GetSqlDateTime(i++);
                    lst_descrizione = reader.GetSqlString(i++);
                    lsl_id_societa_cliente = reader.GetSqlInt32(i++);
                    riv_flag_rifatturazione = reader.GetSqlInt32(i++);
                    lsl_id_societa_cliente_rifatturazione = reader.GetSqlInt32(i++);
                    cdc_id_centro_di_costo = reader.GetSqlInt32(i++);
                    riv_flag_autorizzazione_forzata = reader.GetSqlInt32(i++);
                    riv_gruppo = reader.GetSqlString(i++);
                    riv_motivo_trasferta = reader.GetSqlString(i++);
                    riv_societa_cliente_rifatturazione = reader.GetSqlString(i++);
                    riv_riv_id_richiesta = reader.GetSqlInt32(i++);                    
                    riv_data_dal = reader.GetSqlDateTime(i++);
                    riv_data_al = reader.GetSqlDateTime(i++);
                    riv_nome_richiesta = reader.GetSqlString(i++);
                }

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "RichiestaViaggio.Read.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }

        /// <summary>
        /// Aggiorna l'ggetto nella base dati(Richiesta Viaggio)
        /// </summary>
        /// <param name="p_riv_id_richiesta">Id richiesta</param>
        /// <param name="t"></param>
        /// <param name="db"></param>
        public void Update(SqlInt32 p_riv_id_richiesta, DbTransaction t, Database db)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                //Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE RICHIESTA_VIAGGIO SET
					 ute_id_utente = @ute_id_utente, 			
                     ute_id_utente_da_assegnare = @ute_id_utente_da_assegnare,		 
					 ute_ute_id_utente = @ute_ute_id_utente, 
                     ute_ute_id_utente2 = @ute_ute_id_utente2,                     
					 lsr_id_stato_richiesta = @lsr_id_stato_richiesta, 
					 riv_id_missione_cliente = @riv_id_missione_cliente, 					 					 
                     riv_data_assegnazione = @riv_data_assegnazione, 					 
					 riv_flag_ospite = @riv_flag_ospite, 
					 riv_totale_viaggio = @riv_totale_viaggio, 					 					                      
                     riv_data_conferma = @riv_data_conferma,                     
                     riv_aux1 = @riv_aux1,
                     riv_aux2 = @riv_aux2,
                     riv_aux3 = @riv_aux3,
                     riv_aux4 = @riv_aux4,
                     riv_aux5 = @riv_aux5,                     
                     riv_aux6 = @riv_aux6,
                     cdc_id_centro_di_costo = @cdc_id_centro_di_costo,
                     lsa_id_stato_autorizzazione = @lsa_id_stato_autorizzazione,
                     lsa_id_stato_autorizzazione2 = @lsa_id_stato_autorizzazione2,
                     cli_id_cliente = @cli_id_cliente,
                     riv_cli_ragione_sociale = @riv_cli_ragione_sociale,
                     riv_flag_autorizzazione_richiesta = @riv_flag_autorizzazione_richiesta,                                          
                     riv_flag_autorizzazione_forzata = @riv_flag_autorizzazione_forzata,                                          
                     riv_flag_aut_policy = @riv_flag_aut_policy,                     
                     riv_flag_invio_notifica = @riv_flag_invio_notifica,                     
                     riv_aux7 = @riv_aux7,
                     riv_aux8 = @riv_aux8,
                     riv_aux9 = @riv_aux9,
                     riv_aux10 = @riv_aux10,
                     riv_aux11 = @riv_aux11,
                     riv_aux12 = @riv_aux12,
                     riv_nro_telefono_viaggiatore = @riv_nro_telefono_viaggiatore,
                     riv_email_viaggiatore = @riv_email_viaggiatore,                     
                     lsl_id_societa_cliente = @lsl_id_societa_cliente,
                     riv_flag_rifatturazione = @riv_flag_rifatturazione,
                     lsl_id_societa_cliente_rifatturazione = @lsl_id_societa_cliente_rifatturazione,
                     riv_last_user_funzionalita = @riv_last_user_funzionalita,
                     riv_gruppo = @riv_gruppo,
                     riv_motivo_trasferta = @riv_motivo_trasferta,
                     riv_societa_cliente_rifatturazione = @riv_societa_cliente_rifatturazione,
                     riv_nome_richiesta = @riv_nome_richiesta
                     
					 WHERE (riv_id_richiesta = @riv_id_richiesta) ";


                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "ute_id_utente_da_assegnare", DbType.Int32, ute_id_utente_da_assegnare);
                db.AddInParameter(dbCommand, "ute_ute_id_utente", DbType.Int32, ute_ute_id_utente);
                db.AddInParameter(dbCommand, "ute_ute_id_utente2", DbType.Int32, ute_ute_id_utente2);
                db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, lsr_id_stato_richiesta);
                db.AddInParameter(dbCommand, "riv_id_missione_cliente", DbType.String, riv_id_missione_cliente);
                db.AddInParameter(dbCommand, "riv_data_conferma", DbType.DateTime, riv_data_conferma);
                db.AddInParameter(dbCommand, "riv_data_assegnazione", DbType.DateTime, riv_data_assegnazione);
                db.AddInParameter(dbCommand, "riv_flag_ospite", DbType.Int32, riv_flag_ospite);
                db.AddInParameter(dbCommand, "riv_totale_viaggio", DbType.Decimal, riv_totale_viaggio);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);
                db.AddInParameter(dbCommand, "riv_aux1", DbType.String, riv_aux1);
                db.AddInParameter(dbCommand, "riv_aux2", DbType.String, riv_aux2);
                db.AddInParameter(dbCommand, "riv_aux3", DbType.String, riv_aux3);
                db.AddInParameter(dbCommand, "riv_aux4", DbType.Int32, riv_aux4);
                db.AddInParameter(dbCommand, "riv_aux5", DbType.Int32, riv_aux5);
                db.AddInParameter(dbCommand, "riv_aux6", DbType.String, riv_aux6);
                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, cdc_id_centro_di_costo);
                db.AddInParameter(dbCommand, "lsa_id_stato_autorizzazione", DbType.Int32, lsa_id_stato_autorizzazione);
                db.AddInParameter(dbCommand, "lsa_id_stato_autorizzazione2", DbType.Int32, lsa_id_stato_autorizzazione2);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
                db.AddInParameter(dbCommand, "riv_cli_ragione_sociale", DbType.String, riv_cli_ragione_sociale);
                db.AddInParameter(dbCommand, "riv_flag_autorizzazione_richiesta", DbType.Int32, riv_flag_autorizzazione_richiesta);
                db.AddInParameter(dbCommand, "riv_flag_autorizzazione_forzata", DbType.Int32, riv_flag_autorizzazione_forzata);
                db.AddInParameter(dbCommand, "riv_flag_invio_notifica", DbType.Int32, riv_flag_invio_notifica);
                db.AddInParameter(dbCommand, "riv_flag_aut_policy", DbType.Int32, riv_flag_aut_policy);
                db.AddInParameter(dbCommand, "riv_aux7", DbType.Int32, riv_aux7);
                db.AddInParameter(dbCommand, "riv_aux8", DbType.Int32, riv_aux8);
                db.AddInParameter(dbCommand, "riv_aux9", DbType.Int32, riv_aux9);
                db.AddInParameter(dbCommand, "riv_aux10", DbType.String, riv_aux10);
                db.AddInParameter(dbCommand, "riv_aux11", DbType.Int32, riv_aux11);
                db.AddInParameter(dbCommand, "riv_aux12", DbType.Int32, riv_aux12);
                db.AddInParameter(dbCommand, "riv_gruppo", DbType.String, riv_gruppo);
                db.AddInParameter(dbCommand, "riv_nro_telefono_viaggiatore", DbType.String, riv_nro_telefono_viaggiatore);
                db.AddInParameter(dbCommand, "riv_email_viaggiatore", DbType.String, riv_email_viaggiatore);
                db.AddInParameter(dbCommand, "lsl_id_societa_cliente", DbType.Int32, lsl_id_societa_cliente);
                db.AddInParameter(dbCommand, "riv_flag_rifatturazione", DbType.Int32, riv_flag_rifatturazione);
                db.AddInParameter(dbCommand, "lsl_id_societa_cliente_rifatturazione", DbType.Int32, lsl_id_societa_cliente_rifatturazione);
                db.AddInParameter(dbCommand, "riv_last_user_funzionalita", DbType.Int32, riv_last_user_funzionalita);
                db.AddInParameter(dbCommand, "riv_motivo_trasferta", DbType.String, riv_motivo_trasferta);
                db.AddInParameter(dbCommand, "riv_societa_cliente_rifatturazione", DbType.String, riv_societa_cliente_rifatturazione);
                db.AddInParameter(dbCommand, "riv_nome_richiesta", DbType.String, riv_nome_richiesta);

                db.ExecuteNonQuery(dbCommand, t);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "RichiestaViaggio.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Elenco delle Richieste Viaggio
        /// </summary>
        /// <returns></returns>
        public DataSet List()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();
            BasePageRichiesta bpr = new BasePageRichiesta();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"SELECT DISTINCT 
                            RICHIESTA_VIAGGIO.riv_id_richiesta,                             
                            RICHIESTA_VIAGGIO.ute_id_utente, 
                            LOWER(RICHIESTA_VIAGGIO.riv_destinazione_primaria) AS riv_destinazione_primaria, 
                            (RIC_COGNOME + ' ' + RIC_NOME) as RICHIEDENTE,
                            (VIA_COGNOME + ' ' + VIA_NOME) as VIAGGIATORE,
                            LOWER(RICHIESTA_VIAGGIO.RIV_TMP_STATO_RICHIESTA) AS LSR_DESCRIZIONE,                            
                            (UTENTE.UTE_COGNOME + ' ' + UTENTE.UTE_NOME) as ASSEGNATA,
                            (UTENTE_1.UTE_COGNOME + ' ' + UTENTE_1.UTE_NOME) as AUTORIZZATORE,                                                        
                            CONVERT(DATETIME,RICHIESTA_VIAGGIO.RIV_DATA_PRIMA_SCADENZA,3) AS DATA_PRIMA_SCADENZA,
                            ISNULL(DATEDIFF(DAY, GETDATE(), CONVERT(DATETIME,RICHIESTA_VIAGGIO.RIV_DATA_PRIMA_SCADENZA,3)), 0) AS DIFF_DATA_PRIMA_SCADENZA,
                            WORKFLOW_STATI_CLIENTE.WSC_FLAG_CHIUSO,
                            CONVERT(DATETIME,RICHIESTA_VIAGGIO.RIV_DATA_RICHIESTA,3) AS RIV_DATA_RICHIESTA,
                            CONVERT(DATETIME,RICHIEDENTE.RIC_DATA_CONSEGNA_TITOLI,103) AS RIC_DATA_CONSEGNA_TITOLI,
                            RICHIESTA_VIAGGIO.RIV_TMP_TEMPO_ATTESA AS HMINUTI,
                            RICHIESTA_VIAGGIO.RIV_TMP_WRF_CODICE AS IOA_WRF_CODICE,                            
                            RICHIESTA_VIAGGIO.riv_id_missione_cliente,RIV_AUTORIZZATORI_BCK,
                            RICHIESTA_VIAGGIO.RIV_CLI_RAGIONE_SOCIALE as CLI_RAGIONE_SOCIALE,
                            CASE WHEN PRENOTAZIONI_AEREE.RIV_ID_RICHIESTA IS NULL THEN 0 ELSE 1 END AS AIRINDICATOR,
                            CASE WHEN PRENOTAZIONI_HOTEL.RIV_ID_RICHIESTA IS NULL THEN 0 ELSE 1 END AS HOTINDICATOR,
                            CASE WHEN PRENOTAZIONI_AUTO.RIV_ID_RICHIESTA IS NULL THEN 0 ELSE 1 END AS CARINDICATOR,
                            CASE WHEN PRENOTAZIONI_TRENO.RIV_ID_RICHIESTA IS NULL THEN 0 ELSE 1 END AS RAIINDICATOR,
                            CASE WHEN PRENOTAZIONI_MARITTIMI.RIV_ID_RICHIESTA IS NULL THEN 0 ELSE 1 END AS OTHINDICATOR,
                            CASE WHEN LOCK.LCK_ID_RECORD IS NULL THEN 0 ELSE 1 END AS LOCKINDICATOR,RICHIESTA_VIAGGIO.CLI_ID_CLIENTE AS CLI_ID_CLIENTE,
                            RICHIESTA_VIAGGIO.RIV_FLAG_WS_STATUS,
                            RICHIESTA_VIAGGIO.LSA_ID_STATO_AUTORIZZAZIONE AS AUTINDICATOR,                            
                            RICHIESTA_VIAGGIO.LSA_ID_STATO_AUTORIZZAZIONE2 AS AUTINDICATOR2,                      
                            RIV_PAGINA_EDITOR,RIV_AUX4,
                            RICHIESTA_VIAGGIO.RIV_FLAG_AUTORIZZAZIONE_RICHIESTA,LSR_ID_STATO_RICHIESTA,RIV_ORDINAMENTO,RIV_DIZ_CODE_STATO,
                            LOOKUP_SOCIETA_CLIENTE.LSL_DESCRIZIONE,
                            RIV_AUX9,
		                    ISNULL((SELECT ('profile-status status-' + CAST(MAX(pra_stato_servizio) AS varchar(1))) FROM PRENOTAZIONI_AEREE WHERE pra_flag_eliminato = 0 AND RICHIESTA_VIAGGIO.riv_id_richiesta = PRENOTAZIONI_AEREE.riv_id_richiesta), 0) AS STATO_AIR,
		                    ISNULL((SELECT ('profile-status status-' + CAST(MAX(prh_stato_servizio) AS varchar(1))) FROM PRENOTAZIONI_HOTEL WHERE prh_flag_eliminato = 0 AND RICHIESTA_VIAGGIO.riv_id_richiesta = PRENOTAZIONI_HOTEL.riv_id_richiesta), 0) AS STATO_HOT,
		                    ISNULL((SELECT ('profile-status status-' + CAST(MAX(prc_stato_servizio) AS varchar(1))) FROM PRENOTAZIONI_AUTO WHERE prc_flag_eliminato = 0 AND RICHIESTA_VIAGGIO.riv_id_richiesta = PRENOTAZIONI_AUTO.riv_id_richiesta), 0) AS STATO_CAR,
		                    ISNULL((SELECT ('profile-status status-' + CAST(MAX(prt_stato_servizio) AS varchar(1))) FROM PRENOTAZIONI_TRENO WHERE prt_flag_eliminato = 0 AND RICHIESTA_VIAGGIO.riv_id_richiesta = PRENOTAZIONI_TRENO.riv_id_richiesta), 0) AS STATO_RAI,
		                    ISNULL((SELECT ('profile-status status-' + CAST(MAX(prm_stato_servizio) AS varchar(1))) FROM PRENOTAZIONI_MARITTIMI WHERE prm_flag_eliminato = 0 AND RICHIESTA_VIAGGIO.riv_id_richiesta = PRENOTAZIONI_MARITTIMI.riv_id_richiesta), 0) AS STATO_OTH,
                            WORKFLOW_CASES.ute_id_utente UTENTE_ULTIMA_NOTA,
                            LEFT(WORKFLOW_CASES.ioa_nota, 50) AS ULTIMA_NOTA,

	                        (
                                ISNULL((SELECT SUM(ISNULL(pra_importo_dovuto,0) - ISNULL(pra_importo_rimborso,0) + ISNULL(pra_importo_penale,0)) FROM PRENOTAZIONI_AEREE WHERE PRENOTAZIONI_AEREE.riv_id_richiesta = RICHIESTA_VIAGGIO.riv_id_richiesta AND pra_flag_eliminato = 0), 0)
                                +
                                ISNULL((SELECT SUM(ISNULL(prc_importo_dovuto,0) - ISNULL(prc_importo_rimborso,0) + ISNULL(prc_importo_penale,0)) FROM PRENOTAZIONI_AUTO WHERE PRENOTAZIONI_AUTO.riv_id_richiesta = RICHIESTA_VIAGGIO.riv_id_richiesta AND prc_flag_eliminato = 0), 0)
                                +
                                ISNULL((SELECT SUM(ISNULL(prt_importo_dovuto,0) - ISNULL(prt_importo_rimborso,0) + ISNULL(prt_importo_penale,0)) FROM PRENOTAZIONI_TRENO WHERE PRENOTAZIONI_TRENO.riv_id_richiesta = RICHIESTA_VIAGGIO.riv_id_richiesta AND prt_flag_eliminato = 0), 0)
                                +
                                ISNULL((SELECT SUM(ISNULL(prh_importo_dovuto,0) - ISNULL(prh_importo_rimborso,0) + ISNULL(prh_importo_penale,0)) FROM PRENOTAZIONI_HOTEL WHERE PRENOTAZIONI_HOTEL.riv_id_richiesta = RICHIESTA_VIAGGIO.riv_id_richiesta AND prh_flag_eliminato = 0), 0)
                                +
                                ISNULL((SELECT SUM(ISNULL(prm_importo_dovuto,0) - ISNULL(prm_importo_rimborso,0) + ISNULL(prm_importo_penale,0)) FROM PRENOTAZIONI_MARITTIMI WHERE PRENOTAZIONI_MARITTIMI.riv_id_richiesta = RICHIESTA_VIAGGIO.riv_id_richiesta AND prm_flag_eliminato = 0), 0)
	                        ) AS IMPORTO_SERVIZI
                            ,RIV_GRUPPO
                            ,CLIENTI.CLI_ACRONIMO
                            ,RICHIESTA_VIAGGIO.riv_nome_richiesta as NOME_RICHIESTA
                            ,ISNULL(UTE_ID_UTENTE_DA_ASSEGNARE,0) AS UTE_ID_UTENTE_DA_ASSEGNARE
                            ,ISNULL(RIV_FLAG_FAVORITE,0) AS RIV_FLAG_FAVORITE

                            FROM RICHIESTA_VIAGGIO WITH (NOLOCK) 
                            INNER JOIN RICHIEDENTE WITH (NOLOCK) ON RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = RICHIEDENTE.RIV_ID_RICHIESTA
                            INNER JOIN VIAGGIATORI WITH (NOLOCK) ON RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = VIAGGIATORI.RIV_ID_RICHIESTA
                            LEFT JOIN UTENTE WITH (NOLOCK) ON RICHIESTA_VIAGGIO.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE 
                            LEFT JOIN UTENTE UTENTE_1 WITH (NOLOCK) ON RICHIESTA_VIAGGIO.UTE_UTE_ID_UTENTE = UTENTE_1.UTE_ID_UTENTE                            
                            LEFT JOIN UTENTE UTE_RIC WITH (NOLOCK) ON RICHIEDENTE.UTE_ID_UTENTE = UTE_RIC.UTE_ID_UTENTE                            
                            INNER JOIN OBJECTOWNER WITH (NOLOCK) ON RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = OBJECTOWNER.ID_OGGETTO 
                            LEFT JOIN PRENOTAZIONI_AEREE WITH (NOLOCK) ON RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = PRENOTAZIONI_AEREE.RIV_ID_RICHIESTA AND PRA_FLAG_ELIMINATO = 0 
                            LEFT JOIN PRENOTAZIONI_HOTEL WITH (NOLOCK) ON RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = PRENOTAZIONI_HOTEL.RIV_ID_RICHIESTA AND PRH_FLAG_ELIMINATO = 0 
                            LEFT JOIN PRENOTAZIONI_AUTO WITH (NOLOCK) ON RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = PRENOTAZIONI_AUTO.RIV_ID_RICHIESTA  AND PRC_FLAG_ELIMINATO = 0
                            LEFT JOIN PRENOTAZIONI_TRENO WITH (NOLOCK) ON RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = PRENOTAZIONI_TRENO.RIV_ID_RICHIESTA  AND PRT_FLAG_ELIMINATO = 0
                            LEFT JOIN PRENOTAZIONI_MARITTIMI WITH (NOLOCK) ON RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = PRENOTAZIONI_MARITTIMI.RIV_ID_RICHIESTA AND PRM_FLAG_ELIMINATO = 0
                			LEFT JOIN LOCK on LCK_ID_RECORD = RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA 
                            LEFT JOIN LOOKUP_SOCIETA_CLIENTE ON RICHIESTA_VIAGGIO.LSL_ID_SOCIETA_CLIENTE = LOOKUP_SOCIETA_CLIENTE.LSL_ID_SOCIETA_CLIENTE
                            INNER JOIN WORKFLOW_STATI_CLIENTE ON RICHIESTA_VIAGGIO.LSR_ID_STATO_RICHIESTA = WORKFLOW_STATI_CLIENTE.WFS_ID_STATO AND RICHIESTA_VIAGGIO.CLI_ID_CLIENTE = WORKFLOW_STATI_CLIENTE.CLI_ID_CLIENTE
                            INNER JOIN CLIENTI ON RICHIESTA_VIAGGIO.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE
                            LEFT JOIN
                            (
	                            SELECT MAX(IOA_ID_ISTANZA) AS ID_ISTANZA, IOA_ID_OGGETTO
	                            FROM WORKFLOW_CASES         
	                            WHERE 
	                            (ioa_nota IS NOT NULL AND LTRIM(RTRIM(IOA_NOTA)) <> '')
	                            AND ioa_data_passaggio IS NOT NULL
	                            GROUP BY IOA_ID_OGGETTO
                            ) TBL_ULTIMA_NOTA ON RICHIESTA_VIAGGIO.riv_id_richiesta = TBL_ULTIMA_NOTA.ioa_id_oggetto
                            LEFT JOIN WORKFLOW_CASES ON TBL_ULTIMA_NOTA.ID_ISTANZA = WORKFLOW_CASES.ioa_id_istanza AND ioa_data_passaggio IS NOT NULL
                            ");

                if (SqlWhereClause != string.Empty)
                {
                    sb.Append(SqlWhereClause);
                }

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                dbCommand.CommandTimeout = 300;
                db.LoadDataSet(dbCommand, ds, "RICHIESTA_VIAGGIO");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "RichiestaViaggio.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        #endregion

        #region Metodi
        
        public static DataSet showHideFields(int p_cli_id_cliente, string pagina)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"    SELECT 
                                CNC_ID_CAMPO_NASCOSTO,
                                CNC_NOME_CAMPO_NASCOSTO,
                                CASE WHEN (CNC_FLAG_VISIBILE = 1) THEN 'True' ELSE 'False' END AS CNC_FLAG_VISIBILE,                                
                                CASE WHEN (CNC_FLAG_REQUIRED = 1) THEN 'True' ELSE 'False' END AS CNC_FLAG_REQUIRED,
                                CASE WHEN (CNC_FLAG_IMPORTANT = 1) THEN 'True' ELSE 'False' END AS CNC_FLAG_IMPORTANT,                                
                                CNC_CHIAVE_LABEL,
                                CNC_TIPO                                
                                FROM CAMPI_NASCOSTI_CLIENTE                                                           
                                WHERE CNC_PAGINA=@pagina AND CLI_ID_CLIENTE ");
                if (p_cli_id_cliente > 0)
                    sb.Append("= @cli_id_cliente");
                else
                    sb.Append("IS NULL");

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);
                db.AddInParameter(dbCommand, "pagina", DbType.String, pagina);                
                db.LoadDataSet(dbCommand, ds, "CAMPI_NASCOSTI_CLIENTE");                
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "RichiestaViaggio.showHideFields");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }        
        
        public void getValueForAppViaMail(SqlString p_codiceUnivoco)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT WORKFLOW_AZIONI_CASES.UTE_ID_UTENTE,RIV_TMP_WRF_CODICE,RIV_ID_RICHIESTA,LSR_ID_STATO_RICHIESTA,RICHIESTA_VIAGGIO.CLI_ID_CLIENTE,
                                CASE WHEN RIV_FLAG_AUTORIZZAZIONE_FORZATA = 0 THEN RIV_FLAG_AUTORIZZAZIONE_RICHIESTA ELSE RIV_FLAG_AUTORIZZAZIONE_FORZATA END, RIV_FLAG_WS_STATUS
                                FROM WORKFLOW_AZIONI_CASES
                                INNER JOIN RICHIESTA_VIAGGIO ON WORKFLOW_AZIONI_CASES.IOA_ID_OGGETTO = RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA
					            WHERE CAST(WFW_CODICE_UNIVOCO_MAIL AS NVARCHAR(100)) = @codiceUnivoco AND WFW_FLAG_MAIL_CLICK <> 1 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "codiceUnivoco", DbType.String, p_codiceUnivoco);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    ute_id_utente = reader.GetSqlInt32(0);
                    riv_tmp_wrf_codice = reader.GetSqlString(1);                    
                    riv_id_richiesta = reader.GetSqlInt32(2);
                    lsr_id_stato_richiesta = reader.GetSqlInt32(3);
                    cli_id_cliente = reader.GetSqlInt32(4);
                    riv_flag_autorizzazione_richiesta = reader.GetSqlInt32(5);
                    riv_flag_ws_status = reader.GetSqlInt32(6);
                }

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "RichiestaViaggio.getValueForAppViaMail.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }

        public void updateMailClick(SqlString p_codiceUnivoco, int p_value)
        {            
            string sqlCommand = null;
            DbCommand dbCommand = null;
           
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE WORKFLOW_AZIONI_CASES SET WFW_FLAG_MAIL_CLICK = @value
					        WHERE WFW_CODICE_UNIVOCO_MAIL = @codiceUnivoco ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "codiceUnivoco", DbType.String, p_codiceUnivoco);
                db.AddInParameter(dbCommand, "value", DbType.Int32, p_value);               
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "RichiestaViaggio.updateMailClick.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }            
        }
        
        #endregion
    }
}


