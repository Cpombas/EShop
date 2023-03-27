using e_shop.DbContexts;
using e_shop.Entities;
using e_shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing.Drawing2D;

namespace e_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EShopContext _context;

        public ProductsController(EShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ListProductsDTO>> Get()
        {
            var products = await _context.Products. //Include("Category").
                Select(i => new ListProductsDTO(i)).ToListAsync();

            return products;
        }

        [HttpGet("id")]

        public async Task<IActionResult> GetProdcutByID(int id)
        {
            var product = await _context.Products.//Include("Category").
                FirstOrDefaultAsync(i => i.ProductId == id);

            return product == null ? NotFound() : Ok(new ListProductsDTO(product));
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await _context.Products.//Include("Caegory").
                FirstOrDefaultAsync(i => i.Name == name);

            return product == null ? NotFound() : Ok(new ListProductsDTO(product));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateItem(CreateProductDTO product)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newProduct = new Products
            {
                Name = product.Name,
                Price = product.Price,
                Brand = product.Brand,
                Description = product.Description,
                CategoryId = product.CategoryId
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdcutByID), new { id = newProduct.ProductId }, product);
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDTO product)
        {
            if (id != product.ProductId) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var productDB = _context.Products.Find(id);

            productDB.Name = product.Name;
            productDB.Price = product.Price;
            productDB.Brand = product.Brand;
            productDB.Description = product.Description;
            productDB.CategoryId = product.CategoryId;

            _context.Entry(productDB).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
