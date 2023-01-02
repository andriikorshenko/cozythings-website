using CozyThings.Services.ShoppingCartApi.Models.Cart;

namespace CozyThings.Services.ShoppingCartApi.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);

        Task<CartDto> CreateUpdateCart(CartDto dto);

        Task<bool> RemoveFromCart(int cartDetailsId);

        Task<bool> ApplyCoupon(string userId, string couponCode);

        Task<bool> RemoveCoupon(string userId);

        Task<bool> ClearCart(string userId);
    }
}
