#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   CampiNascostiCliente.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per CAMPINASCOSTICLIENTE
//
// Autore:      AR - SDG srl
// Data:        20/05/2011
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
	/// Tabella CAMPI_NASCOSTI_CLIENTE 
	/// </summary>
	public class CampiNascostiCliente
	{
		#region attributi e variabili

	    private SqlInt32 cnc_id_campo_nascosto = SqlInt32.Null;
	    private SqlInt32 cli_id_cliente = SqlInt32.Null;
	    private SqlString cnc_nome_campo_nascosto = SqlString.Null;
	    private SqlInt32 cnc_flag_visibile = SqlInt32.Null;
	    private SqlString cnc_pagina = SqlString.Null;
	    private SqlString cnc_tipo = SqlString.Null;
	    private SqlInt32 cnc_flag_required = SqlInt32.Null;
	    private SqlString cnc_chiave_label = SqlString.Null;
		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cnc_id_campo_nascosto
		{
			get { return cnc_id_campo_nascosto; }	
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cli_id_cliente
		{
			get { return cli_id_cliente; }	
			set { cli_id_cliente = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cnc_nome_campo_nascosto
		{
			get { return cnc_nome_campo_nascosto; }	
			set { cnc_nome_campo_nascosto = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cnc_flag_visibile
		{
			get { return cnc_flag_visibile; }	
			set { cnc_flag_visibile = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cnc_pagina
		{
			get { return cnc_pagina; }	
			set { cnc_pagina = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cnc_tipo
		{
			get { return cnc_tipo; }	
			set { cnc_tipo = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Cnc_flag_required
		{
			get { return cnc_flag_required; }	
			set { cnc_flag_required = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Cnc_chiave_label
		{
			get { return cnc_chiave_label; }	
			set { cnc_chiave_label = value; }
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
		public CampiNascostiCliente()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
		public void Read(SqlInt32 p_cnc_id_campo_nascosto)
		{
			SqlDataReader reader = null;
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" SELECT 
					 CAMPI_NASCOSTI_CLIENTE.cnc_id_campo_nascosto, 
					 CAMPI_NASCOSTI_CLIENTE.cli_id_cliente, 
					 CAMPI_NASCOSTI_CLIENTE.cnc_nome_campo_nascosto, 
					 CAMPI_NASCOSTI_CLIENTE.cnc_flag_visibile, 
					 CAMPI_NASCOSTI_CLIENTE.cnc_pagina, 
					 CAMPI_NASCOSTI_CLIENTE.cnc_tipo, 
					 CAMPI_NASCOSTI_CLIENTE.cnc_flag_required, 
					 CAMPI_NASCOSTI_CLIENTE.cnc_chiave_label	 
				 	 FROM CAMPI_NASCOSTI_CLIENTE WHERE 
					 (cnc_id_campo_nascosto = @cnc_id_campo_nascosto) 
					 ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "cnc_id_campo_nascosto", DbType.Int32, p_cnc_id_campo_nascosto);

				reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

				while (reader.Read()) 
				{
					cnc_id_campo_nascosto = reader.GetSqlInt32(0);
					cli_id_cliente = reader.GetSqlInt32(1);
					cnc_nome_campo_nascosto = reader.GetSqlString(2);
					cnc_flag_visibile = reader.GetSqlInt32(3);
					cnc_pagina = reader.GetSqlString(4);
					cnc_tipo = reader.GetSqlString(5);
					cnc_flag_required = reader.GetSqlInt32(6);
					cnc_chiave_label = reader.GetSqlString(7);

				}	
			}
			catch(Exception ex)
			{
				ex.Data.Add("Class.Method", "CampiNascostiCliente.Read.");
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
		public void Update(SqlInt32 p_cnc_id_campo_nascosto)
		{
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" UPDATE CAMPI_NASCOSTI_CLIENTE SET
					 cli_id_cliente = @cli_id_cliente, 
					 cnc_nome_campo_nascosto = @cnc_nome_campo_nascosto, 
					 cnc_flag_visibile = @cnc_flag_visibile, 
					 cnc_pagina = @cnc_pagina, 
					 cnc_tipo = @cnc_tipo, 
					 cnc_flag_required = @cnc_flag_required, 
					 cnc_chiave_label = @cnc_chiave_label
					 WHERE   
				     (cnc_id_campo_nascosto = @cnc_id_campo_nascosto) 
					 "; 										

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
				db.AddInParameter(dbCommand, "cnc_nome_campo_nascosto", DbType.String, cnc_nome_campo_nascosto);
				db.AddInParameter(dbCommand, "cnc_flag_visibile", DbType.Int32, cnc_flag_visibile);
				db.AddInParameter(dbCommand, "cnc_pagina", DbType.String, cnc_pagina);
				db.AddInParameter(dbCommand, "cnc_tipo", DbType.String, cnc_tipo);
				db.AddInParameter(dbCommand, "cnc_flag_required", DbType.Int32, cnc_flag_required);
				db.AddInParameter(dbCommand, "cnc_chiave_label", DbType.String, cnc_chiave_label);
										
				db.AddInParameter(dbCommand, "cnc_id_campo_nascosto", DbType.Int32, p_cnc_id_campo_nascosto);
										
				db.ExecuteNonQuery(dbCommand);           
            
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CampiNascostiCliente.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
		}

		/// <summary>
		/// Cancella l'oggetto dalla base dati.
		/// </summary>
        public static void Delete(SqlInt32 p_cnc_id_campo_nascosto)
        {
			string sqlCommand = null;
			DbCommand dbCommand = null;
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sqlCommand = @" DELETE FROM CAMPI_NASCOSTI_CLIENTE WHERE 
					(cnc_id_campo_nascosto = @cnc_id_campo_nascosto) 
					";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.AddInParameter(dbCommand, "cnc_id_campo_nascosto", DbType.Int32, p_cnc_id_campo_nascosto);
										
				db.ExecuteNonQuery(dbCommand);           
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CampiNascostiCliente.Delete.");
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
	
				sqlCommand = @" INSERT INTO CAMPI_NASCOSTI_CLIENTE (
						cli_id_cliente, 
						cnc_nome_campo_nascosto, 
						cnc_flag_visibile, 
						cnc_pagina, 
						cnc_tipo, 
						cnc_flag_required, 
						cnc_chiave_label	 ) 
					VALUES ( 
						@cli_id_cliente, 
						@cnc_nome_campo_nascosto, 
						@cnc_flag_visibile, 
						@cnc_pagina, 
						@cnc_tipo, 
						@cnc_flag_required, 
						@cnc_chiave_label	 ) 

				; SELECT SCOPE_IDENTITY()";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "cli_id_cliente", DbType.Int32, cli_id_cliente);
				db.AddInParameter(dbCommand, "cnc_nome_campo_nascosto", DbType.String, cnc_nome_campo_nascosto);
				db.AddInParameter(dbCommand, "cnc_flag_visibile", DbType.Int32, cnc_flag_visibile);
				db.AddInParameter(dbCommand, "cnc_pagina", DbType.String, cnc_pagina);
				db.AddInParameter(dbCommand, "cnc_tipo", DbType.String, cnc_tipo);
				db.AddInParameter(dbCommand, "cnc_flag_required", DbType.Int32, cnc_flag_required);
				db.AddInParameter(dbCommand, "cnc_chiave_label", DbType.String, cnc_chiave_label);

 				dataReader = db.ExecuteReader(dbCommand);
 				if (dataReader.Read())
 				{
 					cnc_id_campo_nascosto = Convert.ToInt32(dataReader[0]);
 				}
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "CampiNascostiCliente.Create.");
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
        /// Elenca tutti gli elementi CampiNascostiCliente dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB non viene specificata la whereclause.
        /// </summary>
        public static DataSet List()
        {
            return List(string.Empty, "CAMPI_NASCOSTI_CLIENTE");
        }
		/// <summary>
		/// Elenca tutti gli elementi CampiNascostiCliente dell'analisi. Il nome della tabella del dataset corrisponde al nome della tabella nel DB
		/// </summary>
		public static DataSet List(string sqlWhereClause) 
		{
			return List(sqlWhereClause,"CAMPI_NASCOSTI_CLIENTE");
		}
		/// <summary>
		/// Elenca tutti gli elementi CampiNascostiCliente dell'analisi. L'utente può scegliere il nome della tabella nel dataset
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
					CAMPI_NASCOSTI_CLIENTE.cnc_id_campo_nascosto, 
					CAMPI_NASCOSTI_CLIENTE.cli_id_cliente, 
					CAMPI_NASCOSTI_CLIENTE.cnc_nome_campo_nascosto, 
					CAMPI_NASCOSTI_CLIENTE.cnc_flag_visibile, 
					CAMPI_NASCOSTI_CLIENTE.cnc_pagina, 
					CAMPI_NASCOSTI_CLIENTE.cnc_tipo, 
					CAMPI_NASCOSTI_CLIENTE.cnc_flag_required, 
					CAMPI_NASCOSTI_CLIENTE.cnc_chiave_label 
				FROM CAMPI_NASCOSTI_CLIENTE ");

				if (sqlWhereClause != string.Empty)
				{
					sb.Append(sqlWhereClause);
				}

				sqlCommand = sb.ToString();

				dbCommand = db.GetSqlStringCommand(sqlCommand);

				db.LoadDataSet(dbCommand, ds, tableName);

				// Add keys to table for correct use of Infragistics WebDataGrid.
				DataColumn[] keys = new DataColumn[1];                
				keys[0] = ds.Tables["CAMPI_NASCOSTI_CLIENTE"].Columns["cnc_id_campo_nascosto"];
				ds.Tables["CAMPI_NASCOSTI_CLIENTE"].PrimaryKey = keys;
			}
		
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "CampiNascostiCliente.List.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}

			return ds; 
		}
						
		#endregion

	}
}
