using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.VIEW
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        bool isValid;
        public frmLogin()
        {
            InitializeComponent();
            isValid = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //kiểm tra trống
        private bool isEmpty()
        {
            if (txtTaiKhoan.Text.Trim().Length == 0 || txtMatKhau.Text.Trim().Length == 0)
                return true;
            return false;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {        
            if (!isEmpty())
            {
                isValid = LOGIN_BUS.Status(txtTaiKhoan.Text, txtMatKhau.Text) != 0 ? true : false;
                if (isValid)
                {
                    this.Close();
                }
                else
                {

                    MessageBox.Show("Tài khoản mật khẩu không chính xác");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản mật khẩu!");
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isValid)
            {
                Application.Exit();
            }
        }
    }
}