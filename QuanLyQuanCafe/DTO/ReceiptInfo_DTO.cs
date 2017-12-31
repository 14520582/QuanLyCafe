using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class ReceiptInfo_DTO
    {
        private String _foodname;
        private int _price, _number, _total;

        public String FoodName
        {
            get
            {
                return _foodname;
            }

            set
            {
                _foodname = value;
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }

        public int Total
        {
            get
            {
                return _total;
            }

            set
            {
                _total = value;
            }
        }

        public ReceiptInfo_DTO(string name, int number, int price, int total)
        {
            FoodName = name;
            Number = number;
            Price = price;
            Total = total;
        }

        public ReceiptInfo_DTO() { }

    }
}
