using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QuanLyQuanCafe.VIEW
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
    
        public frmMain()
        {
            InitializeComponent();
            frmLogin dn = new frmLogin();
            dn.ShowDialog();
            checkUser(dn.getType());
        }
        //public void skins()
        //{
        //    DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
        //    themes.LookAndFeel.SkinName = "Valentine";
        //}
        public Form IsActive(Type type)
        {
            foreach (var f in this.MdiChildren)
            {
                if (f.GetType() == type)
                    return f;
            }
            return null;
        }

        private void btnHoaDon_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = IsActive(typeof(frmInvoice));

            if (f != null)
                f.Activate();
            else
            {
                f = new frmInvoice();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnQLBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = IsActive(typeof(frmTable));

            if (f != null)
                f.Activate();
            else
            {
                f = new frmTable();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = IsActive(typeof(frmMenu));

            if (f != null)
                f.Activate();
            else
            {
                f = new frmMenu();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = IsActive(typeof(frmService));

            if (f != null)
                f.Activate();
            else
            {
                f = new frmService();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Form f = IsActive(typeof(frmService));

            if (f != null)
                f.Activate();
            else
            {
                f = new frmService();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCreateReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form dn = new frmReport();
            dn.ShowDialog();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("www.doubleNT/help");
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = IsActive(typeof(frmAbout));

            if (f != null)
                f.Activate();
            else
            {
                f = new frmAbout();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnThoatHeThong_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                frmLogin dn = new frmLogin();
                dn.ShowDialog();
                checkUser(dn.getType());
            }
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = IsActive(typeof(frmThongKe));

            if (f != null)
                f.Activate();
            else
            {
                f = new frmThongKe();
                f.MdiParent = this;
                f.Show();
            }
        }


        public void checkUser(int userType)
        {
            if(userType == 1)
            {
                btnChart.Enabled = false;
                btnCreateReport.Enabled = false;
                btnMenu.Enabled = false;
                btnQLBan.Enabled = false;
                btnHoaDon.Enabled = false;
            }
            else
            {
                btnChart.Enabled = true;
                btnCreateReport.Enabled = true;
                btnMenu.Enabled = true;
                btnQLBan.Enabled = true;
                btnHoaDon.Enabled = true;
            }
        }
    }
}