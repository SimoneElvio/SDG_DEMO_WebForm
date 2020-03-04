#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   PermessoAccesso.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per PERMESSO_ACCESSO
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

namespace SDG.GestioneUtenti
{
    /// <summary>
    /// Tabella PERMESSO_ACCESSO 
    /// </summary>
    public class PermessoAccesso
    {
        #region attributi e variabili

        private SqlInt32 rul_id_ruolo = SqlInt32.Null;
        private SqlInt32 fnt_id_funzionalita = SqlInt32.Null;
        private SqlInt32 pms_id_modalita_accesso = SqlInt32.Null;


        private string sqlWhereClause = "";
        private DataSet permesso_accessoListDS;

        // ---------------------------------------------------------------------
        // Costanti per facilitare il mapping con le colonne
        // Devono essere nello stesso ordine dei campi della tabella 
        // corrispondente
        // ---------------------------------------------------------------------		

        private const int RUL_ID_RUOLO = 0;
        private const int FNT_ID_FUNZIONALITA = 1;
        private const int PMS_ID_MODALITA_ACCESSO = 2;

        #endregion

        #region Proprieta


        /// <value>
        /// 
        /// </value>
        public SqlInt32 Rul_id_ruolo
        {
            get { return rul_id_ruolo; }
            set { rul_id_ruolo = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Fnt_id_funzionalita
        {
            get { return fnt_id_funzionalita; }
            set { fnt_id_funzionalita = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Pms_id_modalita_accesso
        {
            get { return pms_id_modalita_accesso; }
            set { pms_id_modalita_accesso = value; }
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
        /// Elenco degli elementi PermessoAccesso selezionati
        /// </value>
        public DataSet Permesso_accessoListDS
        {
            get { return permesso_accessoListDS; }
            set { permesso_accessoListDS = value; }
        }

        #endregion

        #region  Costruttori

        /// <summary>
        /// Costruttore standard
        /// </summary>
        public PermessoAccesso()
        {
            permesso_accessoListDS = new DataSet();
        }
        #endregion

        #region Metodi
        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void Read()
        {
            IDataReader reader = null;
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                string sqlCommand = " SELECT " +
                     "RUL_ID_RUOLO, " +
                     "FNT_ID_FUNZIONALITA, " +
                     "PMS_ID_MODALITA_ACCESSO	 " +
                    "FROM PERMESSO_ACCESSO WHERE " +
                     "(RUL_ID_RUOLO =@rul_id_ruolo) " + "AND (FNT_ID_FUNZIONALITA =@fnt_id_funzionalita) " +
                     " ";

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);
                db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);

                reader = db.ExecuteReader(dbCommand);

                while (reader.Read())
                {
                    rul_id_ruolo = reader.GetInt32(RUL_ID_RUOLO);
                    fnt_id_funzionalita = reader.GetInt32(FNT_ID_FUNZIONALITA);
                    pms_id_modalita_accesso = reader.GetInt32(PMS_ID_MODALITA_ACCESSO);
                }
            }
            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }

        //INIZIO AGGIUNTA SGA
        /// <summary>
        /// Test di esistenza di un record nella base dati
        /// </summary>
        public int TestExist()
        {
            IDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;
            int result = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = " SELECT " +
                     "RUL_ID_RUOLO, " +
                     "FNT_ID_FUNZIONALITA, " +
                     "PMS_ID_MODALITA_ACCESSO	 " +
                    "FROM PERMESSO_ACCESSO WHERE " +
                     "(RUL_ID_RUOLO =@rul_id_ruolo) " + "AND (FNT_ID_FUNZIONALITA =@fnt_id_funzionalita) " +
                     " ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);
                db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);

                reader = db.ExecuteReader(dbCommand);
                if (reader.Read()) result = 1;      //Record trovato
                
                reader.Close();

                return result;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "PermessoAccesso.TestExist.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

                return result;
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }
        //FINE AGGIUNTA SGA

        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void Update()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                string sqlCommand = " UPDATE PERMESSO_ACCESSO SET " +
                    "RUL_ID_RUOLO = @rul_id_ruolo, " +
                    "FNT_ID_FUNZIONALITA = @fnt_id_funzionalita, " +
                    "PMS_ID_MODALITA_ACCESSO = @pms_id_modalita_accesso	 " +
                    "WHERE " +
                    "(RUL_ID_RUOLO =@rul_id_ruolo) " + "AND (FNT_ID_FUNZIONALITA =@fnt_id_funzionalita) " +
                    " ";


                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                //Controllare ordine parametri ...
                db.AddInParameter(dbCommand, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);
                db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);
                db.AddInParameter(dbCommand, "pms_id_modalita_accesso", DbType.Int32, pms_id_modalita_accesso);


                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public void Delete(int RUL_ID_RUOLO, int FNT_ID_FUNZIONALITA)
        {

            // sistemare .....
            rul_id_ruolo = RUL_ID_RUOLO;
            fnt_id_funzionalita = FNT_ID_FUNZIONALITA;

            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = " DELETE FROM PERMESSO_ACCESSO WHERE " +
                    "(RUL_ID_RUOLO =@rul_id_ruolo) " + "AND (FNT_ID_FUNZIONALITA =@fnt_id_funzionalita) " + " ";
                
                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);
                db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);
                
                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "PermessoAccesso.Delete.");
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
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                string sqlCommand = " INSERT INTO PERMESSO_ACCESSO (" +
                        "RUL_ID_RUOLO, " +
                        "FNT_ID_FUNZIONALITA, " +
                        "PMS_ID_MODALITA_ACCESSO	 )" +
                    "VALUES ( " +
                        "@rul_id_ruolo, " +
                        "@fnt_id_funzionalita, " +
                        "@pms_id_modalita_accesso	 )";



                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "rul_id_ruolo", DbType.Int32, rul_id_ruolo);
                db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);
                db.AddInParameter(dbCommand, "pms_id_modalita_accesso", DbType.Int32, pms_id_modalita_accesso);

                db.ExecuteNonQuery(dbCommand);


            }
            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

        }

        /// <summary>
        /// Elenca tutti gli elementi PermessoAccesso dell'analisi
        /// </summary>
        public DataSet List()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                string sqlCommand = " SELECT " +
                        "RUL_ID_RUOLO, " +
                        "FNT_ID_FUNZIONALITA, " +
                        "PMS_ID_MODALITA_ACCESSO	 " +
                        "FROM PERMESSO_ACCESSO " + @sqlWhereClause;

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                db.LoadDataSet(dbCommand, permesso_accessoListDS, "PERMESSO_ACCESSO");
                return permesso_accessoListDS;

            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (permesso_accessoListDS != null)
                    ((IDisposable)permesso_accessoListDS).Dispose();
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi PermessoAccesso di un dato ruolo
        /// </summary>
        public IDataReader ListPermessiAccessoByRuolo(string myParRulIdRuolo, string nodeValue)
        {
            try
            {
                if (myParRulIdRuolo == SqlString.Null)
                {
                    myParRulIdRuolo = "0";
                }

                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                string sqlCommand = " SELECT " +
                        "PERMESSO_ACCESSO.RUL_ID_RUOLO, " +
                        "PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA, " +
                        "PERMESSO_ACCESSO.PMS_ID_MODALITA_ACCESSO, " +
                        "PERMESSI_LOOKUP.PMS_DESCRIZIONE, " +
                        "RUOLI.RUL_RUOLO, " +
                        "FUNZIONALITA.FNT_DESCRIZIONE_ITA, " +
                        "FUNZIONALITA.FNT_DESCRIZIONE_ENG, " +
                        "FUNZIONALITA.FNT_PAGINA_ASP, " +
                        "FUNZIONALITA.FNT_FLAG_VISIBILITA_MENU, " +
                        "FUNZIONALITA.FUN_FNT_ID_FUNZIONALITA " +
                        "FROM PERMESSO_ACCESSO " +
                        "LEFT JOIN PERMESSI_LOOKUP ON PERMESSI_LOOKUP.PMS_ID_MODALITA_ACCESSO = PERMESSO_ACCESSO.PMS_ID_MODALITA_ACCESSO " +
                        "LEFT JOIN RUOLI ON RUOLI.RUL_ID_RUOLO = PERMESSO_ACCESSO.RUL_ID_RUOLO " +
                        "LEFT JOIN FUNZIONALITA ON FUNZIONALITA.FNT_ID_FUNZIONALITA = PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA " +
                        "WHERE PERMESSO_ACCESSO.RUL_ID_RUOLO = " + myParRulIdRuolo + " " +
                        "AND FUNZIONALITA.FNT_ID_FUNZIONALITA <> " + nodeValue + " " +
                        "AND FUNZIONALITA.FNT_FLAG_ELIMINATO=0" + " " + 
                        "ORDER BY FUNZIONALITA.FNT_POSIZIONE ASC ";

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                
                return db.ExecuteReader(dbCommand);
            }
                
            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }
        }

        //AR Aggiunto metodo per popolare correttamente il Menu Funzionalità
        /// <summary>
        /// Elenca tutti gli elementi PermessoAccesso di un dato utente.
        /// </summary>
        public IDataReader ListPermessiAccessoByUtente(string myParUteIdUtente, string nodeValue,string lingua)
        {
            try
            {
                if (myParUteIdUtente == SqlString.Null)
                {
                    myParUteIdUtente = "0";
                }

                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                string sqlCommand = " SELECT " +
                                        "FUNZIONALITA.FNT_ID_FUNZIONALITA, " +
                                        "MAX_ACCESSO.MODALITA_ACCESSO, " +                        
                                        "DIZIONARIO.DIZ_DESCRIZIONE, " +
                                        "FUNZIONALITA.FNT_PAGINA_ASP, " +
                                        "FUNZIONALITA.FNT_FLAG_VISIBILITA_MENU, " +
                                        "FUNZIONALITA.FUN_FNT_ID_FUNZIONALITA, " +
                                        "FUNZIONALITA.FNT_FLAG_APRI_NUOVA, " +
                                        "FUNZIONALITA.FNT_ICONA_MENU " +
                                        "FROM FUNZIONALITA " +
                                            "LEFT JOIN ( " +
                                            "SELECT MAX(PERMESSO_ACCESSO.PMS_ID_MODALITA_ACCESSO) AS MODALITA_ACCESSO, " +
                                            "FUNZIONALITA.FNT_ID_FUNZIONALITA AS ID_FUNZIONALITA " +
                                            "FROM UTENTE " +
                                            "INNER JOIN RUOLI_UTENTE ON RUOLI_UTENTE.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE " +
                                            "INNER JOIN RUOLI ON RUOLI_UTENTE.RUL_ID_RUOLO = RUOLI.RUL_ID_RUOLO " +
                                            "INNER JOIN PERMESSO_ACCESSO ON RUOLI.RUL_ID_RUOLO = PERMESSO_ACCESSO.RUL_ID_RUOLO " +
                                            "INNER JOIN FUNZIONALITA ON PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA = FUNZIONALITA.FNT_ID_FUNZIONALITA " +                        
                                            "WHERE UTENTE.UTE_ID_UTENTE = " + myParUteIdUtente + " " +
                                            "AND RUOLI_UTENTE.URL_STATO_RUOLO_UTENTE = 1 " +                        
                                            "GROUP BY FUNZIONALITA.FNT_ID_FUNZIONALITA " +
                                            ") MAX_ACCESSO ON FUNZIONALITA.FNT_ID_FUNZIONALITA = MAX_ACCESSO.ID_FUNZIONALITA " +
                                        "INNER JOIN DIZIONARIO ON FUNZIONALITA.FNT_CHIAVE_DIZIONARIO = DIZIONARIO.DIZ_CHIAVE " +
                                        "WHERE FUNZIONALITA.FNT_FLAG_ELIMINATO=0 AND FUNZIONALITA.FNT_ID_FUNZIONALITA <> " + nodeValue + " " +
                                        "AND DIZIONARIO.LKN_CODICE_UIC = '" + lingua + "' " +
                                        "ORDER BY FUNZIONALITA.FNT_POSIZIONE ASC ";

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                return db.ExecuteReader(dbCommand);
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }
        }

        //AR Aggiunta utility che restituisce l'ID dato il permesso
        /// <summary>
        /// getPermessoFromName
        /// </summary>
        /// <returns>PMS_ID_MODALITA_ACCESSO</returns>
        public void getPermessoFromName(string theName)
        {
            IDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                //AR N.B. questa select è stata strutturata così affinché 
                // la posizione PMS_ID_MODALITA_ACCESSO sia coerente con l'enumerativo
                sqlCommand = " SELECT " +
                " 0, 0, PMS_ID_MODALITA_ACCESSO " +
                " FROM PERMESSI_LOOKUP WHERE PMS_DESCRIZIONE = '" + theName + "' ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                reader = db.ExecuteReader(dbCommand);
                while (reader.Read())
                {
                    pms_id_modalita_accesso = reader.GetInt32(PMS_ID_MODALITA_ACCESSO);
                }
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "PermessiLookup.getPermessoFromName.");
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
        /// getLookupPermessi
        /// </summary>
        /// <param name="qCultureInfoName"></param>
        /// <returns>dataSet:PMS_ID_MODALITA_ACCESSO,PMS_DESCRIZIONE</returns>
        public IDataReader getLookupPermessi()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = " SELECT " +
                " PMS_ID_MODALITA_ACCESSO, " +
                " PMS_DESCRIZIONE " +
                " FROM PERMESSI_LOOKUP " + @sqlWhereClause;

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                return db.ExecuteReader(dbCommand);
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "PermessiLookup.getLookupPermessi.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

                IDataReader idr = null;
                return idr;
            }
        }



        /// <summary>
        /// getDsLookupPermessi
        /// </summary>
        /// <param name="qCultureInfoName"></param>
        /// <returns>dataSet:PMS_ID_MODALITA_ACCESSO,PMS_DESCRIZIONE</returns>
        public DataSet getDsLookupPermessi()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            DataSet dsPermessi = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = " SELECT " +
                " PMS_ID_MODALITA_ACCESSO, " +
                " PMS_DESCRIZIONE " +
                " FROM PERMESSI_LOOKUP " + @sqlWhereClause;

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                db.LoadDataSet(dbCommand, dsPermessi, "PERMESSI");
                return dsPermessi;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "PermessiLookup.getDsLookupPermessi.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                throw ex;
            }
            finally
            {
                if (dsPermessi != null)
                    ((IDisposable)dsPermessi).Dispose();
            }
            
        }
        #endregion

    }
}


