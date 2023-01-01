using AutoMapper;
using CozyThings.Services.CouponApi.Data.Entities;
using CozyThings.Services.CouponApi.Models;

namespace CozyThings.Services.CouponApi
{
    public class MappingConfig 
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
