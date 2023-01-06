using CozyThings.Integration.MessageBus.Services;
using CozyThings.Services.ShoppingCartApi.Message;
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
        private readonly IMessageBus messageBus;
        private readonly ResponseDto responseDto;

        public CartController(ICartRepository cartRepository, IMessageBus messageBus)
        {
            this.cartRepository = cartRepository;
            this.messageBus = messageBus;
            responseDto = new();
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCart(string userId)
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

        [HttpPost("Checkout")]
        public async Task<object> Checkout(CheckoutHeaderDto checkoutHeaderDto)
        {
            try
            {
                CartDto cartDto = await cartRepository.GetCartByUserId(checkoutHeaderDto.UserId);
                if (cartDto == null)
                {
                    return BadRequest();
                }
                checkoutHeaderDto.CartDetails = cartDto.CartDetails;
                await messageBus.PublishMessage(checkoutHeaderDto, "checkoutmessagetopic");
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
