#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Gruppi Cliente
// Nome File:   GruppiCliente.cs
//
// Namespace:   BusinessObjects
// Descrizione: Classe per GRUPPI_CLIENTE
//
// Autore:      FB
// Data:        12/02/2019
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
    /// Tabella GRUPPI_CLIENTE 
    /// </summary>
    public class GruppiCliente
    {
		#region attributi e variabili


	    private  SqlInt32 grc_id_gruppi_cliente = SqlInt32.Null;
        private SqlInt32 cli_id_cliente = SqlInt32.Null;
        private SqlString grc_nome = SqlString.Null;
        private SqlString grc_descrizione = SqlString.Null;
        private SqlDateTime grc_data_creazione = SqlDateTime.Null;
        private SqlDateTime grc_data_aggiornamento = SqlDateTime.Null;
        private SqlDateTime grc_data_eliminazione = SqlDateTime.Null;
        private SqlInt32 grc_creato_da = SqlInt32.Null;
        private SqlInt32 grc_aggiornato_da = SqlInt32.Null;
        private SqlInt32 grc_eliminato_da = SqlInt32.Null;
        private SqlInt32 grc_flag_eliminato = SqlInt32.Null;

        private string sqlWhereClause = "";
		private DataSet gruppi_clienteListDS;


		#endregion

		#region Proprieta
		

		
		public  SqlInt32 Grc_id_gruppi_cliente
        {
			get { return grc_id_gruppi_cliente; }
			set { grc_id_gruppi_cliente = value; }
		}

        
        public SqlInt32 Cli_id_cliente
        {
            get { return cli_id_cliente; }
            set { cli_id_cliente = value; }
        }

        public SqlString Grc_nome
        {
            get { return grc_nome; }
            set { grc_nome = value; }
        }

        public SqlString Grc_descrizione
        {
            get { return grc_descrizione; }
            set { grc_descrizione = value; }
        }

        public SqlDateTime Grc_data_creazione
        {
            get { return grc_data_creazione; }
            set { grc_data_creazione = value; }
        }

        public SqlDateTime Grc_data_aggiornamento
        {
            get { return grc_data_aggiornamento; }
            set { grc_data_aggiornamento = value; }
        }

        public SqlDateTime Grc_data_eliminazione
        {
            get { return grc_data_eliminazione; }
            set { grc_data_eliminazione = value; }
        }


        public SqlInt32 Grc_creato_da
        {
            get { return grc_creato_da; }
            set { grc_creato_da = value; }
        }

        public SqlInt32 Grc_aggiornato_da
        {
            get { return grc_aggiornato_da; }
            set { grc_aggiornato_da = value; }
        }

        public  SqlInt32 Grc_eliminato_da
        {
			get { return grc_eliminato_da; }
			set { grc_eliminato_da = value; }
		}


		public SqlInt32 Grc_flag_eliminato
        {
			get { return grc_flag_eliminato; }
			set { grc_flag_eliminato = value; }
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
		/// Elenco degli elementi selezionati
		/// </value>
		public DataSet Gruppi_clienteListDS
        {
			get { return  gruppi_clienteListDS; }
			set { gruppi_clienteListDS = value; }
		}

		#endregion
		
		#region  Costruttori

		/// <summary>
		/// Costruttore standard
		/// </summary>
		public GruppiCliente()
		{
            gruppi_clienteListDS = new DataSet();
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

                sqlCommand = @" SELECT [GRC_ID_GRUPPI_CLIENTE]
                                      ,[CLI_ID_CLIENTE]
                                      ,[GRC_NOME]
                                      ,[GRC_DESCRIZIONE]
                                      ,[GRC_DATA_CREAZIONE]
                                      ,[GRC_DATA_AGGIORNAMENTO]
                                      ,[GRC_DATA_ELIMINAZIONE]
                                      ,[GRC_CREATO_DA]
                                      ,[GRC_AGGIORNATO_DA]
                                      ,[GRC_ELIMINATO_DA]
                                      ,[GRC_FLAG_ELIMINATO]
                                FROM [GRUPPI_CLIENTE] 
                                WHERE
                                    GRC_ID_GRUPPI_CLIENTE = @grc_id_gruppi_cliente ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "grc_id_gruppi_cliente", DbType.Int32, grc_id_gruppi_cliente);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    grc_id_gruppi_cliente = reader.GetSqlInt32(0);
                    cli_id_cliente = reader.GetSqlInt32(1);
                    grc_nome = reader.GetSqlString(2);
                    grc_descrizione = reader.GetSqlString(3);
                    grc_data_creazione = reader.GetSqlDateTime(4);
                    grc_data_aggiornamento = reader.GetSqlDateTime(5);
                    grc_data_eliminazione = reader.GetSqlDateTime(6);
                    grc_creato_da = reader.GetSqlInt32(7);
                    grc_aggiornato_da = reader.GetSqlInt32(8);
                    grc_eliminato_da = reader.GetSqlInt32(9);
                    grc_flag_eliminato = reader.GetSqlInt32(10);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "GruppiCliente.Read.");
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

                sqlCommand = @" UPDATE 
                                    GRUPPI_CLIENTE 
                                SET 
                                    [CLI_ID_CLIENTE] = @cli_id_cliente,
                                    [GRC_NOME] = @grc_nome,
                                    [GRC_DESCRIZIONE] = @grc_descrizione,
                                    [GRC_DATA_AGGIORNAMENTO] = getdate(),
                                    [GRC_AGGIORNATO_DA]= @grc_aggiornato_da
					            WHERE GRC_ID_GRUPPI_CLIENTE = @grc_id_gruppi_cliente ";
			
				dbCommand = db.GetSqlStringCommand(sqlCommand);


                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
				db.AddInParameter(dbCommand, "grc_nome", DbType.String, grc_nome);
                db.AddInParameter(dbCommand, "grc_descrizione", DbType.String, grc_descrizione);										
				db.AddInParameter(dbCommand, "grc_aggiornato_da", DbType.Int32, grc_aggiornato_da);
                db.AddInParameter(dbCommand, "grc_id_gruppi_cliente", DbType.Int32, grc_id_gruppi_cliente);

				
                db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "GruppiCliente.Update.");
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

				sqlCommand = @" UPDATE 
                                    GRUPPI_CLIENTE
                                SET
                                    GRC_FLAG_ELIMINATO=1,
                                    GRC_DATA_ELIMINAZIONE = getdate(),
                                    GRC_ELIMINATO_DA= @grc_eliminato_da
                               WHERE GRC_ID_GRUPPI_CLIENTE = @grc_id_gruppi_cliente;


                               UPDATE 
                                    CROSS_GRUPPI_CLIENTE_UTENTI
                                SET
                                    CGC_FLAG_ELIMINATO=1,
                                    CGC_DATA_ELIMINAZIONE = getdate(),
                                    CGC_ELIMINATO_DA= @grc_eliminato_da
                               WHERE GRC_ID_GRUPPI_CLIENTE = @grc_id_gruppi_cliente";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "grc_id_gruppi_cliente", DbType.Int32, grc_id_gruppi_cliente);
                db.AddInParameter(dbCommand, "grc_eliminato_da", DbType.Int32, grc_eliminato_da);

                db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "GruppiCliente.Delete.");
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
	
				sqlCommand = @" INSERT INTO [dbo].[GRUPPI_CLIENTE]
                                       ([CLI_ID_CLIENTE]
                                       ,[GRC_NOME]
                                       ,[GRC_DESCRIZIONE]
                                       ,[GRC_DATA_CREAZIONE]
                                       ,[GRC_CREATO_DA]
                                       ,[GRC_FLAG_ELIMINATO])
                                 VALUES
                                       (@cli_id_cliente 
                                       ,@grc_nome
                                       ,@grc_descrizione 
                                       ,GETDATE()
                                       ,@grc_creato_da
                                       ,0
                                       );
                                SELECT SCOPE_IDENTITY()
                                "; 
                
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
                db.AddInParameter(dbCommand, "grc_nome", DbType.String, grc_nome);
				db.AddInParameter(dbCommand, "grc_descrizione", DbType.String, grc_descrizione);
				db.AddInParameter(dbCommand, "grc_creato_da", DbType.Int32, grc_creato_da);

                dataReader = db.ExecuteReader(dbCommand);
                if (dataReader.Read())
                {
                    grc_id_gruppi_cliente = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();
			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "GruppiCliente.Create.");
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
        /// Elenca tutti gli elementi GruppiCliente dell'analisi
        /// </summary>
        public DataSet List() 
		{
			string sqlCommand = null;
            DbCommand dbCommand = null;

			try 
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
            
				sqlCommand = @"SELECT 
                                     GRUPPI_CLIENTE.[GRC_ID_GRUPPI_CLIENTE]
                                    ,GRUPPI_CLIENTE.[CLI_ID_CLIENTE]
                                    ,CLIENTI.[CLI_RAGIONE_SOCIALE]
                                    ,GRUPPI_CLIENTE.[GRC_NOME]
                                    ,GRUPPI_CLIENTE.[GRC_DESCRIZIONE]
                                    ,GRUPPI_CLIENTE.[GRC_DATA_CREAZIONE]
                                    ,GRUPPI_CLIENTE.[GRC_DATA_AGGIORNAMENTO]
                                    ,GRUPPI_CLIENTE.[GRC_DATA_ELIMINAZIONE]
                                    ,GRUPPI_CLIENTE.[GRC_CREATO_DA]
                                    ,GRUPPI_CLIENTE.[GRC_AGGIORNATO_DA]
                                    ,GRUPPI_CLIENTE.[GRC_ELIMINATO_DA]
                                    ,GRUPPI_CLIENTE.[GRC_FLAG_ELIMINATO] 
						        FROM 
                                    GRUPPI_CLIENTE 
                                INNER JOIN CLIENTI
                                    ON GRUPPI_CLIENTE.CLI_ID_CLIENTE=CLIENTI.CLI_ID_CLIENTE " + @sqlWhereClause;

				dbCommand = db.GetSqlStringCommand(sqlCommand);
				db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

				db.LoadDataSet(dbCommand, gruppi_clienteListDS, "GRUPPI_CLIENTE");
				return gruppi_clienteListDS; 
			
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "GruppiCliente.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

				return gruppi_clienteListDS; 
			}

			finally
			{	
				if (gruppi_clienteListDS != null)
					((IDisposable)gruppi_clienteListDS).Dispose();
			}
		}
						
        

        

		#endregion

	}
}


