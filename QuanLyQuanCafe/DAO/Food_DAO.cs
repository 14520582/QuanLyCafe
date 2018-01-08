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
    class Food_DAO
    {
        public static DataTable LoadFood()
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("LoadFood", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //public static DataTable LoadFoodCategory()
        //{
        //    SqlConnection cnn = ConnectToSQL.Connect();
        //    SqlCommand cmd = new SqlCommand("LoadFoodCategory", cnn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dtb = new DataTable();
        //    da.Fill(dtb);
        //    return dtb;
        //}

        //public static DataTable LoadFoodUnit()
        //{
        //    SqlConnection cnn = ConnectToSQL.Connect();
        //    SqlCommand cmd = new SqlCommand("LoadFoodUnit", cnn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dtb = new DataTable();
        //    da.Fill(dtb);
        //    return dtb;
        //}

        public static DataTable SearchByName(string name)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("searchByName", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NameOfFood", SqlDbType.NVarChar, 100);
            cmd.Parameters["@NameOfFood"].Value = name;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        public static DataTable SearchByCategory(string category)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("searchByCategory", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NameOfCategory", SqlDbType.NVarChar, 100);
            cmd.Parameters["@NameOfCategory"].Value = category;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }


        public static void AddFood(Food_DTO food)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("AddFood", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@IdCategory", SqlDbType.Int);
            cmd.Parameters.Add("@IdUnit", SqlDbType.Int);
            cmd.Parameters.Add("@Price", SqlDbType.Float);
            cmd.Parameters["@Name"].Value = food.Name;
            cmd.Parameters["@IdCategory"].Value = food.IdCategory;
            cmd.Parameters["@IdUnit"].Value = food.IdUnit;
            cmd.Parameters["@Price"].Value = food.Price;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }


        public static void EditFood(Food_DTO food)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("UpdateFood", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdFood", SqlDbType.Int);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@IdCategory", SqlDbType.Int);
            cmd.Parameters.Add("@IdUnit", SqlDbType.Int);
            cmd.Parameters.Add("@Price", SqlDbType.Float);
            cmd.Parameters["@IdFood"].Value = food.IdFood;
            cmd.Parameters["@Name"].Value = food.Name;
            cmd.Parameters["@IdCategory"].Value = food.IdCategory;
            cmd.Parameters["@IdUnit"].Value = food.IdUnit;
            cmd.Parameters["@Price"].Value = food.Price;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void DeleteFood(string IdFood)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("DeleteFood", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdFood", SqlDbType.Int);
            cmd.Parameters["@IdFood"].Value = IdFood;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static int isExistedFood(string name)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("isExistedFood", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FoodName", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters["@FoodName"].Value = name;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int kq = Convert.ToInt32(cmd.Parameters["@Result"].Value);
            cnn.Close();
            return kq;
        }
        //public static int getIdCategoryByName(string NameCategory)
        //{
        //    SqlConnection cnn = ConnectToSQL.Connect();
        //    SqlCommand cmd = new SqlCommand("getIDCategoryByName", cnn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@IdCategory", SqlDbType.Int).Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add("@NameCategory", SqlDbType.NVarChar, 100);
        //    cmd.Parameters["@NameCategory"].Value = NameCategory;
        //    cnn.Open();
        //    cmd.ExecuteNonQuery();
        //    int idCategory = Convert.ToInt32(cmd.Parameters["@IdCategory"].Value);
        //    cnn.Close();
        //    return idCategory;
        //}

        //public static int getIdUnitByName(string NameUnit)
        //{
        //    SqlConnection cnn = ConnectToSQL.Connect();
        //    SqlCommand cmd = new SqlCommand("getIDUnitByName", cnn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@IdUnit", SqlDbType.Int).Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add("@NameUnit", SqlDbType.NVarChar, 100);
        //    cmd.Parameters["@NameUnit"].Value = NameUnit;
        //    cnn.Open();
        //    cmd.ExecuteNonQuery();
        //    int idUnit = Convert.ToInt32(cmd.Parameters["@IdUnit"].Value);
        //    cnn.Close();
        //    return idUnit;
        //}

        //public static void AddFoodCategory(string NameCategory)
        //{
        //    SqlConnection cnn = ConnectToSQL.Connect();
        //    SqlCommand cmd = new SqlCommand("AddFoodCategory", cnn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@NameCategory", SqlDbType.NVarChar, 100);        
        //    cmd.Parameters["@NameCategory"].Value = NameCategory;
        //    cnn.Open();
        //    cmd.ExecuteNonQuery();
        //    cnn.Close();
        //}

    }
}
