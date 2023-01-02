using CozyThings.Frontend.Web.Models;

namespace CozyThings.Frontend.Web.Services
{
    public interface ICouponService
    {
        Task<T> GetCouponAsync<T>(string couponCode, string token = null);  
    }
}
