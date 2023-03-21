using e_shop.DbContexts;
using e_shop.Entities;
using e_shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using static e_shop.Models.ListCategoryDTO;

namespace e_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly EShopContext _context;

        public CategoryController(EShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ListCategoryDTO>> GetCategories()
        {
            var categories = await _context.Category.
                Select(c => new ListCategoryDTO(c)).ToListAsync();

            return categories;
        }

        [HttpGet("id")]

        public async Task<IActionResult> GetCategoryByID(int id)
        {
            var category = await _context.Category.
                FirstOrDefaultAsync(c => c.CategoryId == id);

            return category == null ? NotFound() : Ok(new ListCategoryDTO(category));
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var category = await _context.Category.
                FirstOrDefaultAsync(c => c.Name == name);

            return category == null ? NotFound() : Ok(new ListCategoryDTO(category));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO category)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newCategory = new Category
            {
                Name = category.Name
            };

            await _context.Category.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoryByID), new { id = newCategory.CategoryId }, category);
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDTO category)
        {
            if (id != category.CategoryId) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var categoryDB = _context.Category.Find(id);

            categoryDB.Name = category.Name;
            categoryDB.CategoryId = category.CategoryId;

            _context.Entry(categoryDB).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
                return NotFound();

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
