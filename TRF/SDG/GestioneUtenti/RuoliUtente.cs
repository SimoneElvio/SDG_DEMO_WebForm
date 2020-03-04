#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   RuoliUtente.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per RUOLI_UTENTE
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
using System.Data.SqlTypes;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SDG.ExceptionHandling;
using System.Text;

namespace SDG.GestioneUtenti
{
	/// <summary>
	/// Tabella RUOLI_UTENTE 
	/// </summary>
	public class RuoliUtente
	{
		#region attributi e variabili

	    private  SqlInt32 ute_id_utente = SqlInt32.Null;
        private SqlInt32 url_id_ruoli_utente = SqlInt32.Null;
        private SqlInt32 ute_id_utente_aggiornato = SqlInt32.Null;
        private SqlInt32 ute_id_utente_creato = SqlInt32.Null;
	    private  SqlInt32 rul_id_ruolo = SqlInt32.Null;
        //Nota SGA: per ora messo sempre a True perchè il valore non è gestito in pagina
	    private  SqlBoolean url_stato_ruolo_utente = SqlBoolean.True;
	    private  SqlDateTime url_data_assegnazione = SqlDateTime.Null;
        private SqlDateTime url_data_disabilitazione = SqlDateTime.Null;
		

		private string sqlWhereClause = "";
		private DataSet ruoli_utenteListDS;

		// ---------------------------------------------------------------------
		// Costanti per facilitare il mapping con le colonne
		// Devono essere nello stesso ordine dei campi della tabella 
		// corrispondente
		// ---------------------------------------------------------------------		

	     private const int UTE_ID_UTENTE = 0;
	     private const int RUL_ID_RUOLO = 1;
	     private const int URL_STATO_RUOLO_UTENTE = 2;
	     private const int URL_DATA_ASSEGNAZIONE = 3;
         private const int URL_ID_RUOLI_UTENTE = 4;

		#endregion

		#region Proprieta
		

		/// <value>
		/// Identificatore dell'utente che viene replicato in tutte le tabelle.
		/// </value>
		public  SqlInt32 Ute_id_utente
		{
			get { return  ute_id_utente; }
			set { ute_id_utente = value; }
		}

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Url_id_ruoli_utente
        {
            get { return url_id_ruoli_utente; }
            set { url_id_ruoli_utente = value; }
        }
        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Ute_id_utente_aggiornato
        {
            get { return ute_id_utente_aggiornato; }
            set { ute_id_utente_aggiornato = value; }
        }

        /// <value>
        /// Identificatore dell'utente che viene replicato in tutte le tabelle.
        /// </value>
        public SqlInt32 Ute_id_utente_creato
        {
            get { return ute_id_utente_creato; }
            set { ute_id_utente_creato = value; }
        }

		/// <value>
		/// ID Profilo
		/// </value>
		public  SqlInt32 Rul_id_ruolo
		{
			get { return  rul_id_ruolo; }
			set { rul_id_ruolo = value; }
		}

		/// <value>
		/// Stato del Profilo dell'utente. (1 assegnato, 0 non Assegnato)
		/// </value>
		public  SqlBoolean Url_stato_ruolo_utente
		{
			get { return  url_stato_ruolo_utente; }
			set { url_stato_ruolo_utente = value; }
		}

		/// <value>
		/// Data di assegnazione del profilo all'utente
		/// </value>
		public  SqlDateTime Url_data_assegnazione
		{
			get { return  url_data_assegnazione; }
			set { url_data_assegnazione = value; }
		}

