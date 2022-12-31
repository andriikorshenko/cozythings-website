namespace CozyThings.Services.ShoppingCartApi.Models.Cart
{
    public class CartDetailsDto
    {
        public int Id { get; set; }

        public int CartHeaderId { get; set; }

        public virtual CartHeaderDto CartHeader { get; set; }

        public int ProductId { get; set; }

        public virtual ProductDto Product { get; set; }

        public int Count { get; set; }
    }
}
