using CozyThings.Services.CouponApi.Models;

namespace CozyThings.Services.CouponApi.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
