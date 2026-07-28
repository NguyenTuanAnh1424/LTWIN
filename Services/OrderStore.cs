using System;
using System.Collections.Generic;
using System.Linq;
using LTWIN.Models;

namespace LTWIN.Services
{
    public static class OrderStore
    {
        public static List<POSOrderRecord> OrderHistory { get; private set; }

        static OrderStore()
        {
            OrderHistory = new List<POSOrderRecord>();
            InitMockOrders();
        }

        private static void InitMockOrders()
        {
            OrderHistory.Add(new POSOrderRecord
            {
                InvoiceCode = "POS202607281001",
                OrderDate = DateTime.Now.AddHours(-2),
                CustomerName = "Nguyễn Văn Hoàng (0988123456)",
                SubTotal = 7050000,
                Discount = 50000,
                GrandTotal = 7000000,
                CustomerMoney = 7000000,
                ChangeMoney = 0,
                Status = "Hoàn Thành",
                Items = new List<POSCartItemRecord>
                {
                    new POSCartItemRecord { ProductId = 1, ProductName = "Nike Air Max 270 React", UnitPrice = 3200000, Quantity = 1 },
                    new POSCartItemRecord { ProductId = 2, ProductName = "Adidas Ultraboost 22", UnitPrice = 3850000, Quantity = 1 }
                },
                InvoiceContent = "========================================\n" +
                                 "       HÓA ĐƠN BÁN HÀNG SNEAKER STORE   \n" +
                                 "========================================\n" +
                                 "Mã Hóa Đơn : POS202607281001\n" +
                                 "Khách hàng : Nguyễn Văn Hoàng (0988123456)\n" +
                                 "• Nike Air Max 270 React: 1 x 3.200.000 VNĐ\n" +
                                 "• Adidas Ultraboost 22: 1 x 3.850.000 VNĐ\n" +
                                 "TỔNG THANH TOÁN: 7.000.000 VNĐ\n"
            });

            OrderHistory.Add(new POSOrderRecord
            {
                InvoiceCode = "POS202607270915",
                OrderDate = DateTime.Now.AddDays(-1),
                CustomerName = "Trần Thị Thu (0912345678)",
                SubTotal = 4500000,
                Discount = 0,
                GrandTotal = 4500000,
                CustomerMoney = 5000000,
                ChangeMoney = 500000,
                Status = "Hoàn Thành",
                Items = new List<POSCartItemRecord>
                {
                    new POSCartItemRecord { ProductId = 3, ProductName = "Air Jordan 1 Retro High", UnitPrice = 4500000, Quantity = 1 }
                },
                InvoiceContent = "========================================\n" +
                                 "       HÓA ĐƠN BÁN HÀNG SNEAKER STORE   \n" +
                                 "========================================\n" +
                                 "Mã Hóa Đơn : POS202607270915\n" +
                                 "Khách hàng : Trần Thị Thu (0912345678)\n" +
                                 "• Air Jordan 1 Retro High: 1 x 4.500.000 VNĐ\n" +
                                 "TỔNG THANH TOÁN: 4.500.000 VNĐ\n"
            });

            OrderHistory.Add(new POSOrderRecord
            {
                InvoiceCode = "POS202607261430",
                OrderDate = DateTime.Now.AddDays(-2),
                CustomerName = "Khách Lẻ (Không Tích Điểm)",
                SubTotal = 2490000,
                Discount = 0,
                GrandTotal = 2490000,
                CustomerMoney = 2500000,
                ChangeMoney = 10000,
                Status = "Đã Hủy",
                Items = new List<POSCartItemRecord>
                {
                    new POSCartItemRecord { ProductId = 4, ProductName = "Puma RS-X Reinvent", UnitPrice = 2490000, Quantity = 1 }
                },
                InvoiceContent = "========================================\n" +
                                 "       HÓA ĐƠN BÁN HÀNG SNEAKER STORE   \n" +
                                 "========================================\n" +
                                 "Mã Hóa Đơn : POS202607261430\n" +
                                 "Khách hàng : Khách Lẻ (Không Tích Điểm)\n" +
                                 "• Puma RS-X Reinvent: 1 x 2.490.000 VNĐ\n" +
                                 "TỔNG THANH TOÁN: 2.490.000 VNĐ\n"
            });
        }

        public static void AddOrder(POSOrderRecord order)
        {
            OrderHistory.Insert(0, order);
        }
    }
}
