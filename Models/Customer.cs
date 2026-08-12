using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTWIN.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public int RewardPoints { get; set; } = 0;

        // Tính năng mở rộng: Hạng khách hàng tự động dựa trên điểm
        [NotMapped]
        public string CustomerTier
        {
            get
            {
                if (RewardPoints >= 500) return "Kim Cương";
                if (RewardPoints >= 200) return "Vàng";
                if (RewardPoints >= 50) return "Bạc";
                return "Đồng";
            }
        }
    }
}