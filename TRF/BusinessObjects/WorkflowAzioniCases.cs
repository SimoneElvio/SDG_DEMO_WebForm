#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Missyo
// Nome File:   WorkflowAzioniCases.cs
//
// Namespace:   BusinessObjects.Anagrafiche
// Descrizione: Classe per WORKFLOWAZIONICASES
//
// Autore:      SE - SDG srl
// Data:        02/02/2018
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

namespace BusinessObjects.Anagrafiche
{
	/// <summary>
	/// Tabella WORKFLOW_AZIONI_CASES 
	/// </summary>
	public class WorkflowAzioniCases
	{
		#region attributi e variabili

	    private SqlInt32 wfw_id_case_azioni = SqlInt32.Null;
	    private SqlInt32 ute_id_utente = SqlInt32.Null;
	    private SqlInt32 wfa_id_azione = SqlInt32.Null;
	    private SqlInt32 ioa_id_oggetto = SqlInt32.Null;
	    private SqlString wfw_codice_azione = SqlString.Null;
	    private SqlString wfw_from = SqlString.Null;
	    private SqlString wfw_metodo = SqlString.Null;
	    private SqlString wfw_oggetto = SqlString.Null;
	    private SqlString wfw_testo = SqlString.Null;
	    private SqlInt32 wfw_priorita = SqlInt32.Null;
	    private SqlDateTime wfw_data_schedulata = SqlDateTime.Null;
	    private SqlDateTime wfw_data_effettuazione = SqlDateTime.Null;
	    private SqlDateTime wfw_data_creazione = SqlDateTime.Null;
	    private SqlString wfw_to = SqlString.Null;
	    private SqlString wfw_cc = SqlString.Null;
	    private SqlString wfw_ccn = SqlString.Null;
	    private SqlInt32 wfw_raggruppa_per_destinatario = SqlInt32.Null;
	    private SqlInt32 wfw_timeout = SqlInt32.Null;
	    private SqlString wfw_classe = SqlString.Null;
	    private SqlInt32 wfw_stato_esecuzione = SqlInt32.Null;
	    private SqlInt32 wfs_id_stato = SqlInt32.Null;
	    private SqlInt32 sta_wfs_id_stato = SqlInt32.Null;
	    private SqlString wfw_partizionamento = SqlString.Null;
	    private SqlString wfw_sql_for_file = SqlString.Null;
	    private SqlInt32 wfw_file_generated = SqlInt32.Null;
	    private SqlInt32 wfw_expect_file = SqlInt32.Null;
	    private SqlString wfw_lingua = SqlString.Null;
        private SqlInt64 wfw_lock = SqlInt64.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Wfw_id_case_azioni
		{
			get { return wfw_id_case_azioni; }	
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
		public SqlInt32 Wfa_id_azione
		{
			get { return wfa_id_azione; }	
			set { wfa_id_azione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Ioa_id_oggetto
		{
			get { return ioa_id_oggetto; }	
			set { ioa_id_oggetto = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_codice_azione
		{
			get { return wfw_codice_azione; }	
			set { wfw_codice_azione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_from
		{
			get { return wfw_from; }	
			set { wfw_from = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_metodo
		{
			get { return wfw_metodo; }	
			set { wfw_metodo = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_oggetto
		{
			get { return wfw_oggetto; }	
			set { wfw_oggetto = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_testo
		{
			get { return wfw_testo; }	
			set { wfw_testo = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Wfw_priorita
		{
			get { return wfw_priorita; }	
			set { wfw_priorita = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Wfw_data_schedulata
		{
			get { return wfw_data_schedulata; }	
			set { wfw_data_schedulata = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Wfw_data_effettuazione
		{
			get { return wfw_data_effettuazione; }	
			set { wfw_data_effettuazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Wfw_data_creazione
		{
			get { return wfw_data_creazione; }	
			set { wfw_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_to
		{
			get { return wfw_to; }	
			set { wfw_to = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_cc
		{
			get { return wfw_cc; }	
			set { wfw_cc = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_ccn
		{
			get { return wfw_ccn; }	
			set { wfw_ccn = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Wfw_raggruppa_per_destinatario
		{
			get { return wfw_raggruppa_per_destinatario; }	
			set { wfw_raggruppa_per_destinatario = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Wfw_timeout
		{
			get { return wfw_timeout; }	
			set { wfw_timeout = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_classe
		{
			get { return wfw_classe; }	
			set { wfw_classe = value; }
		}


		/// <value>
		/// 
		/// </value>
		public SqlInt32 Wfw_stato_esecuzione
		{
			get { return wfw_stato_esecuzione; }	
			set { wfw_stato_esecuzione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Wfs_id_stato
		{
			get { return wfs_id_stato; }	
			set { wfs_id_stato = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Sta_wfs_id_stato
		{
			get { return sta_wfs_id_stato; }	
			set { sta_wfs_id_stato = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_partizionamento
		{
			get { return wfw_partizionamento; }	
			set { wfw_partizionamento = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_sql_for_file
		{
			get { return wfw_sql_for_file; }	
			set { wfw_sql_for_file = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Wfw_file_generated
		{
			get { return wfw_file_generated; }	
			set { wfw_file_generated = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Wfw_expect_file
		{
			get { return wfw_expect_file; }	
			set { wfw_expect_file = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Wfw_lingua
		{
			get { return wfw_lingua; }	
			set { wfw_lingua = value; }
		}


        /// <value>
        /// 
        /// </value>
        public SqlInt64 Wfw_lock
        {
            get { return wfw_lock; }
            set { wfw_lock = value; }
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
		public WorkflowAzioniCases()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_wfw_id_case_azioni)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 WORKFLOW_AZIONI_CASES.wfw_id_case_azioni, 
					 WORKFLOW_AZIONI_CASES.ute_id_utente, 
					 WORKFLOW_AZIONI_CASES.wfa_id_azione, 
					 WORKFLOW_AZIONI_CASES.ioa_id_oggetto, 
					 WORKFLOW_AZIONI_CASES.wfw_codice_azione, 
					 WORKFLOW_AZIONI_CASES.wfw_from, 
					 WORKFLOW_AZIONI_CASES.wfw_metodo, 
					 WORKFLOW_AZIONI_CASES.wfw_oggetto, 
					 WORKFLOW_AZIONI_CASES.wfw_testo, 
					 WORKFLOW_AZIONI_CASES.wfw_priorita, 
					 WORKFLOW_AZIONI_CASES.wfw_data_schedulata, 
					 WORKFLOW_AZIONI_CASES.wfw_data_effettuazione, 
					 WORKFLOW_AZIONI_CASES.wfw_data_creazione, 
					 WORKFLOW_AZIONI_CASES.wfw_to, 
					 WORKFLOW_AZIONI_CASES.wfw_cc, 
					 WORKFLOW_AZIONI_CASES.wfw_ccn, 
					 WORKFLOW_AZIONI_CASES.wfw_raggruppa_per_destinatario, 
					 WORKFLOW_AZIONI_CASES.wfw_timeout, 
					 WORKFLOW_AZIONI_CASES.wfw_classe, 
					 WORKFLOW_AZIONI_CASES.wfw_stato_esecuzione, 
					 WORKFLOW_AZIONI_CASES.wfs_id_stato, 
					 WORKFLOW_AZIONI_CASES.sta_wfs_id_stato, 
					 WORKFLOW_AZIONI_CASES.wfw_partizionamento, 
					 WORKFLOW_AZIONI_CASES.wfw_sql_for_file, 
					 WORKFLOW_AZIONI_CASES.wfw_file_generated, 
					 WORKFLOW_AZIONI_CASES.wfw_expect_file, 
					 WORKFLOW_AZIONI_CASES.wfw_lingua,
                     WORKFLOW_AZIONI_CASES.wfw_lock	 
				 	 FROM WORKFLOW_AZIONI_CASES WHERE 
					 (wfw_id_case_azioni = @wfw_id_case_azioni) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "wfw_id_case_azioni", DbType.Int32, p_wfw_id_case_azioni);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					int i = 0;
					wfw_id_case_azioni = reader.GetSqlInt32(i++);
					ute_id_utente = reader.GetSqlInt32(i++);
					wfa_id_azione = reader.GetSqlInt32(i++);
					ioa_id_oggetto = reader.GetSqlInt32(i++);
					wfw_codice_azione = reader.GetSqlString(i++);
					wfw_from = reader.GetSqlString(i++);
					wfw_metodo = reader.GetSqlString(i++);
					wfw_oggetto = reader.GetSqlString(i++);
					wfw_testo = reader.GetSqlString(i++);
					wfw_priorita = reader.GetSqlInt32(i++);
					wfw_data_schedulata = reader.GetSqlDateTime(i++);
					wfw_data_effettuazione = reader.GetSqlDateTime(i++);
					wfw_data_creazione = reader.GetSqlDateTime(i++);
					wfw_to = reader.GetSqlString(i++);
					wfw_cc = reader.GetSqlString(i++);
					wfw_ccn = reader.GetSqlString(i++);
					wfw_raggruppa_per_destinatario = reader.GetSqlInt32(i++);
					wfw_timeout = reader.GetSqlInt32(i++);
					wfw_classe = reader.GetSqlString(i++);
					wfw_stato_esecuzione = reader.GetSqlInt32(i++);
					wfs_id_stato = reader.GetSqlInt32(i++);
					sta_wfs_id_stato = reader.GetSqlInt32(i++);
					wfw_partizionamento = reader.GetSqlString(i++);
					wfw_sql_for_file = reader.GetSqlString(i++);
					wfw_file_generated = reader.GetSqlInt32(i++);
					wfw_expect_file = reader.GetSqlInt32(i++);
					wfw_lingua = reader.GetSqlString(i++);
                    wfw_lock = reader.GetSqlInt64(i++);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "WorkflowAzioniCases.Read.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
				throw ex;
			}

			finally
			{
				if(reader != null)
				{
					((IDisposable)reader).Dispose();
					dbCommand.Connection.Close();
				}
			}
		}
		
		/// <summary>
		/// Aggiorna l'oggetto nella base dati
		/// </summary>	
		public void Update(SqlInt32 p_wfw_id_case_azioni)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE WORKFLOW_AZIONI_CASES SET
					 ute_id_utente = @ute_id_utente, 
					 wfa_id_azione = @wfa_id_azione, 
					 ioa_id_oggetto = @ioa_id_oggetto, 
					 wfw_codice_azione = @wfw_codice_azione, 
					 wfw_from = @wfw_from, 
					 wfw_metodo = @wfw_metodo, 
					 wfw_oggetto = @wfw_oggetto, 
					 wfw_testo = @wfw_testo, 
					 wfw_priorita = @wfw_priorita, 
					 wfw_data_schedulata = @wfw_data_schedulata, 
					 wfw_data_effettuazione = @wfw_data_effettuazione, 
					 wfw_data_creazione = @wfw_data_creazione, 
					 wfw_to = @wfw_to, 
					 wfw_cc = @wfw_cc, 
					 wfw_ccn = @wfw_ccn, 
					 wfw_raggruppa_per_destinatario = @wfw_raggruppa_per_destinatario, 
					 wfw_timeout = @wfw_timeout, 
					 wfw_classe = @wfw_classe, 
					 wfw_stato_esecuzione = @wfw_stato_esecuzione, 
					 wfs_id_stato = @wfs_id_stato, 
					 sta_wfs_id_stato = @sta_wfs_id_stato, 
					 wfw_partizionamento = @wfw_partizionamento, 
					 wfw_sql_for_file = @wfw_sql_for_file, 
					 wfw_file_generated = @wfw_file_generated, 
					 wfw_expect_file = @wfw_expect_file, 
					 wfw_lingua = @wfw_lingua,
                     wfw_lock=@wfw_lock
					 WHERE   
				     (wfw_id_case_azioni = @wfw_id_case_azioni) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "wfa_id_azione", DbType.Int32, wfa_id_azione);
				db.AddInParameter(dbCommand, "ioa_id_oggetto", DbType.Int32, ioa_id_oggetto);
				db.AddInParameter(dbCommand, "wfw_codice_azione", DbType.String, wfw_codice_azione);
				db.AddInParameter(dbCommand, "wfw_from", DbType.String, wfw_from);
				db.AddInParameter(dbCommand, "wfw_metodo", DbType.String, wfw_metodo);
				db.AddInParameter(dbCommand, "wfw_oggetto", DbType.String, wfw_oggetto);
				db.AddInParameter(dbCommand, "wfw_testo", DbType.String, wfw_testo);
				db.AddInParameter(dbCommand, "wfw_priorita", DbType.Int32, wfw_priorita);
				db.AddInParameter(dbCommand, "wfw_data_schedulata", DbType.DateTime, wfw_data_schedulata);
				db.AddInParameter(dbCommand, "wfw_data_effettuazione", DbType.DateTime, wfw_data_effettuazione);
				db.AddInParameter(dbCommand, "wfw_data_creazione", DbType.DateTime, wfw_data_creazione);
				db.AddInParameter(dbCommand, "wfw_to", DbType.String, wfw_to);
				db.AddInParameter(dbCommand, "wfw_cc", DbType.String, wfw_cc);
				db.AddInParameter(dbCommand, "wfw_ccn", DbType.String, wfw_ccn);
				db.AddInParameter(dbCommand, "wfw_raggruppa_per_destinatario", DbType.Int32, wfw_raggruppa_per_destinatario);
				db.AddInParameter(dbCommand, "wfw_timeout", DbType.Int32, wfw_timeout);
				db.AddInParameter(dbCommand, "wfw_classe", DbType.String, wfw_classe);
				db.AddInParameter(dbCommand, "wfw_stato_esecuzione", DbType.Int32, wfw_stato_esecuzione);
				db.AddInParameter(dbCommand, "wfs_id_stato", DbType.Int32, wfs_id_stato);
				db.AddInParameter(dbCommand, "sta_wfs_id_stato", DbType.Int32, sta_wfs_id_stato);
				db.AddInParameter(dbCommand, "wfw_partizionamento", DbType.String, wfw_partizionamento);
				db.AddInParameter(dbCommand, "wfw_sql_for_file", DbType.String, wfw_sql_for_file);
				db.AddInParameter(dbCommand, "wfw_file_generated", DbType.Int32, wfw_file_generated);
				db.AddInParameter(dbCommand, "wfw_expect_file", DbType.Int32, wfw_expect_file);
				db.AddInParameter(dbCommand, "wfw_lingua", DbType.String, wfw_lingua);
                db.AddInParameter(dbCommand, "wfw_lock", DbType.Int64, wfw_lock);
										
				db.AddInParameter(dbCommand, "wfw_id_case_azioni", DbType.Int32, p_wfw_id_case_azioni);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "WorkflowAzioniCases.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
			}
		}

		/// <summary>
		/// Cancella fisicamente l'oggetto dalla base dati.
		/// </summary>
		public static void Drop(SqlInt32 p_wfw_id_case_azioni)
		{
			Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
			DbConnection c =  db.CreateConnection();
			DbTransaction t = null;

			try
			{
				c.Open();
				t = c.BeginTransaction();

				Drop( p_wfw_id_case_azioni, t);

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
					ex2.Data.Add("Class.Method", "WorkflowAzioniCases.Wipe.Rollback");
					ex2.Data.Add("SQL", "Rollback error");
				}
				ex.Data.Add("Class.Method", "WorkflowAzioniCases.Wipe.");
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
        public static void Drop(SqlInt32 p_wfw_id_case_azioni, DbTransaction transaction)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM WORKFLOW_AZIONI_CASES WHERE 
					(wfw_id_case_azioni = @wfw_id_case_azioni) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "wfw_id_case_azioni", DbType.Int32, p_wfw_id_case_azioni);
										
				db.ExecuteNonQuery(dbCommand, transaction);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "WorkflowAzioniCases.Wipe.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
			}
		}
		
		/// <summary>
		/// Cancella logicamente l'oggetto dalla base dati.
		/// </summary>
		public void Delete(SqlInt32 p_wfw_id_case_azioni)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
			
				sqlCommand = @" UPDATE WORKFLOW_AZIONI_CASES SET

					 WHERE   
				     (wfw_id_case_azioni = @wfw_id_case_azioni) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "wfw_id_case_azioni", DbType.Int32, p_wfw_id_case_azioni);
										
				db.ExecuteNonQuery(dbCommand);
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "WorkflowAzioniCases.Delete.");
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
	
				sqlCommand = @" INSERT INTO WORKFLOW_AZIONI_CASES (
						ute_id_utente, 
						wfa_id_azione, 
						ioa_id_oggetto, 
						wfw_codice_azione, 
						wfw_from, 
						wfw_metodo, 
						wfw_oggetto, 
						wfw_testo, 
						wfw_priorita, 
						wfw_data_schedulata, 
						wfw_data_effettuazione, 
						wfw_data_creazione, 
						wfw_to, 
						wfw_cc, 
						wfw_ccn, 
						wfw_raggruppa_per_destinatario, 
						wfw_timeout, 
						wfw_classe, 
						wfw_stato_esecuzione, 
						wfs_id_stato, 
						sta_wfs_id_stato, 
						wfw_partizionamento, 
						wfw_sql_for_file, 
						wfw_file_generated, 
						wfw_expect_file, 
						wfw_lingua,
                        wfw_lock) 
					VALUES ( 
						@ute_id_utente, 
						@wfa_id_azione, 
						@ioa_id_oggetto, 
						@wfw_codice_azione, 
						@wfw_from, 
						@wfw_metodo, 
						@wfw_oggetto, 
						@wfw_testo, 
						@wfw_priorita, 
						@wfw_data_schedulata, 
						@wfw_data_effettuazione, 
						@wfw_data_creazione, 
						@wfw_to, 
						@wfw_cc, 
						@wfw_ccn, 
						@wfw_raggruppa_per_destinatario, 
						@wfw_timeout, 
						@wfw_classe, 
						@wfw_stato_esecuzione, 
						@wfs_id_stato, 
						@sta_wfs_id_stato, 
						@wfw_partizionamento, 
						@wfw_sql_for_file, 
						@wfw_file_generated, 
						@wfw_expect_file, 
						@wfw_lingua,
                        @wfw_lock) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "wfa_id_azione", DbType.Int32, wfa_id_azione);
				db.AddInParameter(dbCommand, "ioa_id_oggetto", DbType.Int32, ioa_id_oggetto);
				db.AddInParameter(dbCommand, "wfw_codice_azione", DbType.String, wfw_codice_azione);
				db.AddInParameter(dbCommand, "wfw_from", DbType.String, wfw_from);
				db.AddInParameter(dbCommand, "wfw_metodo", DbType.String, wfw_metodo);
				db.AddInParameter(dbCommand, "wfw_oggetto", DbType.String, wfw_oggetto);
				db.AddInParameter(dbCommand, "wfw_testo", DbType.String, wfw_testo);
				db.AddInParameter(dbCommand, "wfw_priorita", DbType.Int32, wfw_priorita);
				db.AddInParameter(dbCommand, "wfw_data_schedulata", DbType.DateTime, wfw_data_schedulata);
				db.AddInParameter(dbCommand, "wfw_data_effettuazione", DbType.DateTime, wfw_data_effettuazione);
				db.AddInParameter(dbCommand, "wfw_data_creazione", DbType.DateTime, wfw_data_creazione);
				db.AddInParameter(dbCommand, "wfw_to", DbType.String, wfw_to);
				db.AddInParameter(dbCommand, "wfw_cc", DbType.String, wfw_cc);
				db.AddInParameter(dbCommand, "wfw_ccn", DbType.String, wfw_ccn);
				db.AddInParameter(dbCommand, "wfw_raggruppa_per_destinatario", DbType.Int32, wfw_raggruppa_per_destinatario);
				db.AddInParameter(dbCommand, "wfw_timeout", DbType.Int32, wfw_timeout);
				db.AddInParameter(dbCommand, "wfw_classe", DbType.String, wfw_classe);
				db.AddInParameter(dbCommand, "wfw_stato_esecuzione", DbType.Int32, wfw_stato_esecuzione);
				db.AddInParameter(dbCommand, "wfs_id_stato", DbType.Int32, wfs_id_stato);
				db.AddInParameter(dbCommand, "sta_wfs_id_stato", DbType.Int32, sta_wfs_id_stato);
				db.AddInParameter(dbCommand, "wfw_partizionamento", DbType.String, wfw_partizionamento);
				db.AddInParameter(dbCommand, "wfw_sql_for_file", DbType.String, wfw_sql_for_file);
				db.AddInParameter(dbCommand, "wfw_file_generated", DbType.Int32, wfw_file_generated);
				db.AddInParameter(dbCommand, "wfw_expect_file", DbType.Int32, wfw_expect_file);
				db.AddInParameter(dbCommand, "wfw_lingua", DbType.String, wfw_lingua);
                db.AddInParameter(dbCommand, "wfw_lock", DbType.Int64, wfw_lock);

 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					wfw_id_case_azioni = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "WorkflowAzioniCases.Create.");
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
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void Create(DbTransaction transaction, Database db) 
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {

                sqlCommand = @" INSERT INTO WORKFLOW_AZIONI_CASES (
						ute_id_utente, 
						wfa_id_azione, 
						ioa_id_oggetto, 
						wfw_codice_azione, 
						wfw_from, 
						wfw_metodo, 
						wfw_oggetto, 
						wfw_testo, 
						wfw_priorita, 
						wfw_data_schedulata, 
						wfw_data_effettuazione, 
						wfw_data_creazione, 
						wfw_to, 
						wfw_cc, 
						wfw_ccn, 
						wfw_raggruppa_per_destinatario, 
						wfw_timeout, 
						wfw_classe, 
						wfw_stato_esecuzione, 
						wfs_id_stato, 
						sta_wfs_id_stato, 
						wfw_partizionamento, 
						wfw_sql_for_file, 
						wfw_file_generated, 
						wfw_expect_file, 
						wfw_lingua,
                        wfw_lock) 
					VALUES ( 
						@ute_id_utente, 
						@wfa_id_azione, 
						@ioa_id_oggetto, 
						@wfw_codice_azione, 
						@wfw_from, 
						@wfw_metodo, 
						@wfw_oggetto, 
						@wfw_testo, 
						@wfw_priorita, 
						@wfw_data_schedulata, 
						@wfw_data_effettuazione, 
						@wfw_data_creazione, 
						@wfw_to, 
						@wfw_cc, 
						@wfw_ccn, 
						@wfw_raggruppa_per_destinatario, 
						@wfw_timeout, 
						@wfw_classe, 
						@wfw_stato_esecuzione, 
						@wfs_id_stato, 
						@sta_wfs_id_stato, 
						@wfw_partizionamento, 
						@wfw_sql_for_file, 
						@wfw_file_generated, 
						@wfw_expect_file, 
						@wfw_lingua,
                        @wfw_lock) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "wfa_id_azione", DbType.Int32, wfa_id_azione);
                db.AddInParameter(dbCommand, "ioa_id_oggetto", DbType.Int32, ioa_id_oggetto);
                db.AddInParameter(dbCommand, "wfw_codice_azione", DbType.String, wfw_codice_azione);
                db.AddInParameter(dbCommand, "wfw_from", DbType.String, wfw_from);
                db.AddInParameter(dbCommand, "wfw_metodo", DbType.String, wfw_metodo);
                db.AddInParameter(dbCommand, "wfw_oggetto", DbType.String, wfw_oggetto);
                db.AddInParameter(dbCommand, "wfw_testo", DbType.String, wfw_testo);
                db.AddInParameter(dbCommand, "wfw_priorita", DbType.Int32, wfw_priorita);
                db.AddInParameter(dbCommand, "wfw_data_schedulata", DbType.DateTime, wfw_data_schedulata);
                db.AddInParameter(dbCommand, "wfw_data_effettuazione", DbType.DateTime, wfw_data_effettuazione);
                db.AddInParameter(dbCommand, "wfw_data_creazione", DbType.DateTime, wfw_data_creazione);
                db.AddInParameter(dbCommand, "wfw_to", DbType.String, wfw_to);
                db.AddInParameter(dbCommand, "wfw_cc", DbType.String, wfw_cc);
                db.AddInParameter(dbCommand, "wfw_ccn", DbType.String, wfw_ccn);
                db.AddInParameter(dbCommand, "wfw_raggruppa_per_destinatario", DbType.Int32, wfw_raggruppa_per_destinatario);
                db.AddInParameter(dbCommand, "wfw_timeout", DbType.Int32, wfw_timeout);
                db.AddInParameter(dbCommand, "wfw_classe", DbType.String, wfw_classe);
                db.AddInParameter(dbCommand, "wfw_stato_esecuzione", DbType.Int32, wfw_stato_esecuzione);
                db.AddInParameter(dbCommand, "wfs_id_stato", DbType.Int32, wfs_id_stato);
                db.AddInParameter(dbCommand, "sta_wfs_id_stato", DbType.Int32, sta_wfs_id_stato);
                db.AddInParameter(dbCommand, "wfw_partizionamento", DbType.String, wfw_partizionamento);
                db.AddInParameter(dbCommand, "wfw_sql_for_file", DbType.String, wfw_sql_for_file);
                db.AddInParameter(dbCommand, "wfw_file_generated", DbType.Int32, wfw_file_generated);
                db.AddInParameter(dbCommand, "wfw_expect_file", DbType.Int32, wfw_expect_file);
                db.AddInParameter(dbCommand, "wfw_lingua", DbType.String, wfw_lingua);
                db.AddInParameter(dbCommand, "wfw_lock", DbType.Int64, wfw_lock);

                dataReader = db.ExecuteReader(dbCommand,transaction);
                if (dataReader.Read())
                {
                    wfw_id_case_azioni = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "WorkflowAzioniCases.Create.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
            }
            finally
            {
                if (dataReader != null)
                    ((IDisposable)dataReader).Dispose();
            }
        }
		
		/// <summary>
        /// Elenca tutti gli elementi WorkflowAzioniCases dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "WORKFLOW_AZIONI_CASES");
        }
		/// <summary>
		/// Elenca tutti gli elementi WorkflowAzioniCases dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"WORKFLOW_AZIONI_CASES");
		}
		/// <summary>
		/// Elenca tutti gli elementi WorkflowAzioniCases dell'analisi. L'utente può scegliere il nome della tabella nel dataset.
		/// Il primo campo deve corrispondere alla key utilizzata dalla GridView.
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
					WORKFLOW_AZIONI_CASES.wfw_id_case_azioni, 
					WORKFLOW_AZIONI_CASES.ute_id_utente, 
					WORKFLOW_AZIONI_CASES.wfa_id_azione, 
					WORKFLOW_AZIONI_CASES.ioa_id_oggetto, 
					WORKFLOW_AZIONI_CASES.wfw_codice_azione, 
					WORKFLOW_AZIONI_CASES.wfw_from, 
					WORKFLOW_AZIONI_CASES.wfw_metodo, 
					WORKFLOW_AZIONI_CASES.wfw_oggetto, 
					WORKFLOW_AZIONI_CASES.wfw_testo, 
					WORKFLOW_AZIONI_CASES.wfw_priorita, 
					WORKFLOW_AZIONI_CASES.wfw_data_schedulata, 
					WORKFLOW_AZIONI_CASES.wfw_data_effettuazione, 
					WORKFLOW_AZIONI_CASES.wfw_data_creazione, 
					WORKFLOW_AZIONI_CASES.wfw_to, 
					WORKFLOW_AZIONI_CASES.wfw_cc, 
					WORKFLOW_AZIONI_CASES.wfw_ccn, 
					WORKFLOW_AZIONI_CASES.wfw_raggruppa_per_destinatario, 
					WORKFLOW_AZIONI_CASES.wfw_timeout, 
					WORKFLOW_AZIONI_CASES.wfw_classe, 
					WORKFLOW_AZIONI_CASES.wfw_stato_esecuzione, 
					WORKFLOW_AZIONI_CASES.wfs_id_stato, 
					WORKFLOW_AZIONI_CASES.sta_wfs_id_stato, 
					WORKFLOW_AZIONI_CASES.wfw_partizionamento, 
					WORKFLOW_AZIONI_CASES.wfw_sql_for_file, 
					WORKFLOW_AZIONI_CASES.wfw_file_generated, 
					WORKFLOW_AZIONI_CASES.wfw_expect_file, 
					WORKFLOW_AZIONI_CASES.wfw_lingua,
                    WORKFLOW_AZIONI_CASES.wfw_lock 
				FROM WORKFLOW_AZIONI_CASES ");

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
				ex.Data.Add("Class.Method", "WorkflowAzioniCases.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
			}

			return ds; 
		}

        /// <summary>
        /// Utilizzata per il browser
        /// </summary>
        public static DataSet ListForBrowser(string VWhereClause)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT TOP 600
					            WORKFLOW_AZIONI_CASES.wfw_id_case_azioni, 
					            WORKFLOW_AZIONI_CASES.wfa_id_azione, 
                                WORKFLOW_AZIONI.wfa_descrizione_azione,
					            WORKFLOW_AZIONI_CASES.wfw_codice_azione, 
					            WORKFLOW_AZIONI_CASES.wfw_metodo, 
                                WORKFLOW_AZIONI_CASES.wfw_data_creazione, 
					            WORKFLOW_AZIONI_CASES.wfw_data_schedulata, 
					            WORKFLOW_AZIONI_CASES.wfw_data_effettuazione,
					            WORKFLOW_AZIONI_CASES.wfw_classe, 
					            CASE WORKFLOW_AZIONI_CASES.wfw_stato_esecuzione
                                    WHEN 1 THEN 'ESEGUITO'
                                    WHEN 0 THEN 'IN ERRORE'
                                    WHEN -1 THEN 'IN ESECUZIONE'
                                    ELSE 'DA ESEGUIRE'
                                END AS wfw_stato_esecuzione,
                                ISNULL(UTENTE.ute_cognome + ' ' +  UTENTE.ute_nome,'') AS UTENTE,
                                WORKFLOW_AZIONI_CASES.wfw_to				           
				            FROM 
                                WORKFLOW_AZIONI_CASES
                            LEFT JOIN WORKFLOW_AZIONI 
                                ON WORKFLOW_AZIONI_CASES.wfa_id_azione=WORKFLOW_AZIONI.wfa_id_azione
                            LEFT JOIN UTENTE
                                ON WORKFLOW_AZIONI_CASES.ute_id_utente=UTENTE.ute_id_utente");

                if (VWhereClause != string.Empty)
                {
                    sb.Append(VWhereClause);
                }

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, "WORKFLOW_AZIONI_CASES");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "WorkflowAzioniCases.ListForBrowser.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
            }

            return ds;
        }


        

		#endregion

	}
}
