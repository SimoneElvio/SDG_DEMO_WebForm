using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SDG.GestioneUtenti;
using SDG.GestioneUtenti.Web;
using SDG.Utility;
using System.Reflection;

namespace GestioneUtenti.Web.Common
{
    public partial class Excel : BasePageBrowser
    {
        #region Web Control Declaration
        protected string WhereClause;
        protected string qClassName;
        protected string qClassMethod;
        protected string qReportTime;
        protected int editorType;
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ripresa parametri di pagina
            editorType = Convert.ToInt32(Request.QueryString["EDITOR_TYPE"]);
            qClassName = Request.QueryString["className"];
            qClassMethod = Request.QueryString["classMethod"];
            qReportTime = Request.QueryString["reportTime"];
            WhereClause = hCallerWhereClause.Value;

            if (!IsPostBack)
            {
                LabelTitolo.InnerText = GetValueDizionarioUI("EXCEL");

                BindTableColumns();
            }
        }
        #endregion


        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //Genero Bottoniera (solo Export e Close)
            base.GenerateStandardBrowserButtons(false, true, false, true, false, false, true, editorType);
            ExportButton.Click += new EventHandler(ExportButton_Click);
        }
        #endregion


        #region Web Form Event Handler

        protected void ExportButton_Click(object sender, EventArgs e)
        {
            DataSet ds = fillDataSet();

            foreach (ListItem item in chkFields.Items)
            {
                if (!item.Selected)
                {
                    ds.Tables[0].Columns.Remove(item.Value);
                }
            }

            if (qReportTime == "SI")
                base.DataSetToExcel(ds.Tables, qClassName,true);
            else
                base.DataSetToExcel(ds.Tables, qClassName);
        }

        #endregion
        
        #region Functions

        protected DataSet fillDataSet()
        {
            object[] paramValues = null;
            paramValues = new object[1];
            paramValues[0] = WhereClause;

            DataSet ds = Utilita.GetDataSet(qClassMethod, "WhereClause", paramValues);
            return ds;
        }

        private void BindTableColumns()
        {
            DataSet ds = fillDataSet();
            DataTable table = ds.Tables[0];
            DataTable columnNames = new DataTable();

            columnNames.Columns.Add("Column_value");
            columnNames.Columns.Add("Column_name");
            foreach (DataColumn column in table.Columns)
            {
                columnNames.Rows.Add(column.ColumnName, getDizionarioUI(column.ColumnName));
            }
            
            chkFields.DataSource = columnNames;
            chkFields.DataBind();
        }

        //private void GetData()
        //{

        //    DataSet ds = fillDataSet();
        //    DataTable table = ds.Tables[0];

        //    // specify the data source for the GridView
        //    GridView1.DataSource = table;
        //    // bind the data now
        //    GridView1.DataBind();
        //}


        //protected void ShowGrid(object sender, EventArgs e)
        //{
        //    foreach (ListItem item in chkFields.Items)
        //    {
        //        if (item.Selected)
        //        {
        //            BoundField b = new BoundField();
        //            b.DataField = item.Value;
        //            b.HeaderText = item.Value;
        //            GridView1.Columns.Add(b);
        //        }
        //    }
        //    this.GetData();
        //}
        #endregion
    }
}
