namespace LTWIN.Forms
{
    partial class FormMain
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
            panelSidebar = new Panel();
            btnExit = new Button();
            btnLogout = new Button();
            btnReport = new Button();
            btnStockImport = new Button();
            btnOrderHistory = new Button();
            btnCustomer = new Button();
            btnPOS = new Button();
            btnCategory = new Button();
            btnProduct = new Button();
            panelLogo = new Panel();
            lblLogoSub = new Label();
            lblLogoMain = new Label();
            panelHeader = new Panel();
            lblUserRole = new Label();
            lblTitle = new Label();
            panelChildForm = new Panel();
            btnEmployee = new Button();
            panelSidebar.SuspendLayout();
            panelLogo.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(30, 34, 45);
            panelSidebar.Controls.Add(btnEmployee);
            panelSidebar.Controls.Add(btnExit);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnReport);
            panelSidebar.Controls.Add(btnStockImport);
            panelSidebar.Controls.Add(btnOrderHistory);
            panelSidebar.Controls.Add(btnCustomer);
            panelSidebar.Controls.Add(btnPOS);
            panelSidebar.Controls.Add(btnCategory);
            panelSidebar.Controls.Add(btnProduct);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(274, 907);
            panelSidebar.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Bottom;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExit.ForeColor = Color.FromArgb(116, 125, 140);
            btnExit.Location = new Point(0, 780);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Padding = new Padding(23, 0, 0, 0);
            btnExit.Size = new Size(274, 60);
            btnExit.TabIndex = 7;
            btnExit.Text = "🚪 Thoát Ứng Dụng";
            btnExit.TextAlign = ContentAlignment.MiddleLeft;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(255, 71, 87);
            btnLogout.Location = new Point(0, 840);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(23, 0, 0, 0);
            btnLogout.Size = new Size(274, 67);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "🔑 Đăng Xuất Tài Khoản";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnReport
            // 
            btnReport.Dock = DockStyle.Top;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnReport.ForeColor = Color.FromArgb(223, 228, 234);
            btnReport.Location = new Point(0, 551);
            btnReport.Margin = new Padding(3, 4, 3, 4);
            btnReport.Name = "btnReport";
            btnReport.Padding = new Padding(23, 0, 0, 0);
            btnReport.Size = new Size(274, 73);
            btnReport.TabIndex = 5;
            btnReport.Text = "📊 Thống Kê && Báo Cáo";
            btnReport.TextAlign = ContentAlignment.MiddleLeft;
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // btnStockImport
            // 
            btnStockImport.Dock = DockStyle.Top;
            btnStockImport.FlatAppearance.BorderSize = 0;
            btnStockImport.FlatStyle = FlatStyle.Flat;
            btnStockImport.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnStockImport.ForeColor = Color.FromArgb(223, 228, 234);
            btnStockImport.Location = new Point(0, 478);
            btnStockImport.Margin = new Padding(3, 4, 3, 4);
            btnStockImport.Name = "btnStockImport";
            btnStockImport.Padding = new Padding(23, 0, 0, 0);
            btnStockImport.Size = new Size(274, 73);
            btnStockImport.TabIndex = 9;
            btnStockImport.Text = "📦 Nhập Kho Sản Phẩm";
            btnStockImport.TextAlign = ContentAlignment.MiddleLeft;
            btnStockImport.UseVisualStyleBackColor = true;
            btnStockImport.Click += btnStockImport_Click;
            // 
            // btnOrderHistory
            // 
            btnOrderHistory.Dock = DockStyle.Top;
            btnOrderHistory.FlatAppearance.BorderSize = 0;
            btnOrderHistory.FlatStyle = FlatStyle.Flat;
            btnOrderHistory.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnOrderHistory.ForeColor = Color.FromArgb(223, 228, 234);
            btnOrderHistory.Location = new Point(0, 405);
            btnOrderHistory.Margin = new Padding(3, 4, 3, 4);
            btnOrderHistory.Name = "btnOrderHistory";
            btnOrderHistory.Padding = new Padding(23, 0, 0, 0);
            btnOrderHistory.Size = new Size(274, 73);
            btnOrderHistory.TabIndex = 8;
            btnOrderHistory.Text = "📜 Lịch Sử Hóa Đơn";
            btnOrderHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnOrderHistory.UseVisualStyleBackColor = true;
            btnOrderHistory.Click += btnOrderHistory_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.Dock = DockStyle.Top;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnCustomer.ForeColor = Color.FromArgb(223, 228, 234);
            btnCustomer.Location = new Point(0, 332);
            btnCustomer.Margin = new Padding(3, 4, 3, 4);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Padding = new Padding(23, 0, 0, 0);
            btnCustomer.Size = new Size(274, 73);
            btnCustomer.TabIndex = 4;
            btnCustomer.Text = "👥 Quản Lý Khách Hàng";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnPOS
            // 
            btnPOS.Dock = DockStyle.Top;
            btnPOS.FlatAppearance.BorderSize = 0;
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnPOS.ForeColor = Color.FromArgb(223, 228, 234);
            btnPOS.Location = new Point(0, 259);
            btnPOS.Margin = new Padding(3, 4, 3, 4);
            btnPOS.Name = "btnPOS";
            btnPOS.Padding = new Padding(23, 0, 0, 0);
            btnPOS.Size = new Size(274, 73);
            btnPOS.TabIndex = 3;
            btnPOS.Text = "\U0001f6d2 Bán Hàng POS";
            btnPOS.TextAlign = ContentAlignment.MiddleLeft;
            btnPOS.UseVisualStyleBackColor = true;
            btnPOS.Click += btnPOS_Click;
            // 
            // btnCategory
            // 
            btnCategory.Dock = DockStyle.Top;
            btnCategory.FlatAppearance.BorderSize = 0;
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnCategory.ForeColor = Color.FromArgb(223, 228, 234);
            btnCategory.Location = new Point(0, 186);
            btnCategory.Margin = new Padding(3, 4, 3, 4);
            btnCategory.Name = "btnCategory";
            btnCategory.Padding = new Padding(23, 0, 0, 0);
            btnCategory.Size = new Size(274, 73);
            btnCategory.TabIndex = 2;
            btnCategory.Text = "🏷️ Quản Lý Danh Mục";
            btnCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnCategory.UseVisualStyleBackColor = true;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnProduct
            // 
            btnProduct.Dock = DockStyle.Top;
            btnProduct.FlatAppearance.BorderSize = 0;
            btnProduct.FlatStyle = FlatStyle.Flat;
            btnProduct.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnProduct.ForeColor = Color.FromArgb(223, 228, 234);
            btnProduct.Location = new Point(0, 113);
            btnProduct.Margin = new Padding(3, 4, 3, 4);
            btnProduct.Name = "btnProduct";
            btnProduct.Padding = new Padding(23, 0, 0, 0);
            btnProduct.Size = new Size(274, 73);
            btnProduct.TabIndex = 1;
            btnProduct.Text = "👟 Quản Lý Giày";
            btnProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnProduct.UseVisualStyleBackColor = true;
            btnProduct.Click += btnProduct_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(30, 35, 45);
            panelLogo.Controls.Add(lblLogoSub);
            panelLogo.Controls.Add(lblLogoMain);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(3, 4, 3, 4);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(274, 113);
            panelLogo.TabIndex = 0;
            // 
            // lblLogoSub
            // 
            lblLogoSub.AutoSize = true;
            lblLogoSub.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblLogoSub.ForeColor = Color.FromArgb(116, 125, 140);
            lblLogoSub.Location = new Point(55, 64);
            lblLogoSub.Name = "lblLogoSub";
            lblLogoSub.Size = new Size(217, 19);
            lblLogoSub.TabIndex = 1;
            lblLogoSub.Text = "HỆ THỐNG QUẢN LÝ BÁN GIÀY";
            // 
            // lblLogoMain
            // 
            lblLogoMain.AutoSize = true;
            lblLogoMain.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblLogoMain.ForeColor = Color.White;
            lblLogoMain.Location = new Point(25, 24);
            lblLogoMain.Name = "lblLogoMain";
            lblLogoMain.Size = new Size(250, 35);
            lblLogoMain.TabIndex = 0;
            lblLogoMain.Text = "👟 SNEAKER STORE";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblUserRole);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(274, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1097, 113);
            panelHeader.TabIndex = 1;
            // 
            // lblUserRole
            // 
            lblUserRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserRole.AutoSize = true;
            lblUserRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUserRole.ForeColor = Color.FromArgb(47, 53, 66);
            lblUserRole.Location = new Point(823, 43);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(264, 23);
            lblUserRole.TabIndex = 1;
            lblUserRole.Text = "👤 Nguyễn Văn Hoàng (Admin)";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(47, 53, 66);
            lblTitle.Location = new Point(34, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(353, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ SẢN PHẨM GIÀY";
            // 
            // panelChildForm
            // 
            panelChildForm.BackColor = Color.FromArgb(241, 242, 246);
            panelChildForm.Dock = DockStyle.Fill;
            panelChildForm.Location = new Point(274, 113);
            panelChildForm.Margin = new Padding(3, 4, 3, 4);
            panelChildForm.Name = "panelChildForm";
            panelChildForm.Padding = new Padding(23, 27, 23, 27);
            panelChildForm.Size = new Size(1097, 794);
            panelChildForm.TabIndex = 2;
            // 
            // btnEmployee
            // 
            btnEmployee.Dock = DockStyle.Top;
            btnEmployee.FlatAppearance.BorderSize = 0;
            btnEmployee.FlatStyle = FlatStyle.Flat;
            btnEmployee.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnEmployee.ForeColor = Color.FromArgb(223, 228, 234);
            btnEmployee.Location = new Point(0, 624);
            btnEmployee.Margin = new Padding(3, 4, 3, 4);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Padding = new Padding(23, 0, 0, 0);
            btnEmployee.Size = new Size(274, 73);
            btnEmployee.TabIndex = 10;
            btnEmployee.Text = "Quản Lý Nhân Viên";
            btnEmployee.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployee.UseVisualStyleBackColor = true;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 907);
            Controls.Add(panelChildForm);
            Controls.Add(panelHeader);
            Controls.Add(panelSidebar);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 784);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ Thống Quản Lý Bán Giày - SNEAKER STORE (C# WinForms)";
            Load += FormMain_Load;
            panelSidebar.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Panel panelLogo;
        private Label lblLogoMain;
        private Label lblLogoSub;
        private Button btnProduct;
        private Button btnCategory;
        private Button btnPOS;
        private Button btnCustomer;
        private Button btnOrderHistory;
        private Button btnStockImport;
        private Button btnReport;
        private Button btnLogout;
        private Button btnExit;
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblUserRole;
        private Panel panelChildForm;
        private Button btnEmployee;
    }
}
