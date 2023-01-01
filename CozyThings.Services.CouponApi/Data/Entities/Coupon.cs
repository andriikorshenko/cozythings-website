using CozyThings.Services.ProductApi.Data.Abstractions;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace CozyThings.Services.CouponApi.Data.Entities
{
    public class Coupon : Entity
    {
        public string CouponCode { get; set; }

        public double DiscountAmount { get; set; }
    }
}
