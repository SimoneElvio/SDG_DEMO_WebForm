#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TAF
// Nome File:   CrossGruppiClienteUtenti.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per CROSSUTENTECLIENTE
//
// Autore:      FB - SDG srl
// Data:        14/02/2019
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
    /// Tabella [CROSS_GRUPPI_CLIENTE_UTENTI] 
    /// </summary>
    public class CrossGruppiClienteUtenti
    {
		#region attributi e variabili

	    private SqlInt32 cgc_id_cross_gruppi_cliente_utenti = SqlInt32.Null;
	    private SqlInt32 grc_id_gruppi_cliente = SqlInt32.Null;
	    private SqlInt32 ute_id_utente = SqlInt32.Null;
	    private SqlInt32 cgc_flag_eliminato = SqlInt32.Null;
	    private SqlDateTime cgc_data_creazione = SqlDateTime.Null;
	    private SqlDateTime cgc_data_aggiornamento = SqlDateTime.Null;
        private SqlDateTime cgc_data_eliminazione = SqlDateTime.Null;
        private SqlInt32 cgc_creato_da = SqlInt32.Null;
	    private SqlInt32 cgc_aggiornato_da = SqlInt32.Null;
        private SqlInt32 cgc_eliminato_da = SqlInt32.Null;

		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cgc_id_cross_gruppi_cliente_utenti
        {
			get { return cgc_id_cross_gruppi_cliente_utenti; }           
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Grc_id_gruppi_cliente
        {
			get { return grc_id_gruppi_cliente; }	
			set { grc_id_gruppi_cliente = value; }
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
		public SqlInt32 Cgc_flag_eliminato
        {
			get { return cgc_flag_eliminato; }	
			set { cgc_flag_eliminato = value; }
		}



		/// <value>
		/// 
		/// </value>
		public SqlDateTime Cgc_data_creazione
        {
			get { return cgc_data_creazione; }	
			set { cgc_data_creazione = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime Cgc_data_aggiornamento
        {
			get { return cgc_data_aggiornamento; }	
			set { cgc_data_aggiornamento = value; }
		}

        /// <value>
		/// 
		/// </value>
		public SqlDateTime Cgc_data_eliminazione
        {
            get { return cgc_data_eliminazione; }
            set { cgc_data_eliminazione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cgc_creato_da
        {
			get { return cgc_creato_da; }	
			set { cgc_creato_da = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cgc_aggiornato_da
        {
			get { return cgc_aggiornato_da; }	
			set { cgc_aggiornato_da = value; }
		}

        /// <value>
		/// 
		/// </value>
		public SqlInt32 Cgc_eliminato_da
        {
            get { return cgc_eliminato_da; }
            set { cgc_eliminato_da = value; }
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
		public CrossGruppiClienteUtenti()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_cgc_id_cross_gruppi_cliente_utenti)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 CROSS_GRUPPI_CLIENTE_UTENTI.cgc_id_cross_gruppi_cliente_utenti, 
					 CROSS_GRUPPI_CLIENTE_UTENTI.grc_id_gruppi_cliente, 
					 CROSS_GRUPPI_CLIENTE_UTENTI.ute_id_utente, 
					 CROSS_GRUPPI_CLIENTE_UTENTI.cgc_flag_eliminato, 
					 CROSS_GRUPPI_CLIENTE_UTENTI.cgc_data_creazione, 
					 CROSS_GRUPPI_CLIENTE_UTENTI.cgc_data_aggiornamento, 
                     CROSS_GRUPPI_CLIENTE_UTENTI.cgc_data_eliminazione, 
					 CROSS_GRUPPI_CLIENTE_UTENTI.cgc_creato_da, 
					 CROSS_GRUPPI_CLIENTE_UTENTI.cgc_aggiornato_da,
                     CROSS_GRUPPI_CLIENTE_UTENTI.cgc_eliminato_da
				 	 FROM CROSS_GRUPPI_CLIENTE_UTENTI WHERE 
					 (cgc_id_cross_gruppi_cliente_utenti = @cgc_id_cross_gruppi_cliente_utenti) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "cgc_id_cross_gruppi_cliente_utenti", DbType.Int32, p_cgc_id_cross_gruppi_cliente_utenti);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
                    cgc_id_cross_gruppi_cliente_utenti = reader.GetSqlInt32(0);
					grc_id_gruppi_cliente = reader.GetSqlInt32(1);
					ute_id_utente = reader.GetSqlInt32(2);
					cgc_flag_eliminato = reader.GetSqlInt32(3);
					cgc_data_creazione = reader.GetSqlDateTime(4);
					cgc_data_aggiornamento = reader.GetSqlDateTime(5);
                    cgc_data_eliminazione = reader.GetSqlDateTime(6);
                    cgc_creato_da = reader.GetSqlInt32(7);
					cgc_aggiornato_da = reader.GetSqlInt32(8);
                    cgc_eliminato_da = reader.GetSqlInt32(9);
				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossGruppiClienteUtenti.Read.");
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
		/// Aggiorna l'oggetto nella base dati
		/// </summary>	
		public void Update(SqlInt32 p_cgc_id_cross_gruppi_cliente_utenti)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE 
                                    CROSS_GRUPPI_CLIENTE_UTENTI 
                                SET
					                grc_id_gruppi_cliente = @grc_id_gruppi_cliente, 
					                ute_id_utente = @ute_id_utente, 					  
					                cgc_data_aggiornamento = getdate(), 
					                cgc_aggiornato_da = @cgc_aggiornato_da
					            WHERE   
				                 (cgc_id_cross_gruppi_cliente_utenti = @cgc_id_cross_gruppi_cliente_utenti) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "grc_id_gruppi_cliente", DbType.Int32, grc_id_gruppi_cliente);
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "cgc_aggiornato_da", DbType.Int32, cgc_aggiornato_da);
										
				db.AddInParameter(dbCommand, "cgc_id_cross_gruppi_cliente_utenti", DbType.Int32, p_cgc_id_cross_gruppi_cliente_utenti);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossGruppiClienteUtenti.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}


        

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
		public  void Delete(SqlInt32 p_cgc_id_cross_gruppi_cliente_utenti)
		{
			Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
			DbConnection c =  db.CreateConnection();
			DbTransaction t = null;

			try
			{
				c.Open();
				t = c.BeginTransaction();

				Delete(p_cgc_id_cross_gruppi_cliente_utenti, t);

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
					ex2.Data.Add("Class.Method", "CrossGruppiClienteUtenti.Delete.Rollback");
					ex2.Data.Add("SQL", "Rollback error");
				}
				ex.Data.Add("Class.Method", "CrossGruppiClienteUtenti.Delete.");
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
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public  void Delete(SqlInt32 p_cgc_id_cross_gruppi_cliente_utenti, DbTransaction transaction)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE CROSS_GRUPPI_CLIENTE_UTENTI SET CGC_FLAG_ELIMINATO = 1 WHERE 
					(cgc_id_cross_gruppi_cliente_utenti = @cgc_id_cross_gruppi_cliente_utenti) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "cgc_id_cross_gruppi_cliente_utenti", DbType.Int32, p_cgc_id_cross_gruppi_cliente_utenti);
										
				db.ExecuteNonQuery(dbCommand, transaction);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossGruppiClienteUtenti.Delete.");
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
	
				sqlCommand = @" INSERT INTO CROSS_GRUPPI_CLIENTE_UTENTI (
						grc_id_gruppi_cliente, 
						ute_id_utente, 
						cgc_flag_eliminato, 
						cgc_data_creazione, 
						cgc_creato_da	 ) 
					VALUES ( 
						@grc_id_gruppi_cliente, 
						@ute_id_utente, 
						0, 
						getdate(), 
						@cgc_creato_da	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "grc_id_gruppi_cliente", DbType.Int32, grc_id_gruppi_cliente);
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
				db.AddInParameter(dbCommand, "cgc_creato_da", DbType.Int32, cgc_creato_da);

 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					cgc_id_cross_gruppi_cliente_utenti = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "CrossGruppiClienteUtenti.Create.");
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
        /// Elenca tutti gli elementi CrossGruppiClienteUtenti dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public DataSet List(int id_gruppi_cliente, string subWhereClause) 
		{
			string sqlCommand = null;
			StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
            DataSet ds = new DataSet();
			
			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            
				sb.Append(@" SELECT 
					            CROSS_GRUPPI_CLIENTE_UTENTI.cgc_id_cross_gruppi_cliente_utenti, 
                                CROSS_GRUPPI_CLIENTE_UTENTI.grc_id_gruppi_cliente, 
					            CROSS_GRUPPI_CLIENTE_UTENTI.ute_id_utente, 
					            CROSS_GRUPPI_CLIENTE_UTENTI.cgc_flag_eliminato, 
					            CROSS_GRUPPI_CLIENTE_UTENTI.cgc_data_creazione, 
					            CROSS_GRUPPI_CLIENTE_UTENTI.cgc_data_aggiornamento, 
                                CROSS_GRUPPI_CLIENTE_UTENTI.cgc_data_eliminazione, 
					            CROSS_GRUPPI_CLIENTE_UTENTI.cgc_creato_da, 
					            CROSS_GRUPPI_CLIENTE_UTENTI.cgc_aggiornato_da, 
                                CROSS_GRUPPI_CLIENTE_UTENTI.cgc_eliminato_da, 
                                COALESCE(UTE_COGNOME + ' ' + UTE_NOME,UTE_COGNOME) AS UTENTE
				            FROM 
                                CROSS_GRUPPI_CLIENTE_UTENTI 
                            INNER JOIN UTENTE 
                                ON CROSS_GRUPPI_CLIENTE_UTENTI.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE
                            WHERE 
                                CROSS_GRUPPI_CLIENTE_UTENTI.GRC_ID_GRUPPI_CLIENTE = @id_gruppi_cliente ");	
                			
                sb.Append(" AND CROSS_GRUPPI_CLIENTE_UTENTI.CGC_FLAG_ELIMINATO = 0 ");
                sb.Append(subWhereClause);
                sqlCommand = sb.ToString();
				dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "id_gruppi_cliente", DbType.Int32, id_gruppi_cliente);
				db.LoadDataSet(dbCommand, ds, "CROSS_GRUPPI_CLIENTE_UTENTI");
				
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CrossGruppiClienteUtenti.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}

        /// <summary>
        /// Restuisce elenco dei gruppi a cui appartiene un utente
        /// </summary>
        public DataSet getDdlGruppiCliente(int ute_id_utente)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
                                GRUPPI_CLIENTE.GRC_ID_GRUPPI_CLIENTE, 
                                GRUPPI_CLIENTE.GRC_NOME
                             FROM 
                                CROSS_GRUPPI_CLIENTE_UTENTI
                             INNER JOIN GRUPPI_CLIENTE
                                ON CROSS_GRUPPI_CLIENTE_UTENTI.GRC_ID_GRUPPI_CLIENTE=GRUPPI_CLIENTE.GRC_ID_GRUPPI_CLIENTE
                             WHERE
                                    CROSS_GRUPPI_CLIENTE_UTENTI.UTE_ID_UTENTE=@ute_id_utente AND
                                    CROSS_GRUPPI_CLIENTE_UTENTI.CGC_FLAG_ELIMINATO=0 AND
                                    GRUPPI_CLIENTE.GRC_FLAG_ELIMINATO=0
                             ORDER BY GRUPPI_CLIENTE.GRC_NOME ASC
                                ");

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);

                db.LoadDataSet(dbCommand, ds, "GRUPPI_CLIENTE");

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.getDdlGruppiCliente.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }


        #endregion

    }
}
