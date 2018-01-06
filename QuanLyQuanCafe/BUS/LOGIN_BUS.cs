using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BUS
{
    class LOGIN_BUS
    {
        public static int Status(string name, string password)
        {
            return LOGIN_DAO.Status(name, password);
        }

        public static int getTypeByName(string name)
        {
            return LOGIN_DAO.getTypeByName(name);
        }
    }
}
