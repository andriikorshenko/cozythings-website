using CozyThings.Services.ShoppingCartApi.Models;

namespace CozyThings.Services.ShoppingCartApi.Data.Entities
{
    public class Cart
    {
        public CartHeaderDto CartHeader { get; set; }

        public IEnumerable<CartDetailsDto> CartDetails { get; set; }
    }
}
