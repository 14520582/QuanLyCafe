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
    class FoodUnit_BUS
    {
        public static DataTable LoadFoodUnit()
        {
            return FoodUnit_DAO.LoadFoodUnit();
        }
        public static int getIdUnitByName(String NameUnit)
        {
            return FoodUnit_DAO.getIdUnitByName(NameUnit);
        }
    }
}
