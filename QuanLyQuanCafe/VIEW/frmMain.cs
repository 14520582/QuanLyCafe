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
            Form dn = new frmLogin();
            dn.ShowDialog();
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
    }
}