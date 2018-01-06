using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class ShopInfo_DTO
    {
        string name, wifi, phone, address, facebook, time;
        public ShopInfo_DTO()
        {

        }
        public ShopInfo_DTO(string _name,string _phone,string _address, string _wifi, string _facebook, string _time)
        {
            name = _name;
            phone = _phone;
            address = _address;
            wifi = _wifi;
            facebook = _facebook;
            time = _time;
        }
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Facebook
        {
            get
            {
                return facebook;
            }

            set
            {
                facebook = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public string Wifi
        {
            get
            {
                return wifi;
            }

            set
            {
                wifi = value;
            }
        }
    }
}
