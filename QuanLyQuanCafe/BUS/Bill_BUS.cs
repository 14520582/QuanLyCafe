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
    }
}
