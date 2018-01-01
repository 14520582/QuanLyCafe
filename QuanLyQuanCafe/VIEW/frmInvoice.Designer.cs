namespace QuanLyQuanCafe.VIEW
{
    partial class frmInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoice));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvBill = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.refreshButton = new DevExpress.XtraEditors.SimpleButton();
            this.searchButton = new DevExpress.XtraEditors.SimpleButton();
            this.exportButton = new DevExpress.XtraEditors.SimpleButton();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5});
            this.gridView2.GridControl = this.dgvBill;
            this.gridView2.Name = "gridView2";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ID";
            this.gridColumn5.FieldName = "Id";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            // 
            // dgvBill
            // 
            this.dgvBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBill.Location = new System.Drawing.Point(0, 56);
            this.dgvBill.MainView = this.gridView1;
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.Size = new System.Drawing.Size(860, 425);
            this.dgvBill.TabIndex = 1;
            this.dgvBill.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            this.dgvBill.Click += new System.EventHandler(this.dgvBill_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.dgvBill;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số Hóa Đơn";
            this.gridColumn1.FieldName = "IdBill";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 70;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn2.Caption = "Ngày Lập";
            this.gridColumn2.FieldName = "Date";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 206;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tổng Tiền (VNĐ)";
            this.gridColumn3.DisplayFormat.FormatString = "n0";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "TotalPrice";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 233;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Trạng Thái";
            this.gridColumn4.FieldName = "Status";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 187;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.refreshButton);
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Controls.Add(this.exportButton);
            this.groupBox1.Controls.Add(this.toDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fromDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // refreshButton
            // 
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.Location = new System.Drawing.Point(304, 18);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(26, 23);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(356, 18);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Tìm";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(437, 18);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Xuất ra Excel";
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // toDate
            // 
            this.toDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDate.Location = new System.Drawing.Point(192, 19);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(106, 21);
            this.toDate.TabIndex = 3;
            this.toDate.ValueChanged += new System.EventHandler(this.toDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // fromDate
            // 
            this.fromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDate.Location = new System.Drawing.Point(39, 19);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(106, 21);
            this.fromDate.TabIndex = 1;
            this.fromDate.ValueChanged += new System.EventHandler(this.fromDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ";
            // 
            // frmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 481);
            this.Controls.Add(this.dgvBill);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmInvoice";
            this.Text = "Hóa Đơn";
            this.Load += new System.EventHandler(this.frmInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fromDate;
        private DevExpress.XtraEditors.SimpleButton searchButton;
        private DevExpress.XtraEditors.SimpleButton exportButton;
        private DevExpress.XtraGrid.GridControl dgvBill;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton refreshButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}