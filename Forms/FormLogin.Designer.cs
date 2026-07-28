namespace LTWIN.Forms
{
    partial class FormLogin
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
            lblSubTitle = new Label();
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            lblHint = new Label();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader (THANH TIÊU ĐỀ LOGO CỬA HÀNG GIÀY)
            // 
            panelHeader.BackColor = Color.FromArgb(47, 53, 66);
            panelHeader.Controls.Add(lblSubTitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(420, 90);
            panelHeader.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSubTitle.ForeColor = Color.FromArgb(116, 125, 140);
            lblSubTitle.Location = new Point(102, 53);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(216, 15);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "HỆ THỐNG QUẢN LÝ CỬA HÀNG GIÀY";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(88, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(244, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👟 SNEAKER STORE POS";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(47, 53, 66);
            lblUsername.Location = new Point(45, 115);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(107, 17);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên Đăng Nhập:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10.5F);
            txtUsername.Location = new Point(45, 137);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Nhập admin hoặc nhanvien...";
            txtUsername.Size = new Size(330, 26);
            txtUsername.TabIndex = 2;
            txtUsername.Text = "admin";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(47, 53, 66);
            lblPassword.Location = new Point(45, 180);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(71, 17);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Mật Khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10.5F);
            txtPassword.Location = new Point(45, 202);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.PlaceholderText = "Nhập mật khẩu...";
            txtPassword.Size = new Size(330, 26);
            txtPassword.TabIndex = 4;
            txtPassword.Text = "admin123";
            // 
            // btnLogin (NÚT ĐĂNG NHẬP CHÍNH)
            // 
            btnLogin.BackColor = Color.FromArgb(255, 71, 87);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(45, 255);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(330, 42);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "🔐 ĐĂNG NHẬP HỆ THỐNG";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit (NÚT THOÁT)
            // 
            btnExit.BackColor = Color.FromArgb(116, 125, 140);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(45, 308);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(330, 36);
            btnExit.TabIndex = 6;
            btnExit.Text = "🚪 Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblHint.ForeColor = Color.Gray;
            lblHint.Location = new Point(65, 355);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(290, 15);
            lblHint.TabIndex = 7;
            lblHint.Text = "💡 Demo: Admin (admin/admin123) | N.Viên (nhanvien/123456)";
            // 
            // FormLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 385);
            Controls.Add(lblHint);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập Hệ Thống Quản Lý Bán Giày";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private Label lblHint;
    }
}
