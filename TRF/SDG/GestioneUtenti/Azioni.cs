#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Azioni.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per AZIONI
//
// Autore:      AR - SDG srl
// Data:        07/07/2008
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
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using SDG.Utility;
using SDG.ExceptionHandling;

namespace SDG.GestioneUtenti
{
	/// <summary>
	/// Tabella AZIONI 
	/// </summary>
	public class Azioni
	{
		#region attributi e variabili

	    private SqlInt32 azi_id_azione_funzione = SqlInt32.Null;
	    private SqlInt32 fnt_id_funzionalita = SqlInt32.Null;
	    private SqlString azi_descrizione = SqlString.Null;
	    private SqlDateTime azi_data_creazione = SqlDateTime.Null;
	    private SqlDateTime azi_data_aggiornamento = SqlDateTime.Null;
	    private SqlInt32 azi_creato_da = SqlInt32.Null;
	    private SqlInt32 azi_aggiornato_da = SqlInt32.Null;
		
		private string sqlWhereClause = "";
		private DataSet azioniListDS;

		#endregion

		#region Proprieta
		

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Azi_id_azione_funzione
		{
			get { return  azi_id_azione_funzione; }
			set { azi_id_azione_funzione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Fnt_id_funzionalita
		{
			get { return  fnt_id_funzionalita; }
			set { fnt_id_funzionalita = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Azi_descrizione
		{
			get { return  azi_descrizione; }
			set { azi_descrizione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlDateTime Azi_data_creazione
		{
			get { return  azi_data_creazione; }
			set { azi_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlDateTime Azi_data_aggiornamento
		{
			get { return  azi_data_aggiornamento; }
			set { azi_data_aggiornamento = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Azi_creato_da
		{
			get { return  azi_creato_da; }
			set { azi_creato_da = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Azi_aggiornato_da
		{
			get { return  azi_aggiornato_da; }
			set { azi_aggiornato_da = value; }
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
		/// Elenco degli elementi Azioni selezionati
		/// </value>
		public DataSet AzioniListDS
		{
			get { return  azioniListDS; }
			set { azioniListDS = value; }
		}

		#endregion
		
		#region  Costruttori

		/// <summary>
		/// Costruttore standard
		/// </summary>
		public Azioni()
		{
			azioniListDS = new DataSet();
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
					 AZIONI.AZI_ID_AZIONE_FUNZIONE, 
					 AZIONI.FNT_ID_FUNZIONALITA, 
					 AZIONI.AZI_DESCRIZIONE, 
					 AZIONI.AZI_DATA_CREAZIONE, 
					 AZIONI.AZI_DATA_AGGIORNAMENTO, 
					 AZIONI.AZI_CREATO_DA, 
					 AZIONI.AZI_AGGIORNATO_DA	 
				 	 FROM AZIONI WHERE 
					 (AZI_ID_AZIONE_FUNZIONE =@azi_id_azione_funzione) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "azi_id_azione_funzione", DbType.Int32, azi_id_azione_funzione);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					azi_id_azione_funzione = reader.GetSqlInt32(0);
					fnt_id_funzionalita = reader.GetSqlInt32(1);
					azi_descrizione = reader.GetSqlString(2);
					azi_data_creazione = reader.GetSqlDateTime(3);
					azi_data_aggiornamento = reader.GetSqlDateTime(4);
					azi_creato_da = reader.GetSqlInt32(5);
					azi_aggiornato_da = reader.GetSqlInt32(6);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "Azioni.Read.");
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

				sqlCommand = @" UPDATE AZIONI SET 
					 FNT_ID_FUNZIONALITA = @fnt_id_funzionalita, 
					 AZI_DESCRIZIONE = @azi_descrizione, 
					 AZI_DATA_CREAZIONE = @azi_data_creazione, 
					 AZI_DATA_AGGIORNAMENTO = @azi_data_aggiornamento, 
					 AZI_CREATO_DA = @azi_creato_da, 
					 AZI_AGGIORNATO_DA = @azi_aggiornato_da
					 WHERE   
				     (AZI_ID_AZIONE_FUNZIONE =@azi_id_azione_funzione) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);
				db.AddInParameter(dbCommand, "azi_descrizione", DbType.String, azi_descrizione);
				db.AddInParameter(dbCommand, "azi_data_creazione", DbType.DateTime, azi_data_creazione);
				db.AddInParameter(dbCommand, "azi_data_aggiornamento", DbType.DateTime, azi_data_aggiornamento);
				db.AddInParameter(dbCommand, "azi_creato_da", DbType.Int32, azi_creato_da);
				db.AddInParameter(dbCommand, "azi_aggiornato_da", DbType.Int32, azi_aggiornato_da);
										
				db.AddInParameter(dbCommand, "azi_id_azione_funzione", DbType.Int32, azi_id_azione_funzione);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Azioni.Update.");
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

				sqlCommand = @" DELETE FROM AZIONI WHERE 
					(AZI_ID_AZIONE_FUNZIONE =@azi_id_azione_funzione) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "azi_id_azione_funzione", DbType.Int32, azi_id_azione_funzione);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Azioni.Delete.");
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
	
				sqlCommand = @" INSERT INTO AZIONI (
						FNT_ID_FUNZIONALITA, 
						AZI_DESCRIZIONE, 
						AZI_DATA_CREAZIONE, 
						AZI_DATA_AGGIORNAMENTO, 
						AZI_CREATO_DA, 
						AZI_AGGIORNATO_DA	 ) 
					VALUES ( 
						@fnt_id_funzionalita, 
						@azi_descrizione, 
						@azi_data_creazione, 
						@azi_data_aggiornamento, 
						@azi_creato_da, 
						@azi_aggiornato_da	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);
				db.AddInParameter(dbCommand, "azi_descrizione", DbType.String, azi_descrizione);
				db.AddInParameter(dbCommand, "azi_data_creazione", DbType.DateTime, azi_data_creazione);
				db.AddInParameter(dbCommand, "azi_data_aggiornamento", DbType.DateTime, azi_data_aggiornamento);
				db.AddInParameter(dbCommand, "azi_creato_da", DbType.Int32, azi_creato_da);
				db.AddInParameter(dbCommand, "azi_aggiornato_da", DbType.Int32, azi_aggiornato_da);

 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					azi_id_azione_funzione = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "Azioni.Create.");
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
            return List(string.Empty, "AZIONI");
        }
		/// <summary>
		/// Elenca tutti gli elementi Azioni dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"AZIONI");
		}
		/// <summary>
		/// Elenca tutti gli elementi Azioni dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					AZIONI.AZI_ID_AZIONE_FUNZIONE, 
					AZIONI.FNT_ID_FUNZIONALITA, 
					AZIONI.AZI_DESCRIZIONE, 
					AZIONI.AZI_DATA_CREAZIONE, 
					AZIONI.AZI_DATA_AGGIORNAMENTO, 
					AZIONI.AZI_CREATO_DA, 
					AZIONI.AZI_AGGIORNATO_DA 
				FROM AZIONI ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, "AZIONI");
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Azioni.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}
						
		#endregion

	}
}
