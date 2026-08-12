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
    }
}