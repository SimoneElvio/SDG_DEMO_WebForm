#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   TransazioniRichiesta.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per TRANSAZIONIRICHIESTA
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
	/// Tabella TRANSAZIONI_RICHIESTA 
	/// </summary>
	public class TransazioniRichiesta
	{
		#region attributi e variabili

	    private SqlInt32 trr_id_transazione = SqlInt32.Null;
	    private SqlInt32 lsr_id_stato_richiesta = SqlInt32.Null;
	    private SqlInt32 riv_id_richiesta = SqlInt32.Null;	    
	    private SqlDateTime trr_data_ora = SqlDateTime.Null;
	    private SqlString trr_nome_cognome_utente = SqlString.Null;
	    private SqlString trr_note = SqlString.Null;
	    private SqlInt32 trr_flag_last_indicator = SqlInt32.Null;
        private SqlString lsr_descrizione = SqlString.Null;
        private SqlInt32 trr_flag_change_state = SqlInt32.Null;

		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Trr_id_transazione
		{
			get { return trr_id_transazione; }	
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Lsr_id_stato_richiesta
		{
			get { return lsr_id_stato_richiesta; }	
			set { lsr_id_stato_richiesta = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Riv_id_richiesta
		{
			get { return riv_id_richiesta; }	
			set { riv_id_richiesta = value; }
		}
		

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Trr_data_ora
		{
			get { return trr_data_ora; }	
			set { trr_data_ora = value; }
		}

		/// <value>
		/// Nome cognome dell'utente che ha operato la transazione di stato sulla richiesta trasferta.
		/// </value>
		public SqlString Trr_nome_cognome_utente
		{
			get { return trr_nome_cognome_utente; }	
			set { trr_nome_cognome_utente = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Trr_note
		{
			get { return trr_note; }	
			set { trr_note = value; }
		}
		/// <value>
		/// 
		/// </value>
		public SqlInt32 Trr_flag_last_indicator
		{
			get { return trr_flag_last_indicator; }	
			set { trr_flag_last_indicator = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Trr_flag_change_state
        {
            get { return trr_flag_change_state; }
            set { trr_flag_change_state = value; }
        }
        /// <value>
        /// 
        /// </value>
        public SqlString Lsr_descrizione
        {
            get { return lsr_descrizione; }
            set { lsr_descrizione = value; }
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
		public TransazioniRichiesta()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_riv_id_richiesta)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT TOP 1
					 TRANSAZIONI_RICHIESTA.trr_id_transazione, 
					 TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta, 
					 TRANSAZIONI_RICHIESTA.riv_id_richiesta, 					 
					 TRANSAZIONI_RICHIESTA.trr_data_ora, 
					 TRANSAZIONI_RICHIESTA.trr_nome_cognome_utente, 
					 TRANSAZIONI_RICHIESTA.trr_note, 
					 TRANSAZIONI_RICHIESTA.trr_flag_last_indicator	 
				 	 FROM TRANSAZIONI_RICHIESTA WHERE 
					 (riv_id_richiesta = @riv_id_richiesta) ORDER BY trr_id_transazione DESC
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					trr_id_transazione = reader.GetSqlInt32(0);
					lsr_id_stato_richiesta = reader.GetSqlInt32(1);
					riv_id_richiesta = reader.GetSqlInt32(2);					
					trr_data_ora = reader.GetSqlDateTime(3);
					trr_nome_cognome_utente = reader.GetSqlString(4);
					trr_note = reader.GetSqlString(5);
					trr_flag_last_indicator = reader.GetSqlInt32(6);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "TransazioniRichiesta.Read.");
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
		public void Update(SqlInt32 p_trr_id_transazione)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE TRANSAZIONI_RICHIESTA SET
					 lsr_id_stato_richiesta = @lsr_id_stato_richiesta, 
					 riv_id_richiesta = @riv_id_richiesta, 					 
					 trr_data_ora = @trr_data_ora, 
					 trr_nome_cognome_utente = @trr_nome_cognome_utente, 
					 trr_note = @trr_note, 
					 trr_flag_last_indicator = @trr_flag_last_indicator
					 WHERE   
				     (trr_id_transazione = @trr_id_transazione) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, lsr_id_stato_richiesta);
				db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);				
				db.AddInParameter(dbCommand, "trr_data_ora", DbType.DateTime, trr_data_ora);
				db.AddInParameter(dbCommand, "trr_nome_cognome_utente", DbType.String, trr_nome_cognome_utente);
				db.AddInParameter(dbCommand, "trr_note", DbType.String, trr_note);
				db.AddInParameter(dbCommand, "trr_flag_last_indicator", DbType.Int32, trr_flag_last_indicator);										
				db.AddInParameter(dbCommand, "trr_id_transazione", DbType.Int32, p_trr_id_transazione);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "TransazioniRichiesta.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete(SqlInt32 p_trr_id_transazione)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM TRANSAZIONI_RICHIESTA WHERE 
					(trr_id_transazione = @trr_id_transazione) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "trr_id_transazione", DbType.Int32, p_trr_id_transazione);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "TransazioniRichiesta.Delete.");
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
            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            DbConnection c = db.CreateConnection();
            DbTransaction t = null;

            try
            {
                c.Open();
                t = c.BeginTransaction();

                Create(t);

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
                    ex2.Data.Add("Class.Method", "TransazioniRichiesta.Create.Rollback");
                    ex2.Data.Add("SQL", "Rollback error");
                }
                ex.Data.Add("Class.Method", "TransazioniRichiesta.Create.");
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
		/// Crea l'oggetto corrispondente nella base dati.
		/// </summary>
        public void Create(DbTransaction t) 
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			IDataReader dataReader = null;
			
			try
			{ 
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
	
				sqlCommand = @" INSERT INTO TRANSAZIONI_RICHIESTA (
						lsr_id_stato_richiesta, 
						riv_id_richiesta, 						
						trr_data_ora, 
						trr_nome_cognome_utente, 
						trr_note, 
						trr_flag_last_indicator,
                        trr_flag_state_change) 
					VALUES ( 
						@lsr_id_stato_richiesta, 
						@riv_id_richiesta, 						
						@trr_data_ora, 
						@trr_nome_cognome_utente, 
						@trr_note, 
						@trr_flag_last_indicator,
                        @trr_flag_change_state) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, lsr_id_stato_richiesta);
				db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);				
				db.AddInParameter(dbCommand, "trr_data_ora", DbType.DateTime, trr_data_ora);
				db.AddInParameter(dbCommand, "trr_nome_cognome_utente", DbType.String, trr_nome_cognome_utente);
				db.AddInParameter(dbCommand, "trr_note", DbType.String, trr_note);
				db.AddInParameter(dbCommand, "trr_flag_last_indicator", DbType.Int32, trr_flag_last_indicator);
                db.AddInParameter(dbCommand, "trr_flag_change_state", DbType.Int32, trr_flag_change_state);

                dataReader = db.ExecuteReader(dbCommand, t);
 				if (dataReader.Read())
 				{
 					trr_id_transazione = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "TransazioniRichiesta.Create.");
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
        /// Elenca tutti gli elementi TransazioniRichiesta dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "TRANSAZIONI_RICHIESTA");
        }
		/// <summary>
		/// Elenca tutti gli elementi TransazioniRichiesta dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"TRANSAZIONI_RICHIESTA");
		}
		/// <summary>
		/// Elenca tutti gli elementi TransazioniRichiesta dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					TRANSAZIONI_RICHIESTA.trr_id_transazione, 
					TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta, 
					TRANSAZIONI_RICHIESTA.riv_id_richiesta, 					
					TRANSAZIONI_RICHIESTA.trr_data_ora, 
					TRANSAZIONI_RICHIESTA.trr_nome_cognome_utente, 
					TRANSAZIONI_RICHIESTA.trr_note, 
					TRANSAZIONI_RICHIESTA.trr_flag_last_indicator 
				FROM TRANSAZIONI_RICHIESTA ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["TRANSAZIONI_RICHIESTA"].Columns["trr_id_transazione"];
				ds.Tables["TRANSAZIONI_RICHIESTA"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "TransazioniRichiesta.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

        /// <summary>
        /// Restituisce l'elenco log con tutte le note.
        /// </summary>
        /// <param name="riv_id_richiesta">Id Richiesta</param>
        /// <returns></returns>
        public static DataSet ListLog(Int32 riv_id_richiesta)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT DISTINCT                     
					COALESCE(UTENTE.UTE_COGNOME + ' ' + UTENTE.UTE_NOME,UTENTE.UTE_COGNOME) AS UTENTE,
                    IOA_DATA_PASSAGGIO,
                    --STATO_PARTENZA.LSR_DESCRIZIONE AS STATO_PARTENZA,
                    --STATO_ARRIVO.LSR_DESCRIZIONE AS STATO_ARRIVO,
                    STATO_PARTENZA.WFS_CHIAVE_DIZIONARIO AS STATO_PARTENZA,
                    STATO_ARRIVO.WFS_CHIAVE_DIZIONARIO AS STATO_ARRIVO,
                    IOA_WAIT,IOA_NOTA
				 	FROM WORKFLOW_CASES             
                    INNER JOIN UTENTE ON WORKFLOW_CASES.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE        
                    LEFT JOIN WORKFLOW_STATI STATO_PARTENZA ON WORKFLOW_CASES.WFS_ID_STATO = STATO_PARTENZA.WFS_ID_STATO
                    LEFT JOIN WORKFLOW_STATI STATO_ARRIVO ON WORKFLOW_CASES.STA_WFS_ID_STATO = STATO_ARRIVO.WFS_ID_STATO
                    WHERE IOA_ID_OGGETTO=" + riv_id_richiesta + @" AND IOA_DATA_PASSAGGIO IS NOT NULL
                    AND ioa_nota IS NOT NULL AND ioa_nota <> ''
                    ORDER BY IOA_DATA_PASSAGGIO ASC ");
             
                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, "WORKFLOW_CASES");

                // Add keys to table for correct use of Infragistics WebDataGrid.
                //DataColumn[] keys = new DataColumn[1];
                //keys[0] = ds.Tables["WORKFLOW_CASES"].Columns["trr_id_transazione"];
                //ds.Tables["WORKFLOW_CASES"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TransazioniRichiesta.ListLog.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public static DataSet ListAssegnazioneHRG(Int32 riv_id_richiesta)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					TRANSAZIONI_RICHIESTA.trr_id_transazione, 
					TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta, 
					TRANSAZIONI_RICHIESTA.riv_id_richiesta, 					
					TRANSAZIONI_RICHIESTA.trr_data_ora, 
					TRANSAZIONI_RICHIESTA.trr_nome_cognome_utente, 
					TRANSAZIONI_RICHIESTA.trr_note, 
					TRANSAZIONI_RICHIESTA.trr_flag_last_indicator, 
				    LOOKUP_STATO_RICHIESTA.lsr_descrizione
				 	FROM TRANSAZIONI_RICHIESTA 
                    INNER JOIN LOOKUP_STATO_RICHIESTA ON TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta = LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta                     
                    WHERE RIV_ID_RICHIESTA=" + riv_id_richiesta + " and TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta > 3 ORDER BY TRR_DATA_ORA ASC");


                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, "TRANSAZIONI_RICHIESTA");

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["TRANSAZIONI_RICHIESTA"].Columns["trr_id_transazione"];
                ds.Tables["TRANSAZIONI_RICHIESTA"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TransazioniRichiesta.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public static DataSet ListAssegnazioneCliente(Int32 riv_id_richiesta)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					TRANSAZIONI_RICHIESTA.trr_id_transazione, 
					TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta, 
					TRANSAZIONI_RICHIESTA.riv_id_richiesta, 					
					TRANSAZIONI_RICHIESTA.trr_data_ora, 
					TRANSAZIONI_RICHIESTA.trr_nome_cognome_utente, 
					TRANSAZIONI_RICHIESTA.trr_note, 
					TRANSAZIONI_RICHIESTA.trr_flag_last_indicator, 
				    LOOKUP_STATO_RICHIESTA.lsr_descrizione
				 	FROM TRANSAZIONI_RICHIESTA 
                    INNER JOIN LOOKUP_STATO_RICHIESTA ON TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta = LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta                     
                    WHERE RIV_ID_RICHIESTA=" + riv_id_richiesta + " and TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta <> 4 ORDER BY TRR_DATA_ORA ASC");


                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, "TRANSAZIONI_RICHIESTA");

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["TRANSAZIONI_RICHIESTA"].Columns["trr_id_transazione"];
                ds.Tables["TRANSAZIONI_RICHIESTA"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TransazioniRichiesta.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public void ReadPreviousState(SqlInt32 p_trr_id_transazione, SqlInt32 p_riv_id_richiesta, SqlInt32 p_lsr_id_stato_richiesta,string ordinamento)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT TOP 1
					 TRANSAZIONI_RICHIESTA.trr_id_transazione, 
					 TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta, 
					 TRANSAZIONI_RICHIESTA.riv_id_richiesta, 					 
					 TRANSAZIONI_RICHIESTA.trr_data_ora, 
					 TRANSAZIONI_RICHIESTA.trr_nome_cognome_utente, 
					 TRANSAZIONI_RICHIESTA.trr_note, 
					 TRANSAZIONI_RICHIESTA.trr_flag_last_indicator,
                     LOOKUP_STATO_RICHIESTA.lsr_descrizione                     	 
				 	 FROM TRANSAZIONI_RICHIESTA 
                     INNER JOIN LOOKUP_STATO_RICHIESTA ON TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta = LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta
                     WHERE 
					 (trr_id_transazione < @trr_id_transazione AND riv_id_richiesta = @riv_id_richiesta AND trr_flag_state_change=1) ORDER BY trr_id_transazione " + ordinamento;
					 

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "trr_id_transazione", DbType.Int32, p_trr_id_transazione);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);
                db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, p_lsr_id_stato_richiesta);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    trr_id_transazione = reader.GetSqlInt32(0);
                    lsr_id_stato_richiesta = reader.GetSqlInt32(1);
                    riv_id_richiesta = reader.GetSqlInt32(2);                    
                    trr_data_ora = reader.GetSqlDateTime(3);
                    trr_nome_cognome_utente = reader.GetSqlString(4);
                    trr_note = reader.GetSqlString(5);
                    trr_flag_last_indicator = reader.GetSqlInt32(6);
                    lsr_descrizione = reader.GetSqlString(7);

                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TransazioniRichiesta.Read.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }

        public void ReadPreviousStateHRG(SqlInt32 p_trr_id_transazione, SqlInt32 p_riv_id_richiesta, SqlInt32 p_lsr_id_stato_richiesta, string ordinamento)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT TOP 1
					 TRANSAZIONI_RICHIESTA.trr_id_transazione, 
					 TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta, 
					 TRANSAZIONI_RICHIESTA.riv_id_richiesta, 					 
					 TRANSAZIONI_RICHIESTA.trr_data_ora, 
					 TRANSAZIONI_RICHIESTA.trr_nome_cognome_utente, 
					 TRANSAZIONI_RICHIESTA.trr_note, 
					 TRANSAZIONI_RICHIESTA.trr_flag_last_indicator,
                     LOOKUP_STATO_RICHIESTA.lsr_descrizione                     	 
				 	 FROM TRANSAZIONI_RICHIESTA 
                     INNER JOIN LOOKUP_STATO_RICHIESTA ON TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta = LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta
                     WHERE 
					 (trr_id_transazione < @trr_id_transazione AND riv_id_richiesta = @riv_id_richiesta AND trr_flag_state_change=1) ORDER BY trr_id_transazione " + ordinamento;


                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "trr_id_transazione", DbType.Int32, p_trr_id_transazione);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);
                db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, p_lsr_id_stato_richiesta);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    trr_id_transazione = reader.GetSqlInt32(0);
                    lsr_id_stato_richiesta = reader.GetSqlInt32(1);
                    riv_id_richiesta = reader.GetSqlInt32(2);
                    trr_data_ora = reader.GetSqlDateTime(3);
                    trr_nome_cognome_utente = reader.GetSqlString(4);
                    trr_note = reader.GetSqlString(5);
                    trr_flag_last_indicator = reader.GetSqlInt32(6);
                    lsr_descrizione = reader.GetSqlString(7);

                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TransazioniRichiesta.Read.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }

        public void ReadPreviousStateCliente(SqlInt32 p_trr_id_transazione, SqlInt32 p_riv_id_richiesta, SqlInt32 p_lsr_id_stato_richiesta, string ordinamento)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT TOP 1
					 TRANSAZIONI_RICHIESTA.trr_id_transazione, 
					 TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta, 
					 TRANSAZIONI_RICHIESTA.riv_id_richiesta, 					 
					 TRANSAZIONI_RICHIESTA.trr_data_ora, 
					 TRANSAZIONI_RICHIESTA.trr_nome_cognome_utente, 
					 TRANSAZIONI_RICHIESTA.trr_note, 
					 TRANSAZIONI_RICHIESTA.trr_flag_last_indicator,
                     LOOKUP_STATO_RICHIESTA.lsr_descrizione                     	 
				 	 FROM TRANSAZIONI_RICHIESTA 
                     INNER JOIN LOOKUP_STATO_RICHIESTA ON TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta = LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta
                     WHERE 
					 (trr_id_transazione < @trr_id_transazione AND riv_id_richiesta = @riv_id_richiesta AND trr_flag_state_change=1) ORDER BY trr_id_transazione " + ordinamento;


                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "trr_id_transazione", DbType.Int32, p_trr_id_transazione);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);
                db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, p_lsr_id_stato_richiesta);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    trr_id_transazione = reader.GetSqlInt32(0);
                    lsr_id_stato_richiesta = reader.GetSqlInt32(1);
                    riv_id_richiesta = reader.GetSqlInt32(2);
                    trr_data_ora = reader.GetSqlDateTime(3);
                    trr_nome_cognome_utente = reader.GetSqlString(4);
                    trr_note = reader.GetSqlString(5);
                    trr_flag_last_indicator = reader.GetSqlInt32(6);
                    lsr_descrizione = reader.GetSqlString(7);

                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TransazioniRichiesta.Read.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }

        public void LastActiveTransaction(SqlInt32 p_riv_id_richiesta, SqlInt32 p_lsr_id_stato_richiesta, SqlInt32 HRGStateExist)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT TOP 1
					 TRANSAZIONI_RICHIESTA.trr_id_transazione, 
					 TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta, 
					 TRANSAZIONI_RICHIESTA.riv_id_richiesta, 					 
					 TRANSAZIONI_RICHIESTA.trr_data_ora, 
					 TRANSAZIONI_RICHIESTA.trr_nome_cognome_utente, 
					 TRANSAZIONI_RICHIESTA.trr_note, 
					 TRANSAZIONI_RICHIESTA.trr_flag_last_indicator                   
				 	 FROM TRANSAZIONI_RICHIESTA                      
                     WHERE 
					 (riv_id_richiesta = @riv_id_richiesta ";

                if (HRGStateExist == 1)
                    sqlCommand = sqlCommand + " AND trr_flag_last_indicator=1 AND lsr_id_stato_richiesta=@lsr_id_stato_richiesta) ";
                else
                    sqlCommand = sqlCommand + " AND trr_flag_state_change=1 AND lsr_id_stato_richiesta=@lsr_id_stato_richiesta) order by trr_id_transazione asc ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);
                db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, p_lsr_id_stato_richiesta);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    trr_id_transazione = reader.GetSqlInt32(0);
                    lsr_id_stato_richiesta = reader.GetSqlInt32(1);
                    riv_id_richiesta = reader.GetSqlInt32(2);
                    trr_data_ora = reader.GetSqlDateTime(3);
                    trr_nome_cognome_utente = reader.GetSqlString(4);
                    trr_note = reader.GetSqlString(5);
                    trr_flag_last_indicator = reader.GetSqlInt32(6);                    

                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TransazioniRichiesta.Read.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }



        public void CalcoloTempi(SqlInt32 p_riv_id_richiesta, SqlInt32 stato, string ordinamento)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT TOP 1
					 TRANSAZIONI_RICHIESTA.trr_id_transazione, 
					 TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta, 
					 TRANSAZIONI_RICHIESTA.riv_id_richiesta, 					 
					 TRANSAZIONI_RICHIESTA.trr_data_ora, 
					 TRANSAZIONI_RICHIESTA.trr_nome_cognome_utente, 
					 TRANSAZIONI_RICHIESTA.trr_note, 
					 TRANSAZIONI_RICHIESTA.trr_flag_last_indicator,
                     LOOKUP_STATO_RICHIESTA.lsr_descrizione                     	 
				 	 FROM TRANSAZIONI_RICHIESTA 
                     INNER JOIN LOOKUP_STATO_RICHIESTA ON TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta = LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta
                     WHERE 
					 (riv_id_richiesta = @riv_id_richiesta and TRANSAZIONI_RICHIESTA.lsr_id_stato_richiesta = @stato) ORDER BY trr_id_transazione " + ordinamento;
				

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "stato", DbType.Int32, stato);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);
//                db.AddInParameter(dbCommand, "ordinamento", DbType.String, ordinamento);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    trr_id_transazione = reader.GetSqlInt32(0);
                    lsr_id_stato_richiesta = reader.GetSqlInt32(1);
                    riv_id_richiesta = reader.GetSqlInt32(2);
                    trr_data_ora = reader.GetSqlDateTime(3);
                    trr_nome_cognome_utente = reader.GetSqlString(4);
                    trr_note = reader.GetSqlString(5);
                    trr_flag_last_indicator = reader.GetSqlInt32(6);
                    lsr_descrizione = reader.GetSqlString(7);

                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TransazioniRichiesta.Read.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }

        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void UpdateLastIndicator(SqlInt32 riv_id_richiesta)
        {
            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            DbConnection c = db.CreateConnection();
            DbTransaction t = null;

            try
            {
                c.Open();
                t = c.BeginTransaction();

                UpdateLastIndicator(riv_id_richiesta,t);

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
                    ex2.Data.Add("Class.Method", "TransazioniRichiesta.UpdateLastIndicator.Rollback");
                    ex2.Data.Add("SQL", "Rollback error");
                }
                ex.Data.Add("Class.Method", "TransazioniRichiesta.UpdateLastIndicator.");
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
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void UpdateLastIndicator(SqlInt32 riv_id_richiesta,DbTransaction t)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE TRANSAZIONI_RICHIESTA SET					
					                trr_flag_last_indicator = 0
					            WHERE   (riv_id_richiesta = @riv_id_richiesta)  ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);                

                db.ExecuteNonQuery(dbCommand,t);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TransazioniRichiesta.UpdateLastindicator.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }
      
        public void CreateCloneTransazione()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO TRANSAZIONI_RICHIESTA (
						lsr_id_stato_richiesta, 
						riv_id_richiesta, 						
						trr_data_ora, 
						trr_nome_cognome_utente, 
						trr_note, 
						trr_flag_last_indicator,
                        trr_flag_state_change) 
					    VALUES( 
						@lsr_id_stato_richiesta, 
						@riv_id_richiesta, 						
						@trr_data_ora, 
						@trr_nome_cognome_utente, 
						@trr_note, 
						@trr_flag_last_indicator,
                        @trr_flag_change_state) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                
                db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, lsr_id_stato_richiesta);
				db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);				
				db.AddInParameter(dbCommand, "trr_data_ora", DbType.DateTime, trr_data_ora);
				db.AddInParameter(dbCommand, "trr_nome_cognome_utente", DbType.String, trr_nome_cognome_utente);
				db.AddInParameter(dbCommand, "trr_note", DbType.String, trr_note);
				db.AddInParameter(dbCommand, "trr_flag_last_indicator", DbType.Int32, trr_flag_last_indicator);
                db.AddInParameter(dbCommand, "trr_flag_change_state", DbType.Int32, trr_flag_change_state);

                              

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    trr_id_transazione = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TransazioniRichiesta.Create.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            finally
            {
                if (dataReader != null)
                    ((IDisposable)dataReader).Dispose();
            }
        }

		#endregion

	}
}
