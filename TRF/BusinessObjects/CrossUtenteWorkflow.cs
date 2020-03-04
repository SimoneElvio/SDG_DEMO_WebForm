#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TAF
// Nome File:   CrossUtenteWorkflow.cs
//
// Namespace:   TRF.Portale Richieste
// Descrizione: Classe per CROSSUTENTEWORKFLOW
//
// Autore:      AR - SDG srl
// Data:        02/09/2010
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
	/// Tabella CROSS_UTENTE_WORKFLOW 
	/// </summary>
	public class CrossUtenteWorkflow
	{
		#region attributi e variabili

	    private SqlInt32 cuw_id_utente_workflow = SqlInt32.Null;
	    private SqlInt32 ute_id_utente = SqlInt32.Null;
	    private SqlInt32 wrf_id_workflow = SqlInt32.Null;
	    private SqlInt32 ute_creato_da = SqlInt32.Null;
	    private SqlInt32 ute_aggiornato_da = SqlInt32.Null;
	    private SqlDateTime cuw_data_creazione = SqlDateTime.Null;
	    private SqlDateTime cuw_data_aggiornamento = SqlDateTime.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cuw_id_utente_workflow
		{
			get { return cuw_id_utente_workflow; }	
		}

		/// <value>
		/// Identificatore dell'utente che viene replicato in tutte le tabelle.
		/// </value>
		public SqlInt32 Ute_id_utente
		{
			get { return ute_id_utente; }	
			set { ute_id_utente = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Wrf_id_workflow
		{
			get { return wrf_id_workflow; }	
			set { wrf_id_workflow = value; }
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
		public SqlDateTime Cuw_data_creazione
		{
			get { return cuw_data_creazione; }	
			set { cuw_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Cuw_data_aggiornamento
		{
			get { return cuw_data_aggiornamento; }	
			set { cuw_data_aggiornamento = value; }
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
		public CrossUtenteWorkflow()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_cuw_id_utente_workflow)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 CROSS_UTENTE_WORKFLOW.cuw_id_utente_workflow, 
					 CROSS_UTENTE_WORKFLOW.ute_id_utente, 
					 CROSS_UTENTE_WORKFLOW.wrf_id_workflow, 
					 CROSS_UTENTE_WORKFLOW.ute_creato_da, 
					 CROSS_UTENTE_WORKFLOW.ute_aggiornato_da, 
					 CROSS_UTENTE_WORKFLOW.cuw_data_creazione, 
					 CROSS_UTENTE_WORKFLOW.cuw_data_aggiornamento	 
				 	 FROM CROSS_UTENTE_WORKFLOW WHERE 
					 (cuw_id_utente_workflow = @cuw_id_utente_workflow) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "cuw_id_utente_workflow", DbType.Int32, p_cuw_id_utente_workflow);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					cuw_id_utente_workflow = reader.GetSqlInt32(0);
					ute_id_utente = reader.GetSqlInt32(1);
					wrf_id_workflow = reader.GetSqlInt32(2);
					ute_creato_da = reader.GetSqlInt32(3);
					ute_aggiornato_da = reader.GetSqlInt32(4);
					cuw_data_creazione = reader.GetSqlDateTime(5);
					cuw_data_aggiornamento = reader.GetSqlDateTime(6);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteWorkflow.Read.");
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
		/// Aggiorna l'oggetto nella base dati
		/// </summary>	
		public void Update(SqlInt32 p_cuw_id_utente_workflow)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE CROSS_UTENTE_WORKFLOW SET
					 ute_id_utente = @ute_id_utente, 
					 wrf_id_workflow = @wrf_id_workflow, 
					 ute_aggiornato_da = @ute_aggiornato_da, 
					 cuw_data_aggiornamento = getdate()
					 WHERE   
				     (cuw_id_utente_workflow = @cuw_id_utente_workflow) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "wrf_id_workflow", DbType.Int32, wrf_id_workflow);
				db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
										
				db.AddInParameter(dbCommand, "cuw_id_utente_workflow", DbType.Int32, p_cuw_id_utente_workflow);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteWorkflow.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
		public void Delete(SqlInt32 p_cuw_id_utente_workflow)
		{
			Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
			DbConnection c =  db.CreateConnection();
			DbTransaction t = null;

			try
			{
				c.Open();
				t = c.BeginTransaction();

				Delete( p_cuw_id_utente_workflow, t);

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
					ex2.Data.Add("Class.Method", "CrossUtenteWorkflow.Delete.Rollback");
					ex2.Data.Add("SQL", "Rollback error");
				}
				ex.Data.Add("Class.Method", "CrossUtenteWorkflow.Delete.");
				ex.Data.Add("SQL", ex.Message);

				// Gestione messaggistica all'utente e trace in DB dell'errore
				ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
			finally
			{
				c.Close();
			}
		}
	
		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public void Delete(SqlInt32 p_cuw_id_utente_workflow, DbTransaction transaction)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM CROSS_UTENTE_WORKFLOW WHERE 
					(cuw_id_utente_workflow = @cuw_id_utente_workflow) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "cuw_id_utente_workflow", DbType.Int32, p_cuw_id_utente_workflow);
										
				db.ExecuteNonQuery(dbCommand, transaction);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteWorkflow.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

        public void DeleteWorkflowUtente(SqlInt32 idUtente)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM CROSS_UTENTE_WORKFLOW WHERE 
					(ute_id_utente = @ute_id_utente) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, idUtente);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CrossUtenteWorkflow.DeleteWorkflowUtente.");
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
	
				sqlCommand = @" INSERT INTO CROSS_UTENTE_WORKFLOW (
						ute_id_utente, 
						wrf_id_workflow, 
						ute_creato_da, 
						cuw_data_creazione	 ) 
					VALUES ( 
						@ute_id_utente, 
						@wrf_id_workflow, 
						@ute_creato_da, 
						getdate()	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "wrf_id_workflow", DbType.Int32, wrf_id_workflow);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);

 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					cuw_id_utente_workflow = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "CrossUtenteWorkflow.Create.");
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
        /// Crea i Workflow prendendoli da quelli impostati come "default" sul Cliente/Società
        /// </summary>
        /// <param name="p_cli_id_cliente"></param>
        public void CreateByDefaultCliente(int p_cli_id_cliente, Database db, DbTransaction t)
        {
            StringBuilder sb = new StringBuilder();
            DbCommand dbCommand = null;

            try
            {
                sb.Append(@" INSERT INTO CROSS_UTENTE_WORKFLOW (
						        ute_id_utente, 
						        wrf_id_workflow, 
						        ute_creato_da, 
						        cuw_data_creazione ) 
					        SELECT 
						        @ute_id_utente, 
						        WRF_ID_WORKFLOW, 
						        @ute_creato_da, 
						        getdate() 
                            FROM CROSS_CLIENTE_WORKFLOW
                            WHERE cli_id_cliente = 1
                                AND ccw_flag_eliminato = 0
                                AND ccw_flag_default = 1 ");

                dbCommand = db.GetSqlStringCommand(sb.ToString());

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);

                db.ExecuteNonQuery(dbCommand, t);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CrossUtenteWorkflow.CreateByDefaultCliente.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi CrossUtenteWorkflow dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public DataSet List(int myParUteIdUtente) 
		{
			string sqlCommand = null;
			StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
            DataSet ds = new DataSet();
			
			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            
				sb.Append(@" SELECT 
					CROSS_UTENTE_WORKFLOW.cuw_id_utente_workflow, 
					CROSS_UTENTE_WORKFLOW.ute_id_utente, 
					CROSS_UTENTE_WORKFLOW.wrf_id_workflow, 
					CROSS_UTENTE_WORKFLOW.ute_creato_da, 
					CROSS_UTENTE_WORKFLOW.ute_aggiornato_da, 
					CROSS_UTENTE_WORKFLOW.cuw_data_creazione, 
					CROSS_UTENTE_WORKFLOW.cuw_data_aggiornamento,
                    WORKFLOW.WRF_CODICE,WORKFLOW.WRF_DESCRIZIONE 
				    FROM CROSS_UTENTE_WORKFLOW 
                    INNER JOIN WORKFLOW ON CROSS_UTENTE_WORKFLOW.WRF_ID_WORKFLOW = WORKFLOW.WRF_ID_WORKFLOW 
                    WHERE UTE_ID_UTENTE = @myParUteIdUtente ");
			
				sqlCommand = sb.ToString();
				dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParUteIdUtente", DbType.Int32, myParUteIdUtente);
				db.LoadDataSet(dbCommand, ds, "CROSS_UTENTE_WORKFLOW");
				
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteWorkflow.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

		/// <summary>
        /// Elenca tutti gli elementi CrossUtenteWorkflow dell'analisi con tutte le tabelle collegate. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet ListForExport()
        {
            return ListForExport(string.Empty, "CROSS_UTENTE_WORKFLOW");
        }
		/// <summary>
		/// Elenca tutti gli elementi CrossUtenteWorkflow dell'analisi con tutte le tabelle collegate. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet ListForExport(string sqlWhereClause) 
		{
			return ListForExport(sqlWhereClause,"CROSS_UTENTE_WORKFLOW");
		}
		/// <summary>
		/// Elenca tutti gli elementi CrossUtenteWorkflow dell'analisi con tutte le tabelle collegate. L'utente può scegliere il nome della tabella nel dataset
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
					CROSS_UTENTE_WORKFLOW.cuw_id_utente_workflow AS [id_utente_workflow], 
					CROSS_UTENTE_WORKFLOW.ute_id_utente AS [id_utente], 
					CROSS_UTENTE_WORKFLOW.wrf_id_workflow AS [id_workflow], 
					CROSS_UTENTE_WORKFLOW.ute_creato_da AS [creato_da], 
					CROSS_UTENTE_WORKFLOW.ute_aggiornato_da AS [aggiornato_da], 
					CONVERT(CHAR(10),CROSS_UTENTE_WORKFLOW.cuw_data_creazione,103) AS [data_creazione], 
					CONVERT(CHAR(10),CROSS_UTENTE_WORKFLOW.cuw_data_aggiornamento,103) AS [data_aggiornamento] 
				FROM CROSS_UTENTE_WORKFLOW
				LEFT JOIN UTENTE ON CROSS_UTENTE_WORKFLOW.ute_id_utente = UTENTE.ute_id_utente
				LEFT JOIN WORKFLOW ON CROSS_UTENTE_WORKFLOW.wrf_id_workflow = WORKFLOW.wrf_id_workflow 				");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables[tableName].Columns["cuw_id_utente_workflow"];
				ds.Tables[tableName].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteWorkflow.ListForExport.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

		#endregion

	}
}
