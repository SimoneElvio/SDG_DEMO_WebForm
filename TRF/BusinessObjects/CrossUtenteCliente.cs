#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TAF
// Nome File:   CrossUtenteCliente.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per CROSSUTENTECLIENTE
//
// Autore:      AR - SDG srl
// Data:        09/09/2010
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
	/// Tabella CROSS_UTENTE_CLIENTE 
	/// </summary>
	public class CrossUtenteCliente
	{
		#region attributi e variabili

	    private SqlInt32 cuc_id_cross_utente_cliente = SqlInt32.Null;
	    private SqlInt32 cli_id_cliente = SqlInt32.Null;
	    private SqlInt32 ute_id_utente = SqlInt32.Null;
	    private SqlInt32 cuc_flag_eliminato = SqlInt32.Null;
	    private SqlDateTime cuc_data_creazione = SqlDateTime.Null;
	    private SqlDateTime cuc_data_aggiornamento = SqlDateTime.Null;
	    private SqlInt32 ute_creato_da = SqlInt32.Null;
	    private SqlInt32 ute_aggiornato_da = SqlInt32.Null;
        private SqlInt32 cuc_flag_stato = SqlInt32.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cuc_id_cross_utente_cliente
		{
			get { return cuc_id_cross_utente_cliente; }           
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cli_id_cliente
		{
			get { return cli_id_cliente; }	
			set { cli_id_cliente = value; }
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
		public SqlInt32 Cuc_flag_eliminato
		{
			get { return cuc_flag_eliminato; }	
			set { cuc_flag_eliminato = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cuc_flag_stato
        {
            get { return cuc_flag_stato; }
            set { cuc_flag_stato = value; }
        }

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Cuc_data_creazione
		{
			get { return cuc_data_creazione; }	
			set { cuc_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Cuc_data_aggiornamento
		{
			get { return cuc_data_aggiornamento; }	
			set { cuc_data_aggiornamento = value; }
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
		public CrossUtenteCliente()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_cuc_id_cross_utente_cliente)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 CROSS_UTENTE_CLIENTE.cuc_id_cross_utente_cliente, 
					 CROSS_UTENTE_CLIENTE.cli_id_cliente, 
					 CROSS_UTENTE_CLIENTE.ute_id_utente, 
					 CROSS_UTENTE_CLIENTE.cuc_flag_eliminato, 
					 CROSS_UTENTE_CLIENTE.cuc_data_creazione, 
					 CROSS_UTENTE_CLIENTE.cuc_data_aggiornamento, 
					 CROSS_UTENTE_CLIENTE.ute_creato_da, 
					 CROSS_UTENTE_CLIENTE.ute_aggiornato_da,
                     CROSS_UTENTE_CLIENTE.cuc_flag_stato
				 	 FROM CROSS_UTENTE_CLIENTE WHERE 
					 (cuc_id_cross_utente_cliente = @cuc_id_cross_utente_cliente) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "cuc_id_cross_utente_cliente", DbType.Int32, p_cuc_id_cross_utente_cliente);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					cuc_id_cross_utente_cliente = reader.GetSqlInt32(0);
					cli_id_cliente = reader.GetSqlInt32(1);
					ute_id_utente = reader.GetSqlInt32(2);
					cuc_flag_eliminato = reader.GetSqlInt32(3);
					cuc_data_creazione = reader.GetSqlDateTime(4);
					cuc_data_aggiornamento = reader.GetSqlDateTime(5);
					ute_creato_da = reader.GetSqlInt32(6);
					ute_aggiornato_da = reader.GetSqlInt32(7);
                    cuc_flag_stato = reader.GetSqlInt32(8);
				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteCliente.Read.");
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
		public void Update(SqlInt32 p_cuc_id_cross_utente_cliente)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE CROSS_UTENTE_CLIENTE SET
					 cli_id_cliente = @cli_id_cliente, 
					 ute_id_utente = @ute_id_utente, 					  
					 cuc_data_aggiornamento = getdate(), 
					 ute_aggiornato_da = @ute_aggiornato_da,
                     cuc_flag_stato = @cuc_flag_stato
					 WHERE   
				     (cuc_id_cross_utente_cliente = @cuc_id_cross_utente_cliente) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "cuc_flag_eliminato", DbType.Int32, cuc_flag_eliminato);
				db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
                db.AddInParameter(dbCommand, "cuc_flag_stato", DbType.Int32, cuc_flag_stato);
										
				db.AddInParameter(dbCommand, "cuc_id_cross_utente_cliente", DbType.Int32, p_cuc_id_cross_utente_cliente);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteCliente.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}


        public void UpdateMultiSelection()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE CROSS_UTENTE_CLIENTE SET					 					  
					 cuc_data_aggiornamento = getdate(), 
					 ute_aggiornato_da = @ute_aggiornato_da,
                     cuc_flag_stato = @cuc_flag_stato
					 WHERE   
				     (cli_id_cliente = @cli_id_cliente AND ute_id_utente=@ute_id_utente) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "cuc_flag_eliminato", DbType.Int32, cuc_flag_eliminato);
                db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
                db.AddInParameter(dbCommand, "cuc_flag_stato", DbType.Int32, cuc_flag_stato);                

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CrossUtenteCliente.UpdateMultiSelection.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
		public  void Delete(SqlInt32 p_cuc_id_cross_utente_cliente)
		{
			Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
			DbConnection c =  db.CreateConnection();
			DbTransaction t = null;

			try
			{
				c.Open();
				t = c.BeginTransaction();

				Delete( p_cuc_id_cross_utente_cliente, t);

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
					ex2.Data.Add("Class.Method", "CrossUtenteCliente.Delete.Rollback");
					ex2.Data.Add("SQL", "Rollback error");
				}
				ex.Data.Add("Class.Method", "CrossUtenteCliente.Delete.");
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
        public  void Delete(SqlInt32 p_cuc_id_cross_utente_cliente, DbTransaction transaction)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE CROSS_UTENTE_CLIENTE SET CUC_FLAG_ELIMINATO = 1 WHERE 
					(cuc_id_cross_utente_cliente = @cuc_id_cross_utente_cliente) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "cuc_id_cross_utente_cliente", DbType.Int32, p_cuc_id_cross_utente_cliente);
										
				db.ExecuteNonQuery(dbCommand, transaction);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteCliente.Delete.");
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
	
				sqlCommand = @" INSERT INTO CROSS_UTENTE_CLIENTE (
						cli_id_cliente, 
						ute_id_utente, 
						cuc_flag_eliminato, 
						cuc_data_creazione, 
						ute_creato_da,cuc_flag_stato	 ) 
					VALUES ( 
						@cli_id_cliente, 
						@ute_id_utente, 
						0, 
						getdate(), 
						@ute_creato_da,@cuc_flag_stato	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "cuc_flag_eliminato", DbType.Int32, cuc_flag_eliminato);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);
                db.AddInParameter(dbCommand, "cuc_flag_stato", DbType.Int32, cuc_flag_stato);

 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					cuc_id_cross_utente_cliente = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "CrossUtenteCliente.Create.");
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
		/// Elenca tutti gli elementi CrossUtenteCliente dell'analisi. L'utente può scegliere il nome della tabella nel dataset
		/// </summary>
        public DataSet List(int myParUteIdUtente,string subWhereClause) 
		{
			string sqlCommand = null;
			StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
            DataSet ds = new DataSet();
			
			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            
				sb.Append(@" SELECT 
					CROSS_UTENTE_CLIENTE.cuc_id_cross_utente_cliente, 
                    CLIENTI.CLI_RAGIONE_SOCIALE,
                    CLIENTI.CLI_ACRONIMO,
                    CROSS_UTENTE_CLIENTE.cli_id_cliente, 
					CROSS_UTENTE_CLIENTE.ute_id_utente, 
					CROSS_UTENTE_CLIENTE.cuc_flag_eliminato, 
					CROSS_UTENTE_CLIENTE.cuc_data_creazione, 
					CROSS_UTENTE_CLIENTE.cuc_data_aggiornamento, 
					CROSS_UTENTE_CLIENTE.ute_creato_da, 
					CROSS_UTENTE_CLIENTE.ute_aggiornato_da, 
                    CROSS_UTENTE_CLIENTE.cuc_flag_stato
				FROM CROSS_UTENTE_CLIENTE INNER JOIN CLIENTI ON CROSS_UTENTE_CLIENTE.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE
                WHERE CROSS_UTENTE_CLIENTE.UTE_ID_UTENTE = @myParUteIdUtente ");				
                sb.Append(" AND CROSS_UTENTE_CLIENTE.CUC_FLAG_ELIMINATO = 0 ");
                sb.Append(subWhereClause);
                sqlCommand = sb.ToString();
				dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParUteIdUtente", DbType.Int32, myParUteIdUtente);
				db.LoadDataSet(dbCommand, ds, "CROSS_UTENTE_CLIENTE");
				
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteCliente.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

        /// <summary>
        /// Elenca tutti gli elementi CrossUtenteCliente dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public DataSet ListXSite(int myParUteIdUtente)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					CROSS_UTENTE_CLIENTE.cuc_id_cross_utente_cliente, 
					CLIENTI.CLI_RAGIONE_SOCIALE,
                    CROSS_UTENTE_CLIENTE.cli_id_cliente, 
					CROSS_UTENTE_CLIENTE.ute_id_utente, 																									
                    CROSS_UTENTE_CLIENTE.cuc_flag_stato,
                    CLIENTI.cli_logo_cliente
				    FROM CROSS_UTENTE_CLIENTE INNER JOIN CLIENTI ON CROSS_UTENTE_CLIENTE.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE
                    WHERE CROSS_UTENTE_CLIENTE.UTE_ID_UTENTE = @myParUteIdUtente AND CLIENTI.CLI_FLAG_STATO = 1 ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }
                sb.Append(" AND CROSS_UTENTE_CLIENTE.CUC_FLAG_ELIMINATO = 0 ORDER BY CLIENTI.CLI_RAGIONE_SOCIALE ASC ");
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParUteIdUtente", DbType.Int32, myParUteIdUtente);
                db.LoadDataSet(dbCommand, ds, "CROSS_UTENTE_CLIENTE");

            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CrossUtenteCliente.ListXSite.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

		/// <summary>
        /// Elenca tutti gli elementi CrossUtenteCliente dell'analisi con tutte le tabelle collegate. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet ListForExport()
        {
            return ListForExport(string.Empty, "CROSS_UTENTE_CLIENTE");
        }
		/// <summary>
		/// Elenca tutti gli elementi CrossUtenteCliente dell'analisi con tutte le tabelle collegate. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet ListForExport(string sqlWhereClause) 
		{
			return ListForExport(sqlWhereClause,"CROSS_UTENTE_CLIENTE");
		}
		/// <summary>
		/// Elenca tutti gli elementi CrossUtenteCliente dell'analisi con tutte le tabelle collegate. L'utente può scegliere il nome della tabella nel dataset
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
					CROSS_UTENTE_CLIENTE.cuc_id_cross_utente_cliente AS [id_cross_utente_cliente], 
					CROSS_UTENTE_CLIENTE.cli_id_cliente AS [id_cliente], 
					CROSS_UTENTE_CLIENTE.ute_id_utente AS [id_utente], 
					CROSS_UTENTE_CLIENTE.cuc_flag_eliminato AS [flag_eliminato], 
					CONVERT(CHAR(10),CROSS_UTENTE_CLIENTE.cuc_data_creazione,103) AS [data_creazione], 
					CONVERT(CHAR(10),CROSS_UTENTE_CLIENTE.cuc_data_aggiornamento,103) AS [data_aggiornamento], 
					CROSS_UTENTE_CLIENTE.ute_creato_da AS [creato_da], 
					CROSS_UTENTE_CLIENTE.ute_aggiornato_da AS [aggiornato_da] 
				    FROM CROSS_UTENTE_CLIENTE
				    LEFT JOIN CLIENTI ON CROSS_UTENTE_CLIENTE.cli_id_cliente = CLIENTI.cli_id_cliente
				    LEFT JOIN UTENTE ON CROSS_UTENTE_CLIENTE.ute_id_utente = UTENTE.ute_id_utente 				");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables[tableName].Columns["cuc_id_cross_utente_cliente"];
				ds.Tables[tableName].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossUtenteCliente.ListForExport.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

		#endregion

	}
}
