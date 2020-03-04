#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   Categoria.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per CATEGORIA
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
using SDG.Utility;
using System.Collections.Generic;

namespace BusinessObjects
{
	/// <summary>
	/// Tabella CENTRI DI COSTO 
	/// </summary>
	public class Centri_di_costo
	{
		#region attributi e variabili

	    private SqlInt32 cdc_id_centro_di_costo = SqlInt32.Null;
	    private SqlString cdc_codice_centro_di_costo = SqlString.Null;
	    private SqlString cdc_descrizione = SqlString.Null;
	    private SqlInt32 cdc_flag_visibile = SqlInt32.Null;
	    private SqlInt32 cdc_flag_eliminato = SqlInt32.Null;
        private SqlInt32 ute_id_utente = SqlInt32.Null;
        private SqlInt32 crp_flag_autorizzatore_princ = SqlInt32.Null;
        private SqlInt32 crp_flag_notifica = SqlInt32.Null;
        private SqlInt32 crp_livello_autorizzazione = SqlInt32.Null;
        private SqlInt32 crp_id_cdc_autorizzatori = SqlInt32.Null;
        private SqlInt32 cdc_livelli_autorizzazione = SqlInt32.Null;
        //private SqlInt32 cdc_flag_arv = SqlInt32.Null;
        //private SqlInt32 cdc_flag_mim = SqlInt32.Null;
        //private SqlInt32 cdc_flag_mcm = SqlInt32.Null;
        //private SqlInt32 cdc_flag_mce = SqlInt32.Null;
        private SqlInt32 cra_id_cdc_responsabili_area = SqlInt32.Null;
        private SqlString tipo = SqlString.Null;
        private SqlInt32 cno_id_cdc_nro_ordine = SqlInt32.Null;
        private SqlString cno_descrizione = SqlString.Null;
        private SqlInt32 fnt_id_funzionalita = SqlInt32.Null;
        private SqlString ute_autorizzatore = SqlString.Null;
        private SqlInt32 cli_id_cliente = SqlInt32.Null;

		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cdc_id_centro_di_costo
		{
			get { return cdc_id_centro_di_costo; }
            set { cdc_id_centro_di_costo = value; }
		}

