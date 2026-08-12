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
            tabControlStock.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            tabControlStock.Location = new Point(0, 0);
            tabControlStock.Margin = new Padding(3, 4, 3, 4);
            tabControlStock.Name = "tabControlStock";
            tabControlStock.SelectedIndex = 0;
            tabControlStock.Size = new Size(1097, 793);
            tabControlStock.TabIndex = 0;
            // 
            // tabCreateImport
            // 
            tabCreateImport.Controls.Add(panelImportBody);
            tabCreateImport.Controls.Add(panelImportFooter);
            tabCreateImport.Controls.Add(panelImportHeader);
            tabCreateImport.Location = new Point(4, 30);
            tabCreateImport.Margin = new Padding(3, 4, 3, 4);
            tabCreateImport.Name = "tabCreateImport";
            tabCreateImport.Padding = new Padding(3, 4, 3, 4);
            tabCreateImport.Size = new Size(1089, 759);
            tabCreateImport.TabIndex = 0;
            tabCreateImport.Text = "📦 Lập Phiếu Nhập Kho Mới";
            tabCreateImport.UseVisualStyleBackColor = true;
            // 
            // panelImportBody
            // 
            panelImportBody.Controls.Add(dgvImportCart);
            panelImportBody.Dock = DockStyle.Fill;
            panelImportBody.Location = new Point(3, 137);
            panelImportBody.Margin = new Padding(3, 4, 3, 4);
            panelImportBody.Name = "panelImportBody";
            panelImportBody.Size = new Size(1083, 458);
            panelImportBody.TabIndex = 1;
            // 
            // dgvImportCart
            // 
            dgvImportCart.AllowUserToAddRows = false;
            dgvImportCart.AllowUserToDeleteRows = false;
            dgvImportCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvImportCart.BackgroundColor = Color.White;
            dgvImportCart.BorderStyle = BorderStyle.None;
            dgvImportCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvImportCart.Dock = DockStyle.Fill;
            dgvImportCart.Location = new Point(0, 0);
            dgvImportCart.Margin = new Padding(3, 4, 3, 4);
            dgvImportCart.MultiSelect = false;
            dgvImportCart.Name = "dgvImportCart";
            dgvImportCart.RowHeadersVisible = false;
            dgvImportCart.RowHeadersWidth = 51;
            dgvImportCart.RowTemplate.Height = 32;
            dgvImportCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvImportCart.Size = new Size(1083, 458);
            dgvImportCart.TabIndex = 0;
            dgvImportCart.CellContentClick += dgvImportCart_CellContentClick;
            // 
            // panelImportFooter
            // 
            panelImportFooter.BackColor = Color.FromArgb(248, 249, 250);
            panelImportFooter.Controls.Add(btnConfirmImport);
            panelImportFooter.Controls.Add(btnClearImportCart);
            panelImportFooter.Controls.Add(lblTotalImportMoney);
            panelImportFooter.Controls.Add(lblTotalTitle);
            panelImportFooter.Controls.Add(txtNote);
            panelImportFooter.Controls.Add(lblNoteTitle);
            panelImportFooter.Dock = DockStyle.Bottom;
            panelImportFooter.Location = new Point(3, 595);
            panelImportFooter.Margin = new Padding(3, 4, 3, 4);
            panelImportFooter.Name = "panelImportFooter";
            panelImportFooter.Padding = new Padding(14, 16, 14, 16);
            panelImportFooter.Size = new Size(1083, 160);
            panelImportFooter.TabIndex = 2;
            // 
            // btnConfirmImport
            // 
            btnConfirmImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfirmImport.BackColor = Color.FromArgb(46, 213, 115);
            btnConfirmImport.FlatAppearance.BorderSize = 0;
            btnConfirmImport.FlatStyle = FlatStyle.Flat;
            btnConfirmImport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConfirmImport.ForeColor = Color.White;
            btnConfirmImport.Location = new Point(693, 75);
            btnConfirmImport.Margin = new Padding(3, 4, 3, 4);
            btnConfirmImport.Name = "btnConfirmImport";
            btnConfirmImport.Size = new Size(373, 65);
            btnConfirmImport.TabIndex = 5;
            btnConfirmImport.Text = "📦 XÁC NHẬN NHẬP KHO && IN PHIẾU";
            btnConfirmImport.UseVisualStyleBackColor = false;
            btnConfirmImport.Click += btnConfirmImport_Click;
            // 
            // btnClearImportCart
            // 
            btnClearImportCart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearImportCart.BackColor = Color.FromArgb(116, 125, 140);
            btnClearImportCart.FlatAppearance.BorderSize = 0;
            btnClearImportCart.FlatStyle = FlatStyle.Flat;
            btnClearImportCart.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClearImportCart.ForeColor = Color.White;
            btnClearImportCart.Location = new Point(549, 75);
            btnClearImportCart.Margin = new Padding(3, 4, 3, 4);
            btnClearImportCart.Name = "btnClearImportCart";
            btnClearImportCart.Size = new Size(137, 64);
            btnClearImportCart.TabIndex = 4;
            btnClearImportCart.Text = "🗑️ Hủy Phiếu";
            btnClearImportCart.UseVisualStyleBackColor = false;
            btnClearImportCart.Click += btnClearImportCart_Click;
            // 
            // lblTotalImportMoney
            // 
            lblTotalImportMoney.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalImportMoney.AutoSize = true;
            lblTotalImportMoney.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalImportMoney.ForeColor = Color.FromArgb(255, 71, 87);
            lblTotalImportMoney.Location = new Point(791, 20);
            lblTotalImportMoney.Name = "lblTotalImportMoney";
            lblTotalImportMoney.Size = new Size(88, 32);
            lblTotalImportMoney.TabIndex = 3;
            lblTotalImportMoney.Text = "0 VNĐ";
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTotalTitle.Location = new Point(537, 24);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(248, 25);
            lblTotalTitle.TabIndex = 2;
            lblTotalTitle.Text = "Tổng Giá Trị Lô Hàng Nhập:";
            // 
            // txtNote
            // 
            txtNote.Font = new Font("Segoe UI", 9.5F);
            txtNote.Location = new Point(17, 60);
            txtNote.Margin = new Padding(3, 4, 3, 4);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.PlaceholderText = "Nhập ghi chú cho phiếu nhập kho (Số hợp đồng, đợt giao...)...";
            txtNote.Size = new Size(514, 79);
            txtNote.TabIndex = 1;
            // 
            // lblNoteTitle
            // 
            lblNoteTitle.AutoSize = true;
            lblNoteTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNoteTitle.Location = new Point(17, 24);
            lblNoteTitle.Name = "lblNoteTitle";
            lblNoteTitle.Size = new Size(168, 21);
            lblNoteTitle.TabIndex = 0;
            lblNoteTitle.Text = "Ghi Chú Phiếu Nhập:";
            // 
            // panelImportHeader
            // 
            panelImportHeader.BackColor = Color.White;
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
            panelImportHeader.Location = new Point(3, 4);
            panelImportHeader.Margin = new Padding(3, 4, 3, 4);
            panelImportHeader.Name = "panelImportHeader";
            panelImportHeader.Size = new Size(1083, 133);
            panelImportHeader.TabIndex = 0;
            // 
            // btnAddImportItem
            // 
            btnAddImportItem.BackColor = Color.FromArgb(30, 144, 255);
            btnAddImportItem.FlatAppearance.BorderSize = 0;
            btnAddImportItem.FlatStyle = FlatStyle.Flat;
            btnAddImportItem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAddImportItem.ForeColor = Color.White;
            btnAddImportItem.Location = new Point(834, 69);
            btnAddImportItem.Margin = new Padding(3, 4, 3, 4);
            btnAddImportItem.Name = "btnAddImportItem";
            btnAddImportItem.Size = new Size(229, 43);
            btnAddImportItem.TabIndex = 8;
            btnAddImportItem.Text = "➕ Thêm Vào Phiếu Nhập";
            btnAddImportItem.UseVisualStyleBackColor = false;
            btnAddImportItem.Click += btnAddImportItem_Click;
            // 
            // numImportUnitPrice
            // 
            numImportUnitPrice.Font = new Font("Segoe UI", 9.5F);
            numImportUnitPrice.Increment = new decimal(new int[] { 50000, 0, 0, 0 });
            numImportUnitPrice.Location = new Point(549, 73);
            numImportUnitPrice.Margin = new Padding(3, 4, 3, 4);
            numImportUnitPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numImportUnitPrice.Name = "numImportUnitPrice";
            numImportUnitPrice.Size = new Size(263, 29);
            numImportUnitPrice.TabIndex = 7;
            // 
            // lblPriceTitle
            // 
            lblPriceTitle.AutoSize = true;
            lblPriceTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPriceTitle.Location = new Point(434, 79);
            lblPriceTitle.Name = "lblPriceTitle";
            lblPriceTitle.Size = new Size(111, 20);
            lblPriceTitle.TabIndex = 6;
            lblPriceTitle.Text = "Đơn Giá Nhập:";
            // 
            // numImportQuantity
            // 
            numImportQuantity.Font = new Font("Segoe UI", 9.5F);
            numImportQuantity.Location = new Point(131, 73);
            numImportQuantity.Margin = new Padding(3, 4, 3, 4);
            numImportQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numImportQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numImportQuantity.Name = "numImportQuantity";
            numImportQuantity.Size = new Size(280, 29);
            numImportQuantity.TabIndex = 5;
            numImportQuantity.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblQuantityTitle
            // 
            lblQuantityTitle.AutoSize = true;
            lblQuantityTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQuantityTitle.Location = new Point(17, 79);
            lblQuantityTitle.Name = "lblQuantityTitle";
            lblQuantityTitle.Size = new Size(121, 20);
            lblQuantityTitle.TabIndex = 4;
            lblQuantityTitle.Text = "Số Lượng Nhập:";
            // 
            // cmbProducts
            // 
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducts.Font = new Font("Segoe UI", 9.5F);
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(549, 19);
            cmbProducts.Margin = new Padding(3, 4, 3, 4);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(514, 29);
            cmbProducts.TabIndex = 3;
            cmbProducts.SelectedIndexChanged += cmbProducts_SelectedIndexChanged;
            // 
            // lblProductTitle
            // 
            lblProductTitle.AutoSize = true;
            lblProductTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductTitle.Location = new Point(434, 24);
            lblProductTitle.Name = "lblProductTitle";
            lblProductTitle.Size = new Size(121, 20);
            lblProductTitle.TabIndex = 2;
            lblProductTitle.Text = "Mẫu Giày Nhập:";
            // 
            // cmbSupplier
            // 
            cmbSupplier.Font = new Font("Segoe UI", 9.5F);
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(131, 19);
            cmbSupplier.Margin = new Padding(3, 4, 3, 4);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(279, 29);
            cmbSupplier.TabIndex = 1;
            // 
            // lblSupplierTitle
            // 
            lblSupplierTitle.AutoSize = true;
            lblSupplierTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSupplierTitle.Location = new Point(17, 24);
            lblSupplierTitle.Name = "lblSupplierTitle";
            lblSupplierTitle.Size = new Size(112, 20);
            lblSupplierTitle.TabIndex = 0;
            lblSupplierTitle.Text = "Nhà Cung Cấp:";
            // 
            // tabImportHistory
            // 
            tabImportHistory.Controls.Add(panelHistoryMain);
            tabImportHistory.Controls.Add(panelHistoryBottom);
            tabImportHistory.Location = new Point(4, 30);
            tabImportHistory.Margin = new Padding(3, 4, 3, 4);
            tabImportHistory.Name = "tabImportHistory";
            tabImportHistory.Padding = new Padding(3, 4, 3, 4);
            tabImportHistory.Size = new Size(1089, 759);
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
            panelHistoryMain.Location = new Point(3, 4);
            panelHistoryMain.Margin = new Padding(3, 4, 3, 4);
            panelHistoryMain.Name = "panelHistoryMain";
            panelHistoryMain.RowCount = 2;
            panelHistoryMain.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            panelHistoryMain.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            panelHistoryMain.Size = new Size(1083, 678);
            panelHistoryMain.TabIndex = 0;
            // 
            // grpHistoryReceipts
            // 
            grpHistoryReceipts.Controls.Add(dgvHistoryReceipts);
            grpHistoryReceipts.Dock = DockStyle.Fill;
            grpHistoryReceipts.Location = new Point(9, 11);
            grpHistoryReceipts.Margin = new Padding(9, 11, 9, 11);
            grpHistoryReceipts.Name = "grpHistoryReceipts";
            grpHistoryReceipts.Padding = new Padding(3, 4, 3, 4);
            grpHistoryReceipts.Size = new Size(1065, 350);
            grpHistoryReceipts.TabIndex = 0;
            grpHistoryReceipts.TabStop = false;
            grpHistoryReceipts.Text = "📋 Danh Sách Phiếu Nhập Kho Đã Lập";
            // 
            // dgvHistoryReceipts
            // 
            dgvHistoryReceipts.AllowUserToAddRows = false;
            dgvHistoryReceipts.AllowUserToDeleteRows = false;
            dgvHistoryReceipts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistoryReceipts.BackgroundColor = Color.White;
            dgvHistoryReceipts.BorderStyle = BorderStyle.None;
            dgvHistoryReceipts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistoryReceipts.Dock = DockStyle.Fill;
            dgvHistoryReceipts.Location = new Point(3, 26);
            dgvHistoryReceipts.Margin = new Padding(3, 4, 3, 4);
            dgvHistoryReceipts.MultiSelect = false;
            dgvHistoryReceipts.Name = "dgvHistoryReceipts";
            dgvHistoryReceipts.ReadOnly = true;
            dgvHistoryReceipts.RowHeadersVisible = false;
            dgvHistoryReceipts.RowHeadersWidth = 51;
            dgvHistoryReceipts.RowTemplate.Height = 32;
            dgvHistoryReceipts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoryReceipts.Size = new Size(1059, 320);
            dgvHistoryReceipts.TabIndex = 0;
            dgvHistoryReceipts.SelectionChanged += dgvHistoryReceipts_SelectionChanged;
            // 
            // grpHistoryDetails
            // 
            grpHistoryDetails.Controls.Add(dgvHistoryDetails);
            grpHistoryDetails.Dock = DockStyle.Fill;
            grpHistoryDetails.Location = new Point(9, 383);
            grpHistoryDetails.Margin = new Padding(9, 11, 9, 11);
            grpHistoryDetails.Name = "grpHistoryDetails";
            grpHistoryDetails.Padding = new Padding(3, 4, 3, 4);
            grpHistoryDetails.Size = new Size(1065, 284);
            grpHistoryDetails.TabIndex = 1;
            grpHistoryDetails.TabStop = false;
            grpHistoryDetails.Text = "👟 Chi Tiết Hàng Giày Trong Phiếu Nhập Chọn";
            // 
            // dgvHistoryDetails
            // 
            dgvHistoryDetails.AllowUserToAddRows = false;
            dgvHistoryDetails.AllowUserToDeleteRows = false;
            dgvHistoryDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistoryDetails.BackgroundColor = Color.White;
            dgvHistoryDetails.BorderStyle = BorderStyle.None;
            dgvHistoryDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistoryDetails.Dock = DockStyle.Fill;
            dgvHistoryDetails.Location = new Point(3, 26);
            dgvHistoryDetails.Margin = new Padding(3, 4, 3, 4);
            dgvHistoryDetails.MultiSelect = false;
            dgvHistoryDetails.Name = "dgvHistoryDetails";
            dgvHistoryDetails.ReadOnly = true;
            dgvHistoryDetails.RowHeadersVisible = false;
            dgvHistoryDetails.RowHeadersWidth = 51;
            dgvHistoryDetails.RowTemplate.Height = 30;
            dgvHistoryDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoryDetails.Size = new Size(1059, 254);
            dgvHistoryDetails.TabIndex = 0;
            // 
            // panelHistoryBottom
            // 
            panelHistoryBottom.BackColor = Color.FromArgb(248, 249, 250);
            panelHistoryBottom.Controls.Add(btnRePrintReceipt);
            panelHistoryBottom.Controls.Add(lblHistorySummary);
            panelHistoryBottom.Dock = DockStyle.Bottom;
            panelHistoryBottom.Location = new Point(3, 682);
            panelHistoryBottom.Margin = new Padding(3, 4, 3, 4);
            panelHistoryBottom.Name = "panelHistoryBottom";
            panelHistoryBottom.Padding = new Padding(14, 16, 14, 16);
            panelHistoryBottom.Size = new Size(1083, 73);
            panelHistoryBottom.TabIndex = 1;
            // 
            // btnRePrintReceipt
            // 
            btnRePrintReceipt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRePrintReceipt.BackColor = Color.FromArgb(30, 144, 255);
            btnRePrintReceipt.FlatAppearance.BorderSize = 0;
            btnRePrintReceipt.FlatStyle = FlatStyle.Flat;
            btnRePrintReceipt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRePrintReceipt.ForeColor = Color.White;
            btnRePrintReceipt.Location = new Point(842, 13);
            btnRePrintReceipt.Margin = new Padding(3, 4, 3, 4);
            btnRePrintReceipt.Name = "btnRePrintReceipt";
            btnRePrintReceipt.Size = new Size(223, 48);
            btnRePrintReceipt.TabIndex = 1;
            btnRePrintReceipt.Text = "🖨️ Xem && In Lại Phiếu Nhập";
            btnRePrintReceipt.UseVisualStyleBackColor = false;
            btnRePrintReceipt.Click += btnRePrintReceipt_Click;
            // 
            // lblHistorySummary
            // 
            lblHistorySummary.AutoSize = true;
            lblHistorySummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHistorySummary.ForeColor = Color.FromArgb(47, 53, 66);
            lblHistorySummary.Location = new Point(17, 24);
            lblHistorySummary.Name = "lblHistorySummary";
            lblHistorySummary.Size = new Size(348, 23);
            lblHistorySummary.TabIndex = 0;
            lblHistorySummary.Text = "📊 Tổng phiếu nhập: 0 | Tổng vốn: 0 VNĐ";
            // 
            // FormStockImport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 793);
            Controls.Add(tabControlStock);
            Margin = new Padding(3, 4, 3, 4);
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
