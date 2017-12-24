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
    class Food_BUS
    {
        public static DataTable LoadFood()
        {
            return Food_DAO.LoadFood();
        }

      
        public static void AddFood(Food_DTO food)
        {
            Food_DAO.AddFood(food);
        }

        public static void EditFood(Food_DTO food)
        {
            Food_DAO.EditFood(food);
        }

        public static void DeleteFood(String idFood)
        {
            Food_DAO.DeleteFood(idFood);
        }

        public static int getIdCategoryByName(String NameCategory)
        {
            return Food_DAO.getIdCategoryByName(NameCategory);
        }

        public static int getIdUnitByName(String NameUnit)
        {
            return Food_DAO.getIdUnitByName(NameUnit);
        }

        public static DataTable SearchByName(String name)
        {
            return Food_DAO.SearchByName(name);
        }

        public static DataTable SearchByCategory(String category)
        {
            return Food_DAO.SearchByCategory(category);
        }

        public static DataTable LoadFoodCategory()
        {
            return Food_DAO.LoadFoodCategory();
        }


    }
}
