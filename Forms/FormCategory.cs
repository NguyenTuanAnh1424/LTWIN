using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LTWIN.Models;
using LTWIN.Utils;

namespace LTWIN.Forms
{
    public partial class FormCategory : Form
    {
        private int selectedCategoryId = -1;

        public FormCategory()
        {
            InitializeComponent();
        }

        // 1. SỰ KIỆN KHI FORM MỞ LÊN -> TẢI DỮ LIỆU TỪ SQL SERVER
        private void FormCategory_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvCategories);
            LoadCategoryDataGrid();
        }

        // HÀM TẢI VÀ HÀM TÌM KIẾM DỮ LIỆU TRỰC TIẾP TỪ SQL SERVER
        private void LoadCategoryDataGrid()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            using (var db = new QlyBanGiayContext())
            {
                var query = db.Categories.AsQueryable();

                // Lọc theo từ khóa nếu người dùng có nhập vào ô Tìm kiếm
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(c => c.Name.ToLower().Contains(keyword) ||
                                             (c.Description != null && c.Description.ToLower().Contains(keyword)));
                }

                var displayData = query.Select(c => new
                {
                    Mã_Danh_Mục = c.CategoryId,
                    Tên_Danh_Mục = c.Name,
                    Mô_Tả = c.Description
                }).ToList();

                dgvCategories.DataSource = displayData;
            }
        }

        // 2. CLICK VÀO DÒNG TRONG BANG -> LẤY DỮ LIỆU LÊN Ô INPUT
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCategories.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedCategoryId = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["Mã_Danh_Mục"].Value);

                using (var db = new QlyBanGiayContext())
                {
                    var category = db.Categories.FirstOrDefault(c => c.CategoryId == selectedCategoryId);
                    if (category != null)
                    {
                        txtCategoryName.Text = category.Name;
                        txtDescription.Text = category.Description;
                    }
                }
            }
        }

        // 3. THÊM DANH MỤC MỚI VÀO SQL SERVER
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                // Kiểm tra trùng tên danh mục
                bool isExist = db.Categories.Any(c => c.Name.ToLower() == txtCategoryName.Text.Trim().ToLower());
                if (isExist)
                {
                    MessageBox.Show("Tên danh mục này đã tồn tại trong CSDL!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newCategory = new Category
                {
                    Name = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                // Lưu xuống CSDL SQL Server
                db.Categories.Add(newCategory);
                db.SaveChanges();

                LoadCategoryDataGrid();
                ClearInputs();

                MessageBox.Show($"Đã thêm danh mục '{newCategory.Name}' vào SQL Server thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 4. CẬP NHẬT/SỬA DANH MỤC TRONG SQL SERVER
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId <= 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên danh mục không được để trống!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.CategoryId == selectedCategoryId);
                if (category != null)
                {
                    category.Name = txtCategoryName.Text.Trim();
                    category.Description = txtDescription.Text.Trim();

                    // Cập nhật xuống CSDL SQL Server
                    db.SaveChanges();

                    LoadCategoryDataGrid();
                    ClearInputs();
                    MessageBox.Show("Đã cập nhật danh mục thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // 5. XÓA DANH MỤC KHỎI SQL SERVER
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId <= 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.CategoryId == selectedCategoryId);
                if (category != null)
                {
                    // Ràng buộc dữ liệu: Tránh xóa danh mục đang chứa sản phẩm
                    bool hasProducts = db.Products.Any(p => p.CategoryId == selectedCategoryId);
                    if (hasProducts)
                    {
                        MessageBox.Show("Không thể xóa danh mục này vì đang có mẫu giày thuộc danh mục!\n\nVui lòng xóa các mẫu giày đó trước.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var confirm = MessageBox.Show($"Bạn có chắc muốn xóa danh mục '{category.Name}' khỏi SQL Server?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        db.Categories.Remove(category);
                        db.SaveChanges(); // Xóa hẳn khỏi SQL Server

                        LoadCategoryDataGrid();
                        ClearInputs();
                        MessageBox.Show("Đã xóa danh mục khỏi CSDL thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // 6. TÌM KIẾM DANH MỤC
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCategoryDataGrid();
        }

        // 7. LÀM MỚI FORM (RESET)
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            selectedCategoryId = -1;
            txtCategoryName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtSearch.Text = string.Empty;
            txtCategoryName.Focus();
        }
    }
}