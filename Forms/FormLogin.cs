using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTWIN.Models;
using LTWIN.Utils;

namespace LTWIN.Forms
{
    /// <summary>
    /// MÀN HÌNH ĐĂNG NHẬP (FORMLOGIN.CS)
    /// Xác thực tài khoản người dùng trực tiếp qua CSDL SQL Server (dbo.Users).
    /// </summary>
    public partial class FormLogin : Form
    {
        public User LoggedInUser { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        // XÁC THỰC ĐĂNG NHẬP TRỰC TIẾP TỪ SQL SERVER
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

            User authenticatedUser = null;

            try
            {
                // Kiểm tra thông tin đăng nhập trong CSDL SQL Server
                authenticatedUser = await Task.Run(() =>
                {
                    using (var db = new QlyBanGiayContext())
                    {
                        string hashedPassword = PasswordHelper.HashPassword(password);

                        // Tìm user khớp Tên đăng nhập & Mật khẩu (Hỗ trợ cả Hash lẫn PlainText)
                        return db.Users.FirstOrDefault(u =>
                        u.Username == username && (u.PasswordHash == hashedPassword || u.PasswordHash == password));
                    }
                });
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                btnLogin.Enabled = true;
                MessageBox.Show($"Lỗi kết nối CSDL SQL Server: {ex.Message}", "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Cursor = Cursors.Default;
            btnLogin.Enabled = true;

            if (authenticatedUser != null)
            {
                // Lưu thông tin phiên làm việc
                UserSession.UserId = authenticatedUser.UserId;
                UserSession.Username = authenticatedUser.Username;
                UserSession.Role = authenticatedUser.Role ?? "Admin";

                LoggedInUser = authenticatedUser;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!\nVui lòng kiểm tra lại tài khoản trong SQL Server.",
                                "Đăng Nhập Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}