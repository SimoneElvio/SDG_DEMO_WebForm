#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   CrossUtenteDelegati.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per CROSSUTENTEDELEGATI
//
// Autore:      AR - SDG srl
// Data:        28/03/2013
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Text;
using SDG.ExceptionHandling;

namespace BusinessObjects
{
	/// <summary>
	/// Tabella CROSS_UTENTE_DELEGATI 
	/// </summary>
	public class CrossUtenteDelegati
	{
		#region attributi e variabili

	    private SqlInt32 cud_id_utente_delegato = SqlInt32.Null;
	    private SqlInt32 ute_id_utente = SqlInt32.Null;
	    private SqlInt32 cud_id_delegato1 = SqlInt32.Null;
	    private SqlInt32 cud_id_delegato2 = SqlInt32.Null;
	    private SqlDateTime cud_data_inizio_validita1 = SqlDateTime.Null;
	    private SqlDateTime cud_data_fine_validita1 = SqlDateTime.Null;
	    private SqlDateTime cud_data_inizio_validita2 = SqlDateTime.Null;
	    private SqlDateTime cud_data_fine_validita2 = SqlDateTime.Null;
	    private SqlInt32 cud_id_creato_da = SqlInt32.Null;
	    private SqlInt32 cud_id_aggiornato_da = SqlInt32.Null;
	    private SqlDateTime cud_data_creazione = SqlDateTime.Null;
	    private SqlDateTime cud_data_aggiornamento = SqlDateTime.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cud_id_utente_delegato
		{
			get { return cud_id_utente_delegato; }	
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Ute_id_utente
		{
			get { return ute_id_utente; }	
			set { ute_id_utente = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cud_id_delegato1
		{
			get { return cud_id_delegato1; }	
			set { cud_id_delegato1 = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cud_id_delegato2
		{
			get { return cud_id_delegato2; }	
			set { cud_id_delegato2 = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Cud_data_inizio_validita1
		{
			get { return cud_data_inizio_validita1; }	
			set { cud_data_inizio_validita1 = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Cud_data_fine_validita1
		{
			get { return cud_data_fine_validita1; }	
			set { cud_data_fine_validita1 = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Cud_data_inizio_validita2
		{
			get { return cud_data_inizio_validita2; }	
			set { cud_data_inizio_validita2 = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Cud_data_fine_validita2
		{
			get { return cud_data_fine_validita2; }	
			set { cud_data_fine_validita2 = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cud_id_creato_da
		{
			get { return cud_id_creato_da; }	
			set { cud_id_creato_da = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cud_id_aggiornato_da
		{
			get { return cud_id_aggiornato_da; }	
			set { cud_id_aggiornato_da = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Cud_data_creazione
		{
			get { return cud_data_creazione; }	
			set { cud_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Cud_data_aggiornamento
		{
			get { return cud_data_aggiornamento; }	
			set { cud_data_aggiornamento = value; }
		}


		/// <value>
		/// Where Clause condition
		/// </value>
		public string SqlWhereClause
		{
			get { return  sqlWhereClause; }
			set { sqlWhereClause = value; }
		}
		#endregion
		
		#region Costruttori

		/// <summary>
		/// Costruttore standard
		/// </summary>
		public CrossUtenteDelegati()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_cud_id_utente_delegato)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 CROSS_UTENTE_DELEGATI.cud_id_utente_delegato, 
					 CROSS_UTENTE_DELEGATI.ute_id_utente, 
					 CROSS_UTENTE_DELEGATI.cud_id_delegato1, 
					 CROSS_UTENTE_DELEGATI.cud_id_delegato2, 
					 CROSS_UTENTE_DELEGATI.cud_data_inizio_validita1, 
					 CROSS_UTENTE_DELEGATI.cud_data_fine_validita1, 
					 CROSS_UTENTE_DELEGATI.cud_data_inizio_validita2, 
					 CROSS_UTENTE_DELEGATI.cud_data_fine_validita2, 
					 CROSS_UTENTE_DELEGATI.cud_id_creato_da, 
					 CROSS_UTENTE_DELEGATI.cud_id_aggiornato_da, 
					 CROSS_UTENTE_DELEGATI.cud_data_creazione, 
					 CROSS_UTENTE_DELEGATI.cud_data_aggiornamento	 
				 	 FROM CROSS_UTENTE_DELEGATI WITH (NOLOCK) WHERE 
					 (cud_id_utente_delegato = @cud_id_utente_delegato) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "cud_id_utente_delegato", DbType.Int32, p_cud_id_utente_delegato);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					int i = 0;
					cud_id_utente_delegato = reader.GetSqlInt32(i++);
					ute_id_utente = reader.GetSqlInt32(i++);
					cud_id_delegato1 = reader.GetSqlInt32(i++);
					cud_id_delegato2 = reader.GetSqlInt32(i++);
					cud_data_inizio_validita1 = reader.GetSqlDateTime(i++);
					cud_data_fine_validita1 = reader.GetSqlDateTime(i++);
					cud_data_inizio_validita2 = reader.GetSqlDateTime(i++);
					cud_data_fine_validita2 = reader.GetSqlDateTime(i++);
					cud_id_creato_da = reader.GetSqlInt32(i++);
					cud_id_aggiornato_da = reader.GetSqlInt32(i++);
					cud_data_creazione = reader.GetSqlDateTime(i++);
					cud_data_aggiornamento = reader.GetSqlDateTime(i++);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteDelegati.Read.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
				throw ex;
			}

			finally
			{
				if(reader != null)
					((IDisposable)reader).Dispose();
			}
		}
		
		/// <summary>
		/// Aggiorna l'oggetto nella base dati
		/// </summary>	
		public void Update(SqlInt32 p_cud_id_utente_delegato)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE CROSS_UTENTE_DELEGATI SET
					 ute_id_utente = @ute_id_utente, 
					 cud_id_delegato1 = @cud_id_delegato1, 
					 cud_id_delegato2 = @cud_id_delegato2, 
					 cud_data_inizio_validita1 = @cud_data_inizio_validita1, 
					 cud_data_fine_validita1 = @cud_data_fine_validita1, 
					 cud_data_inizio_validita2 = @cud_data_inizio_validita2, 
					 cud_data_fine_validita2 = @cud_data_fine_validita2, 
					 cud_id_aggiornato_da = @cud_id_aggiornato_da, 
					 cud_data_aggiornamento = getdate()
					 WHERE   
				     (cud_id_utente_delegato = @cud_id_utente_delegato) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "cud_id_delegato1", DbType.Int32, cud_id_delegato1);
				db.AddInParameter(dbCommand, "cud_id_delegato2", DbType.Int32, cud_id_delegato2);
				db.AddInParameter(dbCommand, "cud_data_inizio_validita1", DbType.DateTime, cud_data_inizio_validita1);
				db.AddInParameter(dbCommand, "cud_data_fine_validita1", DbType.DateTime, cud_data_fine_validita1);
				db.AddInParameter(dbCommand, "cud_data_inizio_validita2", DbType.DateTime, cud_data_inizio_validita2);
				db.AddInParameter(dbCommand, "cud_data_fine_validita2", DbType.DateTime, cud_data_fine_validita2);
				db.AddInParameter(dbCommand, "cud_id_aggiornato_da", DbType.Int32, cud_id_aggiornato_da);
										
				db.AddInParameter(dbCommand, "cud_id_utente_delegato", DbType.Int32, p_cud_id_utente_delegato);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteDelegati.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
			}
		}

		/// <summary>
		/// Cancella fisicamente l'oggetto dalla base dati.
		/// </summary>
		public static void Drop(SqlInt32 p_cud_id_utente_delegato)
		{
			Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
			DbConnection c =  db.CreateConnection();
			DbTransaction t = null;

			try
			{
				c.Open();
				t = c.BeginTransaction();

				Drop( p_cud_id_utente_delegato, t);

				t.Commit();
			}
			catch (Exception ex)
			{
				try
				{
					t.Rollback();
				}
				catch (Exception ex2)
				{
					ex2.Data.Add("Class.Method", "CrossUtenteDelegati.Wipe.Rollback");
					ex2.Data.Add("SQL", "Rollback error");
				}
				ex.Data.Add("Class.Method", "CrossUtenteDelegati.Wipe.");
				ex.Data.Add("SQL", ex.Message);

				// Gestione messaggistica all'utente e trace in DB dell'errore
				throw ex;
			}
			finally
			{
				c.Close();
			}
		}
	
		/// <summary>
		/// Cancella fisicamente l'oggetto dalla base dati.
		/// </summary>
        public static void Drop(SqlInt32 p_cud_id_utente_delegato, DbTransaction transaction)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM CROSS_UTENTE_DELEGATI WHERE 
					(cud_id_utente_delegato = @cud_id_utente_delegato) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "cud_id_utente_delegato", DbType.Int32, p_cud_id_utente_delegato);
										
				db.ExecuteNonQuery(dbCommand, transaction);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteDelegati.Wipe.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
			}
		}
		
		/// <summary>
		/// Cancella logicamente l'oggetto dalla base dati.
		/// </summary>
		public static void Delete(SqlInt32 p_cud_id_utente_delegato)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
			
				sqlCommand = @" DELETE FROM CROSS_UTENTE_DELEGATI 
					            WHERE (cud_id_utente_delegato = @cud_id_utente_delegato) "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "cud_id_utente_delegato", DbType.Int32, p_cud_id_utente_delegato);
										
				db.ExecuteNonQuery(dbCommand);
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteDelegati.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
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
	
				sqlCommand = @" INSERT INTO CROSS_UTENTE_DELEGATI (
						ute_id_utente, 
						cud_id_delegato1, 
						cud_id_delegato2, 
						cud_data_inizio_validita1, 
						cud_data_fine_validita1, 
						cud_data_inizio_validita2, 
						cud_data_fine_validita2, 
						cud_id_creato_da, 
						cud_data_creazione	 ) 
					VALUES ( 
						@ute_id_utente, 
						@cud_id_delegato1, 
						@cud_id_delegato2, 
						@cud_data_inizio_validita1, 
						@cud_data_fine_validita1, 
						@cud_data_inizio_validita2, 
						@cud_data_fine_validita2, 
						@cud_id_creato_da, 
						getdate()	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "cud_id_delegato1", DbType.Int32, cud_id_delegato1);
				db.AddInParameter(dbCommand, "cud_id_delegato2", DbType.Int32, cud_id_delegato2);
				db.AddInParameter(dbCommand, "cud_data_inizio_validita1", DbType.DateTime, cud_data_inizio_validita1);
				db.AddInParameter(dbCommand, "cud_data_fine_validita1", DbType.DateTime, cud_data_fine_validita1);
				db.AddInParameter(dbCommand, "cud_data_inizio_validita2", DbType.DateTime, cud_data_inizio_validita2);
				db.AddInParameter(dbCommand, "cud_data_fine_validita2", DbType.DateTime, cud_data_fine_validita2);
				db.AddInParameter(dbCommand, "cud_id_creato_da", DbType.Int32, cud_id_creato_da);

 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					cud_id_utente_delegato = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "CrossUtenteDelegati.Create.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
			}
			finally
			{
				if(dataReader != null)
					((IDisposable)dataReader).Dispose();
			}
		}
		
		/// <summary>
        /// Elenca tutti gli elementi CrossUtenteDelegati dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "CROSS_UTENTE_DELEGATI");
        }
		/// <summary>
		/// Elenca tutti gli elementi CrossUtenteDelegati dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"CROSS_UTENTE_DELEGATI");
		}
		/// <summary>
		/// Elenca tutti gli elementi CrossUtenteDelegati dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					CROSS_UTENTE_DELEGATI.cud_id_utente_delegato, 
					CROSS_UTENTE_DELEGATI.ute_id_utente, 
                    COALESCE(UTENTE.UTE_COGNOME + ' ' + UTENTE.UTE_NOME, UTENTE.UTE_COGNOME) AS UTE_DESCRIZIONE,
                    COALESCE(DELEGATO_1.UTE_COGNOME + ' ' + DELEGATO_1.UTE_NOME, DELEGATO_1.UTE_COGNOME) AS UTE_DELEGATO_1,
                    COALESCE(DELEGATO_2.UTE_COGNOME + ' ' + DELEGATO_2.UTE_NOME, DELEGATO_2.UTE_COGNOME) AS UTE_DELEGATO_2,
					CROSS_UTENTE_DELEGATI.cud_id_delegato1, 
					CROSS_UTENTE_DELEGATI.cud_id_delegato2, 
					CROSS_UTENTE_DELEGATI.cud_data_inizio_validita1, 
					CROSS_UTENTE_DELEGATI.cud_data_fine_validita1, 
					CROSS_UTENTE_DELEGATI.cud_data_inizio_validita2, 
					CROSS_UTENTE_DELEGATI.cud_data_fine_validita2, 
					CROSS_UTENTE_DELEGATI.cud_id_creato_da, 
					CROSS_UTENTE_DELEGATI.cud_id_aggiornato_da, 
					CROSS_UTENTE_DELEGATI.cud_data_creazione, 
					CROSS_UTENTE_DELEGATI.cud_data_aggiornamento 
				    FROM CROSS_UTENTE_DELEGATI WITH (NOLOCK) 
                    INNER JOIN UTENTE ON CROSS_UTENTE_DELEGATI.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE
                    LEFT JOIN UTENTE DELEGATO_1 ON CROSS_UTENTE_DELEGATI.CUD_ID_DELEGATO1 = DELEGATO_1.UTE_ID_UTENTE
                    LEFT JOIN UTENTE DELEGATO_2 ON CROSS_UTENTE_DELEGATI.CUD_ID_DELEGATO2 = DELEGATO_2.UTE_ID_UTENTE
                    ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteDelegati.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
			}

			return ds; 
		}

		/// <summary>
        /// Elenca tutti gli elementi CrossUtenteDelegati dell'analisi con tutte le tabelle collegate. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet ListForExport()
        {
            return ListForExport(string.Empty, "CROSS_UTENTE_DELEGATI");
        }
		/// <summary>
		/// Elenca tutti gli elementi CrossUtenteDelegati dell'analisi con tutte le tabelle collegate. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet ListForExport(string sqlWhereClause) 
		{
			return ListForExport(sqlWhereClause,"CROSS_UTENTE_DELEGATI");
		}
		/// <summary>
		/// Elenca tutti gli elementi CrossUtenteDelegati dell'analisi con tutte le tabelle collegate. L'utente può scegliere il nome della tabella nel dataset
		/// </summary>
		public static DataSet ListForExport(string sqlWhereClause, string tableName) 
		{
			string sqlCommand = null;
			StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
            DataSet ds = new DataSet();
			
			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            
				sb.Append(@" SELECT 
					CROSS_UTENTE_DELEGATI.cud_id_utente_delegato AS [id_utente_delegato], 
					CROSS_UTENTE_DELEGATI.ute_id_utente AS [id_utente], 
					CROSS_UTENTE_DELEGATI.cud_id_delegato1 AS [id_delegato1], 
					CROSS_UTENTE_DELEGATI.cud_id_delegato2 AS [id_delegato2], 
					CONVERT(CHAR(10),CROSS_UTENTE_DELEGATI.cud_data_inizio_validita1,103) AS [data_inizio_validita1], 
					CONVERT(CHAR(10),CROSS_UTENTE_DELEGATI.cud_data_fine_validita1,103) AS [data_fine_validita1], 
					CONVERT(CHAR(10),CROSS_UTENTE_DELEGATI.cud_data_inizio_validita2,103) AS [data_inizio_validita2], 
					CONVERT(CHAR(10),CROSS_UTENTE_DELEGATI.cud_data_fine_validita2,103) AS [data_fine_validita2], 
					CROSS_UTENTE_DELEGATI.cud_id_creato_da AS [id_creato_da], 
					CROSS_UTENTE_DELEGATI.cud_id_aggiornato_da AS [id_aggiornato_da], 
					CONVERT(CHAR(10),CROSS_UTENTE_DELEGATI.cud_data_creazione,103) AS [data_creazione], 
					CONVERT(CHAR(10),CROSS_UTENTE_DELEGATI.cud_data_aggiornamento,103) AS [data_aggiornamento] 
				FROM CROSS_UTENTE_DELEGATI WITH (NOLOCK)  
				LEFT JOIN UTENTE ON CROSS_UTENTE_DELEGATI.ute_id_utente = UTENTE.ute_id_utente 				");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteDelegati.ListForExport.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
			}

			return ds; 
		}

		#endregion

	}
}
