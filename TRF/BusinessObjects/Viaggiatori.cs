#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   Viaggiatori.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per VIAGGIATORI
//
// Autore:      AR - SDG srl
// Data:        07/09/2009
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
	/// Tabella VIAGGIATORI 
	/// </summary>
	public class Viaggiatori
	{
		#region attributi e variabili

	    private SqlInt32 via_id_viaggiatore = SqlInt32.Null;
	    private SqlInt32 riv_id_richiesta = SqlInt32.Null;
	    private SqlInt32 ute_id_utente = SqlInt32.Null;
	    private SqlInt32 cat_id_categoria = SqlInt32.Null;
	    private SqlInt32 uco_id_unita = SqlInt32.Null;
        private SqlInt32 cdc_id_centro_di_costo = SqlInt32.Null;
	    private SqlInt32 rep_id_reparto = SqlInt32.Null;
	    private SqlString via_pa = SqlString.Null;
	    private SqlString via_cognome = SqlString.Null;
	    private SqlString via_nome = SqlString.Null;
	    private SqlString via_telefono = SqlString.Null;
	    private SqlString via_email = SqlString.Null;	    
	    private SqlDateTime via_data_creazione = SqlDateTime.Null;
	    private SqlDateTime via_data_aggiornamento = SqlDateTime.Null;
	    private SqlInt32 ute_creato_da = SqlInt32.Null;
	    private SqlInt32 ute_aggiornato_da = SqlInt32.Null;
        private SqlString via_codice_individuale = SqlString.Null;
        private SqlString via_cdc_addebito = SqlString.Null;
        private SqlString via_istituto = SqlString.Null;
        private SqlString via_cellulare = SqlString.Null;
        private SqlString via_fax = SqlString.Null;

        private SqlInt32 via_flag_iscrizione = SqlInt32.Null;
        private SqlDecimal via_importo_iscrizione = SqlDecimal.Null;
        private SqlString via_descrizione_costi_extra = SqlString.Null;
        private SqlDecimal via_importo_costi_extra = SqlDecimal.Null;
        private SqlInt32 via_flag_errore = SqlInt32.Null;

        //Campi relativi al modulo eventi.
        private SqlString via_azienda = SqlString.Null;
        private SqlString via_provenienza = SqlString.Null;        
        private SqlString via_nro_documento = SqlString.Null;
        private SqlDateTime via_data_nascita = SqlDateTime.Null;
        private SqlInt32 lmt_id_mezzo_trasporto = SqlInt32.Null;
        private SqlInt32 ltt_id_titolo = SqlInt32.Null;
        private SqlInt32 lrt_id_room_type = SqlInt32.Null;
        private SqlInt32 ltd_id_documento = SqlInt32.Null;
        private SqlString via_note_particolari = SqlString.Null;
        private SqlString via_aeroporto_partenza = SqlString.Null;
        private SqlString via_avvicinamento_citta = SqlString.Null;
        private SqlInt32 via_flag_cena = SqlInt32.Null;
        private SqlDateTime via_data_in = SqlDateTime.Null;
        private SqlDateTime via_data_out = SqlDateTime.Null;        
		private SqlString ute_matricola = SqlString.Null;
        private SqlString ute_user_id = SqlString.Null;

		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Via_id_viaggiatore
		{
			get { return via_id_viaggiatore; }	
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
        public SqlInt32 Ute_id_utente
		{
			get { return ute_id_utente; }
            set { ute_id_utente = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lmt_id_mezzo_trasporto
        {
            get { return lmt_id_mezzo_trasporto; }
            set { lmt_id_mezzo_trasporto = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Ltt_id_titolo
        {
            get { return ltt_id_titolo; }
            set { ltt_id_titolo = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Lrt_id_room_type
        {
            get { return lrt_id_room_type; }
            set { lrt_id_room_type = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Ltd_id_documento
        {
            get { return ltd_id_documento; }
            set { ltd_id_documento = value; }
        }

        public SqlString Via_azienda
        {
            get { return via_azienda; }
            set { via_azienda = value; }
        }

        public SqlString Via_provenienza
        {
            get { return via_provenienza; }
            set { via_provenienza = value; }
        }

        public SqlString Via_nro_documento
        {
            get { return via_nro_documento; }
            set { via_nro_documento = value; }
        }

        public SqlString Via_note_particolari
        {
            get { return via_note_particolari; }
            set { via_note_particolari = value; }
        }

        public SqlString Via_aeroporto_partenza
        {
            get { return via_aeroporto_partenza; }
            set { via_aeroporto_partenza = value; }
        }

        public SqlString Via_avvicinamento_citta
        {
            get { return via_avvicinamento_citta; }
            set { via_avvicinamento_citta = value; }
        }

        public SqlDateTime Via_data_in
        {
            get { return via_data_in; }
            set { via_data_in = value; }
        }

        public SqlDateTime Via_data_out
        {
            get { return via_data_out; }
            set { via_data_out = value; }
        }

        public SqlInt32 Via_flag_cena
        {
            get { return via_flag_cena; }
            set { via_flag_cena = value; }
        }

        public SqlDateTime Via_data_nascita
        {
            get { return via_data_nascita; }
            set { via_data_nascita = value; }
        }
		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cat_id_categoria
		{
			get { return cat_id_categoria; }	
			set { cat_id_categoria = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Uco_id_unita
		{
			get { return uco_id_unita; }	
			set { uco_id_unita = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Rep_id_reparto
		{
			get { return rep_id_reparto; }	
			set { rep_id_reparto = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cdc_id_centro_di_costo
        {
            get { return cdc_id_centro_di_costo; }
            set { cdc_id_centro_di_costo = value; }
        }

		/// <value>
		/// Numero univoco che identifica il dipendente all'interno del gruppo.
		/// </value>
		public SqlString Via_pa
		{
			get { return via_pa; }	
			set { via_pa = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Via_cognome
		{
			get { return via_cognome; }	
			set { via_cognome = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Via_nome
		{
			get { return via_nome; }	
			set { via_nome = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlString Via_istituto
        {
            get { return via_istituto; }
            set { via_istituto = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Via_cellulare
        {
            get { return via_cellulare; }
            set { via_cellulare = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Via_fax
        {
            get { return via_fax; }
            set { via_fax = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Via_flag_iscrizione
        {
            get { return via_flag_iscrizione; }
            set { via_flag_iscrizione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Via_flag_errore
        {
            get { return via_flag_errore; }
            set { via_flag_errore = value; }
        }


        /// <value>
        /// 
        /// </value>
        public SqlDecimal Via_importo_iscrizione
        {
            get { return via_importo_iscrizione; }
            set { via_importo_iscrizione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Via_descrizione_costi_extra
        {
            get { return via_descrizione_costi_extra; }
            set { via_descrizione_costi_extra = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlDecimal Via_importo_costi_extra
        {
            get { return via_importo_costi_extra; }
            set { via_importo_costi_extra = value; }
        }

		/// <value>
		/// 
		/// </value>
		public SqlString Via_telefono
		{
			get { return via_telefono; }	
			set { via_telefono = value; }
		}

		/// <value>
		/// di degault i titoli sono inviati a questa email
		/// </value>
		public SqlString Via_email
		{
			get { return via_email; }	
			set { via_email = value; }
		}
		

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Via_data_creazione
		{
			get { return via_data_creazione; }	
			set { via_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Via_data_aggiornamento
		{
			get { return via_data_aggiornamento; }	
			set { via_data_aggiornamento = value; }
		}


        /// <value>
        /// 
        /// </value>
        public SqlString Via_codice_individuale
        {
            get { return via_codice_individuale; }
            set { via_codice_individuale = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Via_cdc_addebito
        {
            get { return via_cdc_addebito; }
            set { via_cdc_addebito = value; }
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
        /// 
        /// </value>
        public SqlString Ute_matricola
        {
            get { return ute_matricola; }
            set { ute_matricola = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Ute_user_id
        {
            get { return ute_user_id; }
            set { ute_user_id = value; }
        }

		/// <value>
		/// Where Clause condition
		/// </value>
		public string SqlWhereClause
		{
			get { return  sqlWhereClause; }
			set { sqlWhereClause = value; }
		}
		#endregion
		
		#region Costruttori

		/// <summary>
		/// Costruttore standard
		/// </summary>
		public Viaggiatori()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_via_id_viaggiatore)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 VIAGGIATORI.via_id_viaggiatore, 
					 VIAGGIATORI.riv_id_richiesta, 
					 VIAGGIATORI.ute_id_utente, 
					 VIAGGIATORI.cat_id_categoria, 
					 VIAGGIATORI.uco_id_unita, 
					 VIAGGIATORI.rep_id_reparto, 
					 VIAGGIATORI.via_pa, 
					 VIAGGIATORI.via_cognome, 
					 VIAGGIATORI.via_nome, 
					 VIAGGIATORI.via_telefono, 
					 VIAGGIATORI.via_email, 
					 VIAGGIATORI.via_cdc_appartenenza, 
					 VIAGGIATORI.via_data_creazione, 
					 VIAGGIATORI.via_data_aggiornamento, 
					 VIAGGIATORI.ute_creato_da, 
					 VIAGGIATORI.ute_aggiornato_da,
                     VIAGGIATORI.cdc_id_centro_di_costo,
                     VIAGGIATORI.via_codice_individuale,
                     VIAGGIATORI.via_cdc_addebito,
	                 VIAGGIATORI.via_azienda,
                     VIAGGIATORI.via_provenienza,
                     VIAGGIATORI.lmt_id_mezzo_trasporto,
                     VIAGGIATORI.ltt_id_titolo,
                     VIAGGIATORI.lrt_id_room_type
				 	 FROM VIAGGIATORI WHERE 
					 (via_id_viaggiatore = @via_id_viaggiatore) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "via_id_viaggiatore", DbType.Int32, p_via_id_viaggiatore);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					via_id_viaggiatore = reader.GetSqlInt32(0);
					riv_id_richiesta = reader.GetSqlInt32(1);
                    ute_id_utente = reader.GetSqlInt32(2);
					cat_id_categoria = reader.GetSqlInt32(3);
					uco_id_unita = reader.GetSqlInt32(4);
					rep_id_reparto = reader.GetSqlInt32(5);
					via_pa = reader.GetSqlString(6);
					via_cognome = reader.GetSqlString(7);
					via_nome = reader.GetSqlString(8);
					via_telefono = reader.GetSqlString(9);
					via_email = reader.GetSqlString(10);					
					via_data_creazione = reader.GetSqlDateTime(11);
					via_data_aggiornamento = reader.GetSqlDateTime(12);
					ute_creato_da = reader.GetSqlInt32(13);
					ute_aggiornato_da = reader.GetSqlInt32(14);
                    cdc_id_centro_di_costo = reader.GetSqlInt32(15);
                    via_codice_individuale = reader.GetSqlString(16);
                    via_cdc_addebito = reader.GetSqlString(17);
                    via_azienda = reader.GetSqlString(18);
                    via_provenienza = reader.GetSqlString(19);
                    lmt_id_mezzo_trasporto = reader.GetSqlInt32(20);
                    ltt_id_titolo = reader.GetSqlInt32(21);
                    lrt_id_room_type = reader.GetSqlInt32(22);
				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "Viaggiatori.Read.");
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
		public void Update(SqlInt32 riv_id_richiesta)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE VIAGGIATORI SET					  
					 ute_id_utente = @ute_id_utente, 
					 via_cognome = @via_cognome, 
					 via_nome = @via_nome, 
					 via_telefono = @via_telefono, 
					 via_email = @via_email,                     
					 via_data_aggiornamento = getdate(), 
					 ute_aggiornato_da = @ute_aggiornato_da
                     WHERE (riv_id_richiesta = @riv_id_richiesta) "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "via_cognome", DbType.String, via_cognome);
				db.AddInParameter(dbCommand, "via_nome", DbType.String, via_nome);
				db.AddInParameter(dbCommand, "via_telefono", DbType.String, via_telefono);
				db.AddInParameter(dbCommand, "via_email", DbType.String, via_email);
                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, cdc_id_centro_di_costo);
				db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);										
				db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);                
				db.ExecuteNonQuery(dbCommand);
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Viaggiatori.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void UpdateDatiFromWs(SqlInt32 riv_id_richiesta, DbTransaction t)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE VIAGGIATORI SET					  					 
					             via_pa = @via_pa, 
					             via_cognome = @via_cognome, 
					             via_nome = @via_nome, 
					             via_telefono = @via_telefono, 
					             via_email = @via_email, 
					             via_data_aggiornamento = getdate(), 
                                 ute_aggiornato_da = @ute_aggiornato_da
					            WHERE (riv_id_richiesta = @riv_id_richiesta) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "via_pa", DbType.String, via_pa);
                db.AddInParameter(dbCommand, "via_cognome", DbType.String, via_cognome);
                db.AddInParameter(dbCommand, "via_nome", DbType.String, via_nome);
                db.AddInParameter(dbCommand, "via_telefono", DbType.String, via_telefono);
                db.AddInParameter(dbCommand, "via_email", DbType.String, via_email);
                db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);

                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);

                db.ExecuteNonQuery(dbCommand,t);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.UpdateDatiFromWs.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete(SqlInt32 p_via_id_viaggiatore)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM VIAGGIATORI WHERE 
					(via_id_viaggiatore = @via_id_viaggiatore) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "via_id_viaggiatore", DbType.Int32, p_via_id_viaggiatore);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Viaggiatori.Delete.");
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
            Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            DbConnection c = db.CreateConnection();
            DbTransaction t = null;

            try
            {
                c.Open();
                t = c.BeginTransaction();

                Create(t);

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
                    ex2.Data.Add("Class.Method", "Viaggiatori.Create.Rollback");
                    ex2.Data.Add("SQL", "Rollback error");
                }
                ex.Data.Add("Class.Method", "Viaggiatori.Create.");
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
		/// Crea l'oggetto corrispondente nella base dati.
		/// </summary>
        public void Create(DbTransaction t) 
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			IDataReader dataReader = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
	
				sqlCommand = @" INSERT INTO VIAGGIATORI (
						riv_id_richiesta, 
						ute_id_utente, 
						cat_id_categoria, 
						uco_id_unita, 
						rep_id_reparto, 
						via_pa, 
						via_cognome, 
						via_nome, 
						via_telefono, 
						via_email,
                        via_codice_individuale,
                        via_cdc_addebito, 
						cdc_id_centro_di_costo, 
						via_data_creazione, 
						ute_creato_da,via_istituto,via_flag_errore,
                        via_azienda,via_provenienza,
                        lmt_id_mezzo_trasporto,ltt_id_titolo,lrt_id_room_type,
                        via_data_nascita,via_nro_documento,ltd_id_documento,
                        via_note_particolari,via_aeroporto_partenza,via_avvicinamento_citta,
                        via_flag_cena,via_data_in,via_data_out
                        ) 
					VALUES ( 
						@riv_id_richiesta, 
						@ute_id_utente, 
						@cat_id_categoria, 
						@uco_id_unita, 
						@rep_id_reparto, 
						@via_pa, 
						dbo.fnProperCase(@via_cognome), 
						dbo.fnProperCase(@via_nome), 
						@via_telefono, 
						@via_email, 
                        @via_codice_individuale,
                        @via_cdc_addebito,
						@cdc_id_centro_di_costo, 
						getdate(), 
						@ute_creato_da,@via_istituto,@via_flag_errore,
                        @via_azienda,@via_provenienza,@lmt_id_mezzo_trasporto,
                        @ltt_id_titolo,@lrt_id_room_type,
                        @via_data_nascita,@via_nro_documento,@ltd_id_documento,
                        @via_note_particolari,@via_aeroporto_partenza,@via_avvicinamento_citta,
                        @via_flag_cena,@via_data_in,@via_data_out
                        ) 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "cat_id_categoria", DbType.Int32, cat_id_categoria);
				db.AddInParameter(dbCommand, "uco_id_unita", DbType.Int32, uco_id_unita);
				db.AddInParameter(dbCommand, "rep_id_reparto", DbType.Int32, rep_id_reparto);
				db.AddInParameter(dbCommand, "via_pa", DbType.String, via_pa);
				db.AddInParameter(dbCommand, "via_cognome", DbType.String, via_cognome);
				db.AddInParameter(dbCommand, "via_nome", DbType.String, via_nome);
				db.AddInParameter(dbCommand, "via_telefono", DbType.String, via_telefono);
				db.AddInParameter(dbCommand, "via_email", DbType.String, via_email);
                db.AddInParameter(dbCommand, "via_codice_individuale", DbType.String, via_codice_individuale);
                db.AddInParameter(dbCommand, "via_cdc_addebito", DbType.String, via_cdc_addebito);
                db.AddInParameter(dbCommand, "cdc_id_centro_di_costo", DbType.Int32, cdc_id_centro_di_costo);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);
                db.AddInParameter(dbCommand, "via_istituto", DbType.String, via_istituto);
                db.AddInParameter(dbCommand, "via_flag_errore", DbType.Int32, via_flag_errore);
                db.AddInParameter(dbCommand, "via_azienda", DbType.String, via_azienda);
                db.AddInParameter(dbCommand, "lmt_id_mezzo_trasporto", DbType.Int32, lmt_id_mezzo_trasporto);
                db.AddInParameter(dbCommand, "via_provenienza", DbType.String, via_provenienza);
                db.AddInParameter(dbCommand, "ltt_id_titolo", DbType.Int32, ltt_id_titolo);
                db.AddInParameter(dbCommand, "lrt_id_room_type", DbType.Int32, lrt_id_room_type);
                db.AddInParameter(dbCommand, "ltd_id_documento", DbType.Int32, ltd_id_documento);
                db.AddInParameter(dbCommand, "via_nro_documento", DbType.String, via_nro_documento);
                db.AddInParameter(dbCommand, "via_data_nascita", DbType.Date, via_data_nascita);
                db.AddInParameter(dbCommand, "via_note_particolari", DbType.String, via_note_particolari);
                db.AddInParameter(dbCommand, "via_aeroporto_partenza", DbType.String, via_aeroporto_partenza);
                db.AddInParameter(dbCommand, "via_avvicinamento_citta", DbType.String, via_avvicinamento_citta);
                db.AddInParameter(dbCommand, "via_flag_cena", DbType.Int32, via_flag_cena);
                db.AddInParameter(dbCommand, "via_data_in", DbType.Date, via_data_in);
                db.AddInParameter(dbCommand, "via_data_out", DbType.Date, via_data_out);

                dataReader = db.ExecuteReader(dbCommand, t);
 				if (dataReader.Read())
 				{
 					via_id_viaggiatore = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "Viaggiatori.Create.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
			finally
			{
				if(dataReader != null)
					((IDisposable)dataReader).Dispose();
			}
		}
		
		/// <summary>
        /// Elenca tutti gli elementi Viaggiatori dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "VIAGGIATORI");
        }
		/// <summary>
		/// Elenca tutti gli elementi Viaggiatori dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"VIAGGIATORI");
		}
		/// <summary>
		/// Elenca tutti gli elementi Viaggiatori dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					VIAGGIATORI.via_id_viaggiatore, 
					VIAGGIATORI.riv_id_richiesta, 
					VIAGGIATORI.ute_id_utente, 
					VIAGGIATORI.cat_id_categoria, 
					VIAGGIATORI.uco_id_unita, 
					VIAGGIATORI.rep_id_reparto, 
					VIAGGIATORI.via_pa, 
					VIAGGIATORI.via_cognome, 
					VIAGGIATORI.via_nome, 
					VIAGGIATORI.via_telefono, 
					VIAGGIATORI.via_email, 
                    VIAGGIATORI.via_codice_individuale,
                    VIAGGIATORI.via_cdc_addebito,
					VIAGGIATORI.cdc_id_centro_di_costo, 
					VIAGGIATORI.via_data_creazione, 
					VIAGGIATORI.via_data_aggiornamento, 
					VIAGGIATORI.ute_creato_da, 
					VIAGGIATORI.ute_aggiornato_da,
                    VIAGGIATORI.via_azienda,
                    VIAGGIATORI.via_provenienza,
                    COALESCE(VIAGGIATORI.via_cognome + ' ' + VIAGGIATORI.via_nome,VIAGGIATORI.via_cognome) as VIAGGIATORE,
                    ltt_id_titolo 
				    FROM VIAGGIATORI ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["VIAGGIATORI"].Columns["via_id_viaggiatore"];
				ds.Tables["VIAGGIATORI"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Viaggiatori.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}
        
        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void ReadByIdRichiesta(SqlInt32 p_riv_id_richiesta)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 VIAGGIATORI.via_id_viaggiatore, 
					 VIAGGIATORI.riv_id_richiesta, 
					 VIAGGIATORI.ute_id_utente, 
					 VIAGGIATORI.cat_id_categoria, 
					 VIAGGIATORI.uco_id_unita, 
					 VIAGGIATORI.rep_id_reparto, 
					 VIAGGIATORI.via_pa, 
					 VIAGGIATORI.via_cognome, 
					 VIAGGIATORI.via_nome, 
					 VIAGGIATORI.via_telefono, 
					 VIAGGIATORI.via_email, 
                     VIAGGIATORI.via_codice_individuale, 
                     VIAGGIATORI.via_cdc_addebito, 
					 VIAGGIATORI.cdc_id_centro_di_costo, 
					 VIAGGIATORI.via_data_creazione, 
					 VIAGGIATORI.via_data_aggiornamento, 
					 VIAGGIATORI.ute_creato_da, 
					 VIAGGIATORI.ute_aggiornato_da,
					 UTENTE.ute_matricola,
                     UTENTE.UTE_USER_ID 
				 	 FROM VIAGGIATORI 
                    LEFT JOIN UTENTE on UTENTE.ute_id_utente = VIAGGIATORI.ute_id_utente
                    WHERE  (riv_id_richiesta = @riv_id_richiesta) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    via_id_viaggiatore = reader.GetSqlInt32(0);
                    riv_id_richiesta = reader.GetSqlInt32(1);
                    ute_id_utente = reader.GetSqlInt32(2);
                    cat_id_categoria = reader.GetSqlInt32(3);
                    uco_id_unita = reader.GetSqlInt32(4);
                    rep_id_reparto = reader.GetSqlInt32(5);
                    via_pa = reader.GetSqlString(6);
                    via_cognome = reader.GetSqlString(7);
                    via_nome = reader.GetSqlString(8);
                    via_telefono = reader.GetSqlString(9);
                    via_email = reader.GetSqlString(10);
                    via_codice_individuale = reader.GetSqlString(11);
                    via_cdc_addebito = reader.GetSqlString(12);
                    cdc_id_centro_di_costo = reader.GetSqlInt32(13);
                    via_data_creazione = reader.GetSqlDateTime(14);
                    via_data_aggiornamento = reader.GetSqlDateTime(15);
                    ute_creato_da = reader.GetSqlInt32(16);
                    ute_aggiornato_da = reader.GetSqlInt32(17);
                    ute_matricola = reader.GetSqlString(18);
                    ute_user_id = reader.GetSqlString(19);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.ReadByIdRichiesta.");
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

        public void CreateCloneViaggiatore(SqlInt32 p_riv_id_richiesta, SqlInt32 p_riv_id_richiesta_orig)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO VIAGGIATORI (
						riv_id_richiesta, 
						ute_id_utente, 
						cat_id_categoria, 
						uco_id_unita, 
						rep_id_reparto, 
						via_pa, 
						via_cognome, 
						via_nome, 
						via_telefono, 
						via_email,
                        via_codice_individuale,
                        via_cdc_addebito, 
						cdc_id_centro_di_costo, 
						via_data_creazione, 
						ute_creato_da	 ) 
					SELECT 
						@riv_id_richiesta, 
						ute_id_utente, 
						cat_id_categoria, 
						uco_id_unita, 
						rep_id_reparto, 
						via_pa, 
						via_cognome, 
						via_nome, 
						via_telefono, 
						via_email, 
                        via_codice_individuale,
                        via_cdc_addebito,
						cdc_id_centro_di_costo, 
						getdate(), 
						ute_creato_da FROM viaggiatori WHERE riv_id_richiesta = @riv_id_richiesta_orig

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);
                db.AddInParameter(dbCommand, "riv_id_richiesta_orig", DbType.Int32, p_riv_id_richiesta_orig);

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    via_id_viaggiatore = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.CreateCloneViaggiatore.");
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
        /// Elenca tutti gli elementi Viaggiatori dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet ListMIM()
        {
            return ListMIM(string.Empty, "VIAGGIATORI");
        }
        /// <summary>
        /// Elenca tutti gli elementi Viaggiatori dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet ListMIM(string sqlWhereClause)
        {
            return ListMIM(sqlWhereClause, "VIAGGIATORI");
        }
        /// <summary>
        /// Elenca tutti gli elementi Viaggiatori dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListMIM(string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					VIAGGIATORI.via_id_viaggiatore, 
					VIAGGIATORI.riv_id_richiesta, 
					VIAGGIATORI.ute_id_utente, 
					VIAGGIATORI.cat_id_categoria, 
					VIAGGIATORI.uco_id_unita, 
					VIAGGIATORI.rep_id_reparto, 
					VIAGGIATORI.via_pa, 
					VIAGGIATORI.via_cognome,
                    VIAGGIATORI.via_nome,
					VIAGGIATORI.via_telefono, 
					VIAGGIATORI.via_email, 
                    VIAGGIATORI.via_codice_individuale,
                    VIAGGIATORI.via_cdc_addebito,
					VIAGGIATORI.cdc_id_centro_di_costo, 
					VIAGGIATORI.via_data_creazione, 
					VIAGGIATORI.via_data_aggiornamento,
                    VIAGGIATORI.via_istituto,
                    VIAGGIATORI.via_spesa_viaggio,via_flag_errore,
                    CASE WHEN PRA_ID_PRENOTAZIONE IS NULL THEN 0 ELSE 1 END AS PRA_INDICATOR,
                    CASE WHEN PRH_ID_PRENOTAZIONE IS NULL THEN 0 ELSE 1 END AS PRH_INDICATOR,
                    CASE WHEN PRC_ID_PRENOTAZIONE IS NULL THEN 0 ELSE 1 END AS PRC_INDICATOR,
                    CASE WHEN PRT_ID_PRENOTAZIONE IS NULL THEN 0 ELSE 1 END AS PRT_INDICATOR,  
                    CASE WHEN PRM_ID_PRENOTAZIONE IS NULL THEN 0 ELSE 1 END AS PRM_INDICATOR, 
					VIAGGIATORI.ute_creato_da, 
					VIAGGIATORI.ute_aggiornato_da,VIAGGIATORI.ltt_id_titolo,via_azienda
				    FROM VIAGGIATORI 
                    LEFT JOIN PRENOTAZIONI_AEREE ON VIAGGIATORI.VIA_ID_VIAGGIATORE = PRENOTAZIONI_AEREE.VIA_ID_VIAGGIATORE 
                    LEFT JOIN PRENOTAZIONI_HOTEL ON VIAGGIATORI.VIA_ID_VIAGGIATORE = PRENOTAZIONI_HOTEL.VIA_ID_VIAGGIATORE 
                    LEFT JOIN PRENOTAZIONI_AUTO ON VIAGGIATORI.VIA_ID_VIAGGIATORE = PRENOTAZIONI_AUTO.VIA_ID_VIAGGIATORE 
                    LEFT JOIN PRENOTAZIONI_TRENO ON VIAGGIATORI.VIA_ID_VIAGGIATORE = PRENOTAZIONI_TRENO.VIA_ID_VIAGGIATORE 
                    LEFT JOIN PRENOTAZIONI_MARITTIMI ON VIAGGIATORI.VIA_ID_VIAGGIATORE = PRENOTAZIONI_MARITTIMI.VIA_ID_VIAGGIATORE 
                           ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, tableName);

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["VIAGGIATORI"].Columns["via_id_viaggiatore"];
                ds.Tables["VIAGGIATORI"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Elenca tutti gli elementi Viaggiatori dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet ListMCE()
        {
            return ListMCE(string.Empty, "VIAGGIATORI");
        }
        /// <summary>
        /// Elenca tutti gli elementi Viaggiatori dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet ListMCE(string sqlWhereClause)
        {
            return ListMCE(sqlWhereClause, "VIAGGIATORI");
        }
        /// <summary>
        /// Elenca tutti gli elementi Viaggiatori dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet ListMCE(string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					VIAGGIATORI.via_id_viaggiatore, 
					VIAGGIATORI.riv_id_richiesta, 
					VIAGGIATORI.ute_id_utente, 
					VIAGGIATORI.cat_id_categoria, 
					VIAGGIATORI.uco_id_unita, 
					VIAGGIATORI.rep_id_reparto, 
					VIAGGIATORI.via_pa, 
					VIAGGIATORI.via_cognome,
                    VIAGGIATORI.via_nome,
					VIAGGIATORI.via_telefono, 
					VIAGGIATORI.via_email, 
                    VIAGGIATORI.via_codice_individuale,
                    VIAGGIATORI.via_cdc_addebito,
					VIAGGIATORI.cdc_id_centro_di_costo, 
					VIAGGIATORI.via_data_creazione, 
					VIAGGIATORI.via_data_aggiornamento,
                    VIAGGIATORI.via_istituto,
                    VIAGGIATORI.via_spesa_viaggio,via_flag_errore,                    
					VIAGGIATORI.ute_creato_da, 
					VIAGGIATORI.ute_aggiornato_da 
				    FROM VIAGGIATORI 
                    ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, tableName);

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["VIAGGIATORI"].Columns["via_id_viaggiatore"];
                ds.Tables["VIAGGIATORI"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void ReadMIM(SqlInt32 p_via_id_viaggiatore)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 VIAGGIATORI.via_id_viaggiatore, 
					 VIAGGIATORI.riv_id_richiesta, 
					 VIAGGIATORI.ute_id_utente, 
					 VIAGGIATORI.via_cognome, 
					 VIAGGIATORI.via_nome, 
					 VIAGGIATORI.via_telefono, 
					 VIAGGIATORI.via_email, 
					 VIAGGIATORI.via_data_creazione, 
					 VIAGGIATORI.via_data_aggiornamento, 
					 VIAGGIATORI.ute_creato_da, 
					 VIAGGIATORI.ute_aggiornato_da,
                     VIAGGIATORI.via_istituto,
                     VIAGGIATORI.via_cellulare,
                     VIAGGIATORI.via_fax,
                     VIAGGIATORI.via_flag_iscrizione,
                     VIAGGIATORI.Via_importo_iscrizione,
                     VIAGGIATORI.Via_importo_costi_extra,
                     VIAGGIATORI.Via_descrizione_costi_extra,
                     VIAGGIATORI.Via_flag_errore
				 	 FROM VIAGGIATORI WHERE 
					 (via_id_viaggiatore = @via_id_viaggiatore) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "via_id_viaggiatore", DbType.Int32, p_via_id_viaggiatore);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    via_id_viaggiatore = reader.GetSqlInt32(0);
                    riv_id_richiesta = reader.GetSqlInt32(1);
                    ute_id_utente = reader.GetSqlInt32(2);
                    via_cognome = reader.GetSqlString(3);
                    via_nome = reader.GetSqlString(4);
                    via_telefono = reader.GetSqlString(5);
                    via_email = reader.GetSqlString(6);
                    via_data_creazione = reader.GetSqlDateTime(7);
                    via_data_aggiornamento = reader.GetSqlDateTime(8);
                    ute_creato_da = reader.GetSqlInt32(9);
                    ute_aggiornato_da = reader.GetSqlInt32(10);
                    via_istituto = reader.GetSqlString(11);
                    via_cellulare = reader.GetSqlString(12);
                    via_fax = reader.GetSqlString(13);
                    via_flag_iscrizione = reader.GetSqlInt32(14);
                    Via_importo_iscrizione = reader.GetSqlDecimal(15);
                    Via_importo_costi_extra = reader.GetSqlDecimal(16);
                    Via_descrizione_costi_extra = reader.GetSqlString(17);
                    Via_flag_errore = reader.GetSqlInt32(18);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.Read.");
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
        public void UpdateMIM(SqlInt32 p_via_id_viaggiatore)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE VIAGGIATORI SET					  
					 via_cognome = @via_cognome,
                     via_nome = @via_nome,
                     via_istituto = @via_istituto,
                     via_telefono = @via_telefono, 
					 via_email = @via_email, 
                     via_fax = @via_fax, 
                     via_cellulare = @via_cellulare, 
                     via_flag_iscrizione = @via_flag_iscrizione, 
                     via_importo_iscrizione = @via_importo_iscrizione, 
                     via_descrizione_costi_extra = @via_descrizione_costi_extra, 
                     via_importo_costi_extra = @via_importo_costi_extra, 
                     via_data_aggiornamento = getdate(), 
                     via_flag_errore = @via_flag_errore,
					 ute_aggiornato_da = @ute_aggiornato_da,
                     ltt_id_titolo = @ltt_id_titolo
					 WHERE   
				     (via_id_viaggiatore = @via_id_viaggiatore) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "via_cognome", DbType.String, via_cognome);
                db.AddInParameter(dbCommand, "via_nome", DbType.String, via_nome);
                db.AddInParameter(dbCommand, "via_istituto", DbType.String, via_istituto);
                db.AddInParameter(dbCommand, "via_telefono", DbType.String, via_telefono);
                db.AddInParameter(dbCommand, "via_email", DbType.String, via_email);
                db.AddInParameter(dbCommand, "via_cellulare", DbType.String, via_cellulare);
                db.AddInParameter(dbCommand, "via_flag_iscrizione", DbType.Int32, via_flag_iscrizione);
                db.AddInParameter(dbCommand, "via_importo_iscrizione", DbType.Decimal, via_importo_iscrizione);
                db.AddInParameter(dbCommand, "via_descrizione_costi_extra", DbType.String, via_descrizione_costi_extra);
                db.AddInParameter(dbCommand, "via_importo_costi_extra", DbType.Decimal, via_importo_costi_extra);
                db.AddInParameter(dbCommand, "via_fax", DbType.String, via_fax);
                db.AddInParameter(dbCommand, "via_flag_errore", DbType.Int32, via_flag_errore);
                db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
                db.AddInParameter(dbCommand, "ltt_id_titolo", DbType.Int32, ltt_id_titolo);
                db.AddInParameter(dbCommand, "via_id_viaggiatore", DbType.Int32, p_via_id_viaggiatore);
                
                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.UpdateMIM.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void UpdateMCE(SqlInt32 p_via_id_viaggiatore)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE VIAGGIATORI SET					  
					 via_cognome = @via_cognome,
                     via_nome = @via_nome,                    
					 ute_aggiornato_da = @ute_aggiornato_da
					 WHERE   
				     (via_id_viaggiatore = @via_id_viaggiatore) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "via_cognome", DbType.String, via_cognome);
                db.AddInParameter(dbCommand, "via_nome", DbType.String, via_nome);               
                db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
                db.AddInParameter(dbCommand, "via_id_viaggiatore", DbType.Int32, p_via_id_viaggiatore);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.UpdateMCE.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        ///
        public void UpdateSpesaViaggio(SqlInt32 p_via_id_viaggiatore, SqlInt32 p_riv_id_richiesta)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE VIAGGIATORI SET					  
					 via_spesa_viaggio = VIA_IMPORTO_ISCRIZIONE + VIA_IMPORTO_COSTI_EXTRA + 
                        (SELECT SUM(TOTALE) AS TOTALE FROM
                                    (
                                        SELECT SUM(PRA_IMPORTO_DOVUTO) AS TOTALE					 
                                        FROM PRENOTAZIONI_AEREE
                                        WHERE 
					                    (riv_id_richiesta = @riv_id_richiesta and via_id_viaggiatore= @via_id_viaggiatore)
                                        UNION ALL
                                        SELECT SUM(PRH_IMPORTO_DOVUTO) AS TOTALE					 
                                        FROM PRENOTAZIONI_HOTEL
                                        WHERE 
					                    (riv_id_richiesta = @riv_id_richiesta and via_id_viaggiatore= @via_id_viaggiatore)
                                        UNION ALL
                                        SELECT SUM(PRC_IMPORTO_DOVUTO) AS TOTALE					 
                                        FROM PRENOTAZIONI_AUTO
                                        WHERE 
					                    (riv_id_richiesta = @riv_id_richiesta and via_id_viaggiatore= @via_id_viaggiatore)
                                        UNION ALL
                                        SELECT SUM(PRT_IMPORTO_DOVUTO) AS TOTALE					 
                                        FROM PRENOTAZIONI_TRENO
                                        WHERE 
					                    (riv_id_richiesta = @riv_id_richiesta and via_id_viaggiatore= @via_id_viaggiatore)
                                        UNION ALL
                                        SELECT SUM(PRM_IMPORTO_DOVUTO) AS TOTALE					 
                                        FROM PRENOTAZIONI_MARITTIMI
                                        WHERE 
					                    (riv_id_richiesta = @riv_id_richiesta and via_id_viaggiatore= @via_id_viaggiatore)
                                    ) IMPORTO_VENDUTO )
					            WHERE   
				        (via_id_viaggiatore = @via_id_viaggiatore) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);
                db.AddInParameter(dbCommand, "via_id_viaggiatore", DbType.Int32, p_via_id_viaggiatore);

                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.UpdateSpesaViaggio.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        //List utilizzata nel modulo eventi per visualizzare gli iscritti a un determinato servizio.
        public DataSet ListViaggiatoriEvento(string tableService,string campoChiave,string idPrenotazione,string sqlCampo1,string sqlCampo2)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"SELECT 
                            VIAGGIATORI.via_id_viaggiatore, 
                            VIAGGIATORI.riv_id_richiesta, 					
                            VIAGGIATORI.via_azienda,
                            VIAGGIATORI.via_provenienza,
                            VIAGGIATORI.via_email,
                            VIAGGIATORI.via_telefono," + sqlCampo1 + sqlCampo2 +
                            @"COALESCE(VIAGGIATORI.via_cognome + ' ' + VIAGGIATORI.via_nome,VIAGGIATORI.via_cognome) as VIAGGIATORE,
                            case when VIAGGIATORI.via_id_viaggiatore in 
                            (select via_id_viaggiatore from " +  tableService + @" where " + campoChiave + @" = " + idPrenotazione + @") then 1 else 0 end as EXIST
                            FROM VIAGGIATORI ");

                if (SqlWhereClause != string.Empty)
                {
                    sb.Append(SqlWhereClause);
                }
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);                

                db.LoadDataSet(dbCommand, ds, "VIAGGIATORI");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.ListViaggiatoriEvento.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public DataSet ListViaggiatoriEventoForExport(string tableService,string campoChiave,string idPrenotazione)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"SELECT 
                            COALESCE(VIAGGIATORI.via_cognome + ' ' + VIAGGIATORI.via_nome,VIAGGIATORI.via_cognome) as VIAGGIATORE,
                            VIAGGIATORI.via_azienda as AZIENDA,
                            VIAGGIATORI.via_provenienza as PROVENIENZA,
                            VIAGGIATORI.via_email as EMAIL,
                            VIAGGIATORI.via_telefono as TELEFONO,
                            case when VIAGGIATORI.via_id_viaggiatore in 
                            (select via_id_viaggiatore from " + tableService + @" where " + campoChiave + @" = " + idPrenotazione + @") then 'Si' else 'No' end as ASSEGNATO
                            FROM VIAGGIATORI ");

                if (SqlWhereClause != string.Empty)
                {
                    sb.Append(SqlWhereClause);
                }
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, "VIAGGIATORI");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.ListViaggiatoriEventoForExport.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public DataSet ListViaggiatoriEventoAllForExport()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"SELECT 
                            LTT_DESCRIZIONE_IT AS TITOLO,                            
                            COALESCE(VIAGGIATORI.via_cognome + ' ' + VIAGGIATORI.via_nome,VIAGGIATORI.via_cognome) as VIAGGIATORE,
                            VIAGGIATORI.via_email as EMAIL,
                            VIAGGIATORI.via_telefono as TELEFONO,
                            CONVERT(DATETIME,VIAGGIATORI.via_data_nascita,103) as [DATA DI NASCITA],
                            LTD_DESCRIZIONE_IT AS [TIPO DOCUMENTO],
                            VIAGGIATORI.VIA_NRO_DOCUMENTO AS [NRO DOCUMENTO],
                            VIAGGIATORI.via_azienda as AZIENDA,
                            LMT_DESCRIZIONE_IT AS [MEZZO DI TRASPORTO],
                            VIAGGIATORI.VIA_NOTE_PARTICOLARI AS NOTE,
                            VIAGGIATORI.via_provenienza as PROVENIENZA,
                            VIAGGIATORI.VIA_AEROPORTO_PARTENZA AS [AEROPORTO PARTENZA],
                            VIAGGIATORI.VIA_AVVICINAMENTO_CITTA AS [AVVICINAMENTO CITTA'],
                            LRT_DESCRIZIONE_IT AS [ROOM TYPE],
                            CASE WHEN VIA_FLAG_CENA = 1 THEN 'SI' ELSE 'NO' END AS CENA,
                            VIAGGIATORI.VIA_DATA_IN AS [DATA IN],
                            VIAGGIATORI.VIA_DATA_OUT AS [DATA OUT]
                            FROM VIAGGIATORI 
                            LEFT JOIN LOOKUP_TITOLO ON VIAGGIATORI.LTT_ID_TITOLO = LOOKUP_TITOLO.LTT_ID_TITOLO
                            LEFT JOIN LOOKUP_TIPO_DOCUMENTO ON VIAGGIATORI.LTD_ID_DOCUMENTO = LOOKUP_TIPO_DOCUMENTO.LTD_ID_DOCUMENTO
                            LEFT JOIN LOOKUP_MEZZO_TRASPORTO ON VIAGGIATORI.LMT_ID_MEZZO_TRASPORTO = LOOKUP_MEZZO_TRASPORTO.LMT_ID_MEZZO_TRASPORTO
                            LEFT JOIN LOOKUP_ROOM_TYPE ON VIAGGIATORI.LRT_ID_ROOM_TYPE = LOOKUP_ROOM_TYPE.LRT_ID_ROOM_TYPE");

                if (SqlWhereClause != string.Empty)
                {
                    sb.Append(SqlWhereClause);
                }
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, "VIAGGIATORI");
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Viaggiatori.ListViaggiatoriEventoAllForExport.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }
        
        #endregion

	}
}
