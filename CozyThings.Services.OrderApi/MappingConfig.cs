using AutoMapper;
using CozyThings.Services.OrderApi.Data.Entities;
using CozyThings.Services.OrderApi.Models;

namespace CozyThings.Services.OrderApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CheckoutHeaderDto, OrderHeader>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