        /// <value>
        /// Data di assegnazione del profilo all'utente
        /// </value>
        public SqlDateTime Url_data_disabilitazione
        {
            get { return url_data_disabilitazione; }
            set { url_data_disabilitazione = value; }
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
		/// Elenco degli elementi RuoliUtente selezionati
		/// </value>
		public DataSet Ruoli_utenteListDS
		{
			get { return  ruoli_utenteListDS; }
			set { ruoli_utenteListDS = value; }
		}

		#endregion
		
		#region  Costruttori

		/// <summary>
		/// Costruttore standard
		/// </summary>
		public RuoliUtente()
		{
			ruoli_utenteListDS = new DataSet();
		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read()
		{
			IDataReader reader = null;
			string sqlCommand = null;
            DbCommand dbCommand = null;

			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT
                     RUOLI_UTENTE.UTE_ID_UTENTE,
                     RUOLI_UTENTE.RUL_ID_RUOLO,
                     RUOLI_UTENTE.URL_STATO_RUOLO_UTENTE,
                     RUOLI_UTENTE.URL_DATA_ASSEGNAZIONE,
                     RUOLI_UTENTE.URL_ID_RUOLI_UTENTE
                     FROM RUOLI_UTENTE WHERE
                     URL_ID_RUOLI_UTENTE = @url_id_ruoli_utente ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "url_id_ruoli_utente", DbType.Int32, url_id_ruoli_utente);	                

				reader = db.ExecuteReader(dbCommand);

				while (reader.Read()) 
				{
					ute_id_utente = (reader.IsDBNull(UTE_ID_UTENTE)) ? (SqlInt32.Null) : (reader.GetInt32(UTE_ID_UTENTE));
					rul_id_ruolo = (reader.IsDBNull(RUL_ID_RUOLO)) ? (SqlInt32.Null) : (reader.GetInt32(RUL_ID_RUOLO));
					url_stato_ruolo_utente = (reader.IsDBNull(URL_STATO_RUOLO_UTENTE)) ? (SqlBoolean.Null) : (reader.GetBoolean(URL_STATO_RUOLO_UTENTE));
					url_data_assegnazione = (reader.IsDBNull(URL_DATA_ASSEGNAZIONE)) ? (SqlDateTime.Null) : (reader.GetDateTime(URL_DATA_ASSEGNAZIONE));
                    url_id_ruoli_utente = (reader.IsDBNull(URL_ID_RUOLI_UTENTE)) ? (SqlInt32.Null) : (reader.GetInt32(URL_ID_RUOLI_UTENTE));
				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "RuoliUtente.Read.");
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

                sqlCommand = @" UPDATE RUOLI_UTENTE SET
			 		URL_STATO_RUOLO_UTENTE = @url_stato_ruolo_utente,
                    URL_DATA_DISABILITAZIONE = @url_data_disabilitazione,
                    URL_DATA_AGGIORNAMENTO = getdate(),
                    URL_AGGIORNATO_DA = @ute_id_utente_aggiornato
					WHERE URL_ID_RUOLI_UTENTE = @url_id_ruoli_utente ";
			
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "url_stato_ruolo_utente", DbType.Boolean, url_stato_ruolo_utente);
				db.AddInParameter(dbCommand, "url_data_assegnazione", DbType.DateTime, url_data_assegnazione);
                db.AddInParameter(dbCommand, "url_data_disabilitazione", DbType.DateTime, url_data_disabilitazione);										
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "url_id_ruoli_utente", DbType.Int32, url_id_ruoli_utente);
				db.AddInParameter(dbCommand, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);
                db.AddInParameter(dbCommand, "ute_id_utente_aggiornato", DbType.Int32, ute_id_utente_aggiornato);
				
                db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "RuoliUtente.Update.");
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
			// sistemare .....
				
