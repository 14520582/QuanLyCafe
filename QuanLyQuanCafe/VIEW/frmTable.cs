using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;
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
    public partial class frmTable : Form
    {
        public frmTable()
        {
            InitializeComponent();
            LoadTable();
        }
        private void frmTable_Load(object sender, EventArgs e)
        {
            dgvBan.DataSource = Table_BUS.LoadTable();
            bindingData();
            btnLuu.Enabled = false;
        }
        private void LoadTable()
        {
            txtSoLuong.Text = Table_BUS.CountTable().ToString();
            txtBan.ReadOnly = true;
            txtViTri.ReadOnly = true;
            cbxTinhTrang.Enabled = false; 
                                                   
        }
        int flag = 1; //Add: 1, edit: 0
        //bind dữ liệu
        private void bindingData()
        {
            txtBan.DataBindings.Clear();
            txtBan.DataBindings.Add("Text", dgvBan.DataSource, "Name");
            txtViTri.DataBindings.Clear();
            txtViTri.DataBindings.Add("Text", dgvBan.DataSource, "Location");
            cbxTinhTrang.DataBindings.Clear();
            cbxTinhTrang.DataBindings.Add("ValueMember", dgvBan.DataSource, "Status");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            txtBan.ReadOnly = false;
            txtViTri.ReadOnly = false;
            cbxTinhTrang.Enabled = true;

            txtBan.Text = "";
            txtViTri.Text = "";
            cbxTinhTrang.Text = "Trống";

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;                   
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtBan.Text.Trim() != "" && txtViTri.Text.Trim() != "")
            {
                if (flag == 1) //thêm
                {
                    if (Table_BUS.CheckValidTable(txtBan.Text) == 1)
                    {
                        string status;
                        if (cbxTinhTrang.Text == "Trống")
                        {
                            status = "0";
                        }
                        else
                            status = "1";
                        Table_DTO table = new Table_DTO(txtBan.Text, txtViTri.Text, status);
                        Table_BUS.AddTable(table);
                        MessageBox.Show("Lưu thành công");
                    }
                    else
                    {
                        MessageBox.Show("Đã Tồn tại bàn " + txtBan.Text);
                    }
                }
                else //sửa
                {
                    string status;
                    if (cbxTinhTrang.Text == "Trống")
                    {
                        status = "0";
                    }
                    else
                        status = "1";
                    DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    Table_DTO table = new Table_DTO(txtBan.Text, txtViTri.Text, status);
                    Table_BUS.EditTable(table, row[0].ToString());
                    MessageBox.Show("Sửa thành công");

                }
                dgvBan.DataSource = Table_BUS.LoadTable();
                bindingData();
                txtBan.ReadOnly = true;
                txtViTri.ReadOnly = true;
                cbxTinhTrang.Enabled = false;
                txtSoLuong.Text = Table_BUS.CountTable().ToString();
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }else
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa " + txtBan.Text + " ?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                Table_BUS.DeleteTable(row[0].ToString());
                MessageBox.Show("Xóa hoàn tất");
            }
            dgvBan.DataSource = Table_BUS.LoadTable();
            bindingData();
            txtSoLuong.Text = Table_BUS.CountTable().ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadTable();
            dgvBan.DataSource = Table_BUS.LoadTable();
            bindingData();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 0;
            txtBan.ReadOnly = false;
            txtViTri.ReadOnly = false;
            cbxTinhTrang.Enabled = true;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;

        }

        private void dgvBan_Click(object sender, EventArgs e)
        {

        }

        private void cbxTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                if (Convert.ToDecimal(e.Value) == 0) e.DisplayText = "Trống";
                if (Convert.ToDecimal(e.Value) == 1) e.DisplayText = "Đang sử dụng";
            }
        }

        private void cbxTinhTrang_ValueMemberChanged(object sender, EventArgs e)
        {
            if(Int32.Parse(cbxTinhTrang.ValueMember) == 0)
                cbxTinhTrang.Text = "Trống";
            else
                cbxTinhTrang.Text = "Đang sử dụng";
        }
    }
}
