#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   TestiPagine.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per TESTI_PAGINE
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
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Text;
using SDG.ExceptionHandling;

namespace SDG.GestioneUtenti
{
    /// <summary>
    /// Tabella TESTI_PAGINE 
    /// </summary>
    public class TestiPagine
    {
        #region attributi e variabili

        private SqlInt32 tpg_id_testo = SqlInt32.Null;
        private SqlString tpg_pagina = SqlString.Null;
        private SqlString tpg_posizione = SqlString.Null;
        private SqlString testo_it = SqlString.Null;
        private SqlString testo_en = SqlString.Null;

        private string sqlWhereClause = "";
        private DataSet testi_pagineListDS;

        // ---------------------------------------------------------------------
        // Costanti per facilitare il mapping con le colonne
        // Devono essere nello stesso ordine dei campi della tabella 
        // corrispondente
        // ---------------------------------------------------------------------		

        private const int TPG_ID_TESTO = 0;
        private const int TPG_PAGINA = 1;
        private const int TPG_POSIZIONE = 2;
        private const int TESTO_IT = 3;
        private const int TESTO_EN = 4;

        #endregion

        #region Proprieta


        /// <value>
        /// 
        /// </value>
        public SqlInt32 Tpg_id_testo
        {
            get { return tpg_id_testo; }
            set { tpg_id_testo = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Tpg_pagina
        {
            get { return tpg_pagina; }
            set { tpg_pagina = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Tpg_posizione
        {
            get { return tpg_posizione; }
            set { tpg_posizione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Testo_it
        {
            get { return testo_it; }
            set { testo_it = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Testo_en
        {
            get { return testo_en; }
            set { testo_en = value; }
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
        /// Elenco degli elementi TestiPagine selezionati
        /// </value>
        public DataSet Testi_pagineListDS
        {
            get { return testi_pagineListDS; }
            set { testi_pagineListDS = value; }
        }

        #endregion

        #region  Costruttori

        /// <summary>
        /// Costruttore standard
        /// </summary>
        public TestiPagine()
        {
            testi_pagineListDS = new DataSet();
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

                sqlCommand = @" SELECT 
					 TESTI_PAGINE.TPG_ID_TESTO, 
					 TESTI_PAGINE.TPG_PAGINA, 
					 TESTI_PAGINE.TPG_POSIZIONE, 
					 TESTI_PAGINE.TESTO_IT, 
					 TESTI_PAGINE.TESTO_EN	 
				 	 FROM TESTI_PAGINE WHERE 
					 (TPG_PAGINA =@tpg_pagina AND TPG_POSIZIONE =@tpg_posizione ) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "tpg_pagina", DbType.String, tpg_pagina);
                db.AddInParameter(dbCommand, "tpg_posizione", DbType.String, tpg_posizione);

                reader = db.ExecuteReader(dbCommand);

                while (reader.Read())
                {
                    if (reader.IsDBNull(TPG_ID_TESTO))
                    {
                        tpg_id_testo = SqlInt32.Null;
                    }
                    else
                    {
                        tpg_id_testo = reader.GetInt32(TPG_ID_TESTO);
                    }

                    if (reader.IsDBNull(TPG_PAGINA))
                    {
                        tpg_pagina = SqlString.Null;
                    }
                    else
                    {
                        tpg_pagina = reader.GetString(TPG_PAGINA);
                    }

                    if (reader.IsDBNull(TPG_POSIZIONE))
                    {
                        tpg_posizione = SqlString.Null;
                    }
                    else
                    {
                        tpg_posizione = reader.GetString(TPG_POSIZIONE);
                    }

                    if (reader.IsDBNull(TESTO_IT))
                    {
                        testo_it = SqlString.Null;
                    }
                    else
                    {
                        testo_it = reader.GetString(TESTO_IT);
                    }

                    if (reader.IsDBNull(TESTO_EN))
                    {
                        testo_en = SqlString.Null;
                    }
                    else
                    {
                        testo_en = reader.GetString(TESTO_EN);
                    }

                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TestiPagine.Read.");
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

                sqlCommand = @" UPDATE TESTI_PAGINE SET 
					 TPG_PAGINA = @tpg_pagina, 
					 TPG_POSIZIONE = @tpg_posizione, 
					 TESTO_IT = @testo_it, 
					 TESTO_EN = @testo_en
					 WHERE   
				     (TPG_ID_TESTO =@tpg_id_testo) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "tpg_pagina", DbType.String, tpg_pagina);
                db.AddInParameter(dbCommand, "tpg_posizione", DbType.String, tpg_posizione);
                db.AddInParameter(dbCommand, "testo_it", DbType.String, testo_it);
                db.AddInParameter(dbCommand, "testo_en", DbType.String, testo_en);

                db.AddInParameter(dbCommand, "tpg_id_testo", DbType.Int32, tpg_id_testo);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TestiPagine.Update.");
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
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM TESTI_PAGINE WHERE 
					(TPG_ID_TESTO =@tpg_id_testo) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "tpg_id_testo", DbType.Int32, tpg_id_testo);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TestiPagine.Delete.");
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

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO TESTI_PAGINE (
						TPG_PAGINA, 
						TPG_POSIZIONE, 
						TESTO_IT, 
						TESTO_EN	 ) 
					VALUES ( 
						@tpg_pagina, 
						@tpg_posizione, 
						@testo_it, 
						@testo_en	 ) 

				; SELECT SCOPE_IDENTITY()";


                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "tpg_pagina", DbType.String, tpg_pagina);
                db.AddInParameter(dbCommand, "tpg_posizione", DbType.String, tpg_posizione);
                db.AddInParameter(dbCommand, "testo_it", DbType.String, testo_it);
                db.AddInParameter(dbCommand, "testo_en", DbType.String, testo_en);

                IDataReader dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    tpg_id_testo = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();


            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TestiPagine.Create.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

        }

        /// <summary>
        /// Elenca tutti gli elementi TestiPagine dell'analisi
        /// </summary>
        public DataSet List()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" SELECT ");
                sb.Append("TESTI_PAGINE.TPG_ID_TESTO, ");
                sb.Append("TESTI_PAGINE.TPG_PAGINA, ");
                sb.Append("TESTI_PAGINE.TPG_POSIZIONE, ");
                sb.Append("TESTI_PAGINE.TESTO_IT, ");
                sb.Append("TESTI_PAGINE.TESTO_EN	 ");
                sb.Append("FROM TESTI_PAGINE ");

                sb.Append(@sqlWhereClause);
                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                db.LoadDataSet(dbCommand, testi_pagineListDS, "TESTI_PAGINE");
                return testi_pagineListDS;

            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TestiPagine.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

                return testi_pagineListDS;
            }

            finally
            {
                if (testi_pagineListDS != null)
                    ((IDisposable)testi_pagineListDS).Dispose();
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi TestiPagine dell'analisi
        /// </summary>
        public DataSet ListHelp()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" SELECT ");
                sb.Append("TESTI_PAGINE.TPG_ID_TESTO, ");
                sb.Append("TESTI_PAGINE.TPG_PAGINA, ");
                sb.Append("TESTI_PAGINE.TPG_POSIZIONE, ");
                sb.Append("TESTI_PAGINE.TESTO_IT, ");
                sb.Append("TESTI_PAGINE.TESTO_EN	 ");
                sb.Append("FROM TESTI_PAGINE ");

                sb.Append(@sqlWhereClause);
                if (sqlWhereClause != null)
                    sb.Append(" AND TPG_POSIZIONE = 'HELP' ");
                else
                    sb.Append(" WHERE TPG_POSIZIONE = 'HELP' ");

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                db.LoadDataSet(dbCommand, testi_pagineListDS, "TESTI_PAGINE");
                return testi_pagineListDS;

            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "TestiPagine.ListHelp.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

                return testi_pagineListDS;
            }

            finally
            {
                if (testi_pagineListDS != null)
                    ((IDisposable)testi_pagineListDS).Dispose();
            }
        }

        /// <summary>
        /// Ricava i testi della pagina per una lingua
        /// </summary>
        /// <param name="nazID">Identificatore della nazione che determina la lingua</param>
        /// <param name="nameClassPage">Nome della classe della pagina</param>
        /// <returns>Una dictionary table nome-valore con la traduzione dei termini nella lingua indicata</returns>
        public Dictionary<string, string> GetTestipagina(string nameClassPage, int nazID)
        {
            Dictionary<string, string> objHT;
            IDataReader objDr = null;
            objHT = new Dictionary<string, string>();

            try
            {
                string sqlCommand;
                string pos = "";
                string testo = "";
                string field_naz = "";
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                switch (nazID)
                {
                    case 1:
                        field_naz = "TESTO_IT";
                        break;
                    case 3:
                        field_naz = "TESTO_EN";
                        break;
                    default:
                        field_naz = "TESTO_IT";
                        break;
                }

                sqlCommand = "SELECT TPG_POSIZIONE, ";
                sqlCommand += field_naz;
                sqlCommand += " FROM TESTI_PAGINE WHERE TPG_PAGINA = @nameClassPage";
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "nameClassPage", DbType.String, nameClassPage);

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
                        pos = objDr.GetString(0);

                    //Debug.Assert(!objDr.IsDBNull(DIZ_DESCRIZIONE), "Dizionario incompleto!");
                    if (!objDr.IsDBNull(1))
                        testo = objDr.GetString(1);

                    objHT.Add(pos, testo);
                }
                objDr.Close();
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method:", " TestiPagine.GetTestipagina.  ");


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


