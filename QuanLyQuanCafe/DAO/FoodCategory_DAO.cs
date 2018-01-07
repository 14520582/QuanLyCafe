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
    class FoodCategory_DAO
    {

        public static DataTable LoadFoodCategory()
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("LoadFoodCategory", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        public static int getIdCategoryByName(string NameCategory)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("getIDCategoryByName", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCategory", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@NameCategory", SqlDbType.NVarChar, 100);
            cmd.Parameters["@NameCategory"].Value = NameCategory;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int idCategory = Convert.ToInt32(cmd.Parameters["@IdCategory"].Value);
            cnn.Close();
            return idCategory;
        }
        public static int isExistedCategory(string name)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("isExistedCategory", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters["@Category"].Value = name;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int kq = Convert.ToInt32(cmd.Parameters["@Result"].Value);
            cnn.Close();
            return kq;
        }
        public static void AddFoodCategory(string NameCategory)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("AddFoodCategory", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NameCategory", SqlDbType.NVarChar, 100);
            cmd.Parameters["@NameCategory"].Value = NameCategory;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
