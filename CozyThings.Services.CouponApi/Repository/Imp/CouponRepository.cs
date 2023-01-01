using AutoMapper;
using CozyThings.Services.CouponApi.Data;
using CozyThings.Services.CouponApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CozyThings.Services.CouponApi.Repository.Imp
{
    public class CouponRepository : ICouponRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public CouponRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CouponDto> GetCouponByCode(string couponCode)
        {
            var coupon = await dbContext.Coupons
                .FirstOrDefaultAsync(x => x.CouponCode == couponCode);

            return mapper.Map<CouponDto>(coupon);
        }
    }
}
