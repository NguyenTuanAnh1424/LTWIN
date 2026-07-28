namespace LTWIN.Forms
{
    partial class FormCheckout
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
            panelHeader = new Panel();
            lblTitle = new Label();
            panelSelectProduct = new Panel();
            btnAddToCart = new Button();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cmbProducts = new ComboBox();
            lblSelectProduct = new Label();
            panelCart = new Panel();
            panelBottomAction = new Panel();
            btnCheckout = new Button();
            btnClearCart = new Button();
            btnRemoveCart = new Button();
            lblTotalMoney = new Label();
            lblTotalTitle = new Label();
            dgvCart = new DataGridView();
            panelHeader.SuspendLayout();
            panelSelectProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            panelCart.SuspendLayout();
            panelBottomAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(15, 15);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(990, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(47, 53, 66);
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(244, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BÁN HÀNG & LẬP HÓA ĐƠN";
            // 
            // panelSelectProduct
            // 
            panelSelectProduct.BackColor = Color.White;
            panelSelectProduct.Controls.Add(btnAddToCart);
            panelSelectProduct.Controls.Add(numQuantity);
            panelSelectProduct.Controls.Add(lblQuantity);
            panelSelectProduct.Controls.Add(cmbProducts);
            panelSelectProduct.Controls.Add(lblSelectProduct);
            panelSelectProduct.Dock = DockStyle.Top;
            panelSelectProduct.Location = new Point(15, 65);
            panelSelectProduct.Name = "panelSelectProduct";
            panelSelectProduct.Padding = new Padding(15);
            panelSelectProduct.Size = new Size(990, 70);
            panelSelectProduct.TabIndex = 1;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(46, 213, 115);
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(620, 18);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(150, 32);
            btnAddToCart.TabIndex = 4;
            btnAddToCart.Text = "🛒 Thêm Vào Giỏ";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.Location = new Point(480, 20);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(110, 25);
            numQuantity.TabIndex = 3;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblQuantity.Location = new Point(405, 23);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(71, 17);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Số Lượng:";
            // 
            // cmbProducts
            // 
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducts.Font = new Font("Segoe UI", 10F);
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(135, 20);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(250, 25);
            cmbProducts.TabIndex = 1;
            // 
            // lblSelectProduct
            // 
            lblSelectProduct.AutoSize = true;
            lblSelectProduct.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSelectProduct.Location = new Point(15, 23);
            lblSelectProduct.Name = "lblSelectProduct";
            lblSelectProduct.Size = new Size(110, 17);
            lblSelectProduct.TabIndex = 0;
            lblSelectProduct.Text = "Chọn Mẫu Giày:";
            // 
            // panelCart
            // 
            panelCart.BackColor = Color.White;
            panelCart.Controls.Add(panelBottomAction);
            panelCart.Controls.Add(dgvCart);
            panelCart.Dock = DockStyle.Fill;
            panelCart.Location = new Point(15, 135);
            panelCart.Name = "panelCart";
            panelCart.Padding = new Padding(15, 10, 15, 15);
            panelCart.Size = new Size(990, 430);
            panelCart.TabIndex = 2;
            // 
            // panelBottomAction
            // 
            panelBottomAction.Controls.Add(btnCheckout);
            panelBottomAction.Controls.Add(btnClearCart);
            panelBottomAction.Controls.Add(btnRemoveCart);
            panelBottomAction.Controls.Add(lblTotalMoney);
            panelBottomAction.Controls.Add(lblTotalTitle);
            panelBottomAction.Dock = DockStyle.Bottom;
            panelBottomAction.Location = new Point(15, 335);
            panelBottomAction.Name = "panelBottomAction";
            panelBottomAction.Size = new Size(960, 80);
            panelBottomAction.TabIndex = 1;
            // 
            // btnCheckout
            // 
            btnCheckout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCheckout.BackColor = Color.FromArgb(255, 71, 87);
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(740, 15);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(220, 50);
            btnCheckout.TabIndex = 4;
            btnCheckout.Text = "💳 THANH TOÁN HÓA ĐƠN";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.FromArgb(116, 125, 140);
            btnClearCart.FlatAppearance.BorderSize = 0;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Location = new Point(135, 22);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(110, 36);
            btnClearCart.TabIndex = 3;
            btnClearCart.Text = "🔄 Xóa TẤT CẢ";
            btnClearCart.UseVisualStyleBackColor = false;
            btnClearCart.Click += btnClearCart_Click;
            // 
            // btnRemoveCart
            // 
            btnRemoveCart.BackColor = Color.FromArgb(255, 165, 2);
            btnRemoveCart.FlatAppearance.BorderSize = 0;
            btnRemoveCart.FlatStyle = FlatStyle.Flat;
            btnRemoveCart.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRemoveCart.ForeColor = Color.White;
            btnRemoveCart.Location = new Point(10, 22);
            btnRemoveCart.Name = "btnRemoveCart";
            btnRemoveCart.Size = new Size(110, 36);
            btnRemoveCart.TabIndex = 2;
            btnRemoveCart.Text = "❌ Xóa Hàng";
            btnRemoveCart.UseVisualStyleBackColor = false;
            btnRemoveCart.Click += btnRemoveCart_Click;
            // 
            // lblTotalMoney
            // 
            lblTotalMoney.AutoSize = true;
            lblTotalMoney.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalMoney.ForeColor = Color.FromArgb(255, 71, 87);
            lblTotalMoney.Location = new Point(480, 25);
            lblTotalMoney.Name = "lblTotalMoney";
            lblTotalMoney.Size = new Size(74, 30);
            lblTotalMoney.TabIndex = 1;
            lblTotalMoney.Text = "0 VNĐ";
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.FromArgb(47, 53, 66);
            lblTotalTitle.Location = new Point(300, 30);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(168, 21);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "TỔNG CỘNG TIỀN:";
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new Point(15, 10);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowTemplate.Height = 35;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(960, 405);
            dgvCart.TabIndex = 0;
            // 
            // FormCheckout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 580);
            Controls.Add(panelCart);
            Controls.Add(panelSelectProduct);
            Controls.Add(panelHeader);
            Name = "FormCheckout";
            Padding = new Padding(15);
            Text = "Bán Hàng & Lập Hóa Đơn";
            Load += FormCheckout_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSelectProduct.ResumeLayout(false);
            panelSelectProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            panelCart.ResumeLayout(false);
            panelBottomAction.ResumeLayout(false);
            panelBottomAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelSelectProduct;
        private Label lblSelectProduct;
        private ComboBox cmbProducts;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Button btnAddToCart;
        private Panel panelCart;
        private DataGridView dgvCart;
        private Panel panelBottomAction;
        private Label lblTotalTitle;
        private Label lblTotalMoney;
        private Button btnRemoveCart;
        private Button btnClearCart;
        private Button btnCheckout;
    }
}
