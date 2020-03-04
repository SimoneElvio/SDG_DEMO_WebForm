#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Utente.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per UTENTE
//
// Autore:      AR - SDG srl
// Data:        27/06/2008
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Collections.Generic;
using SDG.ExceptionHandling;

namespace SDG.GestioneUtenti
{
    /// <summary>
    /// Tabella UTENTE 
    /// </summary>
    public class Utente
    {
        #region attributi e variabili

        private SqlInt32 ute_id_utente = SqlInt32.Null;
        private SqlString ute_nome = SqlString.Null;
        private SqlString ute_cognome = SqlString.Null;
        private SqlString ute_alias = SqlString.Null;
        private SqlString ute_sigla = SqlString.Null;
        private SqlString ute_descrizione = SqlString.Null;
        private SqlString ute_user_id = SqlString.Null;
        private SqlString ute_password = SqlString.Null;
        private SqlString ute_telefono = SqlString.Null;
        private SqlString ute_fax = SqlString.Null;
        private SqlString ute_email = SqlString.Null;
        private SqlBoolean ute_stato_utente = SqlBoolean.Null;
        private SqlString ute_tipo_utente = SqlString.Null;
        private SqlDateTime ute_expiration_date = SqlDateTime.Null;
        private SqlInt32 ute_session_id = SqlInt32.Null;
        private SqlDateTime ute_ultimo_accesso = SqlDateTime.Null;
	    private SqlBoolean ute_consenso_privacy = SqlBoolean.Null;
	    private SqlDateTime ute_data_creazione = SqlDateTime.Null;
	    private SqlDateTime ute_data_aggiornamento = SqlDateTime.Null;
	    private SqlInt32 ute_creato_da = SqlInt32.Null;
	    private SqlInt32 ute_aggiornato_da = SqlInt32.Null;
        private SqlInt32 ute_accessi_errati = SqlInt32.Null;
        private SqlInt32 ute_id_utente_autorizzatore = SqlInt32.Null;
        private SqlInt32 aui_flag_autorizzatore_princ = SqlInt32.Null;
        private SqlInt32 aui_livello_autorizzazione = SqlInt32.Null;
        private SqlInt32 ute_id_utente_autorizzato = SqlInt32.Null;
        private SqlString ute_matricola = SqlString.Null;
        private SqlInt32 cdc_id_centro_di_costo = SqlInt32.Null;
        private SqlString tpi_acronimo = SqlString.Null;
        private SqlInt32 cli_id_cliente = SqlInt32.Null;
        private SqlBoolean ute_flag_autorizzazione_automatica = SqlBoolean.Null;
        private SqlString viaggiatore = SqlString.Null;
        private SqlInt32 ute_id_utente_autorizzatore_2 = SqlInt32.Null;
        private SqlString ute_autorizzatore_2 = SqlString.Null;
        private SqlString ute_autorizzatore = SqlString.Null;
        private SqlString codice_workflow = SqlString.Null;
        private SqlInt32 wrf_id_workflow = SqlInt32.Null;        
        private SqlString coalesceUtente = SqlString.Null;
        private SqlString mac_codice_univoco = SqlString.Null;
        private SqlInt32 riv_id_richiesta = SqlInt32.Null;
        private SqlString ioa_wrf_codice = SqlString.Null;
        private SqlInt32 cli_versione_reporting = SqlInt32.Null;
        private SqlString cli_dominio_mail = SqlString.Null;
        private SqlString cli_acronimo = SqlString.Null;
        private SqlInt32 aui_id_autorizzazione = SqlInt32.Null;
        private SqlInt32 ute_flag_pwd_inviata = SqlInt32.Null;
        private SqlInt32 ute_flag_uscita_forzata = SqlInt32.Null;
        private SqlInt32 ute_nro_max_sessioni = SqlInt32.Null;
        private SqlDateTime ute_data_invio_pwd = SqlDateTime.Null;        
        private SqlString cdc_codice_centro_di_costo = SqlString.Null;
        private SqlInt32 aui_flag_notifica = SqlInt32.Null;
        private SqlInt32 ute_gestione_gruppo = SqlInt32.Null;
        private SqlDateTime data_cessazione = SqlDateTime.Null;
        private SqlInt32 coddip = SqlInt32.Null;
        private SqlString strReturn = SqlString.Null;
        private SqlInt32 lsl_id_societa_cliente = SqlInt32.Null;
        private SqlDateTime ute_data_nascita = SqlDateTime.Null;
        private SqlString ute_sesso = SqlString.Null;
        private SqlInt32 try_id_travel_policy_selezionata = SqlInt32.Null;
        private SqlInt32 ute_processo_autorizzativo_liv_1 = SqlInt32.Null;
        private SqlInt32 ute_processo_autorizzativo_liv_2 = SqlInt32.Null;

        //Propriet‡ per evento
        private SqlString riv_user_id_evento = SqlString.Null;
        private SqlString riv_password_evento = SqlString.Null;
        private SqlInt32 ute_flag_bypass_import = SqlInt32.Null;

        private string sqlWhereClause = "";
        private DataSet utenteListDS;
        #endregion

        #region costanti
        public const string maschio = "M";
        public const string femmina = "F";
        #endregion 

        #region Proprieta


        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Ute_id_utente
        {
            get { return ute_id_utente; }
            set { ute_id_utente = value; }
        }

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Ute_id_utente_autorizzatore
        {
            get { return ute_id_utente_autorizzatore; }
            set { ute_id_utente_autorizzatore = value; }
        }

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Aui_id_autorizzazione
        {
            get { return aui_id_autorizzazione; }
            set { aui_id_autorizzazione = value; }
        }

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Aui_flag_notifica
        {
            get { return aui_flag_notifica; }
            set { aui_flag_notifica = value; }
        }

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Ute_flag_pwd_inviata
        {
            get { return ute_flag_pwd_inviata; }
            set { ute_flag_pwd_inviata = value; }
        }

        /// <value>
        /// Identificatore del workflow
        /// </value>
        public SqlInt32 Wrf_id_workflow
        {
            get { return wrf_id_workflow; }
            set { wrf_id_workflow = value; }
        }

        /// <value>
        /// Flag uscita forzata dal TAF
        /// </value>
        public SqlInt32 Ute_flag_uscita_forzata
        {
            get { return ute_flag_uscita_forzata; }
            set { ute_flag_uscita_forzata = value; }
        }

