#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   Lookup_tipo_documento.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per LOOKUP_TIPO_DOCUMENTO
//
// Autore:      AR - SDG srl
// Data:        12/11/2010
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
using System.Data;
using System.Data.Common;
using System.Text;
using SDG.ExceptionHandling;

namespace BusinessObjects
{
    ///<summary>
    ///summary description for LOOKUP CLASS
    ///</summary>
    ///<remarks>
    ///comment here.
    ///</remarks>

    public class LookupTipoDocumento
    {

        #region Attributi e Variabili
        private string sqlWhereClause = "";

        /// <value>
        /// Where Clause condition
        /// </value>
        public string SqlWhereClause
        {
            get { return sqlWhereClause; }
            set { sqlWhereClause = value; }
        }
		
        #endregion

        #region  Costruttori
        public LookupTipoDocumento()
        {
        }
        #endregion

        #region METODI
        /// <summary>
        /// getLookupTipoDocumento
        /// </summary>
        /// <param name="qCultureInfoName"></param>
        /// <returns>iDataReader:,_DESCRIZIONE</returns>
        public IDataReader getLookupTipoDocumento(string qCultureInfoName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
			
			try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" SELECT ");
                sb.Append("LOOKUP_TIPO_DOCUMENTO.LTD_ID_DOCUMENTO, ");
                switch (qCultureInfoName)
                {
                    case "it":
                        sb.Append("LOOKUP_TIPO_DOCUMENTO.LTD_DESCRIZIONE_IT AS LTD_DESCRIZIONE ");
                        break;
                    case "en":
                        sb.Append("LOOKUP_TIPO_DOCUMENTO.LTD_DESCRIZIONE_EN AS LTD_DESCRIZIONE ");
                        break;
                    default:
                        sb.Append("LOOKUP_TIPO_DOCUMENTO.LTD_DESCRIZIONE_IT AS LTD_DESCRIZIONE ");
                        break;
                }
                sb.Append(" FROM LOOKUP_TIPO_DOCUMENTO ");
                sb.Append(@sqlWhereClause);

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                return db.ExecuteReader(dbCommand);
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupTipoDocumento.getLookupTipoDocumento.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

                IDataReader idr = null;
                return idr;
            }
        }

		
		/// <summary>
		/// getDSLookupTipoDocumento - restituisce un DataSet (da usare solo per inline edit dei combo nelle WebGrid)
		/// </summary>
		/// <param name="qCultureInfoName"></param>
		/// <returns>DataSet:,_DESCRIZIONE</returns>
		public DataSet getDSLookupTipoDocumento(string qCultureInfoName)
		{
			string sqlCommand = null;
			StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
			DataSet dsLookupTipoDocumento = new DataSet();
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sb.Append(" SELECT ");
				sb.Append("LOOKUP_TIPO_DOCUMENTO.LTD_ID_DOCUMENTO, ");
				switch (qCultureInfoName)
				{
					case "it":
						sb.Append("LOOKUP_TIPO_DOCUMENTO.LTD_DESCRIZIONE_IT AS LTD_DESCRIZIONE ");
						break;
					case "en":
						sb.Append("LOOKUP_TIPO_DOCUMENTO.LTD_DESCRIZIONE_EN AS LTD_DESCRIZIONE ");
						break;
					default:
						sb.Append("LOOKUP_TIPO_DOCUMENTO.LTD_DESCRIZIONE_IT AS LTD_DESCRIZIONE ");
						break;
				}
				sb.Append(" FROM LOOKUP_TIPO_DOCUMENTO ");
				sb.Append(@sqlWhereClause);

				sqlCommand = sb.ToString();
				dbCommand = db.GetSqlStringCommand(sqlCommand);
				db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

				db.LoadDataSet(dbCommand, dsLookupTipoDocumento, "LOOKUP_TIPO_DOCUMENTO");
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupTipoDocumento.getLookupTipoDocumento.");
				ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

				// Gestione messaggistica all'utente e trace in DB dell'errore
				ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
			return dsLookupTipoDocumento;
		}

		#endregion
    }
}
