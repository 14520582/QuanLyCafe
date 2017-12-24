using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class Food_DTO
    {
        private int _idFood;
        private String _name;
        private int _idCategory;
        private int _idUnit;
        private float _price;

        public int IdFood
        {
            get
            {
                return _idFood;
            }

            set
            {
                this._idFood = value;
            }
        }

        public String Name
        {
            get
            {
                return _name;
            }

            set
            {
                this._name = value;
            }
        }

        public int IdCategory
        {
            get
            {
                return _idCategory;
            }

            set
            {
                this._idCategory = value;
            }
        }

        public float Price
        {
            get
            {
                return _price;
            }

            set
            {
                this._price = value;
            }
        }

        public int IdUnit
        {
            get
            {
                return _idUnit;
            }

            set
            {
                this._idUnit = value;
            }
        }

        public Food_DTO(int idFood, string name, int idCategory,int idUnit, float price)
        {
            IdFood = idFood; 
            Name = name;
            IdCategory = idCategory;
            Price = price;
            IdUnit = idUnit;
        }

        public Food_DTO(string name, int idCategory, int idUnit, float price)
        {
            Name = name;
            IdCategory = idCategory;
            Price = price;
            IdUnit = idUnit;
        }
    }
}
