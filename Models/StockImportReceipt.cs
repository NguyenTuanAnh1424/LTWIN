using System;
using System.Collections.Generic;

namespace LTWIN.Models
{
    public class StockImportReceipt
    {
        public string ReceiptCode { get; set; } = null!;
        public DateTime ImportDate { get; set; }
        public string SupplierName { get; set; } = null!;
        public string CreatedBy { get; set; } = "Admin Quản Trị";
        public decimal TotalImportAmount { get; set; }
        public string? Note { get; set; }
        public string ReceiptContent { get; set; } = null!;
        public List<StockImportDetail> Items { get; set; } = new List<StockImportDetail>();
    }

    public class StockImportDetail
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ImportUnitPrice { get; set; }
        public int ImportQuantity { get; set; }
        public decimal TotalPrice => ImportUnitPrice * ImportQuantity;
    }
}
