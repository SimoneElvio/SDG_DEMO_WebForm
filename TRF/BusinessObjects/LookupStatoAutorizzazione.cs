#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   LookupStatoAutorizzazione.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per LOOKUPSTATOAUTORIZZAZIONE
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
	/// Tabella LOOKUP_STATO_AUTORIZZAZIONE 
	/// </summary>
	public class LookupStatoAutorizzazione
	{
		#region attributi e variabili

	    private SqlInt32 lsr_id_stato_richiesta = SqlInt32.Null;
	    private SqlString lsa_descrizione = SqlString.Null;
	    private SqlInt32 lsa_flag_visibile = SqlInt32.Null;
	    private SqlInt32 lsa_flag_eliminato = SqlInt32.Null;
	    private SqlDateTime lsa_data_creazione = SqlDateTime.Null;
	    private SqlDateTime lsa_data_aggiornamento = SqlDateTime.Null;
	    private SqlInt32 ute_id_utente = SqlInt32.Null;
	    private SqlInt32 ute_aggiornato_da = SqlInt32.Null;
	    private SqlInt32 ute_creato_da = SqlInt32.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Lsr_id_stato_richiesta
		{
			get { return lsr_id_stato_richiesta; }	
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Lsa_descrizione
		{
			get { return lsa_descrizione; }	
			set { lsa_descrizione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Lsa_flag_visibile
		{
			get { return lsa_flag_visibile; }	
			set { lsa_flag_visibile = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Lsa_flag_eliminato
		{
			get { return lsa_flag_eliminato; }	
			set { lsa_flag_eliminato = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Lsa_data_creazione
		{
			get { return lsa_data_creazione; }	
			set { lsa_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Lsa_data_aggiornamento
		{
			get { return lsa_data_aggiornamento; }	
			set { lsa_data_aggiornamento = value; }
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
		public SqlInt32 Ute_aggiornato_da
		{
			get { return ute_aggiornato_da; }	
			set { ute_aggiornato_da = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Ute_creato_da
		{
			get { return ute_creato_da; }	
			set { ute_creato_da = value; }
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
		public LookupStatoAutorizzazione()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_lsr_id_stato_richiesta)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 LOOKUP_STATO_AUTORIZZAZIONE.lsr_id_stato_richiesta, 
					 LOOKUP_STATO_AUTORIZZAZIONE.lsa_descrizione, 
					 LOOKUP_STATO_AUTORIZZAZIONE.lsa_flag_visibile, 
					 LOOKUP_STATO_AUTORIZZAZIONE.lsa_flag_eliminato, 
					 LOOKUP_STATO_AUTORIZZAZIONE.lsa_data_creazione, 
					 LOOKUP_STATO_AUTORIZZAZIONE.lsa_data_aggiornamento, 
					 LOOKUP_STATO_AUTORIZZAZIONE.ute_id_utente, 
					 LOOKUP_STATO_AUTORIZZAZIONE.ute_aggiornato_da, 
					 LOOKUP_STATO_AUTORIZZAZIONE.ute_creato_da	 
				 	 FROM LOOKUP_STATO_AUTORIZZAZIONE WHERE 
					 (lsr_id_stato_richiesta = @lsr_id_stato_richiesta) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, p_lsr_id_stato_richiesta);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					lsr_id_stato_richiesta = reader.GetSqlInt32(0);
					lsa_descrizione = reader.GetSqlString(1);
					lsa_flag_visibile = reader.GetSqlInt32(2);
					lsa_flag_eliminato = reader.GetSqlInt32(3);
					lsa_data_creazione = reader.GetSqlDateTime(4);
					lsa_data_aggiornamento = reader.GetSqlDateTime(5);
					ute_id_utente = reader.GetSqlInt32(6);
					ute_aggiornato_da = reader.GetSqlInt32(7);
					ute_creato_da = reader.GetSqlInt32(8);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoAutorizzazione.Read.");
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
		public void Update(SqlInt32 p_lsr_id_stato_richiesta)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE LOOKUP_STATO_AUTORIZZAZIONE SET
					 lsa_descrizione = @lsa_descrizione, 
					 lsa_flag_visibile = @lsa_flag_visibile, 
					 lsa_flag_eliminato = @lsa_flag_eliminato, 
					 lsa_data_aggiornamento = getdate(), 
					 ute_id_utente = @ute_id_utente, 
					 ute_aggiornato_da = @ute_aggiornato_da
					 WHERE   
				     (lsr_id_stato_richiesta = @lsr_id_stato_richiesta) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "lsa_descrizione", DbType.String, lsa_descrizione);
				db.AddInParameter(dbCommand, "lsa_flag_visibile", DbType.Int32, lsa_flag_visibile);
				db.AddInParameter(dbCommand, "lsa_flag_eliminato", DbType.Int32, lsa_flag_eliminato);
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
										
				db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, p_lsr_id_stato_richiesta);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoAutorizzazione.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete(SqlInt32 p_lsr_id_stato_richiesta)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM LOOKUP_STATO_AUTORIZZAZIONE WHERE 
					(lsr_id_stato_richiesta = @lsr_id_stato_richiesta) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, p_lsr_id_stato_richiesta);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoAutorizzazione.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}
		
		/// <summary>
		/// Crea l'oggetto corrispondente nella base dati.
		/// </summary>
		public void Create(SqlInt32 p_lsr_id_stato_richiesta) 
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			IDataReader dataReader = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
	
				sqlCommand = @" INSERT INTO LOOKUP_STATO_AUTORIZZAZIONE (
						lsa_descrizione, 
						lsa_flag_visibile, 
						lsa_flag_eliminato, 
						lsa_data_creazione, 
						ute_id_utente, 
						ute_creato_da	 ) 
					VALUES ( 
						@lsa_descrizione, 
						@lsa_flag_visibile, 
						@lsa_flag_eliminato, 
						getdate(), 
						@ute_id_utente, 
						@ute_creato_da	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "lsa_descrizione", DbType.String, lsa_descrizione);
				db.AddInParameter(dbCommand, "lsa_flag_visibile", DbType.Int32, lsa_flag_visibile);
				db.AddInParameter(dbCommand, "lsa_flag_eliminato", DbType.Int32, lsa_flag_eliminato);
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);

				db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, p_lsr_id_stato_richiesta);
 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					lsr_id_stato_richiesta = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "LookupStatoAutorizzazione.Create.");
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
        /// Elenca tutti gli elementi LookupStatoAutorizzazione dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "LOOKUP_STATO_AUTORIZZAZIONE");
        }
		/// <summary>
		/// Elenca tutti gli elementi LookupStatoAutorizzazione dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"LOOKUP_STATO_AUTORIZZAZIONE");
		}
		/// <summary>
		/// Elenca tutti gli elementi LookupStatoAutorizzazione dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					LOOKUP_STATO_AUTORIZZAZIONE.lsr_id_stato_richiesta, 
					LOOKUP_STATO_AUTORIZZAZIONE.lsa_descrizione, 
					LOOKUP_STATO_AUTORIZZAZIONE.lsa_flag_visibile, 
					LOOKUP_STATO_AUTORIZZAZIONE.lsa_flag_eliminato, 
					LOOKUP_STATO_AUTORIZZAZIONE.lsa_data_creazione, 
					LOOKUP_STATO_AUTORIZZAZIONE.lsa_data_aggiornamento, 
					LOOKUP_STATO_AUTORIZZAZIONE.ute_id_utente, 
					LOOKUP_STATO_AUTORIZZAZIONE.ute_aggiornato_da, 
					LOOKUP_STATO_AUTORIZZAZIONE.ute_creato_da 
				FROM LOOKUP_STATO_AUTORIZZAZIONE ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["LOOKUP_STATO_AUTORIZZAZIONE"].Columns["lsr_id_stato_richiesta"];
				ds.Tables["LOOKUP_STATO_AUTORIZZAZIONE"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoAutorizzazione.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}
						
		#endregion

	}
}
