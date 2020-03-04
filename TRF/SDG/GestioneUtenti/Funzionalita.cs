#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Funzionalita.cs
//
// Namespace:   SDG.GestioneUtenti
// Descrizione: Classe per FUNZIONALITA
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
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SDG.Utility;
using SDG.ExceptionHandling;

namespace SDG.GestioneUtenti
{
    /// <summary>
    /// Tabella FUNZIONALITA 
    /// </summary>
    public class Funzionalita
    {
        #region Costanti
        /// <summary>
        /// enum per la tabella Funzionalit‡
        /// </summary>
        public enum eFunzionalita
        {
            ApprovatoreLiv1 = 56,
            DirettoResponsabile = 174
        }

        #endregion

        #region attributi e variabili

        private SqlInt32 fnt_id_funzionalita = SqlInt32.Null;
	    private SqlInt32 fun_fnt_id_funzionalita = SqlInt32.Null;
	    private SqlString fnt_acronimo_funzionalita = SqlString.Null;
	    private SqlInt32 fnt_accesso_predefinito = SqlInt32.Null;
	    private SqlString fnt_descrizione_ita = SqlString.Null;
	    private SqlInt32 fnt_livello = SqlInt32.Null;
	    private SqlInt32 fnt_posizione = SqlInt32.Null;
	    private SqlString fnt_pagina_asp = SqlString.Null;
	    private SqlInt32 fnt_parametri = SqlInt32.Null;
	    private SqlBoolean fnt_flag_foglia = SqlBoolean.Null;
	    private SqlBoolean fnt_flag_visibilita_menu = SqlBoolean.Null;
	    private SqlBoolean fnt_flag_apri_nuova = SqlBoolean.Null;
	    private SqlString fnt_descrizione_eng = SqlString.Null;
	    private SqlDateTime fnt_data_creazione = SqlDateTime.Null;
	    private SqlDateTime fnt_data_aggiornamento = SqlDateTime.Null;
	    private SqlInt32 fnt_creato_da = SqlInt32.Null;
	    private SqlInt32 fnt_aggiornato_da = SqlInt32.Null;
        private SqlInt32 fnt_flag_figura = SqlInt32.Null;
        private SqlInt32 fnt_flag_eliminato= SqlInt32.Null;
        private SqlString fnt_icona_menu = SqlString.Null;
        private SqlString fnt_chiave_dizionario = SqlString.Null;


        private string sqlWhereClause = "";
		private DataSet funzionalitaListDS;

		#endregion

