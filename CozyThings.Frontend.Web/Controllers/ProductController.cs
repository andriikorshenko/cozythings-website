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

        public IActionResult Create()
        {
            return View("CreateOrUpdate", new ProductViewModel()
            {
                Action = FormAction.Create
            });
        }

        [HttpPost]
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

        public async Task<IActionResult> Update(int id)
        {
            var responseDto = await productService.GetProductByIdAsync<ResponseDto>(id);
            if (responseDto == null)
            {
                return NotFound();
            }
            var des = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result));
            var model = mapper.Map<ProductViewModel>(des);
            model.Action = FormAction.Update;
            return View("CreateOrUpdate", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = mapper.Map<ProductUpdateDto>(model);
                var response = await productService.UpdateProductAsync<ResponseDto>(product);
                if (response != null & response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var responseDto = await productService.DeleteProductAsync<ResponseDto>(id);
            if (responseDto != null && responseDto.IsSuccess) 
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
