using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace MasterRouteConverter
{
    public class WorkWithExcel
    {
        public static void ExcelFileToDataTable(out DataTable dtData, string path)
        {
            DataSet dsData = new DataSet();

            string sConnStr = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"{1};HDR=Yes;IMEX=1;\";", path, path.EndsWith(".xlsx") ? "Excel 12.0 Xml" : "Excel 8.0");
            using (OleDbConnection connection = new OleDbConnection(sConnStr))
            {
                connection.Open();

                var dtSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                var sheet1 = dtSchema.Rows[0].Field<string>("TABLE_NAME");

                OleDbCommand command = new OleDbCommand($"Select * from [{sheet1}]", connection);

                //OleDbCommand command = new OleDbCommand(sRequest, connection);
                using (OleDbDataAdapter oddaAdapter = new OleDbDataAdapter(command))
                {
                    oddaAdapter.Fill(dsData);
                }
                connection.Close();
            }

            dtData = dsData.Tables[0];
        }
    }
}
