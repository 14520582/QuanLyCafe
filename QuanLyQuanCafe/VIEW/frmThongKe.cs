using DevExpress.XtraCharts;
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
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập năm để thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                chart1.Series.Clear();
                DataTable dtb = Bill_DAO.StatisticByRevenue(int.Parse(textBox1.Text));
                if (dtb.Rows.Count > 0)
                {
                    chart1.Series.Add("Doanh thu");
                    int str1, sl1;
                    int j = 1;
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        str1 = (int)dtb.Rows[i][0];
                        sl1 = (int)dtb.Rows[i][1];

                        if (str1 == j)
                        {
                            chart1.Series["Doanh thu"].Points.AddXY(str1, sl1);
                            j++;
                        }
                        else
                        {

                            for (; j < str1; j++)
                            {
                                chart1.Series["Doanh thu"].Points.AddXY(j, 0);
                            }

                            chart1.Series["Doanh thu"].Points.AddXY(str1, sl1);
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
                    MessageBox.Show("Không có dữ liệu để thống kê năm " + textBox1.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            

        }
        private void ThongKe()
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
