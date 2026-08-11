using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LTWIN.Models;
using LTWIN.Services;
using LTWIN.Utils;

namespace LTWIN.Forms
{
    public partial class FormPOS : Form
    {
        public class POSCartItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; } = null!;
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice => UnitPrice * Quantity;
        }

        private List<Product> mockProductList;
        private List<Category> mockCategoryList;
        private List<Customer> mockCustomerList;
        private List<POSCartItem> posCartItems;

        public FormPOS()
        {
            InitializeComponent();
            posCartItems = new List<POSCartItem>();
            InitMockPOSData();
        }

        private void InitMockPOSData()
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
                new Product { ProductId = 1, CategoryId = 1, Name = "Nike Air Max 270 React", Price = 3200000, StockQuantity = 15, Category = mockCategoryList[0] },
                new Product { ProductId = 2, CategoryId = 2, Name = "Adidas Ultraboost 22", Price = 3850000, StockQuantity = 8, Category = mockCategoryList[1] },
                new Product { ProductId = 3, CategoryId = 3, Name = "Air Jordan 1 Retro High", Price = 4500000, StockQuantity = 5, Category = mockCategoryList[2] },
                new Product { ProductId = 4, CategoryId = 4, Name = "Puma RS-X Reinvent", Price = 2490000, StockQuantity = 20, Category = mockCategoryList[3] }
            };

            mockCustomerList = new List<Customer>
            {
                new Customer { CustomerId = 0, FullName = "Khách Lẻ (Không Tích Điểm)", PhoneNumber = "" },
                new Customer { CustomerId = 1, FullName = "Nguyễn Văn Hoàng (0988123456)", PhoneNumber = "0988123456", RewardPoints = 350 },
                new Customer { CustomerId = 2, FullName = "Trần Thị Thu (0912345678)", PhoneNumber = "0912345678", RewardPoints = 120 },
                new Customer { CustomerId = 3, FullName = "Phạm Minh Đức (0977888999)", PhoneNumber = "0977888999", RewardPoints = 550 }
            };
        }

        private void FormPOS_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvShoesList);
            ThemeHelper.StyleDataGridView(dgvCartList);
            LoadCategoryComboBox();
            LoadCustomerComboBox();
            LoadShoeGrid();
            InitCartGridColumns();
            UpdatePOSCalculations();
        }

        private void LoadCategoryComboBox()
        {
            cmbCategoryFilter.SelectedIndexChanged -= cmbCategoryFilter_SelectedIndexChanged;

            var filterList = new List<Category> { new Category { CategoryId = 0, Name = "-- Tất cả danh mục --" } };
            filterList.AddRange(mockCategoryList);

            cmbCategoryFilter.DataSource = filterList;
            cmbCategoryFilter.DisplayMember = "Name";
            cmbCategoryFilter.ValueMember = "CategoryId";

            cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
        }

        private void LoadCustomerComboBox()
        {
            cmbCustomer.DataSource = mockCustomerList;
            cmbCustomer.DisplayMember = "FullName";
            cmbCustomer.ValueMember = "CustomerId";
        }

        private void LoadShoeGrid(List<Product> listToDisplay = null)
        {
            dgvShoesList.Columns.Clear();
            var sourceList = listToDisplay ?? mockProductList;

            var displayData = sourceList.Select(p => new
            {
                Mã_SP = p.ProductId,
                Tên_Mẫu_Giày = p.Name,
                Giá_Bán = p.Price.ToString("N0") + " VNĐ",
                Tồn_Kho = p.StockQuantity
            }).ToList();

            dgvShoesList.DataSource = displayData;

            DataGridViewButtonColumn btnSelectCol = new DataGridViewButtonColumn();
            btnSelectCol.Name = "colSelect";
            btnSelectCol.HeaderText = "Thao Tác";
            btnSelectCol.Text = "➕ Chọn";
            btnSelectCol.UseColumnTextForButtonValue = true;
            btnSelectCol.FlatStyle = FlatStyle.Flat;
            dgvShoesList.Columns.Add(btnSelectCol);
        }

        private void InitCartGridColumns()
        {
            dgvCartList.Columns.Clear();
            UpdateCartGrid();
        }

        private void dgvShoesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvShoesList.Columns["colSelect"].Index)
            {
                int productId = Convert.ToInt32(dgvShoesList.Rows[e.RowIndex].Cells["Mã_SP"].Value);
                var shoe = mockProductList.FirstOrDefault(p => p.ProductId == productId);

                if (shoe != null)
                {
                    AddShoeToCart(shoe);
                }
            }
        }

        private void AddShoeToCart(Product shoe)
        {
            var existingItem = posCartItems.FirstOrDefault(i => i.ProductId == shoe.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                posCartItems.Add(new POSCartItem
                {
                    ProductId = shoe.ProductId,
                    ProductName = shoe.Name,
                    UnitPrice = shoe.Price,
                    Quantity = 1
                });
            }

            UpdateCartGrid();
            UpdatePOSCalculations();
        }

        private void UpdateCartGrid()
        {
            dgvCartList.Columns.Clear();

            var displayCart = posCartItems.Select(i => new
            {
                Mã_SP = i.ProductId,
                Tên_Mẫu_Giày = i.ProductName,
                Đơn_Giá = i.UnitPrice.ToString("N0") + " VNĐ",
                Số_Lượng = i.Quantity,
                Thành_Tiền = i.TotalPrice.ToString("N0") + " VNĐ"
            }).ToList();

            dgvCartList.DataSource = displayCart;

            DataGridViewButtonColumn btnRemoveCol = new DataGridViewButtonColumn();
            btnRemoveCol.Name = "colRemove";
            btnRemoveCol.HeaderText = "Xóa";
            btnRemoveCol.Text = "🗑️ Xóa";
            btnRemoveCol.UseColumnTextForButtonValue = true;
            btnRemoveCol.FlatStyle = FlatStyle.Flat;
            dgvCartList.Columns.Add(btnRemoveCol);
        }

        private void dgvCartList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCartList.Columns.Contains("colRemove") && e.ColumnIndex == dgvCartList.Columns["colRemove"].Index)
            {
                int productId = Convert.ToInt32(dgvCartList.Rows[e.RowIndex].Cells["Mã_SP"].Value);
                var itemToRemove = posCartItems.FirstOrDefault(i => i.ProductId == productId);

                if (itemToRemove != null)
                {
                    posCartItems.Remove(itemToRemove);
                    UpdateCartGrid();
                    UpdatePOSCalculations();
                }
            }
        }
        private void CalculateTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvCartList.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }
            lblSubTotal.Text = total.ToString("N0") + " VNĐ";
            lblGrandTotal.Text = total.ToString("N0") + " VNĐ";
        }

        private void UpdatePOSCalculations()
        {
            decimal subTotal = posCartItems.Sum(i => i.TotalPrice);
            decimal discount = numDiscount.Value;
            decimal grandTotal = Math.Max(0, subTotal - discount);
            decimal customerMoney = numCustomerMoney.Value;
            decimal changeMoney = Math.Max(0, customerMoney - grandTotal);

            lblSubTotal.Text = subTotal.ToString("N0") + " VNĐ";
            lblGrandTotal.Text = grandTotal.ToString("N0") + " VNĐ";
            lblChangeMoney.Text = changeMoney.ToString("N0") + " VNĐ";
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            UpdatePOSCalculations();
        }

        private void numCustomerMoney_ValueChanged(object sender, EventArgs e)
        {
            UpdatePOSCalculations();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (posCartItems.Any())
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa tất cả sản phẩm khỏi giỏ hàng?", "Xác Nhận Hủy Giỏ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    posCartItems.Clear();
                    UpdateCartGrid();
                    UpdatePOSCalculations();
                }
            }
        }


        private void btnSearchShoe_Click(object sender, EventArgs e)
        {
            FilterShoes();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterShoes();
        }

        private void FilterShoes()
        {
            string keyword = txtSearchShoe.Text.Trim().ToLower();
            int catId = (cmbCategoryFilter.SelectedItem as Category)?.CategoryId ?? 0;

            var filtered = mockProductList.Where(p =>
                (string.IsNullOrEmpty(keyword) || p.Name.ToLower().Contains(keyword)) &&
                (catId == 0 || p.CategoryId == catId)
            ).ToList();

            LoadShoeGrid(filtered);
        }

        private void dgvShoesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin đôi giày vừa click
                DataGridViewRow row = dgvShoesList.Rows[e.RowIndex];
                string productId = row.Cells["ProductId"].Value.ToString();
                string productName = row.Cells["ProductName"].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                // 1. Kiểm tra xem giày này đã có trong giỏ hàng (dgvCartList) chưa
                bool isExists = false;
                foreach (DataGridViewRow cartRow in dgvCartList.Rows)
                {
                    if (cartRow.Cells["ProductId"].Value != null && cartRow.Cells["ProductId"].Value.ToString() == productId)
                    {
                        // Nếu có rồi thì cộng thêm 1 vào số lượng
                        int currentQuantity = Convert.ToInt32(cartRow.Cells["Quantity"].Value);
                        cartRow.Cells["Quantity"].Value = currentQuantity + 1;
                        cartRow.Cells["Total"].Value = (currentQuantity + 1) * price;
                        isExists = true;
                        break;
                    }
                }

                // 2. Nếu chưa có thì tạo một dòng mới trong giỏ hàng
                if (!isExists)
                {
                    dgvCartList.Rows.Add(productId, productName, 1, price, price);
                }

                // 3. Tính lại tổng tiền sau khi thêm
                CalculateTotal();
            }
        }

        private void btnCompletePayment_Click(object sender, EventArgs e)
        {
            if (!posCartItems.Any())
            {
                MessageBox.Show("Giỏ hàng hiện tại đang rỗng! Vui lòng chọn sản phẩm giày.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subTotal = posCartItems.Sum(i => i.TotalPrice);
            decimal discount = numDiscount.Value;
            decimal grandTotal = Math.Max(0, subTotal - discount);
            decimal customerMoney = numCustomerMoney.Value;

            // SỬA LỖI 1: Chỉ cần kiểm tra tiền khách đưa nhỏ hơn tổng tiền là chặn luôn
            if (customerMoney < grandTotal)
            {
                MessageBox.Show($"Số tiền khách đưa ({customerMoney:N0} VNĐ) còn thiếu {(grandTotal - customerMoney):N0} VNĐ!", "Cảnh Báo Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kết nối Database thật để lưu
            using (var db = new QlyBanGiayContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        User selectedCustomer = cmbCustomer.SelectedItem as User;
                        int customerId = selectedCustomer != null ? selectedCustomer.UserId : 1;
                        string customerName = selectedCustomer != null ? selectedCustomer.FullName : "Khách Lẻ";

                        string invoiceCode = "POS" + DateTime.Now.ToString("yyyyMMddHHmmss");

                        // Tính điểm thưởng (100k = 1 điểm)
                        int earnedPoints = (int)(grandTotal / 100000);
                        if (customerId > 0 && earnedPoints > 0)
                        {
                            // Cập nhật điểm cho User trong DB thật
                            var dbUser = db.Users.Find(customerId);
                            if (dbUser != null)
                            {
                                dbUser.RewardPoints += earnedPoints;
                            }
                        }

                        // Lưu Hóa Đơn vào DB thật
                        var newOrder = new Order
                        {
                            OrderDate = DateTime.Now,
                            TotalAmount = grandTotal,
                            UserId = customerId
                            // Nếu DB của bạn có thêm cột Discount hay InvoiceCode thì map vào đây
                        };
                        db.Orders.Add(newOrder);
                        db.SaveChanges(); // Lấy OrderId

                        // Chuẩn bị chuỗi in hóa đơn
                        string invoiceContent = $"========================================\n" +
                                                $"       HÓA ĐƠN BÁN HÀNG SNEAKER STORE   \n" +
                                                $"========================================\n" +
                                                $"Mã Hóa Đơn : {invoiceCode}\n" +
                                                $"Thời gian  : {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                                                $"Khách hàng : {customerName}\n" +
                                                $"----------------------------------------\n";

                        // Lưu Chi tiết Hóa Đơn & Trừ tồn kho
                        foreach (var item in posCartItems)
                        {
                            // Lấy sản phẩm từ DB để trừ tồn kho
                            var dbShoe = db.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                            if (dbShoe != null)
                            {
                                if (dbShoe.StockQuantity < item.Quantity) throw new Exception($"Giày {dbShoe.Name} không đủ hàng!");
                                dbShoe.StockQuantity -= item.Quantity; // Trừ tồn kho
                            }

                            // Lưu vào bảng OrderDetails
                            db.OrderDetails.Add(new OrderDetail
                            {
                                OrderId = newOrder.OrderId,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity,
                                UnitPrice = item.UnitPrice
                            });

                            // Cộng chuỗi in
                            invoiceContent += $"• {item.ProductName}\n" +
                                              $"  Đơn giá: {item.UnitPrice:N0} VNĐ x {item.Quantity} = {item.TotalPrice:N0} VNĐ\n";
                        }

                        db.SaveChanges(); // Lưu tất cả thay đổi
                        transaction.Commit(); // Chốt giao dịch an toàn

                        // Hoàn thiện chuỗi in hóa đơn
                        invoiceContent += $"----------------------------------------\n" +
                                          $"Tổng tiền hàng: {subTotal:N0} VNĐ\n" +
                                          $"Chiết khấu    : -{discount:N0} VNĐ\n" +
                                          $"TỔNG THANH TOÁN: {grandTotal:N0} VNĐ\n" +
                                          $"Tiền khách đưa : {customerMoney:N0} VNĐ\n" +
                                          $"Tiền thừa trả  : {(customerMoney - grandTotal):N0} VNĐ\n" +
                                          $"----------------------------------------\n" +
                                          (selectedCustomer != null ? $"🎁 Tích lũy thêm: +{earnedPoints} Điểm\n" : "") +
                                          $"========================================\n" +
                                          $"Cảm ơn quý khách và hẹn gặp lại!\n";

                        // Hiển thị Preview
                        string fileName = $"HoaDon_POS_{invoiceCode}.txt";
                        using (FormInvoicePreview previewForm = new FormInvoicePreview("Hóa Đơn Bán Hàng POS", invoiceContent, fileName))
                        {
                            previewForm.ShowDialog(this);
                        }

                        // Dọn dẹp UI sau khi bán xong
                        posCartItems.Clear();
                        numDiscount.Value = 0;
                        numCustomerMoney.Value = 0;
                        UpdateCartGrid();
                        LoadShoeGrid(); // Gọi lại hàm của bạn để load tồn kho mới
                        UpdatePOSCalculations();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        string errorMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                        MessageBox.Show("Lỗi chi tiết từ SQL: " + errorMsg, "Lỗi Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
