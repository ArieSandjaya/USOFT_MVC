using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usoft.Common.CommonFunction
{
    public class ExcelHelper
    {
        public DataTable RetrieveData(string strConn, string dir, string filePath, string ExcelSource, string Condition)
        {
            DataTable dtExcel = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                try
                {
                    string SQLXls = "SELECT * FROM " + ExcelSource + " " + Condition;
                    OleDbDataAdapter da = new OleDbDataAdapter(SQLXls, conn); //get data from Sheet (sheet name must be HIGH_RISK_COUNTRY)
                    da.Fill(dtExcel);
                }
                catch //(Exception ex)
                {
                    File.Delete(filePath);
                    //Directory.Delete(dir);
                    //throw ex;
                }
            }
            return dtExcel;
        }
        public int GetRowCounts(DataTable dt)
        {
            int iRowCount = 0;

            iRowCount = dt.Rows.Count;

            return iRowCount;
        }
    }
}
