#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Lookup_societa_cliente.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per LOOKUP_SOCIETA_CLIENTE
//
// Autore:      SE - SDG srl
// Data:        22/11/2017
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
//using BusinessObjects.Utility;
using SDG.ExceptionHandling;
using System.Collections.Generic;

namespace SDG.GestioneUtenti
{
    ///<summary>
    ///summary description for LOOKUP CLASS
    ///</summary>
    ///<remarks>
    ///comment here.
    ///</remarks>

    public class LookupSocietaCliente
    {

        #region Attributi e Variabili
        private string sqlWhereClause = "";

        private SqlInt32 lsl_id_societa_cliente = SqlInt32.Null;
        private SqlInt32 cli_id_cliente = SqlInt32.Null;
        private SqlString lsl_descrizione = SqlString.Null;
        private SqlString lsl_sigla = SqlString.Null;
        private SqlInt32 lsl_id_autorizzatore = SqlInt32.Null;
        private SqlInt32 lsl_id_creato_da = SqlInt32.Null;
        private SqlInt32 lsl_id_aggiornato_da = SqlInt32.Null;
        private SqlInt32 lsl_id_eliminato_da = SqlInt32.Null;
        private SqlDateTime lsl_data_creazione = SqlDateTime.Null;
        private SqlDateTime lsl_data_aggiornamento = SqlDateTime.Null;
        private SqlInt32 lsl_flag_eliminato = SqlInt32.Null;

        #endregion

