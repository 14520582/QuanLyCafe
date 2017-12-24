namespace QuanLyQuanCafe.VIEW
{
    partial class Ngan
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
            this.dgvLoai = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Category = new DevExpress.XtraGrid.Columns.GridColumn();
            this.image = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.dgvMenu = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbLoai = new System.Windows.Forms.TextBox();
            this.quanLyQuanCafeDataSet11 = new QuanLyQuanCafe.QuanLyQuanCafeDataSet1();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCafeDataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoai
            // 
            this.dgvLoai.Location = new System.Drawing.Point(5, 5);
            this.dgvLoai.MainView = this.gridView1;
            this.dgvLoai.Name = "dgvLoai";
            this.dgvLoai.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.image});
            this.dgvLoai.Size = new System.Drawing.Size(364, 188);
            this.dgvLoai.TabIndex = 0;
            this.dgvLoai.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dgvLoai.Click += new System.EventHandler(this.dgvLoai_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Category});
            this.gridView1.GridControl = this.dgvLoai;
            this.gridView1.Name = "gridView1";
            // 
            // Category
            // 
            this.Category.Caption = "Loại";
            this.Category.FieldName = "NameCategory";
            this.Category.Name = "Category";
            this.Category.Visible = true;
            this.Category.VisibleIndex = 0;
            this.Category.Width = 301;
            // 
            // image
            // 
            this.image.Name = "image";
            // 
            // dgvMenu
            // 
            this.dgvMenu.Location = new System.Drawing.Point(5, 218);
            this.dgvMenu.MainView = this.gridView2;
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.Size = new System.Drawing.Size(364, 271);
            this.dgvMenu.TabIndex = 1;
            this.dgvMenu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView2.GridControl = this.dgvMenu;
            this.gridView2.Name = "gridView2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Đơn vị tính";
            this.gridColumn2.FieldName = "NameUnit";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Đơn giá";
            this.gridColumn3.FieldName = "Price";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // tbLoai
            // 
            this.tbLoai.Location = new System.Drawing.Point(12, 154);
            this.tbLoai.Name = "tbLoai";
            this.tbLoai.Size = new System.Drawing.Size(100, 20);
            this.tbLoai.TabIndex = 2;
            this.tbLoai.TextChanged += new System.EventHandler(this.tbLoai_TextChanged);
            // 
            // quanLyQuanCafeDataSet11
            // 
            this.quanLyQuanCafeDataSet11.DataSetName = "QuanLyQuanCafeDataSet1";
            this.quanLyQuanCafeDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Ngan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 501);
            this.Controls.Add(this.dgvMenu);
            this.Controls.Add(this.dgvLoai);
            this.Controls.Add(this.tbLoai);
            this.Name = "Ngan";
            this.Text = "Ngan";
            this.Load += new System.EventHandler(this.Ngan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCafeDataSet11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgvLoai;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Category;
        private DevExpress.XtraGrid.GridControl dgvMenu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.TextBox tbLoai;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit image;
        private QuanLyQuanCafeDataSet1 quanLyQuanCafeDataSet11;
    }
}