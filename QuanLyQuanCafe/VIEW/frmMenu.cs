using System;
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

namespace QuanLyQuanCafe.VIEW
{
    public partial class frmMenu : Form
    {
        int flagThem = 0;
        int flagSua = 0;
        int flagTim = 0;
        public frmMenu()
        {
            InitializeComponent();
            LoadFood();
            
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            dgvMenu.DataSource = Food_BUS.LoadFood();
            bindingData();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa " + tbTen.Text + " ?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        Food_BUS.DeleteFood(tbMa.Text);
                        MessageBox.Show("Xóa hoàn tất");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xóa");
                    }
                    
                    

                }
                dgvMenu.DataSource = Food_BUS.LoadFood();
                bindingData();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void LoadFood()
        {
            tbMa.Enabled = false;
            tbTen.ReadOnly = true;
            tbDG.ReadOnly = true;
            cbDV.Enabled = false;
            cbLoai.Enabled = false;
            btHuy.Enabled = false;
            cbLoai.DataSource = FoodCategory_BUS.LoadFoodCategory();
            cbLoai.DisplayMember = "NameCategory";
            cbLoai.ValueMember = "NameCategory";
            cbDV.DataSource = FoodUnit_BUS.LoadFoodUnit();
            cbDV.DisplayMember = "NameUnit";
            cbDV.ValueMember = "NameUnit";

        }

        private void bindingData()
        {
            tbMa.DataBindings.Clear();
            tbMa.DataBindings.Add("Text", dgvMenu.DataSource, "IdFood");
            tbTen.DataBindings.Clear();
            tbTen.DataBindings.Add("Text", dgvMenu.DataSource, "Name");
            cbLoai.DataBindings.Clear();
            cbLoai.DataBindings.Add("Text", dgvMenu.DataSource, "NameCategory");
            tbDG.DataBindings.Clear();
            tbDG.DataBindings.Add("Text", dgvMenu.DataSource, "Price");
            cbDV.DataBindings.Clear();
            cbDV.DataBindings.Add("Text", dgvMenu.DataSource, "NameUnit");
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (flagThem == 0) // chọn thêm
            {
                flagThem = 1;
                btThem.Text = "Lưu";
                tbTen.ReadOnly = false;
                tbDG.ReadOnly = false;
                cbDV.Enabled = true;
                cbLoai.Enabled = true;
                btXoa.Enabled = false;
                btSua.Enabled = false;
                btHuy.Enabled = true;
                tbTen.Text = "";
                tbDG.Text = "";

            }
            else
            {
                if (tbTen.Text.Trim() != "" && tbDG.Text.Trim() != "")
                {
                    if (Food_BUS.isExistedFood(tbTen.Text.Trim()) == 0) // Chọn lưu
                    {
                        flagThem = 0;
                        btThem.Text = "Thêm";
                        tbTen.ReadOnly = true;
                        tbDG.ReadOnly = true;
                        cbDV.Enabled = false;
                        cbLoai.Enabled = false;
                        btXoa.Enabled = true;
                        btSua.Enabled = true;
                        btHuy.Enabled = false;
                        Food_DTO food = new Food_DTO(tbTen.Text, FoodCategory_BUS.getIdCategoryByName(cbLoai.Text), FoodUnit_BUS.getIdUnitByName(cbDV.Text), float.Parse(tbDG.Text));
                        try
                        {
                            Food_BUS.AddFood(food);
                            MessageBox.Show("Thêm thành công");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thêm thất bại");
                        }

                        dgvMenu.DataSource = Food_BUS.LoadFood();
                        bindingData();
                    }else
                    {
                        MessageBox.Show("Món này đã tồn tại.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                }
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
                if (flagSua == 0) // chọn sửa
                {
                    flagSua = 1;
                    btSua.Text = "Lưu";
                    tbTen.ReadOnly = false;
                    tbDG.ReadOnly = false;
                    cbDV.Enabled = true;
                    cbLoai.Enabled = true;
                    btXoa.Enabled = false;
                    btThem.Enabled = false;
                    btHuy.Enabled = true;
                }
                else
                {
                    if (tbTen.Text.Trim() != "" && tbDG.Text.Trim() != "")
                    {
                        if (flagSua == 1) // Chọn lưu
                        {
                            flagSua = 0;
                            btSua.Text = "Sửa";
                            tbTen.ReadOnly = true;
                            tbDG.ReadOnly = true;
                            cbDV.Enabled = false;
                            cbLoai.Enabled = false;
                            btXoa.Enabled = true;
                            btThem.Enabled = true;
                            btHuy.Enabled = false;
                            Food_DTO food = new Food_DTO(Int32.Parse(tbMa.Text), tbTen.Text, FoodCategory_BUS.getIdCategoryByName(cbLoai.Text), FoodUnit_BUS.getIdUnitByName(cbDV.Text), float.Parse(tbDG.Text));
                            try
                            {
                                Food_BUS.EditFood(food);
                                MessageBox.Show("Cập nhật hoàn tất");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Cập nhật thất bại");
                            }

                            dgvMenu.DataSource = Food_BUS.LoadFood();
                            bindingData();

                        }
                    }else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    }
                }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            LoadFood();
            dgvMenu.DataSource = Food_BUS.LoadFood();
            bindingData();
            btThem.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;
            btHuy.Enabled = false;
            flagSua = 0;
            flagThem = 0;
            btSua.Text = "Sửa";
            btThem.Text = "Thêm";
        }

        private void dgvMenu_Click(object sender, EventArgs e)
        {

        }

        private void dgvMenu_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
        }

       

        private void tbTen_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbMa_TextChanged(object sender, EventArgs e)

        {
            

        }

        private void rbTen_CheckedChanged(object sender, EventArgs e)
        {
            flagTim = 0;
        }

        private void rbLoai_CheckedChanged(object sender, EventArgs e)
        {
            flagTim = 1;
        }

        

  

        private void btThemLoai_Click(object sender, EventArgs e)
        {
            if (FoodCategory_BUS.isExistedCategory(tbLoaiMoi.Text.Trim()) == 1)
            {
                MessageBox.Show("Loại này đã tồn tại.");
            }
            else
            {
                try
                {
                    FoodCategory_BUS.AddFoodCategory(tbLoaiMoi.Text);
                    LoadFood();
                    MessageBox.Show("Thêm loại mới thành công");
                    tbLoaiMoi.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void tbDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
