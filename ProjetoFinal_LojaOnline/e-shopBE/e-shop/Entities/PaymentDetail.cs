using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_shop.Entities
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int UserId { get; set; }

        [Required]
        public string? CardOwnerName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(16)]
        public string? CardNumber { get; set; }

        [Required]
        [MaxLength(5)]
        public string? ExpirationDate { get; set; }

        [Required]
        [MaxLength(3)]
        public string? SecurityCode { get; set; }
    }
}
