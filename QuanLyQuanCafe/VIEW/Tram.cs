using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DAO;
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
    public partial class Tram : Form
    {
        public Tram()
        {
            InitializeComponent();
            LoadTable();
        }
        private void LoadTable()
        {            
            DataTable dtb = Table_DAO.LoadTable();         
            for (int i = 0; i < Table_BUS.CountTable(); i++)
            {
                Button btn = new Button() { Width = 80, Height = 80 };

                Object name = dtb.Rows[i]["Name"];
                Object status = dtb.Rows[i]["Status"];              
                btn.Click += new EventHandler(this.buttonTable_Click);
                btn.Name = name.ToString();
                if (status.ToString() == "0")
                {
                    btn.Image = (Image)(Properties.Resources.empty); 
                    btn.Text = Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "Bàn số " + name.ToString();
                }
                else
                {
                    btn.Image = (Image)(Properties.Resources._using);
                    btn.Text = Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "Bàn số " + name.ToString();
                }              
                flowLayoutPanel1.Controls.Add(btn);                                             
            }
            
        }
        private void buttonTable_Click(object sender, EventArgs e)
        {
            string nameTable = (string)((Button)sender).Name;
            MessageBox.Show("Bàn số" + nameTable);
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
