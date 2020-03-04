#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   UnitaContabile.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per UNITACONTABILE
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
	/// Tabella CLIENTI 
	/// </summary>
	public class Clienti
    {
        #region Costanti

        /// <summary>
        /// enum per la Tabella dei Clienti
        /// </summary>
        public enum eCliente
        {
            cliGruppoBain = 12
        }
        #endregion

        #region attributi e variabili

        private SqlInt32 cli_id_cliente = SqlInt32.Null;
	    private SqlString cli_ragione_sociale = SqlString.Null;
	    private SqlString tpi_acronimo = SqlString.Null;        
        private SqlInt32 tpi_id_tipo_installazione = SqlInt32.Null;
        private SqlString cli_indirizzo = SqlString.Null;
        private SqlString cli_citta = SqlString.Null;
        private SqlString cli_email = SqlString.Null;
        private SqlString cli_telefono = SqlString.Null;
        private SqlString cli_fax = SqlString.Null;
        private SqlString cli_cus_cod_tfs = SqlString.Null;
        private SqlString cli_cus_grp_cod = SqlString.Null;
        private SqlString cli_dominio_mail = SqlString.Null;
        private SqlString cli_password_reset = SqlString.Null;
        private SqlInt32 cli_versione_reporting = SqlInt32.Null;
        private SqlInt32 cli_versione_taf = SqlInt32.Null;
        private SqlString cli_link_taf = SqlString.Null;
        private SqlString cli_logo_cliente = SqlString.Null;
        private SqlString cli_acronimo = SqlString.Null;
        private SqlInt32 cli_flag_vis_logo_home_page = SqlInt32.Null;
        private SqlInt32 cli_flag_stato = SqlInt32.Null;
        private SqlString cli_nota_home = SqlString.Null;
        private SqlInt32 cli_flag_calendario_generato = SqlInt32.Null;
        private SqlInt32 cli_alert_number_of_day = SqlInt32.Null;
        private SqlString cli_list_status_filter = SqlString.Null;
        private SqlInt32 ute_id_utente = SqlInt32.Null;
        private SqlInt32 cli_hide_riv_number_of_day = SqlInt32.Null;

        private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cli_id_cliente
		{
			get { return cli_id_cliente; }	
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cli_ragione_sociale
		{
			get { return cli_ragione_sociale; }	
			set { cli_ragione_sociale = value; }
		}

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_logo_cliente
        {
            get { return cli_logo_cliente; }
            set { cli_logo_cliente = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_acronimo
        {
            get { return cli_acronimo; }
            set { cli_acronimo = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_link_taf
        {
            get { return cli_link_taf; }
            set { cli_link_taf = value; }
        }

		/// <value>
		/// 
		/// </value>
		public SqlString Tpi_acronimo
		{
			get { return tpi_acronimo; }	
			set { tpi_acronimo = value; }
		}
        

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Tpi_id_tipo_installazione
        {
            get { return tpi_id_tipo_installazione; }
            set { tpi_id_tipo_installazione = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_indirizzo
        {
            get { return cli_indirizzo; }
            set { cli_indirizzo = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_citta
        {
            get { return cli_citta; }
            set { cli_citta = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_telefono
        {
            get { return cli_telefono; }
            set { cli_telefono = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_email
        {
            get { return cli_email; }
            set { cli_email = value; }
        }
        
        /// <value>
        /// 
        /// </value>
        public SqlString Cli_dominio_mail
        {
            get { return cli_dominio_mail; }
            set { cli_dominio_mail = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_password_reset
        {
            get { return cli_password_reset; }
            set { cli_password_reset = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_fax
        {
            get { return cli_fax; }
            set { cli_fax = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_cus_cod_tfs
        {
            get { return cli_cus_cod_tfs; }
            set { cli_cus_cod_tfs = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_cus_grp_cod
        {
            get { return cli_cus_grp_cod; }
            set { cli_cus_grp_cod = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cli_versione_reporting
        {
            get { return cli_versione_reporting; }
            set { cli_versione_reporting = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cli_versione_taf
        {
            get { return cli_versione_taf; }
            set { cli_versione_taf = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cli_flag_vis_logo_home_page
        {
            get { return cli_flag_vis_logo_home_page; }
            set { cli_flag_vis_logo_home_page = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cli_flag_stato
        {
            get { return cli_flag_stato; }
            set { cli_flag_stato = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_nota_home
        {
            get { return cli_nota_home; }
            set { cli_nota_home = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cli_flag_calendario_generato
        {
            get { return cli_flag_calendario_generato; }
            set { cli_flag_calendario_generato = value; }
        }
        
        /// <value>
        /// 
        /// </value>
        public SqlInt32 Cli_alert_number_of_day
        {
            get { return cli_alert_number_of_day; }
            set { cli_alert_number_of_day = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Cli_list_status_filter
        {
            get { return cli_list_status_filter; }
            set { cli_list_status_filter = value; }
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
        public SqlInt32 Cli_hide_riv_number_of_day
        {
            get { return cli_hide_riv_number_of_day; }
            set { cli_hide_riv_number_of_day = value; }
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
		public Clienti()
		{

		}
		#endregion
		
		#region Metodi		

        public void Read(SqlString p_cli_cus_grp_cod)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            cli_id_cliente = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT
					            CLIENTI.cli_id_cliente
					            FROM CLIENTI
                                WHERE cli_cus_grp_cod = @cli_cus_grp_cod";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "cli_cus_grp_cod", DbType.String, p_cli_cus_grp_cod);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    cli_id_cliente = reader.GetSqlInt32(0);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.Read.");
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
        
        public void Read(SqlInt32 p_cli_id_cliente, string qCultureInfo)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
                                    CLIENTI.cli_id_cliente, 
                                    CLIENTI.cli_ragione_sociale, 
                                    LOOKUP_TIPO_INSTALLAZIONE.tpi_id_tipo_installazione,
                                    cli_telefono,
                                    cli_fax,cli_email,
                                    cli_indirizzo,
                                    cli_citta,cli_cus_cod_tfs,
                                    cli_cus_grp_cod,
                                    cli_dominio_mail,
                                    cli_versione_reporting,
                                    cli_password_reset,
                                    cli_link_taf,
                                    cli_logo_cliente,
                                    cli_acronimo,
                                    cli_flag_vis_logo_home_page,
                                    cli_flag_stato,
                                    cli_versione_taf,
                                    cli_alert_number_of_day,
                                    cli_list_status_filter, ";

                if (qCultureInfo == "it")
                    sqlCommand += "cli_nota_home as cli_nota_home";
                else
                    sqlCommand += "cli_nota_home_en as cli_nota_home";
				 	
                sqlCommand += @" FROM CLIENTI 
                     INNER JOIN LOOKUP_TIPO_INSTALLAZIONE ON CLIENTI.TPI_ID_TIPO_INSTALLAZIONE = LOOKUP_TIPO_INSTALLAZIONE.TPI_ID_TIPO_INSTALLAZIONE
                     WHERE (cli_id_cliente = @cli_id_cliente) ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);
				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
                    cli_id_cliente = reader.GetSqlInt32(0);
					cli_ragione_sociale = reader.GetSqlString(1);
                    tpi_id_tipo_installazione = reader.GetSqlInt32(2);                    
                    cli_telefono = reader.GetSqlString(3);
                    cli_fax = reader.GetSqlString(4);
                    cli_email = reader.GetSqlString(5);
                    cli_indirizzo = reader.GetSqlString(6);
                    cli_citta = reader.GetSqlString(7);
                    cli_cus_cod_tfs = reader.GetSqlString(8);
                    cli_cus_grp_cod = reader.GetSqlString(9);
                    cli_dominio_mail = reader.GetSqlString(10);
                    cli_versione_reporting = reader.GetSqlInt32(11);
                    cli_password_reset = reader.GetSqlString(12);
                    cli_link_taf = reader.GetSqlString(13);
                    cli_logo_cliente = reader.GetSqlString(14);
                    cli_acronimo = reader.GetSqlString(15);
                    cli_flag_vis_logo_home_page = reader.GetSqlInt32(16);
                    cli_flag_stato = reader.GetSqlInt32(17);
                    cli_versione_taf = reader.GetSqlInt32(18);
                    cli_alert_number_of_day = reader.GetSqlInt32(19);
                    cli_list_status_filter = reader.GetSqlString(20);
                    cli_nota_home = reader.GetSqlString(21);
				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "Clienti.Read.");
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
        public void Update(SqlInt32 p_cli_id_cliente)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE CLIENTI SET
					 cli_ragione_sociale = @cli_ragione_sociale, 
                     cli_indirizzo = @cli_indirizzo, 
                     cli_telefono = @cli_telefono, 
                     cli_fax = @cli_fax, 
                     cli_email = @cli_email, 
                     cli_dominio_mail = @cli_dominio_mail, 
                     cli_citta = @cli_citta,                      
                     cli_cus_cod_tfs = @cli_cus_cod_tfs,                      
                     cli_cus_grp_cod = @cli_cus_grp_cod,                      
					 tpi_id_tipo_installazione = @tpi_id_tipo_installazione,
                     cli_versione_reporting = @cli_versione_reporting,
                     cli_password_reset = @cli_password_reset,
                     cli_link_taf = @cli_link_taf,
                     cli_acronimo = @cli_acronimo,
                     cli_logo_cliente = @cli_logo_cliente,
                     cli_flag_vis_logo_home_page = @cli_flag_vis_logo_home_page,
                     cli_flag_stato = @cli_flag_stato,
                     cli_versione_taf = @cli_versione_taf,
                     cli_nota_home = @cli_nota_home

					 WHERE   
				     (cli_id_cliente = @cli_id_cliente) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cli_ragione_sociale", DbType.String, cli_ragione_sociale);
                db.AddInParameter(dbCommand, "tpi_id_tipo_installazione", DbType.Int32, tpi_id_tipo_installazione);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);
                db.AddInParameter(dbCommand, "cli_versione_reporting", DbType.Int32, cli_versione_reporting);
                db.AddInParameter(dbCommand, "cli_indirizzo", DbType.String, cli_indirizzo);
                db.AddInParameter(dbCommand, "cli_telefono", DbType.String, cli_telefono);
                db.AddInParameter(dbCommand, "cli_fax", DbType.String, cli_fax);
                db.AddInParameter(dbCommand, "cli_email", DbType.String, cli_email);
                db.AddInParameter(dbCommand, "cli_dominio_mail", DbType.String, cli_dominio_mail);
                db.AddInParameter(dbCommand, "cli_citta", DbType.String, cli_citta);
                db.AddInParameter(dbCommand, "cli_cus_cod_tfs", DbType.String, cli_cus_cod_tfs);
                db.AddInParameter(dbCommand, "cli_cus_grp_cod", DbType.String, cli_cus_grp_cod);
                db.AddInParameter(dbCommand, "cli_password_reset", DbType.String, cli_password_reset);
                db.AddInParameter(dbCommand, "cli_link_taf", DbType.String, cli_link_taf);
                db.AddInParameter(dbCommand, "cli_acronimo", DbType.String, cli_acronimo);
                db.AddInParameter(dbCommand, "cli_logo_cliente", DbType.String, cli_logo_cliente);
                db.AddInParameter(dbCommand, "cli_flag_vis_logo_home_page", DbType.Int32, cli_flag_vis_logo_home_page);
                db.AddInParameter(dbCommand, "cli_flag_stato", DbType.Int32, cli_flag_stato);
                db.AddInParameter(dbCommand, "cli_versione_taf", DbType.Int32, cli_versione_taf);
                db.AddInParameter(dbCommand, "cli_nota_home", DbType.String, cli_nota_home);
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Clienti.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

        public void UpdateFlagCalendarioGenerato(SqlInt32 p_cli_id_cliente)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE CLIENTI SET					 
                     cli_flag_calendario_generato = 1
					 WHERE   
				     (cli_id_cliente = @cli_id_cliente) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                
                db.AddInParameter(dbCommand, "cli_flag_calendario_generato", DbType.Int32, cli_flag_calendario_generato);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);                
                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.UpdateFlagCalendarioGenerato.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        public void UpdateFlagCalendarioGenerato(SqlInt32 p_cli_id_cliente,SqlInt32 p_flag_calendario_generato)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE CLIENTI SET					 
                     cli_flag_calendario_generato = @cli_flag_calendario_generato
					 WHERE   
				     (cli_id_cliente = @cli_id_cliente) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);


                db.AddInParameter(dbCommand, "cli_flag_calendario_generato", DbType.Int32, p_flag_calendario_generato);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);
                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.UpdateFlagCalendarioGenerato.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }
      
		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public void Delete(SqlInt32 p_cli_id_cliente)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM CLIENTI WHERE 
					(cli_id_cliente = @cli_id_cliente) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Clienti.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

        /// <summary>
        /// Cancella l'oggetto dalla base dati.
        /// </summary>
        public void DeleteCustomerDTF(SqlInt32 p_cli_id_cliente)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE FROM CLIENTI_ECCEZIONE_RIC WHERE 
					(cli_id_cliente = @cli_id_cliente) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.DeleteCustomerDTF.");
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
	
				sqlCommand = @" INSERT INTO CLIENTI (
						cli_ragione_sociale,
                        cli_indirizzo,cli_citta,cli_telefono,cli_fax,cli_email,cli_dominio_mail, 
						tpi_id_tipo_installazione,cli_cus_cod_tfs,cli_cus_grp_cod,cli_versione_reporting,cli_password_reset,
                        cli_link_taf,cli_acronimo,cli_logo_cliente,cli_flag_vis_logo_home_page,cli_flag_stato,cli_versione_taf,cli_nota_home) 
					VALUES ( 
						@cli_ragione_sociale,
                        @cli_indirizzo,@cli_citta,@cli_telefono,@cli_fax,@cli_email,@cli_dominio_mail, 
						@tpi_id_tipo_installazione,@cli_cus_cod_tfs,@cli_cus_grp_cod,@cli_versione_reporting,@cli_password_reset,
                        @cli_link_taf,@cli_acronimo,@cli_logo_cliente,@cli_flag_vis_logo_home_page,@cli_flag_stato,@cli_versione_taf,@cli_nota_home) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cli_ragione_sociale", DbType.String, cli_ragione_sociale);
                db.AddInParameter(dbCommand, "tpi_id_tipo_installazione", DbType.Int32, tpi_id_tipo_installazione);
                db.AddInParameter(dbCommand, "cli_versione_reporting", DbType.Int32, cli_versione_reporting);
                db.AddInParameter(dbCommand, "cli_indirizzo", DbType.String, cli_indirizzo);
                db.AddInParameter(dbCommand, "cli_telefono", DbType.String, cli_telefono);
                db.AddInParameter(dbCommand, "cli_fax", DbType.String, cli_fax);
                db.AddInParameter(dbCommand, "cli_email", DbType.String, cli_email);
                db.AddInParameter(dbCommand, "cli_dominio_mail", DbType.String, cli_dominio_mail);
                db.AddInParameter(dbCommand, "cli_citta", DbType.String, cli_citta);
                db.AddInParameter(dbCommand, "cli_cus_cod_tfs", DbType.String, cli_cus_cod_tfs);
                db.AddInParameter(dbCommand, "cli_cus_grp_cod", DbType.String, cli_cus_grp_cod);
                db.AddInParameter(dbCommand, "cli_password_reset", DbType.String, cli_password_reset);
                db.AddInParameter(dbCommand, "cli_link_taf", DbType.String, cli_link_taf);
                db.AddInParameter(dbCommand, "cli_acronimo", DbType.String, cli_acronimo);
                db.AddInParameter(dbCommand, "cli_logo_cliente", DbType.String, cli_logo_cliente);
                db.AddInParameter(dbCommand, "cli_flag_vis_logo_home_page", DbType.Int32, cli_flag_vis_logo_home_page);
                db.AddInParameter(dbCommand, "cli_flag_stato", DbType.Int32, cli_flag_stato);
                db.AddInParameter(dbCommand, "cli_versione_taf", DbType.Int32, cli_versione_taf);
                db.AddInParameter(dbCommand, "cli_nota_home", DbType.String, cli_nota_home);
                
 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
                    cli_id_cliente = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "Clienti.Create.");
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
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void CreateCustomerDTF(Int32 p_cli_id_cliente, String p_cus_grp_cod)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO CLIENTI_ECCEZIONE_RIC (cli_id_cliente,
						cer_cus_cod_tfs,cer_descrizione) 
					SELECT  
						@cli_id_cliente,
                        cus_cod,
                        cus_name
                    FROM CUSTOMER
                    WHERE CUS_GRP_COD = @cus_grp_cod
				        ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);
                db.AddInParameter(dbCommand, "cus_grp_cod", DbType.String, p_cus_grp_cod);
                dataReader = db.ExecuteReader(dbCommand);
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.CreateCustomerDTF.");
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
        /// Crea l'oggetto corrispondente nella base dati.
        /// </summary>
        public void CreateServiceDTF()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" INSERT INTO SERVIZI_PER_RIC (cli_id_cliente,
						lss_id_servizio) 
					SELECT  
						@cli_id_cliente,
                        lss_id_servizio                        
                    FROM LOOKUP_SERVIZI ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
                dataReader = db.ExecuteReader(dbCommand);
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.CreateServiceDTF.");
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
        /// Elenca tutti gli elementi UnitaContabile dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "CLIENTI");
        }
		/// <summary>
		/// Elenca tutti gli elementi UnitaContabile dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"CLIENTI");
		}
		/// <summary>
		/// Elenca tutti gli elementi UnitaContabile dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					CLIENTI.cli_id_cliente, 
					CLIENTI.cli_ragione_sociale, 
                    CLIENTI.cli_acronimo,
					LOOKUP_TIPO_INSTALLAZIONE.tpi_acronimo,cli_dominio_mail,
                    LOOKUP_TIPO_INSTALLAZIONE.tpi_descrizione,cli_indirizzo,cli_email,cli_telefono,cli_citta,cli_versione_reporting,cli_password_reset,
                    cli_link_taf,cli_flag_vis_logo_home_page,cli_flag_stato,cli_versione_taf,cli_flag_calendario_generato

				    FROM CLIENTI 
                    INNER JOIN LOOKUP_TIPO_INSTALLAZIONE ON CLIENTI.TPI_ID_TIPO_INSTALLAZIONE = LOOKUP_TIPO_INSTALLAZIONE.TPI_ID_TIPO_INSTALLAZIONE ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["CLIENTI"].Columns["cli_id_cliente"];
                ds.Tables["CLIENTI"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Clienti.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}


        /// <summary>
        /// Elenca tutti gli elementi UnitaContabile dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public DataSet getDdlClienti()
        {
            return getDdlClienti(string.Empty, "CLIENTI");
        }
        /// <summary>
        /// Elenca tutti gli elementi UnitaContabile dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public DataSet getDdlClienti(string sqlWhereClause)
        {
            return getDdlClienti(sqlWhereClause, "CLIENTI");
        }
        /// <summary>
        /// Elenca tutti gli elementi UnitaContabile dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public DataSet getDdlClienti(string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
                                CLIENTI.cli_id_cliente, 
                                CLIENTI.cli_ragione_sociale
                                FROM CLIENTI
                                ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sb.Append(" ORDER BY CLI_RAGIONE_SOCIALE ASC " );

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                
                db.LoadDataSet(dbCommand, ds, tableName);

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["CLIENTI"].Columns["cli_id_cliente"];
                ds.Tables["CLIENTI"].PrimaryKey = keys;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.getDdlClienti.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Elenca tutti gli elementi UnitaContabile dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet getListTipoInstallazione()
        {
            return getListTipoInstallazione(string.Empty, "LOOKUP_TIPO_INSTALLAZIONE");
        }
        /// <summary>
        /// Elenca tutti gli elementi UnitaContabile dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
        /// </summary>
        public static DataSet getListTipoInstallazione(string sqlWhereClause)
        {
            return getListTipoInstallazione(sqlWhereClause, "LOOKUP_TIPO_INSTALLAZIONE");
        }
        /// <summary>
        /// Elenca tutti gli elementi UnitaContabile dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet getListTipoInstallazione(string sqlWhereClause, string tableName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 
					TPI_ID_TIPO_INSTALLAZIONE, 
					TPI_DESCRIZIONE 					
                    FROM LOOKUP_TIPO_INSTALLAZIONE ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, tableName);

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["LOOKUP_TIPO_INSTALLAZIONE"].Columns["TPI_ID_TIPO_INSTALLAZIONE"];
                ds.Tables["LOOKUP_TIPO_INSTALLAZIONE"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.getListTipoInstallazione.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Elenca tutti gli elementi UnitaContabile dell'analisi. L'utente può scegliere il nome della tabella nel dataset
        /// </summary>
        public static DataSet getListSottoClienti(string strWhereClause)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT DISTINCT
					CER_CUS_COD_TFS, 
					CER_DESCRIZIONE 					
                    FROM CLIENTI_ECCEZIONE_RIC 
                    INNER JOIN CLIENTI ON CLIENTI_ECCEZIONE_RIC.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE ");

                sb.Append(strWhereClause);                    

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);                
                db.LoadDataSet(dbCommand, ds, "CLIENTI_ECCEZIONE_RIC");               
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.getListSottoClienti.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        /// <summary>
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void RicavaCliente(SqlInt32 p_riv_id_richiesta)


        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 					 
                                CLIENTI.cli_id_cliente,
                                CLIENTI.cli_ragione_sociale,
                                LOOKUP_TIPO_INSTALLAZIONE.tpi_acronimo,
                                CLIENTI.cli_acronimo                                
                                FROM CLIENTI 
                                INNER JOIN UTENTE ON UTENTE.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE
                                INNER JOIN RICHIEDENTE ON UTENTE.UTE_ID_UTENTE = RICHIEDENTE.UTE_ID_UTENTE
                                INNER JOIN RICHIESTA_VIAGGIO ON RICHIEDENTE.RIV_ID_RICHIESTA = RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA
                                INNER JOIN LOOKUP_TIPO_INSTALLAZIONE ON CLIENTI.TPI_ID_TIPO_INSTALLAZIONE = LOOKUP_TIPO_INSTALLAZIONE.TPI_ID_TIPO_INSTALLAZIONE
                                WHERE 
					            (RICHIESTA_VIAGGIO.RIV_ID_RICHIESTA = @riv_id_richiesta) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, p_riv_id_richiesta);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    cli_id_cliente = reader.GetSqlInt32(0);
                    cli_ragione_sociale = reader.GetSqlString(1);
                    tpi_acronimo = reader.GetSqlString(2);
                    cli_acronimo = reader.GetSqlString(3);                    
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.Read.");
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
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void RicavaCliente(SqlString p_acronimo_cliente)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;
            cli_id_cliente = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 					 
                                CLI_ID_CLIENTE
                                FROM CLIENTI                                 
                                WHERE 
					            CLI_ACRONIMO = @acronimo_cliente ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "acronimo_cliente", DbType.String, p_acronimo_cliente);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    cli_id_cliente = reader.GetSqlInt32(0);                    
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.RicavaCliente.");
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
        /// Legge i dati per l'oggetto dalla base dati
        /// </summary>
        public void RicavaClienteUtente(SqlInt32 p_idUtente)
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT 					 
                                CLIENTI.cli_id_cliente,
                                CLIENTI.cli_ragione_sociale,
                                CLIENTI.cli_acronimo                                
                                FROM CLIENTI 
                                INNER JOIN UTENTE ON UTENTE.CLI_ID_CLIENTE = CLIENTI.CLI_ID_CLIENTE                                
                                WHERE UTENTE.UTE_ID_UTENTE = @ute_id_utente ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, p_idUtente);
                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                while (reader.Read())
                {
                    cli_id_cliente = reader.GetSqlInt32(0);
                    cli_ragione_sociale = reader.GetSqlString(1);                    
                    cli_acronimo = reader.GetSqlString(2);                    
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.RicavaClienteUtente.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));                
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }
        }

        public void UpdateStateCustomerUser(SqlInt32 p_cli_id_cliente,bool p_stato)
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            //int stato = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                //if (p_stato)
                //    stato = 1;
                //else
                //    stato = 0;
                    
                sqlCommand = @" UPDATE UTENTE SET
					 UTE_STATO_UTENTE = @stato
					 WHERE   
				     (cli_id_cliente = @cli_id_cliente) 
					 ";
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, p_cli_id_cliente);
                db.AddInParameter(dbCommand, "stato", DbType.Boolean, p_stato);                
                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.UpdateStateCustomerUser.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
        }

        public static DataSet getGruppo()
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@"    SELECT DISTINCT
                                CLI_CUS_GRP_COD,CUS_NAME
                                FROM CLIENTI  					
                                INNER JOIN 
                                CUSTOMER ON CLIENTI.CLI_CUS_GRP_COD = CUSTOMER.CUS_COD");
                sb.Append(@" WHERE CLI_FLAG_STATO = 1 ");
                sb.Append(" ORDER BY CUS_NAME ASC ");
                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.LoadDataSet(dbCommand, ds, "CLIENTI");                
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.getGruppo.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }

        public bool rigeneraCalendario(int idCliente,int anno)
        {
            DbCommand dbCommand = null;            
            bool calendarioGenerato = false;            
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");              
               
                dbCommand = db.GetStoredProcCommand("spWF_Populate_customer_calendar");
                db.AddInParameter(dbCommand, "Anno", DbType.Int32, anno);
                db.AddInParameter(dbCommand, "id_cliente", DbType.Int32, idCliente);
                db.ExecuteNonQuery(dbCommand);

                calendarioGenerato = true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.rigeneraCalendario.");
                ex.Data.Add("SQL", ex.Message);
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            return calendarioGenerato;
        }

        public bool generaCalendarioStandard(int idCliente, int anno)
        {
            DbCommand dbCommand = null;
            bool calendarioGenerato = false;
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");


                dbCommand = db.GetStoredProcCommand("spWF_Populate_standard_calendar");
                db.AddInParameter(dbCommand, "id_cliente", DbType.Int32, idCliente);
                db.ExecuteNonQuery(dbCommand);

                dbCommand = db.GetStoredProcCommand("spWF_Populate_customer_calendar");
                db.AddInParameter(dbCommand, "Anno", DbType.Int32, anno);
                db.AddInParameter(dbCommand, "id_cliente", DbType.Int32, idCliente);
                db.ExecuteNonQuery(dbCommand);

                calendarioGenerato = true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Clienti.generaCalendarioStandard.");
                ex.Data.Add("SQL", ex.Message);
                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }
            return calendarioGenerato;
        }

		#endregion

	}
}
