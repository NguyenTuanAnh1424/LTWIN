namespace LTWIN.Forms
{
    partial class FormProduct
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
            panelSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            cmbCategoryFilter = new ComboBox();
            dgvProducts = new DataGridView();
            panelInput = new Panel();
            btnSelectImage = new Button();
            picProductImage = new PictureBox();
            lblImageTitle = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            numStock = new NumericUpDown();
            lblStock = new Label();
            numPrice = new NumericUpDown();
            lblPrice = new Label();
            cmbCategory = new ComboBox();
            lblCategory = new Label();
            txtName = new TextBox();
            lblName = new Label();
            lblFormTitle = new Label();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(cmbCategoryFilter);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(15);
            panelSearch.Size = new Size(1020, 60);
            panelSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(47, 53, 66);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(560, 15);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(220, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên giày cần tìm...";
            txtSearch.Size = new Size(320, 26);
            txtSearch.TabIndex = 1;
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryFilter.Font = new Font("Segoe UI", 9.5F);
            cmbCategoryFilter.FormattingEnabled = true;
            cmbCategoryFilter.Location = new Point(15, 17);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(190, 25);
            cmbCategoryFilter.TabIndex = 0;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(0, 60);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowTemplate.Height = 35;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(630, 520);
            dgvProducts.TabIndex = 1;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.Controls.Add(btnSelectImage);
            panelInput.Controls.Add(picProductImage);
            panelInput.Controls.Add(lblImageTitle);
            panelInput.Controls.Add(btnClear);
            panelInput.Controls.Add(btnDelete);
            panelInput.Controls.Add(btnEdit);
            panelInput.Controls.Add(btnAdd);
            panelInput.Controls.Add(txtDescription);
            panelInput.Controls.Add(lblDescription);
            panelInput.Controls.Add(numStock);
            panelInput.Controls.Add(lblStock);
            panelInput.Controls.Add(numPrice);
            panelInput.Controls.Add(lblPrice);
            panelInput.Controls.Add(cmbCategory);
            panelInput.Controls.Add(lblCategory);
            panelInput.Controls.Add(txtName);
            panelInput.Controls.Add(lblName);
            panelInput.Controls.Add(lblFormTitle);
            panelInput.Dock = DockStyle.Right;
            panelInput.Location = new Point(630, 60);
            panelInput.Name = "panelInput";
            panelInput.Padding = new Padding(15);
            panelInput.Size = new Size(390, 520);
            panelInput.TabIndex = 2;
            // 
            // btnSelectImage
            // 
            btnSelectImage.BackColor = Color.FromArgb(47, 53, 66);
            btnSelectImage.FlatAppearance.BorderSize = 0;
            btnSelectImage.FlatStyle = FlatStyle.Flat;
            btnSelectImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSelectImage.ForeColor = Color.White;
            btnSelectImage.Location = new Point(255, 145);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(120, 30);
            btnSelectImage.TabIndex = 17;
            btnSelectImage.Text = "📷 Chọn Ảnh";
            btnSelectImage.UseVisualStyleBackColor = false;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // picProductImage
            // 
            picProductImage.BackColor = Color.FromArgb(241, 242, 246);
            picProductImage.BorderStyle = BorderStyle.FixedSingle;
            picProductImage.Location = new Point(255, 40);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(120, 100);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabIndex = 16;
            picProductImage.TabStop = false;
            // 
            // lblImageTitle
            // 
            lblImageTitle.AutoSize = true;
            lblImageTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblImageTitle.Location = new Point(255, 20);
            lblImageTitle.Name = "lblImageTitle";
            lblImageTitle.Size = new Size(89, 15);
            lblImageTitle.TabIndex = 15;
            lblImageTitle.Text = "Xem Trước Ảnh:";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(116, 125, 140);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(200, 465);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(175, 38);
            btnClear.TabIndex = 14;
            btnClear.Text = "🔄 Làm Mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 71, 87);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(15, 465);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(175, 38);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "🗑️ Xóa Giày";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(30, 144, 255);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(200, 415);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(175, 38);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "✏️ Cập Nhật";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 213, 115);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(15, 415);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(175, 38);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "➕ Thêm Giày Mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9.5F);
            txtDescription.Location = new Point(15, 345);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(360, 55);
            txtDescription.TabIndex = 10;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescription.Location = new Point(15, 327);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(95, 15);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Mô Tả Sản Phẩm:";
            // 
            // numStock
            // 
            numStock.Font = new Font("Segoe UI", 9.5F);
            numStock.Location = new Point(15, 290);
            numStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(360, 24);
            numStock.TabIndex = 8;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStock.Location = new Point(15, 272);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(111, 15);
            lblStock.TabIndex = 7;
            lblStock.Text = "Số Lượng Tồn Kho:";
            // 
            // numPrice
            // 
            numPrice.Font = new Font("Segoe UI", 9.5F);
            numPrice.Increment = new decimal(new int[] { 50000, 0, 0, 0 });
            numPrice.Location = new Point(15, 235);
            numPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(360, 24);
            numPrice.TabIndex = 6;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.Location = new Point(15, 217);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(81, 15);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Giá Bán (VNĐ):";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 9.5F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(15, 180);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(360, 25);
            cmbCategory.TabIndex = 4;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategory.Location = new Point(15, 162);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(93, 15);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Danh Mục Giày:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 9.5F);
            txtName.Location = new Point(15, 125);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Ví dụ: Nike Air Max...";
            txtName.Size = new Size(225, 24);
            txtName.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblName.Location = new Point(15, 107);
            lblName.Name = "lblName";
            lblName.Size = new Size(84, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Tên Mẫu Giày:";
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(47, 53, 66);
            lblFormTitle.Location = new Point(15, 15);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(227, 21);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "THÔNG TIN SẢN PHẨM GIÀY";
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 580);
            Controls.Add(dgvProducts);
            Controls.Add(panelInput);
            Controls.Add(panelSearch);
            Name = "FormProduct";
            Text = "Quản Lý Sản Phẩm Giày";
            Load += FormProduct_Load;
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSearch;
        private ComboBox cmbCategoryFilter;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvProducts;
        private Panel panelInput;
        private Label lblFormTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Label lblStock;
        private NumericUpDown numStock;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private Label lblImageTitle;
        private PictureBox picProductImage;
        private Button btnSelectImage;
    }
}
