using System;
using System.Collections.Generic;

namespace LTWIN.Models
{
    public class POSOrderRecord
    {
        public string InvoiceCode { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = null!;
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal CustomerMoney { get; set; }
        public decimal ChangeMoney { get; set; }
        public string Status { get; set; } = "Hoàn Thành";
        public string InvoiceContent { get; set; } = null!;
        public List<POSCartItemRecord> Items { get; set; } = new List<POSCartItemRecord>();
    }

    public class POSCartItemRecord
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
