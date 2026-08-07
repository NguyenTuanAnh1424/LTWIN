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

            int paddingLeft = 55;
            int paddingRight = 25;
            int paddingTop = 35;
            int paddingBottom = 45;

            int chartWidth = width - paddingLeft - paddingRight;
            int chartHeight = height - paddingTop - paddingBottom;

            if (chartWidth <= 0 || chartHeight <= 0 || chartPoints == null || chartPoints.Count == 0)
                return;

            decimal maxValue = chartPoints.Max(p => p.Value);
            if (maxValue <= 0) maxValue = 1;

            // Tìm cột có doanh thu cao nhất
            decimal peakVal = chartPoints.Max(p => p.Value);

            // 1. Vẽ các đường kẻ ngang (Gridlines) & Nhãn trục Y (Triệu VNĐ)
            int linesCount = 4;
            using (Font yFont = new Font("Segoe UI", 8.0F, FontStyle.Regular))
            using (Brush yBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
            using (Pen gridPen = new Pen(Color.FromArgb(241, 245, 249), 1f))
            {
                gridPen.DashStyle = DashStyle.Dash;
                for (int i = 0; i <= linesCount; i++)
                {
                    int y = paddingTop + (chartHeight * i / linesCount);
                    g.DrawLine(gridPen, paddingLeft, y, width - paddingRight, y);

                    // Nhãn trục Y
                    decimal gridVal = maxValue * (linesCount - i) / linesCount;
                    string yText = (gridVal / 1000000m).ToString("0.#") + "M";
                    SizeF ySize = g.MeasureString(yText, yFont);
                    g.DrawString(yText, yFont, yBrush, paddingLeft - ySize.Width - 8, y - ySize.Height / 2);
                }
            }

            // 2. Tính tọa độ đỉnh của từng cột để vẽ Cột + Đường xu hướng
            int count = chartPoints.Count;
            int totalBarSpace = chartWidth / count;
            int barWidth = Math.Max(16, (int)(totalBarSpace * 0.50));

            PointF[] trendPoints = new PointF[count];

            using (Font fontLabel = new Font("Segoe UI", 8.5F, FontStyle.Regular))
            using (Font fontValue = new Font("Segoe UI", 8.0F, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
            {
                for (int i = 0; i < count; i++)
                {
                    var pt = chartPoints[i];
                    float ratio = (float)(pt.Value / maxValue);
                    int barH = (int)(chartHeight * ratio);

                    int x = paddingLeft + (i * totalBarSpace) + (totalBarSpace - barWidth) / 2;
                    int y = paddingTop + (chartHeight - barH);

                    bool isPeak = pt.Value == peakVal && peakVal > 0;

                    // Lưu tọa độ tâm đỉnh cột cho đường xu hướng
                    trendPoints[i] = new PointF(x + barWidth / 2f, y);

                    // Bán kính bo góc đỉnh cột
                    int radius = Math.Min(6, barWidth / 2);

                    // Đường dẫn hình học cột bo góc đỉnh
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        if (barH > radius * 2)
                        {
                            path.AddArc(x, y, radius * 2, radius * 2, 180, 90);
                            path.AddArc(x + barWidth - radius * 2, y, radius * 2, radius * 2, 270, 90);
                            path.AddLine(x + barWidth, y + radius, x + barWidth, paddingTop + chartHeight);
                            path.AddLine(x + barWidth, paddingTop + chartHeight, x, paddingTop + chartHeight);
                            path.CloseFigure();
                        }
                        else
                        {
                            path.AddRectangle(new Rectangle(x, y, barWidth, Math.Max(2, barH)));
                        }

                        // Gradient fill cho cột
                        Color colStart = isPeak ? Color.FromArgb(99, 102, 241) : Color.FromArgb(129, 140, 248);
                        Color colEnd = isPeak ? Color.FromArgb(79, 70, 229) : Color.FromArgb(199, 210, 254);

                        using (LinearGradientBrush barBrush = new LinearGradientBrush(
                            new Rectangle(x, y, barWidth, Math.Max(2, barH)),
                            colStart, colEnd, LinearGradientMode.Vertical))
                        {
                            g.FillPath(barBrush, path);
                        }

                        // Viền cột peak (nút cao nhất)
                        if (isPeak)
                        {
                            using (Pen peakPen = new Pen(Color.FromArgb(67, 56, 202), 1.5f))
                            {
                                g.DrawPath(peakPen, path);
                            }
                        }
                    }

                    // Hiển thị nhãn mốc thời gian dưới trục X
                    SizeF lblSize = g.MeasureString(pt.Label, fontLabel);
                    g.DrawString(pt.Label, fontLabel, textBrush, x + (barWidth - lblSize.Width) / 2, height - paddingBottom + 10);
                }

                // 3. Vẽ Đường Xu Hướng Spline Mượt Mà (Bezier Curve) đè lên đỉnh các cột
                if (count > 1)
                {
                    using (Pen linePen = new Pen(Color.FromArgb(16, 185, 129), 2.5f)) // Màu xanh Ngọc Lục Bảo
                    {
                        linePen.LineJoin = LineJoin.Round;
                        g.DrawCurve(linePen, trendPoints, 0.4f);
                    }

                    // Vẽ các nút điểm tròn trên đường xu hướng
                    for (int i = 0; i < count; i++)
                    {
                        var pt = chartPoints[i];
                        PointF tp = trendPoints[i];
                        bool isPeak = pt.Value == peakVal && peakVal > 0;

                        float dotSize = isPeak ? 9f : 7f;
                        RectangleF dotRect = new RectangleF(tp.X - dotSize / 2f, tp.Y - dotSize / 2f, dotSize, dotSize);

                        using (Brush dotBrush = new SolidBrush(isPeak ? Color.FromArgb(239, 68, 68) : Color.FromArgb(16, 185, 129)))
                        using (Pen dotBorderPen = new Pen(Color.White, 2f))
                        {
                            g.FillEllipse(dotBrush, dotRect);
                            g.DrawEllipse(dotBorderPen, dotRect);
                        }

                        // Hiển thị Badge giá trị mượt trên đỉnh điểm
                        string valText = (pt.Value / 1000000m).ToString("0.#") + "M";
                        SizeF valSize = g.MeasureString(valText, fontValue);

                        int badgePaddingH = 5;
                        int badgePaddingV = 2;
                        RectangleF badgeBg = new RectangleF(
                            tp.X - valSize.Width / 2f - badgePaddingH,
                            tp.Y - valSize.Height - 12f,
                            valSize.Width + badgePaddingH * 2,
                            valSize.Height + badgePaddingV * 2);

                        Color badgeBgColor = isPeak ? Color.FromArgb(254, 242, 242) : Color.FromArgb(240, 253, 244);
                        Color badgeTextColor = isPeak ? Color.FromArgb(220, 38, 38) : Color.FromArgb(15, 118, 110);

                        using (GraphicsPath badgePath = ThemeHelper.CreateRoundedRectanglePath(badgeBg, 4))
                        using (Brush bBgBrush = new SolidBrush(badgeBgColor))
                        using (Pen bBorderPen = new Pen(isPeak ? Color.FromArgb(252, 165, 165) : Color.FromArgb(167, 243, 208), 1f))
                        using (Brush bTextBrush = new SolidBrush(badgeTextColor))
                        {
                            g.FillPath(bBgBrush, badgePath);
                            g.DrawPath(bBorderPen, badgePath);
                            g.DrawString(valText, fontValue, bTextBrush, tp.X - valSize.Width / 2f, tp.Y - valSize.Height - 10f);
                        }
                    }
                }
            }

            // 4. Vẽ trục hoành X
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
