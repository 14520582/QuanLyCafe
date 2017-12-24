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
    class Table_DAO
    {
        public static DataTable LoadTable()
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("LoadTable", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static int CheckValidTable(string name)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("CheckValidTable", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters["@Name"].Value = name;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int kq = Convert.ToInt32(cmd.Parameters["@Result"].Value);
            cnn.Close();
            return kq;
        }
        public static void AddTable(Table_DTO table)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("AddTable", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Location", SqlDbType.NVarChar, 200);
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 20);
            cmd.Parameters["@Name"].Value = table.Name;
            cmd.Parameters["@Location"].Value = table.Location;
            cmd.Parameters["@Status"].Value = table.Status; ;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void EditTable(Table_DTO table, string IdTable)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("EditTable", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Location", SqlDbType.NVarChar, 200);
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@IdTable", SqlDbType.Int);
            cmd.Parameters["@IdTable"].Value = IdTable;
            cmd.Parameters["@Name"].Value = table.Name;
            cmd.Parameters["@Location"].Value = table.Location;
            cmd.Parameters["@Status"].Value = table.Status; ;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static int CountTable()
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("CountTable", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Number", SqlDbType.Int).Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int soluong = Convert.ToInt32(cmd.Parameters["@Number"].Value);
            cnn.Close();
            return soluong;
        }
        public static void DeleteTable(string IdTable)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("DeleteTable", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdTable", SqlDbType.Int);
            cmd.Parameters["@IdTable"].Value = IdTable;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

    }
}
