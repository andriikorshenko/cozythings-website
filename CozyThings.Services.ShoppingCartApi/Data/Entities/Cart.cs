namespace CozyThings.Services.ShoppingCartApi.Data.Entities
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }

        public IEnumerable<CartDetails> CartDetails { get; set; }
    }
}
