#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   Customer.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per CUSTOMER
//
// Autore:      AR - SDG srl
// Data:        21/07/2010
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
	/// Tabella CUSTOMER 
	/// </summary>
	public class Customer
	{
		#region attributi e variabili

	    private SqlString cus_cod = SqlString.Null;
	    private SqlString stp_cod = SqlString.Null;
	    private SqlString cou_cod = SqlString.Null;
	    private SqlString cus_grp_cod = SqlString.Null;
	    private SqlString bro_cod = SqlString.Null;
	    private SqlString cus_acc_cod = SqlString.Null;
	    private SqlString cus_wwo_cod = SqlString.Null;
	    private SqlString cus_name = SqlString.Null;
	    private SqlString cus_addr = SqlString.Null;
	    private SqlString cus_city = SqlString.Null;
	    private SqlString cus_zip = SqlString.Null;
	    private SqlString cus_phone = SqlString.Null;
	    private SqlString cus_fax = SqlString.Null;
	    private SqlString cus_email = SqlString.Null;
	    private SqlString cus_pi = SqlString.Null;
	    private SqlString cus_cf = SqlString.Null;
	    private SqlInt16 cus_priv_ind = SqlInt16.Null;
	    private SqlInt16 cus_valid_ind = SqlInt16.Null;
	    private SqlString cus_galileo_bar = SqlString.Null;
	    private SqlDateTime la_time = SqlDateTime.Null;
	    private SqlString la_user = SqlString.Null;
	    private SqlInt16 cus_inv_heading_ind = SqlInt16.Null;
	    private SqlInt16 cus_auto_print_ind = SqlInt16.Null;
	    private SqlString cus_name_est = SqlString.Null;
	    private SqlString cus_addr_est = SqlString.Null;
	    private SqlString cus_city_est = SqlString.Null;
	    private SqlString cus_zip_est = SqlString.Null;
	    private SqlString cus_stp_cod_est = SqlString.Null;
	    private SqlString cus_cou_cod_est = SqlString.Null;
	    private SqlString cus_rif_est = SqlString.Null;
	    private SqlString cus_pi_est = SqlString.Null;
	    private SqlString cus_cf_est = SqlString.Null;
	    private SqlString cus_email_est = SqlString.Null;
	    private SqlString cus_refer_ec_person = SqlString.Null;
	    private SqlString cus_format_email = SqlString.Null;
	    private SqlInt16 cus_send_email_man_ind = SqlInt16.Null;
	    private SqlInt16 cus_send_email_auto_ind = SqlInt16.Null;
	    private SqlString cus_invoice_email = SqlString.Null;
	    private SqlString cus_invoice_email_bcc = SqlString.Null;
	    private SqlInt16 cus_send_email_ec_ind = SqlInt16.Null;
	    private SqlString cus_send_email_ec = SqlString.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_cod
		{
			get { return cus_cod; }	
			set { cus_cod = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Stp_cod
		{
			get { return stp_cod; }	
			set { stp_cod = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cou_cod
		{
			get { return cou_cod; }	
			set { cou_cod = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_grp_cod
		{
			get { return cus_grp_cod; }	
			set { cus_grp_cod = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Bro_cod
		{
			get { return bro_cod; }	
			set { bro_cod = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_acc_cod
		{
			get { return cus_acc_cod; }	
			set { cus_acc_cod = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_wwo_cod
		{
			get { return cus_wwo_cod; }	
			set { cus_wwo_cod = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_name
		{
			get { return cus_name; }	
			set { cus_name = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_addr
		{
			get { return cus_addr; }	
			set { cus_addr = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_city
		{
			get { return cus_city; }	
			set { cus_city = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_zip
		{
			get { return cus_zip; }	
			set { cus_zip = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_phone
		{
			get { return cus_phone; }	
			set { cus_phone = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_fax
		{
			get { return cus_fax; }	
			set { cus_fax = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_email
		{
			get { return cus_email; }	
			set { cus_email = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_pi
		{
			get { return cus_pi; }	
			set { cus_pi = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_cf
		{
			get { return cus_cf; }	
			set { cus_cf = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt16  Cus_priv_ind
		{
			get { return cus_priv_ind; }	
			set { cus_priv_ind = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt16 Cus_valid_ind
		{
			get { return cus_valid_ind; }	
			set { cus_valid_ind = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_galileo_bar
		{
			get { return cus_galileo_bar; }	
			set { cus_galileo_bar = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlDateTime La_time
		{
			get { return la_time; }	
			set { la_time = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString La_user
		{
			get { return la_user; }	
			set { la_user = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt16  Cus_inv_heading_ind
		{
			get { return cus_inv_heading_ind; }	
			set { cus_inv_heading_ind = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt16  Cus_auto_print_ind
		{
			get { return cus_auto_print_ind; }	
			set { cus_auto_print_ind = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_name_est
		{
			get { return cus_name_est; }	
			set { cus_name_est = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_addr_est
		{
			get { return cus_addr_est; }	
			set { cus_addr_est = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_city_est
		{
			get { return cus_city_est; }	
			set { cus_city_est = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_zip_est
		{
			get { return cus_zip_est; }	
			set { cus_zip_est = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_stp_cod_est
		{
			get { return cus_stp_cod_est; }	
			set { cus_stp_cod_est = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_cou_cod_est
		{
			get { return cus_cou_cod_est; }	
			set { cus_cou_cod_est = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_rif_est
		{
			get { return cus_rif_est; }	
			set { cus_rif_est = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_pi_est
		{
			get { return cus_pi_est; }	
			set { cus_pi_est = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_cf_est
		{
			get { return cus_cf_est; }	
			set { cus_cf_est = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_email_est
		{
			get { return cus_email_est; }	
			set { cus_email_est = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_refer_ec_person
		{
			get { return cus_refer_ec_person; }	
			set { cus_refer_ec_person = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_format_email
		{
			get { return cus_format_email; }	
			set { cus_format_email = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt16  Cus_send_email_man_ind
		{
			get { return cus_send_email_man_ind; }	
			set { cus_send_email_man_ind = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt16  Cus_send_email_auto_ind
		{
			get { return cus_send_email_auto_ind; }	
			set { cus_send_email_auto_ind = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_invoice_email
		{
			get { return cus_invoice_email; }	
			set { cus_invoice_email = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_invoice_email_bcc
		{
			get { return cus_invoice_email_bcc; }	
			set { cus_invoice_email_bcc = value; }
		}

		/// <value>
		/// 
		/// </value>
        public SqlInt16 Cus_send_email_ec_ind
		{
			get { return cus_send_email_ec_ind; }	
			set { cus_send_email_ec_ind = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cus_send_email_ec
		{
			get { return cus_send_email_ec; }	
			set { cus_send_email_ec = value; }
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
		public Customer()
		{

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
					 CUSTOMER.CUS_COD, 
					 CUSTOMER.STP_COD, 
					 CUSTOMER.COU_COD, 
					 CUSTOMER.CUS_GRP_COD, 
					 CUSTOMER.BRO_COD, 
					 CUSTOMER.CUS_ACC_COD, 
					 CUSTOMER.CUS_WWO_COD, 
					 CUSTOMER.CUS_NAME, 
					 CUSTOMER.CUS_ADDR, 
					 CUSTOMER.CUS_CITY, 
					 CUSTOMER.CUS_ZIP, 
					 CUSTOMER.CUS_PHONE, 
					 CUSTOMER.CUS_FAX, 
					 CUSTOMER.CUS_EMAIL, 
					 CUSTOMER.CUS_PI, 
					 CUSTOMER.CUS_CF, 
					 CUSTOMER.CUS_PRIV_IND, 
					 CUSTOMER.CUS_VALID_IND, 
					 CUSTOMER.CUS_GALILEO_BAR, 
					 CUSTOMER.LA_TIME, 
					 CUSTOMER.LA_USER, 
					 CUSTOMER.CUS_INV_HEADING_IND, 
					 CUSTOMER.CUS_AUTO_PRINT_IND, 
					 CUSTOMER.CUS_NAME_EST, 
					 CUSTOMER.CUS_ADDR_EST, 
					 CUSTOMER.CUS_CITY_EST, 
					 CUSTOMER.CUS_ZIP_EST, 
					 CUSTOMER.CUS_STP_COD_EST, 
					 CUSTOMER.CUS_COU_COD_EST, 
					 CUSTOMER.CUS_RIF_EST, 
					 CUSTOMER.CUS_PI_EST, 
					 CUSTOMER.CUS_CF_EST, 
					 CUSTOMER.CUS_EMAIL_EST, 
					 CUSTOMER.CUS_REFER_EC_PERSON, 
					 CUSTOMER.CUS_FORMAT_EMAIL, 
					 CUSTOMER.CUS_SEND_EMAIL_MAN_IND, 
					 CUSTOMER.CUS_SEND_EMAIL_AUTO_IND, 
					 CUSTOMER.CUS_INVOICE_EMAIL, 
					 CUSTOMER.CUS_INVOICE_EMAIL_BCC, 
					 CUSTOMER.CUS_SEND_EMAIL_EC_IND, 
					 CUSTOMER.CUS_SEND_EMAIL_EC	 
				 	 FROM CUSTOMER WHERE 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					cus_cod = reader.GetSqlString(0);
					stp_cod = reader.GetSqlString(1);
					cou_cod = reader.GetSqlString(2);
					cus_grp_cod = reader.GetSqlString(3);
					bro_cod = reader.GetSqlString(4);
					cus_acc_cod = reader.GetSqlString(5);
					cus_wwo_cod = reader.GetSqlString(6);
					cus_name = reader.GetSqlString(7);
					cus_addr = reader.GetSqlString(8);
					cus_city = reader.GetSqlString(9);
					cus_zip = reader.GetSqlString(10);
					cus_phone = reader.GetSqlString(11);
					cus_fax = reader.GetSqlString(12);
					cus_email = reader.GetSqlString(13);
					cus_pi = reader.GetSqlString(14);
					cus_cf = reader.GetSqlString(15);
					cus_priv_ind = reader.GetSqlInt16(16);
					cus_valid_ind = reader.GetSqlInt16(17);
					cus_galileo_bar = reader.GetSqlString(18);
					la_time = reader.GetSqlDateTime(19);
					la_user = reader.GetSqlString(20);
					cus_inv_heading_ind = reader.GetSqlInt16(21);
					cus_auto_print_ind = reader.GetSqlInt16(22);
					cus_name_est = reader.GetSqlString(23);
					cus_addr_est = reader.GetSqlString(24);
					cus_city_est = reader.GetSqlString(25);
					cus_zip_est = reader.GetSqlString(26);
					cus_stp_cod_est = reader.GetSqlString(27);
					cus_cou_cod_est = reader.GetSqlString(28);
					cus_rif_est = reader.GetSqlString(29);
					cus_pi_est = reader.GetSqlString(30);
					cus_cf_est = reader.GetSqlString(31);
					cus_email_est = reader.GetSqlString(32);
					cus_refer_ec_person = reader.GetSqlString(33);
					cus_format_email = reader.GetSqlString(34);
					cus_send_email_man_ind = reader.GetSqlInt16(35);
					cus_send_email_auto_ind = reader.GetSqlInt16(36);
					cus_invoice_email = reader.GetSqlString(37);
					cus_invoice_email_bcc = reader.GetSqlString(38);
                    cus_send_email_ec_ind = reader.GetSqlInt16(39);
					cus_send_email_ec = reader.GetSqlString(40);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "Customer.Read.");
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

				sqlCommand = @" UPDATE CUSTOMER SET
					 CUS_COD = @cus_cod, 
					 STP_COD = @stp_cod, 
					 COU_COD = @cou_cod, 
					 CUS_GRP_COD = @cus_grp_cod, 
					 BRO_COD = @bro_cod, 
					 CUS_ACC_COD = @cus_acc_cod, 
					 CUS_WWO_COD = @cus_wwo_cod, 
					 CUS_NAME = @cus_name, 
					 CUS_ADDR = @cus_addr, 
					 CUS_CITY = @cus_city, 
					 CUS_ZIP = @cus_zip, 
					 CUS_PHONE = @cus_phone, 
					 CUS_FAX = @cus_fax, 
					 CUS_EMAIL = @cus_email, 
					 CUS_PI = @cus_pi, 
					 CUS_CF = @cus_cf, 
					 CUS_PRIV_IND = @cus_priv_ind, 
					 CUS_VALID_IND = @cus_valid_ind, 
					 CUS_GALILEO_BAR = @cus_galileo_bar, 
					 LA_TIME = @la_time, 
					 LA_USER = @la_user, 
					 CUS_INV_HEADING_IND = @cus_inv_heading_ind, 
					 CUS_AUTO_PRINT_IND = @cus_auto_print_ind, 
					 CUS_NAME_EST = @cus_name_est, 
					 CUS_ADDR_EST = @cus_addr_est, 
					 CUS_CITY_EST = @cus_city_est, 
					 CUS_ZIP_EST = @cus_zip_est, 
					 CUS_STP_COD_EST = @cus_stp_cod_est, 
					 CUS_COU_COD_EST = @cus_cou_cod_est, 
					 CUS_RIF_EST = @cus_rif_est, 
					 CUS_PI_EST = @cus_pi_est, 
					 CUS_CF_EST = @cus_cf_est, 
					 CUS_EMAIL_EST = @cus_email_est, 
					 CUS_REFER_EC_PERSON = @cus_refer_ec_person, 
					 CUS_FORMAT_EMAIL = @cus_format_email, 
					 CUS_SEND_EMAIL_MAN_IND = @cus_send_email_man_ind, 
					 CUS_SEND_EMAIL_AUTO_IND = @cus_send_email_auto_ind, 
					 CUS_INVOICE_EMAIL = @cus_invoice_email, 
					 CUS_INVOICE_EMAIL_BCC = @cus_invoice_email_bcc, 
					 CUS_SEND_EMAIL_EC_IND = @cus_send_email_ec_ind, 
					 CUS_SEND_EMAIL_EC = @cus_send_email_ec
					 WHERE   
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "cus_cod", DbType.String, cus_cod);
				db.AddInParameter(dbCommand, "stp_cod", DbType.String, stp_cod);
				db.AddInParameter(dbCommand, "cou_cod", DbType.String, cou_cod);
				db.AddInParameter(dbCommand, "cus_grp_cod", DbType.String, cus_grp_cod);
				db.AddInParameter(dbCommand, "bro_cod", DbType.String, bro_cod);
				db.AddInParameter(dbCommand, "cus_acc_cod", DbType.String, cus_acc_cod);
				db.AddInParameter(dbCommand, "cus_wwo_cod", DbType.String, cus_wwo_cod);
				db.AddInParameter(dbCommand, "cus_name", DbType.String, cus_name);
				db.AddInParameter(dbCommand, "cus_addr", DbType.String, cus_addr);
				db.AddInParameter(dbCommand, "cus_city", DbType.String, cus_city);
				db.AddInParameter(dbCommand, "cus_zip", DbType.String, cus_zip);
				db.AddInParameter(dbCommand, "cus_phone", DbType.String, cus_phone);
				db.AddInParameter(dbCommand, "cus_fax", DbType.String, cus_fax);
				db.AddInParameter(dbCommand, "cus_email", DbType.String, cus_email);
				db.AddInParameter(dbCommand, "cus_pi", DbType.String, cus_pi);
				db.AddInParameter(dbCommand, "cus_cf", DbType.String, cus_cf);
				db.AddInParameter(dbCommand, "cus_priv_ind",DbType.Int16 , cus_priv_ind);
				db.AddInParameter(dbCommand, "cus_valid_ind", DbType.Int16, cus_valid_ind);
				db.AddInParameter(dbCommand, "cus_galileo_bar", DbType.String, cus_galileo_bar);
				db.AddInParameter(dbCommand, "la_time", DbType.DateTime, la_time);
				db.AddInParameter(dbCommand, "la_user", DbType.String, la_user);
				db.AddInParameter(dbCommand, "cus_inv_heading_ind", DbType.Int16, cus_inv_heading_ind);
				db.AddInParameter(dbCommand, "cus_auto_print_ind", DbType.Int16, cus_auto_print_ind);
				db.AddInParameter(dbCommand, "cus_name_est", DbType.String, cus_name_est);
				db.AddInParameter(dbCommand, "cus_addr_est", DbType.String, cus_addr_est);
				db.AddInParameter(dbCommand, "cus_city_est", DbType.String, cus_city_est);
				db.AddInParameter(dbCommand, "cus_zip_est", DbType.String, cus_zip_est);
				db.AddInParameter(dbCommand, "cus_stp_cod_est", DbType.String, cus_stp_cod_est);
				db.AddInParameter(dbCommand, "cus_cou_cod_est", DbType.String, cus_cou_cod_est);
				db.AddInParameter(dbCommand, "cus_rif_est", DbType.String, cus_rif_est);
				db.AddInParameter(dbCommand, "cus_pi_est", DbType.String, cus_pi_est);
				db.AddInParameter(dbCommand, "cus_cf_est", DbType.String, cus_cf_est);
				db.AddInParameter(dbCommand, "cus_email_est", DbType.String, cus_email_est);
				db.AddInParameter(dbCommand, "cus_refer_ec_person", DbType.String, cus_refer_ec_person);
				db.AddInParameter(dbCommand, "cus_format_email", DbType.String, cus_format_email);
				db.AddInParameter(dbCommand, "cus_send_email_man_ind", DbType.Int16, cus_send_email_man_ind);
				db.AddInParameter(dbCommand, "cus_send_email_auto_ind", DbType.Int16, cus_send_email_auto_ind);
				db.AddInParameter(dbCommand, "cus_invoice_email", DbType.String, cus_invoice_email);
				db.AddInParameter(dbCommand, "cus_invoice_email_bcc", DbType.String, cus_invoice_email_bcc);
                db.AddInParameter(dbCommand, "cus_send_email_ec_ind", DbType.Int16, cus_send_email_ec_ind);
				db.AddInParameter(dbCommand, "cus_send_email_ec", DbType.String, cus_send_email_ec);
										
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Customer.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete()
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM CUSTOMER WHERE 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Customer.Delete.");
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
	
				sqlCommand = @" INSERT INTO CUSTOMER (
						CUS_COD, 
						STP_COD, 
						COU_COD, 
						CUS_GRP_COD, 
						BRO_COD, 
						CUS_ACC_COD, 
						CUS_WWO_COD, 
						CUS_NAME, 
						CUS_ADDR, 
						CUS_CITY, 
						CUS_ZIP, 
						CUS_PHONE, 
						CUS_FAX, 
						CUS_EMAIL, 
						CUS_PI, 
						CUS_CF, 
						CUS_PRIV_IND, 
						CUS_VALID_IND, 
						CUS_GALILEO_BAR, 
						LA_TIME, 
						LA_USER, 
						CUS_INV_HEADING_IND, 
						CUS_AUTO_PRINT_IND, 
						CUS_NAME_EST, 
						CUS_ADDR_EST, 
						CUS_CITY_EST, 
						CUS_ZIP_EST, 
						CUS_STP_COD_EST, 
						CUS_COU_COD_EST, 
						CUS_RIF_EST, 
						CUS_PI_EST, 
						CUS_CF_EST, 
						CUS_EMAIL_EST, 
						CUS_REFER_EC_PERSON, 
						CUS_FORMAT_EMAIL, 
						CUS_SEND_EMAIL_MAN_IND, 
						CUS_SEND_EMAIL_AUTO_IND, 
						CUS_INVOICE_EMAIL, 
						CUS_INVOICE_EMAIL_BCC, 
						CUS_SEND_EMAIL_EC_IND, 
						CUS_SEND_EMAIL_EC	 ) 
					VALUES ( 
						@cus_cod, 
						@stp_cod, 
						@cou_cod, 
						@cus_grp_cod, 
						@bro_cod, 
						@cus_acc_cod, 
						@cus_wwo_cod, 
						@cus_name, 
						@cus_addr, 
						@cus_city, 
						@cus_zip, 
						@cus_phone, 
						@cus_fax, 
						@cus_email, 
						@cus_pi, 
						@cus_cf, 
						@cus_priv_ind, 
						@cus_valid_ind, 
						@cus_galileo_bar, 
						@la_time, 
						@la_user, 
						@cus_inv_heading_ind, 
						@cus_auto_print_ind, 
						@cus_name_est, 
						@cus_addr_est, 
						@cus_city_est, 
						@cus_zip_est, 
						@cus_stp_cod_est, 
						@cus_cou_cod_est, 
						@cus_rif_est, 
						@cus_pi_est, 
						@cus_cf_est, 
						@cus_email_est, 
						@cus_refer_ec_person, 
						@cus_format_email, 
						@cus_send_email_man_ind, 
						@cus_send_email_auto_ind, 
						@cus_invoice_email, 
						@cus_invoice_email_bcc, 
						@cus_send_email_ec_ind, 
						@cus_send_email_ec	 ) 

				";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "cus_cod", DbType.String, cus_cod);
				db.AddInParameter(dbCommand, "stp_cod", DbType.String, stp_cod);
				db.AddInParameter(dbCommand, "cou_cod", DbType.String, cou_cod);
				db.AddInParameter(dbCommand, "cus_grp_cod", DbType.String, cus_grp_cod);
				db.AddInParameter(dbCommand, "bro_cod", DbType.String, bro_cod);
				db.AddInParameter(dbCommand, "cus_acc_cod", DbType.String, cus_acc_cod);
				db.AddInParameter(dbCommand, "cus_wwo_cod", DbType.String, cus_wwo_cod);
				db.AddInParameter(dbCommand, "cus_name", DbType.String, cus_name);
				db.AddInParameter(dbCommand, "cus_addr", DbType.String, cus_addr);
				db.AddInParameter(dbCommand, "cus_city", DbType.String, cus_city);
				db.AddInParameter(dbCommand, "cus_zip", DbType.String, cus_zip);
				db.AddInParameter(dbCommand, "cus_phone", DbType.String, cus_phone);
				db.AddInParameter(dbCommand, "cus_fax", DbType.String, cus_fax);
				db.AddInParameter(dbCommand, "cus_email", DbType.String, cus_email);
				db.AddInParameter(dbCommand, "cus_pi", DbType.String, cus_pi);
				db.AddInParameter(dbCommand, "cus_cf", DbType.String, cus_cf);
				db.AddInParameter(dbCommand, "cus_priv_ind",DbType.Int16 , cus_priv_ind);
                db.AddInParameter(dbCommand, "cus_valid_ind", DbType.Int16, cus_valid_ind);
				db.AddInParameter(dbCommand, "cus_galileo_bar", DbType.String, cus_galileo_bar);
				db.AddInParameter(dbCommand, "la_time", DbType.DateTime, la_time);
				db.AddInParameter(dbCommand, "la_user", DbType.String, la_user);
				db.AddInParameter(dbCommand, "cus_inv_heading_ind",DbType.Int16 , cus_inv_heading_ind);
				db.AddInParameter(dbCommand, "cus_auto_print_ind",DbType.Int16 , cus_auto_print_ind);
				db.AddInParameter(dbCommand, "cus_name_est", DbType.String, cus_name_est);
				db.AddInParameter(dbCommand, "cus_addr_est", DbType.String, cus_addr_est);
				db.AddInParameter(dbCommand, "cus_city_est", DbType.String, cus_city_est);
				db.AddInParameter(dbCommand, "cus_zip_est", DbType.String, cus_zip_est);
				db.AddInParameter(dbCommand, "cus_stp_cod_est", DbType.String, cus_stp_cod_est);
				db.AddInParameter(dbCommand, "cus_cou_cod_est", DbType.String, cus_cou_cod_est);
				db.AddInParameter(dbCommand, "cus_rif_est", DbType.String, cus_rif_est);
				db.AddInParameter(dbCommand, "cus_pi_est", DbType.String, cus_pi_est);
				db.AddInParameter(dbCommand, "cus_cf_est", DbType.String, cus_cf_est);
				db.AddInParameter(dbCommand, "cus_email_est", DbType.String, cus_email_est);
				db.AddInParameter(dbCommand, "cus_refer_ec_person", DbType.String, cus_refer_ec_person);
				db.AddInParameter(dbCommand, "cus_format_email", DbType.String, cus_format_email);
				db.AddInParameter(dbCommand, "cus_send_email_man_ind",DbType.Int16 , cus_send_email_man_ind);
				db.AddInParameter(dbCommand, "cus_send_email_auto_ind",DbType.Int16 , cus_send_email_auto_ind);
				db.AddInParameter(dbCommand, "cus_invoice_email", DbType.String, cus_invoice_email);
				db.AddInParameter(dbCommand, "cus_invoice_email_bcc", DbType.String, cus_invoice_email_bcc);
				db.AddInParameter(dbCommand, "cus_send_email_ec_ind",DbType.Int16 , cus_send_email_ec_ind);
				db.AddInParameter(dbCommand, "cus_send_email_ec", DbType.String, cus_send_email_ec);

				db.ExecuteNonQuery(dbCommand);

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "Customer.Create.");
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
        /// Elenca tutti gli elementi Customer dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "CUSTOMER");
        }
		/// <summary>
		/// Elenca tutti gli elementi Customer dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"CUSTOMER");
		}
		/// <summary>
		/// Elenca tutti gli elementi Customer dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					CUSTOMER.CUS_COD, 
					CUSTOMER.STP_COD, 
					CUSTOMER.COU_COD, 
					CUSTOMER.CUS_GRP_COD, 
					CUSTOMER.BRO_COD, 
					CUSTOMER.CUS_ACC_COD, 
					CUSTOMER.CUS_WWO_COD, 
					CUSTOMER.CUS_NAME, 
					CUSTOMER.CUS_ADDR, 
					CUSTOMER.CUS_CITY, 
					CUSTOMER.CUS_ZIP, 
					CUSTOMER.CUS_PHONE, 
					CUSTOMER.CUS_FAX, 
					CUSTOMER.CUS_EMAIL, 
					CUSTOMER.CUS_PI, 
					CUSTOMER.CUS_CF, 
					CUSTOMER.CUS_PRIV_IND, 
					CUSTOMER.CUS_VALID_IND, 
					CUSTOMER.CUS_GALILEO_BAR, 
					CUSTOMER.LA_TIME, 
					CUSTOMER.LA_USER, 
					CUSTOMER.CUS_INV_HEADING_IND, 
					CUSTOMER.CUS_AUTO_PRINT_IND, 
					CUSTOMER.CUS_NAME_EST, 
					CUSTOMER.CUS_ADDR_EST, 
					CUSTOMER.CUS_CITY_EST, 
					CUSTOMER.CUS_ZIP_EST, 
					CUSTOMER.CUS_STP_COD_EST, 
					CUSTOMER.CUS_COU_COD_EST, 
					CUSTOMER.CUS_RIF_EST, 
					CUSTOMER.CUS_PI_EST, 
					CUSTOMER.CUS_CF_EST, 
					CUSTOMER.CUS_EMAIL_EST, 
					CUSTOMER.CUS_REFER_EC_PERSON, 
					CUSTOMER.CUS_FORMAT_EMAIL, 
					CUSTOMER.CUS_SEND_EMAIL_MAN_IND, 
					CUSTOMER.CUS_SEND_EMAIL_AUTO_IND, 
					CUSTOMER.CUS_INVOICE_EMAIL, 
					CUSTOMER.CUS_INVOICE_EMAIL_BCC, 
					CUSTOMER.CUS_SEND_EMAIL_EC_IND, 
					CUSTOMER.CUS_SEND_EMAIL_EC 
				FROM CUSTOMER ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[0];                
				ds.Tables["CUSTOMER"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "Customer.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}


        public static DataSet getListCustomerCod(string sqlWhereClause)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(@" SELECT 					 
					CUSTOMER.CUS_GRP_COD, 
					CUSTOMER.CUS_NAME					
				FROM CUSTOMER ");

                if (sqlWhereClause != string.Empty)
                {
                    sb.Append(sqlWhereClause);
                }

                sb.Append(" ORDER BY CUS_NAME ASC ");

                sqlCommand = sb.ToString();

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.LoadDataSet(dbCommand, ds, "CUSTOMER");

                // Add keys to table for correct use of Infragistics WebDataGrid.
                DataColumn[] keys = new DataColumn[0];
                ds.Tables["CUSTOMER"].PrimaryKey = keys;
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Customer.getListCustomerCod.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
            }

            return ds;
        }
		#endregion

	}
}
