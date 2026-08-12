using System;
using System.Drawing;
using System.Windows.Forms;
using LTWIN.Models;

namespace LTWIN.Forms
{
    /// <summary>
    /// MÀN HÌNH CHÍNH ỨNG DỤNG (FORMMAIN.CS)
    /// Điều hướng toàn bộ các chức năng hệ thống và phân quyền theo Role thực tế từ SQL Server.
    /// </summary>
    public partial class FormMain : Form
    {
        private readonly User currentUser;
        private Form activeForm = null;

        public bool IsLoggingOut { get; private set; } = false;

        // Constructor mặc định (dùng cho Designer)
        public FormMain()
        {
            InitializeComponent();
            currentUser = new User { FullName = "Quản Trị Viên", Role = "Admin" };
        }

        // Constructor nhận thông tin User đăng nhập thật từ SQL Server
        public FormMain(User user)
        {
            InitializeComponent();
            currentUser = user ?? new User { FullName = "Nhân Viên Bán Hàng", Role = "Employee" };
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ApplyRolePermissions();
        }

        // PHÂN QUYỀN HIỂN THỊ MENU THEO ROLE THẬT TỪ CSDL
        private void ApplyRolePermissions()
        {
            string userRole = currentUser.Role ?? "Admin";
            string roleDisplayName = userRole.Equals("Admin", StringComparison.OrdinalIgnoreCase)
                                     ? "Quản Trị Viên"
                                     : "Nhân Viên Bán Hàng";

            lblUserRole.Text = $"👤 {currentUser.FullName ?? "Người Dùng"} ({roleDisplayName})";

            if (userRole.Equals("Employee", StringComparison.OrdinalIgnoreCase))
            {
                // Nhân viên: Ẩn các menu Quản lý sản phẩm, Danh mục, Nhân viên & Báo cáo
                btnProduct.Visible = false;
                btnCategory.Visible = false;
                btnReport.Visible = false;
                btnEmployee.Visible = false;

                // Hiển thị menu tác nghiệp hàng ngày
                btnPOS.Visible = true;
                btnOrderHistory.Visible = true;
                btnStockImport.Visible = true;
                btnCustomer.Visible = true;

                // Mặc định mở ngay màn hình Bán Hàng POS
                OpenChildForm(new FormPOS(), btnPOS, "MÀN HÌNH BÁN HÀNG POS TẠI QUẦY");
            }
            else
            {
                // Quản trị viên (Admin): Hiển thị đầy đủ tất cả menu
                btnProduct.Visible = true;
                btnCategory.Visible = true;
                btnPOS.Visible = true;
                btnOrderHistory.Visible = true;
                btnStockImport.Visible = true;
                btnCustomer.Visible = true;
                btnReport.Visible = true;
                btnEmployee.Visible = true;

                // Mặc định mở màn hình Quản Lý Giày
                OpenChildForm(new FormProduct(), btnProduct, "QUẢN LÝ SẢN PHẨM GIÀY");
            }
        }

        // HÀM MỞ FORM CON TRONG PANEL CHÍNH & DỌN DẸP BỘ NHỚ
        private void OpenChildForm(Form childForm, Button btnSender, string titleText)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose(); // Dọn dẹp tài nguyên Form cũ
            }

            HighlightSidebarButton(btnSender);

            lblTitle.Text = titleText;

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelChildForm.Controls.Clear(); // Làm sạch panel trước khi chèn form mới
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // TỰ ĐỘNG ĐỔI MÀU NÚT SIDEBAR ĐANG ĐƯỢC CHỌN
        private void HighlightSidebarButton(Button activeBtn)
        {
            foreach (Control control in panelSidebar.Controls)
            {
                if (control is Button btn && btn != btnExit && btn != btnLogout)
                {
                    btn.BackColor = Color.FromArgb(30, 34, 45);
                    btn.ForeColor = Color.FromArgb(203, 213, 225);
                }
            }

            if (activeBtn != null && activeBtn != btnLogout && activeBtn != btnExit)
            {
                activeBtn.BackColor = Color.FromArgb(79, 70, 229);
                activeBtn.ForeColor = Color.White;
            }
        }

        // --- CÁC SỰ KIỆN CLICK CHUYỂN MÀN HÌNH ---

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormProduct(), (Button)sender, "QUẢN LÝ SẢN PHẨM GIÀY");
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCategory(), (Button)sender, "QUẢN LÝ DANH MỤC GIÀY");
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormPOS(), (Button)sender, "MÀN HÌNH BÁN HÀNG POS TẠI QUẦY");
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCustomer(), (Button)sender, "QUẢN LÝ KHÁCH HÀNG & ĐIỂM TÍCH LŨY");
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormOrderHistory(), (Button)sender, "QUẢN LÝ LỊCH SỬ HÓA ĐƠN & ĐƠN HÀNG");
        }

        private void btnStockImport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormStockImport(), (Button)sender, "QUẢN LÝ NHẬP KHO SẢN PHẨM GIÀY");
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormReport(), (Button)sender, "THỐNG KÊ & BÁO CÁO DOANH THU");
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormEmployee(), (Button)sender, "QUẢN LÝ NHÂN VIÊN & TÀI KHOẢN");
        }

        // ĐĂNG XUẤT TÀI KHOẢN
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn ĐĂNG XUẤT khỏi tài khoản '{currentUser.FullName}'?",
                "Xác Nhận Đăng Xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                IsLoggingOut = true;
                this.Close();
            }
        }

        // THOÁT ỨNG DỤNG
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát hẳn ứng dụng không?",
                "Xác Nhận Thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                IsLoggingOut = false;
                Application.Exit();
            }
        }
    }
}