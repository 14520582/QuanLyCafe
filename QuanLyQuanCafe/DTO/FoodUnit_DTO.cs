using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class FoodUnit_DTO
    {
        private int _idUnit;
        private String _nameUnit;

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

        public String NameUnit
        {
            get
            {
                return _nameUnit;
            }

            set
            {
                this._nameUnit = value;
            }
        }

        public FoodUnit_DTO(int idUnit, string nameUnit)
        {
            IdUnit = idUnit;
            NameUnit = nameUnit;
        }
    }
}
