using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LTWIN.Models;
using LTWIN.Utils;

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

        public FormCheckout()
        {
            InitializeComponent();
            cartList = new List<CartItem>();
        }

        // 1. FORM LOAD -> TẢI DANH SÁCH SẢN PHẨM TỪ SQL SERVER
        private void FormCheckout_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvCart);
            LoadProductsFromDatabase();
            UpdateCartDataGrid();
        }

        // HÀM TẢI CÁC MẪU GIÀY CÒN HÀNG TỪ SQL SERVER
        private void LoadProductsFromDatabase()
        {
            using (var db = new QlyBanGiayContext())
            {
                // Chỉ lấy các sản phẩm còn tồn kho > 0
                var availableProducts = db.Products
                                          .Where(p => p.StockQuantity > 0)
                                          .ToList();

                cmbProducts.DataSource = availableProducts;
                cmbProducts.DisplayMember = "Name";
                cmbProducts.ValueMember = "ProductId";
            }
        }

        // 2. THÊM SẢN PHẨM VÀO GIỎ HÀNG (CÓ KIỂM TRA TỒN KHO SQL)
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

                // Kiểm tra tổng số lượng trong giỏ + số lượng muốn thêm có vượt quá tồn kho trong SQL không
                var existingItem = cartList.FirstOrDefault(c => c.ProductId == selectedProduct.ProductId);
                int currentCartQty = existingItem != null ? existingItem.Quantity : 0;

                using (var db = new QlyBanGiayContext())
                {
                    var dbProduct = db.Products.FirstOrDefault(p => p.ProductId == selectedProduct.ProductId);
                    if (dbProduct == null || (currentCartQty + quantity) > dbProduct.StockQuantity)
                    {
                        MessageBox.Show($"Mẫu giày '{selectedProduct.Name}' chỉ còn tồn kho {dbProduct?.StockQuantity ?? 0} đôi!\nBạn đã có {currentCartQty} đôi trong giỏ.",
                                        "Cảnh Báo Tồn Kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

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

        // 3. XÓA MỘT SẢN PHẨM KHỎI GIỎ HÀNG
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

        // 4. XÓA TOÀN BỘ GIỎ HÀNG
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

        // 5. THANH TOÁN -> LƯU HÓA ĐƠN VÀO SQL SERVER & TRỪ TỒN KHO
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (!cartList.Any())
            {
                MessageBox.Show("Giỏ hàng đang rỗng! Vui lòng chọn mẫu giày trước khi bán.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalMoney = cartList.Sum(c => c.TotalPrice);
            string invoiceCode = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string customerName = "Khách Lẻ";

            using (var db = new QlyBanGiayContext())
            {
                // Bước 5.1: Kiểm tra lại số lượng tồn kho thực tế trong CSDL một lần nữa
                foreach (var item in cartList)
                {
                    var product = db.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                    if (product == null || product.StockQuantity < item.Quantity)
                    {
                        MessageBox.Show($"Mẫu giày '{item.ProductName}' không đủ hàng trong kho (Còn: {product?.StockQuantity ?? 0}). Vui lòng kiểm tra lại!",
                                        "Lỗi Tồn Kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Bước 5.2: Tạo đơn hàng mới trong CSDL SQL Server (dbo.Orders)
                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    TotalAmount = totalMoney
                };

                db.Orders.Add(order);
                db.SaveChanges(); // Lưu để SQL cấp OrderId tự động

                // Bước 5.3: Lưu chi tiết đơn hàng (dbo.OrderDetails) & Trừ số lượng tồn kho (dbo.Products)
                foreach (var item in cartList)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };
                    db.OrderDetails.Add(orderDetail);

                    // Trừ số lượng tồn kho của giày
                    var product = db.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                    if (product != null)
                    {
                        product.StockQuantity -= item.Quantity;
                    }
                }

                // Lưu tất cả thay đổi chi tiết & kho hàng vào SQL Server
                db.SaveChanges();
            }

            // Bước 5.4: Tạo nội dung In Hóa Đơn
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
                MessageBox.Show(invoiceContent + "\n\n⚠️ Lỗi hiển thị xem trước: " + ex.Message, "Thông Báo Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Dọn dẹp giỏ hàng & Tải lại danh sách giày còn tồn kho mới nhất
            cartList.Clear();
            UpdateCartDataGrid();
            LoadProductsFromDatabase();

            MessageBox.Show("Thanh toán thành công! Dữ liệu hóa đơn và tồn kho đã được lưu vào SQL Server.",
                            "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}