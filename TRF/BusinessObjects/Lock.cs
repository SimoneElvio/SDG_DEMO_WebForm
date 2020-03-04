#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    TRF
// Nome File:   Categoria.cs
//
// Namespace:   TRF.PortaleRichieste
// Descrizione: Classe per CATEGORIA
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
	/// Tabella LOCK
	/// </summary>
	public class Lock
	{
		#region attributi e variabili

	    private SqlInt32 lck_id_record = SqlInt32.Null;
	    private SqlString lck_tabella = SqlString.Null;	    
	    private SqlInt32 ute_id_utente = SqlInt32.Null;
        private SqlString lck_utente = SqlString.Null;
        private SqlString lck_utente_contatti = SqlString.Null;
        private SqlDateTime lck_last_ping = SqlDateTime.Null;
        private SqlGuid lck_id_sessione = SqlGuid.Null;
	    		
		private string sqlWhereClause = "";
		#endregion

		#region Proprieta

		/// <value>
		/// 
		/// </value>
		public SqlInt32 Lck_id_record
		{
			get { return lck_id_record; }	
            set { lck_id_record = value; }
		}

		/// <value>
		/// 
		/// </value>
		public SqlString Lck_tabella
		{
			get { return lck_tabella; }	
			set { lck_tabella = value; }
		}


        /// <value>
        /// 
        /// </value>
        public SqlGuid Lck_id_sessione
        {
            get { return lck_id_sessione; }
            set { lck_id_sessione = value; }
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
        public SqlString Lck_utente
        {
            get { return lck_utente; }
            set { lck_utente = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlString Lck_utente_contatti
        {
            get { return lck_utente_contatti; }
            set { lck_utente_contatti = value; }
        }

        /// <value>
        /// 
        /// </value>
        public SqlDateTime Lck_last_ping
        {
            get { return lck_last_ping; }
            set { lck_last_ping = value; }
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
		public Lock()
		{

		}
		#endregion
		
		#region Metodi
		/// <summary>
		/// Legge i dati per l'oggetto dalla base dati
		/// </summary>
        public bool ReadLock()
        {
            SqlDataReader reader = null;
            string sqlCommand = null;
            DbCommand dbCommand = null;
            bool isLocked = false;
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" SELECT LCK_ID_RECORD,
                        COALESCE(UTE_COGNOME + ' ' + UTE_NOME + ' ' + CONVERT(VARCHAR(20),LCK_DATA_LOCK,103) + ' ' + CONVERT(VARCHAR(20),LCK_DATA_LOCK,108)  ,UTE_COGNOME + ' ' + CONVERT(VARCHAR(20),LCK_DATA_LOCK,103) + ' ' + CONVERT(VARCHAR(20),LCK_DATA_LOCK,108)) AS UTENTE_LOCK,
                        ISNULL(UTE_TELEFONO,'') AS UTENTE_CONTATTI_LOCK
				 	 FROM LOCK 
                     LEFT JOIN UTENTE ON LOCK.UTE_ID_UTENTE = UTENTE.UTE_ID_UTENTE
                     WHERE 
					 (lck_id_record = @lck_id_record AND lck_tabella=@lck_tabella) 
					 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lck_id_record", DbType.Int32, lck_id_record);
                db.AddInParameter(dbCommand, "lck_tabella", DbType.String, lck_tabella);

                reader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader;

                lck_id_record = SqlInt32.Null;
                lck_utente = string.Empty;
                lck_utente_contatti = string.Empty;
                while (reader.Read())
                {
                    lck_id_record = reader.GetSqlInt32(0);                    
                    lck_utente = reader.GetSqlString(1);
                    lck_utente_contatti = reader.GetSqlString(2);
                    isLocked = true;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Lock.Read.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                throw ex;
            }

            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();                
            }
            return isLocked;
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

                sqlCommand = @" DELETE FROM LOCK WHERE 
					(lck_id_sessione = @lck_id_sessione) 
					";

                dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "lck_id_sessione", DbType.Guid, lck_id_sessione);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Lock.Delete.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                throw ex;
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
	
				sqlCommand = @" INSERT INTO LOCK (
						lck_id_record, 
						lck_data_lock, 
						lck_tabella, 
						ute_id_utente, 
						lck_unique_id,lck_last_ping,lck_id_sessione )
					VALUES ( 
						@lck_id_record, 
						getdate(), 
						@lck_tabella, 
						@ute_id_utente, 						
						NEWID(),getdate(),@lck_id_sessione) ";
										
				dbCommand = db.GetSqlStringCommand(sqlCommand);
            
				db.AddInParameter(dbCommand, "lck_id_record", DbType.Int32, lck_id_record);				
				db.AddInParameter(dbCommand, "lck_tabella", DbType.String, lck_tabella);
				db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.AddInParameter(dbCommand, "lck_id_sessione", DbType.Guid, lck_id_sessione);
							
 				dataReader = db.ExecuteReader(dbCommand);
 				dataReader.Close();

			}
			catch (Exception ex)
			{
                ex.Data.Add("Class.Method", "Categoria.Create.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                throw ex;
			}
			finally
			{
				if(dataReader != null)
					((IDisposable)dataReader).Dispose();
			}
		}

        /// <summary>
        /// Aggiorna l'oggetto corrispondente nella base dati.
        /// </summary>
        public void Update()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            IDataReader dataReader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" UPDATE LOCK SET
						lck_last_ping = getdate() 
                        WHERE lck_id_utente = @ute_id_utente";

                dbCommand = db.GetSqlStringCommand(sqlCommand);                
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                dataReader = db.ExecuteReader(dbCommand);
                dataReader.Close();

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Lock.Update.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                throw ex;
            }
            finally
            {
                if (dataReader != null)
                    ((IDisposable)dataReader).Dispose();
            }
        }

        /// <summary>
        /// Elimina dalla tabella dei Lock, tutti quegli oggetti il cui utente è inattivo per più di 2 minuti.
        /// </summary>	
        public void DeleteNotPinging()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");

                sqlCommand = @" DELETE from LOCK 
                                where UTE_ID_UTENTE in (select UTENTE.UTE_ID_UTENTE
                                from utente WHERE DATEDIFF(minute, UTENTE.UTE_LAST_PING, getdate()) > 5) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ute_id_utente", DbType.Int32, ute_id_utente);
                db.ExecuteNonQuery(dbCommand);

            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Lock.DeleteNotPinging.");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                throw ex;
            }
        }

        public bool forceResetSession(int idRichiesta)
        {            
            string sqlCommand = null;
            DbCommand dbCommand = null;
            bool succesfullReset = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                sqlCommand = @" UPDATE UTENTE SET UTE_FLAG_USCITA_FORZATA = 1 WHERE 
                UTE_ID_UTENTE = (SELECT UTE_ID_UTENTE FROM LOCK WHERE LCK_ID_RECORD = @riv_id_richiesta) ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "riv_id_richiesta", DbType.Int32, idRichiesta);
                db.ExecuteNonQuery(dbCommand);

                succesfullReset = true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Lock.forceResetSession");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));

                throw ex;
            }

            return succesfullReset;
        }

        public bool disconnectAllUsers()
        {
            string sqlCommand = null;
            DbCommand dbCommand = null;
            bool succesfullReset = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase("CONNECTION_STRING");
                sqlCommand = @" UPDATE UTENTE SET UTE_FLAG_USCITA_FORZATA = 1 
                FROM UTENTE INNER JOIN SESSIONI_UTENTI ON UTENTE.UTE_ID_UTENTE = SESSIONI_UTENTI.UTE_ID_UTENTE
                WHERE DATEDIFF(minute, SESSIONI_UTENTI.SSU_DATA_LAST_PING, getdate()) < 2 ";

                dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.ExecuteNonQuery(dbCommand);

                succesfullReset = true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Class.Method", "Lock.disconnectAllUsers");
                ex.Data.Add("SQL", GenericError.SubstituteParameters(dbCommand.CommandText, dbCommand.Parameters));
                throw ex;
            }

            return succesfullReset;
        }

		#endregion

	}
}
