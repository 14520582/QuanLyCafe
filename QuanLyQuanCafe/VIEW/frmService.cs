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
using QuanLyQuanCafe.DAO;
using System.Globalization;

namespace QuanLyQuanCafe.VIEW
{
    public partial class frmService : Form
    {
        DataTable tablelist;
        DataTable tableofbill;
        DataTable billInfo = new DataTable();
        int currentIdBill;
        bool creatingBill = false;
        public frmService()
        {
            InitializeComponent();
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnAddInfo.Enabled = false;
            btnReduce.Enabled = false;
            billInfo.Columns.Add("IdFood");
            billInfo.Columns.Add("FoodName");
            billInfo.Columns.Add("Number");
            billInfo.Columns.Add("NameUnit");
            billInfo.Columns.Add("Total");
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            dgvLoai.DataSource = FoodCategory_BUS.LoadFoodCategory();
            tbLoai.DataBindings.Clear();
            tbLoai.DataBindings.Add("Text", dgvLoai.DataSource, "NameCategory");

            dgvMenu.DataSource = Food_BUS.SearchByCategory(tbLoai.Text);
            //Load Take away bill
            gcBillTakeAway.DataSource = Bill_BUS.LoadBillTakeAway();
            //Load Table
            LoadTable();

        }

        private void tbLoai_TextChanged(object sender, EventArgs e)
        {
            dgvMenu.DataSource = Food_BUS.SearchByCategory(tbLoai.Text);
        }
        private void buttonTable_Click(object sender, EventArgs e)
        {
            int IdTable = Int32.Parse(((Button)sender).Name);
            //MessageBox.Show("ID " + IdTable);
            DataRow[] foundRows = tablelist.Select("IdTable = " + IdTable + "");
            int status = Int32.Parse(foundRows[0]["Status"].ToString());
            if(status == 1)
            {
                //MessageBox.Show("ID " + IdTable);
                DataTable bill = Bill_BUS.FindBillByTable(IdTable);
                if(bill.Rows.Count > 0)
                {
                    nameBill.Text = "Hóa Đơn - Bàn ";
                    int idbill = Int32.Parse(bill.Rows[0][0].ToString());
                    currentIdBill = idbill;
                    DataTable billInfo = BillDetails_BUS.LoadBillInfoByIdBill(idbill);
                    tableofbill = BillTable_BUS.FindBillTableByBill(idbill);
                    for (int i = 0; i < tableofbill.Rows.Count; i++)
                        nameBill.Text += " "+tableofbill.Rows[i]["Name"];
                    gcBillInfo.DataSource = billInfo;
                    //tbIdMonInBill.DataBindings.Clear();
                    //tbIdMonInBill.DataBindings.Add("Text", gcBillInfo.DataSource, "IdFood");
                    tbTotal.Text = bill.Rows[0]["TotalPrice"].ToString();
                    dtDate.Value = (DateTime)bill.Rows[0]["Date"];
                }
            }
            tbIdTable.Text = IdTable.ToString();
            btnPay.Enabled = true;
            btnAddInfo.Enabled = true;
            btnReduce.Enabled = true;
        }

