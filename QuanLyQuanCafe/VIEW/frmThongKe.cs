using DevExpress.XtraCharts;
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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
            nUDMonth.Enabled = false;
            nUDsl.Enabled = false;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cbxLoai.Text == "Top 10 SP bán chạy nhất")
            {
                chart1.Show();
                gridControl1.Hide();
                chart1.Series.Clear();
                DataTable dtb = Bill_BUS.Top10Products(int.Parse(nUDMonth.Text), int.Parse(nudYear.Text));
                if (dtb.Rows.Count > 0)
                {
                    chart1.Series.Add("Số Lượng Bán");
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        chart1.Series["Số Lượng Bán"].Points.AddXY(dtb.Rows[i][0], dtb.Rows[i][1]);
                    }
                }
                else
                    MessageBox.Show("Không có dữ liệu để thống kê ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cbxLoai.Text == "Sản phẩm bán không chạy")
            {
                gridControl1.Show();
                chart1.Hide();
                gridControl1.DataSource = Bill_BUS.SplumpProducts(int.Parse(nUDMonth.Text), int.Parse(nudYear.Text), int.Parse(nUDsl.Text));
            }
            else if (cbxLoai.Text == "Sản phẩm không bán được")
            {
                gridControl1.Show();
                chart1.Hide();
                gridControl1.DataSource = Bill_BUS.UnmarketableProducts(int.Parse(nUDMonth.Text), int.Parse(nudYear.Text));
            }
            else
            {
                chart1.Show();
                gridControl1.Hide();
                chart1.Series.Clear();
                DataTable dtb = Bill_DAO.StatisticByRevenue(int.Parse(nudYear.Text));
                if (dtb.Rows.Count > 0)
                {
                    chart1.Series.Add("Doanh thu");
                    int x, y;
                    int j = 1;
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        x = (int)dtb.Rows[i][0];
                        y = (int)dtb.Rows[i][1];

                        if (x == j)
                        {
                            chart1.Series["Doanh thu"].Points.AddXY(x, y);
                            j++;
                        }
                        else
                        {

                            for (; j < x; j++)
                            {
                                chart1.Series["Doanh thu"].Points.AddXY(j, 0);
                            }

                            chart1.Series["Doanh thu"].Points.AddXY(x, y);
                            j++;

                        }
                    }
                    if (j < 13)
                    {
                        for (; j < 13; j++)
                        {
                            chart1.Series["Doanh thu"].Points.AddXY(j, 0);
                        }
                    }
                }
                else
                    MessageBox.Show("Không có dữ liệu để thống kê năm " + nudYear.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void ThongKe()
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbxLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLoai.Text == "Doanh thu")
            {
                nUDMonth.Enabled = false;
                nUDsl.Enabled = false;
            }    
                   
            if(cbxLoai.Text == "Top 10 SP bán chạy nhất")
            {
                nUDsl.Enabled = false;
                nUDMonth.Enabled = true;
            }

            if (cbxLoai.Text == "Sản phẩm bán không chạy")
            {
                nUDsl.Enabled = true;
                nUDMonth.Enabled = true;
            }

            if (cbxLoai.Text == "Sản phẩm không bán được")
            {
                nUDsl.Enabled = false;
                nUDMonth.Enabled = true;
            }
            
        }
    }
}
