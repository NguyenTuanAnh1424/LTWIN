namespace LTWIN.Forms
{
    partial class FormOrderHistory
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
            panelTop = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            cmbTimeFilter = new ComboBox();
            lblTimeFilterTitle = new Label();
            lblHeaderTitle = new Label();
            panelMain = new TableLayoutPanel();
            grpOrders = new GroupBox();
            dgvOrders = new DataGridView();
            grpDetails = new GroupBox();
            dgvOrderDetails = new DataGridView();
            panelBottom = new Panel();
            btnExport = new Button();
            lblSummary = new Label();
            btnCancelOrder = new Button();
            btnRePrint = new Button();
            panelTop.SuspendLayout();
            panelMain.SuspendLayout();
            grpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(cmbTimeFilter);
            panelTop.Controls.Add(lblTimeFilterTitle);
            panelTop.Controls.Add(lblHeaderTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1097, 80);
            panelTop.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(47, 53, 66);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(977, 21);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(103, 40);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "🔍 Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.Location = new Point(709, 25);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã hóa đơn, tên khách...";
            txtSearch.Size = new Size(257, 29);
            txtSearch.TabIndex = 3;
            // 
            // cmbTimeFilter
            // 
            cmbTimeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimeFilter.Font = new Font("Segoe UI", 9.5F);
            cmbTimeFilter.FormattingEnabled = true;
            cmbTimeFilter.Items.AddRange(new object[] { "-- Tất cả thời gian --", "Hôm nay", "7 ngày gần đây", "Tháng này" });
            cmbTimeFilter.Location = new Point(503, 24);
            cmbTimeFilter.Margin = new Padding(3, 4, 3, 4);
            cmbTimeFilter.Name = "cmbTimeFilter";
            cmbTimeFilter.Size = new Size(188, 29);
            cmbTimeFilter.TabIndex = 2;
            cmbTimeFilter.SelectedIndexChanged += cmbTimeFilter_SelectedIndexChanged;
            // 
            // lblTimeFilterTitle
            // 
            lblTimeFilterTitle.AutoSize = true;
            lblTimeFilterTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimeFilterTitle.Location = new Point(434, 31);
            lblTimeFilterTitle.Name = "lblTimeFilterTitle";
            lblTimeFilterTitle.Size = new Size(78, 20);
            lblTimeFilterTitle.TabIndex = 1;
            lblTimeFilterTitle.Text = "Thời gian:";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.FromArgb(47, 53, 66);
            lblHeaderTitle.Location = new Point(17, 24);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(362, 28);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "📜 LỊCH SỬ BÁN HÀNG && HÓA ĐƠN";
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelMain.Controls.Add(grpOrders, 0, 0);
            panelMain.Controls.Add(grpDetails, 0, 1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 80);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 2;
            panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            panelMain.Size = new Size(1097, 633);
            panelMain.TabIndex = 1;
            // 
            // grpOrders
            // 
            grpOrders.Controls.Add(dgvOrders);
            grpOrders.Dock = DockStyle.Fill;
            grpOrders.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpOrders.Location = new Point(11, 13);
            grpOrders.Margin = new Padding(11, 13, 11, 13);
            grpOrders.Name = "grpOrders";
            grpOrders.Padding = new Padding(3, 4, 3, 4);
            grpOrders.Size = new Size(1075, 322);
            grpOrders.TabIndex = 0;
            grpOrders.TabStop = false;
            grpOrders.Text = "📋 Danh Sách Hóa Đơn Đã Lập";
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.BorderStyle = BorderStyle.None;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.Location = new Point(3, 26);
            dgvOrders.Margin = new Padding(3, 4, 3, 4);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.RowTemplate.Height = 32;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(1069, 292);
            dgvOrders.TabIndex = 0;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(dgvOrderDetails);
            grpDetails.Dock = DockStyle.Fill;
            grpDetails.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDetails.Location = new Point(11, 361);
            grpDetails.Margin = new Padding(11, 13, 11, 13);
            grpDetails.Name = "grpDetails";
            grpDetails.Padding = new Padding(3, 4, 3, 4);
            grpDetails.Size = new Size(1075, 259);
            grpDetails.TabIndex = 1;
            grpDetails.TabStop = false;
            grpDetails.Text = "🛍️ Chi Tiết Các Mẫu Giày Trong Hóa Đơn Được Chọn";
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.AllowUserToAddRows = false;
            dgvOrderDetails.AllowUserToDeleteRows = false;
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.BackgroundColor = Color.White;
            dgvOrderDetails.BorderStyle = BorderStyle.None;
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetails.Dock = DockStyle.Fill;
            dgvOrderDetails.Location = new Point(3, 26);
            dgvOrderDetails.Margin = new Padding(3, 4, 3, 4);
            dgvOrderDetails.MultiSelect = false;
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.ReadOnly = true;
            dgvOrderDetails.RowHeadersVisible = false;
            dgvOrderDetails.RowHeadersWidth = 51;
            dgvOrderDetails.RowTemplate.Height = 30;
            dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderDetails.Size = new Size(1069, 229);
            dgvOrderDetails.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(248, 249, 250);
            panelBottom.Controls.Add(btnExport);
            panelBottom.Controls.Add(lblSummary);
            panelBottom.Controls.Add(btnCancelOrder);
            panelBottom.Controls.Add(btnRePrint);
            panelBottom.Cursor = Cursors.Hand;
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            panelBottom.Location = new Point(0, 713);
            panelBottom.Margin = new Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(17, 20, 17, 20);
            panelBottom.Size = new Size(1097, 80);
            panelBottom.TabIndex = 2;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.DimGray;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.ForeColor = SystemColors.ButtonFace;
            btnExport.Location = new Point(503, 14);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(166, 48);
            btnExport.TabIndex = 3;
            btnExport.Text = "📊 Xuất Excel/CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSummary.ForeColor = Color.FromArgb(47, 53, 66);
            lblSummary.Location = new Point(17, 27);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(249, 23);
            lblSummary.TabIndex = 2;
            lblSummary.Text = "📊 Tổng cộng: 0 đơn | 0 VNĐ";
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelOrder.BackColor = Color.FromArgb(255, 71, 87);
            btnCancelOrder.FlatAppearance.BorderSize = 0;
            btnCancelOrder.FlatStyle = FlatStyle.Flat;
            btnCancelOrder.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancelOrder.ForeColor = Color.White;
            btnCancelOrder.Location = new Point(902, 14);
            btnCancelOrder.Margin = new Padding(3, 4, 3, 4);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(178, 48);
            btnCancelOrder.TabIndex = 1;
            btnCancelOrder.Text = "🚫 Hủy Đơn Hàng";
            btnCancelOrder.UseVisualStyleBackColor = false;
            btnCancelOrder.Click += btnCancelOrder_Click;
            // 
            // btnRePrint
            // 
            btnRePrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRePrint.BackColor = Color.FromArgb(30, 144, 255);
            btnRePrint.FlatAppearance.BorderSize = 0;
            btnRePrint.FlatStyle = FlatStyle.Flat;
            btnRePrint.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRePrint.ForeColor = Color.White;
            btnRePrint.Location = new Point(675, 14);
            btnRePrint.Margin = new Padding(3, 4, 3, 4);
            btnRePrint.Name = "btnRePrint";
            btnRePrint.Size = new Size(221, 48);
            btnRePrint.TabIndex = 0;
            btnRePrint.Text = "🖨️ Xem && In Lại Hóa Đơn";
            btnRePrint.UseVisualStyleBackColor = false;
            btnRePrint.Click += btnRePrint_Click;
            // 
            // FormOrderHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 793);
            Controls.Add(panelMain);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormOrderHistory";
            Text = "Quản Lý Lịch Sử Hóa Đơn";
            Load += FormOrderHistory_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMain.ResumeLayout(false);
            grpOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            grpDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblHeaderTitle;
        private Label lblTimeFilterTitle;
        private ComboBox cmbTimeFilter;
        private TextBox txtSearch;
        private Button btnSearch;
        private TableLayoutPanel panelMain;
        private GroupBox grpOrders;
        private DataGridView dgvOrders;
        private GroupBox grpDetails;
        private DataGridView dgvOrderDetails;
        private Panel panelBottom;
        private Button btnRePrint;
        private Button btnCancelOrder;
        private Label lblSummary;
        private Button btnExport;
    }
}
