using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LTWIN.Models;
using LTWIN.Services;
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

        public class ChartPoint
        {
            public string Label { get; set; } = string.Empty;
            public decimal Value { get; set; }
        }

        private List<TopSellingItem> topSellingList;
        private List<ChartPoint> chartPoints;

        public FormReport()
        {
            InitializeComponent();
            topSellingList = new List<TopSellingItem>();
            chartPoints = new List<ChartPoint>();
            InitReportMockData();
        }

        private void InitReportMockData()
        {
            topSellingList = new List<TopSellingItem>
            {
                new TopSellingItem { Rank = 1, ShoeName = "Nike Air Max 270 React", CategoryName = "Giày Chạy Bộ", QuantitySold = 18, TotalRevenue = 57600000 },
                new TopSellingItem { Rank = 2, ShoeName = "Air Jordan 1 Retro High", CategoryName = "Giày Basketball", QuantitySold = 12, TotalRevenue = 54000000 },
                new TopSellingItem { Rank = 3, ShoeName = "Adidas Ultraboost 22", CategoryName = "Giày Chạy Bộ", QuantitySold = 10, TotalRevenue = 38500000 },
                new TopSellingItem { Rank = 4, ShoeName = "Puma RS-X Reinvent", CategoryName = "Giày Sneaker", QuantitySold = 8, TotalRevenue = 19920000 }
            };
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvTopSelling);
            ThemeHelper.AddHoverEffect(btnExportReport, Color.FromArgb(46, 213, 115), Color.FromArgb(38, 180, 98));
            cmbTimeFilter.SelectedIndex = 0;
            LoadReportData();
        }

        private void LoadReportData()
        {
            int filterIndex = cmbTimeFilter.SelectedIndex;

            // 1. Tải số liệu tổng quan
            decimal baseRevenue = topSellingList.Sum(x => x.TotalRevenue);
            int baseShoesSold = topSellingList.Sum(x => x.QuantitySold);
            int baseOrders = 48;

            // Tích hợp thêm từ OrderStore thực tế
            var posOrders = OrderStore.OrderHistory?.Where(o => o.Status == "Hoàn Thành").ToList();
            if (posOrders != null && posOrders.Count > 0)
            {
                baseRevenue += posOrders.Sum(o => o.GrandTotal);
                baseOrders += posOrders.Count;
                baseShoesSold += posOrders.Sum(o => o.Items.Sum(i => i.Quantity));
            }

            decimal totalRevenue = baseRevenue;
            int totalOrders = baseOrders;
            int totalShoesSold = baseShoesSold;

            // Lọc theo mốc thời gian
            if (filterIndex == 1) // Hôm nay
            {
                totalRevenue = Math.Round(baseRevenue * 0.18m);
                totalOrders = 9;
                totalShoesSold = 12;
            }
            else if (filterIndex == 2) // 7 ngày qua
            {
                totalRevenue = Math.Round(baseRevenue * 0.55m);
                totalOrders = 28;
                totalShoesSold = 34;
            }
            else if (filterIndex == 3) // Tháng này
            {
                totalRevenue = Math.Round(baseRevenue * 0.85m);
                totalOrders = 41;
                totalShoesSold = 42;
            }

            decimal avgOrderValue = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            lblCard1Value.Text = totalRevenue.ToString("N0") + " VNĐ";
            lblCard2Value.Text = totalOrders + " Đơn";
            lblCard3Value.Text = totalShoesSold + " Đôi";
            lblCard4Value.Text = avgOrderValue.ToString("N0") + " VNĐ";

            // 2. Tải danh sách Top sản phẩm bán chạy
            var displayData = topSellingList.Select(x => new
            {
                Hạng = "Top " + x.Rank,
                Mẫu_Giày = x.ShoeName,
                Đã_Bán = x.QuantitySold + " đôi",
                Doanh_Thu = x.TotalRevenue.ToString("N0") + " VNĐ"
            }).ToList();

            dgvTopSelling.DataSource = displayData;

            // 3. Chuẩn bị điểm dữ liệu vẽ biểu đồ
            chartPoints.Clear();
            if (filterIndex == 1) // Hôm nay
            {
                chartPoints.Add(new ChartPoint { Label = "08:00", Value = 2500000 });
                chartPoints.Add(new ChartPoint { Label = "10:00", Value = 4800000 });
                chartPoints.Add(new ChartPoint { Label = "12:00", Value = 7200000 });
                chartPoints.Add(new ChartPoint { Label = "14:00", Value = 3900000 });
                chartPoints.Add(new ChartPoint { Label = "16:00", Value = 6100000 });
                chartPoints.Add(new ChartPoint { Label = "18:00", Value = 8500000 });
                chartPoints.Add(new ChartPoint { Label = "20:00", Value = 5400000 });
            }
            else if (filterIndex == 2) // 7 ngày qua
            {
                chartPoints.Add(new ChartPoint { Label = "Thứ 2", Value = 14500000 });
                chartPoints.Add(new ChartPoint { Label = "Thứ 3", Value = 18200000 });
                chartPoints.Add(new ChartPoint { Label = "Thứ 4", Value = 12900000 });
                chartPoints.Add(new ChartPoint { Label = "Thứ 5", Value = 21000000 });
                chartPoints.Add(new ChartPoint { Label = "Thứ 6", Value = 26500000 });
                chartPoints.Add(new ChartPoint { Label = "Thứ 7", Value = 34000000 });
                chartPoints.Add(new ChartPoint { Label = "Chủ Nhật", Value = 29800000 });
            }
            else if (filterIndex == 3) // Tháng này
            {
                chartPoints.Add(new ChartPoint { Label = "Tuần 1", Value = 38000000 });
                chartPoints.Add(new ChartPoint { Label = "Tuần 2", Value = 42500000 });
                chartPoints.Add(new ChartPoint { Label = "Tuần 3", Value = 49000000 });
                chartPoints.Add(new ChartPoint { Label = "Tuần 4", Value = 55200000 });
            }
            else // Tất cả thời gian (6 tháng)
            {
                chartPoints.Add(new ChartPoint { Label = "Tháng 3", Value = 24000000 });
                chartPoints.Add(new ChartPoint { Label = "Tháng 4", Value = 31000000 });
                chartPoints.Add(new ChartPoint { Label = "Tháng 5", Value = 28500000 });
                chartPoints.Add(new ChartPoint { Label = "Tháng 6", Value = 39000000 });
                chartPoints.Add(new ChartPoint { Label = "Tháng 7", Value = 45500000 });
                chartPoints.Add(new ChartPoint { Label = "Tháng 8", Value = 57600000 });
            }

            panelChartCanvas.Invalidate();
        }

        private void panelChartCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            int width = panelChartCanvas.Width;
            int height = panelChartCanvas.Height;

            int paddingLeft = 45;
            int paddingRight = 20;
            int paddingTop = 30;
            int paddingBottom = 40;

            int chartWidth = width - paddingLeft - paddingRight;
            int chartHeight = height - paddingTop - paddingBottom;

            if (chartWidth <= 0 || chartHeight <= 0 || chartPoints == null || chartPoints.Count == 0)
                return;

            decimal maxValue = chartPoints.Max(p => p.Value);
            if (maxValue <= 0) maxValue = 1;

            // 1. Vẽ các đường kẻ ngang (Gridlines)
            using (Pen gridPen = new Pen(Color.FromArgb(241, 245, 249), 1))
            {
                gridPen.DashStyle = DashStyle.Dash;
                int linesCount = 4;
                for (int i = 0; i <= linesCount; i++)
                {
                    int y = paddingTop + (chartHeight * i / linesCount);
                    g.DrawLine(gridPen, paddingLeft, y, width - paddingRight, y);
                }
            }

            // 2. Vẽ các cột doanh thu (Bar Chart)
            int count = chartPoints.Count;
            int totalBarSpace = chartWidth / count;
            int barWidth = Math.Max(12, (int)(totalBarSpace * 0.55));

            using (Font fontLabel = new Font("Segoe UI", 8.5F, FontStyle.Regular))
            using (Font fontValue = new Font("Segoe UI", 8.0F, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
            using (Brush valueBrush = new SolidBrush(Color.FromArgb(79, 70, 229)))
            {
                for (int i = 0; i < count; i++)
                {
                    var pt = chartPoints[i];
                    float ratio = (float)(pt.Value / maxValue);
                    int barH = (int)(chartHeight * ratio);

                    int x = paddingLeft + (i * totalBarSpace) + (totalBarSpace - barWidth) / 2;
                    int y = paddingTop + (chartHeight - barH);

                    // Gradient fill cho cột
                    using (LinearGradientBrush barBrush = new LinearGradientBrush(
                        new Rectangle(x, y, barWidth, Math.Max(1, barH)),
                        Color.FromArgb(79, 70, 229),
                        Color.FromArgb(129, 140, 248),
                        LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(barBrush, x, y, barWidth, Math.Max(1, barH));
                    }

                    // Viền đỉnh cột
                    using (Pen topPen = new Pen(Color.FromArgb(67, 56, 202), 1.5f))
                    {
                        g.DrawLine(topPen, x, y, x + barWidth, y);
                    }

                    // Hiển thị giá trị trên đỉnh cột (Triệu VNĐ)
                    string valText = (pt.Value / 1000000m).ToString("0.#") + "M";
                    SizeF valSize = g.MeasureString(valText, fontValue);
                    g.DrawString(valText, fontValue, valueBrush, x + (barWidth - valSize.Width) / 2, y - valSize.Height - 3);

                    // Hiển thị nhãn mốc thời gian dưới trục X
                    SizeF lblSize = g.MeasureString(pt.Label, fontLabel);
                    g.DrawString(pt.Label, fontLabel, textBrush, x + (barWidth - lblSize.Width) / 2, height - paddingBottom + 8);
                }
            }

            // 3. Vẽ trục hoành X
            using (Pen axisPen = new Pen(Color.FromArgb(203, 213, 225), 1.5f))
            {
                g.DrawLine(axisPen, paddingLeft, height - paddingBottom, width - paddingRight, height - paddingBottom);
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
                                   $"    BÁO CÁO DOANH THU CỬA HÀNG GIÀY     \n" +
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

            foreach (var item in topSellingList)
            {
                reportContent += $" Top {item.Rank}. {item.ShoeName} ({item.CategoryName})\n" +
                                 $"    - Số lượng bán : {item.QuantitySold} đôi\n" +
                                 $"    - Doanh thu    : {item.TotalRevenue:N0} VNĐ\n";
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
