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

        private List<POSCartItem> posCartItems;

        public FormPOS()
        {
            InitializeComponent();
            posCartItems = new List<POSCartItem>();
        }

        // 1. SỰ KIỆN FORM LOAD -> TẢI DỮ LIỆU THỰC TẾ TỪ SQL SERVER
        private void FormPOS_Load(object sender, EventArgs e)
        {
            // Cấu hình trực tiếp chiều cao cho bảng ngay khi load để không bị ai ghi đè
            ConfigureDataGridView(dgvShoesList);
            ConfigureDataGridView(dgvCartList);

            LoadCategoryComboBox();
            LoadCustomerComboBox();
            LoadShoeGrid();
            UpdateCartGrid();
            UpdatePOSCalculations();
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 40, 50);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            // Ép cứng chiều cao tiêu đề rộng rãi và không cho tự động co giãn
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 45;

            // Cố định chiều cao dòng dữ liệu
            dgv.RowTemplate.Height = 35;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        }

        // TẢI DANH MỤC TỪ CSDL
        private void LoadCategoryComboBox()
        {
            cmbCategoryFilter.SelectedIndexChanged -= cmbCategoryFilter_SelectedIndexChanged;

            using (var db = new QlyBanGiayContext())
            {
                var categories = db.Categories.ToList();
                var filterList = new List<Category> { new Category { CategoryId = 0, Name = "-- Tất cả danh mục --" } };
                filterList.AddRange(categories);

                cmbCategoryFilter.DataSource = filterList;
                cmbCategoryFilter.DisplayMember = "Name";
                cmbCategoryFilter.ValueMember = "CategoryId";
            }

            cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
        }

        // TẢI KHÁCH HÀNG TỪ CSDL
        private void LoadCustomerComboBox()
        {
            using (var db = new QlyBanGiayContext())
            {
                var customers = db.Customers.ToList();
                var customerList = new List<Customer>
                {
                    new Customer { CustomerId = 0, FullName = "Khách Lẻ (Không Tích Điểm)", PhoneNumber = "" }
                };
                customerList.AddRange(customers);

                cmbCustomer.DataSource = customerList;
                cmbCustomer.DisplayMember = "FullName";
                cmbCustomer.ValueMember = "CustomerId";
            }
        }

        // TẢI BẢNG MẪU GIÀY TỪ CSDL SQL SERVER
        private void LoadShoeGrid(List<Product> listToDisplay = null)
        {
            dgvShoesList.Columns.Clear();

            using (var db = new QlyBanGiayContext())
            {
                List<Product> sourceList = listToDisplay;

                if (sourceList == null)
                {
                    // Lấy toàn bộ sản phẩm còn tồn kho > 0
                    sourceList = db.Products.Where(p => p.StockQuantity > 0).ToList();
                }

                var displayData = sourceList.Select(p => new
                {
                    Mã_SP = p.ProductId,
                    Tên_Mẫu_Giày = p.Name,
                    Giá_Bán = p.Price.ToString("N0") + " VNĐ",
                    Tồn_Kho = p.StockQuantity
                }).ToList();

                dgvShoesList.DataSource = displayData;

                // Thêm cột nút "Thêm vào giỏ"
                DataGridViewButtonColumn btnSelectCol = new DataGridViewButtonColumn
                {
                    Name = "colSelect",
                    HeaderText = "Thao Tác",
                    Text = "➕ Chọn",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat
                };
                dgvShoesList.Columns.Add(btnSelectCol);
            }
        }

        // 2. TÌM KIẾM VÀ LỌC GIÀY TỪ CSDL
        private void btnSearchShoe_Click(object sender, EventArgs e) => FilterShoes();

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e) => FilterShoes();

        private void FilterShoes()
        {
            string keyword = txtSearchShoe.Text.Trim().ToLower();
            int catId = (cmbCategoryFilter.SelectedItem as Category)?.CategoryId ?? 0;

            using (var db = new QlyBanGiayContext())
            {
                var query = db.Products.Where(p => p.StockQuantity > 0).AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(p => p.Name.ToLower().Contains(keyword));
                }

                if (catId > 0)
                {
                    query = query.Where(p => p.CategoryId == catId);
                }

                LoadShoeGrid(query.ToList());
            }
        }

        // 3. THÊM SẢN PHẨM VÀO GIỎ HÀNG
        private void dgvShoesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvShoesList.Columns.Contains("colSelect") && e.ColumnIndex == dgvShoesList.Columns["colSelect"].Index)
            {
                int productId = Convert.ToInt32(dgvShoesList.Rows[e.RowIndex].Cells["Mã_SP"].Value);
                AddProductIdToCart(productId);
            }
        }

        private void dgvShoesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dgvShoesList.Rows[e.RowIndex].Cells["Mã_SP"].Value);
                AddProductIdToCart(productId);
            }
        }

        private void AddProductIdToCart(int productId)
        {
            using (var db = new QlyBanGiayContext())
            {
                var shoe = db.Products.FirstOrDefault(p => p.ProductId == productId);
                if (shoe == null) return;

                var existingItem = posCartItems.FirstOrDefault(i => i.ProductId == productId);
                int currentQtyInCart = existingItem != null ? existingItem.Quantity : 0;

                if (currentQtyInCart + 1 > shoe.StockQuantity)
                {
                    MessageBox.Show($"Mẫu giày '{shoe.Name}' chỉ còn tồn kho {shoe.StockQuantity} đôi!", "Cảnh Báo Tồn Kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
        }

        // 4. CẬP NHẬT GIỎ HÀNG VÀ TÍNH TIỀN
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

            DataGridViewButtonColumn btnRemoveCol = new DataGridViewButtonColumn
            {
                Name = "colRemove",
                HeaderText = "Xóa",
                Text = "🗑️ Xóa",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
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

        private void numDiscount_ValueChanged(object sender, EventArgs e) => UpdatePOSCalculations();

        private void numCustomerMoney_ValueChanged(object sender, EventArgs e) => UpdatePOSCalculations();

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

        // 5. THANH TOÁN BÁN HÀNG -> LƯU HÓA ĐƠN SQL, TRỪ TỒN KHO & TÍCH ĐIỂM
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

            if (customerMoney < grandTotal)
            {
                MessageBox.Show($"Số tiền khách đưa ({customerMoney:N0} VNĐ) còn thiếu {(grandTotal - customerMoney):N0} VNĐ!", "Cảnh Báo Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QlyBanGiayContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Customer selectedCustomer = cmbCustomer.SelectedItem as Customer;
                        int customerId = selectedCustomer != null ? selectedCustomer.CustomerId : 0;
                        string customerName = (selectedCustomer != null && customerId > 0) ? selectedCustomer.FullName : "Khách Lẻ";

                        string invoiceCode = "POS" + DateTime.Now.ToString("yyyyMMddHHmmss");

                        // Tính điểm thưởng (100k = 1 điểm)
                        int earnedPoints = (int)(grandTotal / 100000);
                        if (customerId > 0 && earnedPoints > 0)
                        {
                            var dbCustomer = db.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                            if (dbCustomer != null)
                            {
                                dbCustomer.RewardPoints += earnedPoints;
                            }
                        }

                        // Tạo hóa đơn mới
                        var newOrder = new Order
                        {
                            OrderDate = DateTime.Now,
                            TotalAmount = grandTotal,
                            UserId = UserSession.UserId > 0 ? UserSession.UserId : 1
                        };

                        db.Orders.Add(newOrder);
                        db.SaveChanges(); // Lấy OrderId tự tăng

                        string invoiceContent = $"========================================\n" +
                                                $"       HÓA ĐƠN BÁN HÀNG SNEAKER STORE   \n" +
                                                $"========================================\n" +
                                                $"Mã Hóa Đơn : {invoiceCode}\n" +
                                                $"Thời gian  : {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                                                $"Khách hàng : {customerName}\n" +
                                                $"----------------------------------------\n";

                        // Lưu chi tiết hóa đơn & Trừ tồn kho
                        foreach (var item in posCartItems)
                        {
                            var dbShoe = db.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                            if (dbShoe == null || dbShoe.StockQuantity < item.Quantity)
                            {
                                throw new Exception($"Mẫu giày '{item.ProductName}' không đủ số lượng trong kho!");
                            }

                            dbShoe.StockQuantity -= item.Quantity; // Trừ kho

                            db.OrderDetails.Add(new OrderDetail
                            {
                                OrderId = newOrder.OrderId,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity,
                                UnitPrice = item.UnitPrice
                            });

                            invoiceContent += $"• {item.ProductName}\n" +
                                              $"  Đơn giá: {item.UnitPrice:N0} VNĐ x {item.Quantity} = {item.TotalPrice:N0} VNĐ\n";
                        }

                        db.SaveChanges();
                        transaction.Commit(); // Chốt giao dịch an toàn

                        invoiceContent += $"----------------------------------------\n" +
                                          $"Tổng tiền hàng: {subTotal:N0} VNĐ\n" +
                                          $"Chiết khấu    : -{discount:N0} VNĐ\n" +
                                          $"TỔNG THANH TOÁN: {grandTotal:N0} VNĐ\n" +
                                          $"Tiền khách đưa : {customerMoney:N0} VNĐ\n" +
                                          $"Tiền thừa trả  : {(customerMoney - grandTotal):N0} VNĐ\n" +
                                          $"----------------------------------------\n" +
                                          (customerId > 0 ? $"🎁 Tích lũy thêm: +{earnedPoints} Điểm\n" : "") +
                                          $"========================================\n" +
                                          $"Cảm ơn quý khách và hẹn gặp lại!\n";

                        // Mở cửa sổ in hóa đơn
                        string fileName = $"HoaDon_POS_{invoiceCode}.txt";
                        using (FormInvoicePreview previewForm = new FormInvoicePreview("Hóa Đơn Bán Hàng POS", invoiceContent, fileName))
                        {
                            previewForm.ShowDialog(this);
                        }

                        // Reset giao diện
                        posCartItems.Clear();
                        numDiscount.Value = 0;
                        numCustomerMoney.Value = 0;
                        UpdateCartGrid();
                        LoadShoeGrid();
                        UpdatePOSCalculations();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        string errorMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                        MessageBox.Show("Lỗi thanh toán: " + errorMsg, "Lỗi Bán Hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}