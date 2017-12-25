using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAO
{
    class FoodUnit_DAO
    {
        public static DataTable LoadFoodUnit()
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("LoadFoodUnit", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        public static int getIdUnitByName(string NameUnit)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("getIDUnitByName", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdUnit", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@NameUnit", SqlDbType.NVarChar, 100);
            cmd.Parameters["@NameUnit"].Value = NameUnit;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int idUnit = Convert.ToInt32(cmd.Parameters["@IdUnit"].Value);
            cnn.Close();
            return idUnit;
        }
    }
}
