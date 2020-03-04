#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   Allegati.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per ALLEGATI
//
// Autore:      AR - SDG srl
// Data:        26/03/2010
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
using SDG.GestioneUtenti.Web;

namespace BusinessObjects
{
	/// <summary>
	/// Tabella ALLEGATI 
	/// </summary>
	public class Allegati
	{
		#region attributi e variabili

	    private SqlInt32 att_id_allegato = SqlInt32.Null;
	    private SqlInt32 riv_id_richiesta = SqlInt32.Null;
	    private SqlString att_nome_file = SqlString.Null;
	    private SqlString att_descrizione = SqlString.Null;
	    private SqlInt32 att_dimensione = SqlInt32.Null;
	    private SqlInt32 ute_creato_da = SqlInt32.Null;
        private SqlInt32 att_tipo = SqlInt32.Null;
        private SqlInt32 att_id_record = SqlInt32.Null;
        private SqlString att_nome_tabella = SqlString.Null;
        private SqlString att_nome_file_tmp = SqlString.Null;
        private SqlInt32 att_dimensione_tmp = SqlInt32.Null;

        private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Att_id_allegato
		{
			get { return att_id_allegato; }	
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
		public SqlString Att_nome_file
		{
			get { return att_nome_file; }	
			set { att_nome_file = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Att_descrizione
		{
			get { return att_descrizione; }	
			set { att_descrizione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Att_dimensione
		{
			get { return att_dimensione; }	
			set { att_dimensione = value; }
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
        public SqlInt32 Att_tipo
        {
            get { return att_tipo; }
            set { att_tipo = value; }
        }        

        /// <value>
        /// Where Clause condition
        /// </value>
        public string SqlWhereClause
		{
			get { return  sqlWhereClause; }
			set { sqlWhereClause = value; }
		}

        /// <summary>
        /// 
        /// </summary>
        public SqlInt32 Att_id_record
        {
            get { return att_id_record; }
            set { att_id_record = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlString Att_nome_tabella
        {
            get { return att_nome_tabella; }
            set { att_nome_tabella = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlString Att_nome_file_tmp
        {
            get { return att_nome_file_tmp; }
            set { att_nome_file_tmp = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlInt32 Att_dimensione_tmp
        {
            get { return att_dimensione_tmp; }
            set { att_dimensione_tmp = value; }
        }

        #endregion

        #region Costruttori

        /// <summary>
        /// Costruttore standard
        /// </summary>
        public Allegati()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_att_id_allegato)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 ALLEGATI.att_id_allegato, 
					 ALLEGATI.riv_id_richiesta, 
					 ALLEGATI.att_nome_file, 
					 ALLEGATI.att_descrizione, 
					 ALLEGATI.att_dimensione, 
					 ALLEGATI.ute_creato_da,
                     ALLEGATI.att_tipo
				 	 FROM ALLEGATI WHERE 
					 att_id_allegato = @att_id_allegato ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "att_id_allegato", DbType.Int32, p_att_id_allegato);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					att_id_allegato = reader.GetSqlInt32(0);
					riv_id_richiesta = reader.GetSqlInt32(1);
					att_nome_file = reader.GetSqlString(2);
					att_descrizione = reader.GetSqlString(3);
					att_dimensione = reader.GetSqlInt32(4);
					ute_creato_da = reader.GetSqlInt32(5);
                    att_tipo = reader.GetSqlInt32(6);
                }	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "Allegati.Read.");
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
        /// 
        /// </summary>
        public void ReadByIdRecord()
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 ALLEGATI.att_id_allegato, 
					 ALLEGATI.riv_id_richiesta, 
					 ALLEGATI.att_nome_file, 
					 ALLEGATI.att_descrizione, 
					 ALLEGATI.att_dimensione, 
					 ALLEGATI.ute_creato_da,
                     ALLEGATI.att_tipo
				 	 FROM ALLEGATI 
                     WHERE 
					 att_id_record = @att_id_record 
                     AND att_nome_tabella = @att_nome_tabella  ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "att_id_record", DbType.Int32, att_id_record);
                db.AddInParameter(dbCommand, "att_nome_tabella", DbType.String, att_nome_tabella);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    att_id_allegato = reader.GetSqlInt32(0);
                    riv_id_richiesta = reader.GetSqlInt32(1);
                    att_nome_file = reader.GetSqlString(2);
                    att_descrizione = reader.GetSqlString(3);
                    att_dimensione = reader.GetSqlInt32(4);
                    ute_creato_da = reader.GetSqlInt32(5);
                    att_tipo = reader.GetSqlInt32(6);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Allegati.ReadByIDRecord.");
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
        /// Aggiornamento temporaneo.
        /// </summary>
        /// <param name="p_att_nome_file"></param>
        /// <param name="transaction"></param>
        /// <param name="db"></param>
        public void UpdateTemporaneo(DbTransaction transaction, Database db)
		{
            StringBuilder sb = new StringBuilder();
			DbCommand dbCommand = null;
			
			try
			{
                sb.Append(@" UPDATE ALLEGATI SET				 
					                att_descrizione = @att_descrizione, 
                                    att_nome_tabella = @att_nome_tabella, ");
                if (att_tipo == BasePage.C_TIPO_ALLEGATO_PRENOTAZIONE_VIAGGIO)
                {
                    sb.Append("     att_nome_file = @att_nome_file, ");
                    sb.Append("     att_dimensione = @att_dimensione ");
                }
                else
                {
                    sb.Append("     att_nome_file_tmp = @att_nome_file_tmp, ");
                    sb.Append("     att_dimensione_tmp = @att_dimensione_tmp ");
                }
                sb.Append(@" WHERE att_id_record = @att_id_record
                            AND att_nome_tabella = @att_nome_tabella ");

                sb.Append(SqlWhereClause);
                
                dbCommand = db.GetSqlStringCommand(sb.ToString());

				db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);				
				db.AddInParameter(dbCommand, "att_descrizione", DbType.String, att_descrizione);
				db.AddInParameter(dbCommand, "att_dimensione", DbType.Int32, att_dimensione);
                db.AddInParameter(dbCommand, "att_nome_file", DbType.String, att_nome_file);
                db.AddInParameter(dbCommand, "att_id_record", DbType.Int32, att_id_record);
                db.AddInParameter(dbCommand, "att_nome_tabella", DbType.String, att_nome_tabella);
                db.AddInParameter(dbCommand, "att_nome_file_tmp", DbType.String, att_nome_file_tmp);
                db.AddInParameter(dbCommand, "att_dimensione_tmp", DbType.Int32, att_dimensione_tmp);

                db.ExecuteNonQuery(dbCommand, transaction);            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Allegati.UpdateTemporaneo.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

      /// <summary>
      /// Aggiorna le colonne att_nome_file, att_dimensione. Valorizzo a NULL
      /// att_nome_file_tmp, att_dimensione_tmp al salvataggio della nota spesa
      /// </summary>
      /// <param name="p_att_id_record">Id record</param>
      /// <param name="transaction"></param>
      /// <param name="db"></param>
        public void UpdateFinale(SqlInt32 p_att_id_record, DbTransaction transaction, Database db)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                sqlCommand = @" UPDATE ALLEGATI SET				 
					                att_nome_file = att_nome_file_tmp,
                                    att_dimensione = att_dimensione_tmp
					                WHERE att_id_record = @att_id_record
                                    AND att_nome_file_tmp IS NOT NULL;

                                UPDATE ALLEGATI 
                                    SET att_nome_file_tmp = null,
                                    att_dimensione_tmp = null
                                    WHERE att_id_record = @att_id_record
					            ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "att_id_record", DbType.Int32, p_att_id_record);

                db.ExecuteNonQuery(dbCommand, transaction);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Allegati.UpdateFinale.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public static void Delete(SqlInt32 p_att_id_allegato)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM ALLEGATI WHERE 
					(att_id_allegato = @att_id_allegato) ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "att_id_allegato", DbType.Int32, p_att_id_allegato);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Allegati.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void Create(DbTransaction transaction, Database db) 
		{
            StringBuilder sb = new StringBuilder();
			DbCommand dbCommand = null;
			IDataReader dataReader = null;
			
			try
			{	
				sb.Append(@" INSERT INTO ALLEGATI (
						    riv_id_richiesta, 
						    att_descrizione, 
						    ute_creato_da,
                            att_tipo,
                            att_id_record,
                            att_nome_tabella,");
                if (att_tipo == BasePage.C_TIPO_ALLEGATO_PRENOTAZIONE_VIAGGIO)
                {
                    sb.Append(@"att_nome_file,
                                att_dimensione) ");
                }
                else
                {
                    sb.Append(@"att_nome_file_tmp,");
                    sb.Append(@"att_dimensione_tmp) ");
                }
            sb.Append(@" VALUES(
                            @riv_id_richiesta,  
						    @att_descrizione,
						    @ute_creato_da,
                            @att_tipo,
                            @att_id_record,
                            @att_nome_tabella,");
                if (att_tipo == BasePage.C_TIPO_ALLEGATO_PRENOTAZIONE_VIAGGIO)
                {
                    sb.Append(@"@att_nome_file,
                                @att_dimensione) ");
                }
                else
                {
                    sb.Append(@"@att_nome_file_tmp,
                                @att_dimensione_tmp) ");
                }

                sb.Append(@"SELECT SCOPE_IDENTITY()");
										
				dbCommand = db.GetSqlStringCommand(sb.ToString());
            
				db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);
				db.AddInParameter(dbCommand, "att_nome_file", DbType.String, att_nome_file);
				db.AddInParameter(dbCommand, "att_descrizione", DbType.String, att_descrizione);
				db.AddInParameter(dbCommand, "att_dimensione", DbType.Int32, att_dimensione);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);
                db.AddInParameter(dbCommand, "att_tipo", DbType.Int32, att_tipo);
                db.AddInParameter(dbCommand, "att_id_record", DbType.Int32, att_id_record);
                db.AddInParameter(dbCommand, "att_nome_tabella", DbType.String, att_nome_tabella);
                db.AddInParameter(dbCommand, "att_dimensione_tmp", DbType.Int32, att_dimensione_tmp);
                db.AddInParameter(dbCommand, "att_nome_file_tmp", DbType.String, att_nome_file_tmp);

                dataReader = db.ExecuteReader(dbCommand, transaction);
 				if (dataReader.Read())
 				{
 					att_id_allegato = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "Allegati.Create.");
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
        /// Elenca tutti gli elementi Allegati dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "ALLEGATI");
        }
		/// <summary>
		/// Elenca tutti gli elementi Allegati dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"ALLEGATI");
		}
		/// <summary>
		/// Elenca tutti gli elementi Allegati dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					ALLEGATI.att_id_allegato, 
					ALLEGATI.riv_id_richiesta, 
					ALLEGATI.att_nome_file, 
					ALLEGATI.att_descrizione, 
					ALLEGATI.att_dimensione, 
					ALLEGATI.ute_creato_da,
                    ALLEGATI.att_id_record,
                    ALLEGATI.att_nome_tabella
    				FROM ALLEGATI ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["ALLEGATI"].Columns["att_id_allegato"];
				ds.Tables["ALLEGATI"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Allegati.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

        /// <summary>
        /// Renderizza l'elenco degli allegati presenti nella richiesta.
        /// </summary>
        /// <param name="p_att_id_record"></param>
        /// <param name="p_att_tipo">1- file prenotazione; 2- fine nota spese</param>
        /// <returns></returns>
        public static DataSet GetAllegati(SqlInt32 p_att_id_record, SqlInt32 p_att_tipo)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");                
                sb.Append(@"SELECT ATT_ID_ALLEGATO, 
                            ISNULL(ATT_NOME_FILE_TMP, ATT_NOME_FILE) AS ATT_NOME_FILE                            
                            FROM ALLEGATI 
                            WHERE ATT_TIPO = @att_tipo ");

                if (p_att_tipo == BasePage.C_TIPO_ALLEGATO_PRENOTAZIONE_VIAGGIO)
                {
                    sb.Append(" AND RIV_ID_RICHIESTA = @ATT_ID_RECORD ");
                }
                else
                {
                    sb.Append(" AND ATT_ID_RECORD = @ATT_ID_RECORD ");
                }

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "att_id_record", DbType.Int32, p_att_id_record);
                db.AddInParameter(dbCommand, "att_tipo", DbType.Int32, p_att_tipo);
                db.LoadDataSet(dbCommand, ds, "ALLEGATI");
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Allegati.GetAllegati");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

		#endregion

	}
}
