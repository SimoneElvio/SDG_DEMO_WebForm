#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Sistema.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per SISTEMA
//
// Autore:      AR - SDG srl
// Data:        07/07/2008
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using SDG.Utility;
using System.Configuration;
using System.Net.Mail;
using SDG.ExceptionHandling;

namespace SDG.GestioneUtenti
{
	/// <summary>
	/// Tabella SISTEMA 
	/// </summary>
	public class Sistema
	{
		#region attributi e variabili

	    private SqlInt32 sis_min_password_length = SqlInt32.Null;
	    private SqlInt32 sis_max_password_length = SqlInt32.Null;
	    private SqlInt32 sis_flag_pwd_maiuscole = SqlInt32.Null;
	    private SqlInt32 sis_flag_pwd_minuscole = SqlInt32.Null;
	    private SqlInt32 sis_flag_pwd_numeri = SqlInt32.Null;
	    private SqlInt32 sis_flag_pwd_caratteri_speciali = SqlInt32.Null;
	    private SqlString sis_pwd_set_caratteri_speciali = SqlString.Null;
	    private SqlInt32 sis_max_password_consecutive = SqlInt32.Null;
	    private SqlInt32 sis_max_tentativi_password = SqlInt32.Null;
	    private SqlInt32 sis_durata_password = SqlInt32.Null;
	    private SqlInt32 sis_flag_pwd_cambia = SqlInt32.Null;
	    private SqlInt32 sis_flag_pwd_cambia_primo_accesso = SqlInt32.Null;
	    private SqlInt32 naz_id_nazione = SqlInt32.Null;
	    private SqlInt32 sis_flag_gestione_cookies = SqlInt32.Null;
	    private SqlInt32 sis_flag_visualizza_info_page = SqlInt32.Null;
        private SqlInt32 sis_flag_autenticazione_remota = SqlInt32.Null;
        private SqlString sis_link_rss_scioperi = SqlString.Null;
        private SqlString sis_link_rss_news = SqlString.Null;
        private SqlDecimal sis_percentuale_lowcost = SqlDecimal.Null;
        private SqlString sis_email_ufficio_viaggi = SqlString.Null;
        private SqlString sis_email_ufficio_viaggi_abc = SqlString.Null;
        private SqlString sis_link_applicazione = SqlString.Null;
		
		private string sqlWhereClause = "";
		private DataSet sistemaListDS;

		#endregion

