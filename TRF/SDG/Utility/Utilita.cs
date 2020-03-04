#region Testatina
// ---------------------------------------------------------------------------
// Progetto:    Gestione Utenti
// Nome File:   Utilita.cs
//
// Namespace: 	SDG.GestioneUtenti
// Descrizione: Funzioni di utilità
//
// Autore:      AR - SDG srl
// Data:        27/06/2008
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Reflection;
//using AutoMapper;
using BusinessObjects;

namespace SDG.Utility
{
    /// <summary>
    /// Summary description for Utils.
    /// </summary>
    public class Utilita
    {
        #region attributi e variabili

        // Lingua di entrata
        private int naz_id_nazione;

        // Tipi di permessi
        private const int accessNone = 1;
        private const int accessRead = 2;
        private const int accessReadWrite = 3;
        private const int accessDelete = 4;

        #endregion

        #region Proprieta
        public int Naz_id_nazione
        {
            get { return naz_id_nazione; }
            set { naz_id_nazione = value; }
        }

        public int AccessNone
        {
            get { return accessNone; }
        }

        public int AccessRead
        {
            get { return accessRead; }
        }

        public int AccessReadWrite
        {
            get { return accessReadWrite; }
        }

        public int AccessDelete
        {
            get { return accessDelete; }
        }

        #endregion

