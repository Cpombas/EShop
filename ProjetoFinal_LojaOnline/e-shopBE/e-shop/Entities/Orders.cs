using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_shop.Entities
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int UserId { get; set; }

        public DateTime DateOfOrder { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public float TotalPrice { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderStatus { get; set; }

    }
}
