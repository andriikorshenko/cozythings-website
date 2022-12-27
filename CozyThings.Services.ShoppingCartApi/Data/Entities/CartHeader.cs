using CozyThings.Services.ProductApi.Data.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace CozyThings.Services.ShoppingCartApi.Data.Entities
{
    public class CartHeader : Entity
    {
        public string UserId { get; set; }

        public string CouponCode { get; set; }
    }
}
