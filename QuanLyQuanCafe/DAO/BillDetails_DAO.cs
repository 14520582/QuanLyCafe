using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLyQuanCafe.DAO
{
    class BillDetails_DAO
    {
        public static DataTable LoadAllBillDetails()
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("LoadAllBillInfo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
    }
}
