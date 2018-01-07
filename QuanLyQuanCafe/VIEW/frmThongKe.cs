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
            chart1.Hide();
            gridControl1.Hide();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cbxLoai.Text == "Top 10 SP bán chạy nhất")
            {
                chart1.Show();
                gridControl1.Hide();
                chart1.Series[0].Points.Clear();
                XYDiagram axs = (XYDiagram)chart1.Diagram;
                axs.AxisX.Title.Text = "Sản phẩm";
                axs.AxisY.Title.Text = "Số lượng";
                axs.AxisX.Title.Visible = true;
                axs.AxisY.Title.Visible = true;
                chart1.Series[0].LegendText = "Số lượng";
                chart1.Titles[0].Text = "Top 10 món bán chạy nhất tại quán tháng " + nUDMonth.Text + "/" + nudYear.Text;
                DataTable dtb = Bill_BUS.Top10Products(int.Parse(nUDMonth.Text), int.Parse(nudYear.Text));
                if (dtb.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        chart1.Series[0].Points.Add(new SeriesPoint(dtb.Rows[i][0], dtb.Rows[i][1]));
                    }
                }
                else
                    MessageBox.Show("Không có dữ liệu để thống kê năm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cbxLoai.Text == "Sản phẩm bán không chạy")
            {
                gridControl1.Show();
                chart1.Hide();
                gridControl1.DataSource = Bill_BUS.SplumpProducts(int.Parse(nUDMonth.Text), int.Parse(nudYear.Text), int.Parse(nUDsl.Text));
            }
            //else if (cbxLoai.Text == "Sản phẩm không bán được")
            //{
            //    gridControl1.Show();
            //    chart1.Hide();
            //    gridControl1.DataSource = Bill_BUS.UnmarketableProducts(int.Parse(nUDMonth.Text), int.Parse(nudYear.Text));
            //}
            else
            {
                chart1.Show();
                gridControl1.Hide();
                chart1.Series[0].Points.Clear();
                XYDiagram axs = (XYDiagram)chart1.Diagram;
                axs.AxisX.Title.Text = "Tháng";
                axs.AxisY.Title.Text = "Doanh thu (VNĐ)";
                axs.AxisX.Title.Visible = true;
                axs.AxisY.Title.Visible = true;
                chart1.Series[0].LegendText = "Doanh thu (VNĐ)";
                chart1.Titles[0].Text = "Doanh thu năm " + nudYear.Text;
                DataTable dtb = Bill_BUS.StatisticByRevenue(int.Parse(nudYear.Text));
                if (dtb.Rows.Count > 0)
                {
                    int j = 0;
                    for(int i = 0; i < 12; i++)
                    {
                        int value = 0;
                        if (j < dtb.Rows.Count)
                        {
                            int x = (int)dtb.Rows[j][0];
                            if (x == i + 1)
                            {
                                value = (int)dtb.Rows[j][1];
                                j++;
                            }
                        }
                        chart1.Series[0].Points.Add(new SeriesPoint("Tháng " + (i+1), value));
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

            //if (cbxLoai.Text == "Sản phẩm không bán được")
            //{
            //    nUDsl.Enabled = false;
            //    nUDMonth.Enabled = true;
            //}
            
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {

        }
    }
}
