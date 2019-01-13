using System.Data;
using System.Data.OleDb;
using System.Text;

namespace fmDataTool.Loader.Base
{
    public class ExcelLoader
    {
        public DataTable GetData(string fullPath, string sheetName)
        {
            DataTable excelData = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=");
            sb.Append(fullPath);
            sb.Append(";Extended Properties='Excel 12.0 Xml;HDR=YES'");

            using (OleDbConnection oleConn = new OleDbConnection(sb.ToString()))
            {
                oleConn.Open();
                string strQry = string.Format("SELECT * FROM [{0}$]", sheetName);

                using (OleDbDataAdapter oleDataAdapter = new OleDbDataAdapter(strQry, oleConn))
                {
                    excelData = new DataTable();
                    oleDataAdapter.Fill(excelData);

                    oleConn.Close();
                }
            }

            return excelData;
        }
    }
}
