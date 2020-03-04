#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   Richiedente.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per RICHIEDENTE
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
	/// Tabella RICHIEDENTE 
	/// </summary>
	public class Richiedente
	{
		#region attributi e variabili

	    private SqlInt32 ric_id_richiedente = SqlInt32.Null;
        private SqlInt32 ute_id_utente = SqlInt32.Null;
	    private SqlInt32 riv_id_richiesta = SqlInt32.Null;
	    private SqlString ric_pa = SqlString.Null;
	    private SqlString ric_cognome = SqlString.Null;
	    private SqlString ric_nome = SqlString.Null;
	    private SqlString ric_telefono = SqlString.Null;
	    private SqlString ric_fax = SqlString.Null;
	    private SqlString ric_email = SqlString.Null;
	    private SqlString ric_email_invio_titoli = SqlString.Null;
	    private SqlString ric_presso = SqlString.Null;
        private SqlString ric_matricola = SqlString.Null; 
        private SqlDateTime ric_data_consegna_titoli = SqlDateTime.Null;
	    private SqlDateTime ric_data_creazione = SqlDateTime.Null;
	    private SqlDateTime ric_data_aggiornamento = SqlDateTime.Null;
	    private SqlInt32 ute_creato_da = SqlInt32.Null;
	    private SqlInt32 ute_aggiornato_da = SqlInt32.Null;        
        private SqlString ute_matricola = SqlString.Null;
        private SqlString ute_user_id = SqlString.Null; 

		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Ric_id_richiedente
		{
			get { return ric_id_richiedente; }	
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
		public SqlString Ric_pa
		{
			get { return ric_pa; }	
			set { ric_pa = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Ric_cognome
		{
			get { return ric_cognome; }	
			set { ric_cognome = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlString Ric_matricola
        {
            get { return ric_matricola; }
            set { ric_matricola = value; }
        }

		/// <value>
		/// 
		/// </value>
		public SqlString Ric_nome
		{
			get { return ric_nome; }	
			set { ric_nome = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Ric_telefono
		{
			get { return ric_telefono; }	
			set { ric_telefono = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Ric_fax
		{
			get { return ric_fax; }	
			set { ric_fax = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Ric_email
		{
			get { return ric_email; }	
			set { ric_email = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Ric_email_invio_titoli
		{
			get { return ric_email_invio_titoli; }	
			set { ric_email_invio_titoli = value; }
		}

		/// <value>
		/// utilizzato solo per la consegna manuale dei biglietti
		/// </value>
		public SqlString Ric_presso
		{
			get { return ric_presso; }	
			set { ric_presso = value; }
		}
        
        /// <value>
        /// matricola
        /// </value>
        public SqlString Ute_matricola
        {
            get { return ute_matricola; }
            set { ute_matricola = value; }
        }


        /// <value>
        /// user_id
        /// </value>
        public SqlString Ute_user_id
        {
            get { return ute_user_id; }
            set { ute_user_id = value; }
        }


		/// <value>
		/// utilizzato solo per la consegna manuale dei biglietti
		/// </value>
		public SqlDateTime Ric_data_consegna_titoli
		{
			get { return ric_data_consegna_titoli; }	
			set { ric_data_consegna_titoli = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Ric_data_creazione
		{
			get { return ric_data_creazione; }	
			set { ric_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Ric_data_aggiornamento
		{
			get { return ric_data_aggiornamento; }	
			set { ric_data_aggiornamento = value; }
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
        public SqlInt32 Ute_id_utente
        {
            get { return ute_id_utente; }
            set { ute_id_utente = value; }
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
		public Richiedente()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_ric_id_richiedente)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 RICHIEDENTE.ric_id_richiedente, 
					 RICHIEDENTE.ute_id_utente, 
					 RICHIEDENTE.riv_id_richiesta, 
					 RICHIEDENTE.ric_pa, 
					 RICHIEDENTE.ric_cognome, 
					 RICHIEDENTE.ric_nome, 
					 RICHIEDENTE.ric_telefono, 
					 RICHIEDENTE.ric_fax, 
					 RICHIEDENTE.ric_email, 
					 RICHIEDENTE.ric_email_invio_titoli, 
					 RICHIEDENTE.ric_presso, 
					 RICHIEDENTE.ric_data_consegna_titoli, 
					 RICHIEDENTE.ric_data_creazione, 
					 RICHIEDENTE.ric_data_aggiornamento, 
					 RICHIEDENTE.ute_creato_da, 
					 RICHIEDENTE.ute_aggiornato_da,
                     RICHIEDENTE.ric_matricola	 
				 	 FROM RICHIEDENTE WHERE 
					 (ric_id_richiedente = @ric_id_richiedente) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "ric_id_richiedente", DbType.Int32, p_ric_id_richiedente);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					ric_id_richiedente = reader.GetSqlInt32(0);
					ute_id_utente = reader.GetSqlInt32(1);
					riv_id_richiesta = reader.GetSqlInt32(2);
					ric_pa = reader.GetSqlString(3);
					ric_cognome = reader.GetSqlString(4);
					ric_nome = reader.GetSqlString(5);
					ric_telefono = reader.GetSqlString(6);
					ric_fax = reader.GetSqlString(7);
					ric_email = reader.GetSqlString(8);
					ric_email_invio_titoli = reader.GetSqlString(9);
					ric_presso = reader.GetSqlString(10);
					ric_data_consegna_titoli = reader.GetSqlDateTime(11);
					ric_data_creazione = reader.GetSqlDateTime(12);
					ric_data_aggiornamento = reader.GetSqlDateTime(13);
					ute_creato_da = reader.GetSqlInt32(14);
					ute_aggiornato_da = reader.GetSqlInt32(15);
                    ric_matricola = reader.GetSqlString(16);
				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "Richiedente.Read.");
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


        public void ReadForCDCMobile(SqlInt32 p_riv_id_richiesta)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 
					 RICHIEDENTE.ric_id_richiedente, 					 
					 RICHIEDENTE.ric_cognome, 
					 RICHIEDENTE.ric_nome					 
				 	 FROM RICHIEDENTE WHERE 
					 (riv_id_richiesta = @riv_id_richiesta) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;
                while (reader.Read())
                {
                    ric_id_richiedente = reader.GetSqlInt32(0);
                    ric_cognome = reader.GetSqlString(1);
                    ric_nome = reader.GetSqlString(2);                    
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Richiedente.ReadForCDCMobile.");
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
		public void Update(SqlInt32 riv_id_richiesta)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE RICHIEDENTE SET
					 ute_id_utente = @ute_id_utente, 					
					 ric_pa = @ric_pa, 
					 ric_cognome = dbo.fnProperCase(@ric_cognome), 
					 ric_nome = dbo.fnProperCase(@ric_nome), 
					 ric_telefono = @ric_telefono, 
					 ric_fax = @ric_fax, 
					 ric_email = @ric_email, 
					 ric_email_invio_titoli = @ric_email_invio_titoli, 
					 ric_presso = @ric_presso, 
                     ric_matricola = @ric_matricola, 
					 ric_data_consegna_titoli = @ric_data_consegna_titoli, 
					 ric_data_aggiornamento = getdate(), 
					 ute_aggiornato_da = @ute_aggiornato_da
					 WHERE   
				     (riv_id_richiesta = @riv_id_richiesta) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);
				db.AddInParameter(dbCommand, "ric_pa", DbType.String, ric_pa);
				db.AddInParameter(dbCommand, "ric_cognome", DbType.String, ric_cognome);
				db.AddInParameter(dbCommand, "ric_nome", DbType.String, ric_nome);
				db.AddInParameter(dbCommand, "ric_telefono", DbType.String, ric_telefono);
				db.AddInParameter(dbCommand, "ric_fax", DbType.String, ric_fax);
				db.AddInParameter(dbCommand, "ric_email", DbType.String, ric_email);
				db.AddInParameter(dbCommand, "ric_email_invio_titoli", DbType.String, ric_email_invio_titoli);
				db.AddInParameter(dbCommand, "ric_presso", DbType.String, ric_presso);
                db.AddInParameter(dbCommand, "ric_matricola", DbType.String, ric_matricola);
				db.AddInParameter(dbCommand, "ric_data_consegna_titoli", DbType.DateTime, ric_data_consegna_titoli);
				db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);
														
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Richiedente.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

        /// <summary>
        /// Aggiorna l'ggetto nella base dati
        /// </summary>	
        public void UpdateDatiFromWs(SqlInt32 riv_id_richiesta,DbTransaction t)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE RICHIEDENTE SET							
					             ric_pa = @ric_pa, 
					             ric_cognome = @ric_cognome, 
					             ric_nome = @ric_nome, 
					             ric_telefono = @ric_telefono, 
					             ric_email = @ric_email, 
					             ric_email_invio_titoli = @ric_email_invio_titoli, 
                                 ric_data_consegna_titoli = @ric_data_consegna_titoli,
					             ric_data_aggiornamento = getdate(), 
					             ute_aggiornato_da = @ute_aggiornato_da
					         WHERE (riv_id_richiesta = @riv_id_richiesta) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
               
                db.AddInParameter(dbCommand, "ric_pa", DbType.String, ric_pa);
                db.AddInParameter(dbCommand, "ric_cognome", DbType.String, ric_cognome);
                db.AddInParameter(dbCommand, "ric_nome", DbType.String, ric_nome);
                db.AddInParameter(dbCommand, "ric_telefono", DbType.String, ric_telefono);                
                db.AddInParameter(dbCommand, "ric_email", DbType.String, ric_email);
                db.AddInParameter(dbCommand, "ric_email_invio_titoli", DbType.String, ric_email_invio_titoli);
                db.AddInParameter(dbCommand, "ric_data_consegna_titoli", DbType.DateTime, ric_data_consegna_titoli);
                db.AddInParameter(dbCommand, "ute_aggiornato_da", DbType.Int32, ute_aggiornato_da);

                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);

                db.ExecuteNonQuery(dbCommand, t);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Richiedente.UpdateDatiFromWs.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete(SqlInt32 p_ric_id_richiedente)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM RICHIEDENTE WHERE 
					(ric_id_richiedente = @ric_id_richiedente) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "ric_id_richiedente", DbType.Int32, p_ric_id_richiedente);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Richiedente.Delete.");
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
                    ex2.Data.Add("Class.Method", "Richiedente.Create.Rollback");
                    ex2.Data.Add("SQL", "Rollback error");
                }
                ex.Data.Add("Class.Method", "Richiedente.Create.");
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
	
				sqlCommand = @" INSERT INTO RICHIEDENTE (						
						riv_id_richiesta, 
						ric_pa, 
						ric_cognome, 
						ric_nome, 
						ric_telefono, 
						ric_fax, 
						ric_email, 
						ric_email_invio_titoli, 
						ric_presso, 
						ric_data_consegna_titoli, 
						ric_data_creazione, 
						ute_creato_da,
                        ute_id_utente,ric_matricola) 
					VALUES ( 						
						@riv_id_richiesta, 
						@ric_pa, 
						dbo.fnProperCase(@ric_cognome), 
						dbo.fnProperCase(@ric_nome), 
						@ric_telefono, 
						@ric_fax, 
						@ric_email, 
						@ric_email_invio_titoli, 
						@ric_presso, 
						@ric_data_consegna_titoli, 
						getdate(), 
						@ute_creato_da,
                        @ute_id_utente,@ric_matricola) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            				
				db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, riv_id_richiesta);
				db.AddInParameter(dbCommand, "ric_pa", DbType.String, ric_pa);
				db.AddInParameter(dbCommand, "ric_cognome", DbType.String, ric_cognome);
				db.AddInParameter(dbCommand, "ric_nome", DbType.String, ric_nome);
				db.AddInParameter(dbCommand, "ric_telefono", DbType.String, ric_telefono);
				db.AddInParameter(dbCommand, "ric_fax", DbType.String, ric_fax);
				db.AddInParameter(dbCommand, "ric_email", DbType.String, ric_email);
				db.AddInParameter(dbCommand, "ric_email_invio_titoli", DbType.String, ric_email_invio_titoli);
				db.AddInParameter(dbCommand, "ric_presso", DbType.String, ric_presso);
                db.AddInParameter(dbCommand, "ric_matricola", DbType.String, ric_matricola);
				db.AddInParameter(dbCommand, "ric_data_consegna_titoli", DbType.DateTime, ric_data_consegna_titoli);
				db.AddInParameter(dbCommand, "ute_creato_da", DbType.Int32, ute_creato_da);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);

                dataReader = db.ExecuteReader(dbCommand, t);
 				if (dataReader.Read())
 				{
 					ric_id_richiedente = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "Richiedente.Create.");
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
        /// Elenca tutti gli elementi Richiedente dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "RICHIEDENTE");
        }
		/// <summary>
		/// Elenca tutti gli elementi Richiedente dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"RICHIEDENTE");
		}
		/// <summary>
		/// Elenca tutti gli elementi Richiedente dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					RICHIEDENTE.ric_id_richiedente, 
					RICHIEDENTE.ute_id_utente, 
					RICHIEDENTE.riv_id_richiesta, 
					RICHIEDENTE.ric_pa, 
					RICHIEDENTE.ric_cognome, 
					RICHIEDENTE.ric_nome, 
					RICHIEDENTE.ric_telefono, 
					RICHIEDENTE.ric_fax, 
					RICHIEDENTE.ric_email, 
					RICHIEDENTE.ric_email_invio_titoli, 
					RICHIEDENTE.ric_presso, 
					RICHIEDENTE.ric_data_consegna_titoli, 
					RICHIEDENTE.ric_data_creazione, 
					RICHIEDENTE.ric_data_aggiornamento, 
					RICHIEDENTE.ute_creato_da, 
					RICHIEDENTE.ute_aggiornato_da 
				FROM RICHIEDENTE ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["RICHIEDENTE"].Columns["ric_id_richiedente"];
				ds.Tables["RICHIEDENTE"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Richiedente.List.");
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
					 RICHIEDENTE.ric_id_richiedente, 
					 RICHIEDENTE.ute_id_utente, 
					 RICHIEDENTE.riv_id_richiesta, 
					 RICHIEDENTE.ric_pa, 
					 RICHIEDENTE.ric_cognome, 
					 RICHIEDENTE.ric_nome, 
					 RICHIEDENTE.ric_telefono, 
					 RICHIEDENTE.ric_fax, 
					 RICHIEDENTE.ric_email, 
					 RICHIEDENTE.ric_email_invio_titoli, 
					 RICHIEDENTE.ric_presso, 
					 RICHIEDENTE.ric_data_consegna_titoli, 
					 RICHIEDENTE.ric_data_creazione, 
					 RICHIEDENTE.ric_data_aggiornamento, 
					 RICHIEDENTE.ute_creato_da, 
					 RICHIEDENTE.ute_aggiornato_da,                     
                     UTENTE.UTE_MATRICOLA,
                     UTENTE.UTE_USER_ID
				 	 FROM RICHIEDENTE LEFT JOIN UTENTE ON RICHIEDENTE.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE                            
                     WHERE (riv_id_richiesta = @riv_id_richiesta) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    ric_id_richiedente = reader.GetSqlInt32(0);
                    ute_id_utente = reader.GetSqlInt32(1);
                    riv_id_richiesta = reader.GetSqlInt32(2);
                    ric_pa = reader.GetSqlString(3);
                    ric_cognome = reader.GetSqlString(4);
                    ric_nome = reader.GetSqlString(5);
                    ric_telefono = reader.GetSqlString(6);
                    ric_fax = reader.GetSqlString(7);
                    ric_email = reader.GetSqlString(8);
                    ric_email_invio_titoli = reader.GetSqlString(9);
                    ric_presso = reader.GetSqlString(10);
                    ric_data_consegna_titoli = reader.GetSqlDateTime(11);
                    ric_data_creazione = reader.GetSqlDateTime(12);
                    ric_data_aggiornamento = reader.GetSqlDateTime(13);
                    ute_creato_da = reader.GetSqlInt32(14);
                    ute_aggiornato_da = reader.GetSqlInt32(15);                    
                    ute_matricola = reader.GetSqlString(16);
                    ute_user_id = reader.GetSqlString(17);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Richiedente.ReadByidRichiesta.");
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


        public void CreateCloneRichiedente(SqlInt32 p_riv_id_richiesta, SqlInt32 p_riv_id_richiesta_orig)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO RICHIEDENTE (						
						riv_id_richiesta, 
						ric_pa, 
						ric_cognome, 
						ric_nome, 
						ric_telefono, 
						ric_fax, 
						ric_email, 
						ric_email_invio_titoli, 
						ric_presso, 
						ric_data_consegna_titoli, 
						ric_data_creazione, 
						ute_creato_da,
                        ute_id_utente,
                        ric_matricola) 
					   
                        SELECT  						
						@riv_id_richiesta, 
						ric_pa, 
						ric_cognome, 
						ric_nome, 
						ric_telefono, 
						ric_fax, 
						ric_email, 
						ric_email_invio_titoli, 
						ric_presso, 
						ric_data_consegna_titoli, 
						getdate(), 
						ute_creato_da,
                        ute_id_utente,ric_matricola from richiedente where riv_id_richiesta = @riv_id_richiesta_orig 

				; SELECT SCOPE_IDENTITY()";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);
                db.AddInParameter(dbCommand, "riv_id_richiesta_orig", DbType.Int32, p_riv_id_richiesta_orig);                

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    ric_id_richiedente = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Richiedente.CreateCloneRichiedente.");
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
