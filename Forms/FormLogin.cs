using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTWIN.Models;
using LTWIN.Utils;

namespace LTWIN.Forms
{
    /// <summary>
    /// MÀN HÌNH ĐĂNG NHẬP (FORMLOGIN.CS)
    /// Hỗ trợ cả xác thực qua CSDL SQL Server (PasswordHelper) và Mock Users cho Demo WinForms.
    /// </summary>
    public partial class FormLogin : Form
    {
        public User LoggedInUser { get; private set; }

        private List<User> mockUserList;

        public FormLogin()
        {
            InitializeComponent();
            InitMockUsers();
        }

        private void InitMockUsers()
        {
            mockUserList = new List<User>
            {
                new User { UserId = 1, Username = "admin", PasswordHash = "admin123", FullName = "Nguyễn Văn Hoàng (Admin)", Role = "Admin" },
                new User { UserId = 2, Username = "nhanvien", PasswordHash = "123456", FullName = "Trần Thị Bích (Nhân Viên)", Role = "Employee" }
            };
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            User? authenticatedUser = null;

            // 1. Kiểm tra nhanh kết nối SQL Server (Timeout 1 giây) trong background Task
            try
            {
                using (var cts = new CancellationTokenSource(1000))
                {
                    authenticatedUser = await Task.Run(() =>
                    {
                        try
                        {
                            using (var db = new QlyBanGiayContext())
                            {
                                if (!db.Database.CanConnect())
                                    return null;

                                string hashedPassword = PasswordHelper.HashPassword(password);
                                return db.Users.FirstOrDefault(u => u.Username == username && (u.PasswordHash == hashedPassword || u.PasswordHash == password));
                            }
                        }
                        catch
                        {
                            return null;
                        }
                    }, cts.Token);
                }
            }
            catch
            {
                authenticatedUser = null;
            }

            this.Cursor = Cursors.Default;
            btnLogin.Enabled = true;

            if (authenticatedUser != null)
            {
                UserSession.UserId = authenticatedUser.UserId;
                UserSession.Username = authenticatedUser.Username;
                UserSession.Role = authenticatedUser.Role ?? "Admin";

                LoggedInUser = authenticatedUser;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // 2. Fallback siêu nhanh qua Mock Data (admin/admin123 & nhanvien/123456)
            var mockUser = mockUserList.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.PasswordHash == password);

            if (mockUser != null)
            {
                UserSession.UserId = mockUser.UserId;
                UserSession.Username = mockUser.Username;
                UserSession.Role = mockUser.Role;

                LoggedInUser = mockUser;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!\n\nTài khoản dùng thử:\n• Admin: admin / admin123\n• Nhân viên: nhanvien / 123456", "Đăng Nhập Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
