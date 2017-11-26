using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BUS
{
    class Table_BUS
    {
        public static void AddTable(Table_DTO table)
        {
            Table_DAO.AddTable(table);
        }
    }
}
