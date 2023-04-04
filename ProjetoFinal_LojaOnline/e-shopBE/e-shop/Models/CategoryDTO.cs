using e_shop.Entities;
using Microsoft.Build.Framework;

namespace e_shop.Models
{
    public class ListCategoryDTO
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        //public ICollection<ListItemsDTO> ItemsInCategory { get; set; }
        //    = new List<ListItemsDTO>();

        //public int NumberOfItemsInCategory
        //{
        //    get
        //    {
        //        return ItemsInCategory.Count;
        //    }
        //}

        public ListCategoryDTO() { }

        public ListCategoryDTO(Category category)
        {
            CategoryId = category.CategoryId;
            Name = category.Name;
            ImageName = category.ImageName;
        }
    }

    public class CreateCategoryDTO
    {
        [Required]
        public string? Name { get; set; }

        //public ICollection<ListItemsDTO> ItemsInCategory { get; set; }
        //= new List<ListItemsDTO>();

        public string? ImageName { get; set; }
    }

    public class UpdateCategoryDTO
    {
        public int CategoryId { get; set; }

        [Required]
        public string? Name { get; set; }

        //public ICollection<ListItemsDTO> ItemsInCategory { get; set; }
        //= new List<ListItemsDTO>();

        public string? ImageName { get; set;}

    }

}
