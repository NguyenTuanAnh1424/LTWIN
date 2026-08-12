using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LTWIN.Models;
using LTWIN.Services;
using LTWIN.Utils;
using Microsoft.EntityFrameworkCore;

namespace LTWIN.Forms
{
    public partial class FormOrderHistory : Form
    {
        public FormOrderHistory()
        {
            InitializeComponent();
        }

        private void FormOrderHistory_Load(object sender, EventArgs e)
        {
            // Thiết lập các mốc thời gian lọc
            cmbTimeFilter.Items.Add("Tất cả");
            cmbTimeFilter.Items.Add("Hôm nay");
            cmbTimeFilter.Items.Add("Tháng này");
            cmbTimeFilter.SelectedIndex = 0;
        }

        // HÀM CHÍNH: TẢI VÀ LỌC DỮ LIỆU TỪ SQL SERVER
        private void LoadOrderList()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            int timeOption = cmbTimeFilter.SelectedIndex;

            using (var db = new QlyBanGiayContext())
            {
                var query = db.Orders.Include(o => o.Customer).AsQueryable();

                // 1. Lọc theo thời gian
                DateTime today = DateTime.Now.Date;
                if (timeOption == 1) // Hôm nay
                {
                    DateTime endOfDay = today.AddDays(1).AddTicks(-1);
                    query = query.Where(o => o.OrderDate >= today && o.OrderDate <= endOfDay);
                }
                else if (timeOption == 2) // Tháng này
                {
                    DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
                    DateTime endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);
                    query = query.Where(o => o.OrderDate >= startOfMonth && o.OrderDate <= endOfMonth);
                }

                // 2. Lọc theo từ khóa (Mã hóa đơn hoặc tên khách)
                if (!string.IsNullOrEmpty(keyword))
                {
                    string lowerKeyword = keyword.ToLower();
                    query = query.Where(o => o.OrderId.ToString().Contains(keyword) ||
                                            (o.Customer != null && o.Customer.FullName.ToLower().Contains(lowerKeyword)));
                }

                // 3. Lấy dữ liệu từ DB lên bộ nhớ (sắp xếp mới nhất lên đầu)
                var resultList = query.OrderByDescending(o => o.OrderDate).ToList();

                // 4. Ánh xạ sang cấu trúc hiển thị trên DataGridView (Đã xóa các toán tử ??)
                var displayData = resultList.Select(o => new
                {
                    Mã_Hóa_Đơn = o.OrderId,
                    Thời_Gian = o.OrderDate.HasValue ? o.OrderDate.Value.ToString("dd/MM/yyyy HH:mm") : "",
                    Khách_Hàng = o.Customer != null ? o.Customer.FullName : "Khách Lẻ",
                    Tổng_Thanh_Toán = o.TotalAmount.ToString("N0") + " VNĐ",
                    Trạng_Thái = string.IsNullOrEmpty(o.Status) ? "Hoàn Thành" : o.Status
                }).ToList();

                dgvOrders.DataSource = displayData;

                // 5. Cập nhật thống kê (Đã xóa toán tử ??)
                decimal totalRevenue = resultList
                    .Where(o => string.IsNullOrEmpty(o.Status) || o.Status == "Hoàn Thành")
                    .Sum(o => o.TotalAmount);

                lblSummary.Text = $"📊 Tổng cộng: {resultList.Count} đơn hàng | Doanh thu thực nhận: {totalRevenue:N0} VNĐ";

