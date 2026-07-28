namespace LTWIN.Forms
{
    partial class FormCustomer
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
            dgvCustomers = new DataGridView();
            panelInput = new Panel();
            btnAddPoints = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            numRewardPoints = new NumericUpDown();
            lblRewardPoints = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhoneNumber = new TextBox();
            lblPhoneNumber = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            lblFormTitle = new Label();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRewardPoints).BeginInit();
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
            btnSearch.Location = new Point(410, 15);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 30);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍 Tìm Kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(15, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên hoặc số điện thoại khách hàng...";
            txtSearch.Size = new Size(380, 26);
            txtSearch.TabIndex = 0;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.Location = new Point(0, 60);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.RowTemplate.Height = 32;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(640, 520);
            dgvCustomers.TabIndex = 1;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.Controls.Add(btnAddPoints);
            panelInput.Controls.Add(btnClear);
            panelInput.Controls.Add(btnDelete);
            panelInput.Controls.Add(btnEdit);
            panelInput.Controls.Add(btnAdd);
            panelInput.Controls.Add(numRewardPoints);
            panelInput.Controls.Add(lblRewardPoints);
            panelInput.Controls.Add(txtAddress);
            panelInput.Controls.Add(lblAddress);
            panelInput.Controls.Add(txtEmail);
            panelInput.Controls.Add(lblEmail);
            panelInput.Controls.Add(txtPhoneNumber);
            panelInput.Controls.Add(lblPhoneNumber);
            panelInput.Controls.Add(txtFullName);
            panelInput.Controls.Add(lblFullName);
            panelInput.Controls.Add(lblFormTitle);
            panelInput.Dock = DockStyle.Right;
            panelInput.Location = new Point(640, 60);
            panelInput.Name = "panelInput";
            panelInput.Padding = new Padding(15);
            panelInput.Size = new Size(380, 520);
            panelInput.TabIndex = 2;
            // 
            // btnAddPoints
            // 
            btnAddPoints.BackColor = Color.FromArgb(255, 165, 2);
            btnAddPoints.FlatAppearance.BorderSize = 0;
            btnAddPoints.FlatStyle = FlatStyle.Flat;
            btnAddPoints.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddPoints.ForeColor = Color.White;
            btnAddPoints.Location = new Point(255, 308);
            btnAddPoints.Name = "btnAddPoints";
            btnAddPoints.Size = new Size(110, 26);
            btnAddPoints.TabIndex = 15;
            btnAddPoints.Text = "🎁 Cộng 50 Đ";
            btnAddPoints.UseVisualStyleBackColor = false;
            btnAddPoints.Click += btnAddPoints_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(116, 125, 140);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(195, 455);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(170, 38);
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
            btnDelete.Location = new Point(15, 455);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(170, 38);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "🗑️ Xóa Khách Hàng";
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
            btnEdit.Location = new Point(195, 405);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(170, 38);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "✏️ Cập Nhật KH";
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
            btnAdd.Location = new Point(15, 405);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(170, 38);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "➕ Thêm KH Mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // numRewardPoints
            // 
            numRewardPoints.Font = new Font("Segoe UI", 9.5F);
            numRewardPoints.Location = new Point(15, 310);
            numRewardPoints.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numRewardPoints.Name = "numRewardPoints";
            numRewardPoints.Size = new Size(230, 24);
            numRewardPoints.TabIndex = 10;
            // 
            // lblRewardPoints
            // 
            lblRewardPoints.AutoSize = true;
            lblRewardPoints.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRewardPoints.Location = new Point(15, 292);
            lblRewardPoints.Name = "lblRewardPoints";
            lblRewardPoints.Size = new Size(88, 15);
            lblRewardPoints.TabIndex = 9;
            lblRewardPoints.Text = "Điểm Tích Lũy:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 9.5F);
            txtAddress.Location = new Point(15, 245);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Ví dụ: 123 Cầu Giấy, Hà Nội...";
            txtAddress.Size = new Size(350, 24);
            txtAddress.TabIndex = 8;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAddress.Location = new Point(15, 227);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(50, 15);
            lblAddress.TabIndex = 7;
            lblAddress.Text = "Địa Chỉ:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(15, 185);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "khachhang@gmail.com...";
            txtEmail.Size = new Size(350, 24);
            txtEmail.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(15, 167);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(40, 15);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Segoe UI", 9.5F);
            txtPhoneNumber.Location = new Point(15, 125);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "0988xxxxxx...";
            txtPhoneNumber.Size = new Size(350, 24);
            txtPhoneNumber.TabIndex = 4;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPhoneNumber.Location = new Point(15, 107);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(88, 15);
            lblPhoneNumber.TabIndex = 3;
            lblPhoneNumber.Text = "Số Điện Thoại:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 9.5F);
            txtFullName.Location = new Point(15, 65);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Ví dụ: Nguyễn Văn A...";
            txtFullName.Size = new Size(350, 24);
            txtFullName.TabIndex = 2;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFullName.Location = new Point(15, 47);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(67, 15);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Họ Và Tên:";
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(47, 53, 66);
            lblFormTitle.Location = new Point(15, 15);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(211, 21);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // FormCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 580);
            Controls.Add(dgvCustomers);
            Controls.Add(panelInput);
            Controls.Add(panelSearch);
            Name = "FormCustomer";
            Text = "Quản Lý Khách Hàng & Điểm Tích Lũy";
            Load += FormCustomer_Load;
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRewardPoints).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvCustomers;
        private Panel panelInput;
        private Label lblFormTitle;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblRewardPoints;
        private NumericUpDown numRewardPoints;
        private Button btnAddPoints;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
    }
}
