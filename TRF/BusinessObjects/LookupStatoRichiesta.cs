#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   LookupStatoRichiesta.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per LOOKUPSTATORICHIESTA
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
using SDG.GestioneUtenti;

namespace BusinessObjects
{
	/// <summary>
	/// Tabella LOOKUP_STATO_RICHIESTA 
	/// </summary>
	public class LookupStatoRichiesta
	{
        #region Costanti
        /// <summary>
        /// enum per la tabella Stati Richiesta
        /// </summary>
        public enum eStatoRichiesta
        {


            Approvato = 14,
            Approvato2 = 18,
            Rifiutato = 15,
            Rifiutato2 = 17,
            NessunoStato = 9,
            InLavorazione = 3,
            Bozza = 1,
            Nuova = 2,
            Completa = 5,
            AttesaApprovazione = 13,
            AttesaApprovazione2 = 16,
            AttesaCliente = 4,
            Annulla = 6,
            RichiestaSblocco = 7,
            RichiediCancellazione = 35,
            Cancellata = 36,
            RichiediModifica = 37

            //C_ATS_FORNITORE = "8";            
            //C_ATS_CLIENTE = "4";
            //C_COMPLETA = "5";
            //C_ANNULLA = "6";
            //C_RIC_SBLOCCO = "7";                        
            //C_INVIA_CONTROLLO_DA_LAV_CLIENTE = "3";
            //C_RESPINTO_AGENZIA = "20";
            //C_ATTESA_APPROVAZIONE = "13";
            //C_ATTESA_APPROVAZIONE1 = "16";                                    
            //C_ANNULLA_AGE = "19";

        }

        #endregion

		#region attributi e variabili

