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
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview;
namespace QuanLyQuanCafe.VIEW
{
    public partial class frmReport : Form
    {
        DateTime current = DateTime.Now;
        String first, last;
        DateTime firstDay, lastDay;
        float total;
        public frmReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckInvalidMonth(Convert.ToInt32(Thang.Text), Convert.ToInt32(Nam.Text)) == false)
            {
                MessageBox.Show("Hiện chưa có dữ liệu của tháng đã chọn hoặc tháng được chọn là không đúng");
            }
            else
            {
                
                
                DataTable data = new DataTable();
                first = "1/" + Thang.Text +"/"+ Nam.Text;
                last = GetLastDayOfMonth(Convert.ToInt32(Thang.Text), Convert.ToInt32(Nam.Text)).ToString() +"/"+ Thang.Text +"/"+ Nam.Text;
                firstDay = Convert.ToDateTime(first);
                lastDay = Convert.ToDateTime(last);

                data = Bill_BUS.FindBillByDate(firstDay, lastDay);
                //data = Bill_BUS.LoadAllBill();
                Report report = new Report();

                List<Bill_DTO> billList = new List<Bill_DTO>();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Bill_DTO bill = new Bill_DTO();
                    bill.Id = Convert.ToInt32(data.Rows[i]["IdBill"]);
                    bill.Date = DateTime.Parse(data.Rows[i]["Date"].ToString());
                    bill.Total = Convert.ToInt32(data.Rows[i]["TotalPrice"]);
                    billList.Add(bill);
                }
                report.lbNgayLap.Text = current.Day.ToString() + "/" + current.Month.ToString() + "/" + current.Year.ToString();
                report.lbthang.Text = Thang.Text + "/" + Nam.Text;
                report.lbCountID.Text = data.Rows.Count.ToString();
                report.lbSumPrice.Text = data.Compute("Sum(TotalPrice)","").ToString()+ " VNĐ";
                report.lbntn.Text = "ngày " + current.Day.ToString() + " tháng " + current.Month.ToString() +" năm " + current.Year.ToString()+".";
                try
                {
                    report.DataSource = billList;
                    ReportPrintTool tool = new ReportPrintTool(report);
                    tool.ShowPreview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
            

        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (current.Month > 1)
            {
                Thang.Text = (current.Month - 1).ToString();
                Nam.Text = current.Year.ToString();
            }
            else
            {
                Thang.Text = "12";
                Nam.Text = (current.Year - 1).ToString();
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Nam_ValueChanged(object sender, EventArgs e)
        {

        }

        private int GetLastDayOfMonth(int month, int year)
        {
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                return 31;
            else
            {
                if (month == 2)
                {
                    if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                        return 29;
                    else return 28;
                }
                else
                    return 30;
            }
        }

        private Boolean CheckInvalidMonth(int month, int year)
        {
            if (year > current.Year || year < 2000 || month > 12 || month < 1)
                return false;
            if (year == current.Year && month > current.Month)
                return false;
            return true;
        }

    }
}
