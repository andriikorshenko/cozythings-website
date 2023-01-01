namespace CozyThings.Services.CouponApi.Models
{
    public record CouponDto
    {
        public int Id { get; init; }

        public string CouponCode { get; init; } = string.Empty;

        public double DiscountAmount { get; init; }
    }
}
