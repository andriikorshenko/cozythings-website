using AutoMapper;
using CozyThings.Services.ProductApi.Data.Entities;
using CozyThings.Services.ProductApi.Models.Product;

namespace CozyThings.Services.ProductApi.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