        #region Costruttori
        public Utilita()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Metodi
        public byte[] getMicrosoftAdvertisingClass()
        {
            /// <summary>
            /// Permette di gestire i permessi di esecuzione del progetto relativi ai singoli MAC address dei Client
            /// </summary>
            byte[] sMicrosoftAdvertisingClass = new byte[16];
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    string microsoftAdvertisingClass;
                    microsoftAdvertisingClass = mo["MacAddress"].ToString();
                    byte[] bMicrosoftAdvertisingClass = Encoding.UTF8.GetBytes(microsoftAdvertisingClass);
                    
                    MD5 md5 = new MD5CryptoServiceProvider();
                    sMicrosoftAdvertisingClass = md5.ComputeHash(bMicrosoftAdvertisingClass);
                    break;
                }
            }
            return sMicrosoftAdvertisingClass;
        }

        //NB: Usually you would add an extension method to convert data from Model to View
        //public static void ConfigureAutoMapper()
        //{

        //    //if you look at the View Diagram you see how conventions works
        //    Mapper.CreateMap<viewtrip, TRF.wsRichiestaViaggio.viewtrip>();
        //    //Mapper.CreateMap<Item, ItemView>();
        //}

        #endregion

        #region functions

        /// <summary>
        /// Trasforma una data in formato stringa (gg/mm/aaaa) nel formato seriale (aaaammgg)
        /// <param name="theDateString" data (gg/mm/aaaa)>
        /// </summary>
        public string dateToString(string theDateString)
        {
            //La data gg/mm/aaaa in input va trasformata in aaaammgg
            string retString, strAnno, strMese, strGiorno;

            strAnno = theDateString.Substring(6, 4);
            strMese = theDateString.Substring(3, 2);
            strGiorno = theDateString.Substring(0, 2);

            retString = strAnno + strMese + strGiorno;
            return retString;
        }

        /// <summary>
        /// Trasforma una data in formato stringa (gg/mm/aaaa) nel formato seriale (aaaammgg)
        /// <param name="theDateString" data (gg/mm/aaaa)>
        /// </summary>
        public string dateToString(DateTime theDate)
        {
            //La data gg/mm/aaaa in input va trasformata in aaaammgg
            string retString, strAnno, strMese, strGiorno;

            strAnno = Convert.ToString(theDate.Year);
            strMese = Convert.ToString(theDate.Month);
            if (strMese.Length == 1)
                strMese = "0" + strMese;
            strGiorno = Convert.ToString(theDate.Day);
            if (strGiorno.Length == 1)
                strGiorno = "0" + strGiorno;

            retString = strAnno + strMese + strGiorno;
            return retString;
        }

        /// <summary>
        /// StripHTML: elimina tutti i tags dell'html dalla stringa
        /// Utilizzata per gli Rss.
        /// </summary>
        /// <param name="htmlString"></param>
        /// <returns>string</returns>
        public static string StripHTML(string htmlString)
        {
            string pattern = @"<(.|\n)+?>";
            htmlString = Regex.Replace(htmlString, pattern, string.Empty);
            return GetTestoDecodificatoHTML(htmlString);
        }

        /// <summary>
        /// GetTestoDecodificatoHTML: converte una stringa codificata in HTML in una stringa decodificata
        /// </summary>
        /// <param name="testo"></param>
        /// <returns>string</returns>
        public static string GetTestoDecodificatoHTML(string testo)
        {
            testo = HttpUtility.HtmlDecode(testo);
            //Sostituisco altri caratteri non accettati
            testo = testo.Replace("'", "’");
            testo = testo.Replace("\"", "’");
            testo = testo.Replace("&", " ");
            return testo;
        }


        /// <summary>
        /// GetTestoCodificatoHTML: converte una stringa NON codificata in HTML in una stringa codificata
        /// </summary>
        /// <param name="testo"></param>
        /// <returns></returns>
        public static string GetTestoCodificatoHTML(string testo)
        {
            //testo = HttpUtility.HtmlEncode(testo);

            //testo = testo.Replace("&", "&amp;");
            //testo = testo.Replace("è", "&egrave;");
            //testo = testo.Replace("È", "&Egrave;");
            //testo = testo.Replace("à", "&agrave;");
            //testo = testo.Replace("ò", "&ograve;");
            //testo = testo.Replace("ì", "&igrave;");
            //testo = testo.Replace("ù", "&ugrave;");
            //testo = testo.Replace("é", "&eacute;");
            //testo = testo.Replace("<", "&lt;");
            //testo = testo.Replace(">", "&gt;");
            //testo = testo.Replace("‘", "&#39;");
            //testo = testo.Replace("’", "&#39;");
            testo = testo.Replace("'", "&#8217;");
            //testo = testo.Replace("\"", "&quot;");
            //testo = testo.Replace("“", "&quot;");
            //testo = testo.Replace("”", "&quot;");
            //testo = testo.Replace("\n", "<br/>");
            //testo = testo.Replace("\r", "");
            //testo = testo.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");

            return testo;
        }


        public static DataTable GetTable(IDataReader _reader)
        {
            DataTable _table = _reader.GetSchemaTable();
            DataTable _dt = new DataTable();
            DataColumn _dc;
            DataRow _row;
            System.Collections.ArrayList _al = new System.Collections.ArrayList();

            for (int i = 0; i < _table.Rows.Count; i++)
            {
                _dc = new DataColumn();

                if (!_dt.Columns.Contains(_table.Rows[i]["ColumnName"].ToString()))
                {
                    _dc.ColumnName = _table.Rows[i]["ColumnName"].ToString();
                    _dc.Unique = Convert.ToBoolean(_table.Rows[i]["IsUnique"]);
                    _dc.AllowDBNull = Convert.ToBoolean(_table.Rows[i]["AllowDBNull"]);
                    _dc.ReadOnly = Convert.ToBoolean(_table.Rows[i]["IsReadOnly"]);
                    _al.Add(_dc.ColumnName);
                    _dt.Columns.Add(_dc);
                }
            }

            while (_reader.Read())
            {
                _row = _dt.NewRow();

                for (int i = 0; i < _al.Count; i++)
                {

                    _row[((System.String)_al[i])] = _reader[(System.String)_al[i]];

                }

                _dt.Rows.Add(_row);
            }
            _reader.Close();

            return _dt;
        }
        /// <summary>
        /// Mappa in una HashTable i nomi delle colonne di una GridView con i rispettivi indici delle celle
        /// </summary>
        /// <param name="gv">GridView da esaminare</param>
        /// <param name="dic">HashTable da riempire con le coppie (indice, nome)</param>
        [Obsolete("Deprecata perchè spostata nella BasePageBrowser")]
        public static Dictionary<string, int> MapGridViewColumnNames(GridView gv)
        {
            Dictionary<string, int> colNames = new Dictionary<string, int>();
            if (gv != null)
            {

                for (int i = 0; i < gv.Columns.Count; i++)
                {
                    DataControlField field = gv.Columns[i];
                    BoundField bfield = field as BoundField;

                    if (gv.Columns[i].HeaderText != "")
                        colNames.Add(gv.Columns[i].HeaderText, i);
                    else
                        if (bfield != null)
                        colNames.Add(bfield.DataField, i);
                }
            }
            return colNames;
        }


        /// <summary>
        /// Sostituzione caratteri Javascript non accettati da SQL.
        /// Inserire qui i controlli SQLInjection
        /// </summary>
        /// <param name="testo">Testo da modificare</param>
        /// <returns>string</returns>
        public static string safeParamSql(string testo)
        {
            testo = testo.Replace("'", "''");
            testo = testo.Replace("/#", @"\");
            return testo;
        }

        /// <summary>
        /// Sostituzione caratteri SQL non accettati da Javascript
        /// </summary>
        /// <param name="testo"></param>
        /// <returns>string</returns>
        public static string safeParamJs(string testo)
        {
            testo = testo.Replace("'", "\\'");
            return testo;
        }

        #endregion

        #region Generate Password

        public string GenerateRandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            //builder.Append(RandomNumber(10, 99));
            //builder.Append(RandomString(2, true));
            builder.Append(RandomNumber(100, 999));
            return builder.ToString();
        }

        /// <summary>
        /// Generates a random string with the given length
        /// </summary>
        /// <param name="size">Size of the string</param>
        /// <param name="lowerCase">If true, generate lowercase string</param>
        /// <returns>Random string</returns>
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        #endregion

        #region Reflection


        public static DataTable GetDataTable(string metodo, string parametriMetodo, object[] parametriPadre)
        {
            DataTable retVal = null;
            //AR Separo i parametri nei loro componenti elementari
            //metodo = Classe.Medodo
            string[] strMetodoAll = null;
            string strClasse = "";
            string strMetodo = "";
            if (metodo != "" && metodo != null)
            {
                strMetodoAll = metodo.Split('.');
                strClasse = strMetodoAll[0];
                strMetodo = strMetodoAll[1];
            }

            string[] stringParam = null;
            if (parametriMetodo != "" && parametriMetodo != null)
                stringParam = parametriMetodo.Split(',');

            //Solo se devo fare qualcosa, chiamo il metodo.
            if (strClasse != "" && strMetodo != "")
            {
                DataSet dsTable = (DataSet)Utilita.InvokeStringMethod(strClasse, strMetodo, parametriPadre);
                if (isFilledDS(dsTable))
                {
                    //Se trovo dei dati, leggo quelli indicati nei parametriMetodo
                    retVal = dsTable.Tables[0];
                }
            }

            return retVal;
        }

        public static DataSet GetDataSet(string metodo, string parametriMetodo, object[] parametriPadre)
        {
            DataSet retVal = null;
            //AR Separo i parametri nei loro componenti elementari
            //metodo = Classe.Medodo
            string[] strMetodoAll = null;
            string strClasse = "";
            string strMetodo = "";
            if (metodo != "" && metodo != null)
            {
                strMetodoAll = metodo.Split('.');
                strClasse = strMetodoAll[0];
                strMetodo = strMetodoAll[1];
            }

            string[] stringParam = null;
            if (parametriMetodo != "" && parametriMetodo != null)
                stringParam = parametriMetodo.Split(',');

            //Solo se devo fare qualcosa, chiamo il metodo.
            if (strClasse != "" && strMetodo != "")
            {
                DataSet dsTable = (DataSet)Utilita.InvokeStringMethod(strClasse, strMetodo, parametriPadre);
                if (isFilledDS(dsTable))
                {
                    //Se trovo dei dati, leggo quelli indicati nei parametriMetodo
                    retVal = dsTable;
                }
            }

            return retVal;
        }

        public static List<int> GetObjectsPK(string metodo, string parametriMetodo, object[] parametriPadre)
        {
            List<int> retVal = new List<int>();
            //AR Separo i parametri nei loro componenti elementari
            //metodo = Classe.Medodo
            string[] strMetodoAll = null;
            string strClasse = "";
            string strMetodo = "";
            if (metodo != "" && metodo != null)
            {
                strMetodoAll = metodo.Split('.');
                strClasse = strMetodoAll[0];
                strMetodo = strMetodoAll[1];
            }

            string[] stringParam = null;
            if (parametriMetodo != "" && parametriMetodo != null)
                stringParam = parametriMetodo.Split(',');

            //Solo se devo fare qualcosa, chiamo il metodo.
            if (strClasse != "" && strMetodo != "")
            {
                DataSet dsTable = (DataSet)Utilita.InvokeStringMethod(strClasse, strMetodo, parametriPadre);
                if (isFilledDS(dsTable))
                {
                    //Se trovo dei dati, leggo quelli indicati nei parametriMetodo
                    DataTable dtTable = dsTable.Tables[0];
                    int idRow = 0;
                    foreach (DataRow r in dsTable.Tables[0].Rows)
                    {
                        foreach (string s in stringParam)
                        {
                            if (dtTable.Columns.Contains(stringParam[0]) && r[stringParam[0]] != DBNull.Value)
                            {
                                retVal.Add(Convert.ToInt32(r[stringParam[0]]));
                            }
                        }
                        idRow++;
                    }
                }
            }

            return retVal;
        }
        public static bool isFilledDS(DataSet ds)
        {
            bool retval = false;

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        retval = true;
                    }
                }
            }
            return retval;
        }
        public static object InvokeStringMethod(string typeName, string methodName, object[] stringParam)
        {
            //AR Codice per trovare i nomi di Assembly e Namespace che definiscono l'ambito 
            //in cui cercare la classe e il metodo da eseguire.
            Type type = typeof(Allegati);
            string namespaceName = type.Namespace;
            string assemblyName = type.Assembly.FullName;

            ////AR Li cabliamo in funzione del Namespace
            ////string assemblyName = "SDG.GestioneUtenti";
            ////string namespaceName = "SDG.GestioneUtenti";

            return InvokeStringMethod(assemblyName, namespaceName, typeName, methodName, stringParam);
        }

        public static object InvokeStringMethod(string assemblyName, string namespaceName, string typeName, string methodName, object[] stringParam)
        {
            Object retNull = null;

            // Get the Type for the class
            Type calledType = Type.GetType(namespaceName + "." + typeName + "," + assemblyName);

            // Invoke the method itself.
            if (calledType == null)
            {
                return retNull;
            }
            else
            {
                MethodInfo theMethod = calledType.GetMethod(methodName, GetTypeArrayFromObjectArray(stringParam));

                // Here we check if the method exists, and if it is a "good"
                // method, using our own CheckMethod method. It makes sure that
                // the client does not call methods inherited from Object or methods
                // that we have in this class that we don't want called.
                if (theMethod == null)
                {
                    return retNull;
                }
                else
                {
                    Object s = calledType.InvokeMember(
                                    methodName,
                                    BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
                                    null,
                                    null,
                                    stringParam);

                    // Return the object that was returned by the called method.
                    return s;
                }
            }
        }

        private static Type[] GetTypeArrayFromObjectArray(object[] pArray)
        {
            Type[] paramTypes = new Type[pArray.Length];
            for (int i = 0; i < pArray.Length; i++)
            {
                paramTypes[i] = pArray[i].GetType();
            }
            return paramTypes;
        }

        #endregion

    }
}
