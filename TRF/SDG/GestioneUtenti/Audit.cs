#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Audit.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per AUDIT
//
// Autore:      AR - SDG srl
// Data:        27/06/2008
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using SDG.Utility;
using SDG.ExceptionHandling;

namespace SDG.GestioneUtenti
{
	/// <summary>
	/// Tabella AUDIT 
	/// </summary>
	public class Audit
	{
		#region attributi e variabili

	    private  SqlInt32 aud_id_audit = SqlInt32.Null;
	    private  SqlInt32 azi_id_azione_funzione = SqlInt32.Null;
	    private  SqlInt32 ute_id_utente = SqlInt32.Null;
        private  SqlString aud_ip_address = SqlString.Null;
	    private  SqlDateTime aud_data_creazione = SqlDateTime.Null;
	    private  SqlString aud_nota = SqlString.Null;
        private SqlString aud_device = SqlString.Null;

		private string sqlWhereClause = "";
		private DataSet auditListDS;

		#endregion

		#region Proprieta
		

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Aud_id_audit
		{
			get { return  aud_id_audit; }
			set { aud_id_audit = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Azi_id_azione_funzione
		{
			get { return  azi_id_azione_funzione; }
			set { azi_id_azione_funzione = value; }
		}

		/// <value>
		/// Identificatore dell'utente che viene replicato in tutte le tabelle.
		/// </value>
		public  SqlInt32 Ute_id_utente
		{
			get { return  ute_id_utente; }
			set { ute_id_utente = value; }
		}


        /// <value>
        /// Indirizzo IP dell'utente tracciato (per riferimento con errori in caso di scadenza sessione).
        /// </value>
        public SqlString Aud_ip_address
        {
            get { return aud_ip_address; }
            set { aud_ip_address = value; }
        }


		/// <value>
		/// 
		/// </value>
		public  SqlDateTime Aud_data_creazione
		{
			get { return  aud_data_creazione; }
			set { aud_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Aud_nota
		{
			get { return  aud_nota; }
			set { aud_nota = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlString Aud_device
        {
            get { return aud_device; }
            set { aud_device = value; }
        }

		/// <value>
		/// Where Clause condition
		/// </value>
		public  string SqlWhereClause
		{
			get { return  sqlWhereClause; }
			set { sqlWhereClause = value; }
		}

		/// <value>
		/// Elenco degli elementi Audit selezionati
		/// </value>
		public DataSet AuditListDS
		{
			get { return  auditListDS; }
			set { auditListDS = value; }
		}

		#endregion
		
		#region  Costruttori

		/// <summary>
		/// Costruttore standard
		/// </summary>
		public Audit()
		{
			auditListDS = new DataSet();
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
					 AUDIT.AUD_ID_AUDIT, 
					 AUDIT.AZI_ID_AZIONE_FUNZIONE, 
					 AUDIT.UTE_ID_UTENTE, 
					 AUDIT.AUD_IP_ADDRESS, 
					 AUDIT.AUD_DATA_CREAZIONE, 
					 AUDIT.AUD_NOTA	 
				 	FROM AUDIT WHERE 
					 (AUD_ID_AUDIT =@aud_id_audit) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "aud_id_audit", DbType.Int32, aud_id_audit);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					aud_id_audit = reader.GetSqlInt32(0);
					azi_id_azione_funzione = reader.GetSqlInt32(1);
					ute_id_utente = reader.GetSqlInt32(2);
                    aud_ip_address = reader.GetSqlString(3);
					aud_data_creazione = reader.GetSqlDateTime(4);
					aud_nota = reader.GetSqlString(5);
				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "Audit.Read.");
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

				sqlCommand = @" UPDATE AUDIT SET 
					 AZI_ID_AZIONE_FUNZIONE = @azi_id_azione_funzione, 
					 UTE_ID_UTENTE = @ute_id_utente, 
                     AUD_IP_ADDRESS = @aud_ip_address, 
					 AUD_DATA_CREAZIONE = @aud_data_creazione, 
					 AUD_NOTA = @aud_nota
					 WHERE   
				     (AUD_ID_AUDIT =@aud_id_audit) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

					db.AddInParameter(dbCommand, "azi_id_azione_funzione", DbType.Int32, azi_id_azione_funzione);
					db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                    db.AddInParameter(dbCommand, "aud_ip_address", DbType.String, aud_ip_address);
					db.AddInParameter(dbCommand, "aud_data_creazione", DbType.DateTime, aud_data_creazione);
					db.AddInParameter(dbCommand, "aud_nota", DbType.String, aud_nota);
										
		         db.AddInParameter(dbCommand, "aud_id_audit", DbType.Int32, aud_id_audit);

				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Audit.Update.");
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

				sqlCommand = @" DELETE FROM AUDIT WHERE 
					(AUD_ID_AUDIT =@aud_id_audit) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "aud_id_audit", DbType.Int32, aud_id_audit);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Audit.Delete.");
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

                sqlCommand = @" INSERT INTO AUDIT (
						AZI_ID_AZIONE_FUNZIONE, 
						UTE_ID_UTENTE, 
                        AUD_IP_ADDRESS, 
						AUD_DATA_CREAZIONE, 
						AUD_NOTA,AUD_DEVICE	 ) 
					VALUES ( 
						@azi_id_azione_funzione, 
						@ute_id_utente, 
                        @aud_ip_address, 
						@aud_data_creazione, 
						@aud_nota,@aud_device	 ) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "azi_id_azione_funzione", DbType.Int32, azi_id_azione_funzione);
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "aud_ip_address", DbType.String, aud_ip_address);
				db.AddInParameter(dbCommand, "aud_data_creazione", DbType.DateTime, aud_data_creazione);
				db.AddInParameter(dbCommand, "aud_nota", DbType.String, aud_nota);
                db.AddInParameter(dbCommand, "aud_device", DbType.String, aud_device);

 				dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    aud_id_audit = Convert.ToInt32(dataReader[0]);
                }
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "Audit.Create.");
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
        /// Elenca tutti gli elementi Piano_di_mitigazione dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "AUDIT");
        }
		/// <summary>
		/// Elenca tutti gli elementi Audit dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"AUDIT");
		}
		/// <summary>
		/// Elenca tutti gli elementi Audit dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					AUDIT.aud_id_audit, 
					AUDIT.AZI_ID_AZIONE_FUNZIONE, 
					AUDIT.UTE_ID_UTENTE, 
                    AUDIT.AUD_IP_ADDRESS, 
					AUDIT.aud_data_creazione, 
					AUDIT.aud_nota 
				FROM AUDIT ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

                sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, "AUDIT");
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Audit.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}


        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void TraceAction(string key)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" INSERT INTO AUDIT ( ");
                sb.Append("AZI_ID_AZIONE_FUNZIONE, ");
                sb.Append("AUD_IP_ADDRESS, ");
                sb.Append("UTE_ID_UTENTE,AUD_DEVICE ) ");
                sb.Append("SELECT ");
                sb.Append("AZIONI.AZI_ID_AZIONE_FUNZIONE, ");
                sb.Append("@aud_ip_address, ");
                sb.Append("@ute_id_utente,	 ");
                sb.Append("@aud_device ");
                sb.Append("FROM AZIONI ");
                sb.Append("WHERE AZIONI.AZI_DESCRIZIONE = '");
                sb.Append(key);
                sb.Append("'; SELECT SCOPE_IDENTITY(); ");

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "aud_ip_address", DbType.String, aud_ip_address);
                db.AddInParameter(dbCommand, "aud_device", DbType.String, aud_device);

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    aud_id_audit = Convert.ToInt32(dataReader[0]);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Audit.TraceAction.");
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