        #region Proprieta

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsl_id_societa_cliente
        {
            get { return lsl_id_societa_cliente; }
            set { lsl_id_societa_cliente = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cli_id_cliente
        {
            get { return cli_id_cliente; }
            set { cli_id_cliente = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Lsl_descrizione
        {
            get { return lsl_descrizione; }
            set { lsl_descrizione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Lsl_sigla
        {
            get { return lsl_sigla; }
            set { lsl_sigla = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsl_id_autorizzatore
        {
            get { return lsl_id_autorizzatore; }
            set { lsl_id_autorizzatore = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsl_id_creato_da
        {
            get { return lsl_id_creato_da; }
            set { lsl_id_creato_da = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsl_id_aggiornato_da
        {
            get { return lsl_id_aggiornato_da; }
            set { lsl_id_aggiornato_da = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsl_id_eliminato_da
        {
            get { return lsl_id_eliminato_da; }
            set { lsl_id_eliminato_da = value; }
        }


        /// <value>
        /// 
        /// </value>
        public SqlDateTime Ssl_data_creazione
        {
            get { return lsl_data_creazione; }
            set { lsl_data_creazione = value; }
        }


        /// <value>
        /// 
        /// </value>
        public SqlDateTime Lsl_data_aggiornamento
        {
            get { return lsl_data_aggiornamento; }
            set { lsl_data_aggiornamento = value; }
        }


        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lsl_flag_eliminato
        {
            get { return lsl_flag_eliminato; }
            set { lsl_flag_eliminato = value; }
        }

        /// <value>
        /// Where Clause condition
        /// </value>
        public string SqlWhereClause
        {
            get { return sqlWhereClause; }
            set { sqlWhereClause = value; }
        }

        //protected Utilita objUtilita;
        #endregion

        #region  Costruttori
        public LookupSocietaCliente()
        {
            //objUtilita = new Utilita();
        }
        #endregion

        #region METODI

        /// <summary>
        /// getLookupSocietaCliente
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> getLookupSocietaCliente()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            Dictionary<int, string> list = new Dictionary<int, string>();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append("SELECT ");
                sb.Append("LOOKUP_SOCIETA_CLIENTE.LSL_ID_SOCIETA_CLIENTE AS [key], ");
                sb.Append("LOOKUP_SOCIETA_CLIENTE.LSL_DESCRIZIONE AS value ");
                sb.Append("FROM LOOKUP_SOCIETA_CLIENTE WITH (NOLOCK) ");
                sb.Append(@sqlWhereClause);

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);

                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetInt32(0), reader.GetString(1));
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupSocietaCliente.getLookupSocietaCliente.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                throw ex;
            }
        }


        /// <summary>
        /// getDsLookupSocietaCliente
        /// </summary>        
        /// <returns></returns>
        public DataSet getDsLookupSocietaCliente()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append("SELECT ");
                sb.Append("LOOKUP_SOCIETA_CLIENTE.LSL_ID_SOCIETA_CLIENTE AS [key], ");
                sb.Append("LOOKUP_SOCIETA_CLIENTE.LSL_DESCRIZIONE AS value, ");
                sb.Append("LOOKUP_SOCIETA_CLIENTE.LSL_FLAG_ELIMINATO AS eliminato ");
                sb.Append("FROM LOOKUP_SOCIETA_CLIENTE WITH (NOLOCK) ");
                sb.Append(@sqlWhereClause);
                
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);                
                db.LoadDataSet(dbCommand, ds, "LOOKUP_SOCIETA_CLIENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "lookup_societa_cliente.getDsLookupSocietaCliente.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// getAutorizzatoreSocieta
        /// </summary>
        /// <param name="idSocieta"></param>
        /// <returns></returns>
        public DataSet getAutorizzatoreSocieta(Int32 idSocieta)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"         
                            SELECT
                            UTENTE.ute_id_utente as idAutorizzatore,                             
				            COALESCE(UTENTE.ute_cognome + ' ' + UTENTE.ute_nome, UTENTE.ute_cognome) as autorizzatore	                            
                            FROM LOOKUP_SOCIETA_CLIENTE                            
				            INNER JOIN UTENTE ON LOOKUP_SOCIETA_CLIENTE.LSL_ID_AUTORIZZATORE = UTENTE.UTE_ID_UTENTE
                            WHERE LOOKUP_SOCIETA_CLIENTE.LSL_ID_SOCIETA_CLIENTE = @idSocieta ");

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "idSocieta", DbType.Int32, idSocieta);
                db.LoadDataSet(dbCommand, ds, "LOOKUP_SOCIETA_CLIENTE");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "lookup_societa_cliente.getAutorizzatoreSocieta.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }



        /// <summary>
        /// Elenca tutti gli elementi LookupSocietaCliente dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "CROSS_CLIENTE_RUOLI");
        }
        /// <summary>
        /// Elenca tutti gli elementi LookupSocietaCliente dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet List(string sqlWhereClause)
        {
            return List(sqlWhereClause, "CROSS_CLIENTE_RUOLI");
        }
        /// <summary>
        /// Elenca tutti gli elementi LookupSocietaCliente dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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

                sb.Append(@"SELECT 
                               LSL_ID_SOCIETA_CLIENTE
                              ,CLI_ID_CLIENTE
                              ,LSL_DESCRIZIONE
                              ,LSL_SIGLA
                              ,LSL_ID_AUTORIZZATORE
                              ,LSL_ID_CREATO_DA
                              ,LSL_ID_AGGIORNATO_DA
                              ,LSL_ID_ELIMINATO_DA
                              ,LSL_DATA_CREAZIONE
                              ,LSL_DATA_AGGIORNAMENTO
                              ,LSL_FLAG_ELIMINATO
                          FROM LOOKUP_SOCIETA_CLIENTE ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, tableName);

                //// Add keys to table for correct use of Infragistics WebDataGrid.
                //DataColumn[] keys = new DataColumn[1];
                //keys[0] = ds.Tables["LOOKUP_SOCIETA_CLIENTE"].Columns["LSL_ID_SOCIETA_CLIENTE"];
                //ds.Tables["LOOKUP_SOCIETA_CLIENTE"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupSocietaCliente.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }



        /// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete(SqlInt32 p_lsl_id_societa_cliente, SqlInt32 p_lsl_id_eliminato_da)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" 
                                UPDATE
                                    LOOKUP_SOCIETA_CLIENTE 
                                SET
                                    LSL_FLAG_ELIMINATO=1,
                                    LSL_ID_ELIMINATO_DA=@lsl_id_eliminato_da,
                                    LSL_DATA_AGGIORNAMENTO=GETDATE()
                                WHERE 
					                LSL_ID_SOCIETA_CLIENTE = @lsl_id_societa_cliente
					            ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lsl_id_societa_cliente", DbType.Int32, p_lsl_id_societa_cliente);
                db.AddInParameter(dbCommand, "lsl_id_eliminato_da", DbType.Int32, p_lsl_id_eliminato_da);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupSocietaCliente.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }



        /// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_lsl_id_societa_cliente)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @"SELECT
                               LSL_ID_SOCIETA_CLIENTE
                              ,CLI_ID_CLIENTE
                              ,LSL_DESCRIZIONE
                              ,LSL_SIGLA
                              ,LSL_ID_AUTORIZZATORE
                              ,LSL_ID_CREATO_DA
                              ,LSL_ID_AGGIORNATO_DA
                              ,LSL_ID_ELIMINATO_DA
                              ,LSL_DATA_CREAZIONE
                              ,LSL_DATA_AGGIORNAMENTO
                              ,LSL_FLAG_ELIMINATO
                          FROM LOOKUP_SOCIETA_CLIENTE WHERE 
					 (LSL_ID_SOCIETA_CLIENTE = @lsl_id_societa_cliente) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lsl_id_societa_cliente", DbType.Int32, p_lsl_id_societa_cliente);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    lsl_id_societa_cliente = reader.GetSqlInt32(0);
                    cli_id_cliente = reader.GetSqlInt32(1);
                    lsl_descrizione = reader.GetSqlString(2);
                    lsl_sigla = reader.GetSqlString(3);
                    lsl_id_autorizzatore= reader.GetSqlInt32(4);
                    lsl_id_creato_da = reader.GetSqlInt32(5);
                    lsl_id_aggiornato_da = reader.GetSqlInt32(6);
                    lsl_id_eliminato_da = reader.GetSqlInt32(7);
                    lsl_data_creazione = reader.GetSqlDateTime(8);
                    lsl_data_aggiornamento = reader.GetSqlDateTime(9);
                    lsl_flag_eliminato = reader.GetSqlInt32(10);
                    
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupSocietaCliente.Read.");
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

                sqlCommand = @" INSERT INTO [dbo].[LOOKUP_SOCIETA_CLIENTE]
                                   ([CLI_ID_CLIENTE]
                                   ,[LSL_DESCRIZIONE]
                                   ,[LSL_SIGLA]
                                   ,[LSL_ID_AUTORIZZATORE]
                                   ,[LSL_ID_CREATO_DA]
                                   ,[LSL_DATA_CREAZIONE]
                                   ,[LSL_FLAG_ELIMINATO])
                             VALUES
                                   (@cli_id_cliente
                                   ,@lsl_descrizione
                                   ,@lsl_sigla
                                   ,@lsl_id_autorizzatore
                                   ,@lsl_id_creato_da
                                   ,@lsl_data_creazione
                                   ,@lsl_flag_eliminato)

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
                db.AddInParameter(dbCommand, "lsl_descrizione", DbType.String, lsl_descrizione);
                db.AddInParameter(dbCommand, "lsl_sigla", DbType.String, lsl_sigla);
                db.AddInParameter(dbCommand, "lsl_id_autorizzatore", DbType.Int32, lsl_id_autorizzatore);
                db.AddInParameter(dbCommand, "lsl_id_creato_da", DbType.Int32, lsl_id_creato_da);
                db.AddInParameter(dbCommand, "lsl_data_creazione", DbType.DateTime, lsl_data_creazione);
                db.AddInParameter(dbCommand, "lsl_flag_eliminato", DbType.Int32, lsl_flag_eliminato);

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    lsl_id_societa_cliente = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupSocietaCliente.Create.");
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
		/// Aggiorna l'ggetto nella base dati
		/// </summary>	
		public void Update(SqlInt32 p_lsl_id_societa_cliente)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE [dbo].[LOOKUP_SOCIETA_CLIENTE]
                                SET [CLI_ID_CLIENTE] = @cli_id_cliente
                                  ,[LSL_DESCRIZIONE] = @lsl_descrizione
                                  ,[LSL_SIGLA] = @lsl_sigla
                                  ,[LSL_ID_AUTORIZZATORE] = @lsl_id_autorizzatore
                                  ,[LSL_ID_AGGIORNATO_DA] = @lsl_id_aggiornato_da
                                  ,[LSL_ID_ELIMINATO_DA] = @lsl_id_eliminato_da
                                  ,[LSL_DATA_AGGIORNAMENTO] = @lsl_data_aggiornamento
                                  ,[LSL_FLAG_ELIMINATO] = @lsl_flag_eliminato
					            WHERE   
				                (lsl_id_societa_cliente = @lsl_id_societa_cliente) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
                db.AddInParameter(dbCommand, "lsl_descrizione", DbType.String, lsl_descrizione);
                db.AddInParameter(dbCommand, "lsl_sigla", DbType.String, lsl_sigla);
                db.AddInParameter(dbCommand, "lsl_id_autorizzatore", DbType.Int32, lsl_id_autorizzatore);
                db.AddInParameter(dbCommand, "lsl_id_aggiornato_da", DbType.Int32, lsl_id_aggiornato_da);
                db.AddInParameter(dbCommand, "lsl_id_eliminato_da", DbType.Int32, lsl_id_eliminato_da); 
                db.AddInParameter(dbCommand, "lsl_data_aggiornamento", DbType.DateTime, lsl_data_aggiornamento);
                db.AddInParameter(dbCommand, "lsl_flag_eliminato", DbType.Int32, lsl_flag_eliminato);

                db.AddInParameter(dbCommand, "lsl_id_societa_cliente", DbType.Int32, p_lsl_id_societa_cliente);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupSocietaCliente.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }
        #endregion
    }
}
