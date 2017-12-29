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
        public static DataTable FindBillTableByBill(int IdBill)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("FindBillTableByBill", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdBill", SqlDbType.Int);
            cmd.Parameters["@IdBill"].Value = IdBill;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static void AddTableIntoBill(BillTable_DTO bt)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("AddTableIntoBill", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdBill", SqlDbType.Int);
            cmd.Parameters["@IdBill"].Value = bt.IdBill;
            cmd.Parameters.Add("@IdTable", SqlDbType.Int);
            cmd.Parameters["@IdTable"].Value = bt.IdTable;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void DeleteBillTable(int idBill, int idTable)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("DeleteBillTable", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdBill", SqlDbType.Int);
            cmd.Parameters["@IdBill"].Value = idBill;
            cmd.Parameters.Add("@IdTable", SqlDbType.Int);
            cmd.Parameters["@IdTable"].Value = idTable;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void DeleteAllTablesOfBill(int idBill)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("DeleteAllTablesOfBill", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdBill", SqlDbType.Int);
            cmd.Parameters["@IdBill"].Value = idBill;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        
    }
}
