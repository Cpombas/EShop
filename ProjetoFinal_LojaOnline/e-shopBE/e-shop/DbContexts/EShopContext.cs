using e_shop.Entities;
using Microsoft.EntityFrameworkCore;
using e_shop.Models;
namespace e_shop.DbContexts
{
    public class EShopContext : DbContext
    {
        public DbSet<User> User { get; set; } = null!;

        public DbSet<Roles> Roles { get; set; } = null!;

        public DbSet<Items> Items { get; set; } = null!;

        public DbSet<Category> Category { get; set; } = null!;

        public DbSet<Orders> Orders { get; set; } = null!;

        public DbSet<OrderItems> OrderItems { get; set; } = null!;

        public DbSet<OrderHistory> OrdersHistory { get; set; } = null!;

        public EShopContext(DbContextOptions<EShopContext> options)
            : base(options)
        {

        }
    }
}
