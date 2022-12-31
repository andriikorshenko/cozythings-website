using CozyThings.Services.ShoppingCartApi.Data.Entities;

namespace CozyThings.Services.ShoppingCartApi.Models.Cart
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }

        public IEnumerable<CartDetailsDto> CartDetails { get; set; }
    }
}
