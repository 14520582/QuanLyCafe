using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyQuanCafe.DAO;
namespace QuanLyQuanCafe.BUS
{
    class BillDetails_BUS
    {
        public static DataTable LoadAllBillDetails()
        {
            return BillDetails_DAO.LoadAllBillDetails();
        }
    }
}
