using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LTWIN.Models;
using LTWIN.Utils;

namespace LTWIN.Forms
{
    /// <summary>
    /// MÀN HÌNH QUẢN LÝ NHÂN VIÊN & TÀI KHOẢN (FORMEMPLOYEE.CS)
    /// Tích hợp đầy đủ CRUD trực tiếp với SQL Server cho các trường: Username, Password, Số điện thoại, Quyền hạn.
    /// </summary>
    public partial class FormEmployee : Form
    {
        private int selectedUserId = -1;

        public FormEmployee()
        {
            InitializeComponent();
        }

        // 1. FORM LOAD -> TẢI DỮ LIỆU VÀ ĐỊNH DẠNG COMBOBOX QUYỀN HẠN
        private void FormEmployee_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvEmployees);
            LoadRoleComboBox();
            LoadEmployeeDataGrid();
        }

        private void LoadRoleComboBox()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Employee");
            cmbRole.SelectedIndex = 1; // Mặc định là Employee
        }

        // TẢI DANH SÁCH NHÂN VIÊN TỪ CSDL SQL SERVER
        private void LoadEmployeeDataGrid()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            using (var db = new QlyBanGiayContext())
            {
                var query = db.Users.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(u => u.Username.ToLower().Contains(keyword) ||
                                             (u.FullName != null && u.FullName.ToLower().Contains(keyword)) ||
                                             (u.PhoneNumber != null && u.PhoneNumber.Contains(keyword)));
                }

                var displayData = query.Select(u => new
                {
                    Mã_NV = u.UserId,
                    Tên_Đăng_Nhập = u.Username,
                    Họ_Và_Tên = string.IsNullOrEmpty(u.FullName) ? "-" : u.FullName,
                    Số_Điện_Thoại = string.IsNullOrEmpty(u.PhoneNumber) ? "-" : u.PhoneNumber,
                    Quyền_Hạn = u.Role == "Admin" ? "Quản Trị Viên" : "Nhân Viên Bán Hàng"
                }).ToList();

                dgvEmployees.DataSource = displayData;
            }
        }

        // 2. CLICK DÒNG TRÊN BẢNG -> ĐỔ DỮ LIỆU LÊN FORM
        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvEmployees.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedUserId = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells["Mã_NV"].Value);

                using (var db = new QlyBanGiayContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.UserId == selectedUserId);
                    if (user != null)
                    {
                        txtFullName.Text = user.Username;
                        txtPassword.Text = ""; // Để trống mật khẩu để bảo mật khi chỉnh sửa
                        txtFullName.Text = user.FullName ?? "";
                        txtPhoneNumber.Text = user.PhoneNumber ?? "";

                        if (!string.IsNullOrEmpty(user.Role) && cmbRole.Items.Contains(user.Role))
                        {
                            cmbRole.SelectedItem = user.Role;
                        }
                    }
                }
            }
        }

        // 3. THÊM TÀI KHOẢN NHÂN VIÊN MỚI
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                bool isExist = db.Users.Any(u => u.Username.ToLower() == txtFullName.Text.Trim().ToLower());
                if (isExist)
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại trong hệ thống!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newUser = new User
                {
                    Username = txtFullName.Text.Trim(),
                    PasswordHash = PasswordHelper.HashPassword(txtPassword.Text.Trim()),
                    FullName = txtFullName.Text.Trim(),
                    PhoneNumber = txtPhoneNumber.Text.Trim(),
                    Role = cmbRole.SelectedItem?.ToString() ?? "Employee"
                };

                db.Users.Add(newUser);
                db.SaveChanges(); // LƯU VÀO SQL SERVER

                LoadEmployeeDataGrid();
                ClearInputs();

                MessageBox.Show($"Đã thêm tài khoản nhân viên '{newUser.Username}' thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 4. CẬP NHẬT THÔNG TIN / ĐỔI MẬT KHẨU
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedUserId <= 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản nhân viên cần cập nhật từ bảng!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserId == selectedUserId);
                if (user != null)
                {
                    user.FullName = txtFullName.Text.Trim();
                    user.PhoneNumber = txtPhoneNumber.Text.Trim();
                    user.Role = cmbRole.SelectedItem?.ToString() ?? "Employee";

                    // Chỉ đổi mã hóa mật khẩu nếu người dùng nhập mật khẩu mới
                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        user.PasswordHash = PasswordHelper.HashPassword(txtPassword.Text.Trim());
                    }

                    db.SaveChanges(); // CẬP NHẬT VÀO SQL SERVER

                    LoadEmployeeDataGrid();
                    ClearInputs();

                    MessageBox.Show("Đã cập nhật thông tin tài khoản thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Đảm bảo tương thích nếu Designer gọi tên btnUpdate_Click
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        // 5. XÓA TÀI KHOẢN NHÂN VIÊN
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId <= 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản nhân viên cần xóa!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedUserId == UserSession.UserId)
            {
                MessageBox.Show("Bạn không thể xóa tài khoản hiện đang đăng nhập hệ thống!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserId == selectedUserId);
                if (user != null)
                {
                    var confirm = MessageBox.Show($"Bạn có chắc muốn xóa tài khoản '{user.Username}'?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        db.Users.Remove(user);
                        db.SaveChanges(); // XÓA KHỎI SQL SERVER

                        LoadEmployeeDataGrid();
                        ClearInputs();

                        MessageBox.Show("Đã xóa tài khoản nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // 6. TÌM KIẾM VÀ LÀM MỚI
        private void btnSearch_Click(object sender, EventArgs e) => LoadEmployeeDataGrid();

        private void btnClear_Click(object sender, EventArgs e) => ClearInputs();

        private void ClearInputs()
        {
            selectedUserId = -1;
            txtFullName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtSearch.Text = string.Empty;
            cmbRole.SelectedIndex = 1;
            txtFullName.Focus();
        }
    }
}