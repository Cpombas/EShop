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
    public class ItemsController : ControllerBase
    {
        private readonly EShopContext _context;

        public ItemsController(EShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ListItemsDTO>> Get()
        {
            var items = await _context.Items. //Include("Category").
                Select(i => new ListItemsDTO(i)).ToListAsync();

            return items;
        }

        [HttpGet("id")]

        public async Task<IActionResult> GetItemByID(int id)
        {
            var items = await _context.Items.//Include("Category").
                FirstOrDefaultAsync(i => i.ItemId == id);

            return items == null ? NotFound() : Ok(new ListItemsDTO(items));
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetItemByName(string name)
        {
            var items = await _context.Items.//Include("Caegory").
                FirstOrDefaultAsync(i => i.Name == name);

            return items == null ? NotFound() : Ok(new ListItemsDTO(items));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateItem(CreateItemDTO item)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newItem = new Items
            {
                Name = item.Name,
                CategoryId = item.CategoryId
            };

            await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemByID), new { id = newItem.ItemId }, item);
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateItem(int id, UpdateItemDTO item)
        {
            if (id != item.ItemId) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var itemDB = _context.Items.Find(id);

            itemDB.Name = item.Name;
            itemDB.CategoryId = item.CategoryId;

            _context.Entry(itemDB).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
