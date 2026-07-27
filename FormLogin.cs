using LTWIN.Models;
using LTWIN.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTWIN
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!");
                return;
            }

            // Gọi Database Context (Kiểm tra lại tên Context của bạn trong thư mục Models nếu khác)
            using (var db = new QlyBanGiayContext())
            {
                // Băm mật khẩu người dùng vừa nhập
                string hashedPassword = PasswordHelper.HashPassword(password);

                // Tìm user trong Database
                // Lưu ý: Cột Role, Password... phụ thuộc vào bảng Users trong DB của bạn
                var user = db.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hashedPassword);

                if (user != null)
                {
                    // Lưu Session
                    UserSession.UserId = user.UserId;
                    UserSession.Username = user.Username;
                    UserSession.Role = user.Role;

                    MessageBox.Show("Đăng nhập thành công với quyền " + UserSession.Role);

                    // Chuyển sang Form chính
                    FormMain mainForm = new FormMain();
                    mainForm.Show();
                    this.Hide(); // Ẩn form đăng nhập
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
            }
        }
    }
}
