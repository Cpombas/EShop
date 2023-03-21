using e_shop.Entities;
using System.ComponentModel.DataAnnotations;

namespace e_shop.Models
{
    public class ListOrdersDTO
    {
        public int OrderId { get; set; }

        public DateTime DateOfOrder { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public float TotalPrice { get; set; }

        public string OrderStatus { get; set; } = string.Empty;

        public ListOrdersDTO() { }

        public ListOrdersDTO(Orders orders)
        {
            OrderId = orders.OrderId;
            DateOfOrder = orders.DateOfOrder;
            DateOfDelivery = orders.DateOfDelivery;
            TotalPrice = orders.TotalPrice;
            OrderStatus = orders.OrderStatus;

        }

    }
    public class CreateOrdersDTO
    {
        public DateTime DateOfOrder { get; set; }

        public DateTime DateOfDelivery { get; set;}

        public float TotalPrice { get; set; }

        public string OrderStatus { get; set; }
    }

    public class UpdateOrdersDTO 
    { 
        public int OrderId { get; set; }

        public DateTime DateOfOrder { get; set;}

        public DateTime DateOfDelivery { get; set;}

        public float TotalPrice { get; set; }

        public string OrderStatus { get; set; }
    }

}
