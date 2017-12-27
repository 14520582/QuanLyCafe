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
        public static DataTable FindBillInfoByDate(DateTime fromDate, DateTime toDate)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("FindBillInfoByDate", cnn);
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
        public static DataTable LoadBillInfoByIdBill(int IdBill)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("LoadBillInfoByIdBill", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdBill", SqlDbType.Int);
            cmd.Parameters["@IdBill"].Value = IdBill;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static void InsertBillDetail(BillDetails_DTO bd)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("AddBillInfo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdBill", SqlDbType.Int);
            cmd.Parameters["@IdBill"].Value = bd.IdBill;
            cmd.Parameters.Add("@IdFood", SqlDbType.Int);
            cmd.Parameters["@IdFood"].Value = bd.IdFood;
            cmd.Parameters.Add("@Number", SqlDbType.Int);
            cmd.Parameters["@Number"].Value = bd.Number;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void DeleteBillInfo(int idBill, int idFood)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("DeleteBillInfo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idBill", SqlDbType.Int);
            cmd.Parameters["@idBill"].Value = idBill;
            cmd.Parameters.Add("@idFood", SqlDbType.Int);
            cmd.Parameters["@idFood"].Value = idFood;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void EditNumberOfInfo(BillDetails_DTO bd)
        {
            SqlConnection cnn = ConnectToSQL.Connect();
            SqlCommand cmd = new SqlCommand("EditNumberOfInfo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdBill", SqlDbType.Int);
            cmd.Parameters["@IdBill"].Value = bd.IdBill;
            cmd.Parameters.Add("@IdFood", SqlDbType.Int);
            cmd.Parameters["@IdFood"].Value = bd.IdFood;
            cmd.Parameters.Add("@Number", SqlDbType.Int);
            cmd.Parameters["@Number"].Value = bd.Number;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        
    }
}
