using CozyThings.Frontend.Web.Models;

namespace CozyThings.Frontend.Web.Services.Imp
{
    public class CouponService : BaseService, ICouponService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CouponService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetCouponAsync<T>(string couponCode, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.CouponApiBase + "/api/coupon/" + couponCode,
                AccessToken = token
            });
        }
    }
}
