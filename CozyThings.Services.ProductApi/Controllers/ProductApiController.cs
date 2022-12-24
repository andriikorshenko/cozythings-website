using CozyThings.Services.ProductApi.Models;
using CozyThings.Services.ProductApi.Models.Product;
using CozyThings.Services.ProductApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyThings.Services.ProductApi.Controllers
{
    [Route("api/products")]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly ResponseDto response;

        public ProductApiController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            this.response = new ResponseDto();
        }

        //[Authorize]
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                var products = await productRepository.GetProducts();
                response.Result = products;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                var products = await productRepository.GetProductById(id);
                response.Result = products;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        [Authorize]
        [HttpPost]
        public async Task<ResponseDto> Create([FromBody] ProductCreateDto dto)
        {
            try
            {
                var product = await productRepository.CreateProduct(dto);
                response.Result = product;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        [Authorize]
        [HttpPut]
        public async Task<ResponseDto> Update([FromBody] ProductUpdateDto dto)
        {
            try
            {
                var product = await productRepository.UpdateProduct(dto);
                response.Result = product;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                var result = await productRepository.DeleteProduct(id);
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }
    }
}
