using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.VIEW
{
    public partial class Ngan : Form
    {
        public Ngan()
        {
            InitializeComponent();
        }

        private void Ngan_Load(object sender, EventArgs e)
        {
            dgvLoai.DataSource = Food_BUS.LoadFoodCategory();
            tbLoai.DataBindings.Clear();
            tbLoai.DataBindings.Add("Text", dgvLoai.DataSource, "NameCategory");

            dgvMenu.DataSource = Food_BUS.SearchByCategory(tbLoai.Text);
        }

        private void dgvLoai_Click(object sender, EventArgs e)
        {

        }

        private void tbLoai_TextChanged(object sender, EventArgs e)
        {
            dgvMenu.DataSource = Food_BUS.SearchByCategory(tbLoai.Text);
        }
    }
}
