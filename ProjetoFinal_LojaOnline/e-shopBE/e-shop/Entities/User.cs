﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_shop.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }
        
        [MaxLength(50)]
        public string? LastName { get; set; }

        public int Age { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [ForeignKey("RoleId")]
        public Roles? Role { get; set; }

        [Required]
        public int RoleId { get; set; }

        //public User (string userName, string password, int roleId)
        //{
        //    UserName = userName;
        //    Password = password;
        //    RoleId = roleId;
        //}

    }
}
