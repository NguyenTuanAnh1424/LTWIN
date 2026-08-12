using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LTWIN.Models;
using LTWIN.Utils;

namespace LTWIN.Forms
{
    public partial class FormCustomer : Form
    {
        private int selectedCustomerId = -1;

        public FormCustomer()
        {
            InitializeComponent();
        }

        // 1. TẢI DỮ LIỆU TỪ BẢNG dbo.Customers
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvCustomers);
            LoadCustomerDataGrid();
        }

        private void LoadCustomerDataGrid()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            using (var db = new QlyBanGiayContext())
            {
                var query = db.Customers.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(c => c.FullName.ToLower().Contains(keyword) ||
                                             c.PhoneNumber.Contains(keyword));
                }

                var displayData = query.Select(c => new
                {
                    Mã_KH = c.CustomerId,
                    Họ_Và_Tên = c.FullName,
                    Số_Điện_Thoại = c.PhoneNumber,
                    Email = string.IsNullOrEmpty(c.Email) ? "-" : c.Email,
                    Địa_Chỉ = string.IsNullOrEmpty(c.Address) ? "-" : c.Address,
                    Điểm_Tích_Lũy = c.RewardPoints + " Đ"
                }).ToList();

                dgvCustomers.DataSource = displayData;
            }
        }

        // 2. CLICK DÒNG TRÊN BẢNG
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomers.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedCustomerId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["Mã_KH"].Value);

                using (var db = new QlyBanGiayContext())
                {
                    var customer = db.Customers.FirstOrDefault(c => c.CustomerId == selectedCustomerId);
                    if (customer != null)
                    {
                        txtFullName.Text = customer.FullName;
                        txtPhoneNumber.Text = customer.PhoneNumber;
                        txtEmail.Text = customer.Email;
                        txtAddress.Text = customer.Address;
                        numRewardPoints.Value = customer.RewardPoints;
                    }
                }
            }
        }

        // 3. THÊM KHÁCH HÀNG
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Số điện thoại khách hàng!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                bool isExist = db.Customers.Any(c => c.PhoneNumber == txtPhoneNumber.Text.Trim());
                if (isExist)
                {
                    MessageBox.Show("Số điện thoại này đã tồn tại trong hệ thống!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newCustomer = new Customer
                {
                    FullName = txtFullName.Text.Trim(),
                    PhoneNumber = txtPhoneNumber.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    RewardPoints = (int)numRewardPoints.Value
                };

                db.Customers.Add(newCustomer);
                db.SaveChanges();

                LoadCustomerDataGrid();
                ClearFormInputs();

                MessageBox.Show($"Đã thêm mới khách hàng '{newCustomer.FullName}' thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 4. CẬP NHẬT
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                var customer = db.Customers.FirstOrDefault(c => c.CustomerId == selectedCustomerId);
                if (customer != null)
                {
                    customer.FullName = txtFullName.Text.Trim();
                    customer.PhoneNumber = txtPhoneNumber.Text.Trim();
                    customer.Email = txtEmail.Text.Trim();
                    customer.Address = txtAddress.Text.Trim();
                    customer.RewardPoints = (int)numRewardPoints.Value;

                    db.SaveChanges();

                    LoadCustomerDataGrid();
                    ClearFormInputs();
                    MessageBox.Show("Đã cập nhật thông tin khách hàng thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // 5. XÓA KHÁCH HÀNG
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                var customer = db.Customers.FirstOrDefault(c => c.CustomerId == selectedCustomerId);
                if (customer != null)
                {
                    var confirm = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng '{customer.FullName}'?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        db.Customers.Remove(customer);
                        db.SaveChanges();

                        LoadCustomerDataGrid();
                        ClearFormInputs();
                        MessageBox.Show("Đã xóa khách hàng thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // 6. CỘNG ĐIỂM THƯỞNG
        private void btnAddPoints_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để cộng điểm!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                var customer = db.Customers.FirstOrDefault(c => c.CustomerId == selectedCustomerId);
                if (customer != null)
                {
                    customer.RewardPoints += 50;
                    db.SaveChanges();

                    numRewardPoints.Value = customer.RewardPoints;
                    LoadCustomerDataGrid();

                    MessageBox.Show($"Đã cộng +50 điểm cho khách hàng '{customer.FullName}'.\nTổng điểm: {customer.RewardPoints} Đ", "Tích Điểm Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // 7. TÌM KIẾM VÀ RESET
        private void btnSearch_Click(object sender, EventArgs e) => LoadCustomerDataGrid();
        private void btnClear_Click(object sender, EventArgs e) => ClearFormInputs();

        private void ClearFormInputs()
        {
            selectedCustomerId = -1;
            txtFullName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtSearch.Text = string.Empty;
            numRewardPoints.Value = 0;
            txtFullName.Focus();
        }
    }
}