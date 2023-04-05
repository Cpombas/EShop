using Microsoft.AspNetCore.Identity;
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

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }
        
        [MaxLength(50)]
        public string? LastName { get; set; }

        public int Age { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        [Required]
        public string Role { get; set; }

        //public User (string userName, string password, int roleId)
        //{
        //    UserName = userName;
        //    Password = password;
        //    RoleId = roleId;
        //}

    }
}
