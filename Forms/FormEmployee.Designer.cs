namespace LTWIN.Forms
{
    partial class FormEmployee
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
            dgvEmployees = new DataGridView();
            txtFullName = new TextBox();
            txtPassword = new TextBox();
            txtPhoneNumber = new TextBox();
            cmbRole = new ComboBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnSearch = new Button();
            txtSearch = new TextBox();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(12, 57);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(371, 328);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(555, 71);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(216, 27);
            txtFullName.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(555, 114);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(216, 27);
            txtPassword.TabIndex = 2;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(555, 163);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(216, 27);
            txtPhoneNumber.TabIndex = 3;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Employee" });
            cmbRole.Location = new Point(555, 218);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(216, 28);
            cmbRole.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(438, 298);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(154, 44);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "+ Thêm Nhân Viên";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(609, 298);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(117, 44);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "✏️ Cập Nhật";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(438, 363);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(153, 44);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(402, 75);
            label1.Name = "label1";
            label1.Size = new Size(149, 28);
            label1.TabIndex = 8;
            label1.Text = "Tên đăng nhập :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(403, 114);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 9;
            label2.Text = "Mật khẩu :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(403, 159);
            label3.Name = "label3";
            label3.Size = new Size(137, 28);
            label3.TabIndex = 10;
            label3.Text = "Số điện thoại :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(403, 214);
            label4.Name = "label4";
            label4.Size = new Size(115, 28);
            label4.TabIndex = 11;
            label4.Text = "Quyền hạn :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.DodgerBlue;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(471, 22);
            label5.Name = "label5";
            label5.Size = new Size(243, 28);
            label5.TabIndex = 12;
            label5.Text = "THÔNG TIN NHÂN VIÊN";
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(44, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(79, 30);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "🔍 Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(139, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 14;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(609, 363);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(117, 44);
            btnClear.TabIndex = 15;
            btnClear.Text = "🔄 Làm Mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // FormEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(cmbRole);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtPassword);
            Controls.Add(txtFullName);
            Controls.Add(dgvEmployees);
            Name = "FormEmployee";
            Text = "Quản Lý Nhân Viên & Tài Khoản";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmployees;
        private TextBox txtFullName;
        private TextBox txtPassword;
        private TextBox txtPhoneNumber;
        private ComboBox cmbRole;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSearch;
        private TextBox txtSearch;
        private Button btnClear;
    }
}