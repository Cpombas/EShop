﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_shop.Entities
{
    public class Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        public string? Brand { get; set; }

        public string? Description { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public int CategoryId { get; set; }

        //public Items(string name, float price)
        //{
        //    Name = name;
        //    Price = price;
        //}


    }
}