	    private SqlInt32 lsr_id_stato_richiesta = SqlInt32.Null;
	    private SqlString lsr_descrizione = SqlString.Null;
	    private SqlInt32 lsr_flag_visibile = SqlInt32.Null;
	    private SqlInt32 lsr_flag_eliminato = SqlInt32.Null;
	    private SqlDateTime lsr_data_creazione = SqlDateTime.Null;
	    private SqlDateTime lsr_data_aggiornamento = SqlDateTime.Null;
	    private SqlInt32 ute_aggiornato_da = SqlInt32.Null;
	    private SqlInt32 ute_creato_da = SqlInt32.Null;
	    private SqlInt32 lsr_codice_notula = SqlInt32.Null;
		
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
		public SqlString Lsr_descrizione
		{
			get { return lsr_descrizione; }	
			set { lsr_descrizione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Lsr_flag_visibile
		{
			get { return lsr_flag_visibile; }	
			set { lsr_flag_visibile = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Lsr_flag_eliminato
		{
			get { return lsr_flag_eliminato; }	
			set { lsr_flag_eliminato = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Lsr_data_creazione
		{
			get { return lsr_data_creazione; }	
			set { lsr_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Lsr_data_aggiornamento
		{
			get { return lsr_data_aggiornamento; }	
			set { lsr_data_aggiornamento = value; }
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
		/// 
		/// </value>
		public SqlInt32 Lsr_codice_notula
		{
			get { return lsr_codice_notula; }	
			set { lsr_codice_notula = value; }
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
		public LookupStatoRichiesta()
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
					 LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta, 
					 LOOKUP_STATO_RICHIESTA.lsr_descrizione, 
					 LOOKUP_STATO_RICHIESTA.lsr_flag_visibile, 
					 LOOKUP_STATO_RICHIESTA.lsr_flag_eliminato, 
					 LOOKUP_STATO_RICHIESTA.lsr_data_creazione, 
					 LOOKUP_STATO_RICHIESTA.lsr_data_aggiornamento, 
					 LOOKUP_STATO_RICHIESTA.ute_aggiornato_da, 
					 LOOKUP_STATO_RICHIESTA.ute_creato_da, 
					 LOOKUP_STATO_RICHIESTA.lsr_codice_notula	 
				 	 FROM LOOKUP_STATO_RICHIESTA WHERE 
					 (lsr_id_stato_richiesta = @lsr_id_stato_richiesta) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, p_lsr_id_stato_richiesta);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					lsr_id_stato_richiesta = reader.GetSqlInt32(0);
					lsr_descrizione = reader.GetSqlString(1);
					lsr_flag_visibile = reader.GetSqlInt32(2);
					lsr_flag_eliminato = reader.GetSqlInt32(3);
					lsr_data_creazione = reader.GetSqlDateTime(4);
					lsr_data_aggiornamento = reader.GetSqlDateTime(5);
					ute_aggiornato_da = reader.GetSqlInt32(6);
					ute_creato_da = reader.GetSqlInt32(7);
					lsr_codice_notula = reader.GetSqlInt32(8);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoRichiesta.Read.");
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

				sqlCommand = @" UPDATE LOOKUP_STATO_RICHIESTA SET
					 lsr_descrizione = @lsr_descrizione, 
					 lsr_flag_visibile = @lsr_flag_visibile, 
					 lsr_flag_eliminato = @lsr_flag_eliminato, 
					 lsr_data_aggiornamento = getdate(), 
					 ute_aggiornato_da = @ute_aggiornato_da, 
					 lsr_codice_notula = @lsr_codice_notula
					 WHERE   
				     (lsr_id_stato_richiesta = @lsr_id_stato_richiesta) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "lsr_descrizione", DbType.String, lsr_descrizione);
				db.AddInParameter(dbCommand, "lsr_flag_visibile", DbType.Int32, lsr_flag_visibile);
				db.AddInParameter(dbCommand, "lsr_flag_eliminato", DbType.Int32, lsr_flag_eliminato);
				db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
				db.AddInParameter(dbCommand, "lsr_codice_notula", DbType.Int32, lsr_codice_notula);
										
				db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, p_lsr_id_stato_richiesta);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoRichiesta.Update.");
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

				sqlCommand = @" DELETE FROM LOOKUP_STATO_RICHIESTA WHERE 
					(lsr_id_stato_richiesta = @lsr_id_stato_richiesta) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "lsr_id_stato_richiesta", DbType.Int32, p_lsr_id_stato_richiesta);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoRichiesta.Delete.");
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
	
				sqlCommand = @" INSERT INTO LOOKUP_STATO_RICHIESTA (
						lsr_descrizione, 
						lsr_flag_visibile, 
						lsr_flag_eliminato, 
						lsr_data_creazione, 
						ute_creato_da, 
						lsr_codice_notula	 ) 
					VALUES ( 
						@lsr_descrizione, 
						@lsr_flag_visibile, 
						@lsr_flag_eliminato, 
						getdate(), 
						@ute_creato_da, 
						@lsr_codice_notula	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "lsr_descrizione", DbType.String, lsr_descrizione);
				db.AddInParameter(dbCommand, "lsr_flag_visibile", DbType.Int32, lsr_flag_visibile);
				db.AddInParameter(dbCommand, "lsr_flag_eliminato", DbType.Int32, lsr_flag_eliminato);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);
				db.AddInParameter(dbCommand, "lsr_codice_notula", DbType.Int32, lsr_codice_notula);

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
                ex.Data.Add("Class.Method", "LookupStatoRichiesta.Create.");
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
        /// Elenca tutti gli elementi LookupStatoRichiesta dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "LOOKUP_STATO_RICHIESTA");
        }
		/// <summary>
		/// Elenca tutti gli elementi LookupStatoRichiesta dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"LOOKUP_STATO_RICHIESTA");
		}
		/// <summary>
		/// Elenca tutti gli elementi LookupStatoRichiesta dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta, 
					LOOKUP_STATO_RICHIESTA.lsr_descrizione, 
					LOOKUP_STATO_RICHIESTA.lsr_flag_visibile, 
					LOOKUP_STATO_RICHIESTA.lsr_flag_eliminato, 
					LOOKUP_STATO_RICHIESTA.lsr_data_creazione, 
					LOOKUP_STATO_RICHIESTA.lsr_data_aggiornamento, 
					LOOKUP_STATO_RICHIESTA.ute_aggiornato_da, 
					LOOKUP_STATO_RICHIESTA.ute_creato_da, 
					LOOKUP_STATO_RICHIESTA.lsr_codice_notula 
				FROM LOOKUP_STATO_RICHIESTA ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["LOOKUP_STATO_RICHIESTA"].Columns["lsr_id_stato_richiesta"];
				ds.Tables["LOOKUP_STATO_RICHIESTA"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupStatoRichiesta.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

        /// <summary>
        /// Elenca tutti gli Stati possibili del Claim
        /// </summary>
        public DataSet ListStatiClaim()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					LSR_ID_STATO_RICHIESTA,LSR_DESCRIZIONE
                    FROM LOOKUP_STATO_RICHIESTA
                    WHERE LSR_ID_STATO_RICHIESTA IN (2,3,4,5,6,14,15,24,25,26)");
                
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "CROSS_UTENTE_CLIENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupStatoRichiesta.ListStatiClaim.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Restituisce id stato attraverso codice notula in input
        /// </summary>
        /// <param name="codice_notula"></param>
        /// <returns>lsr_id_stato_richiesta</returns>
        public int GetIdFromCodiceNotula(int codice_notula)
        {
            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            DbCommand dbCommand = null;
            string sqlCommand;
            SqlDataReader reader = null;

            int IdStatoRichiesta = 0;
            try
            {
                //Recupero id richiesta 
                sqlCommand = @" SELECT TOP 1
				                	LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta
				                FROM LOOKUP_STATO_RICHIESTA WHERE lsr_codice_notula = @lsr_codice_notula 
                                ORDER BY LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "lsr_codice_notula", DbType.Int32, codice_notula);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;
                while (reader.Read())
                {
                    IdStatoRichiesta = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupStatoRichiesta.GetIdFromCodiceNotula.");
                ex.Data.Add("SQL", ex.Message);

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
            return IdStatoRichiesta;
        }

        /// <summary>
        /// Restituisce il filtro con il numero di richieste in funzione degli stati presenti nella tabella CROSS_CLIENTE_RUOLI colonna CCR_LIST_STATUS_FILTER.
        /// </summary>
        /// <param name="ute_id_utente">Id utente</param>
        /// <param name="ltm_id_tipo_modulo">Id tipo modulo</param>
        /// <returns></returns>
        public static DataSet ListStatusFilter(Int32 ute_id_utente, Int32 ltm_id_tipo_modulo)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"DECLARE @list VARCHAR(100)

							SELECT @list = (
											SELECT
											ccr_list_status_filter + ','
											from CROSS_CLIENTE_RUOLI 
											INNER JOIN CROSS_UTENTE_CLIENTE ON CROSS_CLIENTE_RUOLI.CLI_ID_CLIENTE = CROSS_UTENTE_CLIENTE.CLI_ID_CLIENTE
											WHERE CROSS_UTENTE_CLIENTE.UTE_ID_UTENTE = " + ute_id_utente + @"
											AND cuc_flag_eliminato = 0
											AND ccr_flag_eliminato = 0
											AND rul_id_ruolo IN (
												SELECT RUL_ID_RUOLO FROM RUOLI_UTENTE
												WHERE ute_id_utente = " + ute_id_utente + @"
												AND url_data_disabilitazione IS NULL
											)
											FOR XML PATH ('')
										);

                            SELECT  LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta, 
                                    (SELECT DIZ_DESCRIZIONE FROM DIZIONARIO WHERE DIZ_CHIAVE = LOOKUP_STATO_RICHIESTA.lsr_chiave_dizionario and LKN_CODICE_UIC = 'it') AS LABEL_STATO,
                                    COUNT(LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta) as CONTATORE
                            FROM LOOKUP_STATO_RICHIESTA
                            INNER JOIN RICHIESTA_VIAGGIO ON LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta = RICHIESTA_VIAGGIO.lsr_id_stato_richiesta
                            GROUP BY LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta, lsr_descrizione,RICHIESTA_VIAGGIO.cli_id_cliente, riv_flag_eliminata, LOOKUP_STATO_RICHIESTA.lsr_chiave_dizionario, RICHIESTA_VIAGGIO.ltm_id_tipo_modulo
                            HAVING LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta IN (SELECT * FROM dbo.fnSplit(@list, ','))
                            AND RICHIESTA_VIAGGIO.cli_id_cliente in (
	                            SELECT CLI_ID_CLIENTE FROM CROSS_UTENTE_CLIENTE WHERE ute_id_utente = " + ute_id_utente + @"
                                )
                                AND riv_flag_eliminata = 0
                                and COUNT(LOOKUP_STATO_RICHIESTA.lsr_id_stato_richiesta) > 0 
                                AND RICHIESTA_VIAGGIO.ltm_id_tipo_modulo = " + ltm_id_tipo_modulo);

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, "LOOKUP_STATO_RICHIESTA");
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupStatoRichiesta.ListStatusFilter.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Restituisce il numero di richieste dove l'utente è autorizzatore o responsabile.
        /// </summary>
        /// <param name="p_ute_id_utente"></param>
        /// <returns></returns>
        public int getSumRichiesteTeam(int p_ute_id_utente)
        {
            SqlDataReader reader = null;
            DbCommand dbCommand = null;
            
            int returnValue = 0;
            StringBuilder sb = new StringBuilder();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT COUNT(DISTINCT ID_OGGETTO) FROM ObjectOwner
                                INNER JOIN RICHIESTA_VIAGGIO ON RICHIESTA_VIAGGIO.riv_id_richiesta = ObjectOwner.ID_Oggetto
                                WHERE fnt_id_funzionalita IN (");
                sb.Append(Funzionalita.eFunzionalita.ApprovatoreLiv1.GetHashCode());
                sb.Append(", ");
                sb.Append(Funzionalita.eFunzionalita.DirettoResponsabile.GetHashCode());
                sb.Append(@")
                                AND ltm_id_tipo_modulo = 1
                                AND ObjectOwner.ute_id_utente = @ute_id_utente
                                AND riv_flag_eliminata = 0
                                AND riv_id_missione_cliente IS NOT NULL ");

                dbCommand = db.GetSqlStringCommand(sb.ToString());
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, p_ute_id_utente);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    returnValue = reader.GetInt32(0);
                }                
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupStatoRichiesta.getSumRichiesteTeam.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }

            return returnValue;
        }

        /// <summary>
        /// Restituisce il numero di richieste dove l'utente è proprietario
        /// </summary>
        /// <param name="p_ute_id_utente"></param>
        /// <returns></returns>
        public int getSumRichiestePersonali(int p_ute_id_utente)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;
            int returnValue = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT (
	                                SELECT COUNT(RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA)
	                                FROM RICHIESTA_VIAGGIO
	                                INNER JOIN VIAGGIATORI ON RICHIESTA_VIAGGIO.riv_id_richiesta = VIAGGIATORI.riv_id_richiesta
	                                WHERE VIAGGIATORI.ute_id_utente = @ute_id_utente
	                                AND riv_flag_eliminata = 0
	                                AND ltm_id_tipo_modulo = 1
                                    AND RIV_ID_MISSIONE_CLIENTE IS NOT NULL
	                                ) + (
	                                SELECT COUNT(RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA)
	                                FROM RICHIESTA_VIAGGIO
	                                INNER JOIN RICHIEDENTE ON RICHIESTA_VIAGGIO.riv_id_richiesta = RICHIEDENTE.riv_id_richiesta
                                    LEFT JOIN VIAGGIATORI ON RICHIESTA_VIAGGIO.riv_id_richiesta = VIAGGIATORI.riv_id_richiesta
	                                WHERE RICHIEDENTE.ute_id_utente = @ute_id_utente
                                    AND VIAGGIATORI.ute_id_utente <> @ute_id_utente
	                                AND riv_flag_eliminata = 0
	                                AND ltm_id_tipo_modulo = 1
                                    AND RIV_ID_MISSIONE_CLIENTE IS NOT NULL
	                            ) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, p_ute_id_utente);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    returnValue = reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupStatoRichiesta.getSumRichiestePersonali.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }

            return returnValue;
        }
        
        #endregion

    }
}
