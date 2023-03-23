using e_shop.Entities;
using System.ComponentModel.DataAnnotations;

namespace e_shop.Models
{
    public class ListItemsDTO
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string? Brand { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public ListItemsDTO() { }
        public ListItemsDTO(Items items)
        {
            ItemId = items.ItemId;
            Name = items.Name;
            Price = items.Price;
            Brand = items.Brand;
            Description = items.Description;
            CategoryId = items.CategoryId;
        }
    }

    public class CreateItemDTO
    {
        [Required]
        public string? Name { get; set; }

        public float Price { get; set; }

        public string? Brand { get; set; }

        public string? Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }

    public class UpdateItemDTO 
    {
        public int ItemId { get; set; }

        [Required]
        public string? Name { get; set; }

        public float Price { get; set; }

        public string? Brand { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }
    }
}
