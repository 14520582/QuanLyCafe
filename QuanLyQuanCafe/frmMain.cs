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

namespace QuanLyQuanCafe
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        //public void skins()
        //{
        //    DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
        //    themes.LookAndFeel.SkinName = "Valentine";
        //}

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void tabHienThi_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}