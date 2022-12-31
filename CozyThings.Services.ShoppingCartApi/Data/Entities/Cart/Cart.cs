using CozyThings.Services.ShoppingCartApi.Models;

namespace CozyThings.Services.ShoppingCartApi.Data.Entities.Cart
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }

        public IEnumerable<CartDetails> CartDetails { get; set; }
    }
}
