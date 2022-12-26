using CozyThings.Services.ProductApi.Data.Abstractions;

namespace CozyThings.Services.ShoppingCartApi.Data.Entities
{
    public class CartHeader : Entity
    {
        public string UserId { get; set; }

        public string CouponCode { get; set; }
    }
}
