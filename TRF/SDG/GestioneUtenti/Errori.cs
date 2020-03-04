#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Errori.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per ERRORI
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
using SDG.ExceptionHandling;

namespace SDG.GestioneUtenti
{
	/// <summary>
	/// Tabella ERRORI 
	/// </summary>
	public class Errori
	{
		#region attributi e variabili

	    private SqlInt32 err_id_errore = SqlInt32.Null;
	    private SqlInt32 fnt_id_funzionalita = SqlInt32.Null;
        private SqlString fnt_acronimo_funzionalita = SqlString.Null;
	    private SqlInt32 err_err_id_errore = SqlInt32.Null;
	    private SqlDateTime err_data = SqlDateTime.Null;
	    private SqlString err_source = SqlString.Null;
	    private SqlString err_class = SqlString.Null;
	    private SqlString err_version = SqlString.Null;
	    private SqlString err_computer = SqlString.Null;
	    private SqlString err_pagina_asp = SqlString.Null;
	    private SqlString err_str_id_errore = SqlString.Null;
	    private SqlString err_descrizione = SqlString.Null;
	    private SqlString err_sql = SqlString.Null;
	    private SqlInt32 err_id_utente = SqlInt32.Null;
	    private SqlDateTime err_data_creazione = SqlDateTime.Null;
	    private SqlDateTime err_data_aggiornamento = SqlDateTime.Null;
	    private SqlInt32 err_creato_da = SqlInt32.Null;
	    private SqlInt32 err_aggiornato_da = SqlInt32.Null;
		
		private string sqlWhereClause = "";
		private DataSet erroriListDS;

		#endregion

