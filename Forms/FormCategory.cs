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
        private List<Category> categoryList;

        public FormCategory()
        {
            InitializeComponent();
            InitMockCategories();
        }

        private void InitMockCategories()
        {
            categoryList = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Giày Sneaker", Description = "Giày thời trang năng động hàng ngày." },
                new Category { CategoryId = 2, Name = "Giày Chạy Bộ (Running)", Description = "Đế êm hỗ trợ tập luyện thể thao chuyên nghiệp." },
                new Category { CategoryId = 3, Name = "Giày Bóng Rổ (Basketball)", Description = "Cổ cao bảo vệ cổ chân, bám sàn cực tốt." },
                new Category { CategoryId = 4, Name = "Giày Thể Thao Casual", Description = "Phong cách trẻ trung dạo phố." }
            };
        }

        private void FormCategory_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvCategories);
            LoadCategoryDataGrid();
        }

        private void LoadCategoryDataGrid(List<Category> listToDisplay = null)
        {
            var sourceList = listToDisplay ?? categoryList;

            var displayData = sourceList.Select(c => new
            {
                Mã_Danh_Mục = c.CategoryId,
                Tên_Danh_Mục = c.Name,
                Mô_Tả = c.Description
            }).ToList();

            dgvCategories.DataSource = displayData;
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCategories.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedCategoryId = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["Mã_Danh_Mục"].Value);
                var category = categoryList.FirstOrDefault(c => c.CategoryId == selectedCategoryId);

                if (category != null)
                {
                    txtCategoryName.Text = category.Name;
                    txtDescription.Text = category.Description;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newId = categoryList.Any() ? categoryList.Max(c => c.CategoryId) + 1 : 1;

            var newCategory = new Category
            {
                CategoryId = newId,
                Name = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            categoryList.Add(newCategory);
            LoadCategoryDataGrid();
            ClearInputs();

            MessageBox.Show($"Đã thêm danh mục '{newCategory.Name}' thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId <= 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var category = categoryList.FirstOrDefault(c => c.CategoryId == selectedCategoryId);
            if (category != null)
            {
                category.Name = txtCategoryName.Text.Trim();
                category.Description = txtDescription.Text.Trim();

                LoadCategoryDataGrid();
                ClearInputs();
                MessageBox.Show("Đã cập nhật danh mục thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId <= 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var category = categoryList.FirstOrDefault(c => c.CategoryId == selectedCategoryId);
            if (category != null)
            {
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa danh mục '{category.Name}'?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    categoryList.Remove(category);
                    LoadCategoryDataGrid();
                    ClearInputs();
                    MessageBox.Show("Đã xóa danh mục thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            var filtered = categoryList.Where(c => string.IsNullOrEmpty(keyword) || c.Name.ToLower().Contains(keyword)).ToList();
            LoadCategoryDataGrid(filtered);
        }

        private void ClearInputs()
        {
            selectedCategoryId = -1;
            txtCategoryName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}
