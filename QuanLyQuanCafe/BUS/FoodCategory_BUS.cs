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
    class FoodCategory_BUS
    {
        public static void AddFoodCategory(String NameCategory)
        {
            FoodCategory_DAO.AddFoodCategory(NameCategory);
        }

        public static int getIdCategoryByName(String NameCategory)
        {
            return FoodCategory_DAO.getIdCategoryByName(NameCategory);
        }

        public static DataTable LoadFoodCategory()
        {
            return FoodCategory_DAO.LoadFoodCategory();
        }
    }
}
