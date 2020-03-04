#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   LookupStatoServizio.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per LookupStatoServizio
//
// Autore:      SE - SDG srl
// Data:        08/12/2019
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
    /// Tabella LOOKUP_STATO_SERVIZIO 
    /// </summary>
    public class LookupStatoServizio
    {
        #region attributi e variabili

        private SqlInt32 lsv_id_stato_servizio = SqlInt32.Null;
        private SqlString lsv_descrizione = SqlString.Null;
        private SqlString lsv_codice_esadecimale = SqlString.Null;
        private SqlInt32 lss_flag_visibile = SqlInt32.Null;
        private SqlInt32 lsv_flag_eliminato = SqlInt32.Null;
        private SqlInt32 ute_creato_da = SqlInt32.Null;
        private SqlInt32 ute_aggiornato_da = SqlInt32.Null;
        private SqlDateTime lsv_data_creazione = SqlDateTime.Null;
        private SqlDateTime lss_data_aggiornamento = SqlDateTime.Null;

        private string sqlWhereClause = "";
        #endregion

        #region Proprieta

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsv_id_stato_servizio
        {
            get { return lsv_id_stato_servizio; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Lsv_descrizione
        {
            get { return lsv_descrizione; }
            set { lsv_descrizione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Lsv_codice_esadecimale
        {
            get { return lsv_codice_esadecimale; }
            set { lsv_codice_esadecimale = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsv_flag_eliminato
        {
            get { return lsv_flag_eliminato; }
            set { lsv_flag_eliminato = value; }
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
        public LookupStatoServizio()
        {

        }
        #endregion

        #region Metodi
        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void Read(SqlInt32 p_lsv_id_stato_servizio)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 LOOKUP_STATO_SERVIZIO.lsv_id_stato_servizio, 
					 LOOKUP_STATO_SERVIZIO.lsv_descrizione, 
					 LOOKUP_STATO_SERVIZIO.lsv_codice_esadecimale, 
					 LOOKUP_STATO_SERVIZIO.lsv_flag_eliminato, 
					 LOOKUP_STATO_SERVIZIO.ute_creato_da, 
					 LOOKUP_STATO_SERVIZIO.ute_aggiornato_da, 
					 LOOKUP_STATO_SERVIZIO.lsv_data_creazione	 
				 	 FROM LOOKUP_STATO_SERVIZIO WHERE 
					 lsv_id_stato_servizio = @lsv_id_stato_servizio ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lsv_id_stato_servizio", DbType.Int32, p_lsv_id_stato_servizio);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    lsv_id_stato_servizio = reader.GetSqlInt32(0);
                    lsv_descrizione = reader.GetSqlString(1);
                    lsv_codice_esadecimale = reader.GetSqlString(2);
                    lss_flag_visibile = reader.GetSqlInt32(3);
                    lsv_flag_eliminato = reader.GetSqlInt32(4);
                    ute_creato_da = reader.GetSqlInt32(5);
                    ute_aggiornato_da = reader.GetSqlInt32(6);
                    lsv_data_creazione = reader.GetSqlDateTime(7);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupStatoServizio.Read.");
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
        public void Update(SqlInt32 p_lsv_id_stato_servizio)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE LOOKUP_STATO_SERVIZIO SET
					 lsv_descrizione = @lsv_descrizione, 
					 lsv_codice_esadecimale = @lsv_codice_esadecimale, 
					 lsv_flag_eliminato = @lsv_flag_eliminato, 
					 ute_aggiornato_da = @ute_aggiornato_da, 
					 lss_data_aggiornamento = getdate()
					 WHERE   
				     (lsv_id_stato_servizio = @lsv_id_stato_servizio) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lsv_descrizione", DbType.String, lsv_descrizione);
                db.AddInParameter(dbCommand, "lsv_codice_esadecimale", DbType.String, lsv_codice_esadecimale);
                db.AddInParameter(dbCommand, "lsv_flag_eliminato", DbType.Int32, lsv_flag_eliminato);
                db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);

                db.AddInParameter(dbCommand, "lsv_id_stato_servizio", DbType.Int32, p_lsv_id_stato_servizio);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupStatoServizio.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public static void Delete(SqlInt32 p_lsv_id_stato_servizio)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM LOOKUP_STATO_SERVIZIO WHERE 
					(lsv_id_stato_servizio = @lsv_id_stato_servizio) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lsv_id_stato_servizio", DbType.Int32, p_lsv_id_stato_servizio);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupStatoServizio.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void Create(SqlInt32 p_lsv_id_stato_servizio)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO LOOKUP_STATO_SERVIZIO (
						lsv_descrizione, 
						lsv_codice_esadecimale, 
						lsv_flag_eliminato, 
						ute_creato_da, 
						lsv_data_creazione	) 
					VALUES ( 
						@lsv_descrizione, 
						@lsv_codice_esadecimale, 
						@lsv_flag_eliminato, 
						@ute_creato_da, 
						getdate()	 ) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lsv_descrizione", DbType.String, lsv_descrizione);
                db.AddInParameter(dbCommand, "lsv_codice_esadecimale", DbType.String, lsv_codice_esadecimale);
                db.AddInParameter(dbCommand, "lsv_flag_eliminato", DbType.Int32, lsv_flag_eliminato);
                db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);

                db.AddInParameter(dbCommand, "lsv_id_stato_servizio", DbType.Int32, p_lsv_id_stato_servizio);
                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    lsv_id_stato_servizio = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupStatoServizio.Create.");
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
        /// Elenca tutti gli elementi LookupStatoServizio dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public DataSet List()
        {
            return List(string.Empty, "LOOKUP_STATO_SERVIZIO");
        }
        /// <summary>
        /// Elenca tutti gli elementi LookupStatoServizio dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public DataSet List(string sqlWhereClause)
        {
            return List(sqlWhereClause, "LOOKUP_STATO_SERVIZIO");
        }
        /// <summary>
        /// Elenca tutti gli elementi LookupStatoServizio dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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

                sb.Append(@" SELECT 
					LOOKUP_STATO_SERVIZIO.lsv_id_stato_servizio, 
					LOOKUP_STATO_SERVIZIO.lsv_descrizione
				    FROM LOOKUP_STATO_SERVIZIO ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sb.Append(" ORDER BY lsv_descrizione ");

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, tableName);

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["LOOKUP_STATO_SERVIZIO"].Columns["lsv_id_stato_servizio"];
                ds.Tables["LOOKUP_STATO_SERVIZIO"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupStatoServizio.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// getDsLookupStatoServizio
        /// </summary>        
        /// <returns></returns>
        public DataSet getDsLookupStatoServizio()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" SELECT ");
                sb.Append("LOOKUP_STATO_SERVIZIO.lsv_id_stato_servizio as [key], ");
                sb.Append("LOOKUP_STATO_SERVIZIO.lsv_descrizione AS value ");
                sb.Append("FROM LOOKUP_STATO_SERVIZIO WITH (NOLOCK) ");
                sb.Append(@sqlWhereClause);

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "LOOKUP_STATO_SERVIZIO");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupStatoServizio.getDsLookupStatoServizio.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        #endregion

    }
}
