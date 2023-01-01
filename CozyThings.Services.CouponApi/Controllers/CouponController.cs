using CozyThings.Services.CouponApi.Models;
using CozyThings.Services.CouponApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CozyThings.Services.CouponApi.Controllers
{
    [ApiController]
    [Route("api/coupon")]
    public class CouponController : Controller
    {
        private readonly ICouponRepository couponRepository;
        protected ResponseDto responseDto;

        public CouponController(ICouponRepository couponRepository)
        {
            this.couponRepository = couponRepository;
            responseDto = new();
        }

        [HttpGet("{code}")]
        public async Task<object> GetDisciountForCode(string code)
        {
            try
            {
                var coupon = await couponRepository.GetCouponByCode(code);
                responseDto.Result = coupon;
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
