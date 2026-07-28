using System;
using System.Collections.Generic;
using LTWIN.Models;

namespace LTWIN.Services
{
    public static class StockImportStore
    {
        public static List<StockImportReceipt> ImportHistory { get; private set; }
        public static List<string> Suppliers { get; private set; }

        static StockImportStore()
        {
            ImportHistory = new List<StockImportReceipt>();
            Suppliers = new List<string>
            {
                "Tổng Công Ty Nike Việt Nam",
                "Nhà Phân Phối Adidas Đông Nam Á",
                "Công Ty XNK Thể Thao Puma VN",
                "Nhà Cung Cấp Giày Hàng Nhập Khẩu An Phước"
            };

            InitMockImportData();
        }

        private static void InitMockImportData()
        {
            ImportHistory.Add(new StockImportReceipt
            {
                ReceiptCode = "NK20260725001",
                ImportDate = DateTime.Now.AddDays(-3),
                SupplierName = "Tổng Công Ty Nike Việt Nam",
                CreatedBy = "Admin Quản Trị",
                TotalImportAmount = 58400000,
                Note = "Nhập kho hàng mẫu giày đợt 1 tháng 7",
                Items = new List<StockImportDetail>
                {
                    new StockImportDetail { ProductId = 1, ProductName = "Nike Air Max 270 React", ImportUnitPrice = 2400000, ImportQuantity = 15 },
                    new StockImportDetail { ProductId = 3, ProductName = "Air Jordan 1 Retro High", ImportUnitPrice = 3200000, ImportQuantity = 7 }
                },
                ReceiptContent = "========================================\n" +
                                 "       PHIẾU NHẬP KHO HÀNG GIÀY         \n" +
                                 "========================================\n" +
                                 "Mã Phiếu : NK20260725001\n" +
                                 "Nhà CC   : Tổng Công Ty Nike Việt Nam\n" +
                                 "• Nike Air Max 270 React: 15 đôi x 2.400.000 VNĐ = 36.000.000 VNĐ\n" +
                                 "• Air Jordan 1 Retro High: 7 đôi x 3.200.000 VNĐ = 22.400.000 VNĐ\n" +
                                 "TỔNG GIÁ TRỊ NHẬP: 58.400.000 VNĐ\n"
            });
        }

        public static void AddReceipt(StockImportReceipt receipt)
        {
            ImportHistory.Insert(0, receipt);
        }
    }
}
