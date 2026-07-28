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
    public partial class FormOrderHistory : Form
    {
        private List<POSOrderRecord> currentFilteredOrders;

        public FormOrderHistory()
        {
            InitializeComponent();
            currentFilteredOrders = new List<POSOrderRecord>();
        }

        private void FormOrderHistory_Load(object sender, EventArgs e)
        {
            ThemeHelper.StyleDataGridView(dgvOrders);
            ThemeHelper.StyleDataGridView(dgvOrderDetails);
            cmbTimeFilter.SelectedIndex = 0;
            LoadOrderList();
        }

        private void LoadOrderList()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            int timeOption = cmbTimeFilter.SelectedIndex;

            var list = OrderStore.OrderHistory.AsEnumerable();

            if (!string.IsNullOrEmpty(keyword))
            {
                list = list.Where(o => o.InvoiceCode.ToLower().Contains(keyword) || o.CustomerName.ToLower().Contains(keyword));
            }

            if (timeOption == 1) // Hôm nay
            {
                list = list.Where(o => o.OrderDate.Date == DateTime.Today);
            }
            else if (timeOption == 2) // 7 ngày gần đây
            {
                list = list.Where(o => o.OrderDate.Date >= DateTime.Today.AddDays(-7));
            }
            else if (timeOption == 3) // Tháng này
            {
                list = list.Where(o => o.OrderDate.Month == DateTime.Today.Month && o.OrderDate.Year == DateTime.Today.Year);
            }

            currentFilteredOrders = list.ToList();

            var displayData = currentFilteredOrders.Select(o => new
            {
                Mã_Hóa_Đơn = o.InvoiceCode,
                Thời_Gian = o.OrderDate.ToString("dd/MM/yyyy HH:mm"),
                Khách_Hàng = o.CustomerName,
                Tổng_Tiền_Hàng = o.SubTotal.ToString("N0") + " VNĐ",
                Chiết_Khấu = o.Discount.ToString("N0") + " VNĐ",
                Tổng_Thanh_Toán = o.GrandTotal.ToString("N0") + " VNĐ",
                Trạng_Thái = o.Status
            }).ToList();

            dgvOrders.DataSource = displayData;

            decimal totalRevenue = currentFilteredOrders.Where(o => o.Status == "Hoàn Thành").Sum(o => o.GrandTotal);
            lblSummary.Text = $"📊 Tổng cộng: {currentFilteredOrders.Count} đơn hàng | Doanh thu thực nhận: {totalRevenue:N0} VNĐ";

            if (!currentFilteredOrders.Any())
            {
                dgvOrderDetails.DataSource = null;
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int index = dgvOrders.SelectedRows[0].Index;
                if (index >= 0 && index < currentFilteredOrders.Count)
                {
                    var selectedOrder = currentFilteredOrders[index];
                    DisplayOrderDetails(selectedOrder);
                }
            }
            else
            {
                dgvOrderDetails.DataSource = null;
            }
        }

        private void DisplayOrderDetails(POSOrderRecord order)
        {
            var displayDetails = order.Items.Select(i => new
            {
                Mã_SP = i.ProductId,
                Tên_Mẫu_Giày = i.ProductName,
                Đơn_Giá = i.UnitPrice.ToString("N0") + " VNĐ",
                Số_Lượng = i.Quantity + " đôi",
                Thành_Tiền = i.TotalPrice.ToString("N0") + " VNĐ"
            }).ToList();

            dgvOrderDetails.DataSource = displayDetails;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        private void cmbTimeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        private void btnRePrint_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int index = dgvOrders.SelectedRows[0].Index;
                if (index >= 0 && index < currentFilteredOrders.Count)
                {
                    var selectedOrder = currentFilteredOrders[index];
                    string fileName = $"InLai_{selectedOrder.InvoiceCode}.txt";

                    using (FormInvoicePreview previewForm = new FormInvoicePreview("In Lại Hóa Đơn " + selectedOrder.InvoiceCode, selectedOrder.InvoiceContent, fileName))
                    {
                        previewForm.ShowDialog(this);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hóa đơn cần xem hoặc in lại!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int index = dgvOrders.SelectedRows[0].Index;
                if (index >= 0 && index < currentFilteredOrders.Count)
                {
                    var selectedOrder = currentFilteredOrders[index];

                    if (selectedOrder.Status == "Đã Hủy")
                    {
                        MessageBox.Show("Hóa đơn này đã được hủy trước đó!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var confirm = MessageBox.Show($"Bạn có chắc chắn muốn HỦY HÓA ĐƠN '{selectedOrder.InvoiceCode}' này không?", 
                                                  "Xác Nhận Hủy Đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        selectedOrder.Status = "Đã Hủy";
                        MessageBox.Show($"✅ Đã hủy hóa đơn '{selectedOrder.InvoiceCode}' thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrderList();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hóa đơn cần hủy!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