		#region Proprieta
		

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_min_password_length
		{
			get { return  sis_min_password_length; }
			set { sis_min_password_length = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_max_password_length
		{
			get { return  sis_max_password_length; }
			set { sis_max_password_length = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_flag_pwd_maiuscole
		{
			get { return  sis_flag_pwd_maiuscole; }
			set { sis_flag_pwd_maiuscole = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_flag_pwd_minuscole
		{
			get { return  sis_flag_pwd_minuscole; }
			set { sis_flag_pwd_minuscole = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_flag_pwd_numeri
		{
			get { return  sis_flag_pwd_numeri; }
			set { sis_flag_pwd_numeri = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_flag_pwd_caratteri_speciali
		{
			get { return  sis_flag_pwd_caratteri_speciali; }
			set { sis_flag_pwd_caratteri_speciali = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Sis_pwd_set_caratteri_speciali
		{
			get { return  sis_pwd_set_caratteri_speciali; }
			set { sis_pwd_set_caratteri_speciali = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_max_password_consecutive
		{
			get { return  sis_max_password_consecutive; }
			set { sis_max_password_consecutive = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_max_tentativi_password
		{
			get { return  sis_max_tentativi_password; }
			set { sis_max_tentativi_password = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_durata_password
		{
			get { return  sis_durata_password; }
			set { sis_durata_password = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_flag_pwd_cambia
		{
			get { return  sis_flag_pwd_cambia; }
			set { sis_flag_pwd_cambia = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_flag_pwd_cambia_primo_accesso
		{
			get { return  sis_flag_pwd_cambia_primo_accesso; }
			set { sis_flag_pwd_cambia_primo_accesso = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Naz_id_nazione
		{
			get { return  naz_id_nazione; }
			set { naz_id_nazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_flag_gestione_cookies
		{
			get { return  sis_flag_gestione_cookies; }
			set { sis_flag_gestione_cookies = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_flag_visualizza_info_page
		{
			get { return  sis_flag_visualizza_info_page; }
			set { sis_flag_visualizza_info_page = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Sis_flag_autenticazione_remota
		{
			get { return  sis_flag_autenticazione_remota; }
			set { sis_flag_autenticazione_remota = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlString Sis_link_rss_scioperi
        {
            get { return sis_link_rss_scioperi; }
            set { sis_link_rss_scioperi = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Sis_link_rss_news
        {
            get { return sis_link_rss_news; }
            set { sis_link_rss_news = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Sis_email_ufficio_viaggi
        {
            get { return sis_email_ufficio_viaggi; }
            set { sis_email_ufficio_viaggi = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Sis_email_ufficio_viaggi_abc
        {
            get { return sis_email_ufficio_viaggi_abc; }
            set { sis_email_ufficio_viaggi_abc = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Sis_link_applicazione
        {
            get { return sis_link_applicazione; }
            set { sis_link_applicazione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlDecimal Sis_percentuale_lowcost
        {
            get { return sis_percentuale_lowcost; }
            set { sis_percentuale_lowcost = value; }
        }

		/// <value>
		/// Where Clause condition
		/// </value>
		public  string SqlWhereClause
		{
			get { return  sqlWhereClause; }
			set { sqlWhereClause = value; }
		}

		/// <value>
		/// Elenco degli elementi Sistema selezionati
		/// </value>
		public DataSet SistemaListDS
		{
			get { return  sistemaListDS; }
			set { sistemaListDS = value; }
		}

		#endregion
		
		#region  Costruttori

		/// <summary>
		/// Costruttore standard
		/// </summary>
		public Sistema()
		{
			sistemaListDS = new DataSet();
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
					 SISTEMA.SIS_MIN_PASSWORD_LENGTH, 
					 SISTEMA.SIS_MAX_PASSWORD_LENGTH, 
					 SISTEMA.SIS_FLAG_PWD_MAIUSCOLE, 
					 SISTEMA.SIS_FLAG_PWD_MINUSCOLE, 
					 SISTEMA.SIS_FLAG_PWD_NUMERI, 
					 SISTEMA.SIS_FLAG_PWD_CARATTERI_SPECIALI, 
					 SISTEMA.SIS_PWD_SET_CARATTERI_SPECIALI, 
					 SISTEMA.SIS_MAX_PASSWORD_CONSECUTIVE, 
					 SISTEMA.SIS_MAX_TENTATIVI_PASSWORD, 
					 SISTEMA.SIS_DURATA_PASSWORD, 
					 SISTEMA.SIS_FLAG_PWD_CAMBIA, 
					 SISTEMA.SIS_FLAG_PWD_CAMBIA_PRIMO_ACCESSO, 
					 SISTEMA.NAZ_ID_NAZIONE, 
					 SISTEMA.SIS_FLAG_GESTIONE_COOKIES, 
					 SISTEMA.SIS_FLAG_VISUALIZZA_INFO_PAGE, 
					 SISTEMA.SIS_FLAG_AUTENTICAZIONE_REMOTA	, 
					 SISTEMA.SIS_LINK_RSS_SCIOPERI, 
					 SISTEMA.SIS_LINK_RSS_NEWS,	  
                     SISTEMA.SIS_PERCENTUALE_LOWCOST,
                     SISTEMA.SIS_EMAIL_UFFICIO_VIAGGI,
                     SISTEMA.SIS_EMAIL_UFFICIO_VIAGGI_ABC,
                     SISTEMA.SIS_LINK_APPLICAZIONE                     
				 	 FROM SISTEMA 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            

				// reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read()) 
				{
					sis_min_password_length = reader.GetSqlInt32(0);
					sis_max_password_length = reader.GetSqlInt32(1);
					sis_flag_pwd_maiuscole = reader.GetSqlInt32(2);
					sis_flag_pwd_minuscole = reader.GetSqlInt32(3);
					sis_flag_pwd_numeri = reader.GetSqlInt32(4);
					sis_flag_pwd_caratteri_speciali = reader.GetSqlInt32(5);
					sis_pwd_set_caratteri_speciali = reader.GetSqlString(6);
					sis_max_password_consecutive = reader.GetSqlInt32(7);
					sis_max_tentativi_password = reader.GetSqlInt32(8);
					sis_durata_password = reader.GetSqlInt32(9);
					sis_flag_pwd_cambia = reader.GetSqlInt32(10);
					sis_flag_pwd_cambia_primo_accesso = reader.GetSqlInt32(11);
					naz_id_nazione = reader.GetSqlInt32(12);
					sis_flag_gestione_cookies = reader.GetSqlInt32(13);
					sis_flag_visualizza_info_page = reader.GetSqlInt32(14);
                    sis_flag_autenticazione_remota = reader.GetSqlInt32(15);
                    sis_link_rss_scioperi = reader.GetSqlString(16);
                    sis_link_rss_news = reader.GetSqlString(17);
                    sis_percentuale_lowcost = reader.GetSqlDecimal(18);
                    sis_email_ufficio_viaggi = reader.GetSqlString(19);
                    sis_email_ufficio_viaggi_abc = reader.GetSqlString(20);
                    sis_link_applicazione = reader.GetSqlString(21);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "Sistema.Read.");
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

				sqlCommand = @" UPDATE SISTEMA SET 
					 SIS_MIN_PASSWORD_LENGTH = @sis_min_password_length, 
					 SIS_MAX_PASSWORD_LENGTH = @sis_max_password_length, 
					 SIS_FLAG_PWD_MAIUSCOLE = @sis_flag_pwd_maiuscole, 
					 SIS_FLAG_PWD_MINUSCOLE = @sis_flag_pwd_minuscole, 
					 SIS_FLAG_PWD_NUMERI = @sis_flag_pwd_numeri, 
					 SIS_FLAG_PWD_CARATTERI_SPECIALI = @sis_flag_pwd_caratteri_speciali, 
					 SIS_PWD_SET_CARATTERI_SPECIALI = @sis_pwd_set_caratteri_speciali, 
					 SIS_MAX_PASSWORD_CONSECUTIVE = @sis_max_password_consecutive, 
					 SIS_MAX_TENTATIVI_PASSWORD = @sis_max_tentativi_password, 
					 SIS_DURATA_PASSWORD = @sis_durata_password, 
					 SIS_FLAG_PWD_CAMBIA = @sis_flag_pwd_cambia, 
					 SIS_FLAG_PWD_CAMBIA_PRIMO_ACCESSO = @sis_flag_pwd_cambia_primo_accesso, 
					 NAZ_ID_NAZIONE = @naz_id_nazione, 
					 SIS_FLAG_GESTIONE_COOKIES = @sis_flag_gestione_cookies, 
					 SIS_FLAG_VISUALIZZA_INFO_PAGE = @sis_flag_visualizza_info_page, 
					 SIS_FLAG_AUTENTICAZIONE_REMOTA = @sis_flag_autenticazione_remota , 
					 SIS_LINK_RSS_SCIOPERI = @sis_link_rss_scioperi, 
					 SIS_LINK_RSS_NEWS = @sis_link_rss_news,
                     SIS_PERCENTUALE_LOWCOST = @sis_percentuale_lowcost,
                     SIS_EMAIL_UFFICIO_VIAGGI = @sis_email_ufficio_viaggi,
                     SIS_EMAIL_UFFICIO_VIAGGI_ABC = @sis_email_ufficio_viaggi_abc,   
                     SIS_LINK_APPLICAZIONE = @sis_link_applicazione
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "sis_min_password_length", DbType.Int32, sis_min_password_length);
				db.AddInParameter(dbCommand, "sis_max_password_length", DbType.Int32, sis_max_password_length);
				db.AddInParameter(dbCommand, "sis_flag_pwd_maiuscole", DbType.Int32, sis_flag_pwd_maiuscole);
				db.AddInParameter(dbCommand, "sis_flag_pwd_minuscole", DbType.Int32, sis_flag_pwd_minuscole);
				db.AddInParameter(dbCommand, "sis_flag_pwd_numeri", DbType.Int32, sis_flag_pwd_numeri);
				db.AddInParameter(dbCommand, "sis_flag_pwd_caratteri_speciali", DbType.Int32, sis_flag_pwd_caratteri_speciali);
				db.AddInParameter(dbCommand, "sis_pwd_set_caratteri_speciali", DbType.String, sis_pwd_set_caratteri_speciali);
				db.AddInParameter(dbCommand, "sis_max_password_consecutive", DbType.Int32, sis_max_password_consecutive);
				db.AddInParameter(dbCommand, "sis_max_tentativi_password", DbType.Int32, sis_max_tentativi_password);
				db.AddInParameter(dbCommand, "sis_durata_password", DbType.Int32, sis_durata_password);
				db.AddInParameter(dbCommand, "sis_flag_pwd_cambia", DbType.Int32, sis_flag_pwd_cambia);
				db.AddInParameter(dbCommand, "sis_flag_pwd_cambia_primo_accesso", DbType.Int32, sis_flag_pwd_cambia_primo_accesso);
				db.AddInParameter(dbCommand, "naz_id_nazione", DbType.Int32, naz_id_nazione);
				db.AddInParameter(dbCommand, "sis_flag_gestione_cookies", DbType.Int32, sis_flag_gestione_cookies);
				db.AddInParameter(dbCommand, "sis_flag_visualizza_info_page", DbType.Int32, sis_flag_visualizza_info_page);
				db.AddInParameter(dbCommand, "sis_flag_autenticazione_remota", DbType.Int32, sis_flag_autenticazione_remota);
                db.AddInParameter(dbCommand, "sis_link_rss_scioperi", DbType.String, sis_link_rss_scioperi);
                db.AddInParameter(dbCommand, "sis_link_rss_news", DbType.String, sis_link_rss_news);
                db.AddInParameter(dbCommand, "sis_percentuale_lowcost", DbType.Decimal, sis_percentuale_lowcost);
                db.AddInParameter(dbCommand, "sis_email_ufficio_viaggi", DbType.String, sis_email_ufficio_viaggi);
                db.AddInParameter(dbCommand, "sis_email_ufficio_viaggi_abc", DbType.String, sis_email_ufficio_viaggi_abc);
                db.AddInParameter(dbCommand, "sis_link_applicazione", DbType.String, sis_link_applicazione);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Sistema.Update.");
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

				sqlCommand = @" DELETE FROM SISTEMA 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Sistema.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}
		
		/// <summary>
		/// Crea l'oggetto corrispondente nella base dati.
		/// </summary>
		public void Create() 
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
	
				sqlCommand = @" INSERT INTO SISTEMA (
						SIS_MIN_PASSWORD_LENGTH, 
						SIS_MAX_PASSWORD_LENGTH, 
						SIS_FLAG_PWD_MAIUSCOLE, 
						SIS_FLAG_PWD_MINUSCOLE, 
						SIS_FLAG_PWD_NUMERI, 
						SIS_FLAG_PWD_CARATTERI_SPECIALI, 
						SIS_PWD_SET_CARATTERI_SPECIALI, 
						SIS_MAX_PASSWORD_CONSECUTIVE, 
						SIS_MAX_TENTATIVI_PASSWORD, 
						SIS_DURATA_PASSWORD, 
						SIS_FLAG_PWD_CAMBIA, 
						SIS_FLAG_PWD_CAMBIA_PRIMO_ACCESSO, 
						NAZ_ID_NAZIONE, 
						SIS_FLAG_GESTIONE_COOKIES, 
						SIS_FLAG_VISUALIZZA_INFO_PAGE, 
						SIS_FLAG_AUTENTICAZIONE_REMOTA, 
						SIS_LINK_RSS_SCIOPERI, 
						SIS_LINK_RSS_NEWS,SIS_PERCENTUALE_LOWCOST,SIS_EMAIL_UFFICIO_VIAGGI,SIS_LINK_APPLICAZIONE,SIS_EMAIL_UFFICIO_VIAGGI_ABC	 ) 
					VALUES ( 
						@sis_min_password_length, 
						@sis_max_password_length, 
						@sis_flag_pwd_maiuscole, 
						@sis_flag_pwd_minuscole, 
						@sis_flag_pwd_numeri, 
						@sis_flag_pwd_caratteri_speciali, 
						@sis_pwd_set_caratteri_speciali, 
						@sis_max_password_consecutive, 
						@sis_max_tentativi_password, 
						@sis_durata_password, 
						@sis_flag_pwd_cambia, 
						@sis_flag_pwd_cambia_primo_accesso, 
						@naz_id_nazione, 
						@sis_flag_gestione_cookies, 
						@sis_flag_visualizza_info_page, 
						@sis_flag_autenticazione_remota, 
						@sis_link_rss_scioperi, 
						@sis_link_rss_news,@sis_percentuale_lowcost,@sis_email_ufficio_viaggi,@sis_link_applicazione,@sis_email_ufficio_viaggi_abc	 ) 

				";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "sis_min_password_length", DbType.Int32, sis_min_password_length);
				db.AddInParameter(dbCommand, "sis_max_password_length", DbType.Int32, sis_max_password_length);
				db.AddInParameter(dbCommand, "sis_flag_pwd_maiuscole", DbType.Int32, sis_flag_pwd_maiuscole);
				db.AddInParameter(dbCommand, "sis_flag_pwd_minuscole", DbType.Int32, sis_flag_pwd_minuscole);
				db.AddInParameter(dbCommand, "sis_flag_pwd_numeri", DbType.Int32, sis_flag_pwd_numeri);
				db.AddInParameter(dbCommand, "sis_flag_pwd_caratteri_speciali", DbType.Int32, sis_flag_pwd_caratteri_speciali);
				db.AddInParameter(dbCommand, "sis_pwd_set_caratteri_speciali", DbType.String, sis_pwd_set_caratteri_speciali);
				db.AddInParameter(dbCommand, "sis_max_password_consecutive", DbType.Int32, sis_max_password_consecutive);
				db.AddInParameter(dbCommand, "sis_max_tentativi_password", DbType.Int32, sis_max_tentativi_password);
				db.AddInParameter(dbCommand, "sis_durata_password", DbType.Int32, sis_durata_password);
				db.AddInParameter(dbCommand, "sis_flag_pwd_cambia", DbType.Int32, sis_flag_pwd_cambia);
				db.AddInParameter(dbCommand, "sis_flag_pwd_cambia_primo_accesso", DbType.Int32, sis_flag_pwd_cambia_primo_accesso);
				db.AddInParameter(dbCommand, "naz_id_nazione", DbType.Int32, naz_id_nazione);
				db.AddInParameter(dbCommand, "sis_flag_gestione_cookies", DbType.Int32, sis_flag_gestione_cookies);
				db.AddInParameter(dbCommand, "sis_flag_visualizza_info_page", DbType.Int32, sis_flag_visualizza_info_page);
				db.AddInParameter(dbCommand, "sis_flag_autenticazione_remota", DbType.Int32, sis_flag_autenticazione_remota);
                db.AddInParameter(dbCommand, "sis_link_rss_scioperi", DbType.String, sis_link_rss_scioperi);
                db.AddInParameter(dbCommand, "sis_link_rss_news", DbType.String, sis_link_rss_news);
                db.AddInParameter(dbCommand, "sis_percentuale_lowcost", DbType.Decimal, sis_percentuale_lowcost);
                db.AddInParameter(dbCommand, "sis_email_ufficio_viaggi", DbType.String, sis_email_ufficio_viaggi);
                db.AddInParameter(dbCommand, "sis_email_ufficio_viaggi_abc", DbType.String, sis_email_ufficio_viaggi_abc);
                db.AddInParameter(dbCommand, "sis_link_applicazione", DbType.String, sis_link_applicazione);

				db.ExecuteNonQuery(dbCommand);

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "Sistema.Create.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}
		
		/// <summary>
        /// Elenca tutti gli elementi Piano_di_mitigazione dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "SISTEMA");
        }
		/// <summary>
		/// Elenca tutti gli elementi Sistema dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"SISTEMA");
		}
		/// <summary>
		/// Elenca tutti gli elementi Sistema dell'analisi. L'utente può scegliere il nome della tabella nel dataset
		/// </summary>
		public static DataSet List(string sqlWhereClause, string tableName) 
		{
			string sqlCommand = null;
			StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
            DataSet ds = new DataSet();
			
			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            
				sb.Append(@" SELECT 
					SISTEMA.SIS_MIN_PASSWORD_LENGTH, 
					SISTEMA.SIS_MAX_PASSWORD_LENGTH, 
					SISTEMA.SIS_FLAG_PWD_MAIUSCOLE, 
					SISTEMA.SIS_FLAG_PWD_MINUSCOLE, 
					SISTEMA.SIS_FLAG_PWD_NUMERI, 
					SISTEMA.SIS_FLAG_PWD_CARATTERI_SPECIALI, 
					SISTEMA.SIS_PWD_SET_CARATTERI_SPECIALI, 
					SISTEMA.SIS_MAX_PASSWORD_CONSECUTIVE, 
					SISTEMA.SIS_MAX_TENTATIVI_PASSWORD, 
					SISTEMA.SIS_DURATA_PASSWORD, 
					SISTEMA.SIS_FLAG_PWD_CAMBIA, 
					SISTEMA.SIS_FLAG_PWD_CAMBIA_PRIMO_ACCESSO, 
					SISTEMA.NAZ_ID_NAZIONE, 
					SISTEMA.SIS_FLAG_GESTIONE_COOKIES, 
					SISTEMA.SIS_FLAG_VISUALIZZA_INFO_PAGE, 
					SISTEMA.SIS_FLAG_AUTENTICAZIONE_REMOTA, 
					SISTEMA.SIS_LINK_RSS_SCIOPERI, 
					SISTEMA.SIS_LINK_RSS_NEWS,  
                    SISTEMA.SIS_PERCENTUALE_LOWCOST,
                    SISTEMA.SIS_EMAIL_UFFICIO_VIAGGI,
                    SISTEMA.SIS_EMAIL_UFFICIO_VIAGGI_ABC,
                    SISTEMA.SIS_LINK_APPLICAZIONE  
				FROM SISTEMA ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, "SISTEMA");
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Sistema.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

        public bool checkIsTickets()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            SqlDataReader reader = null;
            DbCommand dbCommand = null;
            bool returnValue = false;


            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT SIS_LINK_RSS_SCIOPERI FROM SISTEMA WHERE SIS_LINK_RSS_SCIOPERI IS NULL OR SIS_LINK_RSS_SCIOPERI='' ");

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                //while (reader.Read())
                //{
                //    returnValue = true;
                //}

                if (reader.HasRows)
                    returnValue = true;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Sistema.checkIsTickets.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                returnValue = false;
            }

            return returnValue;

        }



        public static string FormattaEmailPwd(string msg)
        {
            string strBody = string.Empty;
            string pathLogin = ConfigurationManager.AppSettings["pathLogin"];

            strBody = "<style type='text/css'>";
            strBody += "body{font-family:verdana,arial;background-color:#fff;font-size:12px;color:#000}";
            strBody += "div{display:block;width:700px;height:30px;border:1px solid #c0c0c0;padding:6px;}";
            strBody += "span{font-size:10px;float:right}";
            strBody += "p{font-size:11px;text-align:left;margin-left:3px}";
            strBody += "a, a:hover, a:visited{color:#CC0000;font-weight:bold}";
            strBody += "</style>";
            strBody += "<body>";
            strBody += "<div style='background-color:#fff;border:1px solid #c0c0c0;margin:auto'>";
            strBody += "<div style='text-align:center'><img src='http://tickets.sdgitaly.it/Web/Images/hrgtop.jpg'></img></div>";
            strBody += "<p style='text-align:center;font-style:italic'><u>ATTENZIONE:</u> Questo messaggio di notifica &egrave; generato automaticamente dal sistema , si invita a non rispondere.</p>";
            if (msg != "")
                strBody += msg;
            strBody += "<p>Distinti saluti,<br />SDG Srl</p>";
            strBody += "<div style='text-align:right;font-size:10px'>SDG 2013</div>";
            strBody += "</div></body>";

            return strBody;
        }

        /// <summary>
        /// configurazione invio mail
        /// </summary>
        /// <param name="email"></param>
        public static void SendEmail(MailMessage email)
        {
            BusinessObjects.ConfigurationSetting objConfigurationSetting = new BusinessObjects.ConfigurationSetting();
            string SmtpServer = objConfigurationSetting.getValue("SmtpServer");

            try
            {
                SmtpClient Smtp = new SmtpClient();
                Smtp.Host = SmtpServer;
                // Add credentials if the SMTP server requires them.
                Smtp.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                Smtp.Send(email);
                // Clean up.
                email.Dispose();
            }
            catch (Exception ex)
            {
                if (email != null)
                    ((IDisposable)email).Dispose();

                ex.Data.Add("Class.Method", "Sistema.SendEmail.");
                ExceptionPolicy.HandleException(ex, "Propagate Policy");
            }
        }

		#endregion

	}
}
