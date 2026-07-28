using System;
using System.Collections.Generic;

namespace LTWIN.Models
{
    /// <summary>
    /// THỰC THỂ KHÁCH HÀNG (CUSTOMER.CS)
    /// Lưu trữ thông tin khách hàng, số điện thoại, địa chỉ và điểm tích lũy mua giày.
    /// </summary>
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FullName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; }

        public string? Address { get; set; }

        public int RewardPoints { get; set; } = 0;

        /// <summary>
        /// Thuộc tính tự động tính Hạng khách hàng dựa theo Điểm tích lũy:
        /// - 0 - 99 điểm: Hạng Đồng
        /// - 100 - 299 điểm: Hạng Bạc
        /// - 300 - 499 điểm: Hạng Vàng
        /// - Từ 500 điểm trở lên: Hạng Kim Cương
        /// </summary>
        public string CustomerTier
        {
            get
            {
                if (RewardPoints >= 500) return "💎 Kim Cương";
                if (RewardPoints >= 300) return "🥇 Vàng";
                if (RewardPoints >= 100) return "🥈 Bạc";
                return "🥉 Đồng";
            }
        }
    }
}
