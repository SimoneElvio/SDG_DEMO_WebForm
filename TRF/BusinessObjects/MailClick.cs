#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   MailClick.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per MAILCLICK
//
// Autore:      AR - SDG srl
// Data:        08/07/2010
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
	/// Tabella MAIL_CLICK 
	/// </summary>
	public class MailClick
	{
		#region attributi e variabili

	    private SqlInt32 mac_id_mail = SqlInt32.Null;
	    private SqlInt32 ute_id_utente = SqlInt32.Null;
	    private SqlInt32 riv_id_richiesta = SqlInt32.Null;
	    private SqlInt32 mac_stato_mail = SqlInt32.Null;
	    private SqlString mac_codice_univoco = SqlString.Null;
	    private SqlInt32 ute_creato_da = SqlInt32.Null;
	    private SqlInt32 ute_aggiornato_da = SqlInt32.Null;
	    private SqlDateTime mac_data_creazione = SqlDateTime.Null;
	    private SqlDateTime mac_data_aggiornamento = SqlDateTime.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Mac_id_mail
		{
			get { return mac_id_mail; }	
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
		public SqlInt32 Riv_id_richiesta
		{
			get { return riv_id_richiesta; }	
			set { riv_id_richiesta = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Mac_stato_mail
		{
			get { return mac_stato_mail; }	
			set { mac_stato_mail = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Mac_codice_univoco
		{
			get { return mac_codice_univoco; }	
			set { mac_codice_univoco = value; }
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
		public SqlDateTime Mac_data_creazione
		{
			get { return mac_data_creazione; }	
			set { mac_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Mac_data_aggiornamento
		{
			get { return mac_data_aggiornamento; }	
			set { mac_data_aggiornamento = value; }
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
		public MailClick()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_mac_id_mail)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 MAIL_CLICK.mac_id_mail, 
					 MAIL_CLICK.ute_id_utente, 
					 MAIL_CLICK.riv_id_richiesta, 
					 MAIL_CLICK.mac_stato_mail, 
					 MAIL_CLICK.mac_codice_univoco, 
					 MAIL_CLICK.ute_creato_da, 
					 MAIL_CLICK.ute_aggiornato_da, 
					 MAIL_CLICK.mac_data_creazione, 
					 MAIL_CLICK.mac_data_aggiornamento	 
				 	 FROM MAIL_CLICK WHERE 
					 (mac_id_mail = @mac_id_mail) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "mac_id_mail", DbType.Int32, p_mac_id_mail);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					mac_id_mail = reader.GetSqlInt32(0);
					ute_id_utente = reader.GetSqlInt32(1);
					riv_id_richiesta = reader.GetSqlInt32(2);
					mac_stato_mail = reader.GetSqlInt32(3);
					mac_codice_univoco = reader.GetSqlString(4);
					ute_creato_da = reader.GetSqlInt32(5);
					ute_aggiornato_da = reader.GetSqlInt32(6);
					mac_data_creazione = reader.GetSqlDateTime(7);
					mac_data_aggiornamento = reader.GetSqlDateTime(8);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "MailClick.Read.");
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
		public void Update(SqlInt32 p_mac_id_mail)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE MAIL_CLICK SET
					 ute_id_utente = @ute_id_utente, 
					 riv_id_richiesta = @riv_id_richiesta, 
					 mac_stato_mail = @mac_stato_mail, 
					 mac_codice_univoco = @mac_codice_univoco, 
					 ute_aggiornato_da = @ute_aggiornato_da, 
					 mac_data_aggiornamento = getdate()
					 WHERE   
				     (mac_id_mail = @mac_id_mail) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);
				db.AddInParameter(dbCommand, "mac_stato_mail", DbType.Int32, mac_stato_mail);
				db.AddInParameter(dbCommand, "mac_codice_univoco", DbType.String, mac_codice_univoco);
				db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
										
				db.AddInParameter(dbCommand, "mac_id_mail", DbType.Int32, p_mac_id_mail);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "MailClick.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete(SqlInt32 p_mac_id_mail)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM MAIL_CLICK WHERE 
					(mac_id_mail = @mac_id_mail) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "mac_id_mail", DbType.Int32, p_mac_id_mail);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "MailClick.Delete.");
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
	
				sqlCommand = @" INSERT INTO MAIL_CLICK (
						ute_id_utente, 
						riv_id_richiesta, 
						mac_stato_mail, 
						mac_codice_univoco, 
						ute_creato_da, 
						mac_data_creazione	 ) 
					VALUES ( 
						@ute_id_utente, 
						@riv_id_richiesta, 
						1, 
						@mac_codice_univoco, 
						@ute_creato_da, 
						getdate()	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);
				db.AddInParameter(dbCommand, "mac_stato_mail", DbType.Int32, mac_stato_mail);
				db.AddInParameter(dbCommand, "mac_codice_univoco", DbType.String, mac_codice_univoco);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);

 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					mac_id_mail = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "MailClick.Create.");
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
        /// Elenca tutti gli elementi MailClick dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "MAIL_CLICK");
        }
		/// <summary>
		/// Elenca tutti gli elementi MailClick dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"MAIL_CLICK");
		}
		/// <summary>
		/// Elenca tutti gli elementi MailClick dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					MAIL_CLICK.mac_id_mail, 
					MAIL_CLICK.ute_id_utente, 
					MAIL_CLICK.riv_id_richiesta, 
					MAIL_CLICK.mac_stato_mail, 
					MAIL_CLICK.mac_codice_univoco, 
					MAIL_CLICK.ute_creato_da, 
					MAIL_CLICK.ute_aggiornato_da, 
					MAIL_CLICK.mac_data_creazione, 
					MAIL_CLICK.mac_data_aggiornamento 
				FROM MAIL_CLICK ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["MAIL_CLICK"].Columns["mac_id_mail"];
				ds.Tables["MAIL_CLICK"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "MailClick.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}
						
		#endregion

	}
}
