using e_shop.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_shop.Models
{
    public class ListOrderItemsDTO
    {
        public int OrderId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }


        public ListOrderItemsDTO() { }

        public ListOrderItemsDTO(OrderItems orderItems)
        {
            OrderId = orderItems.OrderId;
            ItemId = orderItems.ItemId;
            Quantity= orderItems.Quantity;
            Price= orderItems.Price;
        }
    }

    public class CreateOrderItemsDTO
    {
        public int OrderId { get; set; }

        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public float Price { get; set; }

    }

    public class UpdateOrderItemsDTO 
    {
        public int OrderId { get; set; }

        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public float Price { get; set; }
    }
}
