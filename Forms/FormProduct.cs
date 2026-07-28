using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LTWIN.Models;

using LTWIN.Utils;

namespace LTWIN.Forms
{
    /// <summary>
    /// MÀN HÌNH QUẢN LÝ SẢN PHẨM GIÀY (FORMPRODUCT.CS)
    /// Cung cấp các chức năng CRUD (Xem, Thêm, Sửa, Xóa, Tìm kiếm) và Xử lý Chọn/Hiển thị Ảnh sản phẩm.
    /// </summary>
    public partial class FormProduct : Form
    {
        private int selectedProductId = -1;
        private string selectedImagePath = string.Empty;

        private List<Product> mockProductList;
        private List<Category> mockCategoryList;

        public FormProduct()
        {
            InitializeComponent();
            InitMockData();
        }

        private void InitMockData()
        {
            mockCategoryList = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Giày Sneaker" },
                new Category { CategoryId = 2, Name = "Giày Chạy Bộ (Running)" },
                new Category { CategoryId = 3, Name = "Giày Bóng Rổ (Basketball)" },
                new Category { CategoryId = 4, Name = "Giày Thể Thao Casual" }
            };

            mockProductList = new List<Product>
            {
                new Product { ProductId = 1, CategoryId = 1, Name = "Nike Air Max 270 React", Price = 3200000, StockQuantity = 15, Description = "Đế đệm khí Air Max cao cấp êm ái.", Category = mockCategoryList[0], ImageUrl = "" },
                new Product { ProductId = 2, CategoryId = 2, Name = "Adidas Ultraboost 22", Price = 3850000, StockQuantity = 8, Description = "Đế Boost hoàn trả năng lượng tối đa.", Category = mockCategoryList[1], ImageUrl = "" },
                new Product { ProductId = 3, CategoryId = 3, Name = "Air Jordan 1 Retro High", Price = 4500000, StockQuantity = 5, Description = "Phối màu Classic chuẩn bóng rổ huyền thoại.", Category = mockCategoryList[2], ImageUrl = "" },
                new Product { ProductId = 4, CategoryId = 4, Name = "Puma RS-X Reinvent", Price = 2490000, StockQuantity = 20, Description = "Phong cách Retro cá tính.", Category = mockCategoryList[3], ImageUrl = "" }
            };
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvProducts);
            LoadCategoryComboBoxes();
            LoadProductDataGrid();
        }

        private void LoadCategoryComboBoxes()
        {
            cmbCategoryFilter.SelectedIndexChanged -= cmbCategoryFilter_SelectedIndexChanged;

            cmbCategory.DataSource = new List<Category>(mockCategoryList);
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryId";

            var filterList = new List<Category> { new Category { CategoryId = 0, Name = "-- Tất cả danh mục --" } };
            filterList.AddRange(mockCategoryList);
            cmbCategoryFilter.DataSource = filterList;
            cmbCategoryFilter.DisplayMember = "Name";
            cmbCategoryFilter.ValueMember = "CategoryId";

            cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
        }

        private void LoadProductDataGrid(List<Product> listToDisplay = null)
        {
            var sourceList = listToDisplay ?? mockProductList;

            var displayData = sourceList.Select(p => new
            {
                Mã_Giày = p.ProductId,
                Tên_Mẫu_Giày = p.Name,
                Danh_Mục = p.Category != null ? p.Category.Name : "Khác",
                Giá_Bán = p.Price.ToString("N0") + " VNĐ",
                Số_Lượng_Tồn = p.StockQuantity,
                Hình_Ảnh = string.IsNullOrEmpty(p.ImageUrl) ? "Chưa có ảnh" : Path.GetFileName(p.ImageUrl),
                Mô_Tả = p.Description
            }).ToList();

            dgvProducts.DataSource = displayData;
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn Hình Ảnh Sản Phẩm Giày";
                dialog.Filter = "File Hình Ảnh (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = dialog.FileName;
                    DisplayImagePreview(selectedImagePath);
                }
            }
        }

        private void DisplayImagePreview(string imagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    byte[] bytes = File.ReadAllBytes(imagePath);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        if (picProductImage.Image != null)
                        {
                            picProductImage.Image.Dispose();
                        }
                        picProductImage.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    if (picProductImage.Image != null)
                    {
                        picProductImage.Image.Dispose();
                    }
                    picProductImage.Image = null;
                }
            }
            catch (Exception ex)
            {
                picProductImage.Image = null;
                Console.WriteLine("Lỗi đọc ảnh: " + ex.Message);
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedProductId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["Mã_Giày"].Value);
                var product = mockProductList.FirstOrDefault(p => p.ProductId == selectedProductId);

                if (product != null)
                {
                    txtName.Text = product.Name;
                    numPrice.Value = product.Price;
                    numStock.Value = product.StockQuantity;
                    txtDescription.Text = product.Description;
                    selectedImagePath = product.ImageUrl ?? string.Empty;

                    DisplayImagePreview(selectedImagePath);

                    if (product.CategoryId.HasValue)
                    {
                        cmbCategory.SelectedValue = product.CategoryId.Value;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên mẫu giày!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newId = mockProductList.Any() ? mockProductList.Max(p => p.ProductId) + 1 : 1;
            int catId = (cmbCategory.SelectedItem as Category)?.CategoryId ?? 0;
            var category = mockCategoryList.FirstOrDefault(c => c.CategoryId == catId);

            var newProduct = new Product
            {
                ProductId = newId,
                Name = txtName.Text.Trim(),
                CategoryId = catId,
                Category = category,
                Price = numPrice.Value,
                StockQuantity = (int)numStock.Value,
                Description = txtDescription.Text.Trim(),
                ImageUrl = selectedImagePath
            };

            mockProductList.Add(newProduct);
            LoadProductDataGrid();
            ClearFormInputs();

            MessageBox.Show($"Đã thêm mới mẫu giày '{newProduct.Name}' kèm hình ảnh thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedProductId <= 0)
            {
                MessageBox.Show("Vui lòng chọn mẫu giày cần cập nhật từ bảng dữ liệu!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = mockProductList.FirstOrDefault(p => p.ProductId == selectedProductId);
            if (product != null)
            {
                int catId = (cmbCategory.SelectedItem as Category)?.CategoryId ?? 0;
                product.Name = txtName.Text.Trim();
                product.CategoryId = catId;
                product.Category = mockCategoryList.FirstOrDefault(c => c.CategoryId == catId);
                product.Price = numPrice.Value;
                product.StockQuantity = (int)numStock.Value;
                product.Description = txtDescription.Text.Trim();
                product.ImageUrl = selectedImagePath;

                LoadProductDataGrid();
                ClearFormInputs();
                MessageBox.Show($"Đã cập nhật thông tin và hình ảnh mẫu giày thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductId <= 0)
            {
                MessageBox.Show("Vui lòng chọn mẫu giày cần xóa!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = mockProductList.FirstOrDefault(p => p.ProductId == selectedProductId);
            if (product != null)
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa mẫu giày '{product.Name}' khỏi danh sách?",
                    "Xác Nhận Xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    mockProductList.Remove(product);
                    LoadProductDataGrid();
                    ClearFormInputs();
                    MessageBox.Show("Đã xóa mẫu giày thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFormInputs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void FilterProducts()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            int selectedCatId = 0;

            if (cmbCategoryFilter.SelectedItem is Category selectedCategory)
            {
                selectedCatId = selectedCategory.CategoryId;
            }
            else if (cmbCategoryFilter.SelectedValue != null && int.TryParse(cmbCategoryFilter.SelectedValue.ToString(), out int parsedId))
            {
                selectedCatId = parsedId;
            }

            var filtered = mockProductList.Where(p =>
                (string.IsNullOrEmpty(keyword) || p.Name.ToLower().Contains(keyword)) &&
                (selectedCatId == 0 || p.CategoryId == selectedCatId)
            ).ToList();

            LoadProductDataGrid(filtered);
        }

        private void ClearFormInputs()
        {
            selectedProductId = -1;
            selectedImagePath = string.Empty;

            if (picProductImage.Image != null)
            {
                picProductImage.Image.Dispose();
                picProductImage.Image = null;
            }

            txtName.Text = string.Empty;
            numPrice.Value = 0;
            numStock.Value = 0;
            txtDescription.Text = string.Empty;
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
        }
    }
}
