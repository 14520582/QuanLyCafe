using System;
using System.Collections.Generic;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    class ShopInfo_DAO
    {
        public static DataTable GetShopInfo()
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("getShopInfo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static void EditShopInfo(ShopInfo_DTO shop)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("editShopInfo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
            cmd.Parameters["@Name"].Value = shop.Name;
            cmd.Parameters.Add("@Wifi", SqlDbType.NVarChar, 200);
            cmd.Parameters["@Wifi"].Value = shop.Wifi;
            cmd.Parameters.Add("@Facebook", SqlDbType.NVarChar, 200);
            cmd.Parameters["@Facebook"].Value = shop.Facebook;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200);
            cmd.Parameters["@Address"].Value = shop.Address;
            cmd.Parameters.Add("@OpenAndCloseTime", SqlDbType.NVarChar, 200);
            cmd.Parameters["@OpenAndCloseTime"].Value = shop.Time;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 200);
            cmd.Parameters["@Phone"].Value = shop.Phone;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