			string sqlCommand = null;
            DbCommand dbCommand = null;

			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM RUOLI_UTENTE
                               WHERE URL_ID_RUOLI_UTENTE = @url_id_ruoli_utente ";				
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "url_id_ruoli_utente", DbType.Int32, url_id_ruoli_utente);
	
                db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "RuoliUtente.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

		}

        public void DeleteRuoliUtente(Int32 idUtente)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                sqlCommand = " DELETE FROM RUOLI_UTENTE WHERE " +
                    "(UTE_ID_UTENTE =@ute_id_utente AND url_flag_aggiornato_automaticamente = 1) ";             

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, idUtente);                
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "RuoliUtente.DeleteRuoliUtente.");
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
	
				sqlCommand = " INSERT INTO RUOLI_UTENTE (" +
						"UTE_ID_UTENTE, " +
						"RUL_ID_RUOLO, " +
						"URL_STATO_RUOLO_UTENTE, " +
						"URL_DATA_ASSEGNAZIONE,URL_DATA_CREAZIONE,URL_CREATO_DA,URL_DATA_DISABILITAZIONE	 )" + 
					"VALUES ( " +
						"@ute_id_utente, " +
						"@rul_id_ruolo, " +
						"@url_stato_ruolo_utente, " +
                        "@url_data_assegnazione,getdate(),@ute_id_utente_creato,@url_data_disabilitazione)"; 
                
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "ute_id_utente_creato", DbType.Int32, ute_id_utente_creato);
				db.AddInParameter(dbCommand, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);
				db.AddInParameter(dbCommand, "url_stato_ruolo_utente", DbType.Boolean, url_stato_ruolo_utente);
				db.AddInParameter(dbCommand, "url_data_assegnazione", DbType.DateTime, url_data_assegnazione);
                db.AddInParameter(dbCommand, "url_data_disabilitazione", DbType.DateTime, url_data_disabilitazione);

				db.ExecuteNonQuery(dbCommand);
                
			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "RuoliUtente.Create.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

		}

        /// <summary>
        /// Crea i Ruoli prendendoli da quelli impostati come "default" sul Cliente/Società
        /// </summary>
        /// <param name="p_cli_id_cliente"></param>
        public void CreateByDefaultCliente(int p_cli_id_cliente, Database db, DbTransaction t)
        {
            DbCommand dbCommand = null;
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.Append(@" INSERT INTO RUOLI_UTENTE (
                                UTE_ID_UTENTE, 
                                RUL_ID_RUOLO, 
                                URL_STATO_RUOLO_UTENTE, 
                                URL_DATA_ASSEGNAZIONE,
                                URL_DATA_CREAZIONE,
                                URL_CREATO_DA )
                            SELECT
                                @ute_id_utente, 
                                RUL_ID_RUOLO, 
                                @url_stato_ruolo_utente, 
                                getdate(),
                                getdate(),
                                @ute_id_utente_creato 
                            FROM CROSS_CLIENTE_RUOLI
                            WHERE 
                                ccr_flag_eliminato = 0
                                AND cli_id_cliente = @cli_id_cliente
                                AND ccr_flag_default = 1 ");

                dbCommand = db.GetSqlStringCommand(sb.ToString());

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "ute_id_utente_creato", DbType.Int32, ute_id_utente_creato);
                db.AddInParameter(dbCommand, "url_stato_ruolo_utente", DbType.Boolean, 1);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);

                db.ExecuteNonQuery(dbCommand, t);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "RuoliUtente.CreateByDefaultCliente.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi RuoliUtente dell'analisi
        /// </summary>
        public DataSet List() 
		{
			string sqlCommand = null;
            DbCommand dbCommand = null;

			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            
				sqlCommand = " SELECT " +
						"RUOLI_UTENTE.UTE_ID_UTENTE, " +
						"RUOLI_UTENTE.RUL_ID_RUOLO, " +
						"RUOLI_UTENTE.URL_STATO_RUOLO_UTENTE, " +
						"RUOLI_UTENTE.URL_DATA_ASSEGNAZIONE,URL_ID_RUOLI_UTENTE	 " + 
						"FROM RUOLI_UTENTE " + @sqlWhereClause;

				dbCommand = db.GetSqlStringCommand(sqlCommand);
				db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

				db.LoadDataSet(dbCommand, ruoli_utenteListDS, "RUOLI_UTENTE");
				return ruoli_utenteListDS; 
			
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "RuoliUtente.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

				return ruoli_utenteListDS; 
			}

			finally
			{	
				if (ruoli_utenteListDS != null)
					((IDisposable)ruoli_utenteListDS).Dispose();
			}
		}
						
        /// <summary>
        /// Elenca tutti gli elementi Ruolo di un dato utente
        /// </summary>
        public DataSet ListRuoliByUtente(int myParUteIdUtente)
        {
            try
            {
                if (myParUteIdUtente == SqlInt32.Null)
                {
                    myParUteIdUtente = 0;
                }


                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                string sqlCommand = " SELECT URL_ID_RUOLI_UTENTE," +
                             "RUOLI_UTENTE.UTE_ID_UTENTE, " +
                             "RUOLI.RUL_ID_RUOLO, " +
                             "RUOLI.RUL_RUOLO, " +
                             "CONVERT(VARCHAR(10),RUOLI.RUL_DATA_CREAZIONE, 103) AS RUL_DATA_CREAZIONE, " +
                             "CONVERT(VARCHAR(10),RUOLI_UTENTE.URL_DATA_ASSEGNAZIONE, 103 ) AS URL_DATA_ASSEGNAZIONE, " +
                             "CONVERT(VARCHAR(10),RUOLI_UTENTE.URL_DATA_DISABILITAZIONE, 103 ) AS URL_DATA_DISABILITAZIONE, " +
                             "RUOLI_UTENTE.URL_STATO_RUOLO_UTENTE " +
                             "FROM RUOLI " +
                             "LEFT JOIN RUOLI_UTENTE ON RUOLI_UTENTE.RUL_ID_RUOLO = RUOLI.RUL_ID_RUOLO " +
                             "WHERE RUOLI_UTENTE.UTE_ID_UTENTE = " + @myParUteIdUtente + " ORDER BY URL_STATO_RUOLO_UTENTE DESC";


                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParUteIdUtente", DbType.Int32, myParUteIdUtente);
                db.LoadDataSet(dbCommand, ruoli_utenteListDS, "RUOLI_UTENTE");
                return ruoli_utenteListDS;
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (ruoli_utenteListDS != null)
                    ((IDisposable)ruoli_utenteListDS).Dispose();
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi Utente di un dato ruolo
        /// </summary>
        public DataSet ListUtentiByRuolo(int myParRulIdRuolo)
        {
            try
            {
                if (myParRulIdRuolo == SqlInt32.Null)
                {
                    myParRulIdRuolo = 0;
                }


                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                string sqlCommand = " SELECT " +
                             "RUOLI_UTENTE.UTE_ID_UTENTE,RUOLI_UTENTE.URL_STATO_RUOLO_UTENTE, " +
                             "RUOLI_UTENTE.RUL_ID_RUOLO, " +
                             "UTENTE.UTE_ID_UTENTE, UTENTE.UTE_NOME, UTENTE.UTE_COGNOME, UTENTE.UTE_ALIAS,UTENTE.UTE_SIGLA, " +
                             "UTENTE.UTE_DESCRIZIONE, UTENTE.UTE_USER_ID, UTENTE.UTE_PASSWORD, UTENTE.UTE_TELEFONO, " +
                             "UTENTE.UTE_FAX, UTENTE.UTE_EMAIL, " +
                             "CONVERT(VARCHAR(10),RUOLI_UTENTE.URL_DATA_ASSEGNAZIONE, 103 ) AS URL_DATA_ASSEGNAZIONE, URL_ID_RUOLI_UTENTE " +
                             "FROM RUOLI_UTENTE " +
                             "LEFT JOIN UTENTE ON RUOLI_UTENTE.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE " +
                             "WHERE RUOLI_UTENTE.RUL_ID_RUOLO = " + myParRulIdRuolo + " AND UTE_FLAG_ELIMINATO = 0 AND UTENTE.UTE_STATO_UTENTE = 1 ";

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParRulIdRuolo", DbType.Int32, myParRulIdRuolo);

                db.LoadDataSet(dbCommand, ruoli_utenteListDS, "RUOLI_UTENTE");
                return ruoli_utenteListDS;
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (ruoli_utenteListDS != null)
                    ((IDisposable)ruoli_utenteListDS).Dispose();
            }
        }        

		#endregion

	}
}


