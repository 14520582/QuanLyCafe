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
    class Bill_DAO
    {
        public static DataTable LoadAllBill()
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("LoadAllBill", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static DataTable FindBillByDate(DateTime fromDate, DateTime toDate)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("FindBillByDate", cnn);
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
        public static DataTable LoadBillTakeAway()
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("LoadBillTakeAway", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }  
        public static DataTable FindBillByTable(int IdTable)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("FindBillByTable", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdTable", SqlDbType.Int);
            cmd.Parameters["@IdTable"].Value = IdTable;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static DataTable EditStatusOfBill(int IdBill, int Status)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("EditStatusOfBill", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdBill", SqlDbType.Int);
            cmd.Parameters["@IdBill"].Value = IdBill;
            cmd.Parameters.Add("@Status", SqlDbType.Int);
            cmd.Parameters["@Status"].Value = Status;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static void InsertBill(Bill_DTO Bill)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("AddBill", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Total", SqlDbType.Int);
            cmd.Parameters["@Total"].Value = Bill.Total;
            cmd.Parameters.Add("@Status", SqlDbType.Int);
            cmd.Parameters["@Status"].Value = Bill.Status;
            cmd.Parameters.Add("@Date", SqlDbType.Date);
            cmd.Parameters["@Date"].Value = Bill.Date.ToShortDateString();
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static int GetLastIdBill()
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("GetLastIdBill", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return Int32.Parse(dtb.Rows[0][0].ToString());
        }
        public static void DeleteBill(int idBill)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("DeleteBill", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idBill", SqlDbType.Int);
            cmd.Parameters["@idBill"].Value = idBill;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void DeleteAllOfBill(int idBill)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("DeleteAllOfBill", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idBill", SqlDbType.Int);
            cmd.Parameters["@idBill"].Value = idBill;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void EditTotalOfBill(int idBill, int total)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("EditTotalOfBill", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idBill", SqlDbType.Int);
            cmd.Parameters["@idBill"].Value = idBill;
            cmd.Parameters.Add("@TotalPrice", SqlDbType.Int);
            cmd.Parameters["@TotalPrice"].Value = total;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        
    }
}
