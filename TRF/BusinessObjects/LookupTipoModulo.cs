#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   LookupTipoModulo.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per LOOKUPTIPOMODULO
//
// Autore:      AR - SDG srl
// Data:        09/02/2010
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
	/// Tabella LOOKUP_TIPO_MODULO 
	/// </summary>
	public class LookupTipoModulo
	{
        #region Costanti

        /// <summary>
        /// enum per LookupTipoModulo
        /// Esempio di utilizzo:
        /// Id = LookupTipoModulo.eNomeSenzaLookup.NOME_COSTANTE.GetHashCode();
        /// Descrizione = LookupTipoModulo.eNomeSenzaLookup.NOME_COSTANTE.ToString();
        /// </summary>
        public enum eTipoModulo
        {
            RichiestaViaggio = 1,
            ModuloClaim = 11,
            ModuloHD = 12,
            NotaSpesa = 13
        }

        #endregion


        #region attributi e variabili

        private SqlInt32 ltm_id_tipo_modulo = SqlInt32.Null;
	    private SqlString ltm_descrizione_modulo = SqlString.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Ltm_id_tipo_modulo
		{
			get { return ltm_id_tipo_modulo; }	
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Ltm_descrizione_modulo
		{
			get { return ltm_descrizione_modulo; }	
			set { ltm_descrizione_modulo = value; }
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
		public LookupTipoModulo()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_ltm_id_tipo_modulo)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 LOOKUP_TIPO_MODULO.ltm_id_tipo_modulo, 
					 LOOKUP_TIPO_MODULO.ltm_descrizione_modulo	 
				 	 FROM LOOKUP_TIPO_MODULO WHERE 
					 (ltm_id_tipo_modulo = @ltm_id_tipo_modulo) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "ltm_id_tipo_modulo", DbType.Int32, p_ltm_id_tipo_modulo);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					ltm_id_tipo_modulo = reader.GetSqlInt32(0);
					ltm_descrizione_modulo = reader.GetSqlString(1);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupTipoModulo.Read.");
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
		public void Update(SqlInt32 p_ltm_id_tipo_modulo)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE LOOKUP_TIPO_MODULO SET
					 ltm_descrizione_modulo = @ltm_descrizione_modulo
					 WHERE   
				     (ltm_id_tipo_modulo = @ltm_id_tipo_modulo) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "ltm_descrizione_modulo", DbType.String, ltm_descrizione_modulo);
										
				db.AddInParameter(dbCommand, "ltm_id_tipo_modulo", DbType.Int32, p_ltm_id_tipo_modulo);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupTipoModulo.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete(SqlInt32 p_ltm_id_tipo_modulo)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM LOOKUP_TIPO_MODULO WHERE 
					(ltm_id_tipo_modulo = @ltm_id_tipo_modulo) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "ltm_id_tipo_modulo", DbType.Int32, p_ltm_id_tipo_modulo);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupTipoModulo.Delete.");
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
	
				sqlCommand = @" INSERT INTO LOOKUP_TIPO_MODULO (
						ltm_descrizione_modulo	 ) 
					VALUES ( 
						@ltm_descrizione_modulo	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "ltm_descrizione_modulo", DbType.String, ltm_descrizione_modulo);

 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					ltm_id_tipo_modulo = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "LookupTipoModulo.Create.");
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
        /// Elenca tutti gli elementi LookupTipoModulo dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "LOOKUP_TIPO_MODULO");
        }
		/// <summary>
		/// Elenca tutti gli elementi LookupTipoModulo dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"LOOKUP_TIPO_MODULO");
		}
		/// <summary>
		/// Elenca tutti gli elementi LookupTipoModulo dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					LOOKUP_TIPO_MODULO.ltm_id_tipo_modulo, 
					LOOKUP_TIPO_MODULO.ltm_descrizione_modulo 
				FROM LOOKUP_TIPO_MODULO ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["LOOKUP_TIPO_MODULO"].Columns["ltm_id_tipo_modulo"];
				ds.Tables["LOOKUP_TIPO_MODULO"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupTipoModulo.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

        /// <summary>
        /// Elenca tutti gli elementi LookupTipoModulo dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet ListABC()
        {
            return ListABC(string.Empty, "LOOKUP_TIPO_MODULO");
        }
        /// <summary>
        /// Elenca tutti gli elementi LookupTipoModulo dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet ListABC(string sqlWhereClause)
        {
            return ListABC(sqlWhereClause, "LOOKUP_TIPO_MODULO");
        }
        /// <summary>
        /// Elenca tutti gli elementi LookupTipoModulo dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListABC(string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					LOOKUP_TIPO_MODULO.ltm_id_tipo_modulo, 
					LOOKUP_TIPO_MODULO.ltm_descrizione_modulo 
				    FROM LOOKUP_TIPO_MODULO WHERE LTM_FLAG_ABC = 1 ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, tableName);

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["LOOKUP_TIPO_MODULO"].Columns["ltm_id_tipo_modulo"];
                ds.Tables["LOOKUP_TIPO_MODULO"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupTipoModulo.ListABC.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }
						
		#endregion

	}
}
