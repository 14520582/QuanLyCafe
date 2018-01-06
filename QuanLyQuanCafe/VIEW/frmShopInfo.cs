using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.VIEW
{
    public partial class frmShopInfo : Form
    {
        public frmShopInfo()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmShopInfo_Load(object sender, EventArgs e)
        {
            DataTable shopinfo = ShopInfo_BUS.GetShopInfo();
            tbWifi.Text = shopinfo.Rows[0]["Wifi"].ToString();
            tbName.Text = shopinfo.Rows[0]["Name"].ToString();
            tbAddress.Text = shopinfo.Rows[0]["Address"].ToString();
            tbPhone.Text = shopinfo.Rows[0]["Phone"].ToString();
            tbFacebook.Text = shopinfo.Rows[0]["Facebook"].ToString();
            tbTime.Text = shopinfo.Rows[0]["OpenAndCloseTime"].ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ShopInfo_DTO shop = new ShopInfo_DTO(tbName.Text, tbPhone.Text, tbAddress.Text, tbWifi.Text, tbFacebook.Text, tbTime.Text);
            ShopInfo_BUS.EditShopInfo(shop);
            this.Close();
        }
    }
}
