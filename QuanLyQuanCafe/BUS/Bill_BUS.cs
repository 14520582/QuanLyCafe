using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BUS
{
    class Bill_BUS
    {
        public static DataTable LoadAllBill()
        {
            return Bill_DAO.LoadAllBill();
        }        
        public static DataTable FindBillByDate(DateTime fromDate, DateTime toDate)
        {
            return Bill_DAO.FindBillByDate(fromDate, toDate);
        }
        public static DataTable LoadBillTakeAway()
        {
            return Bill_DAO.LoadBillTakeAway();
        }
        public static DataTable FindBillByTable(int IdTable)
        {
            return Bill_DAO.FindBillByTable(IdTable);
        }
        public static DataTable EditStatusOfBill(int IdBill, int Status)
        {
            return Bill_DAO.EditStatusOfBill(IdBill, Status);
        }
    }
}
