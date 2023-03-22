using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_shop.Entities
{
    public class OrderHistory
    {

        [ForeignKey("OrderId")]
        public Orders? Order { get; set; }

        [Key]
        public int OrderId { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public float TotalPrice { get; set; }


    }
}
