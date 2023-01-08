using CozyThings.Services.OrderApi.Data;
using CozyThings.Services.OrderApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CozyThings.Services.OrderApi.Repository.Imp
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<AppDbContext> dbContext;

        public OrderRepository(DbContextOptions<AppDbContext> dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddOrder(OrderHeader orderHeader)
        {
            await using var db = new AppDbContext(dbContext);
            db.OrderHeaders.Add(orderHeader);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid)
        {
            await using var db = new AppDbContext(dbContext);
            var orderHeaderFromDb = await db.OrderHeaders.FirstOrDefaultAsync(x => x.Id == orderHeaderId);
            if (orderHeaderFromDb != null)
            {
                orderHeaderFromDb.PaymentStatus = paid;
                await db.SaveChangesAsync();
            }
        }
    }
}
