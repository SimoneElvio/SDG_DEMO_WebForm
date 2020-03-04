#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   UtenteTrc.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe UTENTE_TRC
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

using System;
using System.Data;
using System.Data.SqlTypes;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SDG.ExceptionHandling;

namespace SDG.GestioneUtenti
{
	/// <summary>
	/// Tabella UTENTE_TRC 
	/// </summary>
	public class UtenteTrc
	{
		#region attributi e variabili

	    private  SqlInt32 ute_id_utente = SqlInt32.Null;
	    private  SqlBoolean flagupd_ute_id_utente = SqlBoolean.True;
	    private  SqlDateTime utr_data_creazione = SqlDateTime.Null;
	    private  SqlBoolean flagupd_utr_data_creazione = SqlBoolean.True;
	    private  SqlString ute_password = SqlString.Null;
	    private  SqlBoolean flagupd_ute_password = SqlBoolean.True;
		

		private string sqlWhereClause = "";
		private DataSet utente_trcListDS;

		// ---------------------------------------------------------------------
		// Costanti per facilitare il mapping con le colonne
		// Devono essere nello stesso ordine dei campi della tabella 
		// corrispondente
		// ---------------------------------------------------------------------		

	     private const int UTE_ID_UTENTE = 0;
	     private const int UTR_DATA_CREAZIONE = 1;
	     private const int UTE_PASSWORD = 2;

		#endregion

		#region Proprieta
		

		/// <value>
		/// 
		/// Viene settato di default il flagupd a True
		/// </value>
		public  SqlInt32 Ute_id_utente
		{
			get { return  ute_id_utente; }
			set { ute_id_utente = value; flagupd_ute_id_utente = SqlBoolean.True;}
		}


		/// <value>
		/// 
		/// Viene settato di default il flagupd a True
		/// </value>
		public  SqlDateTime Utr_data_creazione
		{
			get { return  utr_data_creazione; }
			set { utr_data_creazione = value; flagupd_utr_data_creazione = SqlBoolean.True;}
		}


		/// <value>
		/// 
		/// Viene settato di default il flagupd a True
		/// </value>
		public  SqlString Ute_password
		{
			get { return  ute_password; }
			set { ute_password = value; flagupd_ute_password = SqlBoolean.True;}
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
		/// Elenco degli elementi UtenteTrc selezionati
		/// </value>
		public DataSet Utente_trcListDS
		{
			get { return  utente_trcListDS; }
			set { utente_trcListDS = value; }
		}

		#endregion
		
		#region  Costruttori

		/// <summary>
		/// Costruttore standard
		/// </summary>
		public UtenteTrc()
		{
			utente_trcListDS = new DataSet();
		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void armFlags(SqlBoolean theFlag)
        {
			flagupd_ute_id_utente = theFlag;
			flagupd_utr_data_creazione = theFlag;
			flagupd_ute_password = theFlag;
		}

		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read()
		{
			IDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
                                UTENTE_TRC.UTE_ID_UTENTE, 
                                UTENTE_TRC.UTR_DATA_CREAZIONE, 
                                UTENTE_TRC.UTE_PASSWORD	 
                                FROM UTENTE_TRC WHERE 
                                UTE_ID_UTENTE = @ute_id_utente
                                AND UTR_DATA_CREAZIONE = @utr_data_creazione
                                ";

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "utr_data_creazione", DbType.DateTime, utr_data_creazione);

				reader = db.ExecuteReader(dbCommand);

                while (reader.Read()) 
				{
					ute_id_utente = (reader.IsDBNull(UTE_ID_UTENTE)) ? (SqlInt32.Null) : (reader.GetInt32(UTE_ID_UTENTE));
					utr_data_creazione = (reader.IsDBNull(UTR_DATA_CREAZIONE)) ? (SqlDateTime.Null) : (reader.GetDateTime(UTR_DATA_CREAZIONE));
					ute_password = (reader.IsDBNull(UTE_PASSWORD)) ? (SqlString.Null) : (reader.GetString(UTE_PASSWORD));
				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "UtenteTrc.Read.");
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
            StringBuilder sb = new StringBuilder(2000);
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append("UPDATE UTENTE_TRC SET ");
		 		if (flagupd_ute_id_utente == true)
		 		{
		 			sb.Append("UTE_ID_UTENTE = @ute_id_utente, ");
		 		}
		 		if (flagupd_utr_data_creazione == true)
		 		{
		 			sb.Append("UTR_DATA_CREAZIONE = @utr_data_creazione, ");
		 		}
		 		if (flagupd_ute_password == true)
		 		{
		 			sb.Append("UTE_PASSWORD = @ute_password	 ");
		 		}
				if (sb.ToString().EndsWith(", "))
				{
					sb.Replace(", ", " ", sb.Length-2, 2); 
				}
				sb.Append(" WHERE ");
                sb.Append("UTE_ID_UTENTE =@ute_id_utente ");
                sb.Append(" AND UTR_DATA_CREAZIONE = @utr_data_creazione ");

                sqlCommand = sb.ToString();
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "utr_data_creazione", DbType.DateTime, utr_data_creazione);
				if (flagupd_ute_password == true)
				{
					db.AddInParameter(dbCommand, "ute_password", DbType.String, ute_password);
				}

				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "UtenteTrc.Update.");
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

