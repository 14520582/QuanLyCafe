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
        private String _location;
        private string _status;

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

        public string Status
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

        public string Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }
        }

        public Table_DTO(string name, string location, string status)
        {
            Name = name;
            Location = location;
            Status = status;
        }
    }
}
