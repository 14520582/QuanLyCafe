using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class BillDetails_DTO
    {
        int id, idBill, idFood, number;
        public BillDetails_DTO()
        {

        }
        public BillDetails_DTO(int _id, int _idBill, int _idFood, int _number)
        {
            id = _id;
            idBill = _idBill;
            idFood = _idFood;
            number = _number;
        }
        public BillDetails_DTO(int _idBill, int _idFood, int _number)
        {
            idBill = _idBill;
            idFood = _idFood;
            number = _number;
        }
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int IdBill
        {
            get
            {
                return idBill;
            }

            set
            {
                idBill = value;
            }
        }

        public int IdFood
        {
            get
            {
                return idFood;
            }

            set
            {
                idFood = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }
    }
}
