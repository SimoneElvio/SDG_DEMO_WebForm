#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   CrossUtenteNotifica.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per CROSSUTENTENOTIFICA
//
// Autore:      AR - SDG srl
// Data:        2010/02/24
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
    /// Tabella CROSS_UTENTE_NOTIFICA 
    /// </summary>
    public class CrossUtenteNotifica 
    {
        #region attributi e variabili

        private SqlInt32 cun_id_cross_utente_notifica = SqlInt32.Null;
        private SqlInt32 ute_id_utente = SqlInt32.Null;
        private SqlInt32 riv_id_richiesta = SqlInt32.Null;

        private string sqlWhereClause = "";
        #endregion

        #region Proprieta

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cun_id_cross_utente_notifica
        {
            get { return cun_id_cross_utente_notifica; }
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
        public CrossUtenteNotifica()
        {

        }
        #endregion

        #region Metodi
        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void Read(SqlInt32 p_cun_id_cross_utente_notifica)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 CROSS_UTENTE_NOTIFICA.cun_id_cross_utente_notifica, 
					 CROSS_UTENTE_NOTIFICA.ute_id_utente, 
					 CROSS_UTENTE_NOTIFICA.riv_id_richiesta	 
				 	 FROM CROSS_UTENTE_NOTIFICA WHERE 
					 (cun_id_cross_utente_notifica = @cun_id_cross_utente_notifica) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cun_id_cross_utente_notifica", DbType.Int32, p_cun_id_cross_utente_notifica);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    cun_id_cross_utente_notifica = reader.GetSqlInt32(0);
                    ute_id_utente = reader.GetSqlInt32(1);
                    riv_id_richiesta = reader.GetSqlInt32(2);

                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CrossUtenteNotifica.Read.");
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
        /// Aggiorna l'oggetto nella base dati
        /// </summary>	
        public void Update(SqlInt32 p_cun_id_cross_utente_notifica)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE CROSS_UTENTE_NOTIFICA SET
					 ute_id_utente = @ute_id_utente, 
					 riv_id_richiesta = @riv_id_richiesta
					 WHERE   
				     (cun_id_cross_utente_notifica = @cun_id_cross_utente_notifica) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);

                db.AddInParameter(dbCommand, "cun_id_cross_utente_notifica", DbType.Int32, p_cun_id_cross_utente_notifica);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CrossUtenteNotifica.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public static void Delete(SqlInt32 p_cun_id_cross_utente_notifica)
        {
            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            DbConnection c = db.CreateConnection();
            DbTransaction t = null;

            try
            {
                c.Open();
                t = c.BeginTransaction();

                Delete(p_cun_id_cross_utente_notifica, t);

                t.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    t.Rollback();
                }
                catch (Exception ex2)
                {
                    ex2.Data.Add("Class.Method", "CrossUtenteNotifica.Delete.Rollback");
                    ex2.Data.Add("SQL", "Rollback error");
                }
                ex.Data.Add("Class.Method", "CrossUtenteNotifica.Delete.");
                ex.Data.Add("SQL", ex.Message);

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            finally
            {
                c.Close();
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public static void Delete(SqlInt32 p_cun_id_cross_utente_notifica, DbTransaction transaction)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM CROSS_UTENTE_NOTIFICA WHERE 
					(cun_id_cross_utente_notifica = @cun_id_cross_utente_notifica) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cun_id_cross_utente_notifica", DbType.Int32, p_cun_id_cross_utente_notifica);

                db.ExecuteNonQuery(dbCommand, transaction);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CrossUtenteNotifica.Delete.");
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

                sqlCommand = @" INSERT INTO CROSS_UTENTE_NOTIFICA (
						ute_id_utente, 
						riv_id_richiesta	 ) 
					VALUES ( 
						@ute_id_utente, 
						@riv_id_richiesta	 ) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    cun_id_cross_utente_notifica = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CrossUtenteNotifica.Create.");
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
        /// Elenca tutti gli elementi CrossUtenteNotifica dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "CROSS_UTENTE_NOTIFICA");
        }
        /// <summary>
        /// Elenca tutti gli elementi CrossUtenteNotifica dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet List(string sqlWhereClause)
        {
            return List(sqlWhereClause, "CROSS_UTENTE_NOTIFICA");
        }
        /// <summary>
        /// Elenca tutti gli elementi CrossUtenteNotifica dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					CROSS_UTENTE_NOTIFICA.cun_id_cross_utente_notifica, 
					CROSS_UTENTE_NOTIFICA.ute_id_utente, 
					CROSS_UTENTE_NOTIFICA.riv_id_richiesta 
				FROM CROSS_UTENTE_NOTIFICA ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, tableName);

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables[tableName].Columns["cun_id_cross_utente_notifica"];
                ds.Tables[tableName].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CrossUtenteNotifica.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Elenca tutti gli elementi CrossUtenteNotifica dell'analisi con tutte le tabelle collegate. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet ListForExport()
        {
            return List(string.Empty, "CROSS_UTENTE_NOTIFICA");
        }
        /// <summary>
        /// Elenca tutti gli elementi CrossUtenteNotifica dell'analisi con tutte le tabelle collegate. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet ListForExport(string sqlWhereClause)
        {
            return List(sqlWhereClause, "CROSS_UTENTE_NOTIFICA");
        }
        /// <summary>
        /// Elenca tutti gli elementi CrossUtenteNotifica dell'analisi con tutte le tabelle collegate. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListForExport(string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					CROSS_UTENTE_NOTIFICA.cun_id_cross_utente_notifica AS [id_cross_utente_notifica], 
					CROSS_UTENTE_NOTIFICA.ute_id_utente AS [id_utente], 
					CROSS_UTENTE_NOTIFICA.riv_id_richiesta AS [id_richiesta] 
				FROM CROSS_UTENTE_NOTIFICA
				LEFT JOIN RICHIESTA_VIAGGIO ON CROSS_UTENTE_NOTIFICA.riv_id_richiesta = RICHIESTA_VIAGGIO.riv_id_richiesta
				LEFT JOIN UTENTE ON CROSS_UTENTE_NOTIFICA.ute_id_utente = UTENTE.ute_id_utente ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, tableName);

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables[tableName].Columns["cun_id_cross_utente_notifica"];
                ds.Tables[tableName].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CrossUtenteNotifica.ListForExport.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public void Create(string userName, string domainName, int idRichiesta)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO CROSS_UTENTE_NOTIFICA( ute_id_utente, riv_id_richiesta ) 
					            SELECT ute_id_utente, @riv_id_richiesta 
                                FROM UTENTE
                                WHERE UTENTE.ute_user_id_win = @userName
                                  AND UTENTE.ute_dominio_win = @domainName ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "userName", DbType.String, userName);
                db.AddInParameter(dbCommand, "domainName", DbType.String, domainName);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, idRichiesta);

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    cun_id_cross_utente_notifica = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "CrossUtenteNotifica.Create.");
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
