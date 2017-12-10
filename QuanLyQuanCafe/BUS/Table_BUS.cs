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
    class Table_BUS
    {
        public static int CheckValidTable(string Name)
        {
            return Table_DAO.CheckValidTable(Name);
        }
        public static void AddTable(Table_DTO table)
        {
            Table_DAO.AddTable(table);
        }
        public static void EditTable(Table_DTO table, string IdTable)
        {
            Table_DAO.EditTable(table, IdTable);
        }
        public static int CountTable()
        {
            return Table_DAO.CountTable();
        }
        public static DataTable LoadTable()
        {
            return Table_DAO.LoadTable();
        }
        public static void DeleteTable(string IdTable)
        {
            Table_DAO.DeleteTable(IdTable);
        }
    }
}
