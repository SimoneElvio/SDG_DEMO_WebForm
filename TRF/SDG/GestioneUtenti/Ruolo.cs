#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Ruoli.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per RUOLI
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
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SDG.ExceptionHandling;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SDG.GestioneUtenti
{
    /// <summary>
    /// Tabella RUOLI 
    /// </summary>
    public class Ruoli
    {
        #region attributi e variabili

        private SqlInt32 rul_id_ruolo = SqlInt32.Null;
        private SqlString rul_ruolo = SqlString.Null;
        private SqlDateTime rul_data_creazione = SqlDateTime.Null;
        private SqlBoolean rul_assegnazione_predefinita = SqlBoolean.Null;
        private SqlString rul_descrizione_estesa = SqlString.Null;
        private SqlInt32 rul_nro_max_elementi = SqlInt32.Null;

        private string sqlWhereClause = "";
        private DataSet ruoliListDS;

        // ---------------------------------------------------------------------
        // Costanti per facilitare il mapping con le colonne
        // Devono essere nello stesso ordine dei campi della tabella 
        // corrispondente
        // ---------------------------------------------------------------------		

        private const int RUL_ID_RUOLO = 0;
        private const int RUL_RUOLO = 1;
        private const int RUL_DATA_CREAZIONE = 2;
        private const int RUL_ASSEGNAZIONE_PREDEFINITA = 3;
        private const int RUL_DESCRIZIONE_ESTESA = 4;
        private const int RUL_NRO_MAX_ELEMENTI = 5;

        #endregion

        #region Proprieta


        /// <value>
        /// ID Profilo
        /// </value>
        public SqlInt32 Rul_id_ruolo
        {
            get { return rul_id_ruolo; }
            set { rul_id_ruolo = value; }
        }

        /// <value>
        /// Nome del Profilo
        /// </value>
        public SqlString Rul_ruolo
        {
            get { return rul_ruolo; }
            set { rul_ruolo = value; }
        }

        /// <value>
        /// Descrizione estesa del ruolo
        /// </value>
        public SqlString Rul_descrizione_estesa
        {
            get { return rul_descrizione_estesa; }
            set { rul_descrizione_estesa = value; }
        }

        /// <value>
        /// Nro massimo di persone associabili
        /// </value>
        public SqlInt32 Rul_nro_max_elementi
        {
            get { return rul_nro_max_elementi; }
            set { rul_nro_max_elementi = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlDateTime Rul_data_creazione
        {
            get { return rul_data_creazione; }
            set { rul_data_creazione = value; }
        }

        /// <value>
        /// Indica se quando creo il profilo, l'utente è abilitato di default ad appartenere a tale ruolo.
        /// </value>
        public SqlBoolean Rul_assegnazione_predefinita
        {
            get { return rul_assegnazione_predefinita; }
            set { rul_assegnazione_predefinita = value; }
        }


        /// <value>
        /// Where Clause condition
        /// </value>
        public string SqlWhereClause
        {
            get { return sqlWhereClause; }
            set { sqlWhereClause = value; }
        }

        /// <value>
        /// Elenco degli elementi Ruoli selezionati
        /// </value>
        public DataSet RuoliListDS
        {
            get { return ruoliListDS; }
            set { ruoliListDS = value; }
        }

        #endregion

        #region  Costruttori

        /// <summary>
        /// Costruttore standard
        /// </summary>
        public Ruoli()
        {
            ruoliListDS = new DataSet();
        }
        #endregion

        #region Metodi
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

                sqlCommand = " SELECT " +
                     "RUOLI.RUL_ID_RUOLO, " +
                     "RUOLI.RUL_RUOLO, " +
                     "RUOLI.RUL_DATA_CREAZIONE, " +
                     "RUOLI.RUL_ASSEGNAZIONE_PREDEFINITA,RUL_DESCRIZIONE_ESTESA,RUL_NRO_MAX_ELEMENTI " +
                    "FROM RUOLI WHERE " +
                     "(RUL_ID_RUOLO =@rul_id_ruolo) " +
                     " ";
                
                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);

                reader = db.ExecuteReader(dbCommand);

                while (reader.Read())
                {
                    rul_id_ruolo = (reader.IsDBNull(RUL_ID_RUOLO)) ? (SqlInt32.Null) : (reader.GetInt32(RUL_ID_RUOLO));
                    rul_ruolo = (reader.IsDBNull(RUL_RUOLO)) ? (SqlString.Null) : (reader.GetString(RUL_RUOLO));
                    rul_data_creazione = (reader.IsDBNull(RUL_DATA_CREAZIONE)) ? (SqlDateTime.Null) : (reader.GetDateTime(RUL_DATA_CREAZIONE));
                    rul_assegnazione_predefinita = (reader.IsDBNull(RUL_ASSEGNAZIONE_PREDEFINITA)) ? (SqlBoolean.Null) : (reader.GetBoolean(RUL_ASSEGNAZIONE_PREDEFINITA));
                    rul_descrizione_estesa = (reader.IsDBNull(RUL_DESCRIZIONE_ESTESA)) ? (SqlString.Null) : (reader.GetString(RUL_DESCRIZIONE_ESTESA));
                    rul_nro_max_elementi = (reader.IsDBNull(RUL_NRO_MAX_ELEMENTI)) ? (SqlInt32.Null) : (reader.GetInt32(RUL_NRO_MAX_ELEMENTI));
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Ruoli.Read.");
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
        public void Update()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = " UPDATE RUOLI SET " +
                    "RUL_RUOLO = @rul_ruolo, " +
                    "RUL_DESCRIZIONE_ESTESA = @rul_descrizione_estesa, " +
                    "RUL_NRO_MAX_ELEMENTI = @rul_nro_max_elementi, " +
                    "RUL_ASSEGNAZIONE_PREDEFINITA = @rul_assegnazione_predefinita	 " +
                    "WHERE " +
                    "(RUL_ID_RUOLO =@rul_id_ruolo) " +
                    " ";
                
                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "rul_ruolo", DbType.String, rul_ruolo);
                db.AddInParameter(dbCommand, "rul_assegnazione_predefinita", DbType.Boolean, rul_assegnazione_predefinita);
                db.AddInParameter(dbCommand, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);
                db.AddInParameter(dbCommand, "rul_descrizione_estesa", DbType.String, rul_descrizione_estesa);
                db.AddInParameter(dbCommand, "rul_nro_max_elementi", DbType.Int32, rul_nro_max_elementi);
                
                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Ruoli.Update.");
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
            bool rethrow;
            DbTransaction transaction = null;
            DbConnection connection = null;
            DbCommand dbCommand = null;

            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            using (connection = db.CreateConnection())
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                try
                {
                    string sqlCommandPAC = @"
                            DELETE FROM PERMESSO_ACCESSO WHERE RUL_ID_RUOLO = @rul_id_ruolo
                            ";
                    DbCommand dbCommandPAC = db.GetSqlStringCommand(sqlCommandPAC);
                    db.AddInParameter(dbCommandPAC, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);

                    string sqlCommandURL = @"
                            DELETE FROM RUOLI_UTENTE WHERE RUL_ID_RUOLO = @rul_id_ruolo
                            ";
                    DbCommand dbCommandURL = db.GetSqlStringCommand(sqlCommandURL);
                    db.AddInParameter(dbCommandURL, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);

                    sqlCommand = @"
                            DELETE FROM RUOLI WHERE RUL_ID_RUOLO = @rul_id_ruolo
                            ";
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.AddInParameter(dbCommand, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);

                    db.ExecuteNonQuery(dbCommandPAC, transaction);
                    db.ExecuteNonQuery(dbCommandURL, transaction);
                    db.ExecuteNonQuery(dbCommand, transaction);

                    transaction.Commit();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    // Rollback transaction 
                    transaction.Rollback();

                    ex.Data.Add("Class.Method", "Ruoli.Delete.");
                    ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    rethrow = ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                    if (rethrow) throw;
                }
            }
        }

        /// <summary>
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void Create()
        {
            string sqlCommand = null;
            bool rethrow;
            DbTransaction transaction = null;
            DbConnection connection = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            using (connection = db.CreateConnection())
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                try
                {
                    sqlCommand = " INSERT INTO RUOLI (" +
                            "RUL_RUOLO,RUL_DESCRIZIONE_ESTESA,RUL_NRO_MAX_ELEMENTI, " +
                            "RUL_DATA_CREAZIONE, " +
                            "RUL_ASSEGNAZIONE_PREDEFINITA	 )" +
                        "VALUES ( " +
                            "@rul_ruolo,@rul_descrizione_estesa,@rul_nro_max_elementi, " +
                            "getDate(), " +
                            "@rul_assegnazione_predefinita	 )";

                    sqlCommand += "; SELECT SCOPE_IDENTITY()";

                    dbCommand = db.GetSqlStringCommand(sqlCommand);

                    db.AddInParameter(dbCommand, "rul_ruolo", DbType.String, rul_ruolo);
                    db.AddInParameter(dbCommand, "rul_descrizione_estesa", DbType.String, rul_descrizione_estesa);
                    db.AddInParameter(dbCommand, "rul_nro_max_elementi", DbType.Int32, rul_nro_max_elementi);
                    db.AddInParameter(dbCommand, "rul_assegnazione_predefinita", DbType.Boolean, rul_assegnazione_predefinita);

                    dataReader = db.ExecuteReader(dbCommand, transaction);
                    if (dataReader.Read())
                    {
                        rul_id_ruolo = Convert.ToInt32(dataReader[0]);
                    }
                    dataReader.Close();

                    //Inserimento di tutte le funzionalità con il loro valore di default
                    string sqlCommandFUNZ = @"
                            INSERT INTO PERMESSO_ACCESSO (RUL_ID_RUOLO, FNT_ID_FUNZIONALITA,
                            PMS_ID_MODALITA_ACCESSO) SELECT @rul_id_ruolo, FNT_ID_FUNZIONALITA,
                            FNT_ACCESSO_PREDEFINITO FROM FUNZIONALITA             
                            ";
                    DbCommand dbCommandFUNZ = db.GetSqlStringCommand(sqlCommandFUNZ);
                    db.AddInParameter(dbCommandFUNZ, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);
                    db.ExecuteNonQuery(dbCommandFUNZ, transaction);

                    transaction.Commit();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    // Rollback transaction 
                    transaction.Rollback();

                    ex.Data.Add("Class.Method", "Ruoli.Create.");
                    ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    rethrow = ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                    if (rethrow) throw;
                }
                finally
                {
                    if (dataReader != null)
                        ((IDisposable)dataReader).Dispose();
                }

            }
        }

        /// <summary>
        /// Elenca tutti gli elementi Ruoli dell'analisi
        /// </summary>
        public DataSet List()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = " SELECT " +
                        "RUOLI.RUL_ID_RUOLO, " +
                        "RUOLI.RUL_RUOLO, " +
                        "RUOLI.RUL_DATA_CREAZIONE, " +
                        "RUOLI.RUL_ASSEGNAZIONE_PREDEFINITA	 " +
                        "FROM RUOLI " + @sqlWhereClause + " ORDER BY RUL_RUOLO ASC ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                db.LoadDataSet(dbCommand, ruoliListDS, "RUOLI");
                return ruoliListDS;

            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Ruoli.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

                return ruoliListDS;
            }

            finally
            {
                if (ruoliListDS != null)
                    ((IDisposable)ruoliListDS).Dispose();
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi Ruolo di un dato utente
        /// </summary>
        public DataSet ListByUtente(int myParUteIdUtente)
        {
            try
            {
                if (myParUteIdUtente == SqlInt32.Null)
                {
                    myParUteIdUtente = 0;
                }


                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                string sqlCommand = " SELECT " +
                             "RUOLI.RUL_ID_RUOLO, " +
                             "RUOLI.RUL_RUOLO, " +
                             "CONVERT(VARCHAR(10),RUOLI.RUL_DATA_CREAZIONE, 103) AS RUL_DATA_CREAZIONE, " +
                             "CONVERT(VARCHAR(10),RUOLI_UTENTE.URL_DATA_ASSEGNAZIONE, 103 ) AS URL_DATA_ASSEGNAZIONE " +
                             "FROM RUOLI " +
                             "LEFT JOIN RUOLI_UTENTE ON RUOLI_UTENTE.RUL_ID_RUOLO = RUOLI.RUL_ID_RUOLO " +
                             "WHERE RUOLI_UTENTE.UTE_ID_UTENTE = " + @myParUteIdUtente + " ";

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParUteIdUtente", DbType.Int32, myParUteIdUtente);

                db.LoadDataSet(dbCommand, ruoliListDS, "RUOLI_UTENTE");
                return ruoliListDS;
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (ruoliListDS != null)
                    ((IDisposable)ruoliListDS).Dispose();
            }
        }

        /// <summary>
        /// Restituisce l'elenco dei ruoli.
        /// </summary>
        /// <returns>dataSet:RUL_ID_RUOLO,RUL_RUOLO</returns>
        public IDataReader getListDropDown()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            SqlDataReader reader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = " SELECT RUL_ID_RUOLO, RUL_RUOLO FROM RUOLI " + @sqlWhereClause + " ORDER BY RUL_RUOLO ASC ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Ruoli.getListDropDown.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return reader;
        }


        

        #endregion

    }
}


