using CozyThings.Services.OrderApi.Data.Entities;

namespace CozyThings.Services.OrderApi.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);

        Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);
    }
}
