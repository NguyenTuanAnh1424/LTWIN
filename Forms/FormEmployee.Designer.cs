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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtFullName = new TextBox();
            cbRole = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(32, 118);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(756, 206);
            dgvEmployees.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(187, 13);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(216, 27);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(187, 55);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(216, 27);
            txtPassword.TabIndex = 2;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(555, 17);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(216, 27);
            txtFullName.TabIndex = 3;
            // 
            // cbRole
            // 
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRole.FormattingEnabled = true;
            cbRole.Items.AddRange(new object[] { "Admin", "Employee" });
            cbRole.Location = new Point(555, 59);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(216, 28);
            cbRole.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(104, 351);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(116, 44);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(335, 351);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(117, 44);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(563, 351);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(116, 44);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 12);
            label1.Name = "label1";
            label1.Size = new Size(149, 28);
            label1.TabIndex = 8;
            label1.Text = "Tên đăng nhập :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 51);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 9;
            label2.Text = "Mật khẩu :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(423, 13);
            label3.Name = "label3";
            label3.Size = new Size(80, 28);
            label3.TabIndex = 10;
            label3.Text = "Họ tên :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(423, 55);
            label4.Name = "label4";
            label4.Size = new Size(115, 28);
            label4.TabIndex = 11;
            label4.Text = "Quyền hạn :";
            // 
            // FormEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(cbRole);
            Controls.Add(txtFullName);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(dgvEmployees);
            Name = "FormEmployee";
            Text = "Quản Lý Nhân Viên & Tài Khoản";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmployees;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtFullName;
        private ComboBox cbRole;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}