namespace LTWIN.Forms
{
    partial class FormCategory
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
            dgvCategories = new DataGridView();
            panelInput = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtCategoryName = new TextBox();
            lblCategoryName = new Label();
            lblTitle = new Label();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            panelInput.SuspendLayout();
            SuspendLayout();
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(15);
            panelSearch.Size = new Size(1000, 60);
            panelSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(47, 53, 66);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(350, 15);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍 Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(15, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên danh mục cần tìm...";
            txtSearch.Size = new Size(320, 26);
            txtSearch.TabIndex = 0;
            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.BackgroundColor = Color.White;
            dgvCategories.BorderStyle = BorderStyle.None;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Dock = DockStyle.Fill;
            dgvCategories.Location = new Point(0, 60);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.RowTemplate.Height = 35;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(640, 520);
            dgvCategories.TabIndex = 1;
            dgvCategories.CellClick += dgvCategories_CellClick;
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.Controls.Add(btnClear);
            panelInput.Controls.Add(btnDelete);
            panelInput.Controls.Add(btnEdit);
            panelInput.Controls.Add(btnAdd);
            panelInput.Controls.Add(txtDescription);
            panelInput.Controls.Add(lblDescription);
            panelInput.Controls.Add(txtCategoryName);
            panelInput.Controls.Add(lblCategoryName);
            panelInput.Controls.Add(lblTitle);
            panelInput.Dock = DockStyle.Right;
            panelInput.Location = new Point(640, 60);
            panelInput.Name = "panelInput";
            panelInput.Padding = new Padding(15);
            panelInput.Size = new Size(360, 520);
            panelInput.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(116, 125, 140);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(185, 300);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(160, 38);
            btnClear.TabIndex = 8;
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
            btnDelete.Location = new Point(15, 300);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(160, 38);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "🗑️ Xóa";
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
            btnEdit.Location = new Point(185, 250);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(160, 38);
            btnEdit.TabIndex = 6;
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
            btnAdd.Location = new Point(15, 250);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(160, 38);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "➕ Thêm Danh Mục";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9.5F);
            txtDescription.Location = new Point(15, 145);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(330, 80);
            txtDescription.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescription.Location = new Point(15, 127);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 15);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Mô Tả Danh Mục:";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Font = new Font("Segoe UI", 9.5F);
            txtCategoryName.Location = new Point(15, 80);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.PlaceholderText = "Ví dụ: Giày Sneaker...";
            txtCategoryName.Size = new Size(330, 24);
            txtCategoryName.TabIndex = 2;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategoryName.Location = new Point(15, 62);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(89, 15);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "Tên Danh Mục:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(47, 53, 66);
            lblTitle.Location = new Point(15, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN DANH MỤC";
            // 
            // FormCategory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 580);
            Controls.Add(dgvCategories);
            Controls.Add(panelInput);
            Controls.Add(panelSearch);
            Name = "FormCategory";
            Text = "Quản Lý Danh Mục Giày";
            Load += FormCategory_Load;
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvCategories;
        private Panel panelInput;
        private Label lblTitle;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
    }
}
