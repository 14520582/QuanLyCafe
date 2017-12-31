using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.BUS
{
    class BillDetails_BUS
    {
        public static DataTable LoadAllBillDetails()
        {
            return BillDetails_DAO.LoadAllBillDetails();
        }
        public static DataTable FindBillInfoByDate(DateTime fromDate, DateTime toDate)
        {
            return BillDetails_DAO.FindBillInfoByDate(fromDate, toDate);
        }
        public static DataTable LoadBillInfoByIdBill(int IdBill)
        {
            return BillDetails_DAO.LoadBillInfoByIdBill(IdBill);
        }
        public static void InsertBillDetail(BillDetails_DTO bd)
        {
            BillDetails_DAO.InsertBillDetail(bd);
        }
        public static void DeleteBillInfo(int idBill, int idFood)
        {
            BillDetails_DAO.DeleteBillInfo(idBill, idFood);
        }
        public static void EditNumberOfInfo(BillDetails_DTO bd)
        {
            BillDetails_DAO.EditNumberOfInfo(bd);
        }

        public static DataTable LoadBillInfoToReceiptByIdBill(int IdBill)
        {
            return BillDetails_DAO.LoadBillInfoToReceiptByIdBill(IdBill);
        }
    }
}
