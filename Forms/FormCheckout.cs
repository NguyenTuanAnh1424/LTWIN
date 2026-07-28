using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LTWIN.Models;

namespace LTWIN.Forms
{
    public partial class FormCheckout : Form
    {
        public class CartItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; } = null!;
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice => UnitPrice * Quantity;
        }

        private List<CartItem> cartList;
        private List<Product> availableProducts;

        public FormCheckout()
        {
            InitializeComponent();
            cartList = new List<CartItem>();
            InitMockProducts();
        }

        private void InitMockProducts()
        {
            availableProducts = new List<Product>
            {
                new Product { ProductId = 1, Name = "Nike Air Max 270 React", Price = 3200000, StockQuantity = 15 },
                new Product { ProductId = 2, Name = "Adidas Ultraboost 22", Price = 3850000, StockQuantity = 8 },
                new Product { ProductId = 3, Name = "Air Jordan 1 Retro High", Price = 4500000, StockQuantity = 5 },
                new Product { ProductId = 4, Name = "Puma RS-X Reinvent", Price = 2490000, StockQuantity = 20 }
            };
        }

        private void FormCheckout_Load(object sender, EventArgs e)
        {
            cmbProducts.DataSource = availableProducts;
            cmbProducts.DisplayMember = "Name";
            cmbProducts.ValueMember = "ProductId";
            UpdateCartDataGrid();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem is Product selectedProduct)
            {
                int quantity = (int)numQuantity.Value;
                if (quantity <= 0)
                {
                    MessageBox.Show("Vui lòng chọn số lượng lớn hơn 0!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingItem = cartList.FirstOrDefault(c => c.ProductId == selectedProduct.ProductId);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                }
                else
                {
                    cartList.Add(new CartItem
                    {
                        ProductId = selectedProduct.ProductId,
                        ProductName = selectedProduct.Name,
                        UnitPrice = selectedProduct.Price,
                        Quantity = quantity
                    });
                }

                UpdateCartDataGrid();
            }
        }

        private void btnRemoveCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvCart.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < cartList.Count)
                {
                    cartList.RemoveAt(selectedIndex);
                    UpdateCartDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong giỏ để xóa!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            cartList.Clear();
            UpdateCartDataGrid();
        }

        private void UpdateCartDataGrid()
        {
            var displayData = cartList.Select(c => new
            {
                Mã_SP = c.ProductId,
                Tên_Mẫu_Giày = c.ProductName,
                Đơn_Giá = c.UnitPrice.ToString("N0") + " VNĐ",
                Số_Lượng = c.Quantity,
                Thành_Tiền = c.TotalPrice.ToString("N0") + " VNĐ"
            }).ToList();

            dgvCart.DataSource = displayData;
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = cartList.Sum(c => c.TotalPrice);
            lblTotalMoney.Text = total.ToString("N0") + " VNĐ";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (!cartList.Any())
            {
                MessageBox.Show("Giỏ hàng đang rỗng! Vui lòng chọn mẫu giày trước khi bán.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string customerName = "Khách Lẻ";
            string invoiceCode = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            decimal totalMoney = cartList.Sum(c => c.TotalPrice);

            string invoiceContent = $"========================================\n" +
                                    $"       HÓA ĐƠN BÁN HÀNG SNEAKER STORE   \n" +
                                    $"========================================\n" +
                                    $"Mã Hóa Đơn : {invoiceCode}\n" +
                                    $"Ngày lập   : {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                                    $"Khách hàng : {customerName}\n" +
                                    $"----------------------------------------\n";

            foreach (var item in cartList)
            {
                invoiceContent += $"• {item.ProductName}\n" +
                                  $"  Số lượng: {item.Quantity} x {item.UnitPrice:N0} = {item.TotalPrice:N0} VNĐ\n";
            }

            invoiceContent += $"----------------------------------------\n" +
                              $"TỔNG CỘNG THANH TOÁN: {totalMoney:N0} VNĐ\n" +
                              $"========================================\n" +
                              $"Cảm ơn quý khách và hẹn gặp lại!\n";

            try
            {
                string fileName = $"HoaDon_{invoiceCode}.txt";
                using (FormInvoicePreview previewForm = new FormInvoicePreview("Hóa Đơn Bán Hàng", invoiceContent, fileName))
                {
                    previewForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(invoiceContent + "\n\n⚠️ Lỗi: " + ex.Message, "Thông Báo Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cartList.Clear();
            UpdateCartDataGrid();
        }
    }
}
