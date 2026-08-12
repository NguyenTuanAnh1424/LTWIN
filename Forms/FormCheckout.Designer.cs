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
            panelHeader.Location = new Point(17, 20);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1132, 67);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(47, 53, 66);
            lblTitle.Location = new Point(17, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(293, 30);
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
            panelSelectProduct.Location = new Point(17, 87);
            panelSelectProduct.Margin = new Padding(3, 4, 3, 4);
            panelSelectProduct.Name = "panelSelectProduct";
            panelSelectProduct.Padding = new Padding(17, 20, 17, 20);
            panelSelectProduct.Size = new Size(1132, 93);
            panelSelectProduct.TabIndex = 1;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(46, 213, 115);
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(709, 24);
            btnAddToCart.Margin = new Padding(3, 4, 3, 4);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(171, 43);
            btnAddToCart.TabIndex = 4;
            btnAddToCart.Text = "\U0001f6d2 Thêm Vào Giỏ";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.Location = new Point(549, 27);
            numQuantity.Margin = new Padding(3, 4, 3, 4);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(126, 30);
            numQuantity.TabIndex = 3;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblQuantity.Location = new Point(463, 31);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(86, 21);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Số Lượng:";
            // 
            // cmbProducts
            // 
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducts.Font = new Font("Segoe UI", 10F);
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(154, 27);
            cmbProducts.Margin = new Padding(3, 4, 3, 4);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(285, 31);
            cmbProducts.TabIndex = 1;
            // 
            // lblSelectProduct
            // 
            lblSelectProduct.AutoSize = true;
            lblSelectProduct.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSelectProduct.Location = new Point(17, 31);
            lblSelectProduct.Name = "lblSelectProduct";
            lblSelectProduct.Size = new Size(130, 21);
            lblSelectProduct.TabIndex = 0;
            lblSelectProduct.Text = "Chọn Mẫu Giày:";
            // 
            // panelCart
            // 
            panelCart.BackColor = Color.White;
            panelCart.Controls.Add(panelBottomAction);
            panelCart.Controls.Add(dgvCart);
            panelCart.Dock = DockStyle.Fill;
            panelCart.Location = new Point(17, 180);
            panelCart.Margin = new Padding(3, 4, 3, 4);
            panelCart.Name = "panelCart";
            panelCart.Padding = new Padding(17, 13, 17, 20);
            panelCart.Size = new Size(1132, 573);
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
            panelBottomAction.Location = new Point(17, 446);
            panelBottomAction.Margin = new Padding(3, 4, 3, 4);
            panelBottomAction.Name = "panelBottomAction";
            panelBottomAction.Size = new Size(1098, 107);
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
            btnCheckout.Location = new Point(806, 20);
            btnCheckout.Margin = new Padding(3, 4, 3, 4);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(292, 67);
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
            btnClearCart.Location = new Point(154, 29);
            btnClearCart.Margin = new Padding(3, 4, 3, 4);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(161, 48);
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
            btnRemoveCart.Location = new Point(11, 29);
            btnRemoveCart.Margin = new Padding(3, 4, 3, 4);
            btnRemoveCart.Name = "btnRemoveCart";
            btnRemoveCart.Size = new Size(126, 48);
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
            lblTotalMoney.Location = new Point(549, 33);
            lblTotalMoney.Name = "lblTotalMoney";
            lblTotalMoney.Size = new Size(99, 37);
            lblTotalMoney.TabIndex = 1;
            lblTotalMoney.Text = "0 VNĐ";
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.FromArgb(47, 53, 66);
            lblTotalTitle.Location = new Point(343, 40);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(188, 28);
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
            dgvCart.Location = new Point(17, 13);
            dgvCart.Margin = new Padding(3, 4, 3, 4);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.RowTemplate.Height = 35;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(1098, 540);
            dgvCart.TabIndex = 0;
            // 
            // FormCheckout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 773);
            Controls.Add(panelCart);
            Controls.Add(panelSelectProduct);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormCheckout";
            Padding = new Padding(17, 20, 17, 20);
            Text = "Bán Hàng & Lập Hóa Đơn";
            Load += FormCheckout_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSelectProduct.ResumeLayout(false);
            panelSelectProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
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
