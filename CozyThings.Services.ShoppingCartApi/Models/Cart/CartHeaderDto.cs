using CozyThings.Services.ProductApi.Data.Abstractions;

namespace CozyThings.Services.ShoppingCartApi.Models.Cart
{
    public class CartHeaderDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string CouponCode { get; set; }
    }
}
