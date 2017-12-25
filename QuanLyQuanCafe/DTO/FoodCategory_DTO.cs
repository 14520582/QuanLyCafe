using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class FoodCategory_DTO
    {
        private int _idCategory;
        private String _nameCategory;

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

        public String NameCategory
        {
            get
            {
                return _nameCategory;
            }

            set
            {
                this._nameCategory = value;
            }
        }

        public FoodCategory_DTO(int idCategory, string nameCategory)
        {
            IdCategory = idCategory;
            NameCategory = nameCategory;
        }
    }
}
