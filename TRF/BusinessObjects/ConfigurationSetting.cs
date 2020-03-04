#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   ConfigurationSetting.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per CONFIGURATIONSETTING
//
// Autore:      AR - SDG srl
// Data:        05/04/2016
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
	/// Tabella CONFIGURATION_SETTING 
	/// </summary>
	public class ConfigurationSetting
	{
		#region attributi e variabili

	    private SqlInt32 set_id_configuration_setting = SqlInt32.Null;
	    private SqlInt32 set_id_utente = SqlInt32.Null;
	    private SqlString set_key = SqlString.Null;
	    private SqlString set_value = SqlString.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Set_id_configuration_setting
		{
			get { return set_id_configuration_setting; }	
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Set_id_utente
		{
			get { return set_id_utente; }	
			set { set_id_utente = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Set_key
		{
			get { return set_key; }	
			set { set_key = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Set_value
		{
			get { return set_value; }	
			set { set_value = value; }
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
		public ConfigurationSetting()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_set_id_configuration_setting)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 CONFIGURATION_SETTING.set_id_configuration_setting, 
					 CONFIGURATION_SETTING.set_id_utente, 
					 CONFIGURATION_SETTING.set_key, 
					 CONFIGURATION_SETTING.set_value	 
				 	 FROM CONFIGURATION_SETTING WHERE 
					 (set_id_configuration_setting = @set_id_configuration_setting) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "set_id_configuration_setting", DbType.Int32, p_set_id_configuration_setting);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					set_id_configuration_setting = reader.GetSqlInt32(0);
					set_id_utente = reader.GetSqlInt32(1);
					set_key = reader.GetSqlString(2);
					set_value = reader.GetSqlString(3);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "ConfigurationSetting.Read.");
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
		public void Update(SqlInt32 p_set_id_configuration_setting)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE CONFIGURATION_SETTING SET
					 set_id_utente = @set_id_utente, 
					 set_key = @set_key, 
					 set_value = @set_value
					 WHERE   
				     (set_id_configuration_setting = @set_id_configuration_setting) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "set_id_utente", DbType.Int32, set_id_utente);
				db.AddInParameter(dbCommand, "set_key", DbType.String, set_key);
				db.AddInParameter(dbCommand, "set_value", DbType.String, set_value);
										
				db.AddInParameter(dbCommand, "set_id_configuration_setting", DbType.Int32, p_set_id_configuration_setting);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "ConfigurationSetting.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete(SqlInt32 p_set_id_configuration_setting)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM CONFIGURATION_SETTING WHERE 
					(set_id_configuration_setting = @set_id_configuration_setting) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "set_id_configuration_setting", DbType.Int32, p_set_id_configuration_setting);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "ConfigurationSetting.Delete.");
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
	
				sqlCommand = @" INSERT INTO CONFIGURATION_SETTING (
						set_id_utente, 
						set_key, 
						set_value	 ) 
					VALUES ( 
						@set_id_utente, 
						@set_key, 
						@set_value	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "set_id_utente", DbType.Int32, set_id_utente);
				db.AddInParameter(dbCommand, "set_key", DbType.String, set_key);
				db.AddInParameter(dbCommand, "set_value", DbType.String, set_value);

 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					set_id_configuration_setting = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "ConfigurationSetting.Create.");
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
        /// Restituisce il value dalla tabella configuration setting
        /// </summary>
        /// <param name="p_key"></param>
        /// <returns>Value</returns>
        public string getValue(string p_key)
        {
            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            DbCommand dbCommand = null;
            string sqlCommand;
            SqlDataReader reader = null;

            string returnValue = string.Empty;

            try
            {
                //Recupero id richiesta 
                sqlCommand = @" SELECT ISNULL(SET_VALUE, '') FROM CONFIGURATION_SETTING WHERE SET_KEY = @key ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "key", DbType.String, p_key);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;
                while (reader.Read())
                {
                    returnValue = reader.GetSqlString(0).ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "ConfigurationSetting.getValue.");
                ex.Data.Add("SQL", ex.Message);

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
        /// Elenca tutti gli elementi ConfigurationSetting dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "CONFIGURATION_SETTING");
        }
		/// <summary>
		/// Elenca tutti gli elementi ConfigurationSetting dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"CONFIGURATION_SETTING");
		}
		/// <summary>
		/// Elenca tutti gli elementi ConfigurationSetting dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					CONFIGURATION_SETTING.set_id_configuration_setting, 
					CONFIGURATION_SETTING.set_id_utente, 
					CONFIGURATION_SETTING.set_key, 
					CONFIGURATION_SETTING.set_value 
				FROM CONFIGURATION_SETTING ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["CONFIGURATION_SETTING"].Columns["set_id_configuration_setting"];
				ds.Tables["CONFIGURATION_SETTING"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "ConfigurationSetting.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}
						
		#endregion

	}
}
