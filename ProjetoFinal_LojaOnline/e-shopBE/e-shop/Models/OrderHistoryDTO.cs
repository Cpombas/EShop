using e_shop.Entities;

namespace e_shop.Models
{
    public class ListOrderHistoryDTO
    {
        public int OrderId { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public float TotalPrice { get; set; }

        public ListOrderHistoryDTO() { }

        public ListOrderHistoryDTO(OrderHistory orderHistory)
        {
            OrderId = orderHistory.OrderId;
            DateOfDelivery= orderHistory.DateOfDelivery;
            TotalPrice = orderHistory.TotalPrice;
        }
    }

    public class CreateOrderHistoryDTO
    {
        public int OrderId { get; set; }

        public DateTime DateOfDelivery { get; set;}

        public float TotalPrice { get; set; }
    }

    public class UpdateOrderHistoryDTO 
    {
        public int OrderId { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public float TotalPrice { get; set; }
    }
}
