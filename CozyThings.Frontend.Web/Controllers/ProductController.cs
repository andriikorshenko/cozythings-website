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

        [HttpGet("")]
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

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View("CreateOrUpdate", new ProductViewModel()
            {
                Action = FormAction.Create
            });
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = mapper.Map<ProductCreateDto>(model);
                var response = await productService.CreateProductAsync<ResponseDto>(product);
                if (response != null & response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
    }
}