        /// <value>
        /// Identificatore della richiesta viaggio
        /// </value>
        public SqlInt32 Riv_id_richiesta
        {
            get { return riv_id_richiesta; }
            set { riv_id_richiesta = value; }
        }

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Ute_id_utente_autorizzatore_2
        {
            get { return ute_id_utente_autorizzatore_2; }
            set { ute_id_utente_autorizzatore_2 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ute_autorizzatore_2
        {
            get { return ute_autorizzatore_2; }
            set { ute_autorizzatore_2 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ioa_wrf_codice
        {
            get { return ioa_wrf_codice; }
            set { ioa_wrf_codice = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ute_autorizzatore
        {
            get { return ute_autorizzatore; }
            set { ute_autorizzatore= value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Codice_workflow
        {
            get { return codice_workflow; }
            set { codice_workflow = value; }
        }

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Ute_id_utente_autorizzato
        {
            get { return ute_id_utente_autorizzato; }
            set { ute_id_utente_autorizzato = value; }
        }

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlBoolean Ute_flag_autorizzazione_automatica
        {
            get { return ute_flag_autorizzazione_automatica; }
            set { ute_flag_autorizzazione_automatica = value; }
        }

        /// <value>
        /// Nro massimo delle sessioni aperte per l'utente.
        /// </value>
        public SqlInt32 Ute_nro_max_sessioni
        {
            get { return ute_nro_max_sessioni; }
            set { ute_nro_max_sessioni = value; }
        }

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Aui_flag_autorizzatore_princ
        {
            get { return aui_flag_autorizzatore_princ; }
            set { aui_flag_autorizzatore_princ = value; }
        }

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Aui_livello_autorizzazione
        {
            get { return aui_livello_autorizzazione; }
            set { aui_livello_autorizzazione = value; }
        }


        /// <value>
        /// 
        /// </value>
        public SqlString Ute_nome
        {
            get { return ute_nome; }
            set { ute_nome = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString CoalesceUtente
        {
            get { return coalesceUtente; }
            set { coalesceUtente = value; }
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
        public SqlString Tpi_acronimo
        {
            get { return tpi_acronimo; }
            set { tpi_acronimo = value; }
        }
        
        /// <value>
        /// 
        /// </value>
        public SqlString Ute_cognome
        {
            get { return ute_cognome; }
            set { ute_cognome = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ute_matricola
        {
            get { return ute_matricola; }
            set { ute_matricola = value; }
        }
       
        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Cdc_id_centro_di_costo
        {
            get { return cdc_id_centro_di_costo; }
            set { cdc_id_centro_di_costo = value; }
        }

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Cli_id_cliente
        {
            get { return cli_id_cliente; }
            set { cli_id_cliente = value; }
        }

        /// <value>
        /// Flag che indica la gestione del gruppo nell'utente (ZARA)
        /// </value>
        public SqlInt32 Ute_gestione_gruppo
        {
            get { return ute_gestione_gruppo; }
            set { ute_gestione_gruppo = value; }
        }

        /// <value>
        /// Vecchio codice utente
        /// </value>
        public SqlString Ute_alias
        {
            get { return ute_alias; }
            set { ute_alias = value; }
        }

        /// <value>
        /// Abbreviativo che identifica in modo univoco un utente e che non puÚ essere modificata una volta inserita nel sistema. 
        /// </value>
        public SqlString Ute_sigla
        {
            get { return ute_sigla; }
            set { ute_sigla = value; }
        }

        /// <value>
        /// Descrizione dell'Utente utilizzata per la composizione dei Contratti.
        /// </value>
        public SqlString Ute_descrizione
        {
            get { return ute_descrizione; }
            set { ute_descrizione = value; }
        }

        /// <value>
        /// Nome con cui l'utente accede al sistema.
        /// </value>
        public SqlString Ute_user_id
        {
            get { return ute_user_id; }
            set { ute_user_id = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ute_password
        {
            get { return ute_password; }
            set { ute_password = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ute_telefono
        {
            get { return ute_telefono; }
            set { ute_telefono = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ute_fax
        {
            get { return ute_fax; }
            set { ute_fax = value; }
        }

        /// <value>
        /// Indirizzo Email.
        /// </value>
        public SqlString Ute_email
        {
            get { return ute_email; }
            set { ute_email = value; }
        }

        /// <value>
        /// Stato dell'utente. (abilitato, non abilitato...)
        /// </value>
        public SqlBoolean Ute_stato_utente
        {
            get { return ute_stato_utente; }
            set { ute_stato_utente = value; }
        }

        /// <value>
        /// Flag utile a bypassare la riconfigurazione degli autorizzatori in fase di import (novartis)
        /// </value>
        public SqlInt32 Ute_flag_bypass_import
        {
            get { return ute_flag_bypass_import; }
            set { ute_flag_bypass_import = value; }
        }


        /// <value>
        /// Indica la tipologia del''utente, Banker, ....
        /// </value>
        public SqlString Ute_tipo_utente
        {
            get { return ute_tipo_utente; }
            set { ute_tipo_utente = value; }
        }

        /// <value>
        /// Data di scadenza dell'abilitazione dell'utente.
        /// </value>
        public SqlDateTime Ute_expiration_date
        {
            get { return ute_expiration_date; }
            set { ute_expiration_date = value; }
        }

        /// <value>
        /// Data di scadenza dell'abilitazione dell'utente.
        /// </value>
        public SqlDateTime Ute_data_invio_pwd
        {
            get { return ute_data_invio_pwd; }
            set { ute_data_invio_pwd = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Ute_session_id
        {
            get { return ute_session_id; }
            set { ute_session_id = value; }
        }

		/// <value>
		/// 
        /// </value>
        public SqlDateTime Ute_ultimo_accesso
        {
            get { return ute_ultimo_accesso; }
            set { ute_ultimo_accesso = value; }
        }

		/// <value>
		/// 
		/// </value>
		public  SqlBoolean Ute_consenso_privacy
		{
			get { return  ute_consenso_privacy; }
			set { ute_consenso_privacy = value; }
		}

		/// <value>
        /// Data di Inserimento del Record.
		/// </value>
		public  SqlDateTime Ute_data_creazione
		{
			get { return  ute_data_creazione; }
			set { ute_data_creazione = value; }
		}

		/// <value>
        /// Data di Aggiornamento del Record.
		/// </value>
		public  SqlDateTime Ute_data_aggiornamento
		{
			get { return  ute_data_aggiornamento; }
			set { ute_data_aggiornamento = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Ute_creato_da
		{
			get { return  ute_creato_da; }
			set { ute_creato_da = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Ute_aggiornato_da
		{
			get { return  ute_aggiornato_da; }
			set { ute_aggiornato_da = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Ute_accessi_errati
        {
            get { return ute_accessi_errati; }
            set { ute_accessi_errati = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cli_versione_reporting
        {
            get { return cli_versione_reporting; }
            set { cli_versione_reporting = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_dominio_mail
        {
            get { return cli_dominio_mail; }
            set { cli_dominio_mail = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_acronimo
        {
            get { return cli_acronimo; }
            set { cli_acronimo = value; }
        }

        /// <value>
        /// Where Clause condition
        /// </value>
        public string SqlWhereClause
        {
            get { return sqlWhereClause; }
            set { sqlWhereClause = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Mac_codice_univoco
        {
            get { return mac_codice_univoco; }
            set { mac_codice_univoco = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_user_id_evento
        {
            get { return riv_user_id_evento; }
            set { riv_user_id_evento = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Riv_password_evento
        {
            get { return riv_password_evento; }
            set { riv_password_evento = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cdc_codice_centro_di_costo
        {
            get { return cdc_codice_centro_di_costo; }
            set { cdc_codice_centro_di_costo = value; }
        }
        /// <value>
        /// Elenco degli elementi Utente selezionati
        /// </value>
        public DataSet UtenteListDS
        {
            get { return utenteListDS; }
            set { utenteListDS = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlDateTime Data_cessazione
        {
            get { return data_cessazione; }
            set { data_cessazione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Coddip
        {
            get { return coddip; }
            set { coddip = value; }
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
        public SqlDateTime Ute_data_nascita
        {
            get { return ute_data_nascita; }
            set { ute_data_nascita = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ute_sesso
        {
            get { return ute_sesso; }
            set { ute_sesso = value; }
        }

        public SqlString StrReturn
        {
            get { return strReturn; }
            set { strReturn = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Try_id_travel_policy_selezionata
        {
            get { return try_id_travel_policy_selezionata; }
            set { try_id_travel_policy_selezionata = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Ute_processo_autorizzativo_liv_1
        {
            get { return ute_processo_autorizzativo_liv_1; }
            set { ute_processo_autorizzativo_liv_1 = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Ute_processo_autorizzativo_liv_2
        {
            get { return ute_processo_autorizzativo_liv_2; }
            set { ute_processo_autorizzativo_liv_2 = value; }
        }

        

        #endregion

        #region  Costruttori

        /// <summary>
        /// Costruttore standard
        /// </summary>
        public Utente()
        {
            utenteListDS = new DataSet();
        }
        #endregion

        #region Metodi

        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void Read()
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 UTENTE.UTE_ID_UTENTE, 
					 UTENTE.ute_nome, 
					 UTENTE.ute_cognome, 
					 UTENTE.ute_alias, 
					 UTENTE.ute_sigla, 
					 UTENTE.ute_descrizione, 
					 UTENTE.ute_user_id, 
					 UTENTE.UTE_PASSWORD, 
					 UTENTE.ute_telefono, 
					 UTENTE.ute_fax, 
					 UTENTE.ute_email, 
					 UTENTE.ute_stato_utente, 
					 UTENTE.ute_tipo_utente, 
					 UTENTE.ute_expiration_date, 
					 UTENTE.ute_session_id, 
					 UTENTE.ute_ultimo_accesso, 
					 UTENTE.ute_consenso_privacy, 
					 UTENTE.ute_data_creazione, 
					 UTENTE.ute_data_aggiornamento, 
					 UTENTE.ute_creato_da, 
					 UTENTE.ute_aggiornato_da, 
					 UTENTE.ute_accessi_errati,                     
                     UTENTE.ute_matricola,
                     UTENTE.cdc_id_centro_di_costo,
                     UTENTE.cli_id_cliente,
                     UTENTE.ute_flag_autorizzazione_automatica,
                     UTENTE.wrf_id_workflow,
                     COALESCE(UTENTE.ute_cognome + ' ' + UTENTE.ute_nome,UTENTE.ute_cognome) as UTENTE,
                     CLIENTI.cli_versione_reporting,CLIENTI.cli_dominio_mail,ute_flag_pwd_inviata,ute_data_invio_pwd,
                     ute_flag_uscita_forzata,
                     ute_flag_bypass_import,
                     UTENTE.lsl_id_societa_cliente,
                     UTENTE.ute_data_nascita,
                     UTENTE.ute_sesso,
                     UTENTE.try_id_travel_policy_selezionata
				 	 FROM UTENTE LEFT JOIN CLIENTI ON UTENTE.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE
                     WHERE 
					 (UTE_ID_UTENTE =@ute_id_utente) 
					 ";
                
                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    int i = 0;

                    ute_id_utente = reader.GetSqlInt32(i++);
					ute_nome = reader.GetSqlString(i++);
					ute_cognome = reader.GetSqlString(i++);
					ute_alias = reader.GetSqlString(i++);
					ute_sigla = reader.GetSqlString(i++);
					ute_descrizione = reader.GetSqlString(i++);
					ute_user_id = reader.GetSqlString(i++);
					ute_password = reader.GetSqlString(i++);
					ute_telefono = reader.GetSqlString(i++);
					ute_fax = reader.GetSqlString(i++);
					ute_email = reader.GetSqlString(i++);
					ute_stato_utente = reader.GetSqlBoolean(i++);
					ute_tipo_utente = reader.GetSqlString(i++);
					ute_expiration_date = reader.GetSqlDateTime(i++);
					ute_session_id = reader.GetSqlInt32(i++);
					ute_ultimo_accesso = reader.GetSqlDateTime(i++);
					ute_consenso_privacy = reader.GetSqlBoolean(i++);
					ute_data_creazione = reader.GetSqlDateTime(i++);
					ute_data_aggiornamento = reader.GetSqlDateTime(i++);
					ute_creato_da = reader.GetSqlInt32(i++);
					ute_aggiornato_da = reader.GetSqlInt32(i++);
					ute_accessi_errati = reader.GetSqlInt32(i++);                    
                    ute_matricola = reader.GetSqlString(i++);
                    cdc_id_centro_di_costo = reader.GetSqlInt32(i++);
                    cli_id_cliente = reader.GetSqlInt32(i++);
                    ute_flag_autorizzazione_automatica = reader.GetSqlBoolean(i++);
                    wrf_id_workflow = reader.GetSqlInt32(i++);
                    coalesceUtente = reader.GetSqlString(i++);
                    cli_versione_reporting = reader.GetSqlInt32(i++);
                    cli_dominio_mail = reader.GetSqlString(i++);
                    ute_flag_pwd_inviata = reader.GetSqlInt32(i++);
                    ute_data_invio_pwd = reader.GetSqlDateTime(i++);                    
                    ute_flag_uscita_forzata = reader.GetSqlInt32(i++);
                    ute_flag_bypass_import = reader.GetSqlInt32(i++);
                    lsl_id_societa_cliente = reader.GetSqlInt32(i++);
                    ute_data_nascita= reader.GetSqlDateTime(i++);
                    ute_sesso = reader.GetSqlString(i++);
                    try_id_travel_policy_selezionata = reader.GetSqlInt32(i++);
                }	
			}
			catch(Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.Read.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            finally
            {
				if(reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }

        public void Read(string p_whereclause)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 UTENTE.UTE_ID_UTENTE, 
					 UTENTE.ute_nome, 
					 UTENTE.ute_cognome, 
					 UTENTE.ute_alias, 
					 UTENTE.ute_sigla, 
					 UTENTE.ute_descrizione, 
					 UTENTE.ute_user_id, 
					 UTENTE.UTE_PASSWORD, 
					 UTENTE.ute_telefono, 
					 UTENTE.ute_fax, 
					 UTENTE.ute_email, 
					 UTENTE.ute_stato_utente, 
					 UTENTE.ute_tipo_utente, 
					 UTENTE.ute_expiration_date, 
					 UTENTE.ute_session_id, 
					 UTENTE.ute_ultimo_accesso, 
					 UTENTE.ute_consenso_privacy, 
					 UTENTE.ute_data_creazione, 
					 UTENTE.ute_data_aggiornamento, 
					 UTENTE.ute_creato_da, 
					 UTENTE.ute_aggiornato_da, 
					 UTENTE.ute_accessi_errati,                     
                     UTENTE.ute_matricola,
                     UTENTE.cdc_id_centro_di_costo,
                     UTENTE.cli_id_cliente,
                     UTENTE.ute_flag_autorizzazione_automatica,
                     UTENTE.wrf_id_workflow,
                     COALESCE(UTENTE.ute_cognome + ' ' + UTENTE.ute_nome,UTENTE.ute_cognome) as UTENTE,
                     CLIENTI.cli_versione_reporting,CLIENTI.cli_dominio_mail,ute_flag_pwd_inviata,ute_data_invio_pwd,
                     ute_flag_uscita_forzata,
                     ute_flag_bypass_import,
                     UTE_GESTIONE_GRUPPO,
                     UTENTE.ute_data_nascita,
                     UTENTE.ute_sesso,
                     UTENTE.try_id_travel_policy_selezionata
				 	 FROM UTENTE LEFT JOIN CLIENTI ON UTENTE.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE                     
					 " + p_whereclause;


                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    ute_id_utente = reader.GetSqlInt32(0);
                    ute_nome = reader.GetSqlString(1);
                    ute_cognome = reader.GetSqlString(2);
                    ute_alias = reader.GetSqlString(3);
                    ute_sigla = reader.GetSqlString(4);
                    ute_descrizione = reader.GetSqlString(5);
                    ute_user_id = reader.GetSqlString(6);
                    ute_password = reader.GetSqlString(7);
                    ute_telefono = reader.GetSqlString(8);
                    ute_fax = reader.GetSqlString(9);
                    ute_email = reader.GetSqlString(10);
                    ute_stato_utente = reader.GetSqlBoolean(11);
                    ute_tipo_utente = reader.GetSqlString(12);
                    ute_expiration_date = reader.GetSqlDateTime(13);
                    ute_session_id = reader.GetSqlInt32(14);
                    ute_ultimo_accesso = reader.GetSqlDateTime(15);
                    ute_consenso_privacy = reader.GetSqlBoolean(16);
                    ute_data_creazione = reader.GetSqlDateTime(17);
                    ute_data_aggiornamento = reader.GetSqlDateTime(18);
                    ute_creato_da = reader.GetSqlInt32(19);
                    ute_aggiornato_da = reader.GetSqlInt32(20);
                    ute_accessi_errati = reader.GetSqlInt32(21);                    
                    ute_matricola = reader.GetSqlString(22);
                    cdc_id_centro_di_costo = reader.GetSqlInt32(23);
                    cli_id_cliente = reader.GetSqlInt32(24);
                    ute_flag_autorizzazione_automatica = reader.GetSqlBoolean(25);
                    wrf_id_workflow = reader.GetSqlInt32(26);
                    coalesceUtente = reader.GetSqlString(27);
                    cli_versione_reporting = reader.GetSqlInt32(28);
                    cli_dominio_mail = reader.GetSqlString(29);
                    ute_flag_pwd_inviata = reader.GetSqlInt32(30);
                    ute_data_invio_pwd = reader.GetSqlDateTime(31);                    
                    ute_flag_uscita_forzata = reader.GetSqlInt32(32);
                    ute_flag_bypass_import = reader.GetSqlInt32(33);
                    ute_gestione_gruppo = reader.GetSqlInt32(34);
                    ute_data_nascita = reader.GetSqlDateTime(35);
                    ute_sesso = reader.GetSqlString(36);
                    try_id_travel_policy_selezionata= reader.GetSqlInt32(37);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.Read.");
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

        public void ReadperViaggiatore(SqlInt32 p_ute_id_utente)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 UTENTE.UTE_ID_UTENTE, 
					 COALESCE(UTENTE.ute_cognome + ' ' + UTENTE.ute_nome,UTENTE.ute_cognome) AS VIAGGIATORE
				 	 FROM UTENTE WHERE 
					 (UTE_ID_UTENTE =@p_ute_id_utente) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "p_ute_id_utente", DbType.Int32, p_ute_id_utente);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    ute_id_utente = reader.GetSqlInt32(0);
                    viaggiatore = reader.GetSqlString(1);                                      
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.Read.");
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
        /// 
        /// </summary>
        public void ReadProcessoAutorizzativo()
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					             UTENTE.ute_processo_autorizzativo_liv_1, 
					             UTENTE.ute_processo_autorizzativo_liv_2,
                                 UTENTE.ute_cognome,
                                 UTENTE.ute_nome
				 	             FROM UTENTE
                                 WHERE 
					             UTE_ID_UTENTE =@ute_id_utente ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    int i = 0;
                    ute_processo_autorizzativo_liv_1 = reader.GetSqlInt32(i++);
                    ute_processo_autorizzativo_liv_2 = reader.GetSqlInt32(i++);
                    ute_cognome = reader.GetSqlString(i++);
                    ute_nome = reader.GetSqlString(i++);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ReadProcessoAutorizzativo.");
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
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void Update()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE UTENTE SET 
					 ute_nome = dbo.fnProperCase(@ute_nome), 
					 ute_cognome = dbo.fnProperCase(@ute_cognome), 
					 ute_alias = @ute_alias, 
					 ute_sigla = @ute_sigla, 
					 ute_descrizione = @ute_descrizione, 
					 ute_user_id = @ute_user_id, 
					 ute_password = @ute_password, 
					 ute_telefono = @ute_telefono, 
					 ute_fax = @ute_fax, 
					 ute_email = @ute_email, 
					 ute_stato_utente = @ute_stato_utente, 
					 ute_tipo_utente = @ute_tipo_utente, 
					 ute_expiration_date = @ute_expiration_date, 
					 ute_session_id = @ute_session_id, 
					 ute_ultimo_accesso = @ute_ultimo_accesso, 
					 ute_consenso_privacy = @ute_consenso_privacy, 
					 ute_data_creazione = @ute_data_creazione, 
					 ute_data_aggiornamento = getdate(), 
					 ute_creato_da = @ute_creato_da, 
					 ute_aggiornato_da = @ute_aggiornato_da, 
					 ute_accessi_errati = @ute_accessi_errati,                     
                     ute_matricola = @ute_matricola,
                     cdc_id_centro_di_costo = @cdc_id_centro_di_costo,
                     cli_id_cliente = @cli_id_cliente,
                     ute_flag_pwd_inviata = @ute_flag_pwd_inviata,
                     ute_data_invio_pwd = @ute_data_invio_pwd, 
                     wrf_id_workflow = @wrf_id_workflow,
                     ute_flag_autorizzazione_automatica = @ute_flag_autorizzazione_automatica,                     
                     ute_flag_uscita_forzata =  @ute_flag_uscita_forzata,
                     ute_flag_bypass_import =  @ute_flag_bypass_import,
                     lsl_id_societa_cliente = @lsl_id_societa_cliente,
                     ute_data_nascita= @ute_data_nascita,
                     ute_sesso = @ute_sesso,
                     try_id_travel_policy_selezionata=@try_id_travel_policy_selezionata
					 WHERE
				     UTE_ID_UTENTE =@ute_id_utente "; 										
                
                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_nome", DbType.String, ute_nome);
                db.AddInParameter(dbCommand, "ute_cognome", DbType.String, ute_cognome);
                db.AddInParameter(dbCommand, "ute_alias", DbType.String, ute_alias);
                db.AddInParameter(dbCommand, "ute_sigla", DbType.String, ute_sigla);
                db.AddInParameter(dbCommand, "ute_descrizione", DbType.String, ute_descrizione);
                db.AddInParameter(dbCommand, "ute_user_id", DbType.String, ute_user_id);
                db.AddInParameter(dbCommand, "ute_password", DbType.String, ute_password);
                db.AddInParameter(dbCommand, "ute_telefono", DbType.String, ute_telefono);
                db.AddInParameter(dbCommand, "ute_fax", DbType.String, ute_fax);
                db.AddInParameter(dbCommand, "ute_email", DbType.String, ute_email);
                db.AddInParameter(dbCommand, "ute_stato_utente", DbType.Boolean, ute_stato_utente);
                db.AddInParameter(dbCommand, "ute_tipo_utente", DbType.String, ute_tipo_utente);
                db.AddInParameter(dbCommand, "ute_expiration_date", DbType.DateTime, ute_expiration_date);
                db.AddInParameter(dbCommand, "ute_session_id", DbType.Int32, ute_session_id);
                db.AddInParameter(dbCommand, "ute_ultimo_accesso", DbType.DateTime, ute_ultimo_accesso);
				db.AddInParameter(dbCommand, "ute_consenso_privacy", DbType.Boolean, ute_consenso_privacy);
				db.AddInParameter(dbCommand, "ute_data_creazione", DbType.DateTime, ute_data_creazione);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);
				db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
                db.AddInParameter(dbCommand, "ute_accessi_errati", DbType.Int32, ute_accessi_errati);                
                db.AddInParameter(dbCommand, "ute_matricola", DbType.String, ute_matricola);
                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, cdc_id_centro_di_costo);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
                db.AddInParameter(dbCommand, "wrf_id_workflow", DbType.Int32, wrf_id_workflow);
                db.AddInParameter(dbCommand, "ute_flag_pwd_inviata", DbType.Int32, ute_flag_pwd_inviata);
                db.AddInParameter(dbCommand, "ute_data_invio_pwd", DbType.DateTime, ute_data_invio_pwd);
                db.AddInParameter(dbCommand, "ute_flag_autorizzazione_automatica", DbType.Boolean, ute_flag_autorizzazione_automatica);                
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "ute_flag_uscita_forzata", DbType.Int32, ute_flag_uscita_forzata);
                db.AddInParameter(dbCommand, "ute_flag_bypass_import", DbType.Int32, ute_flag_bypass_import);
                db.AddInParameter(dbCommand, "lsl_id_societa_cliente", DbType.Int32, lsl_id_societa_cliente);
                db.AddInParameter(dbCommand, "ute_data_nascita", DbType.DateTime, ute_data_nascita);
                db.AddInParameter(dbCommand, "ute_sesso", DbType.String, ute_sesso);
                db.AddInParameter(dbCommand, "try_id_travel_policy_selezionata", DbType.Int32, try_id_travel_policy_selezionata); 

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateProcessoAutorizzativo()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE UTENTE SET 
					             ute_processo_autorizzativo_liv_1 = @ute_processo_autorizzativo_liv_1,
					             ute_processo_autorizzativo_liv_2 = @ute_processo_autorizzativo_liv_2,
					             ute_data_aggiornamento = getdate(),
					             ute_aggiornato_da = @ute_aggiornato_da
					             WHERE UTE_ID_UTENTE = @ute_id_utente ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_processo_autorizzativo_liv_1", DbType.Int32, ute_processo_autorizzativo_liv_1);
                db.AddInParameter(dbCommand, "ute_processo_autorizzativo_liv_2", DbType.Int32, ute_processo_autorizzativo_liv_2);
                db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.UpdateProcessoAutorizzativo.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public void Delete()
        {
            string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE UTENTE SET UTE_FLAG_ELIMINATO = 1 WHERE 
					(UTE_ID_UTENTE =@ute_id_utente) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
                    ex.Data.Add("Class.Method", "Utente.Delete.");
                    ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public void DeleteAutorizzatoriIndividuali()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM AUTORIZZATORI_INDIVIDUALI WHERE 
                                AUI_ID_AUTORIZZAZIONE = @aui_id_autorizzazione
					--(UTE_ID_UTENTE =@ute_id_utente AND UTE_ID_UTENTE_AUTORIZZATORE = @ute_id_utente_autorizzatore) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "ute_id_utente_autorizzatore", DbType.Int32, ute_id_utente_autorizzatore);
                db.AddInParameter(dbCommand, "aui_id_autorizzazione", DbType.Int32, aui_id_autorizzazione);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.DeleteAutorizzatoriIndividuali.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        public void DeleteAutorizzatoriIndividuali(int idUtente)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM AUTORIZZATORI_INDIVIDUALI WHERE 
                                UTE_ID_UTENTE = @ute_id_utente ";
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, idUtente);                
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.DeleteAutorizzatoriIndividuali.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public void DeleteAutorizzatiIndividuali()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM AUTORIZZATORI_INDIVIDUALI WHERE 
					(UTE_ID_UTENTE =@ute_id_utente AND UTE_ID_UTENTE_AUTORIZZATORE=@ute_id_utente_autorizzatore) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "ute_id_utente_autorizzatore", DbType.Int32, ute_id_utente_autorizzatore);                

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.DeleteAutorizzatiIndividuali.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void Create(Database db, DbTransaction t)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
				sqlCommand = @" INSERT INTO UTENTE (
						ute_nome, 
						ute_cognome, 
						ute_alias, 
						ute_sigla, 
						ute_descrizione, 
						ute_user_id, 
						UTE_PASSWORD, 
						ute_telefono, 
						ute_fax, 
						ute_email, 
						ute_stato_utente, 
						ute_tipo_utente, 
						ute_expiration_date, 
						ute_session_id, 
						ute_ultimo_accesso, 
						ute_consenso_privacy, 
						ute_data_creazione, 
						ute_data_aggiornamento, 
						ute_creato_da, 
						ute_aggiornato_da, 
						ute_accessi_errati,                        
                        ute_matricola,
                        cdc_id_centro_di_costo,
                        cli_id_cliente,ute_flag_visibile,
                        ute_flag_eliminato,ute_flag_autorizzazione_automatica,wrf_id_workflow,
                        ute_flag_bypass_import,
                        lsl_id_societa_cliente,
                        ute_data_nascita,
                        ute_sesso,
                        try_id_travel_policy_selezionata,
                        ute_processo_autorizzativo_liv_1,
                        ute_processo_autorizzativo_liv_2) 
					VALUES ( 
						@ute_nome, 
						@ute_cognome, 
						@ute_alias, 
						@ute_sigla, 
						@ute_descrizione, 
						@ute_user_id, 
						@ute_password, 
						@ute_telefono, 
						@ute_fax, 
						@ute_email, 
						@ute_stato_utente, 
						@ute_tipo_utente, 
						@ute_expiration_date, 
						@ute_session_id, 
						@ute_ultimo_accesso, 
						@ute_consenso_privacy, 
						getdate(), 
						@ute_data_aggiornamento, 
						@ute_creato_da, 
						@ute_aggiornato_da, 
						@ute_accessi_errati,                        
                        @ute_matricola,
                        @cdc_id_centro_di_costo,
                        @cli_id_cliente,1,0,@ute_flag_autorizzazione_automatica,@wrf_id_workflow,
                        @ute_flag_bypass_import,
                        @lsl_id_societa_cliente,
                        @ute_data_nascita,
                        @ute_sesso,
                        @try_id_travel_policy_selezionata,
                        @ute_processo_autorizzativo_liv_1,
                        @ute_processo_autorizzativo_liv_2) 

				; SELECT SCOPE_IDENTITY()";
                
                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_nome", DbType.String, ute_nome);
                db.AddInParameter(dbCommand, "ute_cognome", DbType.String, ute_cognome);
                db.AddInParameter(dbCommand, "ute_alias", DbType.String, ute_alias);
                db.AddInParameter(dbCommand, "ute_sigla", DbType.String, ute_sigla);
                db.AddInParameter(dbCommand, "ute_descrizione", DbType.String, ute_descrizione);
                db.AddInParameter(dbCommand, "ute_user_id", DbType.String, ute_user_id);
                db.AddInParameter(dbCommand, "ute_password", DbType.String, ute_password);
                db.AddInParameter(dbCommand, "ute_telefono", DbType.String, ute_telefono);
                db.AddInParameter(dbCommand, "ute_fax", DbType.String, ute_fax);
                db.AddInParameter(dbCommand, "ute_email", DbType.String, ute_email);
                db.AddInParameter(dbCommand, "ute_stato_utente", DbType.Boolean, ute_stato_utente);
                db.AddInParameter(dbCommand, "ute_tipo_utente", DbType.String, ute_tipo_utente);
                db.AddInParameter(dbCommand, "ute_expiration_date", DbType.DateTime, ute_expiration_date);
                db.AddInParameter(dbCommand, "ute_session_id", DbType.Int32, ute_session_id);
                db.AddInParameter(dbCommand, "ute_ultimo_accesso", DbType.DateTime, ute_ultimo_accesso);
				db.AddInParameter(dbCommand, "ute_consenso_privacy", DbType.Boolean, ute_consenso_privacy);
				db.AddInParameter(dbCommand, "ute_data_aggiornamento", DbType.DateTime, ute_data_aggiornamento);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);
				db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
                db.AddInParameter(dbCommand, "ute_accessi_errati", DbType.Int32, ute_accessi_errati);                
                db.AddInParameter(dbCommand, "ute_matricola", DbType.String, ute_matricola);
                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, cdc_id_centro_di_costo);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
                db.AddInParameter(dbCommand, "wrf_id_workflow", DbType.Int32, wrf_id_workflow);
                db.AddInParameter(dbCommand, "ute_flag_autorizzazione_automatica", DbType.Boolean, ute_flag_autorizzazione_automatica);                
                db.AddInParameter(dbCommand, "ute_flag_bypass_import", DbType.Int32, ute_flag_bypass_import);
                db.AddInParameter(dbCommand, "lsl_id_societa_cliente", DbType.Int32, lsl_id_societa_cliente);
                db.AddInParameter(dbCommand, "ute_data_nascita", DbType.DateTime, ute_data_nascita);
                db.AddInParameter(dbCommand, "ute_sesso", DbType.String, ute_sesso);
                db.AddInParameter(dbCommand, "try_id_travel_policy_selezionata", DbType.Int32, try_id_travel_policy_selezionata);
                db.AddInParameter(dbCommand, "ute_processo_autorizzativo_liv_1", DbType.Int32, ute_processo_autorizzativo_liv_1);
                db.AddInParameter(dbCommand, "ute_processo_autorizzativo_liv_2", DbType.Int32, ute_processo_autorizzativo_liv_2);

                dataReader = db.ExecuteReader(dbCommand, t);
                if (dataReader.Read())
                {
                    ute_id_utente = Convert.ToInt32(dataReader[0]);
                }
 				dataReader.Close();
                
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.Create.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
			finally
			{
				if(dataReader != null)
					((IDisposable)dataReader).Dispose();
			}
		}
		
		public DataSet List()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            StringBuilder sb2 = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT DISTINCT
					UTENTE.ute_id_utente, 
					LOWER(UTENTE.ute_nome) AS UTE_NOME, 
					LOWER(UTENTE.ute_cognome) AS UTE_COGNOME,                    
					LOWER(UTENTE.ute_user_id) AS UTE_USER_ID, 
					LOWER(UTENTE.ute_email) AS UTE_EMAIL, 
					UTENTE.ute_stato_utente, 
					UTENTE.cdc_id_centro_di_costo,
                    UTENTE.cli_id_cliente,
					UTENTE.ute_ultimo_accesso,
                    CENTRI_DI_COSTO.cdc_codice_centro_di_costo,
                    CENTRI_DI_COSTO.cdc_descrizione,
                    CLIENTI.CLI_RAGIONE_SOCIALE,
                    (CASE WHEN DATEDIFF(minute, SESSIONI_UTENTI.SSU_DATA_LAST_PING, getdate()) < 2 THEN 1 ELSE 0 END) AS ISONLINE,
                    ute_flag_pwd_inviata,ute_data_invio_pwd,
                    ute_data_nascita,
                    ute_sesso,
                    try_id_travel_policy_selezionata                     
				    FROM UTENTE 
                    LEFT JOIN CENTRI_DI_COSTO ON UTENTE.CDC_ID_CENTRO_DI_COSTO = CENTRI_DI_COSTO.CDC_ID_CENTRO_DI_COSTO
                    LEFT JOIN CLIENTI ON UTENTE.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE
                    LEFT JOIN SESSIONI_UTENTI ON UTENTE.UTE_ID_UTENTE = SESSIONI_UTENTI.UTE_ID_UTENTE
                    WHERE UTE_FLAG_VISIBILE=1 AND UTE_FLAG_ELIMINATO=0 ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sb.Append(" ORDER BY UTE_COGNOME ASC ");
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "UTENTE");


                //CREO UNA COPIA DEL DATATABLE MA SOLO CON UNA COLONNA
                DataTable dt = new DataTable();
                dt.Columns.Add("UTE_ID_UTENTE", typeof(int));                
                dt.TableName = "UTENTE_ID";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataRow drNew = dt.NewRow();
                    drNew["UTE_ID_UTENTE"] = Convert.ToInt32(dr["UTE_ID_UTENTE"]);
                    dt.Rows.Add(drNew);
                }
                ds.Tables.Add(dt);
                //FINE************************************************                     

            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public DataSet ListChangeOperator()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            StringBuilder sb2 = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT DISTINCT 
					UTENTE.ute_id_utente, 
					LOWER(UTENTE.ute_nome) AS UTE_NOME, 
					LOWER(UTENTE.ute_cognome) AS UTE_COGNOME,                    
					LOWER(UTENTE.ute_user_id) AS UTE_USER_ID, 
					LOWER(UTENTE.ute_email) AS UTE_EMAIL					
					FROM UTENTE 
                    INNER JOIN RUOLI_UTENTE ON UTENTE.UTE_ID_UTENTE = RUOLI_UTENTE.UTE_ID_UTENTE
                    INNER JOIN PERMESSO_ACCESSO ON RUOLI_UTENTE.RUL_ID_RUOLO = PERMESSO_ACCESSO.RUL_ID_RUOLO
                    INNER JOIN FUNZIONALITA ON PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA = FUNZIONALITA.FNT_ID_FUNZIONALITA 
                    LEFT JOIN CROSS_UTENTE_CLIENTE ON UTENTE.UTE_ID_UTENTE = CROSS_UTENTE_CLIENTE.UTE_ID_UTENTE                                        
                    WHERE UTE_FLAG_ELIMINATO = 0 AND UTE_STATO_UTENTE = 1 ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sb.Append(" ORDER BY UTE_COGNOME ASC ");
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "UTENTE");
                //FINE************************************************                     

            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ListChangeOperator.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public static DataSet ListForExport(SqlString WhereClause)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            StringBuilder sb2 = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					LOWER(UTENTE.ute_cognome) AS COGNOME,                    
					LOWER(UTENTE.ute_nome) AS NOME, 					
					LOWER(UTENTE.ute_user_id) AS [USER ID], 
					LOWER(UTENTE.ute_email) AS EMAIL, 
					CASE WHEN UTENTE.ute_stato_utente = 1 THEN 'SI' ELSE 'NO' END AS ABILITATO, 
					UTENTE.ute_matricola AS MATRICOLA,
                    UTENTE.ute_ultimo_accesso AS [DATA ULTIMO ACCESSO],
                    CENTRI_DI_COSTO.cdc_codice_centro_di_costo AS [CENTRO DI COSTO],
                    CLIENTI.CLI_RAGIONE_SOCIALE AS CLIENTE,
                    CASE WHEN ute_flag_pwd_inviata = 1 THEN 'SI' ELSE 'NO' END AS [PASSWORD INVIATA],
                    ute_data_invio_pwd AS [DATA INVIO PASSWORD]                     
				    FROM UTENTE 
                    LEFT JOIN CENTRI_DI_COSTO ON UTENTE.CDC_ID_CENTRO_DI_COSTO = CENTRI_DI_COSTO.CDC_ID_CENTRO_DI_COSTO
                    LEFT JOIN CLIENTI ON UTENTE.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE
                     ");

                if (WhereClause != string.Empty)
                {                    
                    sb.Append(" WHERE UTE_FLAG_VISIBILE=1 AND UTE_FLAG_ELIMINATO=0");
                    sb.Append(WhereClause);
                }
                else
                {
                    sb.Append(" WHERE UTE_FLAG_VISIBILE=1 AND UTE_FLAG_ELIMINATO=0");
                }

                sb.Append(" ORDER BY UTE_COGNOME ASC ");
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "UTENTE");

                


            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }
     
        /// <summary>
        /// getListDropDown
        /// </summary>
        /// <param name="qCultureInfoName"></param>
        /// <returns>dataSet:UTE_ID_UTENTE,UTE_USER_ID</returns>
        public IDataReader getListDropDown()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder();
            DbCommand dbCommand = null;
            SqlDataReader reader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" SELECT ");
                sb.Append("UTE_ID_UTENTE, ");
                sb.Append("UTE_USER_ID, COALESCE(UTE_COGNOME + ' ' + UTE_NOME,UTE_COGNOME) AS UTE_COGNOME_NOME ");
                sb.Append("FROM UTENTE WHERE UTE_FLAG_VISIBILE=1 AND UTE_FLAG_ELIMINATO=0 ");

                sb.Append(@sqlWhereClause);
                sb.Append(" ORDER BY UTE_STATO_UTENTE DESC, COALESCE(UTE_COGNOME + ' ' + UTE_NOME,UTE_COGNOME) ASC ");
                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);
                
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.getListDropDown.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return reader;
        }

        /// <summary>
        /// getListLivello
        /// </summary>
        /// <param name="qCultureInfoName"></param>
        /// <returns>dataSet:UTE_ID_UTENTE,UTE_USER_ID</returns>
        public IDataReader getListLivello()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder();
            DbCommand dbCommand = null;
            SqlDataReader reader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" SELECT ");
                sb.Append("FNT_ID_FUNZIONALITA, ");
                sb.Append("FNT_DESCRIZIONE_ITA ");
                sb.Append("FROM FUNZIONALITA ");

                sb.Append(@sqlWhereClause);
                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.getListLivello.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

                IDataReader idr = null;
                return idr;
            }

            return reader;
        }

        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void ReadRichiedente()
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 UTENTE.UTE_ID_UTENTE, 
					 UTENTE.ute_nome, 
					 UTENTE.ute_cognome, 
					 UTENTE.ute_descrizione, 
					 UTENTE.ute_user_id, 
					 UTENTE.UTE_PASSWORD, 
					 UTENTE.ute_telefono, 
					 UTENTE.ute_fax, 
					 UTENTE.ute_email, 
					 UTENTE.ute_stato_utente, 					 
					 UTENTE.ute_expiration_date, 					 					 
                     CENTRI_DI_COSTO.cdc_id_centro_di_costo,
                     CENTRI_DI_COSTO.cdc_codice_centro_di_costo,
                     UTENTE.ute_matricola
				 	 FROM UTENTE 
                     LEFT JOIN CENTRI_DI_COSTO ON UTENTE.CDC_ID_CENTRO_DI_COSTO = CENTRI_DI_COSTO.CDC_ID_CENTRO_DI_COSTO
                     WHERE (UTE_ID_UTENTE =@ute_id_utente) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    int i = 0;
                    ute_id_utente = reader.GetSqlInt32(i++);
                    ute_nome = reader.GetSqlString(i++);
                    ute_cognome = reader.GetSqlString(i++);
                    ute_descrizione = reader.GetSqlString(i++);
                    ute_user_id = reader.GetSqlString(i++);
                    ute_password = reader.GetSqlString(i++);
                    ute_telefono = reader.GetSqlString(i++);
                    ute_fax = reader.GetSqlString(i++);
                    ute_email = reader.GetSqlString(i++);
                    ute_stato_utente = reader.GetSqlBoolean(i++);                    
                    ute_expiration_date = reader.GetSqlDateTime(i++);
                    cdc_id_centro_di_costo = reader.GetSqlInt32(i++);
                    cdc_codice_centro_di_costo = reader.GetSqlString(i++);
                    ute_matricola = reader.GetSqlString(i++);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ReadRichiedente.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }     

        /// <summary>
        /// getListDropDownAbil. Restituisce gli Utenti e la loro abilitazione
        /// </summary>
        /// <param name="qCultureInfoName"></param>
        /// <returns>dataSet:UTE_ID_UTENTE,UTE_USER_ID</returns>
        public DataSet getListDropDownAbil()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder();
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" SELECT ");
                sb.Append("UTE_ID_UTENTE, ");
                sb.Append("UTE_USER_ID, ");
                sb.Append("COALESCE(UTE_COGNOME + ' ' + UTE_NOME,UTE_COGNOME) AS UTENTE, ");
                sb.Append("UTE_STATO_UTENTE ");
                sb.Append("FROM UTENTE ");

                sb.Append(@sqlWhereClause);
                sb.Append(" ORDER BY UTE_COGNOME,UTE_NOME,UTE_USER_ID ASC ");
                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                db.LoadDataSet(dbCommand, ds, "UTENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.getListDropDown.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            return ds;
        }

        /// <summary>
        /// getListDropDownAbil. Restituisce gli Utenti e la loro abilitazione
        /// </summary>
        /// <param name="qCultureInfoName"></param>
        /// <returns>dataSet:UTE_ID_UTENTE,UTE_USER_ID</returns>
        public static DataSet getListUploadInfo()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder();
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();
            

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" SELECT TOP 1 ");
                sb.Append("TRC_NRO_CESSATI, ");
                sb.Append("TRC_NRO_AGGIORNATI, ");
                sb.Append("TRC_NRO_NUOVI ");
                sb.Append("FROM TRACCIAMENTO_UPLOAD ");
                sb.Append(" ORDER BY TRC_ID_TRACCIAMENTO DESC ");
                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "TRACCIAMENTO_UPLOAD");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.getListUploadInfo.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            return ds;
        }

        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void ReadAutorizzatoreLivello2(Int32 idUtente)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT TOP 1 * FROM
                                (SELECT                                
                                dbo.AUTORIZZATORI_INDIVIDUALI.ute_id_utente_autorizzatore, COALESCE (UTENTE.ute_cognome + ' ' + UTENTE.ute_nome, 
                                UTENTE.ute_cognome) AS AUTORIZZATORE,'A' AS ORDINE,UTENTE.UTE_FLAG_VISIBILE,UTENTE.UTE_FLAG_ELIMINATO			     
                                FROM 
                                dbo.AUTORIZZATORI_INDIVIDUALI INNER JOIN
                                dbo.UTENTE ON dbo.AUTORIZZATORI_INDIVIDUALI.ute_id_utente_autorizzatore = UTENTE.ute_id_utente
                                WHERE aui_flag_autorizzatore_princ = 1 and dbo.AUTORIZZATORI_INDIVIDUALI.aui_livello_autorizzazione = 57 and dbo.AUTORIZZATORI_INDIVIDUALI.ute_id_utente = @ute_id_utente
                                
                                UNION ALL
                                
                                SELECT
                                UTENTE.ute_id_utente,COALESCE (UTENTE.ute_cognome + ' ' + UTENTE.ute_nome, UTENTE.ute_cognome) 
                                AS AUTORIZZATORE,'B' AS ORDINE,UTENTE.UTE_FLAG_VISIBILE,UTENTE.UTE_FLAG_ELIMINATO
                                FROM dbo.UTENTE INNER JOIN
                                dbo.CROSS_CDC_AUTORIZZATORI ON UTENTE.ute_id_utente = dbo.CROSS_CDC_AUTORIZZATORI.ute_id_utente 
                                INNER JOIN UTENTE UTENTE_AUTORIZZATO ON UTENTE_AUTORIZZATO.cdc_id_centro_di_costo = CROSS_CDC_AUTORIZZATORI.cdc_id_centro_di_costo
                                WHERE (dbo.CROSS_CDC_AUTORIZZATORI.crp_flag_autorizzatore_princ = 1) AND (crp_livello_autorizzazione = 57) 
                                AND UTENTE_AUTORIZZATO.ute_id_utente = @ute_id_utente) AUTORIZZATORE2


                                WHERE AUTORIZZATORE2.UTE_FLAG_VISIBILE = 1 AND AUTORIZZATORE2.UTE_FLAG_ELIMINATO = 0
                                ORDER BY ORDINE,AUTORIZZATORE ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, idUtente);                

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {                    
                    ute_id_utente_autorizzatore_2 = reader.GetSqlInt32(0);
                    ute_autorizzatore_2 = reader.GetSqlString(1);                 
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ReadAutorizzatoreLivello2.");
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
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void CheckPresidente(Int32 idUtente)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @"SELECT UTENTE.WRF_ID_WORKFLOW,WRF_CODICE FROM UTENTE 
                LEFT JOIN WORKFLOW ON UTENTE.WRF_ID_WORKFLOW = WORKFLOW.WRF_ID_WORKFLOW 
                WHERE UTE_ID_UTENTE=@ute_id_utente ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, idUtente);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    wrf_id_workflow = reader.GetSqlInt32(0);
                    codice_workflow = reader.GetSqlString(1);                    
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.CheckPresidente.");
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
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void CheckWfSpecifico(Int32 idUtente, Int32 idObj)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT CROSS_UTENTE_WORKFLOW.WRF_ID_WORKFLOW,WORKFLOW.WRF_CODICE 
                                FROM CROSS_UTENTE_WORKFLOW 
                                --INNER JOIN UTENTE ON CROSS_UTENTE_WORKFLOW.UTE_ID_UTENTE = CROSS_UTENTE_WORKFLOW.UTE_ID_UTENTE    
                                INNER JOIN WORKFLOW ON CROSS_UTENTE_WORKFLOW.WRF_ID_WORKFLOW = WORKFLOW.WRF_ID_WORKFLOW                 
                                WHERE CROSS_UTENTE_WORKFLOW.UTE_ID_UTENTE=@ute_id_utente AND WORKFLOW.OGT_ID_TIPO_OGGETTO = @idObj";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, idUtente);
                db.AddInParameter(dbCommand, "idObj", DbType.Int32, idObj);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    wrf_id_workflow = reader.GetSqlInt32(0);
                    codice_workflow = reader.GetSqlString(1);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.CheckWfSpecifico.");
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
        /// Elenca tutti gli utenti di una determinata figura (approvatori, richiedenti, ecc)
        /// </summary>
        public static DataSet ListDropDownUtentiFigura()
        {
            return ListDropDownUtentiFigura(string.Empty, "UTENTE");
        }
        /// <summary>
        /// Elenca tutti gli elementi Utente dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet ListDropDownUtentiFigura(string sqlWhereClause)
        {
            return ListDropDownUtentiFigura(sqlWhereClause, "UTENTE");
        }
        /// <summary>
        /// Elenca tutti gli elementi Utente dell'analisi. L'utente pu√≤ scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListDropDownUtentiFigura(string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" 
                            SELECT UTENTE.UTE_ID_UTENTE,
                            COALESCE(UTE_COGNOME + ' ' + UTE_NOME + ', (' + FNT_DESCRIZIONE_ITA + ', ' + CONVERT(VARCHAR,FUNZIONALITA.FNT_ID_FUNZIONALITA)  + ')', UTE_COGNOME) AS FIGURA
                            FROM UTENTE INNER JOIN RUOLI_UTENTE ON UTENTE.UTE_ID_UTENTE = RUOLI_UTENTE.UTE_ID_UTENTE
                            INNER JOIN PERMESSO_ACCESSO ON RUOLI_UTENTE.RUL_ID_RUOLO = PERMESSO_ACCESSO.RUL_ID_RUOLO
                            INNER JOIN FUNZIONALITA ON PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA = FUNZIONALITA.FNT_ID_FUNZIONALITA ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, "UTENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ListDropDownUtentiFigura.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }
       
        /// <summary>
        /// Elenca tutti gli elementi Piano_di_mitigazione dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet ListDropDownResponsabili()
        {
            return ListDropDownResponsabili(string.Empty, "UTENTE");
        }
        /// <summary>
        /// Elenca tutti gli elementi Utente dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet ListDropDownResponsabili(string sqlWhereClause)
        {
            return ListDropDownResponsabili(sqlWhereClause, "UTENTE");
        }
        /// <summary>
        /// Elenca tutti gli elementi Utente dell'analisi. L'utente pu√≤ scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListDropDownResponsabili(string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();
            

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT UTENTE.UTE_ID_UTENTE,
                             COALESCE(UTE_COGNOME + ' ' + UTE_NOME, UTE_COGNOME) AS RESPONSABILE,FNT_DESCRIZIONE_ITA,FUNZIONALITA.FNT_ID_FUNZIONALITA
                             FROM UTENTE INNER JOIN RUOLI_UTENTE ON UTENTE.UTE_ID_UTENTE = RUOLI_UTENTE.UTE_ID_UTENTE
                             INNER JOIN PERMESSO_ACCESSO ON RUOLI_UTENTE.RUL_ID_RUOLO = PERMESSO_ACCESSO.RUL_ID_RUOLO
                             INNER JOIN FUNZIONALITA ON PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA = FUNZIONALITA.FNT_ID_FUNZIONALITA
                             WHERE FNT_ACRONIMO_FUNZIONALITA IN ('RESPAREA') AND PMS_ID_MODALITA_ACCESSO = 4 AND UTE_FLAG_VISIBILE=1 AND UTE_FLAG_ELIMINATO=0 ORDER BY RESPONSABILE ASC");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, "UTENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ListDropDownResponsabili.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Elenca tutti gli elementi Piano_di_mitigazione dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet ListDropDownAutorizzato()
        {
            return ListDropDownAutorizzato(string.Empty, "UTENTE");
        }
        /// <summary>
        /// Elenca tutti gli elementi Utente dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet ListDropDownAutorizzato(string sqlWhereClause)
        {
            return ListDropDownAutorizzato(sqlWhereClause, "UTENTE");
        }
        /// <summary>
        /// Elenca tutti gli elementi Utente dell'analisi. L'utente pu√≤ scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListDropDownAutorizzato(string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT UTENTE.UTE_ID_UTENTE,
                             COALESCE(UTE_COGNOME + ' ' + UTE_NOME, UTE_COGNOME) AS AUTORIZZATO                             
                             FROM UTENTE INNER JOIN RUOLI_UTENTE ON UTENTE.UTE_ID_UTENTE = RUOLI_UTENTE.UTE_ID_UTENTE
                             WHERE RUL_ID_RUOLO = 6 OR RUL_ID_RUOLO = 5 AND (UTE_FLAG_VISIBILE=1 AND UTE_FLAG_ELIMINATO=0)

                             ORDER BY AUTORIZZATO ASC"); //6 STA PER AUTORIZZATORE.

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, "UTENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ListDropDownAutorizzato.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }       

        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void ReadAutorizzatori()
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 AUTORIZZATORI_INDIVIDUALI.UTE_ID_UTENTE, 
					 UTE_ID_UTENTE_AUTORIZZATORE,
                     AUI_FLAG_AUTORIZZATORE_PRINC,
                     AUI_LIVELLO_AUTORIZZAZIONE,
                     COALESCE(UTE_COGNOME + ' '  + UTE_NOME,UTE_COGNOME) AS AUTORIZZATORE
				 	 FROM AUTORIZZATORI_INDIVIDUALI 
                     LEFT JOIN UTENTE ON AUTORIZZATORI_INDIVIDUALI.UTE_ID_UTENTE_AUTORIZZATORE = UTENTE.UTE_ID_UTENTE
                     WHERE 
					 (AUTORIZZATORI_INDIVIDUALI.UTE_ID_UTENTE =@ute_id_utente AND UTE_ID_UTENTE_AUTORIZZATORE = @ute_id_utente_autorizzatore) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "ute_id_utente_autorizzatore", DbType.Int32, ute_id_utente_autorizzatore);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    ute_id_utente = reader.GetSqlInt32(0);
                    ute_id_utente_autorizzatore = reader.GetSqlInt32(1);
                    aui_flag_autorizzatore_princ = reader.GetSqlInt32(2);
                    aui_livello_autorizzazione = reader.GetSqlInt32(3);
                    ute_autorizzatore = reader.GetSqlString(4);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.Read.");
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
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void ReadAutorizzatori(int p_aui_id_autorizzazione)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 AUTORIZZATORI_INDIVIDUALI.UTE_ID_UTENTE, 
					 UTE_ID_UTENTE_AUTORIZZATORE,
                     AUI_FLAG_AUTORIZZATORE_PRINC,
                     AUI_LIVELLO_AUTORIZZAZIONE,
                     AUI_FLAG_NOTIFICA                     
				 	 FROM AUTORIZZATORI_INDIVIDUALI 
                     WHERE  AUI_ID_AUTORIZZAZIONE = @aui_id_autorizzazione
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                
                db.AddInParameter(dbCommand, "aui_id_autorizzazione", DbType.Int32, p_aui_id_autorizzazione);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    ute_id_utente = reader.GetSqlInt32(0);
                    ute_id_utente_autorizzatore = reader.GetSqlInt32(1);
                    aui_flag_autorizzatore_princ = reader.GetSqlInt32(2);
                    aui_livello_autorizzazione = reader.GetSqlInt32(3);
                    aui_flag_notifica = reader.GetSqlInt32(4);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.Read.");
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
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void ReadAutorizzato()
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 UTE_ID_UTENTE, 
					 UTE_ID_UTENTE_AUTORIZZATORE,
                     AUI_FLAG_AUTORIZZATORE_PRINC,
                     AUI_LIVELLO_AUTORIZZAZIONE                     
				 	 FROM AUTORIZZATORI_INDIVIDUALI WHERE 
					 (UTE_ID_UTENTE_AUTORIZZATORE = @ute_id_utente) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    ute_id_utente = reader.GetSqlInt32(0);
                    ute_id_utente_autorizzatore = reader.GetSqlInt32(1);
                    aui_flag_autorizzatore_princ = reader.GetSqlInt32(2);
                    aui_livello_autorizzazione = reader.GetSqlInt32(3);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.Read.");
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
        /// Valida i dati di login utente.
        /// </summary>
        /// <returns>true se i dati di login sono corretti, false altrimenti.
        /// </returns>
        public bool CheckLogin(bool checkPwd)
        {
            string sqlCmd;
            IDataReader objDr = null;
            bool retVal = false;

            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

            // Elenco dei campi della query
            const int CHK_UTE_ID_UTENTE = 0;
            const int CHK_UTE_NOME = 1;
            const int CHK_UTE_COGNOME = 2;
            const int CHK_UTE_SIGLA = 3;
            const int CHK_UTE_EXPIRATION_DATE = 4;
            const int CHK_UTE_ULTIMO_ACCESSO = 5;
            const int CHK_TPI_ACRONIMO = 6;            
            const int CHK_CLI_ID_CLIENTE = 7;
            const int CHK_UTE_NRO_MAX_SESSIONI = 8;
            const int CHK_UTE_GESTIONE_GRUPPO = 9;

            // Query
            sqlCmd = "SELECT UTE_ID_UTENTE, UTE_NOME, UTE_COGNOME, UTE_SIGLA, UTE_EXPIRATION_DATE, UTE_ULTIMO_ACCESSO,LOOKUP_TIPO_INSTALLAZIONE.TPI_ACRONIMO,UTENTE.CLI_ID_CLIENTE,UTE_NRO_MAX_SESSIONI,UTE_GESTIONE_GRUPPO ";
            sqlCmd = sqlCmd + "FROM UTENTE LEFT JOIN CLIENTI ON UTENTE.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE ";
            sqlCmd = sqlCmd + "INNER JOIN LOOKUP_TIPO_INSTALLAZIONE ON CLIENTI.TPI_ID_TIPO_INSTALLAZIONE = LOOKUP_TIPO_INSTALLAZIONE.TPI_ID_TIPO_INSTALLAZIONE WHERE UTE_USER_ID = @ute_user_id ";
            if (checkPwd)
                sqlCmd = sqlCmd + "AND UTE_PASSWORD = @ute_password ";
            
            sqlCmd = sqlCmd + "AND UTENTE.UTE_STATO_UTENTE = 1 ";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCmd);
            db.AddInParameter(dbCommand, "ute_user_id", DbType.String, ute_user_id);
            db.AddInParameter(dbCommand, "ute_password", DbType.String, ute_password);
            db.AddInParameter(dbCommand, "ute_sigla", DbType.String, ute_sigla);

            try
            {

                //return 
                objDr = db.ExecuteReader(dbCommand);

                if (objDr.Read())
                {
                    if (!objDr.IsDBNull(CHK_UTE_ID_UTENTE))
                        ute_id_utente = objDr.GetInt32(CHK_UTE_ID_UTENTE);
                    if (!objDr.IsDBNull(CHK_UTE_NOME))
                        ute_nome = objDr.GetString(CHK_UTE_NOME);
                    if (!objDr.IsDBNull(CHK_UTE_COGNOME))
                        ute_cognome = objDr.GetString(CHK_UTE_COGNOME);
                    if (!objDr.IsDBNull(CHK_UTE_SIGLA))
                        ute_sigla = objDr.GetString(CHK_UTE_SIGLA);
                    if (!objDr.IsDBNull(CHK_UTE_EXPIRATION_DATE))
                        ute_expiration_date = objDr.GetDateTime(CHK_UTE_EXPIRATION_DATE);
                    if (!objDr.IsDBNull(CHK_UTE_ULTIMO_ACCESSO))
                        ute_ultimo_accesso = objDr.GetDateTime(CHK_UTE_ULTIMO_ACCESSO);
                    if (!objDr.IsDBNull(CHK_TPI_ACRONIMO))
                        tpi_acronimo = objDr.GetString(CHK_TPI_ACRONIMO);
                    else
                        tpi_acronimo = string.Empty;
                    if (!objDr.IsDBNull(CHK_CLI_ID_CLIENTE))
                        cli_id_cliente = objDr.GetInt32(CHK_CLI_ID_CLIENTE);
                    if (!objDr.IsDBNull(CHK_UTE_NRO_MAX_SESSIONI))
                        ute_nro_max_sessioni = objDr.GetInt32(CHK_UTE_NRO_MAX_SESSIONI);

                    if (!objDr.IsDBNull(CHK_UTE_GESTIONE_GRUPPO))
                        ute_gestione_gruppo = objDr.GetInt32(CHK_UTE_GESTIONE_GRUPPO);

                    retVal = true;
                }
                objDr.Close();
            }
            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (objDr != null)
                    ((IDisposable)objDr).Dispose();
            }
            return retVal;
             
        }
        
        /// <summary>
        /// Valida i dati di login utente.
        /// </summary>
        /// <returns>true se i dati di login sono corretti, false altrimenti.
        /// </returns>
        public bool CheckByPassLogin()
        {
            string sqlCmd;
            IDataReader objDr = null;
            bool retVal = false;

            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

            // Elenco dei campi della query
            const int CHK_UTE_ID_UTENTE = 0;
            const int CHK_UTE_NOME = 1;
            const int CHK_UTE_COGNOME = 2;
            const int CHK_UTE_SIGLA = 3;
            const int CHK_UTE_EXPIRATION_DATE = 4;
            const int CHK_UTE_ULTIMO_ACCESSO = 5;
            const int CHK_TPI_ACRONIMO = 6;            
            const int CHK_RIV_ID_RICHIESTA = 7;
            const int CHK_IOA_WRF_CODICE = 8;
            const int CHK_CLI_ID_CLIENTE = 9;

            // Query
            sqlCmd = "SELECT UTENTE.UTE_ID_UTENTE, UTE_NOME, UTE_COGNOME, UTE_SIGLA, UTE_EXPIRATION_DATE, UTE_ULTIMO_ACCESSO,LOOKUP_TIPO_INSTALLAZIONE.TPI_ACRONIMO,MAIL_CLICK.RIV_ID_RICHIESTA,IOA_WRF_CODICE,UTENTE.CLI_ID_CLIENTE ";
            sqlCmd = sqlCmd + "FROM MAIL_CLICK INNER JOIN UTENTE ON MAIL_CLICK.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE LEFT JOIN CLIENTI ON UTENTE.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE ";
            sqlCmd = sqlCmd + "INNER JOIN VIEW_WF_PERMANENZA_STATO_CORRENTE ON MAIL_CLICK.RIV_ID_RICHIESTA = VIEW_WF_PERMANENZA_STATO_CORRENTE.IOA_ID_OGGETTO "; 
            sqlCmd = sqlCmd + "INNER JOIN LOOKUP_TIPO_INSTALLAZIONE ON CLIENTI.TPI_ID_TIPO_INSTALLAZIONE = LOOKUP_TIPO_INSTALLAZIONE.TPI_ID_TIPO_INSTALLAZIONE WHERE ";                        
            sqlCmd = sqlCmd + "MAIL_CLICK.MAC_CODICE_UNIVOCO = @mac_codice_univoco ";
            sqlCmd = sqlCmd + "AND MAIL_CLICK.MAC_STATO_MAIL = 1 ";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCmd);
            db.AddInParameter(dbCommand, "mac_codice_univoco", DbType.String, mac_codice_univoco);            

            try
            {

                //return 
                objDr = db.ExecuteReader(dbCommand);

                if (objDr.Read())
                {
                    if (!objDr.IsDBNull(CHK_UTE_ID_UTENTE))
                        ute_id_utente = objDr.GetInt32(CHK_UTE_ID_UTENTE);
                    if (!objDr.IsDBNull(CHK_UTE_NOME))
                        ute_nome = objDr.GetString(CHK_UTE_NOME);
                    if (!objDr.IsDBNull(CHK_UTE_COGNOME))
                        ute_cognome = objDr.GetString(CHK_UTE_COGNOME);
                    if (!objDr.IsDBNull(CHK_UTE_SIGLA))
                        ute_sigla = objDr.GetString(CHK_UTE_SIGLA);
                    if (!objDr.IsDBNull(CHK_UTE_EXPIRATION_DATE))
                        ute_expiration_date = objDr.GetDateTime(CHK_UTE_EXPIRATION_DATE);
                    if (!objDr.IsDBNull(CHK_UTE_ULTIMO_ACCESSO))
                        ute_ultimo_accesso = objDr.GetDateTime(CHK_UTE_ULTIMO_ACCESSO);                    
                    if (!objDr.IsDBNull(CHK_TPI_ACRONIMO))
                        tpi_acronimo = objDr.GetString(CHK_TPI_ACRONIMO);
                    else
                        tpi_acronimo = string.Empty;
                    if (!objDr.IsDBNull(CHK_RIV_ID_RICHIESTA))
                        riv_id_richiesta = objDr.GetInt32(CHK_RIV_ID_RICHIESTA);
                    if (!objDr.IsDBNull(CHK_IOA_WRF_CODICE))
                        ioa_wrf_codice = objDr.GetString(CHK_IOA_WRF_CODICE);
                    if (!objDr.IsDBNull(CHK_CLI_ID_CLIENTE))
                        cli_id_cliente = objDr.GetInt32(CHK_CLI_ID_CLIENTE);

                    retVal = true;
                }
                objDr.Close();
            }
            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (objDr != null)
                    ((IDisposable)objDr).Dispose();
            }
            return retVal;

        }

        /// <summary>
        /// Verifica l'esistenza di un certo utente
        /// </summary>
        /// <returns>true se l'utente esiste, false altrimenti.
        /// </returns>
        public bool CheckUser()
        {
            string sqlCmd;
            IDataReader objDr = null;            
            bool retVal = false;

            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

            // Elenco dei campi della query
            const int CHK_UTE_ID_UTENTE = 0;

            // Query
            sqlCmd = "SELECT UTE_ID_UTENTE ";
            sqlCmd = sqlCmd + "FROM UTENTE WHERE UTE_USER_ID = @ute_user_id ";
            sqlCmd = sqlCmd + "AND UTENTE.UTE_STATO_UTENTE = 1 AND UTE_FLAG_ELIMINATO = 0 ";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCmd);
            db.AddInParameter(dbCommand, "ute_user_id", DbType.String, ute_user_id);
            db.AddInParameter(dbCommand, "ute_sigla", DbType.String, ute_sigla);

            try
            {
                objDr = db.ExecuteReader(dbCommand);

                if (objDr.Read())
                {
                    if (!objDr.IsDBNull(CHK_UTE_ID_UTENTE))
                        ute_id_utente = objDr.GetInt32(CHK_UTE_ID_UTENTE);
                    retVal = true;
                }
                objDr.Close();
            }
            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (objDr != null)
                    ((IDisposable)objDr).Dispose();
            }
            return retVal;

        }

        /// <summary>
        /// Determina i permessi dell'utente autenticato.
        /// </summary>
        /// <returns>Dizionario nome/valore con la modalit‡ di accesso e l'acronimo 
        /// funzionalit‡</returns>
        public Dictionary<string, int> BuildPermissions()
        {
            string sqlCmd;
            //IDataReader objDr = null;
            SqlDataReader reader = null;
            int modalita = 0;
            string acronimo = " ";
            Dictionary<string, int> permissions;		// permessi dell'utente

            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

            // Elenco dei campi della query
            const int MODALITA_ACCESSO = 0;
            const int ACRONIMO_FUNZIONALITA = 1;

            // Query
            sqlCmd = "SELECT MAX(PERMESSO_ACCESSO.PMS_ID_MODALITA_ACCESSO) AS MODALITA_ACCESSO, ";
            sqlCmd = sqlCmd + " UPPER(RTRIM(FUNZIONALITA.FNT_ACRONIMO_FUNZIONALITA)) AS ACRONIMO_FUNZIONALITA ";
            sqlCmd = sqlCmd + " FROM UTENTE ";
            sqlCmd = sqlCmd + "  INNER JOIN RUOLI_UTENTE ON RUOLI_UTENTE.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE ";
            sqlCmd = sqlCmd + "  INNER JOIN RUOLI ON RUOLI_UTENTE.RUL_ID_RUOLO = RUOLI.RUL_ID_RUOLO ";
            sqlCmd = sqlCmd + "  INNER JOIN PERMESSO_ACCESSO ON RUOLI.RUL_ID_RUOLO = PERMESSO_ACCESSO.RUL_ID_RUOLO ";
            sqlCmd = sqlCmd + "  INNER JOIN FUNZIONALITA ON PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA = FUNZIONALITA.FNT_ID_FUNZIONALITA ";
            sqlCmd = sqlCmd + "WHERE UTENTE.UTE_ID_UTENTE = @ute_id_utente ";
            sqlCmd = sqlCmd + "AND RUOLI_UTENTE.URL_STATO_RUOLO_UTENTE = 1 ";
            sqlCmd = sqlCmd + "GROUP BY FUNZIONALITA.FNT_ACRONIMO_FUNZIONALITA ";
            sqlCmd = sqlCmd + "ORDER BY FUNZIONALITA.FNT_ACRONIMO_FUNZIONALITA";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCmd);
            db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);

            try
            {
                //
                // Se non torna righe l'utente non Ë configurato
                //
                //objDr = db.ExecuteReader(dbCommand);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                //
                // Se non torna righe l'utente non Ë autenticato
                //
                //SqlDataReader sqlDR = (SqlDataReader)objDr;
                //if (!sqlDR.HasRows)
                if (!reader.HasRows)
                {
                    //uteNonConfiguratoException = new BusLogicException("Utente.BuildPermissions()");
                    //uteNonConfiguratoException.AdditionalInformation.Add("800", "Utente non configurato");
                    //throw uteNonConfiguratoException;

                    throw new System.Exception("Utente non autenticato...");

                }
                permissions = new Dictionary<string, int>();

                //while (objDr.Read())
                //{
                //    if (!objDr.IsDBNull(MODALITA_ACCESSO))
                //        modalita = (objDr.GetInt32(MODALITA_ACCESSO));
                //    if (!objDr.IsDBNull(ACRONIMO_FUNZIONALITA))
                //        acronimo = objDr.GetString(ACRONIMO_FUNZIONALITA);

                //    //Debug.Assert(!objDr.IsDBNull(MODALITA_ACCESSO) && !objDr.IsDBNull(ACRONIMO_FUNZIONALITA),
                //    //            "Utente.BuildPermissions(): Configurazione utente incompleta!");
                //    permissions.Add(acronimo, modalita);
                //}
                //objDr.Close();
                while (reader.Read())
                {
                    modalita = (int)reader.GetSqlInt32(MODALITA_ACCESSO);
                    acronimo = (string)reader.GetSqlString(ACRONIMO_FUNZIONALITA);

                    //Debug.Assert(!objDr.IsDBNull(MODALITA_ACCESSO) && !objDr.IsDBNull(ACRONIMO_FUNZIONALITA),
                    //            "Utente.BuildPermissions(): Configurazione utente incompleta!");
                    permissions.Add(acronimo, modalita);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                //if (objDr != null)
                //    ((IDisposable)objDr).Dispose();
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
            return permissions;
        }

        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void UltimoAccesso()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE UTENTE SET 
					 UTE_ULTIMO_ACCESSO = getdate(),
                     UTE_ACCESSI_ERRATI = NULL
					 WHERE   
				     (UTE_ID_UTENTE =@ute_id_utente) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.UltimoAccesso.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public int AccessoErrato()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader objDr = null;
            int esito = -1;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE UTENTE SET 
					 UTE_ULTIMO_ACCESSO = getdate(),
                     UTE_ACCESSI_ERRATI = COALESCE(UTE_ACCESSI_ERRATI,0)+1 
					 WHERE   
				     (UTE_USER_ID =@ute_user_id) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_user_id", DbType.String, ute_user_id);

                db.ExecuteNonQuery(dbCommand);

                //Verifico poi se ha raggiunto/superato il max numero di accessi errati ammissibile
                //Valori di ritorno: 1 = max nro tentativi RAGGIUNTO (utente da disattivare)
                //                   0 = max nro tentativi NON ANCORA RAGGIUNTO
                sqlCommand = @" SELECT 
                                (CASE WHEN UTE_ACCESSI_ERRATI >= 
                                    (SELECT 
                                        (CASE WHEN SIS_MAX_TENTATIVI_PASSWORD = -1 
                                     THEN 1000 ELSE SIS_MAX_TENTATIVI_PASSWORD END) FROM SISTEMA) 
                                THEN 1 ELSE 0 END)
                                FROM UTENTE
        					    WHERE (UTE_USER_ID = @ute_user_id) 
		        			 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_user_id", DbType.String, ute_user_id);

                objDr = db.ExecuteReader(dbCommand);

                if (objDr.Read())
                {
                    if (!objDr.IsDBNull(0))
                        esito = objDr.GetInt32(0);
                }
                objDr.Close();
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.UltimoAccesso.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                //In caso di errore, Ë come se lo UserID non esistesse
            }
            finally
            {
                if (objDr != null)
                    ((IDisposable)objDr).Dispose();
            }
            return esito;
        }

        /// <summary>
        /// Aggiorna la colonna UTE_SESSION_ID: =ute_id_utente al Login, =NULL al Logout
        /// </summary>	
        public void Login_Logout(string action)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            SqlInt32 theValue;

            if (action == "Login")
                theValue = this.ute_id_utente;
            else
                theValue = SqlInt32.Null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE UTENTE SET 
					 UTE_SESSION_ID = @theValue
					 WHERE   
				     (UTE_ID_UTENTE =@ute_id_utente) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "theValue", DbType.Int32, theValue);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.Login_Logout.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void DisattivaUserID()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE UTENTE SET 
					 UTE_STATO_UTENTE = 0 " + SqlWhereClause;

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.UltimoAccesso.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Elenca tutti gli utenti
        /// </summary>
        public DataSet ListUtenti()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder();
            DbCommand dbCommand = null;
            bool rethrow;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" SELECT ");
                sb.Append("UTE_ID_UTENTE, ");
                sb.Append("UTE_COGNOME ");
                sb.Append("FROM UTENTE ");
                sb.Append("WHERE UTE_FLAG_VISIBILE=1 AND UTE_FLAG_ELIMINATO=0 ");
                //sb.Append(@sqlWhereClause);

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                db.LoadDataSet(dbCommand, utenteListDS, "UTENTI");
                return utenteListDS;

            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ListUtenti.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                rethrow = ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                if (rethrow) throw;

                return utenteListDS;
            }

            finally
            {
                if (utenteListDS != null)
                    ((IDisposable)utenteListDS).Dispose();
            }
        }

        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void CreateAutorizzatore()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO AUTORIZZATORI_INDIVIDUALI 
                        (
						    ute_id_utente, 
						    ute_id_utente_autorizzatore, 
						    aui_flag_autorizzatore_princ ,
                            aui_livello_autorizzazione,
                            aui_flag_notifica
						) 
					VALUES 
                        ( 
						    @ute_id_utente, 
						    @ute_id_utente_autorizzatore, 
						    @aui_flag_autorizzatore_princ,
                            @aui_livello_autorizzazione,
                            @aui_flag_notifica
						) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "ute_id_utente_autorizzatore", DbType.Int32, ute_id_utente_autorizzatore);
                db.AddInParameter(dbCommand, "aui_flag_autorizzatore_princ", DbType.Int32, aui_flag_autorizzatore_princ);
                db.AddInParameter(dbCommand, "aui_livello_autorizzazione", DbType.Int32, aui_livello_autorizzazione);
                db.AddInParameter(dbCommand, "aui_flag_notifica", DbType.Int32, aui_flag_notifica);
                
                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    //ute_id_utente = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.CreateAutorizzatore.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            finally
            {
                if (dataReader != null)
                    ((IDisposable)dataReader).Dispose();
            }
        }

        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void UpdateAutorizzatori(SqlInt32 p_aui_id_autorizzazione)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE AUTORIZZATORI_INDIVIDUALI SET					 					 
                     ute_id_utente = @ute_id_utente,
                     ute_id_utente_autorizzatore = @ute_id_utente_autorizzatore,
                     aui_flag_autorizzatore_princ = @aui_flag_autorizzatore_princ,
                     aui_livello_autorizzazione = @aui_livello_autorizzazione,
                     aui_flag_notifica = @aui_flag_notifica
					 WHERE   
				     (aui_id_autorizzazione = @aui_id_autorizzazione) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "aui_flag_notifica", DbType.Int32, aui_flag_notifica);
                db.AddInParameter(dbCommand, "aui_id_autorizzazione", DbType.Int32, p_aui_id_autorizzazione);
                db.AddInParameter(dbCommand, "aui_flag_autorizzatore_princ", DbType.Int32, aui_flag_autorizzatore_princ);
                db.AddInParameter(dbCommand, "aui_livello_autorizzazione", DbType.Int32, aui_livello_autorizzazione);
                db.AddInParameter(dbCommand, "ute_id_utente_autorizzatore", DbType.Int32, ute_id_utente_autorizzatore);
                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Centri_di_costo.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void CreateAutorizzato()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO AUTORIZZATORI_INDIVIDUALI 
                        (
						    ute_id_utente, 
						    ute_id_utente_autorizzatore,
                            aui_flag_autorizzatore_princ,
                            aui_livello_autorizzazione 					    
						) 
					VALUES 
                        (                             
						    @ute_id_utente,
                            @ute_id_utente_autorizzato,
                            @aui_flag_autorizzatore_princ,
                            @aui_livello_autorizzazione			    						    
						) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "ute_id_utente_autorizzato", DbType.Int32, ute_id_utente_autorizzato);
                db.AddInParameter(dbCommand, "aui_flag_autorizzatore_princ", DbType.Int32, aui_flag_autorizzatore_princ);
                db.AddInParameter(dbCommand, "aui_livello_autorizzazione", DbType.Int32, aui_livello_autorizzazione);                

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    ute_id_utente = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.CreateAutorizzatore.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            finally
            {
                if (dataReader != null)
                    ((IDisposable)dataReader).Dispose();
            }
        }

        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void ResetAutorizzatorePrinc()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE AUTORIZZATORI_INDIVIDUALI SET 
					 aui_flag_autorizzatore_princ = 0					 
					 WHERE   
				     (UTE_ID_UTENTE =@ute_id_utente AND aui_livello_autorizzazione = @aui_livello_autorizzazione) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);               

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "aui_livello_autorizzazione", DbType.Int32, aui_livello_autorizzazione);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ResetAutorizzatorePrinc.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }
       
        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void UpdateLastPing(string p_session_id)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            SqlGuid sessionId = SqlGuid.Parse(p_session_id);

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE SESSIONI_UTENTI SET 					
                     ssu_data_last_ping = getdate()                     
					 WHERE   
				     (SSU_ID_SESSIONE =@sessionId) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sessionId", DbType.Guid, sessionId);
                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.UpdateLastPing.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// getListLivello
        /// </summary>
        /// <param name="qCultureInfoName"></param>
        /// <returns>dataSet:UTE_ID_UTENTE,UTE_USER_ID</returns>
        public DataSet getListLivelloUtente(Int32 p_ute_id_utente)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder();
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                
                sb.Append(" SELECT ");
                sb.Append(" FUNZIONALITA.FNT_ID_FUNZIONALITA, ");
                sb.Append(" FUNZIONALITA.FNT_DESCRIZIONE_ITA ");
                sb.Append(" FROM FUNZIONALITA ");
                sb.Append(" INNER JOIN PERMESSO_ACCESSO ON FUNZIONALITA.FNT_ID_FUNZIONALITA = PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA ");
                sb.Append(" INNER JOIN RUOLI ON PERMESSO_ACCESSO.RUL_ID_RUOLO = RUOLI.RUL_ID_RUOLO ");
                sb.Append(" INNER JOIN RUOLI_UTENTE ON RUOLI.RUL_ID_RUOLO = RUOLI_UTENTE.RUL_ID_RUOLO ");
                sb.Append(" INNER JOIN UTENTE ON RUOLI_UTENTE.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE ");
                sb.Append(" WHERE FNT_ACRONIMO_FUNZIONALITA IN ('APPLIV1','APPLIV2') AND UTENTE.UTE_ID_UTENTE=@ute_id_utente AND PMS_ID_MODALITA_ACCESSO = 4 ");
                sb.Append(@sqlWhereClause);
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
               
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, p_ute_id_utente);
                db.LoadDataSet(dbCommand, ds, "FUNZIONALITA");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.getListLivelloUtente.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            return ds;
        }

        public void getAcronimoInstallazioneUtente(Int32 p_ute_id_utente)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;
            StringBuilder sb = new StringBuilder();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
                 TPI_ACRONIMO 
                 FROM UTENTE 
                 INNER JOIN CLIENTI ON UTENTE.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE 
                 INNER JOIN LOOKUP_TIPO_INSTALLAZIONE ON CLIENTI.TPI_ID_TIPO_INSTALLAZIONE = LOOKUP_TIPO_INSTALLAZIONE.TPI_ID_TIPO_INSTALLAZIONE 
                 WHERE UTENTE.UTE_ID_UTENTE = @ute_id_utente ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.String, p_ute_id_utente);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    tpi_acronimo = reader.GetSqlString(0);                    
                }
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.getAcronimoInstallazioneUtente.");
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
        
        public DataSet getViaggiatore(Int32 idViaggiatore)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();
            

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"         
                      SELECT                      
                      UTENTE.UTE_ID_UTENTE,
                      UTE_COGNOME,
                      UTE_NOME,
                      CDC_ID_CENTRO_DI_COSTO,
                      WRF_CODICE,
                      UTE_EMAIL,
                      COALESCE(UTE_COGNOME + ' ' + UTE_NOME,UTE_COGNOME) AS UTENTE, 
                      UTE_TELEFONO,
                      UTE_MATRICOLA,
                      LSL_ID_SOCIETA_CLIENTE
                      FROM UTENTE                      
                      INNER JOIN CROSS_UTENTE_WORKFLOW ON UTENTE.UTE_ID_UTENTE = CROSS_UTENTE_WORKFLOW.UTE_ID_UTENTE
                      INNER JOIN WORKFLOW ON CROSS_UTENTE_WORKFLOW.WRF_ID_WORKFLOW = WORKFLOW.WRF_ID_WORKFLOW                      
                      WHERE UTENTE.UTE_ID_UTENTE = @idViaggiatore ");

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "idViaggiatore", DbType.Int32, idViaggiatore);
                db.LoadDataSet(dbCommand, ds, "UTENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.getViaggiatore.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }
     
        public DataSet getTravellerAuthorizator(Int32 idViaggiatore)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();
            

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"         
                            SELECT TOP 1 * 
                            FROM														
                            (
							    SELECT
                                dbo.AUTORIZZATORI_INDIVIDUALI.ute_id_utente_autorizzatore as idAutorizzatore, 
                                FNT_DESCRIZIONE_ITA AS Ruolo, 
                                dbo.AUTORIZZATORI_INDIVIDUALI.aui_livello_autorizzazione,
                                fnt_acronimo_funzionalita,
                                aui_flag_autorizzatore_princ,
				                COALESCE(UTE_AUTORIZZATORE.ute_cognome + ' ' + UTE_AUTORIZZATORE.ute_nome, UTE_AUTORIZZATORE.ute_cognome) as autorizzatore,	
                                1 as priorita
                                FROM
                                UTENTE INNER JOIN
                                dbo.AUTORIZZATORI_INDIVIDUALI ON UTENTE.ute_id_utente = dbo.AUTORIZZATORI_INDIVIDUALI.ute_id_utente INNER JOIN                            
				                funzionalita ON funzionalita.fnt_id_funzionalita = aui_livello_autorizzazione
				                INNER JOIN UTENTE UTE_AUTORIZZATORE ON AUTORIZZATORI_INDIVIDUALI.UTE_ID_UTENTE_AUTORIZZATORE = UTE_AUTORIZZATORE.UTE_ID_UTENTE
                                WHERE dbo.UTENTE.ute_id_utente = @idViaggiatore AND fnt_acronimo_funzionalita = 'APPLIV1'                                
                            ) AUTORIZZATORI

                            ORDER BY PRIORITA DESC,aui_flag_autorizzatore_princ DESC ");

                /*
                UNION                                
                SELECT
                CROSS_CDC_AUTORIZZATORI.ute_id_utente AS idAutorizzatore, 
                FNT_DESCRIZIONE_ITA AS Ruolo, 
                crp_livello_autorizzazione,
                fnt_acronimo_funzionalita,
                crp_flag_autorizzatore_princ,
	            COALESCE(UTE_AUTORIZZATORE.ute_cognome + ' ' + UTE_AUTORIZZATORE.ute_nome, UTE_AUTORIZZATORE.ute_cognome) as autorizzatore,
                0 as priorita
                FROM                                    
                CENTRI_DI_COSTO INNER JOIN UTENTE ON CENTRI_DI_COSTO.cdc_id_centro_di_costo = UTENTE.cdc_id_centro_di_costo														
                INNER JOIN CROSS_CDC_AUTORIZZATORI  ON CENTRI_DI_COSTO.cdc_id_centro_di_costo = CROSS_CDC_AUTORIZZATORI.cdc_id_centro_di_costo 
				INNER JOIN UTENTE UTE_AUTORIZZATORE ON CROSS_CDC_AUTORIZZATORI.UTE_ID_UTENTE = UTE_AUTORIZZATORE.UTE_ID_UTENTE
                INNER JOIN funzionalita ON funzionalita.fnt_id_funzionalita = crp_livello_autorizzazione  
                WHERE UTENTE.ute_id_utente = @idViaggiatore AND fnt_acronimo_funzionalita = 'APPLIV1'
                                
                */

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "idViaggiatore", DbType.Int32, idViaggiatore);
                db.LoadDataSet(dbCommand, ds, "UTENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.getTravellerInformation.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public DataSet getTravellerAuthorizator2(Int32 idViaggiatore)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();
            

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"         
                            SELECT TOP 1 * 
                            FROM														
                            (							    
                                SELECT
                                dbo.AUTORIZZATORI_INDIVIDUALI.ute_id_utente_autorizzatore as idAutorizzatore, 
                                FNT_DESCRIZIONE_ITA AS Ruolo, 
                                dbo.AUTORIZZATORI_INDIVIDUALI.aui_livello_autorizzazione,
                                fnt_acronimo_funzionalita,
                                aui_flag_autorizzatore_princ,
								COALESCE(UTE_AUTORIZZATORE.ute_cognome + ' ' + UTE_AUTORIZZATORE.ute_nome, UTE_AUTORIZZATORE.ute_cognome) as autorizzatore,	
                                1 as priorita
                                FROM
                                UTENTE INNER JOIN
                                dbo.AUTORIZZATORI_INDIVIDUALI ON UTENTE.ute_id_utente = dbo.AUTORIZZATORI_INDIVIDUALI.ute_id_utente INNER JOIN                            
								funzionalita ON funzionalita.fnt_id_funzionalita = aui_livello_autorizzazione
								INNER JOIN UTENTE UTE_AUTORIZZATORE ON AUTORIZZATORI_INDIVIDUALI.UTE_ID_UTENTE_AUTORIZZATORE = UTE_AUTORIZZATORE.UTE_ID_UTENTE
                                WHERE dbo.UTENTE.ute_id_utente = @idViaggiatore AND fnt_acronimo_funzionalita = 'APPLIV2'
                                                          
                             ) AUTORIZZATORI

                            ORDER BY PRIORITA DESC,aui_flag_autorizzatore_princ DESC ");

                            /*
                            UNION
                            SELECT
                            CROSS_CDC_AUTORIZZATORI.ute_id_utente AS idAutorizzatore, 
                            FNT_DESCRIZIONE_ITA AS Ruolo, 
                            crp_livello_autorizzazione,
                            fnt_acronimo_funzionalita,
                            crp_flag_autorizzatore_princ,
				            COALESCE(UTE_AUTORIZZATORE.ute_cognome + ' ' + UTE_AUTORIZZATORE.ute_nome, UTE_AUTORIZZATORE.ute_cognome) as autorizzatore,
                            0 as priorita
                            FROM                                    
                            CENTRI_DI_COSTO INNER JOIN UTENTE ON CENTRI_DI_COSTO.cdc_id_centro_di_costo = UTENTE.cdc_id_centro_di_costo														
                            INNER JOIN CROSS_CDC_AUTORIZZATORI  ON CENTRI_DI_COSTO.cdc_id_centro_di_costo = CROSS_CDC_AUTORIZZATORI.cdc_id_centro_di_costo 
							INNER JOIN UTENTE UTE_AUTORIZZATORE ON CROSS_CDC_AUTORIZZATORI.UTE_ID_UTENTE = UTE_AUTORIZZATORE.UTE_ID_UTENTE
                            INNER JOIN funzionalita ON funzionalita.fnt_id_funzionalita = crp_livello_autorizzazione  
                            WHERE UTENTE.ute_id_utente = @idViaggiatore AND fnt_acronimo_funzionalita = 'APPLIV2'
                            */

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "idViaggiatore", DbType.Int32, idViaggiatore);
                db.LoadDataSet(dbCommand, ds, "UTENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.getTravellerAuthorizator2.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }        

        public DataSet ListViaggiatori()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"
                    SELECT TOP 10 UTENTE.UTE_ID_UTENTE,COALESCE(UTE_COGNOME + ' ' + UTE_NOME,UTE_COGNOME) AS VIAGGIATORE
                    FROM UTENTE
                    INNER JOIN RUOLI_UTENTE ON UTENTE.UTE_ID_UTENTE = RUOLI_UTENTE.UTE_ID_UTENTE
                    INNER JOIN PERMESSO_ACCESSO ON RUOLI_UTENTE.RUL_ID_RUOLO = PERMESSO_ACCESSO.RUL_ID_RUOLO
                    INNER JOIN FUNZIONALITA ON PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA = FUNZIONALITA.FNT_ID_FUNZIONALITA
                    WHERE FNT_ACRONIMO_FUNZIONALITA = 'VIA' AND PERMESSO_ACCESSO.PMS_ID_MODALITA_ACCESSO > 1 and CLI_ID_CLIENTE = @idCliente AND UTE_FLAG_ELIMINATO = 0 AND
                    RUOLI_UTENTE.URL_STATO_RUOLO_UTENTE = 1 AND UTENTE.UTE_STATO_UTENTE = 1 ");

                sb.Append(sqlWhereClause);

                sb.Append(" ORDER BY UTE_COGNOME,UTE_NOME");
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "idCliente", DbType.Int32, cli_id_cliente);
                db.LoadDataSet(dbCommand, ds, "VIAGGIATORI");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ListViaggiatori.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }
        
