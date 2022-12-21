using CozyThings.Frontend.Web.Models.Product;

namespace CozyThings.Frontend.Web.Services
{
    public interface IProductService
    {
        Task<T> GetAllProductsAsync<T>();

        Task<T> GetProductByIdAsync<T>(int id);

        Task<T> CreateProductAsync<T>(ProductCreateDto dto);

        Task<T> UpdateProductAsync<T>(ProductUpdateDto dto);

        Task<T> DeleteProductAsync<T>(int id);
    }
}
