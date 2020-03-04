#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   Lookup_titolo.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per LOOKUP_TITOLO
//
// Autore:      AR - SDG srl
// Data:        26/10/2010
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

    public class LookupTitolo
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
        public LookupTitolo()
        {
        }
        #endregion

        #region METODI
        /// <summary>
        /// getLookupTitolo
        /// </summary>
        /// <param name="qCultureInfoName"></param>
        /// <returns>iDataReader:LTT_ID_TITOLO,LTT_DESCRIZIONE</returns>
        public IDataReader getLookupTitolo(string qCultureInfoName)
        {
            string sqlCommand = null;
            StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
			
			try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sb.Append(" SELECT ");
                sb.Append("LOOKUP_TITOLO.LTT_ID_TITOLO, ");
                switch (qCultureInfoName)
                {
                    case "it":
                        sb.Append("LOOKUP_TITOLO.LTT_DESCRIZIONE_IT AS LTT_DESCRIZIONE ");
                        break;
                    case "en":
                        sb.Append("LOOKUP_TITOLO.LTT_DESCRIZIONE_EN AS LTT_DESCRIZIONE ");
                        break;
                    default:
                        sb.Append("LOOKUP_TITOLO.LTT_DESCRIZIONE_IT AS LTT_DESCRIZIONE ");
                        break;
                }
                sb.Append(" FROM LOOKUP_TITOLO ");
                sb.Append(@sqlWhereClause);

                sqlCommand = sb.ToString();
                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

                return db.ExecuteReader(dbCommand);
            }

            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "LookupTitolo.getLookupTitolo.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                // Gestione messaggistica all'utente e trace in DB dell'errore
                ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");

                IDataReader idr = null;
                return idr;
            }
        }

		
		/// <summary>
		/// getDSLookupTitolo - restituisce un DataSet (da usare solo per inline edit dei combo nelle WebGrid)
		/// </summary>
		/// <param name="qCultureInfoName"></param>
		/// <returns>DataSet:LTT_ID_TITOLO,LTT_DESCRIZIONE</returns>
		public DataSet getDSLookupTitolo(string qCultureInfoName)
		{
			string sqlCommand = null;
			StringBuilder sb = new StringBuilder(2000);
			DbCommand dbCommand = null;
			DataSet dsLookupTitolo = new DataSet();
			
			try
			{
				Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

				sb.Append(" SELECT ");
				sb.Append("LOOKUP_TITOLO.LTT_ID_TITOLO, ");
				switch (qCultureInfoName)
				{
					case "it":
						sb.Append("LOOKUP_TITOLO.LTT_DESCRIZIONE_IT AS LTT_DESCRIZIONE ");
						break;
					case "en":
						sb.Append("LOOKUP_TITOLO.LTT_DESCRIZIONE_EN AS LTT_DESCRIZIONE ");
						break;
					default:
						sb.Append("LOOKUP_TITOLO.LTT_DESCRIZIONE_IT AS LTT_DESCRIZIONE ");
						break;
				}
				sb.Append(" FROM LOOKUP_TITOLO ");
				sb.Append(@sqlWhereClause);

				sqlCommand = sb.ToString();
				dbCommand = db.GetSqlStringCommand(sqlCommand);
				db.AddInParameter(dbCommand, "sqlWhereClause", DbType.String, sqlWhereClause);

				db.LoadDataSet(dbCommand, dsLookupTitolo, "LOOKUP_TITOLO");
			}
			catch (Exception ex)
			{
				ex.Data.Add("Class.Method", "LookupTitolo.getLookupTitolo.");
				ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

				// Gestione messaggistica all'utente e trace in DB dell'errore
				ExceptionPolicy.HandleException(ex, "Direct Data Access Policy");
			}
			return dsLookupTitolo;
		}

		#endregion
    }
}