        public SqlInt32 Cli_id_cliente
        {
            get { return cli_id_cliente; }
            set { cli_id_cliente = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Crp_flag_autorizzatore_princ
        {
            get { return crp_flag_autorizzatore_princ; }
            set { crp_flag_autorizzatore_princ = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Crp_flag_notifica
        {
            get { return crp_flag_notifica; }
            set { crp_flag_notifica = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Crp_id_cdc_autorizzatori
        {
            get { return crp_id_cdc_autorizzatori; }
            set { crp_id_cdc_autorizzatori = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Fnt_id_funzionalita
        {
            get { return fnt_id_funzionalita; }
            set { fnt_id_funzionalita = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cdc_livelli_autorizzazione
        {
            get { return cdc_livelli_autorizzazione; }
            set { cdc_livelli_autorizzazione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Crp_livello_autorizzazione
        {
            get { return crp_livello_autorizzazione; }
            set { crp_livello_autorizzazione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cra_id_cdc_responsabili_area
        {
            get { return cra_id_cdc_responsabili_area; }
            set { cra_id_cdc_responsabili_area = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cno_id_cdc_nro_ordine
        {
            get { return cno_id_cdc_nro_ordine; }
            set { cno_id_cdc_nro_ordine = value; }
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
        public SqlString Ute_autorizzatore
        {
            get { return ute_autorizzatore; }
            set { ute_autorizzatore = value; }
        }

		/// <value>
		/// 
		/// </value>
		public SqlString Cdc_codice_centro_di_costo
		{
			get { return cdc_codice_centro_di_costo; }	
			set { cdc_codice_centro_di_costo = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlString Cno_descrizione
        {
            get { return cno_descrizione; }
            set { cno_descrizione = value; }
        }
		/// <value>
		/// 
		/// </value>
		public SqlString Cdc_descrizione
		{
			get { return cdc_descrizione; }	
			set { cdc_descrizione = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlString Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cdc_flag_visibile
		{
			get { return cdc_flag_visibile; }	
			set { cdc_flag_visibile = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cdc_flag_eliminato
		{
			get { return cdc_flag_eliminato; }	
			set { cdc_flag_eliminato = value; }
		}

        ///// <value>
        ///// 
        ///// </value>
        //public SqlInt32 Cdc_flag_arv
        //{
        //    get { return cdc_flag_arv; }
        //    set { cdc_flag_arv = value; }
        //}

        ///// <value>
        ///// 
        ///// </value>
        //public SqlInt32 Cdc_flag_mim
        //{
        //    get { return cdc_flag_mim; }
        //    set { cdc_flag_mim = value; }
        //}

        ///// <value>
        ///// 
        ///// </value>
        //public SqlInt32 Cdc_flag_mcm
        //{
        //    get { return cdc_flag_mcm; }
        //    set { cdc_flag_mcm = value; }
        //}

        ///// <value>
        ///// 
        ///// </value>
        //public SqlInt32 Cdc_flag_mce
        //{
        //    get { return cdc_flag_mce; }
        //    set { cdc_flag_mce = value; }
        //}


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
		public Centri_di_costo()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_cdc_id_centro_di_costo)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 CENTRI_DI_COSTO.cdc_id_centro_di_costo, 
					 CENTRI_DI_COSTO.cdc_descrizione, 
					 CENTRI_DI_COSTO.cdc_flag_visibile, 
					 CENTRI_DI_COSTO.cdc_flag_eliminato, 
					 CENTRI_DI_COSTO.cdc_codice_centro_di_costo,                     
                     CENTRI_DI_COSTO.cdc_livelli_autorizzazione,                    
                     --CENTRI_DI_COSTO.cdc_flag_arv,
                     --CENTRI_DI_COSTO.cdc_flag_mim,
                     --CENTRI_DI_COSTO.cdc_flag_mcm,
                     --CENTRI_DI_COSTO.cdc_flag_mce,
                     CENTRI_DI_COSTO.CLI_ID_CLIENTE                     
				 	 FROM CENTRI_DI_COSTO WHERE 
					 (cdc_id_centro_di_costo = @cdc_id_centro_di_costo) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, p_cdc_id_centro_di_costo);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{					
					cdc_id_centro_di_costo = reader.GetSqlInt32(0);
                    cdc_descrizione = reader.GetSqlString(1);
                    cdc_flag_visibile = reader.GetSqlInt32(2);
                    cdc_flag_eliminato = reader.GetSqlInt32(3);
                    cdc_codice_centro_di_costo = reader.GetSqlString(4);
                    cdc_livelli_autorizzazione = reader.GetSqlInt32(5);
                    cli_id_cliente = reader.GetSqlInt32(6);                    
				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "Centri_di_costo.Read.");
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

        public void ReadByCDC(SqlString p_cdc_codice_centro_di_costo, SqlInt32 p_cli_id_cliente)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            cdc_id_centro_di_costo = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 CENTRI_DI_COSTO.cdc_id_centro_di_costo 
					 FROM CENTRI_DI_COSTO WHERE 
					 (cdc_codice_centro_di_costo = @cdc_codice_centro_di_costo) 
                     AND
                     (cli_id_cliente = @cli_id_cliente)
                     AND (CDC_FLAG_ELIMINATO = 0)
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "cdc_codice_centro_di_costo", DbType.String, p_cdc_codice_centro_di_costo);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    cdc_id_centro_di_costo = reader.GetSqlInt32(0);                
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Centri_di_costo.ReadByCDC.");
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

        public void ReadByUser(SqlInt32 p_ute_id_utente)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            cdc_codice_centro_di_costo = string.Empty;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 CENTRI_DI_COSTO.cdc_codice_centro_di_costo 
					 FROM CENTRI_DI_COSTO 
                     INNER JOIN UTENTE ON CENTRI_DI_COSTO.CDC_ID_CENTRO_DI_COSTO = UTENTE.CDC_ID_CENTRO_DI_COSTO
                     WHERE 
					 (utente.ute_id_utente = @ute_id_utente) 
                     AND (CDC_FLAG_ELIMINATO = 0)
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);                
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, p_ute_id_utente);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    cdc_codice_centro_di_costo = reader.GetSqlString(0);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Centri_di_costo.ReadByCDC.");
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
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void ReadAutorizzatori(SqlInt32 p_crp_id_cdc_autorizzatori)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 cdc_id_centro_di_costo, 
					 ute_id_utente, 
					 crp_flag_autorizzatore_princ, 
					 crp_livello_autorizzazione, 
					 crp_flag_notifica
				 	 FROM CROSS_CDC_AUTORIZZATORI WHERE 
					 (crp_id_cdc_autorizzatori = @crp_id_cdc_autorizzatori) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "crp_id_cdc_autorizzatori", DbType.Int32, p_crp_id_cdc_autorizzatori);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    cdc_id_centro_di_costo = reader.GetSqlInt32(0);
                    ute_id_utente = reader.GetSqlInt32(1);
                    crp_flag_autorizzatore_princ = reader.GetSqlInt32(2);
                    crp_livello_autorizzazione = reader.GetSqlInt32(3);
                    crp_flag_notifica = reader.GetSqlInt32(4);                    
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Centri_di_costo.ReadAutorizzatori.");
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
		/// Aggiorna l'ggetto nella base dati
		/// </summary>	
        public void Update(SqlInt32 p_cdc_id_centro_di_costo)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE CENTRI_DI_COSTO SET					 
					 cdc_descrizione = @cdc_descrizione,
					 cdc_flag_visibile = @cdc_flag_visibile,
					 cdc_flag_eliminato = @cdc_flag_eliminato,
					 cdc_codice_centro_di_costo = @cdc_codice_centro_di_costo,
                     cdc_livelli_autorizzazione = @cdc_livelli_autorizzazione,
                     --cdc_flag_arv = @cdc_flag_arv,
                     --cdc_flag_mim = @cdc_flag_mim,
                     --cdc_flag_mcm = @cdc_flag_mcm,
                     --cdc_flag_mce = @cdc_flag_mce,
                     cli_id_cliente = @cli_id_cliente                     
					 WHERE   
				     (cdc_id_centro_di_costo = @cdc_id_centro_di_costo) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cdc_descrizione", DbType.String, cdc_descrizione);
                db.AddInParameter(dbCommand, "cdc_codice_centro_di_costo", DbType.String, cdc_codice_centro_di_costo);
                db.AddInParameter(dbCommand, "cdc_flag_visibile", DbType.Int32, cdc_flag_visibile);
                db.AddInParameter(dbCommand, "cdc_flag_eliminato", DbType.Int32, cdc_flag_eliminato);				
                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, p_cdc_id_centro_di_costo);
                db.AddInParameter(dbCommand, "cdc_livelli_autorizzazione", DbType.Int32, cdc_livelli_autorizzazione);
                //db.AddInParameter(dbCommand, "cdc_flag_arv", DbType.Int32, cdc_flag_arv);
                //db.AddInParameter(dbCommand, "cdc_flag_mim", DbType.Int32, cdc_flag_mim);
                //db.AddInParameter(dbCommand, "cdc_flag_mcm", DbType.Int32, cdc_flag_mcm);
                //db.AddInParameter(dbCommand, "cdc_flag_mce", DbType.Int32, cdc_flag_mce);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);                
                db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Centri_di_costo.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void UpdateAutorizzatori(SqlInt32 p_crp_id_cdc_autorizzatori)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE CROSS_CDC_AUTORIZZATORI SET					 
					 cdc_id_centro_di_costo = @cdc_id_centro_di_costo,
                     ute_id_utente = @ute_id_utente,
                     crp_flag_autorizzatore_princ = @crp_flag_autorizzatore_princ,
                     crp_livello_autorizzazione = @crp_livello_autorizzazione,
                     crp_flag_notifica = @crp_flag_notifica
					 WHERE   
				     (crp_id_cdc_autorizzatori = @crp_id_cdc_autorizzatori) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, cdc_id_centro_di_costo);
                db.AddInParameter(dbCommand, "crp_flag_notifica", DbType.Int32, crp_flag_notifica);
                db.AddInParameter(dbCommand, "crp_id_cdc_autorizzatori", DbType.Int32, p_crp_id_cdc_autorizzatori);
                db.AddInParameter(dbCommand, "crp_flag_autorizzatore_princ", DbType.Int32, crp_flag_autorizzatore_princ);
                db.AddInParameter(dbCommand, "crp_livello_autorizzazione", DbType.Int32, crp_livello_autorizzazione);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Centri_di_costo.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public void Delete(SqlInt32 p_cdc_id_centro_di_costo)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE CENTRI_DI_COSTO SET CDC_FLAG_ELIMINATO = 1 WHERE 
					(cdc_id_centro_di_costo = @cdc_id_centro_di_costo) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, p_cdc_id_centro_di_costo);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Centri_di_costo.Delete.");
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
	
				sqlCommand = @" INSERT INTO CENTRI_DI_COSTO (
						cdc_descrizione, 
						cdc_codice_centro_di_costo, 
						cdc_flag_visibile, 
						cdc_flag_eliminato,
                        cdc_livelli_autorizzazione,
                        --cdc_flag_arv,cdc_flag_mim,cdc_flag_mcm,cdc_flag_mce,
                        cli_id_cliente                        
                        )
					VALUES ( 
						@cdc_descrizione, 
						@cdc_codice_centro_di_costo, 
						1,0,@cdc_livelli_autorizzazione,
                        --@cdc_flag_arv,@cdc_flag_mim,@cdc_flag_mcm,@cdc_flag_mce,
                        @cli_id_cliente                        
                        ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cdc_descrizione", DbType.String, cdc_descrizione);
                db.AddInParameter(dbCommand, "cdc_codice_centro_di_costo", DbType.String, cdc_codice_centro_di_costo);
                db.AddInParameter(dbCommand, "cdc_flag_visibile", DbType.Int32, cdc_flag_visibile);
                db.AddInParameter(dbCommand, "cdc_flag_eliminato", DbType.Int32, cdc_flag_eliminato);
                db.AddInParameter(dbCommand, "cdc_livelli_autorizzazione", DbType.Int32, cdc_livelli_autorizzazione);
                //db.AddInParameter(dbCommand, "cdc_flag_arv", DbType.Int32, cdc_flag_arv);
                //db.AddInParameter(dbCommand, "cdc_flag_mim", DbType.Int32, cdc_flag_mim);
                //db.AddInParameter(dbCommand, "cdc_flag_mcm", DbType.Int32, cdc_flag_mcm);
                //db.AddInParameter(dbCommand, "cdc_flag_mce", DbType.Int32, cdc_flag_mce);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);                
				
 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					cdc_id_centro_di_costo = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "Centri_di_costo.Create.");
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
        /// Elenca tutti gli elementi Categoria dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public DataSet List()
        {
            return List(string.Empty, "CENTRI_DI_COSTO");
        }
		/// <summary>
		/// Elenca tutti gli elementi Categoria dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public DataSet List(string sqlWhereClause) 
		{
            return List(sqlWhereClause, "CENTRI_DI_COSTO");
		}
		/// <summary>
		/// Elenca tutti gli elementi Categoria dell'analisi. L'utente può scegliere il nome della tabella nel dataset
		/// </summary>
		public DataSet List(string sqlWhereClause, string tableName) 
		{
			string sqlCommand = null;
			StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
            DataSet ds = new DataSet();
			
			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            
				sb.Append(@"
					        SELECT 
                            CENTRI_DI_COSTO.cdc_id_centro_di_costo, 
                            CENTRI_DI_COSTO.cdc_codice_centro_di_costo, 
                            CENTRI_DI_COSTO.cdc_descrizione, 
                            CENTRI_DI_COSTO.cdc_flag_visibile, 
                            CENTRI_DI_COSTO.cdc_flag_eliminato,
                            CLIENTI.CLI_RAGIONE_SOCIALE,
                            CENTRI_DI_COSTO.cdc_livelli_autorizzazione as CRP_LIVELLO_AUTORIZZAZIONE,
                            dbo.fnGetAutorizzatori(CENTRI_DI_COSTO.cdc_id_centro_di_costo,'" + tipo + @"') as AUTORIZZATORE_PRINC,CENTRI_DI_COSTO.CLI_ID_CLIENTE
                            FROM CENTRI_DI_COSTO INNER JOIN CLIENTI ON CENTRI_DI_COSTO.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE                
                            WHERE CDC_FLAG_VISIBILE = 1 AND CDC_FLAG_ELIMINATO = 0 ");

			    if (SqlWhereClause != string.Empty)
			    {
				    sb.Append(SqlWhereClause);
			    }

                sb.Append(" ORDER BY CDC_CODICE_CENTRO_DI_COSTO ");                                
				
                sqlCommand = sb.ToString();
				dbCommand = db.GetSqlStringCommand(sqlCommand);
				db.LoadDataSet(dbCommand, ds, tableName);								
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Centri_di_costo.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

        public DataSet ListForExport(string sqlWhereClause)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"
					        SELECT 
                            CLIENTI.CLI_RAGIONE_SOCIALE AS [RAGIONE_SOCIALE],
                            CENTRI_DI_COSTO.cdc_codice_centro_di_costo AS [CODICE], 
                            CENTRI_DI_COSTO.cdc_descrizione AS [DESCRIZIONE],                             
                            CCB_ANNO AS [ANNO],CCB_IMPORTO_BUDGET AS [IMPORTO BUDGET],CCB_IMPORTO_SPESO AS [IMPORTO SPESO],CCB_IMPORTO_RESIDUO AS [IMPORTO_RESIDUO]
                            FROM CENTRI_DI_COSTO INNER JOIN CLIENTI ON CENTRI_DI_COSTO.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE
                            INNER JOIN CROSS_CDC_BUDGET ON CENTRI_DI_COSTO.CDC_ID_CENTRO_DI_COSTO = CROSS_CDC_BUDGET.CDC_ID_CENTRO_DI_COSTO                
                            WHERE CDC_FLAG_VISIBILE = 1 AND CDC_FLAG_ELIMINATO = 0 ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sb.Append(" ORDER BY CDC_CODICE_CENTRO_DI_COSTO,CCB_ANNO DESC ");

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "CENTRI_DI_COSTO");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Centri_di_costo.ListForExport.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public DataSet ListCDC()
        {
            string WhereClause = SqlWhereClause;
            return List(WhereClause);        
        }

        public Dictionary<int, string> getLookupCdc()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            Dictionary<int, string> list = new Dictionary<int, string>();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append("SELECT ");
                sb.Append("CENTRI_DI_COSTO.CDC_ID_CENTRO_DI_COSTO AS [key], ");
                sb.Append("COALESCE(CENTRI_DI_COSTO.CDC_CODICE_CENTRO_DI_COSTO + ' - ' + CDC_DESCRIZIONE, CDC_CODICE_CENTRO_DI_COSTO) AS value ");
                sb.Append("FROM CENTRI_DI_COSTO WITH (NOLOCK) ");
                sb.Append(@sqlWhereClause);

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);

                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetInt32(0), reader.GetString(1));
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Centri_di_Costo.getLookupCdc.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
            }
        }


        /// <summary>
        /// getDsLookupCdc
        /// </summary>        
        /// <returns></returns>
        public DataSet getDsLookupCdc()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append("SELECT ");
                sb.Append("CENTRI_DI_COSTO.CDC_ID_CENTRO_DI_COSTO AS [key], ");
                sb.Append("COALESCE(CENTRI_DI_COSTO.CDC_CODICE_CENTRO_DI_COSTO + ' - ' + CDC_DESCRIZIONE, CDC_CODICE_CENTRO_DI_COSTO) AS value, ");
                sb.Append("CDC_FLAG_ELIMINATO AS eliminato ");
                sb.Append("FROM CENTRI_DI_COSTO WITH (NOLOCK) ");
                sb.Append(@sqlWhereClause);

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "CENTRI_DI_COSTO");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Centri_di_Costo.getDsLookupCdc.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Elenca tutti gli elementi Categoria dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListAutorizzatoriByCDC(int myParCdc)
        {
           DataSet ds = new DataSet();

            try
            {
                if (myParCdc == SqlInt32.Null)
                {
                    myParCdc = 0;
                }

                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                string sqlCommand = @" SELECT
					CROSS_CDC_AUTORIZZATORI.crp_id_cdc_autorizzatori,UTENTE.UTE_ID_UTENTE, 
					COALESCE(UTENTE.ute_cognome + ' ' + UTENTE.ute_nome,UTENTE.ute_cognome) as AUTORIZZATORE, 
					CROSS_CDC_AUTORIZZATORI.crp_flag_autorizzatore_princ,FNT_DESCRIZIONE_ITA					
				    FROM CROSS_CDC_AUTORIZZATORI LEFT JOIN UTENTE ON CROSS_CDC_AUTORIZZATORI.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE
                    LEFT JOIN FUNZIONALITA ON CROSS_CDC_AUTORIZZATORI.CRP_LIVELLO_AUTORIZZAZIONE = FNT_ID_FUNZIONALITA
                    WHERE CROSS_CDC_AUTORIZZATORI.CDC_ID_CENTRO_DI_COSTO = " + @myParCdc + " AND FNT_ACRONIMO_FUNZIONALITA IN('APPLIV1','APPLIV2') ";               

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParCdc", DbType.Int32, myParCdc);

                db.LoadDataSet(dbCommand, ds, "CROSS_CDC_AUTORIZZATORI");

                return ds;
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (ds != null)
                    ((IDisposable)ds).Dispose();
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi Categoria dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListAutorizzatoriALLByCDC(int myParCdc)
        {
            DataSet ds = new DataSet();

            try
            {
                if (myParCdc == SqlInt32.Null)
                {
                    myParCdc = 0;
                }

                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                string sqlCommand = @" SELECT
					CROSS_CDC_AUTORIZZATORI.crp_id_cdc_autorizzatori,UTENTE.UTE_ID_UTENTE, 
					COALESCE(UTENTE.ute_cognome + ' ' + UTENTE.ute_nome,UTENTE.ute_cognome) as AUTORIZZATORE, 
					CROSS_CDC_AUTORIZZATORI.crp_flag_autorizzatore_princ,FNT_DESCRIZIONE_ITA,CRP_FLAG_NOTIFICA					
				    FROM CROSS_CDC_AUTORIZZATORI LEFT JOIN UTENTE ON CROSS_CDC_AUTORIZZATORI.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE
                    LEFT JOIN FUNZIONALITA ON CROSS_CDC_AUTORIZZATORI.CRP_LIVELLO_AUTORIZZAZIONE = FNT_ID_FUNZIONALITA
                    WHERE CROSS_CDC_AUTORIZZATORI.CDC_ID_CENTRO_DI_COSTO = " + @myParCdc;

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParCdc", DbType.Int32, myParCdc);

                db.LoadDataSet(dbCommand, ds, "CROSS_CDC_AUTORIZZATORI");

                return ds;
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (ds != null)
                    ((IDisposable)ds).Dispose();
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi Categoria dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListResponsabiliByCDC(int myParCdc)
        {
            DataSet ds = new DataSet();

            try
            {
                if (myParCdc == SqlInt32.Null)
                {
                    myParCdc = 0;
                }

                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                string sqlCommand = @" SELECT
					CROSS_CDC_RESPONSABILI_AREA.cra_id_cdc_responsabili_area,UTENTE.UTE_ID_UTENTE, 
					COALESCE(UTENTE.ute_cognome + ' ' + UTENTE.ute_nome,UTENTE.ute_cognome) as RESPONSABILE					
				    FROM CROSS_CDC_RESPONSABILI_AREA LEFT JOIN UTENTE ON CROSS_CDC_RESPONSABILI_AREA.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE                    
                    WHERE CROSS_CDC_RESPONSABILI_AREA.CDC_ID_CENTRO_DI_COSTO = " + @myParCdc;

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParCdc", DbType.Int32, myParCdc);

                db.LoadDataSet(dbCommand, ds, "CROSS_CDC_RESPONSABILI_AREA");

                return ds;
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (ds != null)
                    ((IDisposable)ds).Dispose();
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi Categoria dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListOrdiniByCDC(int myParCdc)
        {
            DataSet ds = new DataSet();

            try
            {
                if (myParCdc == SqlInt32.Null)
                {
                    myParCdc = 0;
                }

                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                string sqlCommand = @" SELECT
					CROSS_CDC_NRO_ORDINI.cno_id_cdc_nro_ordine,cno_descrizione					
				    FROM CROSS_CDC_NRO_ORDINI
                    WHERE CROSS_CDC_NRO_ORDINI.CDC_ID_CENTRO_DI_COSTO = " + @myParCdc;

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParCdc", DbType.Int32, myParCdc);

                db.LoadDataSet(dbCommand, ds, "CROSS_CDC_NRO_ORDINI");

                return ds;
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (ds != null)
                    ((IDisposable)ds).Dispose();
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi Categoria dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListBudgetByCDC(int myParCdc)
        {
            DataSet ds = new DataSet();

            try
            {
                if (myParCdc == SqlInt32.Null)
                {
                    myParCdc = 0;
                }

                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                string sqlCommand = @" SELECT
					CROSS_CDC_BUDGET.CCB_ID_BUDGET,CCB_ANNO,CCB_IMPORTO_BUDGET,CCB_IMPORTO_RESIDUO,CCB_IMPORTO_SPESO
				    FROM CROSS_CDC_BUDGET
                    WHERE CROSS_CDC_BUDGET.CDC_ID_CENTRO_DI_COSTO = " + @myParCdc;

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParCdc", DbType.Int32, myParCdc);

                db.LoadDataSet(dbCommand, ds, "CROSS_CDC_BUDGET");

                return ds;
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (ds != null)
                    ((IDisposable)ds).Dispose();
            }
        }
     
        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void ReadAutorizzatoriResponsabili()
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
                     CDC_ID_CENTRO_DI_COSTO,
					 CROSS_CDC_AUTORIZZATORI.UTE_ID_UTENTE, 					 
                     CRP_FLAG_AUTORIZZATORE_PRINC,
                     CRP_LIVELLO_AUTORIZZAZIONE,
                     COALESCE(UTE_COGNOME + ' ' + UTE_NOME,UTE_COGNOME) AUTORIZZATORE   
				 	 FROM CROSS_CDC_AUTORIZZATORI 
                     LEFT JOIN UTENTE ON CROSS_CDC_AUTORIZZATORI.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE
                     WHERE 
					 (CDC_ID_CENTRO_DI_COSTO =@cdc_id_centro_di_costo AND UTE_ID_UTENTE = @ute_id_utente) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, cdc_id_centro_di_costo);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    cdc_id_centro_di_costo = reader.GetSqlInt32(0);
                    ute_id_utente = reader.GetSqlInt32(1);
                    crp_flag_autorizzatore_princ = reader.GetSqlInt32(2);
                    crp_livello_autorizzazione = reader.GetSqlInt32(3);
                    ute_autorizzatore = reader.GetSqlString(4);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.Read.");
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
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void ResetAutorizzatorePrinc()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE CROSS_CDC_AUTORIZZATORI SET 
					 crp_flag_autorizzatore_princ = 0					 
					 WHERE   
				     (CDC_ID_CENTRO_DI_COSTO =@cdc_id_centro_di_costo AND crp_livello_autorizzazione = @crp_livello_autorizzazione) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, cdc_id_centro_di_costo);
                db.AddInParameter(dbCommand, "crp_livello_autorizzazione", DbType.Int32, crp_livello_autorizzazione);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.ResetAutorizzatorePrinc.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void CreateAutorizzatore()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO CROSS_CDC_AUTORIZZATORI 
                        (
						    ute_id_utente, 						    
                            cdc_id_centro_di_costo,
						    crp_flag_autorizzatore_princ ,
                            crp_livello_autorizzazione,
                            crp_flag_notifica
						) 
					VALUES 
                        ( 
						    @ute_id_utente, 
						    @cdc_id_centro_di_costo, 
						    @crp_flag_autorizzatore_princ,
                            @crp_livello_autorizzazione,
                            @crp_flag_notifica
						) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, cdc_id_centro_di_costo);
                db.AddInParameter(dbCommand, "crp_flag_autorizzatore_princ", DbType.Int32, crp_flag_autorizzatore_princ);
                db.AddInParameter(dbCommand, "crp_livello_autorizzazione", DbType.Int32, crp_livello_autorizzazione);
                db.AddInParameter(dbCommand, "crp_flag_notifica", DbType.Int32, crp_flag_notifica);

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    //crp_id_cdc_autorizzatori = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.CreateAutorizzatore.");
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

        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void CreateResponsabile()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO CROSS_CDC_RESPONSABILI_AREA 
                        (
						    ute_id_utente, 						    
                            cdc_id_centro_di_costo,
                            fnt_id_funzionalita						    
						) 
					VALUES 
                        ( 
						    @ute_id_utente, 
						    @cdc_id_centro_di_costo,
                            @fnt_id_funzionalita
						) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, cdc_id_centro_di_costo);
                db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);                

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    //crp_id_cdc_autorizzatori = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.CreateResponsabile.");
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

        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void CreateOrdine()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO CROSS_CDC_NRO_ORDINI 
                        (						    
                            cdc_id_centro_di_costo,
                            cno_descrizione

						) 
					VALUES 
                        ( 						    
						    @cdc_id_centro_di_costo,
                            @cno_descrizione
						) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cno_descrizione", DbType.String, cno_descrizione);
                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, cdc_id_centro_di_costo);

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    //crp_id_cdc_autorizzatori = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.CreateOrdine.");
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

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public void DeleteAutorizzatoriCdc()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM CROSS_CDC_AUTORIZZATORI WHERE 
					(CRP_ID_CDC_AUTORIZZATORI =@crp_id_cdc_autorizzatori) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "crp_id_cdc_autorizzatori", DbType.Int32, crp_id_cdc_autorizzatori);                

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.DeleteAutorizzatoriCdc.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public void DeleteResponsabiliCdc()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM CROSS_CDC_RESPONSABILI_AREA WHERE 
					(CRA_ID_CDC_RESPONSABILI_AREA =@cra_id_cdc_responsabili_area) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "cra_id_cdc_responsabili_area", DbType.Int32, cra_id_cdc_responsabili_area);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.DeleteResponsabiliCdc.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public void DeleteOrdiniCdc()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM CROSS_CDC_NRO_ORDINI WHERE 
					(CNO_ID_CDC_NRO_ORDINE =@cno_id_cdc_nro_ordine) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "cno_id_cdc_nro_ordine", DbType.Int32, cno_id_cdc_nro_ordine);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Utente.DeleteOrdiniCdc.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi Categoria dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet GetDdlCentroDiCosto()
        {
            return GetDdlCentroDiCosto(string.Empty, "CENTRI_DI_COSTO");
        }
        /// <summary>
        /// Elenca tutti gli elementi Categoria dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        /// <param name="sqlWhereClause"></param>
        /// <returns></returns>
        public static DataSet GetDdlCentroDiCosto(string sqlWhereClause)
        {
            return GetDdlCentroDiCosto(sqlWhereClause, "CENTRI_DI_COSTO");
        }
        /// <summary>
        /// Elenca tutti gli elementi Categoria dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        /// <param name="sqlWhereClause"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataSet GetDdlCentroDiCosto(string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					CENTRI_DI_COSTO.cdc_id_centro_di_costo, 
					CENTRI_DI_COSTO.cdc_codice_centro_di_costo, 
					CENTRI_DI_COSTO.cdc_descrizione, 
					CENTRI_DI_COSTO.cdc_codice_centro_di_costo + ' - ' + CENTRI_DI_COSTO.cdc_descrizione as codice_descrizione, 
					CENTRI_DI_COSTO.cdc_flag_visibile, 
					CENTRI_DI_COSTO.cdc_flag_eliminato					
				    FROM CENTRI_DI_COSTO WHERE CDC_FLAG_VISIBILE = 1 AND CDC_FLAG_ELIMINATO = 0
                     ");

                sb.Append(sqlWhereClause);
                sb.Append(" ORDER BY CDC_CODICE_CENTRO_DI_COSTO");

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, tableName);               
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Centri_di_costo.GetDdlCentroDiCosto.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public bool checkCDCExist(string codiceCDC, int idCliente)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            SqlDataReader reader = null;
            DbCommand dbCommand = null;
            bool returnValue = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					CDC_ID_CENTRO_DI_COSTO
				    FROM CENTRI_DI_COSTO                    
                    WHERE 
                    CENTRI_DI_COSTO.CDC_CODICE_CENTRO_DI_COSTO = @cdc_codice_centro_di_costo AND CLI_ID_CLIENTE = @cli_id_cliente ");

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "cdc_codice_centro_di_costo", DbType.String, codiceCDC);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, idCliente);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                //AR 14/09/2011 Siccome basta che venga trovato qualcosa, ci limitiamo a testare HasRows
                //while (reader.Read())
                //{
                //    returnValue = true;
                //}

                if (reader.HasRows)
                    returnValue = true;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CentriDiCostoBudget.checkCDCBudget.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                //AR 14/09/2011 Superfluo (è già il default)
                //returnValue = false;
            }

            return returnValue;

        }
				
		#endregion

	}
}
