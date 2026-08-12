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
    /// Tích hợp trực tiếp CSDL SQL Server (QlyBanGiayContext) cho toàn bộ thao tác CRUD và Quản lý Ảnh.
    /// </summary>
    public partial class FormProduct : Form
    {
        private int selectedProductId = -1;
        private string selectedImagePath = string.Empty;

        public FormProduct()
        {
            InitializeComponent();
        }

        // 1. SỰ KIỆN FORM LOAD -> TẢI DỮ LIỆU TỪ SQL SERVER
        private void FormProduct_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvProducts);
            LoadCategoryComboBoxes();
            LoadProductDataGrid();
        }

        // TẢI DANH MỤC TỪ SQL SERVER VÀO CÁC COMBOBOX
        private void LoadCategoryComboBoxes()
        {
            cmbCategoryFilter.SelectedIndexChanged -= cmbCategoryFilter_SelectedIndexChanged;

            using (var db = new QlyBanGiayContext())
            {
                var categoryList = db.Categories.ToList();

                // ComboBox chọn danh mục khi thêm/sửa sản phẩm
                cmbCategory.DataSource = new List<Category>(categoryList);
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "CategoryId";

                // ComboBox lọc danh mục trên thanh tìm kiếm
                var filterList = new List<Category> { new Category { CategoryId = 0, Name = "-- Tất cả danh mục --" } };
                filterList.AddRange(categoryList);

                cmbCategoryFilter.DataSource = filterList;
                cmbCategoryFilter.DisplayMember = "Name";
                cmbCategoryFilter.ValueMember = "CategoryId";
            }

            cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
        }

        // TẢI DANH SÁCH SẢN PHẨM TỪ SQL SERVER LÊN DATAGRIDVIEW
        private void LoadProductDataGrid(List<Product> listToDisplay = null)
        {
            using (var db = new QlyBanGiayContext())
            {
                List<Product> sourceList = listToDisplay ?? db.Products.ToList();

                var categories = db.Categories.ToDictionary(c => c.CategoryId, c => c.Name);

                var displayData = sourceList.Select(p => new
                {
                    Mã_Giày = p.ProductId,
                    Tên_Mẫu_Giày = p.Name,
                    Danh_Mục = (p.CategoryId.HasValue && categories.ContainsKey(p.CategoryId.Value)) ? categories[p.CategoryId.Value] : "Khác",
                    Giá_Bán = p.Price.ToString("N0") + " VNĐ",
                    Số_Lượng_Tồn = p.StockQuantity,
                    Hình_Ảnh = string.IsNullOrEmpty(p.ImageUrl) ? "Chưa có ảnh" : Path.GetFileName(p.ImageUrl),
                    Mô_Tả = p.Description
                }).ToList();

                dgvProducts.DataSource = displayData;

                // Gán lại tên hiển thị tiếng Việt có dấu hoàn chỉnh cho các cột trên DataGridView
                if (dgvProducts.Columns.Contains("Mã_Giày")) dgvProducts.Columns["Mã_Giày"].HeaderText = "Mã Giày";
                if (dgvProducts.Columns.Contains("Tên_Mẫu_Giày")) dgvProducts.Columns["Tên_Mẫu_Giày"].HeaderText = "Tên Mẫu Giày";
                if (dgvProducts.Columns.Contains("Danh_Mục")) dgvProducts.Columns["Danh_Mục"].HeaderText = "Danh Mục";
                if (dgvProducts.Columns.Contains("Giá_Bán")) dgvProducts.Columns["Giá_Bán"].HeaderText = "Giá Bán";
                if (dgvProducts.Columns.Contains("Số_Lượng_Tồn")) dgvProducts.Columns["Số_Lượng_Tồn"].HeaderText = "Số Lượng Tồn";
                if (dgvProducts.Columns.Contains("Hình_Ảnh")) dgvProducts.Columns["Hình_Ảnh"].HeaderText = "Hình Ảnh";
                if (dgvProducts.Columns.Contains("Mô_Tả")) dgvProducts.Columns["Mô_Tả"].HeaderText = "Mô Tả";
            }
        }

        // 2. CHỌN VÀ HIỂN THỊ XEM TRƯỚC HÌNH ẢNH
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn Hình Ảnh Sản Phẩm Giày";
                dialog.Filter = "File Hình Ảnh (*.jpg; *.jpeg; *.png; *.bmp; *.webp)|*.jpg;*.jpeg;*.png;*.bmp;*.webp|All Files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = dialog.FileName;
                    DisplayImagePreview(selectedImagePath);
                    picProductImage.Tag = dialog.FileName;
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
                        picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    ClearPicturePreview();
                }
            }
            catch (Exception ex)
            {
                ClearPicturePreview();
                Console.WriteLine("Lỗi đọc ảnh: " + ex.Message);
            }
        }

        private void ClearPicturePreview()
        {
            if (picProductImage.Image != null)
            {
                picProductImage.Image.Dispose();
                picProductImage.Image = null;
            }
        }

        // 3. CLICK DÒNG TRÊN BẢNG -> HIỂN THỊ DỮ LIỆU LÊN FORM
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedProductId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["Mã_Giày"].Value);

                using (var db = new QlyBanGiayContext())
                {
                    var product = db.Products.FirstOrDefault(p => p.ProductId == selectedProductId);
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
        }

        // 4. THÊM SẢN PHẨM MỚI VÀO SQL SERVER
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên mẫu giày!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                int catId = (cmbCategory.SelectedItem as Category)?.CategoryId ?? 0;

                var newProduct = new Product
                {
                    Name = txtName.Text.Trim(),
                    CategoryId = catId > 0 ? catId : (int?)null,
                    Price = numPrice.Value,
                    StockQuantity = (int)numStock.Value,
                    Description = txtDescription.Text.Trim(),
                    ImageUrl = selectedImagePath
                };

                db.Products.Add(newProduct);
                db.SaveChanges(); // LƯU VÀO CSDL SQL SERVER

                LoadProductDataGrid();
                ClearFormInputs();

                MessageBox.Show($"Đã thêm mới mẫu giày '{newProduct.Name}' vào SQL Server thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 5. CẬP NHẬT SẢN PHẨM TRONG SQL SERVER
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedProductId <= 0)
            {
                MessageBox.Show("Vui lòng chọn mẫu giày cần cập nhật từ bảng dữ liệu!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên mẫu giày không được để trống!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                var product = db.Products.FirstOrDefault(p => p.ProductId == selectedProductId);
                if (product != null)
                {
                    int catId = (cmbCategory.SelectedItem as Category)?.CategoryId ?? 0;

                    product.Name = txtName.Text.Trim();
                    product.CategoryId = catId > 0 ? catId : (int?)null;
                    product.Price = numPrice.Value;
                    product.StockQuantity = (int)numStock.Value;
                    product.Description = txtDescription.Text.Trim();

                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        product.ImageUrl = selectedImagePath;
                    }

                    db.SaveChanges(); // CẬP NHẬT CSDL SQL SERVER

                    LoadProductDataGrid();
                    ClearFormInputs();

                    MessageBox.Show("Đã cập nhật thông tin và hình ảnh mẫu giày vào SQL Server thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm này trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 6. XÓA SẢN PHẨM KHỎI SQL SERVER
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductId <= 0)
            {
                MessageBox.Show("Vui lòng chọn mẫu giày cần xóa!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                var product = db.Products.FirstOrDefault(p => p.ProductId == selectedProductId);
                if (product != null)
                {
                    // Ràng buộc: Kiểm tra xem sản phẩm đã từng phát sinh hóa đơn bán hàng chưa
                    bool hasOrders = db.OrderDetails.Any(od => od.ProductId == selectedProductId);
                    if (hasOrders)
                    {
                        MessageBox.Show("Không thể xóa mẫu giày này vì đã có lịch sử hóa đơn bán hàng!\nBạn có thể giảm Số Lượng Tồn về 0 để ngưng bán.",
                                        "Lỗi Ràng Buộc Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var confirm = MessageBox.Show(
                        $"Bạn có chắc muốn xóa mẫu giày '{product.Name}' khỏi CSDL SQL Server?",
                        "Xác Nhận Xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        db.Products.Remove(product);
                        db.SaveChanges(); // XÓA KHỎI CSDL

                        LoadProductDataGrid();
                        ClearFormInputs();

                        MessageBox.Show("Đã xóa mẫu giày khỏi SQL Server thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // 7. TÌM KIẾM VÀ LỌC SẢN PHẨM
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
            int selectedCatId = (cmbCategoryFilter.SelectedItem as Category)?.CategoryId ?? 0;

            using (var db = new QlyBanGiayContext())
            {
                var query = db.Products.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(p => p.Name.ToLower().Contains(keyword));
                }

                if (selectedCatId > 0)
                {
                    query = query.Where(p => p.CategoryId == selectedCatId);
                }

                LoadProductDataGrid(query.ToList());
            }
        }

        // 8. LÀM MỚI FORM (RESET)
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFormInputs();
        }

        private void ClearFormInputs()
        {
            selectedProductId = -1;
            selectedImagePath = string.Empty;

            ClearPicturePreview();

            txtName.Text = string.Empty;
            numPrice.Value = 0;
            numStock.Value = 0;
            txtDescription.Text = string.Empty;
            txtSearch.Text = string.Empty;

            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            txtName.Focus();
        }

        private void lblImageTitle_Click(object sender, EventArgs e)
        {

        }
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0 && dgvProducts.Columns.Contains("Hình_Ảnh"))
            {
                var cellValue = dgvProducts.SelectedRows[0].Cells["Hình_Ảnh"].Value;
                string imagePath = cellValue != null ? cellValue.ToString() : "";

                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    picProductImage.ImageLocation = imagePath;
                    picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    if (picProductImage.Image != null)
                    {
                        picProductImage.Image.Dispose();
                        picProductImage.Image = null;
                    }
                }
            }
        }
    }
}