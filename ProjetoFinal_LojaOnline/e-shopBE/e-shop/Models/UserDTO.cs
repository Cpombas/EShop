﻿using e_shop.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace e_shop.Models
{
    public class ListUserDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; }


        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? Age { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public int RoleId { get; set; }

        public ListUserDTO() { }

        public ListUserDTO(User user)
        {
            UserId = user.UserId;
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Age = user.Age;
            Email = user.Email;
            Address = user.Address;
            RoleId = user.RoleId;
        }

        public class CreateUserDTO
        {
            [Required]
            public string? UserName { get; set; }

            [Required]
            public string? Password { get; set; }

            public string? FirstName { get; set; }

            public string? LastName { get; set; }

            public int Age { get; set; }

            public string? Email { get; set; }

            public string? Address { get; set; }

            [Required]
            public int RoleId { get; set; }

        }

        public class UpdateUserDTO 
        {
            public int UserId { get; set; }

            [Required]
            public string? UserName { get; set; }

            public string? Password { get; set; }

            public string? FirstName { get; set; }

            public string? LastName { get; set; }

            public int Age { get; set; }

            public string? Email { get; set; }

            public string? Address { get; set; }

            public int RoleId { get; set; }
        }
    }
}
