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
    class ShopInfo_BUS
    {
        public static DataTable GetShopInfo()
        {
            return ShopInfo_DAO.GetShopInfo();
        }
        public static void EditShopInfo(ShopInfo_DTO shop)
        {
            ShopInfo_DAO.EditShopInfo(shop);
        }
    }
}
