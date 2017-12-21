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
using System.Data.OleDb;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
namespace QuanLyQuanCafe.VIEW
{
    public partial class frmInvoice : Form
    {
        public frmInvoice()
        {
            InitializeComponent();
            InitializefrmInvoice();
        }
        private void InitializefrmInvoice()
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void frmInvoice_Load(object sender, EventArgs e)
        {
            DataSet dataSet11 = new DataSet();
            dataSet11.Tables.Add(Bill_BUS.LoadAllBill());
            dataSet11.Tables.Add(BillDetails_BUS.LoadAllBillDetails());
            dataSet11.Tables.Add(BillTable_BUS.LoadAllBillTable());

            DataColumn keyColumn = dataSet11.Tables[0].Columns["IdBill"];
            DataColumn foreignKeyColumn = dataSet11.Tables[1].Columns["IdBill"];
            dataSet11.Relations.Add("BidtoDetails", keyColumn, foreignKeyColumn);

            DataColumn keyColumn1 = dataSet11.Tables[0].Columns["IdBill"];
            DataColumn foreignKeyColumn1 = dataSet11.Tables[2].Columns["IdBill"];
            dataSet11.Relations.Add("BidtoTable", keyColumn1, foreignKeyColumn1);

            dgvBill.DataSource = dataSet11.Tables[0];
            dgvBill.ForceInitialize();

            //Details
            //Assign a GridView to the relationship
            GridView gridView1 = new GridView(dgvBill);
            dgvBill.LevelTree.Nodes.Add("BidtoDetails", gridView1);
            //Specify text to be displayed within detail tabs.
            gridView1.ViewCaption = "Chi tiết";

            //Create columns for the detail pattern View
            gridView1.PopulateColumns(dataSet11.Tables[1]);
            //Hide the BillID column for the detail View
            gridView1.Columns["IdBill"].VisibleIndex = -1;
            //Hide the Id of BillInFo column for the detail View
            gridView1.Columns["Id"].VisibleIndex = -1;

            ////Format Total column values as currency
            gridView1.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["Total"].DisplayFormat.FormatString = "n0";
            gridView1.Columns["Total"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Total"].Caption = "Tổng tiền (VNĐ)";
            gridView1.Columns["FoodName"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["FoodName"].Caption = "Tên Món";
            gridView1.Columns["Number"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Number"].Caption = "Số lượng";

            //Table
            //Assign a GridView to the relationship
            CardView cardView1 = new CardView(dgvBill);
            dgvBill.LevelTree.Nodes.Add("BidtoTable", cardView1);
            //Specify text to be displayed within detail tabs.
            cardView1.ViewCaption = "Bàn";

            //Create columns for the detail pattern View
            cardView1.PopulateColumns(dataSet11.Tables[2]);
            //Hide the BillID column for the detail View
            cardView1.Columns["IdBill"].VisibleIndex = -1;
            //Hide the Id of BillInFo column for the detail View
            cardView1.Columns["Id"].VisibleIndex = -1;
            cardView1.Columns["IdTable"].VisibleIndex = -1;
            //cardView1.Columns["IdTable"].OptionsColumn.AllowEdit = false;
            //cardView1.Columns["IdTable"].Caption = "ID";
            cardView1.Columns["Name"].OptionsColumn.AllowEdit = false;
            cardView1.Columns["Name"].Caption = "Bàn";
            cardView1.CardCaptionFormat = "Thông tin {0}";
            cardView1.OptionsView.ShowQuickCustomizeButton = false;
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                if (Convert.ToDecimal(e.Value) == 0) e.DisplayText = "Chưa thanh toán";
                if (Convert.ToDecimal(e.Value) == 1) e.DisplayText = "Đã thanh toán";
            }
        }

        private void dgvBill_Click(object sender, EventArgs e)
        {

        }
    }
}
