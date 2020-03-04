#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   LookupStatoCaricamento.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per LOOKUPSTATOCARICAMENTO
//
// Autore:      AR - SDG srl
// Data:        23/11/2009
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
	/// Tabella LOOKUP_STATO_CARICAMENTO 
	/// </summary>
	public class LookupStatoCaricamento
	{
		#region attributi e variabili

	    private SqlInt32 lsc_id_stato_caricamento = SqlInt32.Null;
	    private SqlString lsc_descrizione_en = SqlString.Null;
	    private SqlString lsc_descrizione_it = SqlString.Null;
	    private SqlInt32 ute_creato_da = SqlInt32.Null;
	    private SqlInt32 ute_aggiornato_da = SqlInt32.Null;
	    private SqlInt32 lsc_flag_eliminato = SqlInt32.Null;
	    private SqlDateTime lsc_data_creazione = SqlDateTime.Null;
	    private SqlDateTime lsc_data_aggiornamento = SqlDateTime.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Lsc_id_stato_caricamento
		{
			get { return lsc_id_stato_caricamento; }	
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Lsc_descrizione_en
		{
			get { return lsc_descrizione_en; }	
			set { lsc_descrizione_en = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Lsc_descrizione_it
		{
			get { return lsc_descrizione_it; }	
			set { lsc_descrizione_it = value; }
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
		public SqlInt32 Lsc_flag_eliminato
		{
			get { return lsc_flag_eliminato; }	
			set { lsc_flag_eliminato = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Lsc_data_creazione
		{
			get { return lsc_data_creazione; }	
			set { lsc_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Lsc_data_aggiornamento
		{
			get { return lsc_data_aggiornamento; }	
			set { lsc_data_aggiornamento = value; }
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
		public LookupStatoCaricamento()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_lsc_id_stato_caricamento)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 LOOKUP_STATO_CARICAMENTO.lsc_id_stato_caricamento, 
					 LOOKUP_STATO_CARICAMENTO.lsc_descrizione_en, 
					 LOOKUP_STATO_CARICAMENTO.lsc_descrizione_it, 
					 LOOKUP_STATO_CARICAMENTO.ute_creato_da, 
					 LOOKUP_STATO_CARICAMENTO.ute_aggiornato_da, 
					 LOOKUP_STATO_CARICAMENTO.lsc_flag_eliminato, 
					 LOOKUP_STATO_CARICAMENTO.lsc_data_creazione, 
					 LOOKUP_STATO_CARICAMENTO.lsc_data_aggiornamento	 
				 	 FROM LOOKUP_STATO_CARICAMENTO WHERE 
					 (lsc_id_stato_caricamento = @lsc_id_stato_caricamento) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "lsc_id_stato_caricamento", DbType.Int32, p_lsc_id_stato_caricamento);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					lsc_id_stato_caricamento = reader.GetSqlInt32(0);
					lsc_descrizione_en = reader.GetSqlString(1);
					lsc_descrizione_it = reader.GetSqlString(2);
					ute_creato_da = reader.GetSqlInt32(3);
					ute_aggiornato_da = reader.GetSqlInt32(4);
					lsc_flag_eliminato = reader.GetSqlInt32(5);
					lsc_data_creazione = reader.GetSqlDateTime(6);
					lsc_data_aggiornamento = reader.GetSqlDateTime(7);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoCaricamento.Read.");
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
		public void Update(SqlInt32 p_lsc_id_stato_caricamento)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE LOOKUP_STATO_CARICAMENTO SET
					 lsc_descrizione_en = @lsc_descrizione_en, 
					 lsc_descrizione_it = @lsc_descrizione_it, 
					 ute_creato_da = @ute_creato_da, 
					 ute_aggiornato_da = @ute_aggiornato_da, 
					 lsc_flag_eliminato = @lsc_flag_eliminato, 
					 lsc_data_aggiornamento = getdate()
					 WHERE   
				     (lsc_id_stato_caricamento = @lsc_id_stato_caricamento) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "lsc_descrizione_en", DbType.String, lsc_descrizione_en);
				db.AddInParameter(dbCommand, "lsc_descrizione_it", DbType.String, lsc_descrizione_it);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);
				db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
				db.AddInParameter(dbCommand, "lsc_flag_eliminato", DbType.Int32, lsc_flag_eliminato);
										
				db.AddInParameter(dbCommand, "lsc_id_stato_caricamento", DbType.Int32, p_lsc_id_stato_caricamento);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoCaricamento.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete(SqlInt32 p_lsc_id_stato_caricamento)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM LOOKUP_STATO_CARICAMENTO WHERE 
					(lsc_id_stato_caricamento = @lsc_id_stato_caricamento) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "lsc_id_stato_caricamento", DbType.Int32, p_lsc_id_stato_caricamento);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoCaricamento.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}
		
		/// <summary>
		/// Crea l'oggetto corrispondente nella base dati.
		/// </summary>
		public void Create(SqlInt32 p_lsc_id_stato_caricamento) 
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			IDataReader dataReader = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
	
				sqlCommand = @" INSERT INTO LOOKUP_STATO_CARICAMENTO (
						lsc_descrizione_en, 
						lsc_descrizione_it, 
						ute_creato_da, 
						ute_aggiornato_da, 
						lsc_flag_eliminato, 
						lsc_data_creazione	 ) 
					VALUES ( 
						@lsc_descrizione_en, 
						@lsc_descrizione_it, 
						@ute_creato_da, 
						@ute_aggiornato_da, 
						@lsc_flag_eliminato, 
						getdate()	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "lsc_descrizione_en", DbType.String, lsc_descrizione_en);
				db.AddInParameter(dbCommand, "lsc_descrizione_it", DbType.String, lsc_descrizione_it);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);
				db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
				db.AddInParameter(dbCommand, "lsc_flag_eliminato", DbType.Int32, lsc_flag_eliminato);

				db.AddInParameter(dbCommand, "lsc_id_stato_caricamento", DbType.Int32, p_lsc_id_stato_caricamento);
 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					lsc_id_stato_caricamento = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "LookupStatoCaricamento.Create.");
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
        /// Elenca tutti gli elementi LookupStatoCaricamento dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "LOOKUP_STATO_CARICAMENTO");
        }
		/// <summary>
		/// Elenca tutti gli elementi LookupStatoCaricamento dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"LOOKUP_STATO_CARICAMENTO");
		}
		/// <summary>
		/// Elenca tutti gli elementi LookupStatoCaricamento dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					LOOKUP_STATO_CARICAMENTO.lsc_id_stato_caricamento, 
					LOOKUP_STATO_CARICAMENTO.lsc_descrizione_en, 
					LOOKUP_STATO_CARICAMENTO.lsc_descrizione_it, 
					LOOKUP_STATO_CARICAMENTO.ute_creato_da, 
					LOOKUP_STATO_CARICAMENTO.ute_aggiornato_da, 
					LOOKUP_STATO_CARICAMENTO.lsc_flag_eliminato, 
					LOOKUP_STATO_CARICAMENTO.lsc_data_creazione, 
					LOOKUP_STATO_CARICAMENTO.lsc_data_aggiornamento 
				FROM LOOKUP_STATO_CARICAMENTO ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["LOOKUP_STATO_CARICAMENTO"].Columns["lsc_id_stato_caricamento"];
				ds.Tables["LOOKUP_STATO_CARICAMENTO"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoCaricamento.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}
						
		#endregion

	}
}