        //List relativa al viaggiatore per Ernst & Young
        public DataSet ListDropDownViaggiatore()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                sb.Append(@" SELECT UTENTE.UTE_ID_UTENTE,LOWER(COALESCE(UTE_COGNOME + ' ' + UTE_NOME,UTE_COGNOME)) AS UTENTE,");
                sb.Append(@" UTE_COGNOME,");
                sb.Append(@" UTE_NOME,");
                sb.Append(@" CDC_CODICE_CENTRO_DI_COSTO,");
                sb.Append(@" UTE_MATRICOLA,");
                sb.Append(@" UTE_EMAIL");
                sb.Append(@" FROM UTENTE ");
                sb.Append(@" INNER JOIN CENTRI_DI_COSTO ON UTENTE.CDC_ID_CENTRO_DI_COSTO = CENTRI_DI_COSTO.CDC_ID_CENTRO_DI_COSTO ");
                sb.Append(@SqlWhereClause);                
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);                
                db.LoadDataSet(dbCommand, ds, "UTENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ListDropDownViaggiatore.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }
        
        public void ReadByUser(string p_ute_user_id)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT UTE_ID_UTENTE,UTE_EMAIL,CLI_ID_CLIENTE FROM UTENTE
                     WHERE 
					 UTE_USER_ID = @ute_user_id 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_user_id", DbType.String, p_ute_user_id);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {                    
                    ute_id_utente = reader.GetSqlInt32(0);
                    ute_email = reader.GetSqlString(1);
                    cli_id_cliente = reader.GetSqlInt32(2);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ReadByUser.");
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
        /// Elenca tutti gli elementi con WhereClause variabile
        /// </summary>
        public static DataSet ListDropDownUtenti(string sqlWhereClause)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();


            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT DISTINCT UTENTE.UTE_ID_UTENTE,
                             COALESCE(UTE_COGNOME + ' ' + UTE_NOME, UTE_COGNOME) AS UTE_DESCRIZIONE
                             FROM UTENTE 
                             INNER JOIN RUOLI_UTENTE ON UTENTE.UTE_ID_UTENTE = RUOLI_UTENTE.UTE_ID_UTENTE
                             LEFT JOIN PERMESSO_ACCESSO ON RUOLI_UTENTE.RUL_ID_RUOLO = PERMESSO_ACCESSO.RUL_ID_RUOLO
                             LEFT JOIN FUNZIONALITA ON PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA = FUNZIONALITA.FNT_ID_FUNZIONALITA ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "UTENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ListDropDownUtenti.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public DataSet getDelegati(int idAutorizzatore, int livello)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();


            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                //sb.Append(@" SELECT AUT1.UTE_ID_UTENTE as idAutorizzatore,COALESCE(AUT1.UTE_COGNOME + ' ' + AUT1.UTE_NOME,AUT1.UTE_COGNOME) AS autorizzatore,");
                //sb.Append(@" AUT2.UTE_ID_UTENTE as idAutorizzatore2,COALESCE(AUT2.UTE_COGNOME + ' ' + AUT2.UTE_NOME,AUT2.UTE_COGNOME) AS autorizzatore2 ");
                //sb.Append(@" FROM CROSS_UTENTE_DELEGATI ");                
                //sb.Append(@" LEFT JOIN UTENTE AUT1 ON CROSS_UTENTE_DELEGATI.CUD_ID_DELEGATO1 = AUT1.UTE_ID_UTENTE  AND (GETDATE() BETWEEN CUD_DATA_INIZIO_VALIDITA1 AND CUD_DATA_FINE_VALIDITA1)");
                //sb.Append(@" LEFT JOIN UTENTE AUT2 ON CROSS_UTENTE_DELEGATI.CUD_ID_DELEGATO2 = AUT2.UTE_ID_UTENTE  AND (GETDATE() BETWEEN CUD_DATA_INIZIO_VALIDITA2 AND CUD_DATA_FINE_VALIDITA2)");
                //sb.Append(@" WHERE (CROSS_UTENTE_DELEGATI.UTE_ID_UTENTE = @idAutorizzatore OR CROSS_UTENTE_DELEGATI.UTE_ID_UTENTE = @idAutorizzatore2) ");

                sb.Append(@" SELECT ");
                sb.Append(@" UTENTE.UTE_ID_UTENTE as idAutorizzatore,");
                sb.Append(@" COALESCE(UTENTE.UTE_COGNOME + ' ' + UTENTE.UTE_NOME,UTENTE.UTE_COGNOME) AS autorizzatore");
                sb.Append(@" FROM CROSS_UTENTE_DELEGATI ");
                    
                if (livello == 1)
                    sb.Append(@" LEFT JOIN UTENTE ON CROSS_UTENTE_DELEGATI.CUD_ID_DELEGATO1 = UTENTE.UTE_ID_UTENTE  AND (GETDATE() BETWEEN CUD_DATA_INIZIO_VALIDITA1 AND CUD_DATA_FINE_VALIDITA1) AND CROSS_UTENTE_DELEGATI.UTE_ID_UTENTE = @idAutorizzatore ");                                        
                
                else
                    sb.Append(@" LEFT JOIN UTENTE ON CROSS_UTENTE_DELEGATI.CUD_ID_DELEGATO2 = UTENTE.UTE_ID_UTENTE  AND (GETDATE() BETWEEN CUD_DATA_INIZIO_VALIDITA2 AND CUD_DATA_FINE_VALIDITA2) AND CROSS_UTENTE_DELEGATI.UTE_ID_UTENTE = @idAutorizzatore ");                 
                

                sb.Append(@" WHERE UTENTE.UTE_ID_UTENTE IS NOT NULL");

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "idAutorizzatore", DbType.Int32, idAutorizzatore);                
                db.LoadDataSet(dbCommand, ds, "UTENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.getDelegati.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Verifica esistenza di un utente non eliminato con lo stesso numero matricola/user id/email.
        /// </summary>
        /// <returns></returns>
        public int existUser()
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;
            StringBuilder sb = new StringBuilder();
            int returnValue = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT ute_id_utente
                                FROM UTENTE
                                WHERE cli_id_cliente = @cli_id_cliente
                                AND ute_flag_eliminato = 0
                                AND ute_id_utente <> @ute_id_utente
                                AND (
                                    ute_matricola = @ute_matricola OR
                                    ute_user_id = @ute_user_id OR
                                    ute_email = @ute_email
                                    ) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
                db.AddInParameter(dbCommand, "ute_matricola", DbType.String, ute_matricola);
                db.AddInParameter(dbCommand, "ute_user_id", DbType.String, ute_user_id);
                db.AddInParameter(dbCommand, "ute_email", DbType.String, ute_email);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    returnValue = reader.GetInt32(0);
                }                
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.existUser.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }

            return returnValue;
        }

        public DataSet getElencoOperatori()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"
                    SELECT UTENTE.UTE_ID_UTENTE as [key],COALESCE(UTE_COGNOME + ' ' + UTE_NOME,UTE_COGNOME) AS value
                    FROM UTENTE
                    INNER JOIN RUOLI_UTENTE ON UTENTE.UTE_ID_UTENTE = RUOLI_UTENTE.UTE_ID_UTENTE
                    INNER JOIN PERMESSO_ACCESSO ON RUOLI_UTENTE.RUL_ID_RUOLO = PERMESSO_ACCESSO.RUL_ID_RUOLO
                    INNER JOIN FUNZIONALITA ON PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA = FUNZIONALITA.FNT_ID_FUNZIONALITA
                    INNER JOIN CROSS_UTENTE_CLIENTE ON UTENTE.UTE_ID_UTENTE = CROSS_UTENTE_CLIENTE.UTE_ID_UTENTE AND CUC_FLAG_STATO = 1
                    WHERE FNT_ACRONIMO_FUNZIONALITA = 'OPE' AND PERMESSO_ACCESSO.PMS_ID_MODALITA_ACCESSO > 1 AND UTE_FLAG_ELIMINATO = 0 AND
                    RUOLI_UTENTE.URL_STATO_RUOLO_UTENTE = 1 AND UTENTE.UTE_STATO_UTENTE = 1 AND UTENTE.UTE_ID_UTENTE <> 1 "); // Tutti gli utenti operatori tranne admin
 
                sb.Append(sqlWhereClause);

                sb.Append(" ORDER BY UTE_COGNOME,UTE_NOME");
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "OPERATORI");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ListViaggiatori.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }
        #endregion

        #region Caricamento Utenti

        /// <summary>
        /// Insert record nella tabella UTENTI_IMPORT.
        /// La struttura della tabella deve essere allineata su tutti i DB di Missyo.
        /// </summary>
        /// <param name="dtXls">Data Table con i dati del file xls</param>
        public void CreateByXls(DataTable dtXls)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                // Svuoto la tabella temporanea degli utenti importati
                sqlCommand = "DELETE FROM UTENTI_IMPORT WHERE CLI_ID_CLIENTE = " + cli_id_cliente;
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.ExecuteNonQuery(dbCommand);

                foreach (DataRow dr in dtXls.Rows)
                {
                    sqlCommand = @" INSERT INTO UTENTI_IMPORT 
                                        ([nome]
                                        ,[cognome]
                                        ,[email]
                                        ,[societa]
                                        ,[coddip]
                                        ,[centro_di_costo]
                                        ,[e_mail_autorizzatore]
                                        ,[e_mail_responsabile]
                                        ,[data_cessazione]
                                        ,[CLI_ID_CLIENTE]
                                        ,autorizzatore
                                        ,responsabile
                                        ,username
                                        ,telefono)
				                    VALUES(
					                    @ute_nome,
                                        @ute_cognome,
                                        @ute_email,
                                        @ute_societa,
                                        @coddip,
                                        @ute_centro_di_costo,
                                        @ute_mail_autorizzatore1,
                                        @ute_mail_autorizzatore2,
                                        @data_cessazione,
                                        @cli_id_cliente,
                                        @autorizzatore,
                                        @responsabile,
                                        @username,
                                        @telefono
                                        )";

                    dbCommand = db.GetSqlStringCommand(sqlCommand);

                    // Funzione utilizzata da tutti i progetti di Missyo.
                    // Per ogni singola colonna deve essere verificata l'esistenza.

                    db.AddInParameter(dbCommand, "ute_nome", DbType.String, dtXls.Columns.Contains("nome") ? dr["nome"].ToString() : null);
                    db.AddInParameter(dbCommand, "ute_cognome", DbType.String, dtXls.Columns.Contains("cognome") ? dr["cognome"].ToString() : null);
                    db.AddInParameter(dbCommand, "ute_email", DbType.String, dtXls.Columns.Contains("email") ? dr["email"].ToString() : null);
                    db.AddInParameter(dbCommand, "ute_societa", DbType.String, dtXls.Columns.Contains("societa") ? dr["societa"].ToString() : null);
                    db.AddInParameter(dbCommand, "coddip", DbType.String, dtXls.Columns.Contains("codice") ? dr["codice"].ToString() : null);
                    db.AddInParameter(dbCommand, "ute_centro_di_costo", DbType.String, dtXls.Columns.Contains("cdc") ? dr["cdc"].ToString() : null);
                    db.AddInParameter(dbCommand, "ute_mail_autorizzatore1", DbType.String, dtXls.Columns.Contains("email_autorizzatore") ? dr["email_autorizzatore"].ToString() : null); // modificare xls ZARA
                    db.AddInParameter(dbCommand, "ute_mail_autorizzatore2", DbType.String, dtXls.Columns.Contains("email_responsabile") ? dr["email_responsabile"].ToString() : null); // modificare xls ZARA
                    db.AddInParameter(dbCommand, "data_cessazione", DbType.String, dtXls.Columns.Contains("data_cessazione") ? dr["data_cessazione"].ToString() : null);
                    db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);

                    db.AddInParameter(dbCommand, "autorizzatore", DbType.String, dtXls.Columns.Contains("autorizzatore") ? dr["autorizzatore"].ToString() : null);
                    db.AddInParameter(dbCommand, "responsabile", DbType.String, dtXls.Columns.Contains("responsabile") ? dr["responsabile"].ToString() : null);
                    db.AddInParameter(dbCommand, "username", DbType.String, dtXls.Columns.Contains("username") ? dr["username"].ToString() : null);
                    db.AddInParameter(dbCommand, "telefono", DbType.String, dtXls.Columns.Contains("telefono") ? dr["telefono"].ToString() : null);

                    dbCommand.CommandTimeout = 3000;
                    db.ExecuteNonQuery(dbCommand);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.CreateByXls.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            finally
            {
                if (dataReader != null)
                    ((IDisposable)dataReader).Dispose();
            }
        }

        /// <summary>
        /// Chiamata alla stored proceudre "spUpload_Utenti" che effettua:
        /// - check dei dati (tipo azione = CHECK)
        /// - consolidamento dei dati (tipo azione = JOB)
        /// </summary>
        /// <param name="idUtente">Id utente che sta effettuando il caricamento</param>
        public void spUpload_Utenti(int idUtente)
        {
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                dbCommand = db.GetStoredProcCommand("spUpload_Utenti");
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, Cli_id_cliente);
                db.AddInParameter(dbCommand, "tipo_azione", DbType.String, "CHECK");
                db.AddInParameter(dbCommand, "ute_id_utente_import", DbType.Int32, idUtente);
                db.AddOutParameter(dbCommand, "strReturn", DbType.String, 2000);
                db.ExecuteNonQuery(dbCommand);

                strReturn = db.GetParameterValue(dbCommand, "@strReturn").ToString();
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.spUpload_Utenti");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                //return 99;//Errore generico
            }
        }

        /// <summary>
        /// Restituisce l'elenco di errori tracciati nel log durante il caricamento del file excel
        /// </summary>
        /// <param name="p_ute_id_utente">Id utente che sta effettuando il caricamento</param>
        /// <returns></returns>
        public DataSet ListError(int p_ute_id_utente)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
                                COGNOME, NOME, ERRORE
                                FROM UTENTI_IMPORT_LOG
                                WHERE UTE_ID_UTENTE = @ute_id_utente 
                                ORDER BY COGNOME, NOME ");

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, p_ute_id_utente);
                db.LoadDataSet(dbCommand, ds, "UTENTI_IMPORT_LOG");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ListError.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        #endregion
    }
}


