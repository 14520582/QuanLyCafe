using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class LOGIN_DTO
    {
        private int _idAccount;
        public int IdAccount
        {
            get
            {
                return _idAccount;
            }

            set
            {
                _idAccount = value;
            }
        }
         //sdfjdsf

        private string _name;
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

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        private int _type;
        public int Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public LOGIN_DTO(int id, string name, string password, int type)
        {
            IdAccount = id;
            Name = name;
            Password = password;
            Type = type;
        }
    }
}
