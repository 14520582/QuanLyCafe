using QuanLyQuanCafe.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyQuanCafe.DAO
{
    public class LOGIN_DAO
    {

       
        public static int Status(string name, string password)
        {            
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("LogIn", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 1000);
            cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters["@UserName"].Value = name;
            cmd.Parameters["@Password"].Value = password; ;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int kq = Convert.ToInt32(cmd.Parameters["@Result"].Value);
            cnn.Close();
            return kq;
        }

        public static int getTypeByName(string nameAccount)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("getTypeByName", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@NameAccount", SqlDbType.NVarChar, 100);
            cmd.Parameters["@NameAccount"].Value = nameAccount;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int type = Convert.ToInt32(cmd.Parameters["@Type"].Value);
            cnn.Close();
            return type;
        }
    }
}
