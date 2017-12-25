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
            //Table_BUS.LoadTable();
            DataSet dataSet11 = new DataSet();
            dataSet11.Tables.Add(Table_BUS.LoadTable());
            DataTable dtb = Table_DAO.LoadTable();
            for (int i = 0; i < Table_BUS.CountTable(); i++)
            {
                Button btn = new Button() { Width = 80, Height = 80 };

                Object name = dtb.Rows[i]["Name"];
                Object status = dtb.Rows[i]["Status"];
                if (status.ToString() == "0")
                {
                    btn.Image = Image.FromFile(@"C:\Users\hp\Documents\GitHubl\QuanLyCafe\QuanLyQuanCafe\Picture\empty.png");
                    btn.Text = Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + name.ToString();
                }
                else
                {
                    btn.Image = Image.FromFile(@"C:\Users\hp\Documents\GitHubl\QuanLyCafe\QuanLyQuanCafe\Picture\using.png");
                    btn.Text = Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + name.ToString();
                }
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

    }
}
