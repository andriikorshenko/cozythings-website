using CozyThings.Services.ProductApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CozyThings.Services.ProductApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 11,
                Name = "Ultra Comfy X-Model",
                Price = 99.98,
                Description = "Some unique description #1...",
                ImageUrl = "https://cozythings.blob.core.windows.net/cozythings/chair-1.jpg",
                CategoryName = "Chairs"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                Name = "Mega Comfy Y-Model",
                Price = 1099.98,
                Description = "Some unique description #2...",
                ImageUrl = "https://cozythings.blob.core.windows.net/cozythings/sofa-1.jpg",
                CategoryName = "Sofas"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 13,
                Name = "Super Comfy M-Model",
                Price = 999.98,
                Description = "Some unique description #3...",
                ImageUrl = "https://cozythings.blob.core.windows.net/cozythings/table-1.jpg",
                CategoryName = "Tables"
            });
        }
    }
}
