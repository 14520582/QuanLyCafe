using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class Table_DTO
    {
        private int _idTable;
        private String _name;
        private int _status;

        public int IdTable
        {
            get
            {
                return _idTable;
            }

            set
            {
                _idTable = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }
        public Table_DTO(string name, int status)
        {
            Name = name;
            Status = status;
        }
    }
}
