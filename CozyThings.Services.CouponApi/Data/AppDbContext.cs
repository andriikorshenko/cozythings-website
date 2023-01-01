using Microsoft.EntityFrameworkCore;

namespace CozyThings.Services.CouponApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }


    }
}
