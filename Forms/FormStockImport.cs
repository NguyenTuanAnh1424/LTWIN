using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LTWIN.Models;
using LTWIN.Services;

using LTWIN.Utils;

namespace LTWIN.Forms
{
    public partial class FormStockImport : Form
    {
        public class ImportCartItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; } = null!;
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice => UnitPrice * Quantity;
        }

        private List<Product> productList;
        private List<ImportCartItem> importCartList;

        public FormStockImport()
        {
            InitializeComponent();
            importCartList = new List<ImportCartItem>();
            InitMockProducts();
        }

        private void InitMockProducts()
        {
            productList = new List<Product>
            {
                new Product { ProductId = 1, Name = "Nike Air Max 270 React", Price = 3200000, StockQuantity = 15 },
                new Product { ProductId = 2, Name = "Adidas Ultraboost 22", Price = 3850000, StockQuantity = 8 },
                new Product { ProductId = 3, Name = "Air Jordan 1 Retro High", Price = 4500000, StockQuantity = 5 },
                new Product { ProductId = 4, Name = "Puma RS-X Reinvent", Price = 2490000, StockQuantity = 20 }
            };
        }

        private void FormStockImport_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvImportCart);
            ThemeHelper.StyleDataGridView(dgvHistoryReceipts);
            ThemeHelper.StyleDataGridView(dgvHistoryDetails);
            LoadSuppliers();
            LoadProductsComboBox();
            UpdateImportCartGrid();
            LoadImportHistoryGrid();
        }

        private void LoadSuppliers()
        {
            cmbSupplier.DataSource = new List<string>(StockImportStore.Suppliers);
        }

        private void LoadProductsComboBox()
        {
            cmbProducts.DataSource = productList;
            cmbProducts.DisplayMember = "Name";
            cmbProducts.ValueMember = "ProductId";
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem is Product selected)
            {
                // Gợi ý giá nhập (ví dụ 75% giá bán lẻ)
                decimal estimatedCost = Math.Round(selected.Price * 0.75m / 10000) * 10000;
                numImportUnitPrice.Value = Math.Min(numImportUnitPrice.Maximum, Math.Max(numImportUnitPrice.Minimum, estimatedCost));
            }
        }

        private void btnAddImportItem_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem is Product selectedProduct)
            {
                int quantity = (int)numImportQuantity.Value;
                decimal unitPrice = numImportUnitPrice.Value;

                if (quantity <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng lớn hơn 0!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existing = importCartList.FirstOrDefault(i => i.ProductId == selectedProduct.ProductId);
                if (existing != null)
                {
                    existing.Quantity += quantity;
                    existing.UnitPrice = unitPrice;
                }
                else
                {
                    importCartList.Add(new ImportCartItem
                    {
                        ProductId = selectedProduct.ProductId,
                        ProductName = selectedProduct.Name,
                        UnitPrice = unitPrice,
                        Quantity = quantity
                    });
                }

                UpdateImportCartGrid();
            }
        }

        private void UpdateImportCartGrid()
        {
            dgvImportCart.Columns.Clear();

            var displayData = importCartList.Select(i => new
            {
                Mã_SP = i.ProductId,
                Tên_Mẫu_Giày = i.ProductName,
                Đơn_Giá_Nhập = i.UnitPrice.ToString("N0") + " VNĐ",
                Số_Lượng_Nhập = i.Quantity + " đôi",
                Thành_Tiền_Nhập = i.TotalPrice.ToString("N0") + " VNĐ"
            }).ToList();

            dgvImportCart.DataSource = displayData;

            DataGridViewButtonColumn btnRemoveCol = new DataGridViewButtonColumn();
            btnRemoveCol.Name = "colRemove";
            btnRemoveCol.HeaderText = "Xóa";
            btnRemoveCol.Text = "🗑️ Xóa";
            btnRemoveCol.UseColumnTextForButtonValue = true;
            btnRemoveCol.FlatStyle = FlatStyle.Flat;
            dgvImportCart.Columns.Add(btnRemoveCol);

            decimal grandTotal = importCartList.Sum(i => i.TotalPrice);
            lblTotalImportMoney.Text = grandTotal.ToString("N0") + " VNĐ";
        }

        private void dgvImportCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvImportCart.Columns.Contains("colRemove") && e.ColumnIndex == dgvImportCart.Columns["colRemove"].Index)
            {
                int productId = Convert.ToInt32(dgvImportCart.Rows[e.RowIndex].Cells["Mã_SP"].Value);
                var item = importCartList.FirstOrDefault(i => i.ProductId == productId);
                if (item != null)
                {
                    importCartList.Remove(item);
                    UpdateImportCartGrid();
                }
            }
        }

        private void btnClearImportCart_Click(object sender, EventArgs e)
        {
            if (importCartList.Any())
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn hủy tất cả sản phẩm khỏi phiếu nhập?", "Xác Nhận Hủy Phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    importCartList.Clear();
                    UpdateImportCartGrid();
                }
            }
        }

        private void btnConfirmImport_Click(object sender, EventArgs e)
        {
            if (!importCartList.Any())
            {
                MessageBox.Show("Phiếu nhập kho hiện đang rỗng! Vui lòng chọn sản phẩm cần nhập.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string supplier = cmbSupplier.Text.Trim();
            if (string.IsNullOrEmpty(supplier))
            {
                supplier = "Nhà Cung Cấp Tự Do";
            }

            string receiptCode = "NK" + DateTime.Now.ToString("yyyyMMddHHmmss");
            decimal totalImportAmount = importCartList.Sum(i => i.TotalPrice);

            // Cập nhật số lượng tồn kho cho sản phẩm
            foreach (var cartItem in importCartList)
            {
                var p = productList.FirstOrDefault(x => x.ProductId == cartItem.ProductId);
                if (p != null)
                {
                    p.StockQuantity += cartItem.Quantity;
                }
            }

            string receiptContent = $"========================================\n" +
                                    $"       PHIẾU NHẬP KHO HÀNG SNEAKER STORE\n" +
                                    $"========================================\n" +
                                    $"Mã Phiếu   : {receiptCode}\n" +
                                    $"Thời Gian  : {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                                    $"Nhà Cung Cấp: {supplier}\n" +
                                    $"Người Lập  : Admin Quản Trị\n" +
                                    $"Ghi Chú    : {txtNote.Text.Trim()}\n" +
                                    $"----------------------------------------\n";

            foreach (var item in importCartList)
            {
                receiptContent += $"• {item.ProductName}\n" +
                                  $"  Giá nhập: {item.UnitPrice:N0} VNĐ x {item.Quantity} đôi = {item.TotalPrice:N0} VNĐ\n";
            }

            receiptContent += $"----------------------------------------\n" +
                              $"TỔNG GIÁ TRỊ NHẬP KHO: {totalImportAmount:N0} VNĐ\n" +
                              $"========================================\n" +
                              $"Xác nhận đã nhập hàng thành công vào kho!\n";

            var receiptRecord = new StockImportReceipt
            {
                ReceiptCode = receiptCode,
                ImportDate = DateTime.Now,
                SupplierName = supplier,
                CreatedBy = "Admin Quản Trị",
                TotalImportAmount = totalImportAmount,
                Note = txtNote.Text.Trim(),
                ReceiptContent = receiptContent,
                Items = importCartList.Select(i => new StockImportDetail
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    ImportUnitPrice = i.UnitPrice,
                    ImportQuantity = i.Quantity
                }).ToList()
            };

            StockImportStore.AddReceipt(receiptRecord);

            try
            {
                string fileName = $"PhieuNhapKho_{receiptCode}.txt";
                using (FormInvoicePreview previewForm = new FormInvoicePreview("Phiếu Nhập Kho Sản Phẩm", receiptContent, fileName))
                {
                    previewForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(receiptContent + "\n\n⚠️ Lỗi: " + ex.Message, "Thông Báo Nhập Kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            importCartList.Clear();
            txtNote.Clear();
            UpdateImportCartGrid();
            LoadImportHistoryGrid();
        }

        private void LoadImportHistoryGrid()
        {
            var history = StockImportStore.ImportHistory;

            var displayData = history.Select(h => new
            {
                Mã_Phiếu = h.ReceiptCode,
                Thời_Gian = h.ImportDate.ToString("dd/MM/yyyy HH:mm"),
                Nhà_Cung_Cấp = h.SupplierName,
                Tổng_Tiền_Nhập = h.TotalImportAmount.ToString("N0") + " VNĐ",
                Người_Lập = h.CreatedBy,
                Ghi_Chú = h.Note
            }).ToList();

            dgvHistoryReceipts.DataSource = displayData;

            decimal totalCost = history.Sum(h => h.TotalImportAmount);
            lblHistorySummary.Text = $"📊 Tổng phiếu nhập: {history.Count} | Tổng vốn nhập kho: {totalCost:N0} VNĐ";
        }

        private void dgvHistoryReceipts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistoryReceipts.SelectedRows.Count > 0)
            {
                int index = dgvHistoryReceipts.SelectedRows[0].Index;
                if (index >= 0 && index < StockImportStore.ImportHistory.Count)
                {
                    var selectedReceipt = StockImportStore.ImportHistory[index];
                    DisplayHistoryDetails(selectedReceipt);
                }
            }
            else
            {
                dgvHistoryDetails.DataSource = null;
            }
        }

        private void DisplayHistoryDetails(StockImportReceipt receipt)
        {
            var displayDetails = receipt.Items.Select(i => new
            {
                Mã_SP = i.ProductId,
                Tên_Mẫu_Giày = i.ProductName,
                Đơn_Giá_Nhập = i.ImportUnitPrice.ToString("N0") + " VNĐ",
                Số_Lượng_Nhập = i.ImportQuantity + " đôi",
                Thành_Tiền = i.TotalPrice.ToString("N0") + " VNĐ"
            }).ToList();

            dgvHistoryDetails.DataSource = displayDetails;
        }

        private void btnRePrintReceipt_Click(object sender, EventArgs e)
        {
            if (dgvHistoryReceipts.SelectedRows.Count > 0)
            {
                int index = dgvHistoryReceipts.SelectedRows[0].Index;
                if (index >= 0 && index < StockImportStore.ImportHistory.Count)
                {
                    var selectedReceipt = StockImportStore.ImportHistory[index];
                    string fileName = $"InLai_PhieuNhap_{selectedReceipt.ReceiptCode}.txt";

                    using (FormInvoicePreview previewForm = new FormInvoicePreview("In Lại Phiếu Nhập " + selectedReceipt.ReceiptCode, selectedReceipt.ReceiptContent, fileName))
                    {
                        previewForm.ShowDialog(this);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu nhập kho để in lại!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