		#region Proprieta
		

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Err_id_errore
		{
			get { return  err_id_errore; }
			set { err_id_errore = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Fnt_id_funzionalita
		{
			get { return  fnt_id_funzionalita; }
			set { fnt_id_funzionalita = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlString Fnt_acronimo_funzionalita
        {
            get { return fnt_acronimo_funzionalita; }
            // questo è inutile in quanto non verrà mai editato il record errori!
            set { fnt_acronimo_funzionalita = value; }
        }

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Err_err_id_errore
		{
			get { return  err_err_id_errore; }
			set { err_err_id_errore = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlDateTime Err_data
		{
			get { return  err_data; }
			set { err_data = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Err_source
		{
			get { return  err_source; }
			set { err_source = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Err_class
		{
			get { return  err_class; }
			set { err_class = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Err_version
		{
			get { return  err_version; }
			set { err_version = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Err_computer
		{
			get { return  err_computer; }
			set { err_computer = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Err_pagina_asp
		{
			get { return  err_pagina_asp; }
			set { err_pagina_asp = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Err_str_id_errore
		{
			get { return  err_str_id_errore; }
			set { err_str_id_errore = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Err_descrizione
		{
			get { return  err_descrizione; }
			set { err_descrizione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Err_sql
		{
			get { return  err_sql; }
			set { err_sql = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Err_id_utente
		{
			get { return  err_id_utente; }
			set { err_id_utente = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlDateTime Err_data_creazione
		{
			get { return  err_data_creazione; }
			set { err_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlDateTime Err_data_aggiornamento
		{
			get { return  err_data_aggiornamento; }
			set { err_data_aggiornamento = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Err_creato_da
		{
			get { return  err_creato_da; }
			set { err_creato_da = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Err_aggiornato_da
		{
			get { return  err_aggiornato_da; }
			set { err_aggiornato_da = value; }
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
		/// Elenco degli elementi Errori selezionati
		/// </value>
		public DataSet ErroriListDS
		{
			get { return  erroriListDS; }
			set { erroriListDS = value; }
		}

		#endregion
		
		#region  Costruttori

		/// <summary>
		/// Costruttore standard
		/// </summary>
		public Errori()
		{
			erroriListDS = new DataSet();
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
					 ERRORI.ERR_ID_ERRORE, 
					 ERRORI.fnt_id_funzionalita, 
					 ERRORI.ERR_ERR_ID_ERRORE, 
					 ERRORI.err_data, 
					 ERRORI.err_source, 
					 ERRORI.err_class, 
					 ERRORI.err_version, 
					 ERRORI.err_computer, 
					 ERRORI.err_pagina_asp, 
					 ERRORI.err_str_id_errore, 
					 ERRORI.err_descrizione, 
					 ERRORI.err_sql, 
					 ERRORI.ERR_ID_UTENTE, 
					 ERRORI.err_data_creazione, 
					 ERRORI.err_data_aggiornamento, 
					 ERRORI.err_creato_da, 
					 ERRORI.err_aggiornato_da	 
				 	 FROM ERRORI WHERE 
					 (ERR_ID_ERRORE =@err_id_errore) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "err_id_errore", DbType.Int32, err_id_errore);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					err_id_errore = reader.GetSqlInt32(0);
					fnt_id_funzionalita = reader.GetSqlInt32(1);
					err_err_id_errore = reader.GetSqlInt32(2);
					err_data = reader.GetSqlDateTime(3);
					err_source = reader.GetSqlString(4);
					err_class = reader.GetSqlString(5);
					err_version = reader.GetSqlString(6);
					err_computer = reader.GetSqlString(7);
					err_pagina_asp = reader.GetSqlString(8);
					err_str_id_errore = reader.GetSqlString(9);
					err_descrizione = reader.GetSqlString(10);
					err_sql = reader.GetSqlString(11);
					err_id_utente = reader.GetSqlInt32(12);
					err_data_creazione = reader.GetSqlDateTime(13);
					err_data_aggiornamento = reader.GetSqlDateTime(14);
					err_creato_da = reader.GetSqlInt32(15);
					err_aggiornato_da = reader.GetSqlInt32(16);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "Errori.Read.");
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

				sqlCommand = @" UPDATE ERRORI SET 
					 fnt_id_funzionalita = @fnt_id_funzionalita, 
					 ERR_ERR_ID_ERRORE = @err_err_id_errore, 
					 err_data = @err_data, 
					 err_source = @err_source, 
					 err_class = @err_class, 
					 err_version = @err_version, 
					 err_computer = @err_computer, 
					 err_pagina_asp = @err_pagina_asp, 
					 err_str_id_errore = @err_str_id_errore, 
					 err_descrizione = @err_descrizione, 
					 err_sql = @err_sql, 
					 ERR_ID_UTENTE = @err_id_utente, 
					 err_data_creazione = @err_data_creazione, 
					 err_data_aggiornamento = @err_data_aggiornamento, 
					 err_creato_da = @err_creato_da, 
					 err_aggiornato_da = @err_aggiornato_da
					 WHERE   
				     (ERR_ID_ERRORE =@err_id_errore) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);
				db.AddInParameter(dbCommand, "err_err_id_errore", DbType.Int32, err_err_id_errore);
				db.AddInParameter(dbCommand, "err_data", DbType.DateTime, err_data);
				db.AddInParameter(dbCommand, "err_source", DbType.String, err_source);
				db.AddInParameter(dbCommand, "err_class", DbType.String, err_class);
				db.AddInParameter(dbCommand, "err_version", DbType.String, err_version);
				db.AddInParameter(dbCommand, "err_computer", DbType.String, err_computer);
				db.AddInParameter(dbCommand, "err_pagina_asp", DbType.String, err_pagina_asp);
				db.AddInParameter(dbCommand, "err_str_id_errore", DbType.String, err_str_id_errore);
				db.AddInParameter(dbCommand, "err_descrizione", DbType.String, err_descrizione);
				db.AddInParameter(dbCommand, "err_sql", DbType.String, err_sql);
				db.AddInParameter(dbCommand, "err_id_utente", DbType.Int32, err_id_utente);
				db.AddInParameter(dbCommand, "err_data_creazione", DbType.DateTime, err_data_creazione);
				db.AddInParameter(dbCommand, "err_data_aggiornamento", DbType.DateTime, err_data_aggiornamento);
				db.AddInParameter(dbCommand, "err_creato_da", DbType.Int32, err_creato_da);
				db.AddInParameter(dbCommand, "err_aggiornato_da", DbType.Int32, err_aggiornato_da);
										
				db.AddInParameter(dbCommand, "err_id_errore", DbType.Int32, err_id_errore);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Errori.Update.");
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

				sqlCommand = @" DELETE FROM ERRORI WHERE 
					(ERR_ID_ERRORE =@err_id_errore) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "err_id_errore", DbType.Int32, err_id_errore);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Errori.Delete.");
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
			IDataReader dataReader = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
	
				sqlCommand = @" INSERT INTO ERRORI (
						fnt_id_funzionalita, 
						ERR_ERR_ID_ERRORE, 
						err_data, 
						err_source, 
						err_class, 
						err_version, 
						err_computer, 
						err_pagina_asp, 
						err_str_id_errore, 
						err_descrizione, 
						err_sql, 
						ERR_ID_UTENTE, 
						err_data_creazione, 
						err_data_aggiornamento, 
						err_creato_da, 
						err_aggiornato_da	 ) 
					VALUES ( 
						@fnt_id_funzionalita, 
						@err_err_id_errore, 
						@err_data, 
						@err_source, 
						@err_class, 
						@err_version, 
						@err_computer, 
						@err_pagina_asp, 
						@err_str_id_errore, 
						@err_descrizione, 
						@err_sql, 
						@err_id_utente, 
						@err_data_creazione, 
						@err_data_aggiornamento, 
						@err_creato_da, 
						@err_aggiornato_da	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);
				db.AddInParameter(dbCommand, "err_err_id_errore", DbType.Int32, err_err_id_errore);
				db.AddInParameter(dbCommand, "err_data", DbType.DateTime, err_data);
				db.AddInParameter(dbCommand, "err_source", DbType.String, err_source);
				db.AddInParameter(dbCommand, "err_class", DbType.String, err_class);
				db.AddInParameter(dbCommand, "err_version", DbType.String, err_version);
				db.AddInParameter(dbCommand, "err_computer", DbType.String, err_computer);
				db.AddInParameter(dbCommand, "err_pagina_asp", DbType.String, err_pagina_asp);
				db.AddInParameter(dbCommand, "err_str_id_errore", DbType.String, err_str_id_errore);
				db.AddInParameter(dbCommand, "err_descrizione", DbType.String, err_descrizione);
				db.AddInParameter(dbCommand, "err_sql", DbType.String, err_sql);
				db.AddInParameter(dbCommand, "err_id_utente", DbType.Int32, err_id_utente);
				db.AddInParameter(dbCommand, "err_data_creazione", DbType.DateTime, err_data_creazione);
				db.AddInParameter(dbCommand, "err_data_aggiornamento", DbType.DateTime, err_data_aggiornamento);
				db.AddInParameter(dbCommand, "err_creato_da", DbType.Int32, err_creato_da);
				db.AddInParameter(dbCommand, "err_aggiornato_da", DbType.Int32, err_aggiornato_da);

 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					err_id_errore = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "Errori.Create.");
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
		
		/// <summary>
        /// Elenca tutti gli elementi Piano_di_mitigazione dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "ERRORI");
        }
		/// <summary>
		/// Elenca tutti gli elementi Errori dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"ERRORI");
		}
		/// <summary>
		/// Elenca tutti gli elementi Errori dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					ERRORI.ERR_ID_ERRORE, 
					ERRORI.fnt_id_funzionalita, 
					ERRORI.ERR_ERR_ID_ERRORE, 
					ERRORI.err_data, 
					ERRORI.err_source, 
					ERRORI.err_class, 
					ERRORI.err_version, 
					ERRORI.err_computer, 
					ERRORI.err_pagina_asp, 
					ERRORI.err_str_id_errore, 
					ERRORI.err_descrizione, 
					ERRORI.err_sql, 
					ERRORI.ERR_ID_UTENTE, 
					ERRORI.err_data_creazione, 
					ERRORI.err_data_aggiornamento, 
					ERRORI.err_creato_da, 
					ERRORI.err_aggiornato_da, 
                    UTENTE.UTE_USER_ID
				FROM ERRORI 
                LEFT JOIN UTENTE ON ERRORI.ERR_ID_UTENTE = UTENTE.UTE_ID_UTENTE ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

                sb.Append(" ORDER BY ERRORI.ERR_DATA DESC ");

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, "ERRORI");
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Errori.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

        /// <summary>
        /// Pulisce la base dati cancellando tutti i record dalla tabella ERRORI.
        /// </summary>
        public void DeleteAll()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = " DELETE FROM ERRORI ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.ExecuteNonQuery(dbCommand);
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Errori.DeleteAll.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

        }

		#endregion

	}
}
