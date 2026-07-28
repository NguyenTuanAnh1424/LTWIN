namespace LTWIN.Forms
{
    partial class FormStockImport
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
            tabControlStock = new TabControl();
            tabCreateImport = new TabPage();
            panelImportBody = new Panel();
            dgvImportCart = new DataGridView();
            panelImportFooter = new Panel();
            btnConfirmImport = new Button();
            btnClearImportCart = new Button();
            lblTotalImportMoney = new Label();
            lblTotalTitle = new Label();
            txtNote = new TextBox();
            lblNoteTitle = new Label();
            panelImportHeader = new Panel();
            btnAddImportItem = new Button();
            numImportUnitPrice = new NumericUpDown();
            lblPriceTitle = new Label();
            numImportQuantity = new NumericUpDown();
            lblQuantityTitle = new Label();
            cmbProducts = new ComboBox();
            lblProductTitle = new Label();
            cmbSupplier = new ComboBox();
            lblSupplierTitle = new Label();
            tabImportHistory = new TabPage();
            panelHistoryMain = new TableLayoutPanel();
            grpHistoryReceipts = new GroupBox();
            dgvHistoryReceipts = new DataGridView();
            grpHistoryDetails = new GroupBox();
            dgvHistoryDetails = new DataGridView();
            panelHistoryBottom = new Panel();
            btnRePrintReceipt = new Button();
            lblHistorySummary = new Label();
            tabControlStock.SuspendLayout();
            tabCreateImport.SuspendLayout();
            panelImportBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImportCart).BeginInit();
            panelImportFooter.SuspendLayout();
            panelImportHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numImportUnitPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numImportQuantity).BeginInit();
            tabImportHistory.SuspendLayout();
            panelHistoryMain.SuspendLayout();
            grpHistoryReceipts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistoryReceipts).BeginInit();
            grpHistoryDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistoryDetails).BeginInit();
            panelHistoryBottom.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlStock
            // 
            tabControlStock.Controls.Add(tabCreateImport);
            tabControlStock.Controls.Add(tabImportHistory);
            tabControlStock.Dock = DockStyle.Fill;
            tabControlStock.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            tabControlStock.Location = new System.Drawing.Point(0, 0);
            tabControlStock.Name = "tabControlStock";
            tabControlStock.SelectedIndex = 0;
            tabControlStock.Size = new System.Drawing.Size(960, 595);
            tabControlStock.TabIndex = 0;
            // 
            // tabCreateImport
            // 
            tabCreateImport.Controls.Add(panelImportBody);
            tabCreateImport.Controls.Add(panelImportFooter);
            tabCreateImport.Controls.Add(panelImportHeader);
            tabCreateImport.Location = new System.Drawing.Point(4, 26);
            tabCreateImport.Name = "tabCreateImport";
            tabCreateImport.Padding = new System.Windows.Forms.Padding(3);
            tabCreateImport.Size = new System.Drawing.Size(952, 565);
            tabCreateImport.TabIndex = 0;
            tabCreateImport.Text = "📦 Lập Phiếu Nhập Kho Mới";
            tabCreateImport.UseVisualStyleBackColor = true;
            // 
            // panelImportBody
            // 
            panelImportBody.Controls.Add(dgvImportCart);
            panelImportBody.Dock = DockStyle.Fill;
            panelImportBody.Location = new System.Drawing.Point(3, 103);
            panelImportBody.Name = "panelImportBody";
            panelImportBody.Size = new System.Drawing.Size(946, 339);
            panelImportBody.TabIndex = 1;
            // 
            // dgvImportCart
            // 
            dgvImportCart.AllowUserToAddRows = false;
            dgvImportCart.AllowUserToDeleteRows = false;
            dgvImportCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvImportCart.BackgroundColor = System.Drawing.Color.White;
            dgvImportCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvImportCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvImportCart.Dock = DockStyle.Fill;
            dgvImportCart.Location = new System.Drawing.Point(0, 0);
            dgvImportCart.MultiSelect = false;
            dgvImportCart.Name = "dgvImportCart";
            dgvImportCart.RowHeadersVisible = false;
            dgvImportCart.RowTemplate.Height = 32;
            dgvImportCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvImportCart.Size = new System.Drawing.Size(946, 339);
            dgvImportCart.TabIndex = 0;
            dgvImportCart.CellContentClick += dgvImportCart_CellContentClick;
            // 
            // panelImportFooter
            // 
            panelImportFooter.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            panelImportFooter.Controls.Add(btnConfirmImport);
            panelImportFooter.Controls.Add(btnClearImportCart);
            panelImportFooter.Controls.Add(lblTotalImportMoney);
            panelImportFooter.Controls.Add(lblTotalTitle);
            panelImportFooter.Controls.Add(txtNote);
            panelImportFooter.Controls.Add(lblNoteTitle);
            panelImportFooter.Dock = DockStyle.Bottom;
            panelImportFooter.Location = new System.Drawing.Point(3, 442);
            panelImportFooter.Name = "panelImportFooter";
            panelImportFooter.Padding = new System.Windows.Forms.Padding(12);
            panelImportFooter.Size = new System.Drawing.Size(946, 120);
            panelImportFooter.TabIndex = 2;
            // 
            // btnConfirmImport
            // 
            btnConfirmImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfirmImport.BackColor = System.Drawing.Color.FromArgb(46, 213, 115);
            btnConfirmImport.FlatAppearance.BorderSize = 0;
            btnConfirmImport.FlatStyle = FlatStyle.Flat;
            btnConfirmImport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnConfirmImport.ForeColor = System.Drawing.Color.White;
            btnConfirmImport.Location = new System.Drawing.Point(620, 60);
            btnConfirmImport.Name = "btnConfirmImport";
            btnConfirmImport.Size = new System.Drawing.Size(310, 48);
            btnConfirmImport.TabIndex = 5;
            btnConfirmImport.Text = "📦 XÁC NHẬN NHẬP KHO && IN PHIẾU";
            btnConfirmImport.UseVisualStyleBackColor = false;
            btnConfirmImport.Click += btnConfirmImport_Click;
            // 
            // btnClearImportCart
            // 
            btnClearImportCart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearImportCart.BackColor = System.Drawing.Color.FromArgb(116, 125, 140);
            btnClearImportCart.FlatAppearance.BorderSize = 0;
            btnClearImportCart.FlatStyle = FlatStyle.Flat;
            btnClearImportCart.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnClearImportCart.ForeColor = System.Drawing.Color.White;
            btnClearImportCart.Location = new System.Drawing.Point(490, 60);
            btnClearImportCart.Name = "btnClearImportCart";
            btnClearImportCart.Size = new System.Drawing.Size(120, 48);
            btnClearImportCart.TabIndex = 4;
            btnClearImportCart.Text = "🗑️ Hủy Phiếu";
            btnClearImportCart.UseVisualStyleBackColor = false;
            btnClearImportCart.Click += btnClearImportCart_Click;
            // 
            // lblTotalImportMoney
            // 
            lblTotalImportMoney.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalImportMoney.AutoSize = true;
            lblTotalImportMoney.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTotalImportMoney.ForeColor = System.Drawing.Color.FromArgb(255, 71, 87);
            lblTotalImportMoney.Location = new System.Drawing.Point(690, 15);
            lblTotalImportMoney.Name = "lblTotalImportMoney";
            lblTotalImportMoney.Size = new System.Drawing.Size(69, 25);
            lblTotalImportMoney.TabIndex = 3;
            lblTotalImportMoney.Text = "0 VNĐ";
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            lblTotalTitle.Location = new System.Drawing.Point(490, 18);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new System.Drawing.Size(193, 19);
            lblTotalTitle.TabIndex = 2;
            lblTotalTitle.Text = "Tổng Giá Trị Lô Hàng Nhập:";
            // 
            // txtNote
            // 
            txtNote.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtNote.Location = new System.Drawing.Point(15, 45);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.PlaceholderText = "Nhập ghi chú cho phiếu nhập kho (Số hợp đồng, đợt giao...)...";
            txtNote.Size = new System.Drawing.Size(450, 60);
            txtNote.TabIndex = 1;
            // 
            // lblNoteTitle
            // 
            lblNoteTitle.AutoSize = true;
            lblNoteTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblNoteTitle.Location = new System.Drawing.Point(15, 18);
            lblNoteTitle.Name = "lblNoteTitle";
            lblNoteTitle.Size = new System.Drawing.Size(133, 17);
            lblNoteTitle.TabIndex = 0;
            lblNoteTitle.Text = "Ghi Chú Phiếu Nhập:";
            // 
            // panelImportHeader
            // 
            panelImportHeader.BackColor = System.Drawing.Color.White;
            panelImportHeader.Controls.Add(btnAddImportItem);
            panelImportHeader.Controls.Add(numImportUnitPrice);
            panelImportHeader.Controls.Add(lblPriceTitle);
            panelImportHeader.Controls.Add(numImportQuantity);
            panelImportHeader.Controls.Add(lblQuantityTitle);
            panelImportHeader.Controls.Add(cmbProducts);
            panelImportHeader.Controls.Add(lblProductTitle);
            panelImportHeader.Controls.Add(cmbSupplier);
            panelImportHeader.Controls.Add(lblSupplierTitle);
            panelImportHeader.Dock = DockStyle.Top;
            panelImportHeader.Location = new System.Drawing.Point(3, 3);
            panelImportHeader.Name = "panelImportHeader";
            panelImportHeader.Size = new System.Drawing.Size(946, 100);
            panelImportHeader.TabIndex = 0;
            // 
            // btnAddImportItem
            // 
            btnAddImportItem.BackColor = System.Drawing.Color.FromArgb(30, 144, 255);
            btnAddImportItem.FlatAppearance.BorderSize = 0;
            btnAddImportItem.FlatStyle = FlatStyle.Flat;
            btnAddImportItem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnAddImportItem.ForeColor = System.Drawing.Color.White;
            btnAddImportItem.Location = new System.Drawing.Point(730, 52);
            btnAddImportItem.Name = "btnAddImportItem";
            btnAddImportItem.Size = new System.Drawing.Size(200, 32);
            btnAddImportItem.TabIndex = 8;
            btnAddImportItem.Text = "➕ Thêm Vào Phiếu Nhập";
            btnAddImportItem.UseVisualStyleBackColor = false;
            btnAddImportItem.Click += btnAddImportItem_Click;
            // 
            // numImportUnitPrice
            // 
            numImportUnitPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            numImportUnitPrice.Increment = new decimal(new int[] { 50000, 0, 0, 0 });
            numImportUnitPrice.Location = new Point(480, 55);
            numImportUnitPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numImportUnitPrice.Name = "numImportUnitPrice";
            numImportUnitPrice.Size = new System.Drawing.Size(230, 24);
            numImportUnitPrice.TabIndex = 7;
            // 
            // lblPriceTitle
            // 
            lblPriceTitle.AutoSize = true;
            lblPriceTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblPriceTitle.Location = new Point(380, 59);
            lblPriceTitle.Name = "lblPriceTitle";
            lblPriceTitle.Size = new System.Drawing.Size(89, 15);
            lblPriceTitle.TabIndex = 6;
            lblPriceTitle.Text = "Đơn Giá Nhập:";
            // 
            // numImportQuantity
            // 
            numImportQuantity.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            numImportQuantity.Location = new Point(115, 55);
            numImportQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numImportQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numImportQuantity.Name = "numImportQuantity";
            numImportQuantity.Size = new System.Drawing.Size(245, 24);
            numImportQuantity.TabIndex = 5;
            numImportQuantity.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblQuantityTitle
            // 
            lblQuantityTitle.AutoSize = true;
            lblQuantityTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblQuantityTitle.Location = new Point(15, 59);
            lblQuantityTitle.Name = "lblQuantityTitle";
            lblQuantityTitle.Size = new System.Drawing.Size(95, 15);
            lblQuantityTitle.TabIndex = 4;
            lblQuantityTitle.Text = "Số Lượng Nhập:";
            // 
            // cmbProducts
            // 
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducts.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(480, 14);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new System.Drawing.Size(450, 25);
            cmbProducts.TabIndex = 3;
            cmbProducts.SelectedIndexChanged += cmbProducts_SelectedIndexChanged;
            // 
            // lblProductTitle
            // 
            lblProductTitle.AutoSize = true;
            lblProductTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblProductTitle.Location = new Point(380, 18);
            lblProductTitle.Name = "lblProductTitle";
            lblProductTitle.Size = new System.Drawing.Size(94, 15);
            lblProductTitle.TabIndex = 2;
            lblProductTitle.Text = "Mẫu Giày Nhập:";
            // 
            // cmbSupplier
            // 
            cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(115, 14);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new System.Drawing.Size(245, 25);
            cmbSupplier.TabIndex = 1;
            // 
            // lblSupplierTitle
            // 
            lblSupplierTitle.AutoSize = true;
            lblSupplierTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSupplierTitle.Location = new Point(15, 18);
            lblSupplierTitle.Name = "lblSupplierTitle";
            lblSupplierTitle.Size = new System.Drawing.Size(88, 15);
            lblSupplierTitle.TabIndex = 0;
            lblSupplierTitle.Text = "Nhà Cung Cấp:";
            // 
            // tabImportHistory
            // 
            tabImportHistory.Controls.Add(panelHistoryMain);
            tabImportHistory.Controls.Add(panelHistoryBottom);
            tabImportHistory.Location = new System.Drawing.Point(4, 26);
            tabImportHistory.Name = "tabImportHistory";
            tabImportHistory.Padding = new System.Windows.Forms.Padding(3);
            tabImportHistory.Size = new System.Drawing.Size(952, 565);
            tabImportHistory.TabIndex = 1;
            tabImportHistory.Text = "📜 Lịch Sử Phiếu Nhập Kho";
            tabImportHistory.UseVisualStyleBackColor = true;
            // 
            // panelHistoryMain
            // 
            panelHistoryMain.ColumnCount = 1;
            panelHistoryMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelHistoryMain.Controls.Add(grpHistoryReceipts, 0, 0);
            panelHistoryMain.Controls.Add(grpHistoryDetails, 0, 1);
            panelHistoryMain.Dock = DockStyle.Fill;
            panelHistoryMain.Location = new System.Drawing.Point(3, 3);
            panelHistoryMain.Name = "panelHistoryMain";
            panelHistoryMain.RowCount = 2;
            panelHistoryMain.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            panelHistoryMain.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            panelHistoryMain.Size = new System.Drawing.Size(946, 504);
            panelHistoryMain.TabIndex = 0;
            // 
            // grpHistoryReceipts
            // 
            grpHistoryReceipts.Controls.Add(dgvHistoryReceipts);
            grpHistoryReceipts.Dock = DockStyle.Fill;
            grpHistoryReceipts.Location = new System.Drawing.Point(8, 8);
            grpHistoryReceipts.Margin = new Padding(8);
            grpHistoryReceipts.Name = "grpHistoryReceipts";
            grpHistoryReceipts.Size = new System.Drawing.Size(930, 261);
            grpHistoryReceipts.TabIndex = 0;
            grpHistoryReceipts.TabStop = false;
            grpHistoryReceipts.Text = "📋 Danh Sách Phiếu Nhập Kho Đã Lập";
            // 
            // dgvHistoryReceipts
            // 
            dgvHistoryReceipts.AllowUserToAddRows = false;
            dgvHistoryReceipts.AllowUserToDeleteRows = false;
            dgvHistoryReceipts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistoryReceipts.BackgroundColor = System.Drawing.Color.White;
            dgvHistoryReceipts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHistoryReceipts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistoryReceipts.Dock = DockStyle.Fill;
            dgvHistoryReceipts.Location = new System.Drawing.Point(3, 20);
            dgvHistoryReceipts.MultiSelect = false;
            dgvHistoryReceipts.Name = "dgvHistoryReceipts";
            dgvHistoryReceipts.ReadOnly = true;
            dgvHistoryReceipts.RowHeadersVisible = false;
            dgvHistoryReceipts.RowTemplate.Height = 32;
            dgvHistoryReceipts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoryReceipts.Size = new System.Drawing.Size(924, 238);
            dgvHistoryReceipts.TabIndex = 0;
            dgvHistoryReceipts.SelectionChanged += dgvHistoryReceipts_SelectionChanged;
            // 
            // grpHistoryDetails
            // 
            grpHistoryDetails.Controls.Add(dgvHistoryDetails);
            grpHistoryDetails.Dock = DockStyle.Fill;
            grpHistoryDetails.Location = new System.Drawing.Point(8, 285);
            grpHistoryDetails.Margin = new Padding(8);
            grpHistoryDetails.Name = "grpHistoryDetails";
            grpHistoryDetails.Size = new System.Drawing.Size(930, 211);
            grpHistoryDetails.TabIndex = 1;
            grpHistoryDetails.TabStop = false;
            grpHistoryDetails.Text = "👟 Chi Tiết Hàng Giày Trong Phiếu Nhập Chọn";
            // 
            // dgvHistoryDetails
            // 
            dgvHistoryDetails.AllowUserToAddRows = false;
            dgvHistoryDetails.AllowUserToDeleteRows = false;
            dgvHistoryDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistoryDetails.BackgroundColor = System.Drawing.Color.White;
            dgvHistoryDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHistoryDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistoryDetails.Dock = DockStyle.Fill;
            dgvHistoryDetails.Location = new System.Drawing.Point(3, 20);
            dgvHistoryDetails.MultiSelect = false;
            dgvHistoryDetails.Name = "dgvHistoryDetails";
            dgvHistoryDetails.ReadOnly = true;
            dgvHistoryDetails.RowHeadersVisible = false;
            dgvHistoryDetails.RowTemplate.Height = 30;
            dgvHistoryDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoryDetails.Size = new System.Drawing.Size(924, 188);
            dgvHistoryDetails.TabIndex = 0;
            // 
            // panelHistoryBottom
            // 
            panelHistoryBottom.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            panelHistoryBottom.Controls.Add(btnRePrintReceipt);
            panelHistoryBottom.Controls.Add(lblHistorySummary);
            panelHistoryBottom.Dock = DockStyle.Bottom;
            panelHistoryBottom.Location = new System.Drawing.Point(3, 507);
            panelHistoryBottom.Name = "panelHistoryBottom";
            panelHistoryBottom.Padding = new System.Windows.Forms.Padding(12);
            panelHistoryBottom.Size = new System.Drawing.Size(946, 55);
            panelHistoryBottom.TabIndex = 1;
            // 
            // btnRePrintReceipt
            // 
            btnRePrintReceipt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRePrintReceipt.BackColor = System.Drawing.Color.FromArgb(30, 144, 255);
            btnRePrintReceipt.FlatAppearance.BorderSize = 0;
            btnRePrintReceipt.FlatStyle = FlatStyle.Flat;
            btnRePrintReceipt.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnRePrintReceipt.ForeColor = System.Drawing.Color.White;
            btnRePrintReceipt.Location = new System.Drawing.Point(735, 10);
            btnRePrintReceipt.Name = "btnRePrintReceipt";
            btnRePrintReceipt.Size = new System.Drawing.Size(195, 36);
            btnRePrintReceipt.TabIndex = 1;
            btnRePrintReceipt.Text = "🖨️ Xem && In Lại Phiếu Nhập";
            btnRePrintReceipt.UseVisualStyleBackColor = false;
            btnRePrintReceipt.Click += btnRePrintReceipt_Click;
            // 
            // lblHistorySummary
            // 
            lblHistorySummary.AutoSize = true;
            lblHistorySummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblHistorySummary.ForeColor = System.Drawing.Color.FromArgb(47, 53, 66);
            lblHistorySummary.Location = new System.Drawing.Point(15, 18);
            lblHistorySummary.Name = "lblHistorySummary";
            lblHistorySummary.Size = new System.Drawing.Size(252, 19);
            lblHistorySummary.TabIndex = 0;
            lblHistorySummary.Text = "📊 Tổng phiếu nhập: 0 | Tổng vốn: 0 VNĐ";
            // 
            // FormStockImport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(960, 595);
            Controls.Add(tabControlStock);
            Name = "FormStockImport";
            Text = "Quản Lý Nhập Kho Sản Phẩm";
            Load += FormStockImport_Load;
            tabControlStock.ResumeLayout(false);
            tabCreateImport.ResumeLayout(false);
            panelImportBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvImportCart).EndInit();
            panelImportFooter.ResumeLayout(false);
            panelImportFooter.PerformLayout();
            panelImportHeader.ResumeLayout(false);
            panelImportHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numImportUnitPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numImportQuantity).EndInit();
            tabImportHistory.ResumeLayout(false);
            panelHistoryMain.ResumeLayout(false);
            grpHistoryReceipts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistoryReceipts).EndInit();
            grpHistoryDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistoryDetails).EndInit();
            panelHistoryBottom.ResumeLayout(false);
            panelHistoryBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlStock;
        private TabPage tabCreateImport;
        private TabPage tabImportHistory;
        private Panel panelImportHeader;
        private Panel panelImportBody;
        private Panel panelImportFooter;
        private Label lblSupplierTitle;
        private ComboBox cmbSupplier;
        private Label lblProductTitle;
        private ComboBox cmbProducts;
        private Label lblQuantityTitle;
        private NumericUpDown numImportQuantity;
        private Label lblPriceTitle;
        private NumericUpDown numImportUnitPrice;
        private Button btnAddImportItem;
        private DataGridView dgvImportCart;
        private Label lblNoteTitle;
        private TextBox txtNote;
        private Label lblTotalTitle;
        private Label lblTotalImportMoney;
        private Button btnClearImportCart;
        private Button btnConfirmImport;
        private TableLayoutPanel panelHistoryMain;
        private GroupBox grpHistoryReceipts;
        private DataGridView dgvHistoryReceipts;
        private GroupBox grpHistoryDetails;
        private DataGridView dgvHistoryDetails;
        private Panel panelHistoryBottom;
        private Label lblHistorySummary;
        private Button btnRePrintReceipt;
    }
}
