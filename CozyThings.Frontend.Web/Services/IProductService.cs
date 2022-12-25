using CozyThings.Frontend.Web.Models.Product;

namespace CozyThings.Frontend.Web.Services
{
    public interface IProductService
    {
        Task<T> GetAllProductsAsync<T>(string token);

        Task<T> GetProductByIdAsync<T>(int id, string token);

        Task<T> CreateProductAsync<T>(ProductCreateDto dto, string token);

        Task<T> UpdateProductAsync<T>(ProductUpdateDto dto, string token);

        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
