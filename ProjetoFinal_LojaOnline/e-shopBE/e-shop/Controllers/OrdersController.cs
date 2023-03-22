using e_shop.DbContexts;
using e_shop.Entities;
using e_shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace e_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly EShopContext _context;

        public OrdersController(EShopContext context)
        {
            _context = context;
        }

        [HttpGet ("Active Orders")]
        public async Task<IEnumerable<ListOrdersDTO>> GetActiveOrders()
        {
            var orders = await _context.Orders.
                Select(o => new ListOrdersDTO(o)).ToListAsync();

            return orders;
        }

        [HttpGet("Ordered Items")]
        public async Task<IEnumerable<ListOrderItemsDTO>> GetOrderedItems()
        {
            var orders = await _context.OrderItems.
                Select(o => new ListOrderItemsDTO(o)).ToListAsync();

            return orders;
        }

        [HttpGet("Order History")]
        public async Task<IEnumerable<ListOrderHistoryDTO>> GetOrderHistory()
        {
            var orders = await _context.OrdersHistory.
                Select(o => new ListOrderHistoryDTO(o)).ToListAsync();

            return orders;
        }

        [HttpGet("Active orders by OrderId")]

        public async Task<IActionResult> GetActiveOrdersByOrderId(int id)
        {
            var order = await _context.Orders.
                FirstOrDefaultAsync(o => o.OrderId == id);

            return order == null ? NotFound() : Ok(new ListOrdersDTO(order));
        }

        [HttpGet("Ordered Items by OrderId")]

        public async Task<IActionResult> GetOrderedItemsByOrderId(int id)
        {
            var order = await _context.OrderItems.
                FirstOrDefaultAsync(o => o.OrderId == id);

            return order == null ? NotFound() : Ok(new ListOrderItemsDTO(order));
        }

        [HttpGet("Order History by OrderId")]

        public async Task<IActionResult> GetOrderHistoryByOrderId(int id)
        {
            var order = await _context.OrdersHistory.
                FirstOrDefaultAsync(o => o.OrderId == id);

            return order == null ? NotFound() : Ok(new ListOrderHistoryDTO(order));
        }

        [HttpGet("Active orders by UserId")]

        public async Task<IActionResult> GetActiveOrdersByUserId(int id)
        {
            var order = await _context.Orders.
                FirstOrDefaultAsync(o => o.UserId == id);

            return order == null ? NotFound() : Ok(new ListOrdersDTO(order));
        }

        //[HttpGet("Order History by UserId")]

        //public async Task<IActionResult> GetOrderHistoryByUserId(int id)
        //{
        //    var order = await _context.OrdersHistory.
        //        FirstOrDefaultAsync(o => o.UserId == id);

        //    return order == null ? NotFound() : Ok(new ListOrderHistoryDTO(order));
        //}

        [HttpGet("Ordered Items by ItemId")]

        public async Task<IActionResult> GetOrderedItemsByUserId(int id)
        {
            var order = await _context.OrderItems.
                FirstOrDefaultAsync(o => o.ItemId == id);

            return order == null ? NotFound() : Ok(new ListOrderItemsDTO(order));
        }

        [HttpPost("Active Order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateActiveOrder(CreateOrdersDTO order)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newOrder = new Orders
            {
                DateOfOrder = order.DateOfOrder,
                DateOfDelivery = order.DateOfDelivery,
                TotalPrice = order.TotalPrice,
                OrderStatus = order.OrderStatus
            };

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActiveOrdersByOrderId), new { id = newOrder.OrderId }, order);
        }

        [HttpPost("Ordered Item")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrderedItem(CreateOrderItemsDTO order)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newOrder = new OrderItems
            {
                OrderId = order.OrderId,
                ItemId = order.ItemId,
                Quantity = order.Quantity,
                Price = order.Price
            };

            await _context.OrderItems.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderedItemsByOrderId), order);
        }

        [HttpPost("Order History")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrdersHistory(CreateOrderHistoryDTO order)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newOrder = new OrderHistory
            {
                OrderId = order.OrderId,
                DateOfDelivery = order.DateOfDelivery,
                TotalPrice = order.TotalPrice

            };

            await _context.OrdersHistory.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderHistoryByOrderId), order);
        }

        [HttpPut("Active Order by OrderId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateActiveOrder(int id, UpdateOrdersDTO order)
        {
            if (id != order.OrderId) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var orderDB = _context.Orders.Find(id);

            orderDB.OrderId = order.OrderId;
            orderDB.OrderStatus = order.OrderStatus;

            _context.Entry(orderDB).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("Ordered Items by OrderId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateOrderedItems(int id, UpdateOrderItemsDTO order)
        {
            if (id != order.OrderId) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var orderDB = _context.Orders.Find(id);

            orderDB.OrderId = order.OrderId;

            _context.Entry(orderDB).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("Order History by OrderId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateOrderHistory(int id, UpdateOrderHistoryDTO order)
        {
            if (id != order.OrderId) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var orderDB = _context.Orders.Find(id);

            orderDB.OrderId = order.OrderId;

            _context.Entry(orderDB).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("Active Order by OrderId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteFromOrders(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("Ordered Item by OrderId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteFormOrderItems(int id)
        {
            var order = await _context.OrderItems.FindAsync(id);

            if (order == null)
                return NotFound();

            _context.OrderItems.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("OrderHistory by OrderId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteFromOrderHistory(int id)
        {
            var order = await _context.OrdersHistory.FindAsync(id);

            if (order == null)
                return NotFound();

            _context.OrdersHistory.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }







    }
}
