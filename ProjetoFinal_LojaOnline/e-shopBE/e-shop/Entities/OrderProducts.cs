using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_shop.Entities
{
    public class OrderProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderProductId { get; set; }

        [ForeignKey("OrderId")]
        public Orders? Order { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("ProductId")]
        public Products? Product { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

    }
}
