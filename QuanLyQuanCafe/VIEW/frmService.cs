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
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.VIEW
{
    public partial class frmService : Form
    {
        DataTable tablelist;
        DataTable tableofbill = new DataTable();
        DataTable movingtable = new DataTable();
        DataTable billInfo = new DataTable();
        int currentIdBill;
        bool creatingBill = false;
        bool moving = false;
        public frmService()
        {
            InitializeComponent();
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnConfirmMove.Visible = false;
            btnCancelMove.Visible = false;
            btnAddInfo.Enabled = false;
            btnReduce.Enabled = false;
            tableofbill.Columns.Add("IdTable", Type.GetType("System.Int32"));
            movingtable.Columns.Add("IdTable", Type.GetType("System.Int32"));
            billInfo.Columns.Add("Id", Type.GetType("System.Int32"));
            billInfo.Columns.Add("IdBill", Type.GetType("System.Int32"));
            billInfo.Columns.Add("IdFood", Type.GetType("System.Int32"));
            billInfo.Columns.Add("NameUnit");
            billInfo.Columns.Add("FoodName");
            billInfo.Columns.Add("Number", Type.GetType("System.Int32"));
            billInfo.Columns.Add("Total", Type.GetType("System.Int32"));
            gcBillInfo.DataSource = billInfo;
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            dgvLoai.DataSource = FoodCategory_BUS.LoadFoodCategory();
            //tbLoai.DataBindings.Clear();
           // tbLoai.DataBindings.Add("Text", dgvLoai.DataSource, "NameCategory");

            //dgvMenu.DataSource = Food_BUS.SearchByCategory(tbLoai.Text);
            //Load Take away bill
            gcBillTakeAway.DataSource = Bill_BUS.LoadBillTakeAway();
            //Load Table
            LoadTable();

        }

        private void tbLoai_TextChanged(object sender, EventArgs e)
        {
            //dgvMenu.DataSource = Food_BUS.SearchByCategory(tbLoai.Text);
        }
        private void buttonTable_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (creatingBill == false)
            {
                if (moving == false)
                {
                    int IdTable = Int32.Parse(btn.Name);
                    //MessageBox.Show("ID " + IdTable);
                    DataRow[] foundRows = tablelist.Select("IdTable = " + IdTable + "");
                    int status = Int32.Parse(foundRows[0]["Status"].ToString());
                    if (status == 1)
                    {
                        //MessageBox.Show("ID " + IdTable);
                        DataTable bill = Bill_BUS.FindBillByTable(IdTable);
                        if (bill.Rows.Count > 0)
                        {
                            nameBill.Text = "Hóa Đơn - Bàn ";
                            int idbill = Int32.Parse(bill.Rows[0][0].ToString());
                            currentIdBill = idbill;
                            billInfo.Rows.Clear();
                            DataTable binfo = BillDetails_BUS.LoadBillInfoByIdBill(idbill);
                            foreach (DataRow dr in binfo.Rows)
                            {
                                billInfo.Rows.Add(dr.ItemArray);
                            }
                            tableofbill.Rows.Clear();
                            DataTable temp = BillTable_BUS.FindBillTableByBill(idbill);
                            for (int i = 0; i < temp.Rows.Count; i++)
                            {
                                nameBill.Text += " " + temp.Rows[i]["Name"];
                                tableofbill.Rows.Add(temp.Rows[i]["IdTable"]);
                            }
                            //tbIdMonInBill.DataBindings.Clear();
                            //tbIdMonInBill.DataBindings.Add("Text", gcBillInfo.DataSource, "IdFood");
                            //tbTotal.Text = bill.Rows[0]["TotalPrice"].ToString();
                            dtDate.Value = (DateTime)bill.Rows[0]["Date"];
                        }
                        btnPay.Enabled = true;
                        btnAddInfo.Enabled = true;
                        btnReduce.Enabled = true;
                        btnPrint.Enabled = true;
                        btnTeminate.Enabled = true;
                        btnMove.Enabled = true;
                    }
                }else
                {
                    if (btn.BackColor == Color.FromArgb(15, 216, 52))
                    {
                        flowLayoutPanel1.Controls[btn.Name].BackColor = Color.FromArgb(239, 117, 2);
                        movingtable.Rows.Add(Int32.Parse(btn.Name));
                    }else
                    {
                        if (btn.BackColor == Color.FromArgb(239, 117, 2))
                        {
                            flowLayoutPanel1.Controls[btn.Name].BackColor = Color.FromArgb(15, 216, 52);
                            DataRow[] rows = movingtable.Select("IdTable =" + Int32.Parse(btn.Name));
                            rows[0].Delete();
                        }else
                        {
                            DataRow[] rows = tableofbill.Select("IdTable =" + Int32.Parse(btn.Name));
                            if(rows.Length > 0)
                            {
                                flowLayoutPanel1.Controls[btn.Name].BackColor = Color.FromArgb(15, 216, 52);
                                ((Button)flowLayoutPanel1.Controls[btn.Name]).Image = (Image)(Properties.Resources.available);
                                //rows[0].Delete();
                            }
                            else
                            {
                                MessageBox.Show("Bàn đã có người vui lòng chọn bàn khác.");
                            }
                        }
                    }
                }
            }
            else
            {
                int i = 0;
                if (btn.BackColor == Color.FromArgb(15, 216, 52) && i == 0)
                {
                    flowLayoutPanel1.Controls[btn.Name].BackColor = Color.FromArgb(239, 117, 2);
                    i = 1;
                    tableofbill.Rows.Add(Int32.Parse(btn.Name));
                }
                if (btn.BackColor == Color.FromArgb(239, 117, 2) && i == 0)
                {
                    flowLayoutPanel1.Controls[btn.Name].BackColor = Color.FromArgb(15, 216, 52);
                    i = 1;
                    DataRow[] rows = tableofbill.Select("IdTable =" + Int32.Parse(btn.Name));
                    rows[0].Delete();
                }
            }
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (creatingBill == false)
            //{
            //    if (moving == false)
            //    {
            //        tableofbill.Rows.Clear();
            //        int idbill = Int32.Parse(gridView4.GetFocusedRowCellValue("IdBill").ToString());
            //        currentIdBill = idbill;
            //        nameBill.Text = "Hóa Đơn - " + idbill + " (Mang về)";
            //        billInfo.Rows.Clear();
            //        DataTable binfo = BillDetails_BUS.LoadBillInfoByIdBill(idbill);
            //        foreach (DataRow dr in binfo.Rows)
            //        {
            //            billInfo.Rows.Add(dr.ItemArray);
            //        }
            //        //tbIdMonInBill.DataBindings.Clear();
            //        //tbIdMonInBill.DataBindings.Add("Text", gcBillInfo.DataSource, "IdFood");
            //        tbTotal.Text = gridView4.GetFocusedRowCellValue("TotalPrice").ToString();
            //        dtDate.Value = (DateTime)gridView4.GetFocusedRowCellValue("Date");
            //        btnPay.Enabled = true;
            //        btnAddInfo.Enabled = true;
            //        btnReduce.Enabled = true;
            //        btnPrint.Enabled = true;
            //        btnTeminate.Enabled = true;
            //        btnMove.Enabled = true;
            //    }
            //}else
            //{

            //}
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            creatingBill = true;
            billInfo.Rows.Clear();
            btnCancel.Visible = true;
            btnSave.Visible = true;
            btnCreateBill.Visible = false;
            btnAddInfo.Enabled = true;
            btnReduce.Enabled = false;
            btnPay.Enabled = false;
            btnPrint.Enabled = false;
            btnTeminate.Enabled = false;
            btnMove.Enabled = false;
            nameBill.Text = "Hóa Đơn Đang Lập";
            //tbTotal.Text = "0";
            tableofbill.Rows.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Int32.Parse(tbTotal.Text) + "");
            //xu ly bill
            
            Bill_DTO newBill = new Bill_DTO(Int32.Parse(gridColumn6.SummaryItem.SummaryValue.ToString()), 0, DateTime.Now);
            //Bill_DTO newBill = new Bill_DTO(Int32.Parse(tbTotal.Text), 0, DateTime.Now);
            Bill_BUS.InsertBill(newBill);
            currentIdBill = Bill_BUS.GetLastIdBill();
            //xu ly bill info
            for (int i = 0; i < billInfo.Rows.Count; i++)
            {
                int idFood = Int32.Parse(billInfo.Rows[i]["IdFood"].ToString());
                int number = Int32.Parse(billInfo.Rows[i]["Number"].ToString());
                BillDetails_BUS.InsertBillDetail(new BillDetails_DTO(currentIdBill, idFood, number));
            }
            //billInfo.Rows.Clear();
            //xu ly table of bill
            nameBill.Text = "Hóa Đơn - Bàn ";
            for (int i = 0; i < tableofbill.Rows.Count; i++)
            {
                //int status = Int32.Parse(foundRows[0]["Status"].ToString());
                int idTable = Int32.Parse(tableofbill.Rows[i]["IdTable"].ToString());
                DataRow[] foundRows = tablelist.Select("IdTable = " + idTable);
                foundRows[0]["Status"] = 1;
                Table_BUS.EditStatusOfTable(idTable, 1);
                BillTable_BUS.AddTableIntoBill(new BillTable_DTO(currentIdBill, idTable));
                ((Button)flowLayoutPanel1.Controls[tableofbill.Rows[i]["IdTable"].ToString()]).Image = (Image)(Properties.Resources.occupy);
                flowLayoutPanel1.Controls[tableofbill.Rows[i]["IdTable"].ToString()].BackColor = Color.FromArgb(249, 64, 64);
                nameBill.Text += " " + flowLayoutPanel1.Controls[tableofbill.Rows[i]["IdTable"].ToString()].Text.Trim();
            }
            if (tableofbill.Rows.Count < 1)
            {
                gcBillTakeAway.DataSource = Bill_BUS.LoadBillTakeAway();
                nameBill.Text = "Hóa Đơn - " + currentIdBill + " (Mang về)";
            }
            //tableofbill.Rows.Clear();
            btnCreateBill.Visible = true;
            //btnAddInfo.Enabled = false;
            btnCancel.Visible = false;
            //btnReduce.Enabled = false;
            btnSave.Visible = false;
            btnPay.Enabled = true;
            btnPrint.Enabled = true;
            btnTeminate.Enabled = true;
            btnMove.Enabled = true;
            creatingBill = false;
            //tbTotal.Text = "0";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            billInfo.Rows.Clear();
            btnPay.Enabled = false;
            btnPrint.Enabled = false;
            btnTeminate.Enabled = false;
            btnMove.Enabled = false;
            btnCreateBill.Visible = true;
            btnAddInfo.Enabled = false;
            btnReduce.Enabled = false;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            creatingBill = false;
           // tbTotal.Text = "0";
            billInfo.Rows.Clear();
            for(int i = 0; i < tableofbill.Rows.Count; i++)
            {
                flowLayoutPanel1.Controls[tableofbill.Rows[i]["IdTable"].ToString()].BackColor = Color.FromArgb(15, 216, 52);
            }
            tableofbill.Rows.Clear();

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
                btn.Text = Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "" + name.ToString();
                btn.ForeColor = Color.White;
                btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
                if (status.ToString() == "0")
                {
                    btn.Image = (Image)(Properties.Resources.available);
                    btn.BackColor = Color.FromArgb(15, 216, 52);
                }
                else
                {
                    btn.Image = (Image)(Properties.Resources.occupy);
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
                    billInfo.Rows.Add(1, 1,IdFood, NameUnit, FoodName, Number, Total);
                }
            }else
            {
                if(moving == false)
                {
                    int IdFood = Int32.Parse(gridView2.GetFocusedRowCellValue("IdFood").ToString());
                    int Number = Convert.ToInt32(number.Value);
                    int Price = Int32.Parse(gridView2.GetFocusedRowCellValue("Price").ToString());
                    DataRow[] customerRow = billInfo.Select("IdFood =" + IdFood);
                    DataRow[] billRow =  ((DataTable)gcBillTakeAway.DataSource).Select("IdBill =" + currentIdBill);
                    if (customerRow.Length > 0)
                    {
                        int TotalNumber = Int32.Parse(customerRow[0]["Number"].ToString()) + Number;
                        customerRow[0]["Number"] = TotalNumber;
                        customerRow[0]["Total"] = Price * TotalNumber;
                        BillDetails_BUS.EditNumberOfInfo(new BillDetails_DTO(currentIdBill, IdFood, TotalNumber));
                    }
                    else
                    {
                        string FoodName = gridView2.GetFocusedRowCellValue("Name").ToString();
                        string NameUnit = gridView2.GetFocusedRowCellValue("NameUnit").ToString();
                        int Total = Price * Number;
                        billInfo.Rows.Add(1, currentIdBill, IdFood, NameUnit, FoodName, Number, Total);
                        BillDetails_BUS.InsertBillDetail(new BillDetails_DTO(currentIdBill, IdFood, Number));
                    }
                    Bill_BUS.EditTotalOfBill(currentIdBill, Int32.Parse(gridColumn6.SummaryItem.SummaryValue.ToString()));
                    billRow[0]["TotalPrice"] = Int32.Parse(gridColumn6.SummaryItem.SummaryValue.ToString());
                }
            }
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            billInfo.Rows.Clear();
            Bill_BUS.EditStatusOfBill(currentIdBill, 1);
            if (tableofbill.Rows.Count < 1)
                gcBillTakeAway.DataSource = Bill_BUS.LoadBillTakeAway();
            else
            {
                for (int j = 0; j < tableofbill.Rows.Count; j++)
                {
                    int idTable = Int32.Parse(tableofbill.Rows[j]["IdTable"].ToString());
                    Table_BUS.EditStatusOfTable(idTable, 0);
                    ((Button)flowLayoutPanel1.Controls[idTable.ToString()]).Image = (Image)(Properties.Resources.available);
                    flowLayoutPanel1.Controls[idTable.ToString()].BackColor = Color.FromArgb(15, 216, 52);
                }
                //flowLayoutPanel1.Controls.Clear();
                //LoadTable();
                tableofbill.Rows.Clear();
            }
            //tbTotal.Text = "";
            btnAddInfo.Enabled = false;
            btnReduce.Enabled = false;
            btnPay.Enabled = false;
            btnPrint.Enabled = false;
            btnTeminate.Enabled = false;
            btnMove.Enabled = false;
        }

        private void btnReduce_Click(object sender, EventArgs e)
        {
            if (creatingBill)
            {
                int IdFood = Int32.Parse(gridView3.GetFocusedRowCellValue("IdFood").ToString());
                int reduceNumber = Convert.ToInt32(number.Value);
                int Total = Int32.Parse(gridView3.GetFocusedRowCellValue("Total").ToString());
                int Number = Int32.Parse(gridView3.GetFocusedRowCellValue("Number").ToString());
                int Price = Total/Number;
                DataRow[] customerRow = billInfo.Select("IdFood =" + IdFood);
                if (reduceNumber >= Number)
                {
                    customerRow[0].Delete();
                }
                else
                {
                    customerRow[0]["Number"] = Number - reduceNumber;
                    customerRow[0]["Total"] = (Number - reduceNumber)*Price;
                }
            }
            else
            {
                if (moving == false)
                {
                    int IdFood = Int32.Parse(gridView3.GetFocusedRowCellValue("IdFood").ToString());
                    int reduceNumber = Convert.ToInt32(number.Value);
                    int Total = Int32.Parse(gridView3.GetFocusedRowCellValue("Total").ToString());
                    int Number = Int32.Parse(gridView3.GetFocusedRowCellValue("Number").ToString());
                    int Price = Total / Number;
                    DataRow[] customerRow = billInfo.Select("IdFood =" + IdFood);
                    DataRow[] billRow = ((DataTable)gcBillTakeAway.DataSource).Select("IdBill =" + currentIdBill);
                    if (reduceNumber >= Number)
                    {
                        if (billInfo.Rows.Count > 1)
                        {
                            customerRow[0].Delete();
                            BillDetails_BUS.DeleteBillInfo(currentIdBill, IdFood);
                            Bill_BUS.EditTotalOfBill(currentIdBill, Int32.Parse(gridColumn6.SummaryItem.SummaryValue.ToString()));
                            billRow[0]["TotalPrice"] = Int32.Parse(gridColumn6.SummaryItem.SummaryValue.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Không thể để hóa đơn trống.");
                        }
                    }
                    else
                    {
                        customerRow[0]["Number"] = Number - reduceNumber;
                        customerRow[0]["Total"] = (Number - reduceNumber) * Price;
                        BillDetails_BUS.EditNumberOfInfo(new BillDetails_DTO(currentIdBill, IdFood, Number - reduceNumber));
                        Bill_BUS.EditTotalOfBill(currentIdBill, Int32.Parse(gridColumn6.SummaryItem.SummaryValue.ToString()));
                        billRow[0]["TotalPrice"] = Int32.Parse(gridColumn6.SummaryItem.SummaryValue.ToString());
                    }
                }
            }
        }

        private void btnTeminate_Click(object sender, EventArgs e)
        {
            btnPay.Enabled = false;
            btnPrint.Enabled = false;
            btnTeminate.Enabled = false;
            btnMove.Enabled = false;
            btnAddInfo.Enabled = false;
            btnReduce.Enabled = false;
            Bill_BUS.DeleteAllOfBill(currentIdBill);
            billInfo.Rows.Clear();
            //xu ly table of bill
            for (int i = 0; i < tableofbill.Rows.Count; i++)
            {
                int idTable = Int32.Parse(tableofbill.Rows[i]["IdTable"].ToString());
                DataRow[] foundRows = tablelist.Select("IdTable = " + idTable);
                foundRows[0]["Status"] = 0;
                Table_BUS.EditStatusOfTable(idTable, 0);
                ((Button)flowLayoutPanel1.Controls[tableofbill.Rows[i]["IdTable"].ToString()]).Image = (Image)(Properties.Resources.available);
                flowLayoutPanel1.Controls[tableofbill.Rows[i]["IdTable"].ToString()].BackColor = Color.FromArgb(15, 216, 52);
            }
            if (tableofbill.Rows.Count < 1)
                gcBillTakeAway.DataSource = Bill_BUS.LoadBillTakeAway();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (tableofbill.Rows.Count > 0)
            {
                moving = true;
                btnConfirmMove.Visible = true;
                btnCancelMove.Visible = true;
                btnMove.Visible = false;
                btnCreateBill.Enabled = false;
                btnPay.Enabled = false;
                btnAddInfo.Enabled = false;
                btnReduce.Enabled = false;
                btnPrint.Enabled = false;
                btnTeminate.Enabled = false;
            }else
            {
                MessageBox.Show("Vui lòng chọn bàn muốn thao tác.");
            }
        }

        private void btnConfirmMove_Click(object sender, EventArgs e)
        {
            if (movingtable.Rows.Count > 0)
            {
                moving = false;
                btnConfirmMove.Visible = false;
                btnCancelMove.Visible = false;
                btnMove.Visible = true;
                btnPay.Enabled = true;
                btnAddInfo.Enabled = true;
                btnReduce.Enabled = true;
                btnPrint.Enabled = true;
                btnTeminate.Enabled = true;
                btnCreateBill.Enabled = true;
                BillTable_BUS.DeleteAllTablesOfBill(currentIdBill);
                for (int i = 0; i < tableofbill.Rows.Count; i++)
                {
                    int idTable = Int32.Parse(tableofbill.Rows[i]["IdTable"].ToString());
                    Table_BUS.EditStatusOfTable(idTable, 0);
                    DataRow[] foundRows = tablelist.Select("IdTable = " + idTable);
                    foundRows[0]["Status"] = 0;
                }
                for (int i = 0; i < movingtable.Rows.Count; i++)
                {
                    int idTable = Int32.Parse(movingtable.Rows[i]["IdTable"].ToString());
                    BillTable_BUS.AddTableIntoBill(new BillTable_DTO(currentIdBill, idTable));
                    Table_BUS.EditStatusOfTable(idTable, 1);
                    DataRow[] foundRows = tablelist.Select("IdTable = " + idTable);
                    foundRows[0]["Status"] = 1;
                    ((Button)flowLayoutPanel1.Controls[idTable.ToString()]).Image = (Image)(Properties.Resources.occupy);
                    flowLayoutPanel1.Controls[idTable.ToString()].BackColor = Color.FromArgb(249, 64, 64);
                }
                movingtable.Rows.Clear();
            }else
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 bàn.");
            }
        }

        private void btnCancelMove_Click(object sender, EventArgs e)
        {
            moving = false;
            btnConfirmMove.Visible = false;
            btnCancelMove.Visible = false;
            btnMove.Visible = true;
            btnPay.Enabled = true;
            btnAddInfo.Enabled = true;
            btnReduce.Enabled = true;
            btnPrint.Enabled = true;
            btnTeminate.Enabled = true;
            btnCreateBill.Enabled = true;
            for (int i = 0; i < movingtable.Rows.Count; i++)
            {
                string idTable = movingtable.Rows[i]["IdTable"].ToString();
                flowLayoutPanel1.Controls[idTable].BackColor = Color.FromArgb(15, 216, 52);
            }
            movingtable.Rows.Clear();
            for (int i = 0; i < tableofbill.Rows.Count; i++)
            {
                string idTable = tableofbill.Rows[i]["IdTable"].ToString();
                ((Button)flowLayoutPanel1.Controls[idTable]).Image = (Image)(Properties.Resources.occupy);
                flowLayoutPanel1.Controls[idTable].BackColor = Color.FromArgb(249, 64, 64);
            }
        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (creatingBill == false)
            {
                if (moving == false)
                {
                    tableofbill.Rows.Clear();
                    int idbill = Int32.Parse(gridView4.GetFocusedRowCellValue("IdBill").ToString());
                    currentIdBill = idbill;
                    nameBill.Text = "Hóa Đơn - " + idbill + " (Mang về)";
                    billInfo.Rows.Clear();
                    DataTable binfo = BillDetails_BUS.LoadBillInfoByIdBill(idbill);
                    foreach (DataRow dr in binfo.Rows)
                    {
                        billInfo.Rows.Add(dr.ItemArray);
                    }
                    //tbIdMonInBill.DataBindings.Clear();
                    //tbIdMonInBill.DataBindings.Add("Text", gcBillInfo.DataSource, "IdFood");
                    //tbTotal.Text = gridView4.GetFocusedRowCellValue("TotalPrice").ToString();
                    dtDate.Value = (DateTime)gridView4.GetFocusedRowCellValue("Date");
                    btnPay.Enabled = true;
                    btnAddInfo.Enabled = true;
                    btnReduce.Enabled = true;
                    btnPrint.Enabled = true;
                    btnTeminate.Enabled = true;
                    btnMove.Enabled = true;
                }
            }
            else
            {

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            dgvMenu.DataSource = Food_BUS.SearchByCategory(gridView1.GetFocusedRowCellValue("NameCategory").ToString());
        }
    }
}
