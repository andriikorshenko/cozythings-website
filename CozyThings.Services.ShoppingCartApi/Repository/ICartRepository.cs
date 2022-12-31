using CozyThings.Services.ShoppingCartApi.Models.Cart;

namespace CozyThings.Services.ShoppingCartApi.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);

        Task<CartDto> CreateUpdateCart(CartDto dto);

        Task<bool>RemoveFromCart(int cartDetailsId);

        Task<bool> ClearCart(string userId);
    }
}
