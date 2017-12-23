using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLyQuanCafe.DAO
{
    class BillTable_DAO
    {
        public static DataTable LoadAllBillTable()
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("LoadAllBillTable", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static DataTable FindBillTableByDate(DateTime fromDate, DateTime toDate)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("FindBillTableByDate", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fromDate", SqlDbType.Date);
            cmd.Parameters.Add("@toDate", SqlDbType.Date);
            cmd.Parameters["@fromDate"].Value = fromDate.ToShortDateString();
            cmd.Parameters["@toDate"].Value = toDate.ToShortDateString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
    }
}
