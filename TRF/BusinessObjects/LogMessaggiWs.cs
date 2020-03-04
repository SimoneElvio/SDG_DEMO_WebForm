#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   LogMessaggiWs.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per LOGMESSAGGIWS
//
// Autore:      AR - SDG srl
// Data:        11/09/2009
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
    /// Tabella LOG_MESSAGGI_WS 
    /// </summary>
    public class LogMessaggiWs
    {
        #region attributi e variabili

        private SqlInt32 lmw_id = SqlInt32.Null;
        private SqlInt32 riv_id_richiesta = SqlInt32.Null;
        private SqlInt32 cla_lmw_id = SqlInt32.Null;
        private SqlString lmw_xml_schema = SqlString.Null;
        private SqlString lmw_id_missione = SqlString.Null;
        private SqlString lmw_xml_dati = SqlString.Null;
        private SqlString lmw_messaggio = SqlString.Null;

        private string sqlWhereClause = "";
        #endregion

        #region Proprieta

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lmw_id
        {
            get { return lmw_id; }
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
        public SqlInt32 Cla_lmw_id
        {
            get { return cla_lmw_id; }
            set { cla_lmw_id = value; }
        }

        /// <value>
        /// Contiene lo schema XML del dataset in input al WebServices.
        /// </value>
        public SqlString Lmw_xml_schema
        {
            get { return lmw_xml_schema; }
            set { lmw_xml_schema = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Lmw_id_missione
        {
            get { return lmw_id_missione; }
            set { lmw_id_missione = value; }
        }

        /// <value>
        /// Contiene i dati in formato XML del dataset in input al WebServices.
        /// </value>
        public SqlString Lmw_xml_dati
        {
            get { return lmw_xml_dati; }
            set { lmw_xml_dati = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Lmw_messaggio
        {
            get { return lmw_messaggio; }
            set { lmw_messaggio = value; }
        }


        /// <value>
        /// Where Clause condition
        /// </value>
        public string SqlWhereClause
        {
            get { return sqlWhereClause; }
            set { sqlWhereClause = value; }
        }
        #endregion

        #region Costruttori

        /// <summary>
        /// Costruttore standard
        /// </summary>
        public LogMessaggiWs()
        {

        }
        #endregion

        #region Metodi
        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void Read(SqlInt32 p_lmw_id)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 LOG_MESSAGGI_WS.lmw_id, 
					 LOG_MESSAGGI_WS.riv_id_richiesta, 
					 LOG_MESSAGGI_WS.cla_lmw_id, 
					 LOG_MESSAGGI_WS.lmw_xml_schema, 
					 LOG_MESSAGGI_WS.lmw_id_missione, 
					 LOG_MESSAGGI_WS.lmw_xml_dati, 
					 LOG_MESSAGGI_WS.lmw_messaggio	 
				 	 FROM LOG_MESSAGGI_WS WHERE 
					 (lmw_id = @lmw_id) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lmw_id", DbType.Int32, p_lmw_id);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    lmw_id = reader.GetSqlInt32(0);
                    riv_id_richiesta = reader.GetSqlInt32(1);
                    cla_lmw_id = reader.GetSqlInt32(2);
                    lmw_xml_schema = reader.GetSqlString(3);
                    lmw_id_missione = reader.GetSqlString(4);
                    lmw_xml_dati = reader.GetSqlString(5);
                    lmw_messaggio = reader.GetSqlString(6);

                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LogMessaggiWs.Read.");
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
        public void Update(SqlInt32 p_lmw_id)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
                        
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE LOG_MESSAGGI_WS SET
					 riv_id_richiesta = @riv_id_richiesta, 
					 cla_lmw_id = @cla_lmw_id, 
					 lmw_xml_schema = @lmw_xml_schema, 
					 lmw_id_missione = @lmw_id_missione, 
					 lmw_xml_dati = @lmw_xml_dati, 
					 lmw_messaggio = @lmw_messaggio
					 WHERE   
				     (lmw_id = @lmw_id) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);
                db.AddInParameter(dbCommand, "cla_lmw_id", DbType.Int32, cla_lmw_id);
                db.AddInParameter(dbCommand, "lmw_xml_schema", DbType.String, lmw_xml_schema);
                db.AddInParameter(dbCommand, "lmw_id_missione", DbType.String, lmw_id_missione);
                db.AddInParameter(dbCommand, "lmw_xml_dati", DbType.String, lmw_xml_dati);
                db.AddInParameter(dbCommand, "lmw_messaggio", DbType.String, lmw_messaggio);

                db.AddInParameter(dbCommand, "lmw_id", DbType.Int32, p_lmw_id);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LogMessaggiWs.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public static void Delete(SqlInt32 p_lmw_id)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM LOG_MESSAGGI_WS WHERE 
					(lmw_id = @lmw_id) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lmw_id", DbType.Int32, p_lmw_id);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LogMessaggiWs.Delete.");
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
            //IDataReader Ireader = null;
            //SqlDataReader reader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO LOG_MESSAGGI_WS (
						riv_id_richiesta, 
						cla_lmw_id, 
						lmw_xml_schema, 
						lmw_id_missione, 
						lmw_xml_dati, 
						lmw_messaggio,
                        lmw_data_creazione ) 
					VALUES ( 
						@riv_id_richiesta, 
						@cla_lmw_id, 
						@lmw_xml_schema, 
						@lmw_id_missione, 
						@lmw_xml_dati, 
						@lmw_messaggio,
                        GETDATE()) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);
                db.AddInParameter(dbCommand, "cla_lmw_id", DbType.Int32, cla_lmw_id);
                db.AddInParameter(dbCommand, "lmw_xml_schema", DbType.String, lmw_xml_schema);
                db.AddInParameter(dbCommand, "lmw_id_missione", DbType.String, lmw_id_missione);
                db.AddInParameter(dbCommand, "lmw_xml_dati", DbType.String, lmw_xml_dati);
                db.AddInParameter(dbCommand, "lmw_messaggio", DbType.String, lmw_messaggio);
                
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        lmw_id = Convert.ToInt32(reader[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LogMessaggiWs.Create.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            finally
            {
                if (dbCommand.Connection.State.ToString().Contains("open"))
                    dbCommand.Connection.Close();
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi LogMessaggiWs dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "LOG_MESSAGGI_WS");
        }
        /// <summary>
        /// Elenca tutti gli elementi LogMessaggiWs dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet List(string sqlWhereClause)
        {
            return List(sqlWhereClause, "LOG_MESSAGGI_WS");
        }
        /// <summary>
        /// Elenca tutti gli elementi LogMessaggiWs dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					LOG_MESSAGGI_WS.lmw_id, 
					LOG_MESSAGGI_WS.riv_id_richiesta, 
					LOG_MESSAGGI_WS.cla_lmw_id, 
					LOG_MESSAGGI_WS.lmw_xml_schema, 
					LOG_MESSAGGI_WS.lmw_id_missione, 
					LOG_MESSAGGI_WS.lmw_xml_dati, 
					LOG_MESSAGGI_WS.lmw_messaggio 
				FROM LOG_MESSAGGI_WS ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, tableName);

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["LOG_MESSAGGI_WS"].Columns["lmw_id"];
                ds.Tables["LOG_MESSAGGI_WS"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LogMessaggiWs.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }


        

        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati partendo da una riga della stessa tabella 
        /// </summary>
        public void CreateTo(SqlInt32 p_lmw_id)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO LOG_MESSAGGI_WS (
						            riv_id_richiesta, 
						            cla_lmw_id, 
						            lmw_xml_schema, 
						            lmw_id_missione, 
						            lmw_xml_dati, 
						            lmw_messaggio,
                                    lmw_data_creazione ) 
                            SELECT 
                                CASE WHEN @riv_id_richiesta IS NULL THEN riv_id_richiesta ELSE @riv_id_richiesta  END,
                                CASE WHEN @cla_lmw_id IS NULL THEN cla_lmw_id ELSE @cla_lmw_id  END,
                                CASE WHEN @lmw_xml_schema IS NULL THEN lmw_xml_schema ELSE @lmw_xml_schema  END,
                                CASE WHEN @lmw_id_missione IS NULL THEN lmw_id_missione ELSE @lmw_id_missione  END,
                                CASE WHEN @lmw_xml_dati IS NULL THEN lmw_xml_dati ELSE @lmw_xml_dati  END,
                                CASE WHEN @lmw_messaggio IS NULL THEN lmw_messaggio ELSE @lmw_messaggio  END,
                                GETDATE()
                            FROM LOG_MESSAGGI_WS
                            WHERE lmw_id = @p_lmw_id				

						; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                
                db.AddInParameter(dbCommand, "p_lmw_id", DbType.Int32, p_lmw_id);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);
                db.AddInParameter(dbCommand, "cla_lmw_id", DbType.Int32, cla_lmw_id);
                db.AddInParameter(dbCommand, "lmw_xml_schema", DbType.String, lmw_xml_schema);
                db.AddInParameter(dbCommand, "lmw_id_missione", DbType.String, lmw_id_missione);
                db.AddInParameter(dbCommand, "lmw_xml_dati", DbType.String, lmw_xml_dati);
                db.AddInParameter(dbCommand, "lmw_messaggio", DbType.String, lmw_messaggio);

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    lmw_id = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LogMessaggiWs.CreateTo.");
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