                // Xóa lưới chi tiết nếu không có dữ liệu
                if (!resultList.Any())
                {
                    dgvOrderDetails.DataSource = null;
                }
            }
        }

        // SỰ KIỆN: BẤM VÀO HÓA ĐƠN -> HIỂN THỊ CHI TIẾT
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                // Lấy Mã Hóa Đơn từ dòng đang được chọn
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Mã_Hóa_Đơn"].Value);

                using (var db = new QlyBanGiayContext())
                {
                    // Đã xóa các toán tử ??
                    var details = db.OrderDetails
                                    .Where(od => od.OrderId == orderId)
                                    .Select(od => new
                                    {
                                        Mã_SP = od.ProductId,
                                        Tên_Mẫu_Giày = od.Product.Name,
                                        Đơn_Giá = od.UnitPrice.ToString("N0") + " VNĐ",
                                        Số_Lượng = od.Quantity + " đôi",
                                        Thành_Tiền = (od.UnitPrice * od.Quantity).ToString("N0") + " VNĐ"
                                    }).ToList();

                    dgvOrderDetails.DataSource = details;
                }
            }
            else
            {
                dgvOrderDetails.DataSource = null;
            }
        }

        // TÌM KIẾM THEO TỪ KHÓA
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        // LỌC THEO COMBOBOX
        private void cmbTimeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        // IN LẠI HÓA ĐƠN
        private void btnRePrint_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Mã_Hóa_Đơn"].Value);

                using (var db = new QlyBanGiayContext())
                {
                    var order = db.Orders.FirstOrDefault(o => o.OrderId == orderId);
                    if (order != null)
                    {
                        string fileName = $"InLai_POS{orderId}.txt";
                        string customerName = dgvOrders.SelectedRows[0].Cells["Khách_Hàng"].Value.ToString();

                        string invoiceContent = $"=== HÓA ĐƠN BÁN HÀNG SNEAKER STORE ===\n" +
                                                $"Mã Hóa Đơn : POS{orderId}\n" +
                                                $"Thời gian  : {order.OrderDate}\n" +
                                                $"Khách hàng : {customerName}\n" +
                                                $"----------------------------------------\n";

                        var details = db.OrderDetails.Include(od => od.Product).Where(od => od.OrderId == orderId).ToList();
                        foreach (var item in details)
                        {
                            invoiceContent += $"- {item.Product.Name}\n";
                            invoiceContent += $"  {item.UnitPrice:N0} x {item.Quantity} = {(item.UnitPrice * item.Quantity):N0} VNĐ\n";
                        }
                        invoiceContent += $"----------------------------------------\n";
                        invoiceContent += $"TỔNG CỘNG: {order.TotalAmount:N0} VNĐ\n";
                        invoiceContent += $"=== (Bản in lại từ hệ thống) ===";

                        using (FormInvoicePreview previewForm = new FormInvoicePreview("In Lại Hóa Đơn POS" + orderId, invoiceContent, fileName))
                        {
                            previewForm.ShowDialog(this);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hóa đơn cần xem hoặc in lại!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // HỦY HÓA ĐƠN & HOÀN TRẢ TỒN KHO
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Mã_Hóa_Đơn"].Value);
                string currentStatus = dgvOrders.SelectedRows[0].Cells["Trạng_Thái"].Value.ToString();

                if (currentStatus == "Đã Hủy")
                {
                    MessageBox.Show("Hóa đơn này đã được hủy trước đó!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn HỦY HÓA ĐƠN 'POS{orderId}' này không?\n\n(Lưu ý: Số lượng giày của đơn này sẽ được cộng trả lại vào kho)",
                                              "Xác Nhận Hủy Đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    using (var db = new QlyBanGiayContext())
                    {
                        var order = db.Orders.FirstOrDefault(o => o.OrderId == orderId);
                        if (order != null)
                        {
                            // 1. Cập nhật trạng thái hóa đơn
                            order.Status = "Đã Hủy";

                            // 2. Hoàn trả số lượng vào kho (Bảng Products) - Đã xóa toán tử ??
                            var orderItems = db.OrderDetails.Where(od => od.OrderId == orderId).ToList();
                            foreach (var item in orderItems)
                            {
                                var product = db.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                                if (product != null)
                                {
                                    product.StockQuantity = product.StockQuantity + item.Quantity;
                                }
                            }

                            // 3. Lưu vào DB
                            db.SaveChanges();

                            MessageBox.Show($"✅ Đã hủy hóa đơn 'POS{orderId}' thành công và hoàn trả tồn kho!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Load lại danh sách
                            LoadOrderList();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hóa đơn cần hủy!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvOrders.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Mở hộp thoại chọn nơi lưu file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.FileName = $"ThongKeDoanhThu_{DateTime.Now:ddMMyyyy_HHmm}.csv"; // Tên file mặc định có kèm ngày giờ

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Sử dụng UTF8Encoding(true) để Excel đọc được tiếng Việt có dấu (BOM)
                    using (var sw = new System.IO.StreamWriter(sfd.FileName, false, new System.Text.UTF8Encoding(true)))
                    {
                        // 3. Ghi dòng tiêu đề (Headers)
                        var headers = dgvOrders.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText);
                        sw.WriteLine(string.Join(",", headers));

                        // 4. Ghi từng dòng dữ liệu
                        foreach (DataGridViewRow row in dgvOrders.Rows)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>().Select(c =>
                            {
                                string cellValue = c.Value != null ? c.Value.ToString() : "";
                                // Nếu dữ liệu có chứa dấu phẩy (vd: số tiền), phải bọc trong dấu ngoặc kép để tránh lỗi CSV
                                if (cellValue.Contains(","))
                                {
                                    cellValue = $"\"{cellValue}\"";
                                }
                                return cellValue;
                            });
                            sw.WriteLine(string.Join(",", cells));
                        }
                    }
                    MessageBox.Show("Xuất báo cáo thành công! Bạn có thể mở file này bằng Excel.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}