#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   tracciamentoUpload.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per tracciamentoUpload
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
	/// Tabella tracciamento_upload 
	/// </summary>
	public class tracciamentoUpload
	{
		#region attributi e variabili

	    private SqlInt32 trc_id_tracciamento = SqlInt32.Null;
	    private SqlDateTime trc_data_caricamento = SqlDateTime.Null;
	    private SqlInt32 trc_nro_cessati = SqlInt32.Null;
	    private SqlInt32 trc_nro_nuovi = SqlInt32.Null;
	    private SqlInt32 trc_nro_aggiornati = SqlInt32.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Trc_id_tracciamento
		{
			get { return trc_id_tracciamento; }	
			set { trc_id_tracciamento = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Trc_data_caricamento
		{
			get { return trc_data_caricamento; }	
			set { trc_data_caricamento = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Trc_nro_cessati
		{
			get { return trc_nro_cessati; }	
			set { trc_nro_cessati = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Trc_nro_nuovi
		{
			get { return trc_nro_nuovi; }	
			set { trc_nro_nuovi = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Trc_nro_aggiornati
		{
			get { return trc_nro_aggiornati; }	
			set { trc_nro_aggiornati = value; }
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
		public tracciamentoUpload()
		{

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
					 tracciamento_upload.trc_id_tracciamento, 
					 tracciamento_upload.trc_data_caricamento, 
					 tracciamento_upload.trc_nro_cessati, 
					 tracciamento_upload.trc_nro_nuovi, 
					 tracciamento_upload.trc_nro_aggiornati	 
				 	 FROM tracciamento_upload WHERE 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					trc_id_tracciamento = reader.GetSqlInt32(0);
					trc_data_caricamento = reader.GetSqlDateTime(1);
					trc_nro_cessati = reader.GetSqlInt32(2);
					trc_nro_nuovi = reader.GetSqlInt32(3);
					trc_nro_aggiornati = reader.GetSqlInt32(4);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "tracciamentoUpload.Read.");
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

				sqlCommand = @" UPDATE tracciamento_upload SET
					 trc_id_tracciamento = @trc_id_tracciamento, 
					 trc_data_caricamento = @trc_data_caricamento, 
					 trc_nro_cessati = @trc_nro_cessati, 
					 trc_nro_nuovi = @trc_nro_nuovi, 
					 trc_nro_aggiornati = @trc_nro_aggiornati
					 WHERE   
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "trc_id_tracciamento", DbType.Int32, trc_id_tracciamento);
				db.AddInParameter(dbCommand, "trc_data_caricamento", DbType.DateTime, trc_data_caricamento);
				db.AddInParameter(dbCommand, "trc_nro_cessati", DbType.Int32, trc_nro_cessati);
				db.AddInParameter(dbCommand, "trc_nro_nuovi", DbType.Int32, trc_nro_nuovi);
				db.AddInParameter(dbCommand, "trc_nro_aggiornati", DbType.Int32, trc_nro_aggiornati);
										
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "tracciamentoUpload.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete()
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM tracciamento_upload WHERE 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "tracciamentoUpload.Delete.");
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
	
				sqlCommand = @" INSERT INTO tracciamento_upload (
						trc_id_tracciamento, 
						trc_data_caricamento, 
						trc_nro_cessati, 
						trc_nro_nuovi, 
						trc_nro_aggiornati	 ) 
					VALUES ( 
						@trc_id_tracciamento, 
						@trc_data_caricamento, 
						@trc_nro_cessati, 
						@trc_nro_nuovi, 
						@trc_nro_aggiornati	 ) 

				";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "trc_id_tracciamento", DbType.Int32, trc_id_tracciamento);
				db.AddInParameter(dbCommand, "trc_data_caricamento", DbType.DateTime, trc_data_caricamento);
				db.AddInParameter(dbCommand, "trc_nro_cessati", DbType.Int32, trc_nro_cessati);
				db.AddInParameter(dbCommand, "trc_nro_nuovi", DbType.Int32, trc_nro_nuovi);
				db.AddInParameter(dbCommand, "trc_nro_aggiornati", DbType.Int32, trc_nro_aggiornati);

				db.ExecuteNonQuery(dbCommand);

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "tracciamentoUpload.Create.");
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
        /// Elenca tutti gli elementi tracciamentoUpload dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "tracciamento_upload");
        }
		/// <summary>
		/// Elenca tutti gli elementi tracciamentoUpload dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"tracciamento_upload");
		}
		/// <summary>
		/// Elenca tutti gli elementi tracciamentoUpload dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					tracciamento_upload.trc_id_tracciamento, 
					tracciamento_upload.trc_data_caricamento, 
					tracciamento_upload.trc_nro_cessati, 
					tracciamento_upload.trc_nro_nuovi, 
					tracciamento_upload.trc_nro_aggiornati 
				FROM tracciamento_upload ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[0];                
				ds.Tables["tracciamento_upload"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "tracciamentoUpload.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}
						
		#endregion

	}
}
