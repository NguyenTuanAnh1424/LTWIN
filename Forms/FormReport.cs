using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LTWIN.Models;
using LTWIN.Utils;

namespace LTWIN.Forms
{
    public partial class FormReport : Form
    {
        public class TopSellingItem
        {
            public int Rank { get; set; }
            public string ShoeName { get; set; } = null!;
            public string CategoryName { get; set; } = null!;
            public int QuantitySold { get; set; }
            public decimal TotalRevenue { get; set; }
        }

        private List<TopSellingItem> topSellingList = new List<TopSellingItem>();

        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvTopSelling);

            cmbTimeFilter.SelectedIndexChanged -= cmbTimeFilter_SelectedIndexChanged;
            cmbTimeFilter.Items.Clear();
            cmbTimeFilter.Items.Add("Tất cả thời gian");
            cmbTimeFilter.Items.Add("Hôm nay");
            cmbTimeFilter.Items.Add("7 Ngày gần nhất");
            cmbTimeFilter.Items.Add("Tháng này");
            cmbTimeFilter.SelectedIndex = 0;
            cmbTimeFilter.SelectedIndexChanged += cmbTimeFilter_SelectedIndexChanged;

            LoadReportData();
        }

        private void LoadReportData()
        {
            using (var db = new QlyBanGiayContext())
            {
                var ordersQuery = db.Orders.AsQueryable();
                DateTime now = DateTime.Now;

                string filterOption = cmbTimeFilter.SelectedItem?.ToString() ?? "Tất cả thời gian";
                if (filterOption == "Hôm nay")
                {
                    ordersQuery = ordersQuery.Where(o => o.OrderDate.HasValue && o.OrderDate.Value.Date == now.Date);
                }
                else if (filterOption == "7 Ngày gần nhất")
                {
                    DateTime startDay = now.Date.AddDays(-7);
                    ordersQuery = ordersQuery.Where(o => o.OrderDate.HasValue && o.OrderDate.Value >= startDay);
                }
                else if (filterOption == "Tháng này")
                {
                    ordersQuery = ordersQuery.Where(o => o.OrderDate.HasValue && o.OrderDate.Value.Month == now.Month && o.OrderDate.Value.Year == now.Year);
                }

                var filteredOrderIds = ordersQuery.Select(o => o.OrderId).ToList();

                decimal totalRevenue = ordersQuery.Sum(o => (decimal?)o.TotalAmount) ?? 0;
                int totalOrders = filteredOrderIds.Count;

                // 💡 KHẮC PHỤC LỖI DÒNG 72: Lấy od.OrderId.Value khi od.OrderId có giá trị
                var orderDetailsQuery = db.OrderDetails.Where(od => od.OrderId.HasValue && filteredOrderIds.Contains(od.OrderId.Value));

                int totalShoesSold = orderDetailsQuery.Sum(od => (int?)od.Quantity) ?? 0;
                decimal avgOrderValue = totalOrders > 0 ? totalRevenue / totalOrders : 0;

                lblCard1Value.Text = totalRevenue.ToString("N0") + " VNĐ";
                lblCard2Value.Text = totalOrders + " Đơn";
                lblCard3Value.Text = totalShoesSold + " Đôi";
                lblCard4Value.Text = avgOrderValue.ToString("N0") + " VNĐ";

                // Thống kê Top 5 mẫu giày bán chạy (Loại bỏ ProductId null)
                var topProductsData = orderDetailsQuery
                    .Where(od => od.ProductId.HasValue)
                    .GroupBy(od => od.ProductId.Value)
                    .Select(g => new
                    {
                        ProductId = g.Key,
                        QuantitySold = g.Sum(x => x.Quantity),
                        TotalRevenue = g.Sum(x => x.Quantity * x.UnitPrice)
                    })
                    .OrderByDescending(x => x.QuantitySold)
                    .Take(5)
                    .ToList();

                var productsDict = db.Products.ToDictionary(p => p.ProductId, p => p.Name);
                var productCatIds = db.Products.ToDictionary(p => p.ProductId, p => p.CategoryId ?? 0);
                var categoriesDict = db.Categories.ToDictionary(c => c.CategoryId, c => c.Name);

                topSellingList.Clear();
                int rank = 1;

                foreach (var item in topProductsData)
                {
                    string shoeName = productsDict.ContainsKey(item.ProductId) ? productsDict[item.ProductId] : "Mẫu Giày " + item.ProductId;

                    string categoryName = "Khác";
                    if (productCatIds.ContainsKey(item.ProductId))
                    {
                        int catId = productCatIds[item.ProductId];
                        if (categoriesDict.ContainsKey(catId))
                        {
                            categoryName = categoriesDict[catId];
                        }
                    }

                    topSellingList.Add(new TopSellingItem
                    {
                        Rank = rank++,
                        ShoeName = shoeName,
                        CategoryName = categoryName,
                        QuantitySold = item.QuantitySold,
                        TotalRevenue = item.TotalRevenue
                    });
                }

                var displayData = topSellingList.Select(x => new
                {
                    Hạng = "Top " + x.Rank,
                    Tên_Mẫu_Giày = x.ShoeName,
                    Loại_Giày = x.CategoryName,
                    Đã_Bán = x.QuantitySold + " đôi",
                    Doanh_Thu_Mang_Về = x.TotalRevenue.ToString("N0") + " VNĐ"
                }).ToList();

                dgvTopSelling.DataSource = displayData;

                panelChartCanvas.Invalidate();

            }
        }

        private void cmbTimeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            string timeRange = cmbTimeFilter.SelectedItem?.ToString() ?? "Tất cả thời gian";
            string reportCode = "BC" + DateTime.Now.ToString("yyyyMMddHHmmss");

            string reportContent = $"========================================\n" +
                                   $"     BÁO CÁO DOANH THU CỬA HÀNG GIÀY    \n" +
                                   $"========================================\n" +
                                   $"Mã Báo Cáo  : {reportCode}\n" +
                                   $"Thời Gian   : {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                                   $"Phạm Vi Lọc : {timeRange}\n" +
                                   $"----------------------------------------\n" +
                                   $"TỔNG DOANH THU     : {lblCard1Value.Text}\n" +
                                   $"TỔNG ĐƠN HÀNG BÁN  : {lblCard2Value.Text}\n" +
                                   $"SỐ ĐÔI GIÀY ĐÃ BÁN : {lblCard3Value.Text}\n" +
                                   $"GIÁ TRỊ T.BÌNH/ĐƠN : {lblCard4Value.Text}\n" +
                                   $"----------------------------------------\n" +
                                   $"TOP MẪU GIÀY BÁN CHẠY NHẤT:\n";

            if (topSellingList.Any())
            {
                foreach (var item in topSellingList)
                {
                    reportContent += $" Top {item.Rank}. {item.ShoeName} ({item.CategoryName})\n" +
                                     $"    - Số lượng bán : {item.QuantitySold} đôi\n" +
                                     $"    - Doanh thu    : {item.TotalRevenue:N0} VNĐ\n";
                }
            }

            reportContent += $"========================================\n" +
                             $"Người Lập Báo Cáo: Quản Trị Viên (Admin)\n";

            try
            {
                string fileName = $"BaoCao_DoanhThu_{reportCode}.txt";
                using (FormInvoicePreview previewForm = new FormInvoicePreview("Báo Cáo Doanh Thu", reportContent, fileName))
                {
                    previewForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void panelChartCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int width = panelChartCanvas.Width;
            int height = panelChartCanvas.Height;

            // Xóa nền trắng sạch sẽ
            g.Clear(Color.White);

            // Kiểm tra nếu chưa có dữ liệu biểu đồ
            if (topSellingList == null || topSellingList.Count == 0)
            {
                using (Font font = new Font("Segoe UI", 11, FontStyle.Regular))
                {
                    using (Brush brush = new SolidBrush(Color.Gray))
                    {
                        g.DrawString("Chưa có dữ liệu biểu đồ doanh thu", font, brush, new PointF(30, height / 2 - 10));
                    }
                }
                return;
            }

            // Thiết lập thông số hiển thị
            int paddingLeft = 50;
            int paddingBottom = 40;
            int paddingTop = 30;
            int availableWidth = width - paddingLeft - 30;

            int count = topSellingList.Count;
            int barWidth = Math.Max(35, availableWidth / (count * 2));
            int spacing = (availableWidth - (barWidth * count)) / Math.Max(1, count + 1);

            decimal maxRevenue = topSellingList.Max(x => x.TotalRevenue);
            if (maxRevenue <= 0) maxRevenue = 1000000; // Tránh chia cho 0

            int chartHeight = height - paddingBottom - paddingTop;

            for (int i = 0; i < count; i++)
            {
                var item = topSellingList[i];

                // Tính chiều cao cột theo tỷ lệ doanh thu thực tế
                int barHeight = (int)((item.TotalRevenue / (decimal)maxRevenue) * chartHeight);
                if (barHeight < 15) barHeight = 15; // Đảm bảo cột tối thiểu luôn hiển thị

                // Tính tọa độ X, Y chuẩn xác nằm gọn trong khung panel
                int x = paddingLeft + spacing + i * (barWidth + spacing);
                int y = height - paddingBottom - barHeight;

                // Vẽ cột hình chữ nhật với màu gradient Indigo đẹp mắt
                using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Rectangle(x, y, barWidth, barHeight), Color.FromArgb(79, 70, 229), Color.FromArgb(99, 102, 241), 90f))
                {
                    g.FillRectangle(brush, x, y, barWidth, barHeight);
                }

                // Vẽ nhãn tên (Top 1, Top 2...) bên dưới cột
                using (Font font = new Font("Segoe UI", 9, FontStyle.Bold))
                {
                    string label = $"Top {item.Rank}";
                    SizeF textSize = g.MeasureString(label, font);
                    float textX = x + (barWidth - textSize.Width) / 2;
                    g.DrawString(label, font, Brushes.DarkSlateGray, new PointF(textX, height - paddingBottom + 8));
                }
            }
        }
    }
}