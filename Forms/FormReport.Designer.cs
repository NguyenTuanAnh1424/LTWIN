namespace LTWIN.Forms
{
    partial class FormReport
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
            btnExportReport = new Button();
            cmbTimeFilter = new ComboBox();
            lblFilter = new Label();
            panelCards = new TableLayoutPanel();
            card1 = new Panel();
            lblCard1Value = new Label();
            lblCard1Title = new Label();
            card2 = new Panel();
            lblCard2Value = new Label();
            lblCard2Title = new Label();
            card3 = new Panel();
            lblCard3Value = new Label();
            lblCard3Title = new Label();
            card4 = new Panel();
            lblCard4Value = new Label();
            lblCard4Title = new Label();
            panelGridArea = new Panel();
            dgvTopSelling = new DataGridView();
            panelGridHeader = new Panel();
            lblTopSelling = new Label();
            panelTop.SuspendLayout();
            panelCards.SuspendLayout();
            card1.SuspendLayout();
            card2.SuspendLayout();
            card3.SuspendLayout();
            card4.SuspendLayout();
            panelGridArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopSelling).BeginInit();
            panelGridHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnExportReport);
            panelTop.Controls.Add(cmbTimeFilter);
            panelTop.Controls.Add(lblFilter);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(15, 15);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(990, 60);
            panelTop.TabIndex = 0;
            // 
            // btnExportReport
            // 
            btnExportReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportReport.BackColor = Color.FromArgb(46, 213, 115);
            btnExportReport.FlatAppearance.BorderSize = 0;
            btnExportReport.FlatStyle = FlatStyle.Flat;
            btnExportReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExportReport.ForeColor = Color.White;
            btnExportReport.Location = new Point(780, 11);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(195, 38);
            btnExportReport.TabIndex = 2;
            btnExportReport.Text = "📄 Xuất Báo Cáo Text";
            btnExportReport.UseVisualStyleBackColor = false;
            btnExportReport.Click += btnExportReport_Click;
            // 
            // cmbTimeFilter
            // 
            cmbTimeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimeFilter.Font = new Font("Segoe UI", 9.5F);
            cmbTimeFilter.FormattingEnabled = true;
            cmbTimeFilter.Items.AddRange(new object[] { "Tất cả thời gian", "Hôm nay", "7 ngày qua", "Tháng này" });
            cmbTimeFilter.Location = new Point(160, 18);
            cmbTimeFilter.Name = "cmbTimeFilter";
            cmbTimeFilter.Size = new Size(185, 25);
            cmbTimeFilter.TabIndex = 1;
            cmbTimeFilter.SelectedIndexChanged += cmbTimeFilter_SelectedIndexChanged;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFilter.ForeColor = Color.FromArgb(47, 53, 66);
            lblFilter.Location = new Point(15, 21);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(137, 17);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Xem Thống Kê Theo:";
            // 
            // panelCards
            // 
            panelCards.ColumnCount = 4;
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelCards.Controls.Add(card1, 0, 0);
            panelCards.Controls.Add(card2, 1, 0);
            panelCards.Controls.Add(card3, 2, 0);
            panelCards.Controls.Add(card4, 3, 0);
            panelCards.Dock = DockStyle.Top;
            panelCards.Location = new Point(15, 75);
            panelCards.Name = "panelCards";
            panelCards.Padding = new Padding(0, 15, 0, 15);
            panelCards.RowCount = 1;
            panelCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelCards.Size = new Size(990, 115);
            panelCards.TabIndex = 1;
            // 
            // card1
            // 
            card1.BackColor = Color.FromArgb(255, 71, 87);
            card1.Controls.Add(lblCard1Value);
            card1.Controls.Add(lblCard1Title);
            card1.Dock = DockStyle.Fill;
            card1.Location = new Point(0, 15);
            card1.Margin = new Padding(0, 0, 10, 0);
            card1.Name = "card1";
            card1.Padding = new Padding(12);
            card1.Size = new Size(237, 85);
            card1.TabIndex = 0;
            // 
            // lblCard1Value
            // 
            lblCard1Value.AutoSize = true;
            lblCard1Value.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblCard1Value.ForeColor = Color.White;
            lblCard1Value.Location = new Point(12, 42);
            lblCard1Value.Name = "lblCard1Value";
            lblCard1Value.Size = new Size(155, 25);
            lblCard1Value.TabIndex = 1;
            lblCard1Value.Text = "170,020,000 VNĐ";
            // 
            // lblCard1Title
            // 
            lblCard1Title.AutoSize = true;
            lblCard1Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard1Title.ForeColor = Color.FromArgb(255, 218, 221);
            lblCard1Title.Location = new Point(12, 16);
            lblCard1Title.Name = "lblCard1Title";
            lblCard1Title.Size = new Size(119, 15);
            lblCard1Title.TabIndex = 0;
            lblCard1Title.Text = "💰 TỔNG DOANH THU";
            // 
            // card2
            // 
            card2.BackColor = Color.FromArgb(30, 144, 255);
            card2.Controls.Add(lblCard2Value);
            card2.Controls.Add(lblCard2Title);
            card2.Dock = DockStyle.Fill;
            card2.Location = new Point(247, 15);
            card2.Margin = new Padding(10, 0, 10, 0);
            card2.Name = "card2";
            card2.Padding = new Padding(12);
            card2.Size = new Size(227, 85);
            card2.TabIndex = 1;
            // 
            // lblCard2Value
            // 
            lblCard2Value.AutoSize = true;
            lblCard2Value.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblCard2Value.ForeColor = Color.White;
            lblCard2Value.Location = new Point(12, 42);
            lblCard2Value.Name = "lblCard2Value";
            lblCard2Value.Size = new Size(74, 25);
            lblCard2Value.TabIndex = 1;
            lblCard2Value.Text = "48 Đơn";
            // 
            // lblCard2Title
            // 
            lblCard2Title.AutoSize = true;
            lblCard2Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard2Title.ForeColor = Color.FromArgb(218, 235, 255);
            lblCard2Title.Location = new Point(12, 16);
            lblCard2Title.Name = "lblCard2Title";
            lblCard2Title.Size = new Size(125, 15);
            lblCard2Title.TabIndex = 0;
            lblCard2Title.Text = "🧾 TỔNG ĐƠN HÀNG";
            // 
            // card3
            // 
            card3.BackColor = Color.FromArgb(46, 213, 115);
            card3.Controls.Add(lblCard3Value);
            card3.Controls.Add(lblCard3Title);
            card3.Dock = DockStyle.Fill;
            card3.Location = new Point(494, 15);
            card3.Margin = new Padding(10, 0, 10, 0);
            card3.Name = "card3";
            card3.Padding = new Padding(12);
            card3.Size = new Size(227, 85);
            card3.TabIndex = 2;
            // 
            // lblCard3Value
            // 
            lblCard3Value.AutoSize = true;
            lblCard3Value.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblCard3Value.ForeColor = Color.White;
            lblCard3Value.Location = new Point(12, 42);
            lblCard3Value.Name = "lblCard3Value";
            lblCard3Value.Size = new Size(73, 25);
            lblCard3Value.TabIndex = 1;
            lblCard3Value.Text = "48 Đôi";
            // 
            // lblCard3Title
            // 
            lblCard3Title.AutoSize = true;
            lblCard3Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard3Title.ForeColor = Color.FromArgb(218, 255, 230);
            lblCard3Title.Location = new Point(12, 16);
            lblCard3Title.Name = "lblCard3Title";
            lblCard3Title.Size = new Size(116, 15);
            lblCard3Title.TabIndex = 0;
            lblCard3Title.Text = "👟 ĐÔI GIÀY ĐÃ BÁN";
            // 
            // card4
            // 
            card4.BackColor = Color.FromArgb(255, 165, 2);
            card4.Controls.Add(lblCard4Value);
            card4.Controls.Add(lblCard4Title);
            card4.Dock = DockStyle.Fill;
            card4.Location = new Point(741, 15);
            card4.Margin = new Padding(10, 0, 0, 0);
            card4.Name = "card4";
            card4.Padding = new Padding(12);
            card4.Size = new Size(249, 85);
            card4.TabIndex = 3;
            // 
            // lblCard4Value
            // 
            lblCard4Value.AutoSize = true;
            lblCard4Value.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblCard4Value.ForeColor = Color.White;
            lblCard4Value.Location = new Point(12, 42);
            lblCard4Value.Name = "lblCard4Value";
            lblCard4Value.Size = new Size(135, 25);
            lblCard4Value.TabIndex = 1;
            lblCard4Value.Text = "3,542,083 VNĐ";
            // 
            // lblCard4Title
            // 
            lblCard4Title.AutoSize = true;
            lblCard4Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard4Title.ForeColor = Color.FromArgb(255, 243, 218);
            lblCard4Title.Location = new Point(12, 16);
            lblCard4Title.Name = "lblCard4Title";
            lblCard4Title.Size = new Size(125, 15);
            lblCard4Title.TabIndex = 0;
            lblCard4Title.Text = "📊 GIÁ TRỊ T.BÌNH/ĐƠN";
            // 
            // panelGridArea
            // 
            panelGridArea.BackColor = Color.White;
            panelGridArea.Controls.Add(dgvTopSelling);
            panelGridArea.Controls.Add(panelGridHeader);
            panelGridArea.Dock = DockStyle.Fill;
            panelGridArea.Location = new Point(15, 190);
            panelGridArea.Name = "panelGridArea";
            panelGridArea.Size = new Size(990, 375);
            panelGridArea.TabIndex = 2;
            // 
            // dgvTopSelling
            // 
            dgvTopSelling.AllowUserToAddRows = false;
            dgvTopSelling.AllowUserToDeleteRows = false;
            dgvTopSelling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopSelling.BackgroundColor = Color.White;
            dgvTopSelling.BorderStyle = BorderStyle.None;
            dgvTopSelling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopSelling.Dock = DockStyle.Fill;
            dgvTopSelling.Location = new Point(0, 45);
            dgvTopSelling.MultiSelect = false;
            dgvTopSelling.Name = "dgvTopSelling";
            dgvTopSelling.ReadOnly = true;
            dgvTopSelling.RowHeadersVisible = false;
            dgvTopSelling.RowTemplate.Height = 35;
            dgvTopSelling.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopSelling.Size = new Size(990, 330);
            dgvTopSelling.TabIndex = 1;
            // 
            // panelGridHeader
            // 
            panelGridHeader.BackColor = Color.White;
            panelGridHeader.Controls.Add(lblTopSelling);
            panelGridHeader.Dock = DockStyle.Top;
            panelGridHeader.Location = new Point(0, 0);
            panelGridHeader.Name = "panelGridHeader";
            panelGridHeader.Padding = new Padding(15, 12, 15, 8);
            panelGridHeader.Size = new Size(990, 45);
            panelGridHeader.TabIndex = 0;
            // 
            // lblTopSelling
            // 
            lblTopSelling.AutoSize = true;
            lblTopSelling.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTopSelling.ForeColor = Color.FromArgb(47, 53, 66);
            lblTopSelling.Location = new Point(12, 12);
            lblTopSelling.Name = "lblTopSelling";
            lblTopSelling.Size = new Size(260, 20);
            lblTopSelling.TabIndex = 0;
            lblTopSelling.Text = "🔥 TOP 5 MẪU GIÀY BÁN CHẠY NHẤT";
            // 
            // FormReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 580);
            Controls.Add(panelGridArea);
            Controls.Add(panelCards);
            Controls.Add(panelTop);
            Name = "FormReport";
            Padding = new Padding(15);
            Text = "Thống Kê & Báo Cáo Doanh Thu";
            Load += FormReport_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelCards.ResumeLayout(false);
            card1.ResumeLayout(false);
            card1.PerformLayout();
            card2.ResumeLayout(false);
            card2.PerformLayout();
            card3.ResumeLayout(false);
            card3.PerformLayout();
            card4.ResumeLayout(false);
            card4.PerformLayout();
            panelGridArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTopSelling).EndInit();
            panelGridHeader.ResumeLayout(false);
            panelGridHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblFilter;
        private ComboBox cmbTimeFilter;
        private Button btnExportReport;
        private TableLayoutPanel panelCards;
        private Panel card1;
        private Label lblCard1Title;
        private Label lblCard1Value;
        private Panel card2;
        private Label lblCard2Title;
        private Label lblCard2Value;
        private Panel card3;
        private Label lblCard3Title;
        private Label lblCard3Value;
        private Panel card4;
        private Label lblCard4Title;
        private Label lblCard4Value;
        private Panel panelGridArea;
        private Panel panelGridHeader;
        private Label lblTopSelling;
        private DataGridView dgvTopSelling;
    }
}