        private void tbBillTakeAway_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            tableofbill = null;
            int idbill = Int32.Parse(gridView4.GetFocusedRowCellValue("IdBill").ToString());
            currentIdBill = idbill;
            nameBill.Text = "Hóa Đơn - " + idbill + " (Mang về)";
            DataTable billInfo = BillDetails_BUS.LoadBillInfoByIdBill(idbill);
            gcBillInfo.DataSource = billInfo;
            //tbIdMonInBill.DataBindings.Clear();
            //tbIdMonInBill.DataBindings.Add("Text", gcBillInfo.DataSource, "IdFood");
            tbTotal.Text = gridView4.GetFocusedRowCellValue("TotalPrice").ToString();
            dtDate.Value = (DateTime)gridView4.GetFocusedRowCellValue("Date");
            btnPay.Enabled = true;
            btnAddInfo.Enabled = true;
            btnReduce.Enabled = true;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            creatingBill = true;
            gcBillInfo.DataSource = billInfo;
            btnCancel.Visible = true;
            btnSave.Visible = true;
            btnCreateBill.Visible = false;
            btnAddInfo.Enabled = true;
            btnReduce.Enabled = false;
            nameBill.Text = "Hóa Đơn Đang Lập(Mang Đi)";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnCreateBill.Visible = true;
            btnAddInfo.Enabled = false;
            btnCancel.Visible = false;
            btnReduce.Enabled = false;
            btnSave.Visible = false;
            creatingBill = false;
            billInfo.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCreateBill.Visible = true;
            btnAddInfo.Enabled = false;
            btnReduce.Enabled = false;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            creatingBill = false;
            billInfo.Clear();
        }
        private void LoadTable()
        {
            tablelist = Table_BUS.LoadTable();
            for (int i = 0; i < Table_BUS.CountTable(); i++)
            {
                Button btn = new Button() { Width = 80, Height = 80 };
                Object id = tablelist.Rows[i]["IdTable"];
                Object name = tablelist.Rows[i]["Name"];
                Object status = tablelist.Rows[i]["Status"];
                btn.Click += new EventHandler(this.buttonTable_Click);
                btn.Name = id.ToString();
                btn.Text = Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "Bàn " + name.ToString();
                btn.ForeColor = Color.White;
                btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
                if (status.ToString() == "0")
                {
                    btn.Image = (Image)(Properties.Resources.empty);
                    btn.BackColor = Color.FromArgb(15, 216, 52);
                }
                else
                {
                    btn.Image = (Image)(Properties.Resources._using);
                    btn.BackColor = Color.FromArgb(249, 64, 64);
                }

                flowLayoutPanel1.Controls.Add(btn);
            }
        }
        private void btnAddInfo_Click(object sender, EventArgs e)
        {
            btnReduce.Enabled = true;
            if (creatingBill)
            {
                int IdFood = Int32.Parse(gridView2.GetFocusedRowCellValue("IdFood").ToString());
                int Number = Convert.ToInt32(number.Value);
                int Price = Int32.Parse(gridView2.GetFocusedRowCellValue("Price").ToString());
                DataRow[] customerRow = billInfo.Select("IdFood =" + IdFood);
                if (customerRow.Length > 0)
                {
                    int TotalNumber = Int32.Parse(customerRow[0]["Number"].ToString()) + Number;
                    customerRow[0]["Number"] = TotalNumber;
                    customerRow[0]["Total"] = Price * TotalNumber;
                }
                else
                {
                    string FoodName = gridView2.GetFocusedRowCellValue("Name").ToString();
                    string NameUnit = gridView2.GetFocusedRowCellValue("NameUnit").ToString();
                    int Total = Price * Number;
                    billInfo.Rows.Add(IdFood, FoodName, Number, NameUnit, Total);
                }
            }else
            {

            }
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            Bill_BUS.EditStatusOfBill(currentIdBill, 1);
            if(tableofbill == null)
                gcBillTakeAway.DataSource = Bill_BUS.LoadBillTakeAway();
            else
            {
                for (int j = 0; j < tableofbill.Rows.Count; j++)
                {
                    Table_BUS.EditStatusOfTable(Int32.Parse(tableofbill.Rows[j]["IdTable"].ToString()), 0);
                }
                flowLayoutPanel1.Controls.Clear();
                LoadTable();
                tableofbill = null;
            }
            gcBillInfo.DataSource = null;
            tbTotal.Text = "";
            btnPay.Enabled = false;
            btnAddInfo.Enabled = false;
            btnReduce.Enabled = false;
        }

        private void btnReduce_Click(object sender, EventArgs e)
        {
            if (creatingBill)
            {
                int IdFood = Int32.Parse(gridView3.GetFocusedRowCellValue("IdFood").ToString());
                int reduceNumber = Convert.ToInt32(number.Value);
                int Total = Int32.Parse(gridView3.GetFocusedRowCellValue("Total").ToString());
                int Number = Int32.Parse(gridView3.GetFocusedRowCellValue("Number").ToString());
                DataRow[] customerRow = billInfo.Select("IdFood =" + IdFood);
                if (reduceNumber >= Number)
                {
                    customerRow[0].Delete();
                    //int TotalNumber = Int32.Parse(customerRow[0]["Number"].ToString()) + Number;
                    //customerRow[0]["Number"] = TotalNumber;
                    //customerRow[0]["Total"] = Price * TotalNumber;
                }
                else
                {
                    //string FoodName = gridView2.GetFocusedRowCellValue("Name").ToString();
                    //string NameUnit = gridView2.GetFocusedRowCellValue("NameUnit").ToString();
                    //int Total = Price * Number;
                    //billInfo.Rows.Add(IdFood, FoodName, Number, NameUnit, Total);
                }
            }
            else
            {

            }
        }
    }
}