				sqlCommand = @" DELETE FROM UTENTE_TRC WHERE 
                            UTE_ID_UTENTE = @ute_id_utente
                            AND UTR_DATA_CREAZIONE = @utr_data_creazione ";

				dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "utr_data_creazione", DbType.DateTime, utr_data_creazione);

				db.ExecuteNonQuery(dbCommand);            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "UtenteTrc.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

		}
		
		/// <summary>
		/// Crea il record nella tabella di tracciamento password.
		/// </summary>
		public void Create() 
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
	
				sqlCommand = @" INSERT INTO UTENTE_TRC (
						            UTE_ID_UTENTE, 
						            UTE_PASSWORD) 
					            VALUES ( 
						            @ute_id_utente, 
						            @ute_password) ";										

				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "ute_password", DbType.String, ute_password);

				db.ExecuteNonQuery(dbCommand);
			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "UtenteTrc.Create.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

		}
		
		/// <summary>
		/// Elenca tutti gli elementi UtenteTrc dell'analisi
		/// </summary>
		public DataSet List() 
		{
			string sqlCommand = null;
			StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
			
			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            
				sb.Append(" SELECT ");
				sb.Append("UTENTE_TRC.UTE_ID_UTENTE, ");
				sb.Append("UTENTE_TRC.UTR_DATA_CREAZIONE, ");
				sb.Append("UTENTE_TRC.UTE_PASSWORD	 ");
				sb.Append("FROM UTENTE_TRC ");

				sb.Append(@sqlWhereClause);
				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);
				db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

				db.LoadDataSet(dbCommand, utente_trcListDS, "UTENTE_TRC");
				return utente_trcListDS; 
			
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "UtenteTrc.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

				return utente_trcListDS; 
			}

			finally
			{	
				if (utente_trcListDS != null)
					((IDisposable)utente_trcListDS).Dispose();
			}
		}
        
        /// <summary>
        /// Valida la nuova password dell'utente. In base ad alcuni parametri, deve essere diversa o dall'ultima o dalle ultime N.
        /// </summary>
        /// <param name="precedenti">Indica quante password devo controllare per verificare la validità della password attualmente inserita (default=1)</param>
        /// <returns>true se la password è accettabile, false altrimenti.
        /// </returns>
        public bool CheckPassword(int precedenti)
        {
            string sqlCmd;
            IDataReader objDr = null;
            bool pwdAccettabile = false;

            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            
            sqlCmd = "SELECT UTE_PASSWORD FROM (";
            sqlCmd += "SELECT TOP " + precedenti + " UTE_PASSWORD ";
            sqlCmd += @"FROM UTENTE_TRC WHERE UTE_ID_UTENTE = @ute_id_utente
                        ORDER BY UTR_DATA_CREAZIONE DESC
                        ) STORICO WHERE UTE_PASSWORD = @ute_password ";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCmd);
            db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
            db.AddInParameter(dbCommand, "ute_password", DbType.String, ute_password);

            try
            {
                //return 
                objDr = db.ExecuteReader(dbCommand);

                if (objDr.Read())
                {
                    //
                    // Se restituisce qualcosa (non importa cosa) la password è stata usata negli ultimi "precedenti" mesi: non si può usare
                    //
                    pwdAccettabile = false;
                }
                else
                {
                    //
                    // Se non restituisce nulla, la password non è stata usata negli ultimi "precedenti" mesi: si può usare
                    //
                    pwdAccettabile = true;
                }
            }
            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (objDr != null)
                    ((IDisposable)objDr).Dispose();
            }
            return pwdAccettabile;
        }

		#endregion

	}
}
