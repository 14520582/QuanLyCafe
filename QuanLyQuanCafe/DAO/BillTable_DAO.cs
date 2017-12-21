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
    }
}
