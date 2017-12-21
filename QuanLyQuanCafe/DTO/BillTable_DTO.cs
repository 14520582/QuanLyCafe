using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class BillTable_DTO
    {
        int id, idBill, idTable;

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

        public int IdTable
        {
            get
            {
                return idTable;
            }

            set
            {
                idTable = value;
            }
        }
    }
}
