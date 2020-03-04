#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Help.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per FUNZIONALITA
//
// Autore:      GPA - SDG srl
// Data:        20/11/2008
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
using System.Text;
using System.Data.Common;
using System.Collections.Specialized;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace SDG.GestioneUtenti
{
    /// <summary>
    /// Tabella TESTI_PAGINE Utilizzata per Help 
    /// </summary>
    public class Help 
    {
        #region attributi e variabili

        private SqlInt32 tpg_id_testo = SqlInt32.Null;
        private SqlString tpg_pagina = SqlString.Null;
        private SqlString tpg_posizione = SqlString.Null;
        private SqlString testo_it = SqlString.Null;
        private SqlString testo_en = SqlString.Null;

        private string sqlWhereClause = "";
        private DataSet helpListDS;
      
        private NameValueCollection Html;
        private bool exist;
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
		/// Elenco degli elementi Help selezionati
		/// </value>
		public DataSet HelpListDS
		{
			get { return  helpListDS; }
			set { helpListDS = value; }
		}

        public bool Exist
        {
            get { return exist; }
        }
        
        #endregion

        #region  Costruttori

        /// <summary>
        /// Costruttore standard
        /// </summary>
        public Help()
        {
            Html = new NameValueCollection();
            
            helpListDS = new DataSet();            			
        }
        #endregion

        #region Metodi
                
        public string GetHtml(string lingua)
        {
            return Html[lingua.ToLower()];
        }
        public void SetHtml(string stringHtml, string lingua)
        {
            Html[lingua] = stringHtml;
        }
        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void Read()
        {
            IDataReader reader = null;
           
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                string sqlCommand = @"SELECT    TESTI_PAGINE.TPG_ID_TESTO, 
                                                ISNULL(TESTI_PAGINE.TESTO_IT,'') AS TESTO_IT ,
                                                ISNULL(TESTI_PAGINE.TESTO_EN,'') AS TESTO_EN 
                                            FROM TESTI_PAGINE WHERE TPG_PAGINA = @tpg_pagina 
                                                AND TPG_POSIZIONE = @tpg_posizione ";
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "tpg_pagina", DbType.String, tpg_pagina);
                db.AddInParameter(dbCommand, "tpg_posizione", DbType.String, tpg_posizione);

                reader = db.ExecuteReader(dbCommand);
                
                if (reader.Read())
                {
                    //reader.Read();
                    exist = true;
                    string codiceNazione;
                    SqlString htmlNazione;
                    string nomeColonna;
                    for (int col = 1; col < reader.FieldCount; col++)
                    {
                        nomeColonna = reader.GetName(col);
                        codiceNazione = nomeColonna.Substring(nomeColonna.LastIndexOf("_") + 1);
                        htmlNazione = reader.GetString(col);
                        if (htmlNazione.IsNull)
                        {
                            htmlNazione = "";
                        }
                        Html.Add(codiceNazione.ToLower(), htmlNazione.Value);
                    }
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

        /// <summary>
        /// Crea l'oggetto nella base dati
        /// </summary>	
        public void Create()
        {
            if (Html.Keys.Count > 0)
            {
                try
                {

                    Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                    
                    StringBuilder q = new StringBuilder(300);


                    q.Append("INSERT INTO TESTI_PAGINE (TPG_PAGINA,TPG_POSIZIONE, ");
                    for (int i = 0; i < Html.Keys.Count; i++)
                    {
                        if (i > 0)
                        {
                            q.Append(",");
                        }
                        q.Append("TESTO_");
                        q.Append(Html.Keys[i]);
                    }
                    q.Append(") VALUES (@tpg_pagina,@tpg_posizione,");

                    for (int i = 0; i < Html.Keys.Count; i++)
                    {
                        if (i > 0)
                        {
                            q.Append(",");
                        }
                        q.Append("@val");
                        q.Append(i);
                    }
                    q.Append(")");

                    DbCommand dbCommand = db.GetSqlStringCommand(q.ToString());
                    db.AddInParameter(dbCommand, "tpg_pagina", DbType.String, tpg_pagina);
                    db.AddInParameter(dbCommand, "tpg_posizione", DbType.String, tpg_posizione);

                    for (int i = 0; i < Html.Keys.Count; i++)
                    {
                        db.AddInParameter(dbCommand, "val" + i, DbType.String, Html[i]);
                    }
                       
                    db.ExecuteNonQuery(dbCommand);
                
                    //reader = db.ExecuteReader(dbCommand);
                }
                catch (Exception ex)
                {
                    ex.Data.Add("Class.Method", "Help.Create.");

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                }
            }
        }

        /// <summary>
        /// Aggiorna l'oggetto sul db
        /// </summary>
        public void Update()
        {
            if (Html.Keys.Count > 0)
            {
                try
                {
                    Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                    StringBuilder q = new StringBuilder(300);
                   
                    q.Append("UPDATE TESTI_PAGINE SET ");
                    for (int i = 0; i < Html.Keys.Count; i++)
                    {
                        if (i > 0)
                        {
                            q.Append(" , ");
                        }
                        q.Append("TESTO_");
                        q.Append(Html.Keys[i]);
                        q.Append(" = @val");
                        q.Append(i);
                       // param[i + 1] = new SqlParameter("@val" + i, new SqlString(Html[i]));
                        					
                    }
                                                       
               
                    q.Append(" WHERE TPG_PAGINA = @tpg_pagina AND TPG_POSIZIONE = @tpg_posizione ");

                    DbCommand dbCommand = db.GetSqlStringCommand(q.ToString());
                    db.AddInParameter(dbCommand, "tpg_pagina", DbType.String, tpg_pagina);
                    db.AddInParameter(dbCommand, "tpg_posizione", DbType.String, tpg_posizione);


                    for (int i = 0; i < Html.Keys.Count; i++)
                    {
                        db.AddInParameter(dbCommand, "val" + i, DbType.String, Html[i]);
                    }

                    db.ExecuteNonQuery(dbCommand);
                }
                catch (Exception ex)
                {
                    ex.Data.Add("Class.Method", "Help.Update.");

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                }
            }
        }
        #endregion

    }
}

