namespace LTWIN.Forms
{
    partial class FormPOS
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
            panelLeft = new Panel();
            dgvShoesList = new DataGridView();
            panelShoeFilter = new Panel();
            btnSearchShoe = new Button();
            txtSearchShoe = new TextBox();
            cmbCategoryFilter = new ComboBox();
            panelRightCart = new Panel();
            dgvCartList = new DataGridView();
            panelPaymentSummary = new Panel();
            btnCompletePayment = new Button();
            btnClearCart = new Button();
            lblChangeMoney = new Label();
            lblChangeTitle = new Label();
            numCustomerMoney = new NumericUpDown();
            lblCustomerMoneyTitle = new Label();
            lblGrandTotal = new Label();
            lblGrandTotalTitle = new Label();
            numDiscount = new NumericUpDown();
            lblDiscountTitle = new Label();
            lblSubTotal = new Label();
            lblSubTotalTitle = new Label();
            panelCustomerHeader = new Panel();
            cmbCustomer = new ComboBox();
            lblCustomerTitle = new Label();
            lblPOSHeader = new Label();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShoesList).BeginInit();
            panelShoeFilter.SuspendLayout();
            panelRightCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCartList).BeginInit();
            panelPaymentSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCustomerMoney).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            panelCustomerHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(dgvShoesList);
            panelLeft.Controls.Add(panelShoeFilter);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(617, 773);
            panelLeft.TabIndex = 0;
            // 
            // dgvShoesList
            // 
            dgvShoesList.AllowUserToAddRows = false;
            dgvShoesList.AllowUserToDeleteRows = false;
            dgvShoesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShoesList.BackgroundColor = Color.White;
            dgvShoesList.BorderStyle = BorderStyle.None;
            dgvShoesList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShoesList.Dock = DockStyle.Fill;
            dgvShoesList.Location = new Point(0, 80);
            dgvShoesList.Margin = new Padding(3, 4, 3, 4);
            dgvShoesList.MultiSelect = false;
            dgvShoesList.Name = "dgvShoesList";
            dgvShoesList.ReadOnly = true;
            dgvShoesList.RowHeadersVisible = false;
            dgvShoesList.RowHeadersWidth = 51;
            dgvShoesList.RowTemplate.Height = 35;
            dgvShoesList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShoesList.Size = new Size(617, 693);
            dgvShoesList.TabIndex = 1;
            dgvShoesList.CellContentClick += dgvShoesList_CellContentClick;
            dgvShoesList.CellDoubleClick += dgvShoesList_CellDoubleClick;
            // 
            // panelShoeFilter
            // 
            panelShoeFilter.BackColor = Color.White;
            panelShoeFilter.Controls.Add(btnSearchShoe);
            panelShoeFilter.Controls.Add(txtSearchShoe);
            panelShoeFilter.Controls.Add(cmbCategoryFilter);
            panelShoeFilter.Dock = DockStyle.Top;
            panelShoeFilter.Location = new Point(0, 0);
            panelShoeFilter.Margin = new Padding(3, 4, 3, 4);
            panelShoeFilter.Name = "panelShoeFilter";
            panelShoeFilter.Padding = new Padding(14, 16, 14, 16);
            panelShoeFilter.Size = new Size(617, 80);
            panelShoeFilter.TabIndex = 0;
            // 
            // btnSearchShoe
            // 
            btnSearchShoe.BackColor = Color.FromArgb(47, 53, 66);
            btnSearchShoe.FlatAppearance.BorderSize = 0;
            btnSearchShoe.FlatStyle = FlatStyle.Flat;
            btnSearchShoe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearchShoe.ForeColor = Color.White;
            btnSearchShoe.Location = new Point(503, 20);
            btnSearchShoe.Margin = new Padding(3, 4, 3, 4);
            btnSearchShoe.Name = "btnSearchShoe";
            btnSearchShoe.Size = new Size(97, 40);
            btnSearchShoe.TabIndex = 2;
            btnSearchShoe.Text = "🔍 Tìm";
            btnSearchShoe.UseVisualStyleBackColor = false;
            btnSearchShoe.Click += btnSearchShoe_Click;
            // 
            // txtSearchShoe
            // 
            txtSearchShoe.Font = new Font("Segoe UI", 9.5F);
            txtSearchShoe.Location = new Point(217, 24);
            txtSearchShoe.Margin = new Padding(3, 4, 3, 4);
            txtSearchShoe.Name = "txtSearchShoe";
            txtSearchShoe.PlaceholderText = "Nhập tên giày cần chọn...";
            txtSearchShoe.Size = new Size(274, 29);
            txtSearchShoe.TabIndex = 1;
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryFilter.Font = new Font("Segoe UI", 9.5F);
            cmbCategoryFilter.FormattingEnabled = true;
            cmbCategoryFilter.Location = new Point(14, 23);
            cmbCategoryFilter.Margin = new Padding(3, 4, 3, 4);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(188, 29);
            cmbCategoryFilter.TabIndex = 0;
            cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
            // 
            // panelRightCart
            // 
            panelRightCart.BackColor = Color.White;
            panelRightCart.Controls.Add(dgvCartList);
            panelRightCart.Controls.Add(panelPaymentSummary);
            panelRightCart.Controls.Add(panelCustomerHeader);
            panelRightCart.Dock = DockStyle.Right;
            panelRightCart.Location = new Point(617, 0);
            panelRightCart.Margin = new Padding(3, 4, 3, 4);
            panelRightCart.Name = "panelRightCart";
            panelRightCart.Size = new Size(549, 773);
            panelRightCart.TabIndex = 1;
            // 
            // dgvCartList
            // 
            dgvCartList.AllowUserToAddRows = false;
            dgvCartList.AllowUserToDeleteRows = false;
            dgvCartList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCartList.BackgroundColor = Color.White;
            dgvCartList.BorderStyle = BorderStyle.None;
            dgvCartList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCartList.Dock = DockStyle.Fill;
            dgvCartList.Location = new Point(0, 80);
            dgvCartList.Margin = new Padding(3, 4, 3, 4);
            dgvCartList.MultiSelect = false;
            dgvCartList.Name = "dgvCartList";
            dgvCartList.RowHeadersVisible = false;
            dgvCartList.RowHeadersWidth = 51;
            dgvCartList.RowTemplate.Height = 32;
            dgvCartList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCartList.Size = new Size(549, 333);
            dgvCartList.TabIndex = 1;
            dgvCartList.CellContentClick += dgvCartList_CellContentClick;
            // 
            // panelPaymentSummary
            // 
            panelPaymentSummary.BackColor = Color.FromArgb(248, 249, 250);
            panelPaymentSummary.Controls.Add(btnCompletePayment);
            panelPaymentSummary.Controls.Add(btnClearCart);
            panelPaymentSummary.Controls.Add(lblChangeMoney);
            panelPaymentSummary.Controls.Add(lblChangeTitle);
            panelPaymentSummary.Controls.Add(numCustomerMoney);
            panelPaymentSummary.Controls.Add(lblCustomerMoneyTitle);
            panelPaymentSummary.Controls.Add(lblGrandTotal);
            panelPaymentSummary.Controls.Add(lblGrandTotalTitle);
            panelPaymentSummary.Controls.Add(numDiscount);
            panelPaymentSummary.Controls.Add(lblDiscountTitle);
            panelPaymentSummary.Controls.Add(lblSubTotal);
            panelPaymentSummary.Controls.Add(lblSubTotalTitle);
            panelPaymentSummary.Dock = DockStyle.Bottom;
            panelPaymentSummary.Location = new Point(0, 413);
            panelPaymentSummary.Margin = new Padding(3, 4, 3, 4);
            panelPaymentSummary.Name = "panelPaymentSummary";
            panelPaymentSummary.Padding = new Padding(17, 20, 17, 20);
            panelPaymentSummary.Size = new Size(549, 360);
            panelPaymentSummary.TabIndex = 2;
            // 
            // btnCompletePayment
            // 
            btnCompletePayment.BackColor = Color.FromArgb(255, 71, 87);
            btnCompletePayment.FlatAppearance.BorderSize = 0;
            btnCompletePayment.FlatStyle = FlatStyle.Flat;
            btnCompletePayment.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCompletePayment.ForeColor = Color.White;
            btnCompletePayment.Location = new Point(166, 273);
            btnCompletePayment.Margin = new Padding(3, 4, 3, 4);
            btnCompletePayment.Name = "btnCompletePayment";
            btnCompletePayment.Size = new Size(366, 67);
            btnCompletePayment.TabIndex = 11;
            btnCompletePayment.Text = "💳 THANH TOÁN && IN HÓA ĐƠN";
            btnCompletePayment.UseVisualStyleBackColor = false;
            btnCompletePayment.Click += btnCompletePayment_Click;
            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.FromArgb(116, 125, 140);
            btnClearCart.FlatAppearance.BorderSize = 0;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Location = new Point(17, 273);
            btnClearCart.Margin = new Padding(3, 4, 3, 4);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(137, 67);
            btnClearCart.TabIndex = 10;
            btnClearCart.Text = "🗑️ Hủy Giỏ";
            btnClearCart.UseVisualStyleBackColor = false;
            btnClearCart.Click += btnClearCart_Click;
            // 
            // lblChangeMoney
            // 
            lblChangeMoney.AutoSize = true;
            lblChangeMoney.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChangeMoney.ForeColor = Color.FromArgb(46, 213, 115);
            lblChangeMoney.Location = new Point(206, 213);
            lblChangeMoney.Name = "lblChangeMoney";
            lblChangeMoney.Size = new Size(74, 28);
            lblChangeMoney.TabIndex = 9;
            lblChangeMoney.Text = "0 VNĐ";
            // 
            // lblChangeTitle
            // 
            lblChangeTitle.AutoSize = true;
            lblChangeTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblChangeTitle.Location = new Point(17, 216);
            lblChangeTitle.Name = "lblChangeTitle";
            lblChangeTitle.Size = new Size(168, 21);
            lblChangeTitle.TabIndex = 8;
            lblChangeTitle.Text = "Tiền Thừa Trả Khách:";
            // 
            // numCustomerMoney
            // 
            numCustomerMoney.Font = new Font("Segoe UI", 10F);
            numCustomerMoney.Increment = new decimal(new int[] { 50000, 0, 0, 0 });
            numCustomerMoney.Location = new Point(206, 163);
            numCustomerMoney.Margin = new Padding(3, 4, 3, 4);
            numCustomerMoney.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numCustomerMoney.Name = "numCustomerMoney";
            numCustomerMoney.Size = new Size(326, 30);
            numCustomerMoney.TabIndex = 7;
            numCustomerMoney.ValueChanged += numCustomerMoney_ValueChanged;
            // 
            // lblCustomerMoneyTitle
            // 
            lblCustomerMoneyTitle.AutoSize = true;
            lblCustomerMoneyTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCustomerMoneyTitle.Location = new Point(17, 165);
            lblCustomerMoneyTitle.Name = "lblCustomerMoneyTitle";
            lblCustomerMoneyTitle.Size = new Size(134, 21);
            lblCustomerMoneyTitle.TabIndex = 6;
            lblCustomerMoneyTitle.Text = "Tiền Khách Đưa:";
            // 
            // lblGrandTotal
            // 
            lblGrandTotal.AutoSize = true;
            lblGrandTotal.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblGrandTotal.ForeColor = Color.FromArgb(255, 71, 87);
            lblGrandTotal.Location = new Point(206, 107);
            lblGrandTotal.Name = "lblGrandTotal";
            lblGrandTotal.Size = new Size(91, 35);
            lblGrandTotal.TabIndex = 5;
            lblGrandTotal.Text = "0 VNĐ";
            // 
            // lblGrandTotalTitle
            // 
            lblGrandTotalTitle.AutoSize = true;
            lblGrandTotalTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblGrandTotalTitle.Location = new Point(17, 113);
            lblGrandTotalTitle.Name = "lblGrandTotalTitle";
            lblGrandTotalTitle.Size = new Size(208, 25);
            lblGrandTotalTitle.TabIndex = 4;
            lblGrandTotalTitle.Text = "Tổng Tiền Thanh Toán:";
            // 
            // numDiscount
            // 
            numDiscount.Font = new Font("Segoe UI", 9.5F);
            numDiscount.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            numDiscount.Location = new Point(206, 64);
            numDiscount.Margin = new Padding(3, 4, 3, 4);
            numDiscount.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(326, 29);
            numDiscount.TabIndex = 3;
            numDiscount.ValueChanged += numDiscount_ValueChanged;
            // 
            // lblDiscountTitle
            // 
            lblDiscountTitle.AutoSize = true;
            lblDiscountTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDiscountTitle.Location = new Point(17, 67);
            lblDiscountTitle.Name = "lblDiscountTitle";
            lblDiscountTitle.Size = new Size(181, 21);
            lblDiscountTitle.TabIndex = 2;
            lblDiscountTitle.Text = "Giảm Giá / Chiết Khấu:";
            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblSubTotal.Location = new Point(206, 24);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(66, 25);
            lblSubTotal.TabIndex = 1;
            lblSubTotal.Text = "0 VNĐ";
            // 
            // lblSubTotalTitle
            // 
            lblSubTotalTitle.AutoSize = true;
            lblSubTotalTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSubTotalTitle.Location = new Point(17, 24);
            lblSubTotalTitle.Name = "lblSubTotalTitle";
            lblSubTotalTitle.Size = new Size(135, 21);
            lblSubTotalTitle.TabIndex = 0;
            lblSubTotalTitle.Text = "Tổng Tiền Hàng:";
            // 
            // panelCustomerHeader
            // 
            panelCustomerHeader.BackColor = Color.White;
            panelCustomerHeader.Controls.Add(cmbCustomer);
            panelCustomerHeader.Controls.Add(lblCustomerTitle);
            panelCustomerHeader.Controls.Add(lblPOSHeader);
            panelCustomerHeader.Dock = DockStyle.Top;
            panelCustomerHeader.Location = new Point(0, 0);
            panelCustomerHeader.Margin = new Padding(3, 4, 3, 4);
            panelCustomerHeader.Name = "panelCustomerHeader";
            panelCustomerHeader.Padding = new Padding(14, 16, 14, 16);
            panelCustomerHeader.Size = new Size(549, 80);
            panelCustomerHeader.TabIndex = 0;
            // 
            // cmbCustomer
            // 
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.Font = new Font("Segoe UI", 9F);
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(269, 23);
            cmbCustomer.Margin = new Padding(3, 4, 3, 4);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(262, 28);
            cmbCustomer.TabIndex = 2;
            // 
            // lblCustomerTitle
            // 
            lblCustomerTitle.AutoSize = true;
            lblCustomerTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCustomerTitle.Location = new Point(177, 28);
            lblCustomerTitle.Name = "lblCustomerTitle";
            lblCustomerTitle.Size = new Size(97, 20);
            lblCustomerTitle.TabIndex = 1;
            lblCustomerTitle.Text = "Khách Hàng:";
            // 
            // lblPOSHeader
            // 
            lblPOSHeader.AutoSize = true;
            lblPOSHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPOSHeader.ForeColor = Color.FromArgb(47, 53, 66);
            lblPOSHeader.Location = new Point(14, 24);
            lblPOSHeader.Name = "lblPOSHeader";
            lblPOSHeader.Size = new Size(177, 25);
            lblPOSHeader.TabIndex = 0;
            lblPOSHeader.Text = "\U0001f6d2 GIỎ HÀNG POS";
            // 
            // FormPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 773);
            Controls.Add(panelLeft);
            Controls.Add(panelRightCart);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPOS";
            Text = "Màn Hình Bán Hàng POS";
            Load += FormPOS_Load;
            panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShoesList).EndInit();
            panelShoeFilter.ResumeLayout(false);
            panelShoeFilter.PerformLayout();
            panelRightCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCartList).EndInit();
            panelPaymentSummary.ResumeLayout(false);
            panelPaymentSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCustomerMoney).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            panelCustomerHeader.ResumeLayout(false);
            panelCustomerHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private DataGridView dgvShoesList;
        private Panel panelShoeFilter;
        private ComboBox cmbCategoryFilter;
        private TextBox txtSearchShoe;
        private Button btnSearchShoe;
        private Panel panelRightCart;
        private Panel panelCustomerHeader;
        private Label lblPOSHeader;
        private Label lblCustomerTitle;
        private ComboBox cmbCustomer;
        private DataGridView dgvCartList;
        private Panel panelPaymentSummary;
        private Label lblSubTotalTitle;
        private Label lblSubTotal;
        private Label lblDiscountTitle;
        private NumericUpDown numDiscount;
        private Label lblGrandTotalTitle;
        private Label lblGrandTotal;
        private Label lblCustomerMoneyTitle;
        private NumericUpDown numCustomerMoney;
        private Label lblChangeTitle;
        private Label lblChangeMoney;
        private Button btnClearCart;
        private Button btnCompletePayment;
    }
}
