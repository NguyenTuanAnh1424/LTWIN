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

namespace LTWIN.Forms
{
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }
        private void LoadEmployeeData()
        {
            using (var db = new QlyBanGiayContext())
            {
                // Tải danh sách nhân viên lên bảng dgvEmployees
                dgvEmployees.DataSource = db.Users.Select(u => new {
                    u.UserId,
                    u.Username,
                    u.FullName,
                    u.Role
                }).ToList();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để sửa!");
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    user.FullName = txtFullName.Text.Trim();
                    user.Role = cbRole.SelectedItem?.ToString();

                    // Nếu người dùng có nhập mật khẩu mới thì mới cập nhật mật khẩu
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        user.PasswordHash = PasswordHelper.HashPassword(txtPassword.Text.Trim());
                    }

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    LoadEmployeeData(); // Load lại bảng
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa!");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{username}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var db = new QlyBanGiayContext()) // Đổi QlyContext thành QlyBanGiayContext cho đúng tên của bạn
                {
                    var user = db.Users.FirstOrDefault(u => u.Username == username);
                    if (user != null)
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();
                        MessageBox.Show("Xóa tài khoản thành công!");
                        LoadEmployeeData();
                    }
                }
            }
        }
    }
}
