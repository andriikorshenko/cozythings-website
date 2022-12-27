using CozyThings.Services.ShoppingCartApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CozyThings.Services.ShoppingCartApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<CartHeader> CartHeaders { get; set; }

        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
