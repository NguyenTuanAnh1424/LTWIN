using System;
using System.Drawing;
using System.Windows.Forms;
using LTWIN.Models;

namespace LTWIN.Forms
{
    /// <summary>
    /// MÀN HÌNH CHÍNH CỦA ỨNG DỤNG WINDOWS FORMS (FORMMAIN.CS)
    /// Đã tích hợp Màn Hình Bán Hàng POS, Quản Lý Khách Hàng & Điểm Tích Lũy, Quản Lý Sản Phẩm kèm Xem Ảnh.
    /// </summary>
    public partial class FormMain : Form
    {
        private readonly User currentUser;
        private Form activeForm = null;

        public bool IsLoggingOut { get; private set; } = false;

        public FormMain()
        {
            InitializeComponent();
            currentUser = new User { FullName = "Admin Quản Trị", Role = "Admin" };
        }

        public FormMain(User user)
        {
            InitializeComponent();
            currentUser = user ?? new User { FullName = "Khách Hàng", Role = "Employee" };
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            string roleName = currentUser.Role == "Admin" ? "Quản Trị Viên" : "Nhân Viên Bán Hàng";
            lblUserRole.Text = $"👤 {currentUser.FullName} ({roleName})";

            if (currentUser.Role.Equals("Employee", StringComparison.OrdinalIgnoreCase))
            {
                // Nhân viên bán hàng: Ẩn các menu quản lý sản phẩm, danh mục và thống kê báo cáo
                btnProduct.Visible = false;
                btnCategory.Visible = false;
                btnReport.Visible = false;

                // Mở sẵn các menu bán hàng POS, lịch sử hóa đơn, nhập kho và quản lý khách hàng
                btnPOS.Visible = true;
                btnOrderHistory.Visible = true;
                btnStockImport.Visible = true;
                btnCustomer.Visible = true;

                // Mặc định mở ngay Màn hình Bán Hàng POS
                OpenChildForm(new FormPOS(), btnPOS, "MÀN HÌNH BÁN HÀNG POS TẠI QUẦY");
            }
            else
            {
                // Quản trị viên (Admin): Hiển thị đầy đủ tất cả các menu
                btnProduct.Visible = true;
                btnCategory.Visible = true;
                btnPOS.Visible = true;
                btnOrderHistory.Visible = true;
                btnStockImport.Visible = true;
                btnCustomer.Visible = true;
                btnReport.Visible = true;

                // Mặc định mở màn hình Quản Lý Giày
                OpenChildForm(new FormProduct(), btnProduct, "QUẢN LÝ SẢN PHẨM GIÀY");
            }
        }

        private void OpenChildForm(Form childForm, Button btnSender, string titleText)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            HighlightSidebarButton(btnSender);

            lblTitle.Text = titleText;

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

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
