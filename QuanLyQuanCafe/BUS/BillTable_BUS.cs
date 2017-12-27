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
    class BillTable_BUS
    {
        public static DataTable LoadAllBillTable()
        {
            return BillTable_DAO.LoadAllBillTable();
        }
        public static DataTable FindBillTableByDate(DateTime fromDate, DateTime toDate)
        {
            return BillTable_DAO.FindBillTableByDate(fromDate, toDate);
        }
        public static DataTable FindBillTableByBill(int IdBill)
        {
            return BillTable_DAO.FindBillTableByBill(IdBill);
        }
        public static void AddTableIntoBill(BillTable_DTO bt)
        {
            BillTable_DAO.AddTableIntoBill(bt);
        }
        public static void DeleteBillTable(int idBill, int idTable)
        {
            BillTable_DAO.DeleteBillTable(idBill, idTable);
        }
        public static void DeleteAllTablesOfBill(int idBill)
        {
            BillTable_DAO.DeleteAllTablesOfBill(idBill);
        }
    }
}
