using AutoMapper;
using AutoMapper.QueryableExtensions;
using CozyThings.Services.ProductApi.Data;
using CozyThings.Services.ProductApi.Data.Entities;
using CozyThings.Services.ProductApi.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace CozyThings.Services.ProductApi.Repository.Imp
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public ProductRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IQueryable<Product> Products => dbContext.Set<Product>();

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return await Products
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            return await Products
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductDto> CreateProduct(ProductCreateDto dto)
        {
            var product = mapper.Map<Product>(dto);

            dbContext.Add(product);
            await dbContext.SaveChangesAsync();

            return await GetProductById(product.Id);
        }

        public async Task<ProductDto> UpdateProduct(ProductUpdateDto dto)
        {
            var product = mapper.Map<Product>(dto);

            dbContext.Update(product);
            await dbContext.SaveChangesAsync();

            return await GetProductById(product.Id);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var product = await Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    return false;
                }

                dbContext.Remove(product);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }              
    }
}
