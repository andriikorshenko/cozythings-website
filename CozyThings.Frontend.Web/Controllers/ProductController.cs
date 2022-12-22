using AutoMapper;
using CozyThings.Frontend.Web.Models;
using CozyThings.Frontend.Web.Models.Product;
using CozyThings.Frontend.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CozyThings.Frontend.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> products = new();

            var response = await productService.GetAllProductsAsync<ResponseDto>();
            if (response != null & response.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            var list = mapper.Map<IReadOnlyList<ProductViewModel>>(products);
            return View(list);
        }
    }
}
