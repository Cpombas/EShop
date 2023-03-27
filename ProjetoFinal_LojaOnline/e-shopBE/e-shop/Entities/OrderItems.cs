using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_shop.Entities
{
    public class OrderItems
    {
        [ForeignKey("OrderId")]
        public Orders? Order { get; set; }

        [Key]
        public int OrderId { get; set; }

        [ForeignKey("ItemId")]
        public Products? Item { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

    }
}
