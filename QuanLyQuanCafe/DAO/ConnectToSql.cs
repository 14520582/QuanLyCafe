using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyQuanCafe.DAO
{
    class ConnectToSQL
    {
        private static string connect;
        
        public static SqlConnection Connect()
        {
            connect = @"Data Source=dell\sqlexpress2008;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
                      
            return cnn;
        }
       
    }
}
