using CozyThings.Services.ProductApi.Data.Entities;
using CozyThings.Services.ProductApi.Models.Product;

namespace CozyThings.Services.ProductApi.Repository
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        Task<IEnumerable<ProductDto>> GetProducts();

        Task<ProductDto> GetProductById(int id);

        Task<ProductDto> CreateProduct(ProductCreateDto dto);

        Task<ProductDto> UpdateProduct(ProductUpdateDto dto);

        Task<bool> DeleteProduct(int id);
    }
}
