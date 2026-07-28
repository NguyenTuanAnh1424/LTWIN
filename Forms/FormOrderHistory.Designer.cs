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
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(960, 60);
            panelTop.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(47, 53, 66);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(855, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 30);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "🔍 Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.Location = new Point(620, 19);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã hóa đơn, tên khách...";
            txtSearch.Size = new Size(225, 24);
            txtSearch.TabIndex = 3;
            // 
            // cmbTimeFilter
            // 
            cmbTimeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimeFilter.Font = new Font("Segoe UI", 9.5F);
            cmbTimeFilter.FormattingEnabled = true;
            cmbTimeFilter.Items.AddRange(new object[] { "-- Tất cả thời gian --", "Hôm nay", "7 ngày gần đây", "Tháng này" });
            cmbTimeFilter.Location = new Point(440, 18);
            cmbTimeFilter.Name = "cmbTimeFilter";
            cmbTimeFilter.Size = new Size(165, 25);
            cmbTimeFilter.TabIndex = 2;
            cmbTimeFilter.SelectedIndexChanged += cmbTimeFilter_SelectedIndexChanged;
            // 
            // lblTimeFilterTitle
            // 
            lblTimeFilterTitle.AutoSize = true;
            lblTimeFilterTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimeFilterTitle.Location = new Point(380, 23);
            lblTimeFilterTitle.Name = "lblTimeFilterTitle";
            lblTimeFilterTitle.Size = new Size(57, 15);
            lblTimeFilterTitle.TabIndex = 1;
            lblTimeFilterTitle.Text = "Thời gian:";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.FromArgb(47, 53, 66);
            lblHeaderTitle.Location = new Point(15, 18);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(254, 21);
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
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 2;
            panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            panelMain.Size = new Size(960, 475);
            panelMain.TabIndex = 1;
            // 
            // grpOrders
            // 
            grpOrders.Controls.Add(dgvOrders);
            grpOrders.Dock = DockStyle.Fill;
            grpOrders.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpOrders.Location = new Point(10, 10);
            grpOrders.Margin = new Padding(10);
            grpOrders.Name = "grpOrders";
            grpOrders.Size = new Size(940, 241);
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
            dgvOrders.Location = new Point(3, 20);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowTemplate.Height = 32;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(934, 218);
            dgvOrders.TabIndex = 0;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(dgvOrderDetails);
            grpDetails.Dock = DockStyle.Fill;
            grpDetails.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDetails.Location = new Point(10, 271);
            grpDetails.Margin = new Padding(10);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(940, 194);
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
            dgvOrderDetails.Location = new Point(3, 20);
            dgvOrderDetails.MultiSelect = false;
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.ReadOnly = true;
            dgvOrderDetails.RowHeadersVisible = false;
            dgvOrderDetails.RowTemplate.Height = 30;
            dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderDetails.Size = new Size(934, 171);
            dgvOrderDetails.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(248, 249, 250);
            panelBottom.Controls.Add(lblSummary);
            panelBottom.Controls.Add(btnCancelOrder);
            panelBottom.Controls.Add(btnRePrint);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 535);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(15);
            panelBottom.Size = new Size(960, 60);
            panelBottom.TabIndex = 2;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSummary.ForeColor = Color.FromArgb(47, 53, 66);
            lblSummary.Location = new Point(15, 20);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(205, 19);
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
            btnCancelOrder.Location = new Point(810, 12);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(135, 36);
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
            btnRePrint.Location = new Point(625, 12);
            btnRePrint.Name = "btnRePrint";
            btnRePrint.Size = new Size(175, 36);
            btnRePrint.TabIndex = 0;
            btnRePrint.Text = "🖨️ Xem && In Lại Hóa Đơn";
            btnRePrint.UseVisualStyleBackColor = false;
            btnRePrint.Click += btnRePrint_Click;
            // 
            // FormOrderHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 595);
            Controls.Add(panelMain);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
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
    }
}
