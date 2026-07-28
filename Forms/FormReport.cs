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

        private List<TopSellingItem> topSellingList;

        public FormReport()
        {
            InitializeComponent();
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
            cmbTimeFilter.SelectedIndex = 0;
            LoadReportData();
        }

        private void LoadReportData()
        {
            decimal totalRevenue = topSellingList.Sum(x => x.TotalRevenue);
            int totalShoesSold = topSellingList.Sum(x => x.QuantitySold);
            int totalOrders = 48;
            decimal avgOrderValue = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            lblCard1Value.Text = totalRevenue.ToString("N0") + " VNĐ";
            lblCard2Value.Text = totalOrders + " Đơn";
            lblCard3Value.Text = totalShoesSold + " Đôi";
            lblCard4Value.Text = avgOrderValue.ToString("N0") + " VNĐ";

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
