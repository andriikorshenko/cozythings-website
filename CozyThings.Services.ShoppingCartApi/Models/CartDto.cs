using CozyThings.Services.ShoppingCartApi.Data.Entities;

namespace CozyThings.Services.ShoppingCartApi.Models
{
    public class CartDto
    {
        public CartHeader CartHeader { get; set; }

        public IEnumerable<CartDetails> CartDetails { get; set; }
    }
}
