using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class Bill_DTO
    {
        int id, total, status;
        DateTime date;
        public Bill_DTO()
        {

        }
        public Bill_DTO(int _id, int _total, int _status, DateTime _date)
        {
            id = _id;
            total = _total;
            status = _status;
            date = _date;
        }
        public Bill_DTO(int _total, int _status, DateTime _date)
        {
            total = _total;
            status = _status;
            date = _date;
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

        public int Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }
    }
}
