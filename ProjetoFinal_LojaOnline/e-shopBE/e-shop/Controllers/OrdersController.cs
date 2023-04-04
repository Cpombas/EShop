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

        [HttpGet ("ActiveOrders")]
        public async Task<IEnumerable<ListOrdersDTO>> GetActiveOrders()
        {
            var orders = await _context.Orders.
                Select(o => new ListOrdersDTO(o)).ToListAsync();

            return orders;
        }

        [HttpGet("OrderedProducts")]
        public async Task<IEnumerable<ListOrderProductsDTO>> GetOrderedProducts()
        {
            var orders = await _context.OrderProducts.
                Select(o => new ListOrderProductsDTO(o)).ToListAsync();

            return orders;
        }

        [HttpGet("ActiveOrdersByOrderId")]

        public async Task<IActionResult> GetActiveOrdersByOrderId(int id)
        {
            var order = await _context.Orders.
                FirstOrDefaultAsync(o => o.OrderId == id);

            return order == null ? NotFound() : Ok(new ListOrdersDTO(order));
        }

        [HttpGet("OrderedProductsByOrderId")]

        public async Task<IActionResult> GetOrderedProductsByOrderId(int id)
        {
            var order = await _context.OrderProducts.
                FirstOrDefaultAsync(o => o.OrderId == id);

            return order == null ? NotFound() : Ok(new ListOrderProductsDTO(order));
        }

        [HttpGet("ActiveOrdersByUserId")]

        public async Task<IActionResult> GetActiveOrdersByUserId(int id)
        {
            var order = await _context.Orders.
                FirstOrDefaultAsync(o => o.UserId == id);

            return order == null ? NotFound() : Ok(new ListOrdersDTO(order));
        }


        [HttpGet("OrderedProdutsByProductId")]

        public async Task<IActionResult> GetOrderedProdcutsByProductId(int id)
        {
            var order = await _context.OrderProducts.
                FirstOrDefaultAsync(o => o.ProductId == id);

            return order == null ? NotFound() : Ok(new ListOrderProductsDTO(order));
        }

        [HttpPost("ActiveOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateActiveOrder(CreateOrdersDTO order)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newOrder = new Orders
            {
                UserId = order.UserId,
                DateOfOrder = order.DateOfOrder,
                DateOfDelivery = order.DateOfDelivery,
                TotalPrice = order.TotalPrice,
                OrderStatus = order.OrderStatus
            };

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActiveOrdersByOrderId), new { id = newOrder.OrderId }, order);
        }

        [HttpPost("OrderedProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrderedProducts(CreateOrderProductsDTO order)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newOrder = new OrderProducts
            {
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                Price = order.Price
            };

            await _context.OrderProducts.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderedProductsByOrderId), order);
        }

        [HttpPut("ActiveOrdersByOrderId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateActiveOrder(int id, UpdateOrdersDTO order)
        {
            if (id != order.OrderId) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var orderDB = _context.Orders.Find(id);

            orderDB.UserId = order.UserId;
            orderDB.DateOfOrder = order.DateOfOrder;
            orderDB.DateOfDelivery = order.DateOfDelivery;
            orderDB.TotalPrice = order.TotalPrice;
            orderDB.OrderStatus = order.OrderStatus;

            _context.Entry(orderDB).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("OrderedProductsByOrderId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateOrderedProducts(int id, UpdateOrderProductsDTO order)
        {
            if (id != order.OrderProductId) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var orderDB = _context.OrderProducts.Find(id);

            orderDB.OrderId = order.OrderId;
            orderDB.ProductId = order.ProductId;
            orderDB.Quantity = order.Quantity;
            orderDB.Price = order.Price;

            _context.Entry(orderDB).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("ActiveOrderByOrderId")]
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

        [HttpDelete("OrderedProductsByOrderId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteFromOrderedProducts(int id)
        {
            var order = await _context.OrderProducts.FindAsync(id);

            if (order == null)
                return NotFound();

            _context.OrderProducts.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
