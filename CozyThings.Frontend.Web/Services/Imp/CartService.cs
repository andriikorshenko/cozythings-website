using CozyThings.Frontend.Web.Models;

namespace CozyThings.Frontend.Web.Services.Imp
{
    public class CartService : BaseService, ICartService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CartService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.ShoppingCartApiBase + "/api/cart/GetCart/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> AddToCardAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = StaticDetails.ShoppingCartApiBase + "/api/cart/AddCart",
                AccessToken = token
            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = StaticDetails.ShoppingCartApiBase + "/api/cart/UpdateCart",
                AccessToken = token
            });
        }

        public async Task<T> DeleteCartAsync<T>(int cartId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.POST,
                Data = cartId,
                Url = StaticDetails.ShoppingCartApiBase + "/api/cart/RemoveCart",
                AccessToken = token
            });
        }

        public async Task<T> ApplyCouponAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = StaticDetails.ShoppingCartApiBase + "/api/cart/ApplyCoupon",
                AccessToken = token
            });
        }

        public async Task<T> RemoveCouponAsync<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.POST,
                Data = userId,
                Url = StaticDetails.ShoppingCartApiBase + "/api/cart/RemoveCoupon",
                AccessToken = token
            });
        }
    }
}
