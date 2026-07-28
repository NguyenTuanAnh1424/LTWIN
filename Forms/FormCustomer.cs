using System;
using System.Collections.Generic;
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
        private List<Customer> mockCustomerList;

        public FormCustomer()
        {
            InitializeComponent();
            InitMockCustomers();
        }

        private void InitMockCustomers()
        {
            mockCustomerList = new List<Customer>
            {
                new Customer { CustomerId = 1, FullName = "Nguyễn Văn Hoàng", PhoneNumber = "0988123456", Email = "hoang.nv@gmail.com", Address = "123 Cầu Giấy, Hà Nội", RewardPoints = 350 },
                new Customer { CustomerId = 2, FullName = "Trần Thị Thu", PhoneNumber = "0912345678", Email = "thu.tt@gmail.com", Address = "456 Thanh Xuân, Hà Nội", RewardPoints = 120 },
                new Customer { CustomerId = 3, FullName = "Phạm Minh Đức", PhoneNumber = "0977888999", Email = "duc.pm@gmail.com", Address = "789 Đống Đa, Hà Nội", RewardPoints = 550 },
                new Customer { CustomerId = 4, FullName = "Lê Hoàng Yến", PhoneNumber = "0905111222", Email = "yen.lh@gmail.com", Address = "12 Ba Đình, Hà Nội", RewardPoints = 45 }
            };
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvCustomers);
            LoadCustomerDataGrid();
        }

        private void LoadCustomerDataGrid(List<Customer> listToDisplay = null)
        {
            var sourceList = listToDisplay ?? mockCustomerList;

            var displayData = sourceList.Select(c => new
            {
                Mã_KH = c.CustomerId,
                Họ_Và_Tên = c.FullName,
                Số_Điện_Thoại = c.PhoneNumber,
                Email = string.IsNullOrEmpty(c.Email) ? "-" : c.Email,
                Địa_Chỉ = string.IsNullOrEmpty(c.Address) ? "-" : c.Address,
                Điểm_Tích_Lũy = c.RewardPoints + " Đ",
                Hạng_Khách_Hàng = c.CustomerTier
            }).ToList();

            dgvCustomers.DataSource = displayData;
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomers.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedCustomerId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["Mã_KH"].Value);
                var customer = mockCustomerList.FirstOrDefault(c => c.CustomerId == selectedCustomerId);

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Số điện thoại khách hàng!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newId = mockCustomerList.Any() ? mockCustomerList.Max(c => c.CustomerId) + 1 : 1;

            var newCustomer = new Customer
            {
                CustomerId = newId,
                FullName = txtFullName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                RewardPoints = (int)numRewardPoints.Value
            };

            mockCustomerList.Add(newCustomer);
            LoadCustomerDataGrid();
            ClearFormInputs();

            MessageBox.Show($"Đã thêm mới khách hàng '{newCustomer.FullName}' (Hạng: {newCustomer.CustomerTier}) thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật từ danh sách!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var customer = mockCustomerList.FirstOrDefault(c => c.CustomerId == selectedCustomerId);
            if (customer != null)
            {
                customer.FullName = txtFullName.Text.Trim();
                customer.PhoneNumber = txtPhoneNumber.Text.Trim();
                customer.Email = txtEmail.Text.Trim();
                customer.Address = txtAddress.Text.Trim();
                customer.RewardPoints = (int)numRewardPoints.Value;

                LoadCustomerDataGrid();
                ClearFormInputs();
                MessageBox.Show("Đã cập nhật thông tin khách hàng thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var customer = mockCustomerList.FirstOrDefault(c => c.CustomerId == selectedCustomerId);
            if (customer != null)
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa khách hàng '{customer.FullName}' khỏi hệ thống?",
                    "Xác Nhận Xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    mockCustomerList.Remove(customer);
                    LoadCustomerDataGrid();
                    ClearFormInputs();
                    MessageBox.Show("Đã xóa khách hàng thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAddPoints_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để cộng điểm thưởng mua giày!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var customer = mockCustomerList.FirstOrDefault(c => c.CustomerId == selectedCustomerId);
            if (customer != null)
            {
                customer.RewardPoints += 50;
                numRewardPoints.Value = customer.RewardPoints;

                LoadCustomerDataGrid();
                MessageBox.Show($"Đã tích lũy thêm +50 điểm cho khách hàng '{customer.FullName}'.\n\nTổng điểm hiện tại: {customer.RewardPoints} Đ (Hạng: {customer.CustomerTier})", 
                                "Tích Điểm Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFormInputs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            var filtered = mockCustomerList.Where(c =>
                string.IsNullOrEmpty(keyword) ||
                c.FullName.ToLower().Contains(keyword) ||
                c.PhoneNumber.Contains(keyword)
            ).ToList();

            LoadCustomerDataGrid(filtered);
        }

        private void ClearFormInputs()
        {
            selectedCustomerId = -1;
            txtFullName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            numRewardPoints.Value = 0;
        }
    }
}
