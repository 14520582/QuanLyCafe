using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;
namespace QuanLyQuanCafe.VIEW
{
    public partial class frmService : Form
    {
        public frmService()
        {
            InitializeComponent();
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            dgvLoai.DataSource = FoodCategory_BUS.LoadFoodCategory();
            tbLoai.DataBindings.Clear();
            tbLoai.DataBindings.Add("Text", dgvLoai.DataSource, "NameCategory");

            dgvMenu.DataSource = Food_BUS.SearchByCategory(tbLoai.Text);
        }

        private void tbLoai_TextChanged(object sender, EventArgs e)
        {
            dgvMenu.DataSource = Food_BUS.SearchByCategory(tbLoai.Text);
        }
    }
}
