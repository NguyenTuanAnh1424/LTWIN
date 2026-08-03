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

            if (customerMoney < grandTotal && customerMoney > 0)
            {
                MessageBox.Show($"Số tiền khách đưa ({customerMoney:N0} VNĐ) còn thiếu {(grandTotal - customerMoney):N0} VNĐ!", "Cảnh Báo Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer selectedCustomer = cmbCustomer.SelectedItem as Customer ?? mockCustomerList[0];
            string invoiceCode = "POS" + DateTime.Now.ToString("yyyyMMddHHmmss");

            int earnedPoints = (int)(grandTotal / 100000);
            if (selectedCustomer.CustomerId > 0 && earnedPoints > 0)
            {
                selectedCustomer.RewardPoints += earnedPoints;
            }

            string invoiceContent = $"========================================\n" +
                                    $"       HÓA ĐƠN BÁN HÀNG SNEAKER STORE   \n" +
                                    $"========================================\n" +
                                    $"Mã Hóa Đơn : {invoiceCode}\n" +
                                    $"Thời gian  : {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                                    $"Khách hàng : {selectedCustomer.FullName}\n" +
                                    $"----------------------------------------\n";

            foreach (var item in posCartItems)
            {
                var shoe = mockProductList.FirstOrDefault(p => p.ProductId == item.ProductId);
                if (shoe != null)
                {
                    shoe.StockQuantity = Math.Max(0, shoe.StockQuantity - item.Quantity);
                }

                invoiceContent += $"• {item.ProductName}\n" +
                                  $"  Đơn giá: {item.UnitPrice:N0} VNĐ x {item.Quantity} = {item.TotalPrice:N0} VNĐ\n";
            }

            invoiceContent += $"----------------------------------------\n" +
                              $"Tổng tiền hàng: {subTotal:N0} VNĐ\n" +
                              $"Chiết khấu    : -{discount:N0} VNĐ\n" +
                              $"TỔNG THANH TOÁN: {grandTotal:N0} VNĐ\n" +
                              $"Tiền khách đưa : {customerMoney:N0} VNĐ\n" +
                              $"Tiền thừa trả  : {(customerMoney - grandTotal):N0} VNĐ\n" +
                              $"----------------------------------------\n" +
                              (selectedCustomer.CustomerId > 0 ? $"🎁 Tích lũy thêm: +{earnedPoints} Điểm (Tổng: {selectedCustomer.RewardPoints} Đ)\n" : "") +
                              $"========================================\n" +
                              $"Cảm ơn quý khách và hẹn gặp lại!\n";

            var orderRecord = new POSOrderRecord
            {
                InvoiceCode = invoiceCode,
                OrderDate = DateTime.Now,
                CustomerName = selectedCustomer.FullName,
                SubTotal = subTotal,
                Discount = discount,
                GrandTotal = grandTotal,
                CustomerMoney = customerMoney,
                ChangeMoney = Math.Max(0, customerMoney - grandTotal),
                Status = "Hoàn Thành",
                InvoiceContent = invoiceContent,
                Items = posCartItems.Select(i => new POSCartItemRecord
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity
                }).ToList()
            };
            OrderStore.AddOrder(orderRecord);

            try
            {
                string fileName = $"HoaDon_POS_{invoiceCode}.txt";
                using (FormInvoicePreview previewForm = new FormInvoicePreview("Hóa Đơn Bán Hàng POS", invoiceContent, fileName))
                {
                    previewForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(invoiceContent + "\n\n⚠️ Lỗi: " + ex.Message, "Thông Báo Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            posCartItems.Clear();
            numDiscount.Value = 0;
            numCustomerMoney.Value = 0;
            UpdateCartGrid();
            LoadShoeGrid();
            UpdatePOSCalculations();
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
    }
}
