namespace QuanLyQuanCafe.VIEW
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.foodCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyQuanCafeDataSet1 = new QuanLyQuanCafe.QuanLyQuanCafeDataSet1();
            this.cbDV = new System.Windows.Forms.ComboBox();
            this.unitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyQuanCafeDataSet = new QuanLyQuanCafe.QuanLyQuanCafeDataSet();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.tbMa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDG = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btSua = new DevExpress.XtraEditors.SimpleButton();
            this.btXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btThem = new DevExpress.XtraEditors.SimpleButton();
            this.search = new DevExpress.XtraEditors.SearchControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dgvMenu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idFood = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FoodName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Category = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitTableAdapter = new QuanLyQuanCafe.QuanLyQuanCafeDataSetTableAdapters.UnitTableAdapter();
            this.foodCategoryTableAdapter = new QuanLyQuanCafe.QuanLyQuanCafeDataSet1TableAdapters.FoodCategoryTableAdapter();
            this.rbTen = new System.Windows.Forms.RadioButton();
            this.rbLoai = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foodCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCafeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCafeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cbLoai);
            this.groupControl1.Controls.Add(this.cbDV);
            this.groupControl1.Controls.Add(this.tbTen);
            this.groupControl1.Controls.Add(this.tbMa);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.tbDG);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.btHuy);
            this.groupControl1.Controls.Add(this.btSua);
            this.groupControl1.Controls.Add(this.btXoa);
            this.groupControl1.Controls.Add(this.btThem);
            this.groupControl1.Location = new System.Drawing.Point(8, 171);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(235, 219);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Thức uống";
            // 
            // cbLoai
            // 
            this.cbLoai.DataSource = this.foodCategoryBindingSource;
            this.cbLoai.DisplayMember = "NameCategory";
            this.cbLoai.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Location = new System.Drawing.Point(63, 49);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(160, 24);
            this.cbLoai.TabIndex = 30;
            this.cbLoai.ValueMember = "NameCategory";
            // 
            // foodCategoryBindingSource
            // 
            this.foodCategoryBindingSource.DataMember = "FoodCategory";
            this.foodCategoryBindingSource.DataSource = this.quanLyQuanCafeDataSet1;
            // 
            // quanLyQuanCafeDataSet1
            // 
            this.quanLyQuanCafeDataSet1.DataSetName = "QuanLyQuanCafeDataSet1";
            this.quanLyQuanCafeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbDV
            // 
            this.cbDV.DataSource = this.unitBindingSource;
            this.cbDV.DisplayMember = "NameUnit";
            this.cbDV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDV.FormattingEnabled = true;
            this.cbDV.Location = new System.Drawing.Point(90, 81);
            this.cbDV.Name = "cbDV";
            this.cbDV.Size = new System.Drawing.Size(133, 24);
            this.cbDV.TabIndex = 29;
            this.cbDV.ValueMember = "NameUnit";
            // 
            // unitBindingSource
            // 
            this.unitBindingSource.DataMember = "Unit";
            this.unitBindingSource.DataSource = this.quanLyQuanCafeDataSet;
            // 
            // quanLyQuanCafeDataSet
            // 
            this.quanLyQuanCafeDataSet.DataSetName = "QuanLyQuanCafeDataSet";
            this.quanLyQuanCafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbTen
            // 
            this.tbTen.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTen.Location = new System.Drawing.Point(63, 20);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(160, 23);
            this.tbTen.TabIndex = 28;
            this.tbTen.Text = "1";
            this.tbTen.TextChanged += new System.EventHandler(this.tbTen_TextChanged);
            // 
            // tbMa
            // 
            this.tbMa.Location = new System.Drawing.Point(194, 22);
            this.tbMa.Name = "tbMa";
            this.tbMa.Size = new System.Drawing.Size(27, 21);
            this.tbMa.TabIndex = 27;
            this.tbMa.TextChanged += new System.EventHandler(this.tbMa_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(14, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Đơn vị tính";
            // 
            // tbDG
            // 
            this.tbDG.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDG.Location = new System.Drawing.Point(89, 114);
            this.tbDG.Name = "tbDG";
            this.tbDG.Size = new System.Drawing.Size(132, 23);
            this.tbDG.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(14, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Đơn giá";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tên";
            // 
            // btHuy
            // 
            this.btHuy.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuy.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btHuy.Appearance.Options.UseFont = true;
            this.btHuy.Appearance.Options.UseForeColor = true;
            this.btHuy.Image = ((System.Drawing.Image)(resources.GetObject("btHuy.Image")));
            this.btHuy.Location = new System.Drawing.Point(118, 177);
            this.btHuy.Name = "btHuy";
            this.btHuy.Size = new System.Drawing.Size(103, 24);
            this.btHuy.TabIndex = 11;
            this.btHuy.Text = "Hủy";
            this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
            // 
            // btSua
            // 
            this.btSua.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btSua.Appearance.Options.UseFont = true;
            this.btSua.Appearance.Options.UseForeColor = true;
            this.btSua.Image = ((System.Drawing.Image)(resources.GetObject("btSua.Image")));
            this.btSua.Location = new System.Drawing.Point(12, 177);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(103, 24);
            this.btSua.TabIndex = 10;
            this.btSua.Text = "Sửa";
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btXoa
            // 
            this.btXoa.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btXoa.Appearance.Options.UseFont = true;
            this.btXoa.Appearance.Options.UseForeColor = true;
            this.btXoa.Image = ((System.Drawing.Image)(resources.GetObject("btXoa.Image")));
            this.btXoa.Location = new System.Drawing.Point(118, 147);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(103, 24);
            this.btXoa.TabIndex = 9;
            this.btXoa.Text = "Xóa";
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btThem
            // 
            this.btThem.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btThem.Appearance.Options.UseFont = true;
            this.btThem.Appearance.Options.UseForeColor = true;
            this.btThem.Image = ((System.Drawing.Image)(resources.GetObject("btThem.Image")));
            this.btThem.Location = new System.Drawing.Point(13, 147);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(102, 24);
            this.btThem.TabIndex = 8;
            this.btThem.Text = "Thêm";
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // search
            // 
            this.search.EditValue = "";
            this.search.Location = new System.Drawing.Point(10, 102);
            this.search.Name = "search";
            this.search.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Properties.Appearance.Options.UseFont = true;
            this.search.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.search.Size = new System.Drawing.Size(233, 22);
            this.search.TabIndex = 4;
            this.search.SelectedIndexChanged += new System.EventHandler(this.searchControl1_SelectedIndexChanged);
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyQuanCafe.Properties.Resources.a0164_sl;
            this.pictureBox1.Location = new System.Drawing.Point(10, -8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Showcard Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelX4.Location = new System.Drawing.Point(151, 12);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(477, 83);
            this.labelX4.TabIndex = 14;
            this.labelX4.Text = "MENU";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX4.Click += new System.EventHandler(this.labelX4_Click);
            // 
            // dgvMenu
            // 
            this.dgvMenu.Location = new System.Drawing.Point(250, 101);
            this.dgvMenu.MainView = this.gridView1;
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.Size = new System.Drawing.Size(490, 353);
            this.dgvMenu.TabIndex = 15;
            this.dgvMenu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dgvMenu.FocusedViewChanged += new DevExpress.XtraGrid.ViewFocusEventHandler(this.dgvMenu_FocusedViewChanged);
            this.dgvMenu.Click += new System.EventHandler(this.dgvMenu_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idFood,
            this.FoodName,
            this.Category,
            this.Unit,
            this.Price});
            this.gridView1.GridControl = this.dgvMenu;
            this.gridView1.Name = "gridView1";
            // 
            // idFood
            // 
            this.idFood.Caption = "Mã";
            this.idFood.FieldName = "IdFood";
            this.idFood.Name = "idFood";
            this.idFood.Visible = true;
            this.idFood.VisibleIndex = 0;
            // 
            // FoodName
            // 
            this.FoodName.Caption = "Tên";
            this.FoodName.FieldName = "Name";
            this.FoodName.Name = "FoodName";
            this.FoodName.Visible = true;
            this.FoodName.VisibleIndex = 1;
            // 
            // Category
            // 
            this.Category.Caption = "Loại";
            this.Category.FieldName = "NameCategory";
            this.Category.Name = "Category";
            this.Category.Visible = true;
            this.Category.VisibleIndex = 2;
            // 
            // Unit
            // 
            this.Unit.Caption = "Đơn vị";
            this.Unit.FieldName = "NameUnit";
            this.Unit.Name = "Unit";
            this.Unit.Visible = true;
            this.Unit.VisibleIndex = 3;
            // 
            // Price
            // 
            this.Price.Caption = "Giá";
            this.Price.FieldName = "Price";
            this.Price.Name = "Price";
            this.Price.Visible = true;
            this.Price.VisibleIndex = 4;
            // 
            // unitTableAdapter
            // 
            this.unitTableAdapter.ClearBeforeFill = true;
            // 
            // foodCategoryTableAdapter
            // 
            this.foodCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // rbTen
            // 
            this.rbTen.AutoSize = true;
            this.rbTen.Checked = true;
            this.rbTen.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTen.Location = new System.Drawing.Point(110, 135);
            this.rbTen.Name = "rbTen";
            this.rbTen.Size = new System.Drawing.Size(48, 20);
            this.rbTen.TabIndex = 16;
            this.rbTen.TabStop = true;
            this.rbTen.Text = "Tên";
            this.rbTen.UseVisualStyleBackColor = true;
            this.rbTen.CheckedChanged += new System.EventHandler(this.rbTen_CheckedChanged);
            // 
            // rbLoai
            // 
            this.rbLoai.AutoSize = true;
            this.rbLoai.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLoai.Location = new System.Drawing.Point(182, 135);
            this.rbLoai.Name = "rbLoai";
            this.rbLoai.Size = new System.Drawing.Size(49, 20);
            this.rbLoai.TabIndex = 17;
            this.rbLoai.TabStop = true;
            this.rbLoai.Text = "Loại";
            this.rbLoai.UseVisualStyleBackColor = true;
            this.rbLoai.CheckedChanged += new System.EventHandler(this.rbLoai_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(12, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tìm theo";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 467);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbLoai);
            this.Controls.Add(this.rbTen);
            this.Controls.Add(this.dgvMenu);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.search);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmMenu";
            this.Text = "Thực đơn";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foodCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCafeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCafeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SearchControl search;

        private DevExpress.XtraEditors.SimpleButton btThem;
        private DevExpress.XtraEditors.SimpleButton btXoa;
        private DevExpress.XtraEditors.SimpleButton btHuy;
        private DevExpress.XtraEditors.SimpleButton btSua;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDG;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.GridControl dgvMenu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn idFood;
        private DevExpress.XtraGrid.Columns.GridColumn FoodName;
        private DevExpress.XtraGrid.Columns.GridColumn Category;
        private DevExpress.XtraGrid.Columns.GridColumn Unit;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.TextBox tbMa;
        private System.Windows.Forms.ComboBox cbDV;
        private QuanLyQuanCafeDataSet quanLyQuanCafeDataSet;
        private System.Windows.Forms.BindingSource unitBindingSource;
        private QuanLyQuanCafeDataSetTableAdapters.UnitTableAdapter unitTableAdapter;
        private System.Windows.Forms.ComboBox cbLoai;
        private QuanLyQuanCafeDataSet1 quanLyQuanCafeDataSet1;
        private System.Windows.Forms.BindingSource foodCategoryBindingSource;
        private QuanLyQuanCafeDataSet1TableAdapters.FoodCategoryTableAdapter foodCategoryTableAdapter;
        private System.Windows.Forms.RadioButton rbTen;
        private System.Windows.Forms.RadioButton rbLoai;
        private System.Windows.Forms.Label label5;
    }
}