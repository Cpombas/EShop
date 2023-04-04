using e_shop.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_shop.Models
{
    public class ListOrderProductsDTO
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }


        public ListOrderProductsDTO() { }

        public ListOrderProductsDTO(OrderProducts orderItems)
        {
            OrderId = orderItems.OrderId;
            ProductId = orderItems.ProductId;
            Quantity= orderItems.Quantity;
            Price= orderItems.Price;
        }
    }

    public class CreateOrderProductsDTO
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public float Price { get; set; }

    }

    public class UpdateOrderProductsDTO
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public float Price { get; set; }
    }
}
