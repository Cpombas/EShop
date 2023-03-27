using e_shop.Entities;
using System.ComponentModel.DataAnnotations;

namespace e_shop.Models
{
    public class ListProductsDTO
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string? Brand { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public ListProductsDTO() { }
        public ListProductsDTO(Products items)
        {
            ProductId = items.ProductId;
            Name = items.Name;
            Price = items.Price;
            Brand = items.Brand;
            Description = items.Description;
            CategoryId = items.CategoryId;
        }
    }

    public class CreateProductDTO
    {
        [Required]
        public string? Name { get; set; }

        public float Price { get; set; }

        public string? Brand { get; set; }

        public string? Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }

    public class UpdateProductDTO 
    {
        public int ProductId { get; set; }

        [Required]
        public string? Name { get; set; }

        public float Price { get; set; }

        public string? Brand { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }
    }
}