		#region Proprieta
		

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Fnt_id_funzionalita
		{
			get { return  fnt_id_funzionalita; }
			set { fnt_id_funzionalita = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Fun_fnt_id_funzionalita
		{
			get { return  fun_fnt_id_funzionalita; }
			set { fun_fnt_id_funzionalita = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Fnt_flag_figura
        {
            get { return fnt_flag_figura; }
            set { fnt_flag_figura = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Fnt_flag_eliminato
        {
            get { return fnt_flag_eliminato; }
            set { fnt_flag_eliminato = value; }
        }

        

        /// <value>
        /// Acronimo della Funzionalit√†.
        /// </value>
        public  SqlString Fnt_acronimo_funzionalita
		{
			get { return  fnt_acronimo_funzionalita; }
			set { fnt_acronimo_funzionalita = value; }
		}

		/// <value>
		/// Accesso di default.
		/// </value>
		public  SqlInt32 Fnt_accesso_predefinito
		{
			get { return  fnt_accesso_predefinito; }
			set { fnt_accesso_predefinito = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Fnt_descrizione_ita
		{
			get { return  fnt_descrizione_ita; }
			set { fnt_descrizione_ita = value; }
		}

		/// <value>
		/// Indica il livello di indentazione della funzionalit√† nell'albero dei Menu.
		/// </value>
		public  SqlInt32 Fnt_livello
		{
			get { return  fnt_livello; }
			set { fnt_livello = value; }
		}

		/// <value>
		/// Indica la posizione del ramo corrispondente alla funzionalit√† nell'albero dei Menu.
		/// </value>
		public  SqlInt32 Fnt_posizione
		{
			get { return  fnt_posizione; }
			set { fnt_posizione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Fnt_pagina_asp
		{
			get { return  fnt_pagina_asp; }
			set { fnt_pagina_asp = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Fnt_parametri
		{
			get { return  fnt_parametri; }
			set { fnt_parametri = value; }
		}

		/// <value>
		/// Indica se un nodo nell'albero delle funzionalit√† √® o meno una foglia
		/// </value>
		public  SqlBoolean Fnt_flag_foglia
		{
			get { return  fnt_flag_foglia; }
			set { fnt_flag_foglia = value; }
		}

		/// <value>
		/// Indica se la funzionalit√† deve comparire nell'albero dei menu, oppure √® una funzionalit√† utilizzata all'interno di sezioni del sistema.
		/// </value>
		public  SqlBoolean Fnt_flag_visibilita_menu
		{
			get { return  fnt_flag_visibilita_menu; }
			set { fnt_flag_visibilita_menu = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlBoolean Fnt_flag_apri_nuova
		{
			get { return  fnt_flag_apri_nuova; }
			set { fnt_flag_apri_nuova = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlString Fnt_descrizione_eng
		{
			get { return  fnt_descrizione_eng; }
			set { fnt_descrizione_eng = value; }
		}


        /// <value>
		/// 
		/// </value>
		public SqlString Fnt_icona_menu
        {
            get { return fnt_icona_menu; }
            set { fnt_icona_menu = value; }
        }

        /// <value>
		/// 
		/// </value>
		public SqlString Fnt_chiave_dizionario
        {
            get { return fnt_chiave_dizionario; }
            set { fnt_chiave_dizionario = value; }
        }
        
        /// <value>
        /// 
        /// </value>
        public  SqlDateTime Fnt_data_creazione
		{
			get { return  fnt_data_creazione; }
			set { fnt_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlDateTime Fnt_data_aggiornamento
		{
			get { return  fnt_data_aggiornamento; }
			set { fnt_data_aggiornamento = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Fnt_creato_da
		{
			get { return  fnt_creato_da; }
			set { fnt_creato_da = value; }
		}

		/// <value>
		/// 
		/// </value>
		public  SqlInt32 Fnt_aggiornato_da
		{
			get { return  fnt_aggiornato_da; }
			set { fnt_aggiornato_da = value; }
		}


		/// <value>
		/// Where Clause condition
		/// </value>
		public  string SqlWhereClause
		{
			get { return  sqlWhereClause; }
			set { sqlWhereClause = value; }
		}

		/// <value>
		/// Elenco degli elementi Funzionalita selezionati
		/// </value>
		public DataSet FunzionalitaListDS
		{
			get { return  funzionalitaListDS; }
			set { funzionalitaListDS = value; }
		}

		#endregion
		
		#region  Costruttori

		/// <summary>
		/// Costruttore standard
		/// </summary>
		public Funzionalita()
		{
			funzionalitaListDS = new DataSet();
		}
		#endregion

        #region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read()
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 FUNZIONALITA.FNT_ID_FUNZIONALITA, 
					 FUNZIONALITA.FUN_FNT_ID_FUNZIONALITA, 
					 FUNZIONALITA.fnt_acronimo_funzionalita, 
					 FUNZIONALITA.fnt_accesso_predefinito, 
					 FUNZIONALITA.fnt_descrizione_ita, 
					 FUNZIONALITA.fnt_livello, 
					 FUNZIONALITA.fnt_posizione, 
					 FUNZIONALITA.fnt_pagina_asp, 
					 FUNZIONALITA.fnt_parametri, 
					 FUNZIONALITA.fnt_flag_foglia, 
					 FUNZIONALITA.fnt_flag_visibilita_menu, 
					 FUNZIONALITA.fnt_flag_apri_nuova, 
					 FUNZIONALITA.fnt_descrizione_eng, 
					 FUNZIONALITA.fnt_data_creazione, 
					 FUNZIONALITA.fnt_data_aggiornamento, 
					 FUNZIONALITA.fnt_creato_da, 
					 FUNZIONALITA.fnt_aggiornato_da,
                     FUNZIONALITA.fnt_flag_figura,
                     FUNZIONALITA.fnt_flag_eliminato,
                     FUNZIONALITA.fnt_icona_menu,
                     FUNZIONALITA.fnt_chiave_dizionario
				 	 FROM FUNZIONALITA WHERE 
					 (FNT_ID_FUNZIONALITA =@fnt_id_funzionalita) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					fnt_id_funzionalita = reader.GetSqlInt32(0);
					fun_fnt_id_funzionalita = reader.GetSqlInt32(1);
					fnt_acronimo_funzionalita = reader.GetSqlString(2);
					fnt_accesso_predefinito = reader.GetSqlInt32(3);
					fnt_descrizione_ita = reader.GetSqlString(4);
					fnt_livello = reader.GetSqlInt32(5);
					fnt_posizione = reader.GetSqlInt32(6);
					fnt_pagina_asp = reader.GetSqlString(7);
					fnt_parametri = reader.GetSqlInt32(8);
					fnt_flag_foglia = reader.GetSqlBoolean(9);
					fnt_flag_visibilita_menu = reader.GetSqlBoolean(10);
					fnt_flag_apri_nuova = reader.GetSqlBoolean(11);
					fnt_descrizione_eng = reader.GetSqlString(12);
					fnt_data_creazione = reader.GetSqlDateTime(13);
					fnt_data_aggiornamento = reader.GetSqlDateTime(14);
					fnt_creato_da = reader.GetSqlInt32(15);
					fnt_aggiornato_da = reader.GetSqlInt32(16);
                    fnt_flag_figura = reader.GetSqlInt32(17);
                    fnt_flag_eliminato = reader.GetSqlInt32(18);
                    fnt_icona_menu =reader.GetSqlString(19);
                    fnt_chiave_dizionario = reader.GetSqlString(20);


                }	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "Funzionalita.Read.");
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
		/// Aggiorna l'ggetto nella base dati
		/// </summary>	
		public void Update()
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE FUNZIONALITA SET 
					 FUN_FNT_ID_FUNZIONALITA = @fun_fnt_id_funzionalita, 
					 fnt_acronimo_funzionalita = @fnt_acronimo_funzionalita, 
					 fnt_accesso_predefinito = @fnt_accesso_predefinito, 
					 fnt_descrizione_ita = @fnt_descrizione_ita, 
					 fnt_livello = @fnt_livello, 
					 fnt_posizione = @fnt_posizione, 
					 fnt_pagina_asp = @fnt_pagina_asp, 
					 fnt_parametri = @fnt_parametri, 
					 fnt_flag_foglia = @fnt_flag_foglia, 
					 fnt_flag_visibilita_menu = @fnt_flag_visibilita_menu, 
					 fnt_flag_apri_nuova = @fnt_flag_apri_nuova, 
					 fnt_descrizione_eng = @fnt_descrizione_eng, 
					 fnt_data_creazione = @fnt_data_creazione, 
					 fnt_data_aggiornamento = @fnt_data_aggiornamento, 
					 fnt_creato_da = @fnt_creato_da, 
					 fnt_aggiornato_da = @fnt_aggiornato_da,
                     fnt_flag_figura = @fnt_flag_figura,
                     fnt_flag_eliminato = @fnt_flag_eliminato,
                     fnt_icona_menu=@fnt_icona_menu,
                     fnt_chiave_dizionario=@fnt_chiave_dizionario
					 WHERE   
				     (FNT_ID_FUNZIONALITA =@fnt_id_funzionalita) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "fun_fnt_id_funzionalita", DbType.Int32, fun_fnt_id_funzionalita);
				db.AddInParameter(dbCommand, "fnt_acronimo_funzionalita", DbType.String, fnt_acronimo_funzionalita);
				db.AddInParameter(dbCommand, "fnt_accesso_predefinito", DbType.Int32, fnt_accesso_predefinito);
				db.AddInParameter(dbCommand, "fnt_descrizione_ita", DbType.String, fnt_descrizione_ita);
				db.AddInParameter(dbCommand, "fnt_livello", DbType.Int32, fnt_livello);
				db.AddInParameter(dbCommand, "fnt_posizione", DbType.Int32, fnt_posizione);
				db.AddInParameter(dbCommand, "fnt_pagina_asp", DbType.String, fnt_pagina_asp);
				db.AddInParameter(dbCommand, "fnt_parametri", DbType.Int32, fnt_parametri);
				db.AddInParameter(dbCommand, "fnt_flag_foglia", DbType.Boolean, fnt_flag_foglia);
				db.AddInParameter(dbCommand, "fnt_flag_visibilita_menu", DbType.Boolean, fnt_flag_visibilita_menu);
				db.AddInParameter(dbCommand, "fnt_flag_apri_nuova", DbType.Boolean, fnt_flag_apri_nuova);
				db.AddInParameter(dbCommand, "fnt_descrizione_eng", DbType.String, fnt_descrizione_eng);
				db.AddInParameter(dbCommand, "fnt_data_creazione", DbType.DateTime, fnt_data_creazione);
				db.AddInParameter(dbCommand, "fnt_data_aggiornamento", DbType.DateTime, fnt_data_aggiornamento);
				db.AddInParameter(dbCommand, "fnt_creato_da", DbType.Int32, fnt_creato_da);
				db.AddInParameter(dbCommand, "fnt_aggiornato_da", DbType.Int32, fnt_aggiornato_da);
                db.AddInParameter(dbCommand, "fnt_flag_figura", DbType.Int32, fnt_flag_figura);
                db.AddInParameter(dbCommand, "fnt_flag_eliminato", DbType.Int32, fnt_flag_eliminato); 
                db.AddInParameter(dbCommand, "fnt_icona_menu", DbType.String, fnt_icona_menu);
                db.AddInParameter(dbCommand, "fnt_chiave_dizionario", DbType.String, fnt_chiave_dizionario); 



                db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Funzionalita.Update.");
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
            DbCommand dbCommand = null;

            try
            {
                this.Read();
                aggPosizione((int)this.fnt_posizione, -1);

                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                //Prima si elimina dai Permessi di Accesso
		        string sqlCommand = @" UPDATE FUNZIONALITA 
                                       SET fnt_flag_eliminato=1
                                       WHERE (FNT_ID_FUNZIONALITA = @fnt_id_funzionalita); 
                                    
                                        DELETE FROM PERMESSO_ACCESSO 
                                        WHERE (FNT_ID_FUNZIONALITA = @fnt_id_funzionalita) " + " ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);

                db.ExecuteNonQuery(dbCommand);


                //Ora posso eliminare la Funzionalita                
                //sqlCommand = " DELETE FROM FUNZIONALITA WHERE " +
                //    "(FNT_ID_FUNZIONALITA = @fnt_id_funzionalita) " + " ";
                //dbCommand = db.GetSqlStringCommand(sqlCommand);

                //db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);

                //db.ExecuteNonQuery(dbCommand);
            }
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Funzionalita.Delete.");
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
            SqlDataReader reader = null;

            //Funzionalita objFnt = new Funzionalita();
            //objFnt.Fnt_id_funzionalita = this.Fnt_id_funzionalita;
            //objFnt.Read();
            //aggPosizione(-1, (int)objFnt.Fnt_posizione);

            try
            {
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
	
				sqlCommand = @" INSERT INTO FUNZIONALITA (
						FUN_FNT_ID_FUNZIONALITA, 
						fnt_acronimo_funzionalita, 
						fnt_accesso_predefinito, 
						fnt_descrizione_ita, 
						fnt_livello, 
						fnt_posizione, 
						fnt_pagina_asp, 
						fnt_parametri, 
						fnt_flag_foglia, 
						fnt_flag_visibilita_menu, 
						fnt_flag_apri_nuova, 
						fnt_descrizione_eng, 
						fnt_data_creazione, 
						fnt_data_aggiornamento, 
						fnt_creato_da, 
						fnt_aggiornato_da,
                        fnt_flag_figura,
                        fnt_icona_menu,
                        fnt_chiave_dizionario) 
					VALUES ( 
						@fun_fnt_id_funzionalita, 
						@fnt_acronimo_funzionalita, 
						@fnt_accesso_predefinito, 
						@fnt_descrizione_ita, 
						@fnt_livello, 
						@fnt_posizione, 
						@fnt_pagina_asp, 
						@fnt_parametri, 
						@fnt_flag_foglia, 
						@fnt_flag_visibilita_menu, 
						@fnt_flag_apri_nuova, 
						@fnt_descrizione_eng, 
						@fnt_data_creazione, 
						@fnt_data_aggiornamento, 
						@fnt_creato_da, 
						@fnt_aggiornato_da,
                        @fnt_flag_figura,
                        @fnt_icona_menu,
                        @fnt_chiave_dizionario) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "fun_fnt_id_funzionalita", DbType.Int32, fun_fnt_id_funzionalita);
				db.AddInParameter(dbCommand, "fnt_acronimo_funzionalita", DbType.String, fnt_acronimo_funzionalita);
				db.AddInParameter(dbCommand, "fnt_accesso_predefinito", DbType.Int32, fnt_accesso_predefinito);
				db.AddInParameter(dbCommand, "fnt_descrizione_ita", DbType.String, fnt_descrizione_ita);
				db.AddInParameter(dbCommand, "fnt_livello", DbType.Int32, fnt_livello);
				db.AddInParameter(dbCommand, "fnt_posizione", DbType.Int32, fnt_posizione);
				db.AddInParameter(dbCommand, "fnt_pagina_asp", DbType.String, fnt_pagina_asp);
				db.AddInParameter(dbCommand, "fnt_parametri", DbType.Int32, fnt_parametri);
				db.AddInParameter(dbCommand, "fnt_flag_foglia", DbType.Boolean, fnt_flag_foglia);
				db.AddInParameter(dbCommand, "fnt_flag_visibilita_menu", DbType.Boolean, fnt_flag_visibilita_menu);
				db.AddInParameter(dbCommand, "fnt_flag_apri_nuova", DbType.Boolean, fnt_flag_apri_nuova);
				db.AddInParameter(dbCommand, "fnt_descrizione_eng", DbType.String, fnt_descrizione_eng);
				db.AddInParameter(dbCommand, "fnt_data_creazione", DbType.DateTime, fnt_data_creazione);
				db.AddInParameter(dbCommand, "fnt_data_aggiornamento", DbType.DateTime, fnt_data_aggiornamento);
				db.AddInParameter(dbCommand, "fnt_creato_da", DbType.Int32, fnt_creato_da);
				db.AddInParameter(dbCommand, "fnt_aggiornato_da", DbType.Int32, fnt_aggiornato_da);
                db.AddInParameter(dbCommand, "fnt_flag_figura", DbType.Int32, fnt_flag_figura);
                db.AddInParameter(dbCommand, "fnt_icona_menu", DbType.String, fnt_icona_menu);
                db.AddInParameter(dbCommand, "fnt_chiave_dizionario", DbType.String, fnt_chiave_dizionario); 

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
                    fnt_id_funzionalita = Convert.ToInt32(reader[0]);
                }

                //la Funzionalit‡ appena inserita va messa anche nei Permessi di Accesso
                //Per tutti i Ruoli si mette la Funzionalit‡ con il suo Permesso di Accesso predefinito
                sqlCommand = @"";
                sqlCommand += @"INSERT INTO PERMESSO_ACCESSO ( 
                            FNT_ID_FUNZIONALITA, 
                            PMS_ID_MODALITA_ACCESSO, 
                            RUL_ID_RUOLO) 
                            SELECT 
                            FUNZIONALITA.FNT_ID_FUNZIONALITA, 
                            FUNZIONALITA.FNT_ACCESSO_PREDEFINITO, 
                            RUOLI.RUL_ID_RUOLO 
                            FROM FUNZIONALITA, RUOLI 
                            WHERE FNT_ID_FUNZIONALITA NOT IN 
                            (SELECT FNT_ID_FUNZIONALITA FROM PERMESSO_ACCESSO) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.ExecuteNonQuery(dbCommand);

                //Il Ruolo Administrator deve avere sempre per esso DELETE
                sqlCommand = @"";
                sqlCommand += @"UPDATE PERMESSO_ACCESSO 
                            SET PMS_ID_MODALITA_ACCESSO = 
                            (SELECT MAX(PMS_ID_MODALITA_ACCESSO) FROM PERMESSI_LOOKUP) 
                            WHERE RUL_ID_RUOLO = 1 AND FNT_ID_FUNZIONALITA=" + fnt_id_funzionalita.Value;

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

        }

		/// <summary>
        /// Elenca tutti gli elementi Piano_di_mitigazione dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List( "it", string.Empty, "FUNZIONALITA");
        }
        /// <summary>
        /// Elenca tutti gli elementi Funzionalita dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet List(string qCultureInfoName)
        {
            return List(qCultureInfoName, string.Empty, "FUNZIONALITA");
        }       
        /// <summary>
		/// Elenca tutti gli elementi Funzionalita dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string qCultureInfoName, string sqlWhereClause) 
		{
            return List(qCultureInfoName, sqlWhereClause, "FUNZIONALITA");
		}
		/// <summary>
		/// Elenca tutti gli elementi Funzionalita dell'analisi. L'utente pu√≤ scegliere il nome della tabella nel dataset
		/// </summary>
		public static DataSet List(string qCultureInfoName, string sqlWhereClause, string tableName) 
		{
			string sqlCommand = null;
			StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
            DataSet ds = new DataSet();
			
			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            
				sb.Append(@" SELECT 
					FUNZIONALITA.FNT_ID_FUNZIONALITA, 
					FUNZIONALITA.FUN_FNT_ID_FUNZIONALITA, 
					FUNZIONALITA.fnt_acronimo_funzionalita, 
					FUNZIONALITA.fnt_accesso_predefinito, ");
                
                switch (qCultureInfoName)
                {
                    case "it":
                        sb.Append(@"FNT_DESCRIZIONE_ITA AS FNT_DESCRIZIONE, ");
                        break;
                    case "en":
                        sb.Append(@"FNT_DESCRIZIONE_ENG AS FNT_DESCRIZIONE, ");
                        break;
                    default:
                        sb.Append(@"FNT_DESCRIZIONE_ITA AS FNT_DESCRIZIONE, ");
                       break;
                }

				sb.Append(@"FUNZIONALITA.fnt_livello, 
					FUNZIONALITA.fnt_posizione, 
					FUNZIONALITA.fnt_pagina_asp, 
					FUNZIONALITA.fnt_parametri, 
					FUNZIONALITA.fnt_flag_foglia, 
					FUNZIONALITA.fnt_flag_visibilita_menu, 
					FUNZIONALITA.fnt_flag_apri_nuova, 
					FUNZIONALITA.fnt_descrizione_eng, 
					FUNZIONALITA.fnt_data_creazione, 
					FUNZIONALITA.fnt_data_aggiornamento, 
					FUNZIONALITA.fnt_creato_da, 
					FUNZIONALITA.fnt_aggiornato_da,
                    FUNZIONALITA.fnt_flag_figura,
                    FUNZIONALITA.fnt_icona_menu,
                    FUNZIONALITA.fnt_chiave_dizionario,
                    CASE WHEN FUNZIONALITA.FUN_FNT_ID_FUNZIONALITA>1 THEN ");

                switch (qCultureInfoName)
                {
                    case "it":
                        sb.Append(@"(SELECT FNT_DESCRIZIONE_ITA AS FNT_DESCRIZIONE ");
                        break;
                    case "en":
                        sb.Append(@"(SELECT FNT_DESCRIZIONE_ENG AS FNT_DESCRIZIONE ");
                        break;
                    default:
                        sb.Append(@"(SELECT FNT_DESCRIZIONE_ITA AS FNT_DESCRIZIONE ");
                        break;
                }
                sb.Append(@" FROM FUNZIONALITA FUN_PADRE WHERE FUN_PADRE.FNT_ID_FUNZIONALITA=FUNZIONALITA.FUN_FNT_ID_FUNZIONALITA)
                        ELSE '' 
                    END AS FUNZIONALITA_PADRE 
                FROM FUNZIONALITA ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

                //sb.Append(" ORDER BY FNT_DESCRIZIONE ASC ");
				
				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, "FUNZIONALITA");
            }

			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Funzionalita.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
        }

        public DataSet GetDsFunzionalita(string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					FNT_ID_FUNZIONALITA, 
					FNT_DESCRIZIONE_ITA 
				    FROM FUNZIONALITA ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }
                
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, tableName);                
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Funzionalita.GetDsFunzionalita.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }


        /// <summary>
        /// Elenca tutti gli elementi Funzionalita dell'analisi. L'utente puÚ scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet GetDdlFunzionalita(string qCultureInfoName, string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					FNT_ID_FUNZIONALITA, ");

                switch (qCultureInfoName)
                {
                    case "it":
                        sb.Append(@"FNT_DESCRIZIONE_ITA AS FNT_DESCRIZIONE ");
                        break;
                    case "en":
                        sb.Append(@"FNT_DESCRIZIONE_ENG AS FNT_DESCRIZIONE ");
                        break;
                    default:
                        sb.Append(@"FNT_DESCRIZIONE_ITA AS FNT_DESCRIZIONE ");
                        break;
                }

                sb.Append(@"FROM FUNZIONALITA WHERE FNT_FLAG_ELIMINATO = 0
                     ");

                sb.Append(sqlWhereClause);
                sb.Append(" ORDER BY FNT_DESCRIZIONE");

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, tableName);
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Centri_di_costo.GetDdlCentroDiCosto.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }


        /// <summary>
        /// Elenca tutti gli elementi Funzionalita in funzione del livello
        /// </summary>
        public DataSet ListByLevel(int Fun_fnt_id_funzionalita, int theLevel, string qCultureInfoName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                string sqlCommand = " SELECT " +
                        "FNT_ID_FUNZIONALITA, ";
                switch (qCultureInfoName)
                {
                    case "it":
                        sqlCommand += "FNT_DESCRIZIONE_ITA AS FNT_DESCRIZIONE ";
                        break;
                    case "en":
                        sqlCommand += "FNT_DESCRIZIONE_ENG AS FNT_DESCRIZIONE ";
                        break;
                    default:
                        sqlCommand += "FNT_DESCRIZIONE_ITA AS FNT_DESCRIZIONE ";
                        break;
                }

                sqlCommand += "FROM FUNZIONALITA WHERE FNT_LIVELLO = @theLevel ";
                sqlCommand += " AND FUN_FNT_ID_FUNZIONALITA = @Fun_fnt_id_funzionalita ";
                sqlCommand += " ORDER BY FNT_POSIZIONE ASC ";

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "theLevel", DbType.String, theLevel);
                db.AddInParameter(dbCommand, "Fun_fnt_id_funzionalita", DbType.String, Fun_fnt_id_funzionalita);

                db.LoadDataSet(dbCommand, funzionalitaListDS, "FUNZIONALITA");
                return funzionalitaListDS;
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (funzionalitaListDS != null)
                    ((IDisposable)funzionalitaListDS).Dispose();
            }
        }

        public IDataReader ListMenu(string nodeValue)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                string sqlCommand = "SELECT * FROM FUNZIONALITA WHERE FUN_FNT_ID_FUNZIONALITA=" +
                                nodeValue + " AND FNT_ID_FUNZIONALITA<>" + nodeValue + " ";
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                return db.ExecuteReader(dbCommand);
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }
        }

        /// <summary>
        /// Elenca tutti gli elementi Funzionalita di un dato ruolo
        /// </summary>
        /// <param name="myParRulIdRuolo"></param>
        /// <param name="qCultureInfoName"></param>
        /// <returns></returns>
        public DataSet ListFunzionalitaByRuolo(int myParRulIdRuolo, string qCultureInfoName)
        {
            try
            {
                if (myParRulIdRuolo == SqlInt32.Null)
                {
                    myParRulIdRuolo = 0;
                }

                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                string sqlCommand = @" SELECT
                                        FUNZIONALITA.FNT_ID_FUNZIONALITA, 
                                        FUNZIONALITA.FNT_ACRONIMO_FUNZIONALITA, 
                                        PERMESSI_LOOKUP.PMS_ID_MODALITA_ACCESSO, 
                                        PERMESSI_LOOKUP.PMS_DESCRIZIONE, 
                                        PERMESSO_ACCESSO.RUL_ID_RUOLO, ";

                switch (qCultureInfoName)
                {
                    case "it":
                        sqlCommand += "FUNZIONALITA.FNT_DESCRIZIONE_ITA AS FNT_DESCRIZIONE ";
                        break;
                    case "en":
                        sqlCommand += "FUNZIONALITA.FNT_DESCRIZIONE_ENG AS FNT_DESCRIZIONE ";
                        break;
                    default:
                        sqlCommand += "FUNZIONALITA.FNT_DESCRIZIONE_ITA AS FNT_DESCRIZIONE ";
                        break;
                }

                if (myParRulIdRuolo != 0)
                {
                    sqlCommand += @"FROM FUNZIONALITA 
                                    LEFT JOIN PERMESSO_ACCESSO ON PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA = FUNZIONALITA.FNT_ID_FUNZIONALITA 
                                    AND PERMESSO_ACCESSO.RUL_ID_RUOLO = " + myParRulIdRuolo + @" 
                                    LEFT JOIN PERMESSI_LOOKUP ON PERMESSO_ACCESSO.PMS_ID_MODALITA_ACCESSO = PERMESSI_LOOKUP.PMS_ID_MODALITA_ACCESSO 
                                    WHERE fnt_flag_eliminato = 0 ";
                }
                else
                {
                    sqlCommand += "FROM FUNZIONALITA " +
                    "LEFT JOIN PERMESSO_ACCESSO ON PERMESSO_ACCESSO.FNT_ID_FUNZIONALITA = FUNZIONALITA.FNT_ID_FUNZIONALITA " +
                    "LEFT JOIN PERMESSI_LOOKUP ON PERMESSO_ACCESSO.PMS_ID_MODALITA_ACCESSO = PERMESSI_LOOKUP.PMS_ID_MODALITA_ACCESSO " +
                    "WHERE PERMESSO_ACCESSO.RUL_ID_RUOLO = " + myParRulIdRuolo + " " ;
                }

                sqlCommand += " ORDER BY FNT_ACRONIMO_FUNZIONALITA ASC ";

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "myParRulIdRuolo", DbType.Int32, myParRulIdRuolo);

                db.LoadDataSet(dbCommand, funzionalitaListDS, "FNT_ID_FUNZIONALITA");
                return funzionalitaListDS;
            }

            catch (Exception ex)
            {
                // E' successo qualcosa di strano
                throw ex;
            }

            finally
            {
                if (funzionalitaListDS != null)
                    ((IDisposable)funzionalitaListDS).Dispose();
            }
        }

        /// <summary>
        /// Aggiorna il livello dei nodi figli in relazione dello spostamento del nodo padre
        /// deltaLevel Ë l'incremento o il decremento del livello del padre in funzione della sua posizione originaria
        /// </summary>
        public void aggFigli(int deltaLevel)
        {

            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE FUNZIONALITA
                                SET FNT_LIVELLO = FNT_LIVELLO + @inc_level
                                FROM FUNZIONALITA
                                WHERE FNT_ID_FUNZIONALITA IN
                                    (SELECT DISTINCT FNT_ID_FUNZIONALITA
                                    FROM FUNZIONALITA
                                    WHERE FUN_FNT_ID_FUNZIONALITA = @fnt_id_funzionalita)
                                OR FUN_FNT_ID_FUNZIONALITA IN
                                    (SELECT DISTINCT FNT_ID_FUNZIONALITA
                                     FROM FUNZIONALITA
                                    WHERE FUN_FNT_ID_FUNZIONALITA = @fnt_id_funzionalita)
        				    ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "inc_level", DbType.Int32, deltaLevel);
                db.AddInParameter(dbCommand, "fnt_id_funzionalita", DbType.Int32, fnt_id_funzionalita);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Funzionalita.aggFigli.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Aggiorna la posizione dei nodi successivi al nodo che si sta gestendo
        /// oldPosition Ë la posizione di partenza del nodo che si sta gestendo ( =-1 in modalita INS)
        /// newPosition Ë la posizione di arrivo del nodo che si sta gestendo ( =-1 in modalita DEL)
        /// </summary>
        public void aggPosizione(int oldPosition, int newPosition)
        {

            string sqlCommand = null;
            DbCommand dbCommand = null;

            if (oldPosition == -1 && newPosition != -1)
            {
                try
                {
                    Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                    sqlCommand = @" UPDATE FUNZIONALITA
                                    SET FNT_POSIZIONE = FNT_POSIZIONE + 1
                                    FROM FUNZIONALITA
                                    WHERE FNT_POSIZIONE > @thePosition
    				            ";

                    dbCommand = db.GetSqlStringCommand(sqlCommand);

                    db.AddInParameter(dbCommand, "thePosition", DbType.Int32, newPosition);

                    db.ExecuteNonQuery(dbCommand);

                }
                catch (Exception ex)
                {
                    ex.Data.Add("Class.Method", "Funzionalita.aggPosizione.");
                    ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                }
            }

            if (newPosition == -1 && oldPosition != -1)
            {
                try
                {
                    Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                    sqlCommand = @" UPDATE FUNZIONALITA
                                    SET FNT_POSIZIONE = FNT_POSIZIONE - 1
                                    FROM FUNZIONALITA
                                    WHERE FNT_POSIZIONE > @thePosition
    				            ";

                    dbCommand = db.GetSqlStringCommand(sqlCommand);

                    db.AddInParameter(dbCommand, "thePosition", DbType.Int32, oldPosition);

                    db.ExecuteNonQuery(dbCommand);

                }
                catch (Exception ex)
                {
                    ex.Data.Add("Class.Method", "Funzionalita.aggPosizione.");
                    ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                }
            }

            // Se oldPosition > newPosition (sposto su)
            // sui nodi con posizione > oldPosition                 --> sottraggo 1
            // sui nodi con posizione > newPosition e < oldPosition --> sommo 1
            if (oldPosition != -1 && newPosition != -1 && oldPosition > newPosition)
            {
                try
                {
                    Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                    sqlCommand = @" UPDATE FUNZIONALITA
                                    SET FNT_POSIZIONE = FNT_POSIZIONE - 1
                                    FROM FUNZIONALITA
                                    WHERE FNT_POSIZIONE > @oldPosition
    				            ";

                    dbCommand = db.GetSqlStringCommand(sqlCommand);

                    db.AddInParameter(dbCommand, "oldPosition", DbType.Int32, oldPosition);

                    db.ExecuteNonQuery(dbCommand);

                }
                catch (Exception ex)
                {
                    ex.Data.Add("Class.Method", "Funzionalita.aggPosizione.");
                    ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                }

                try
                {
                    Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                    sqlCommand = @" UPDATE FUNZIONALITA
                                    SET FNT_POSIZIONE = FNT_POSIZIONE + 1
                                    FROM FUNZIONALITA
                                    WHERE FNT_POSIZIONE BETWEEN @newPosition AND @oldPosition
    				            ";

                    dbCommand = db.GetSqlStringCommand(sqlCommand);

                    db.AddInParameter(dbCommand, "oldPosition", DbType.Int32, oldPosition);
                    db.AddInParameter(dbCommand, "newPosition", DbType.Int32, newPosition);

                    db.ExecuteNonQuery(dbCommand);

                }
                catch (Exception ex)
                {
                    ex.Data.Add("Class.Method", "Funzionalita.aggPosizione.");
                    ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                }
            }


            // Se oldPosition < newPosition (sposto gi˘)
            // sui nodi con posizione > newPosition                 --> sommo 1
            // sui nodi con posizione > oldPosition e < newPosition --> sottraggo 1
            if (oldPosition != -1 && newPosition != -1 && oldPosition < newPosition)
            {
                try
                {
                    Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                    sqlCommand = @" UPDATE FUNZIONALITA
                                    SET FNT_POSIZIONE = FNT_POSIZIONE + 1
                                    FROM FUNZIONALITA
                                    WHERE FNT_POSIZIONE > @newPosition
    				            ";

                    dbCommand = db.GetSqlStringCommand(sqlCommand);

                    db.AddInParameter(dbCommand, "newPosition", DbType.Int32, newPosition);

                    db.ExecuteNonQuery(dbCommand);

                }
                catch (Exception ex)
                {
                    ex.Data.Add("Class.Method", "Funzionalita.aggPosizione.");
                    ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                }

                try
                {
                    Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                    sqlCommand = @" UPDATE FUNZIONALITA
                                    SET FNT_POSIZIONE = FNT_POSIZIONE - 1
                                    FROM FUNZIONALITA
                                    WHERE FNT_POSIZIONE BETWEEN @oldPosition AND @newPosition
    				            ";

                    dbCommand = db.GetSqlStringCommand(sqlCommand);

                    db.AddInParameter(dbCommand, "oldPosition", DbType.Int32, oldPosition);
                    db.AddInParameter(dbCommand, "newPosition", DbType.Int32, newPosition);

                    db.ExecuteNonQuery(dbCommand);

                }
                catch (Exception ex)
                {
                    ex.Data.Add("Class.Method", "Funzionalita.aggPosizione.");
                    ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                    // Gestione messaggistica all'utente e trace in DB dell'errore
                    ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
                }

            }
        }

        /// <summary>
        /// Riaggiusta la posizione dei nodi dell'albero
        /// </summary>
        public void treeReorder()
        {
            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                sqlCommand = "sp_TreeReorder";
                dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Funzionalita.treeReorder.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }



        #endregion

    }
}


