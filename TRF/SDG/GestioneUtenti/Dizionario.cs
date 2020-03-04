#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Dizionario.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per DIZIONARIO
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

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using SDG.ExceptionHandling;

namespace SDG.GestioneUtenti
{
    /// <summary>
    /// Classe per la gestione di un dizionario di termini da utilizzare
    /// per implementare una interfaccia utente multilingua
    /// </summary>
    public class Dizionario
    {
        #region attributi e variabili

        private SqlInt32 diz_id_dizionario = SqlInt32.Null;
        private SqlString lkn_codice_uic = SqlString.Null;
        private SqlString diz_chiave = SqlString.Null;
        private SqlString diz_descrizione = SqlString.Null;
        private SqlDateTime diz_datacreazione = SqlDateTime.Null;


        private string sqlWhereClause = "";
        #endregion

        #region Proprieta
        
        /// <value>
        /// 
        /// </value>
        public SqlInt32 Diz_id_dizionario
        {
            get { return diz_id_dizionario; }
            set { diz_id_dizionario = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Lkn_codice_uic
        {
            get { return lkn_codice_uic; }
            set { lkn_codice_uic = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Diz_chiave
        {
            get { return diz_chiave; }
            set { diz_chiave = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Diz_descrizione
        {
            get { return diz_descrizione; }
            set { diz_descrizione = value; }
        }
        
        /// <value>
        /// 
        /// </value>
        public SqlDateTime Diz_datacreazione
        {
            get { return diz_datacreazione; }
            set { diz_datacreazione = value; }
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

        #region  Costruttori

        /// <summary>
        /// Costruttore standard
        /// </summary>
        public Dizionario()
        {
            
        }
        #endregion

        #region Metodi


        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void Read(SqlInt32 p_diz_id_dizionario)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 DIZIONARIO.DIZ_ID_DIZIONARIO, 
					 DIZIONARIO.LKN_CODICE_UIC, 
					 DIZIONARIO.DIZ_CHIAVE, 
					 DIZIONARIO.DIZ_DESCRIZIONE, 
					 DIZIONARIO.DIZ_DATACREAZIONE	 
				 	 FROM DIZIONARIO WHERE 
					 (DIZ_ID_DIZIONARIO = @diz_id_dizionario) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "diz_id_dizionario", DbType.Int32, p_diz_id_dizionario);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    diz_id_dizionario = reader.GetSqlInt32(0);
                    lkn_codice_uic = reader.GetSqlString(1);
                    diz_chiave = reader.GetSqlString(2);
                    diz_descrizione = reader.GetSqlString(3);
                    diz_datacreazione = reader.GetSqlDateTime(4);

                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Dizionario.Read.");
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
        public void Update(SqlInt32 p_diz_id_dizionario)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE DIZIONARIO SET 
					 LKN_CODICE_UIC = @lkn_codice_uic, 
					 DIZ_CHIAVE = @diz_chiave, 
					 DIZ_DESCRIZIONE = @diz_descrizione, 
					 DIZ_DATACREAZIONE = @diz_datacreazione
					 WHERE   
				     (DIZ_ID_DIZIONARIO =@diz_id_dizionario) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lkn_codice_uic", DbType.String, lkn_codice_uic);
                db.AddInParameter(dbCommand, "diz_chiave", DbType.String, diz_chiave);
                db.AddInParameter(dbCommand, "diz_descrizione", DbType.String, diz_descrizione);
                db.AddInParameter(dbCommand, "diz_datacreazione", DbType.DateTime, diz_datacreazione);

                db.AddInParameter(dbCommand, "diz_id_dizionario", DbType.Int32, p_diz_id_dizionario);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Dizionario.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public static void Delete(SqlInt32 p_diz_id_dizionario)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM DIZIONARIO WHERE 
					(DIZ_ID_DIZIONARIO =@diz_id_dizionario) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "diz_id_dizionario", DbType.Int32, p_diz_id_dizionario);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Dizionario.Delete.");
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

                sqlCommand = @" INSERT INTO DIZIONARIO (
						LKN_CODICE_UIC, 
						DIZ_CHIAVE, 
						DIZ_DESCRIZIONE	,
                        DIZ_DATACREAZIONE ) 
					VALUES ( 
						@lkn_codice_uic, 
						@diz_chiave, 
						@diz_descrizione, 
                        @diz_datacreazione	 ) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lkn_codice_uic", DbType.String, lkn_codice_uic);                
                db.AddInParameter(dbCommand, "diz_chiave", DbType.String, diz_chiave);
                db.AddInParameter(dbCommand, "diz_descrizione", DbType.String, diz_descrizione);
                db.AddInParameter(dbCommand, "diz_datacreazione", DbType.DateTime, diz_datacreazione);

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    diz_id_dizionario = Convert.ToInt32(dataReader[0]);                     
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Dizionario.Create.");
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
        /// Elenca tutti gli elementi Dizionario dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public DataSet List()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					DIZIONARIO.DIZ_ID_DIZIONARIO, 
					DIZIONARIO.LKN_CODICE_UIC, 
					DIZIONARIO.DIZ_CHIAVE, 
					DIZIONARIO.DIZ_DESCRIZIONE, 
					DIZIONARIO.DIZ_DATACREAZIONE 
				FROM DIZIONARIO ");

                if (SqlWhereClause != string.Empty)
                {
                    sb.Append(SqlWhereClause);
                }

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "DIZIONARIO");

                DataColumn[] keys = new DataColumn[1];
                // Add keys to table for correct use of Infragistics WebDataGrid.
                keys[0] = ds.Tables["DIZIONARIO"].Columns["DIZ_ID_DIZIONARIO"];
                ds.Tables["DIZIONARIO"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Dizionario.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Elenca tutti gli elementi Dizionario
        /// </summary>
        public static DataSet GetDsCodiciNazioni()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet dsDizionario = new DataSet();            
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" SELECT 'it' AS LKN_CODICE_UIC , 'it' AS LKN_DESCR ");
                sb.Append(" UNION ALL ");
                sb.Append(" SELECT 'en' AS LKN_CODICE_UIC , 'en' AS LKN_DESCR ");
                
                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                //db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                db.LoadDataSet(dbCommand, dsDizionario, "LKN_CODICE");

                return dsDizionario;

            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Dizionario.ListDizionario.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

                return dsDizionario;
            }
        }


        /// <summary>
        /// Ricava la traduzione dei termini per una lingua
        /// </summary>
        /// <param name="nazID">Identificatore della nazione che determina la lingua</param>
        /// <returns>Una hash table nome-valore con la traduzione dei termini nella lingua indicata</returns>
        public Dictionary<string, string> GetDictionary(int nazID)
        {
            Dictionary<string, string> objHT;
            IDataReader objDr = null;
            objHT = new Dictionary<string, string>();

            try
            {
                string sqlCommand;
                string diz_chiave = "";
                string diz_descrizione = "";
                string lkn_codice_uic;

                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                switch (nazID)
                {
                    case 1:
                        lkn_codice_uic = "it";
                        break;
                    case 3:
                        lkn_codice_uic = "en";
                        break;
                    default:
                        lkn_codice_uic = "it";
                        break;
                }

                sqlCommand = "SELECT DIZ_CHIAVE, DIZ_DESCRIZIONE FROM DIZIONARIO WHERE LKN_CODICE_UIC= @lkn_codice_uic";
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "lkn_codice_uic", DbType.String, lkn_codice_uic);

                objDr = db.ExecuteReader(dbCommand);

                // Se non torna righe c'e' quacosa di strano
                //if (!objDr.HasRows)
                //{
                //    throw new System.Exception("Non ci sono valori nel dizionario");
                //}
                while (objDr.Read())
                {
                    //Debug.Assert(!objDr.IsDBNull(DIZ_CHIAVE), "Dizionario incompleto!");
                    if (!objDr.IsDBNull(0))
                        diz_chiave = objDr.GetString(0);

                    //Debug.Assert(!objDr.IsDBNull(DIZ_DESCRIZIONE), "Dizionario incompleto!");
                    if (!objDr.IsDBNull(1))
                        diz_descrizione = objDr.GetString(1);

                    objHT.Add(diz_chiave, diz_descrizione);
                }
                objDr.Close();
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method:", " Dizionario.GetDictionary.  ");

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

            }

            finally
            {
                if (objDr != null)
                    ((IDisposable)objDr).Dispose();
            }

            return objHT;
        }




        #endregion
    }
}