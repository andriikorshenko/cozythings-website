using CozyThings.Frontend.Web.Models;

namespace CozyThings.Frontend.Web.Services
{
    public interface ICartService
    {
        Task<T> GetCartByUserIdAsync<T>(string userId, string token = null);

        Task<T> AddToCardAsync<T>(CartDto cartDto, string token = null);

        Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null);

        Task<T> ApplyCouponAsync<T>(CartDto cartDto, string token = null);

        Task<T> RemoveCouponAsync<T>(string userId, string token = null);

        Task<T> DeleteCartAsync<T>(int cartId, string token = null);    
    }
}
