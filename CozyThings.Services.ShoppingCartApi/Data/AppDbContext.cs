using Microsoft.EntityFrameworkCore;

namespace CozyThings.Services.ShoppingCartApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }
        
                
    }
}
