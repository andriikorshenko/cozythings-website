using CozyThings.Services.ShoppingCartApi.Models;
using CozyThings.Services.ShoppingCartApi.Models.Cart;
using CozyThings.Services.ShoppingCartApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CozyThings.Services.ShoppingCartApi.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly ResponseDto responseDto;

        public CartController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
            responseDto = new();
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCall(string userId)
        {
            try
            {
                var cartDto = await cartRepository.GetCartByUserId(userId);
                responseDto.Result = cartDto;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return responseDto;
        }

        [HttpPost("AddCart")]
        public async Task<object> AddCart(CartDto dto)
        {
            try
            {
                var cartDto = await cartRepository.CreateUpdateCart(dto);
                responseDto.Result = cartDto;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return responseDto;
        }

        [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart(CartDto dto)
        {
            try
            {
                var cartDto = await cartRepository.CreateUpdateCart(dto);
                responseDto.Result = cartDto;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return responseDto;
        }

        [HttpPost("RemoveCart")]
        public async Task<object> RemoveCart([FromBody]int cartId)
        {
            try
            {
                var isSuccess = await cartRepository.RemoveFromCart(cartId);
                responseDto.Result = isSuccess;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return responseDto;
        }

        [HttpPost("ApplyCoupon")]
        public async Task<object> ApplyCoupon([FromBody] CartDto cartDto)
        {
            try
            {
                var isSuccess = await cartRepository.ApplyCoupon(cartDto.CartHeader.UserId,
                    cartDto.CartHeader.CouponCode);
                responseDto.Result = isSuccess;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return responseDto;
        }

        [HttpPost("RemoveCoupon")]
        public async Task<object> RemoveCoupon([FromBody] string userId)
        {
            try
            {
                var isSuccess = await cartRepository.RemoveCoupon(userId);
                responseDto.Result = isSuccess;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return responseDto;
        }
    }
}
