#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   SessioniUtenti.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per SESSIONIUTENTI
//
// Autore:      AR - SDG srl
// Data:        07/10/2011
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
	/// Tabella SESSIONI_UTENTI 
	/// </summary>
	public class SessioniUtenti
	{
		#region attributi e variabili

	    private SqlInt32 ssu_id_sessione_utente = SqlInt32.Null;
        private SqlGuid ssu_id_sessione = SqlGuid.Null;
	    private SqlInt32 ute_id_utente = SqlInt32.Null;
	    private SqlDateTime ssu_data_last_ping = SqlDateTime.Null;
	    private SqlDateTime ssu_data_creazione = SqlDateTime.Null;        

		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Ssu_id_sessione_utente
		{
			get { return ssu_id_sessione_utente; }	
			set { ssu_id_sessione_utente = value; }
		}

		/// <value>
		/// 
		/// </value>
        public SqlGuid Ssu_id_sessione
		{
			get { return ssu_id_sessione; }	
			set { ssu_id_sessione = value; }
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
		public SqlDateTime Ssu_data_last_ping
		{
			get { return ssu_data_last_ping; }	
			set { ssu_data_last_ping = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Ssu_data_creazione
		{
			get { return ssu_data_creazione; }	
			set { ssu_data_creazione = value; }
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
		public SessioniUtenti()
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
					 SESSIONI_UTENTI.ssu_id_sessione_utente, 
					 SESSIONI_UTENTI.ssu_id_sessione, 
					 SESSIONI_UTENTI.ute_id_utente, 
					 SESSIONI_UTENTI.ssu_data_last_ping, 
					 SESSIONI_UTENTI.ssu_data_creazione	 
				 	 FROM SESSIONI_UTENTI WHERE SESSIONI_UTENTI.ssu_id_sessione = @ssu_id_sessione
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ssu_id_sessione", DbType.Guid, ssu_id_sessione);
				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					ssu_id_sessione_utente = reader.GetSqlInt32(0);
					ssu_id_sessione = reader.GetSqlGuid(1);
					ute_id_utente = reader.GetSqlInt32(2);
					ssu_data_last_ping = reader.GetSqlDateTime(3);
					ssu_data_creazione = reader.GetSqlDateTime(4);
				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "SessioniUtenti.Read.");
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

				sqlCommand = @" UPDATE SESSIONI_UTENTI SET
					 ssu_id_sessione_utente = @ssu_id_sessione_utente, 					 
					 ute_id_utente = @ute_id_utente, 
					 ssu_data_last_ping = @ssu_data_last_ping					 
					 WHERE ssu_id_sessione = @ssu_id_sessione 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "ssu_id_sessione_utente", DbType.Int32, ssu_id_sessione_utente);
				db.AddInParameter(dbCommand, "ssu_id_sessione", DbType.Guid, ssu_id_sessione);
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "ssu_data_last_ping", DbType.DateTime, ssu_data_last_ping);														
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "SessioniUtenti.Update.");
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

				sqlCommand = @" DELETE FROM SESSIONI_UTENTI WHERE SSU_ID_SESSIONE = @ssu_id_sessione
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ssu_id_sessione", DbType.Guid, ssu_id_sessione);						
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "SessioniUtenti.Delete.");
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
	
				sqlCommand = @" INSERT INTO SESSIONI_UTENTI (						
						ssu_id_sessione, 
						ute_id_utente, 
						ssu_data_last_ping, 
						ssu_data_creazione	 ) 
					VALUES ( 						
						@ssu_id_sessione, 
						@ute_id_utente, 
						getdate(), 
						getdate()) 

				";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);            				
				db.AddInParameter(dbCommand, "ssu_id_sessione", DbType.Guid, ssu_id_sessione);
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);				
				db.ExecuteNonQuery(dbCommand);

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "SessioniUtenti.Create.");
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
        /// Elenca tutti gli elementi SessioniUtenti dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "SESSIONI_UTENTI");
        }
		/// <summary>
		/// Elenca tutti gli elementi SessioniUtenti dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"SESSIONI_UTENTI");
		}
		/// <summary>
		/// Elenca tutti gli elementi SessioniUtenti dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					SESSIONI_UTENTI.ssu_id_sessione_utente, 
					SESSIONI_UTENTI.ssu_id_sessione, 
					SESSIONI_UTENTI.ute_id_utente, 
					SESSIONI_UTENTI.ssu_data_last_ping, 
					SESSIONI_UTENTI.ssu_data_creazione 
				FROM SESSIONI_UTENTI ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[0];                
				ds.Tables["SESSIONI_UTENTI"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "SessioniUtenti.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

        public int CountSessioni(int p_ute_id_utente)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;
            int NroSessioni = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT COUNT(ssu_id_sessione) AS NRO_SESSIONI
					 FROM SESSIONI_UTENTI WHERE SESSIONI_UTENTI.ute_id_utente = @ute_id_utente
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, p_ute_id_utente);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    ssu_id_sessione_utente = reader.GetSqlInt32(0);
                }

                NroSessioni = ssu_id_sessione_utente.Value;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "SessioniUtenti.Read.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }

            return NroSessioni;
        }	
		#endregion

	}
}
