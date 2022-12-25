using AutoMapper;
using CozyThings.Frontend.Web.Models;
using CozyThings.Frontend.Web.Models.Product;
using CozyThings.Frontend.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CozyThings.Frontend.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public HomeController(
            ILogger<HomeController> logger, 
            IProductService productService, 
            IMapper mapper)
        {
            _logger = logger;
            this.productService = productService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> products = new();

            var responseDto = await productService.GetAllProductsAsync<ResponseDto>("");
            if (responseDto != null && responseDto.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(responseDto.Result));
            }
            var list = mapper.Map<IReadOnlyList<ProductViewModel>>(products);
            return View(list);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            ProductViewModel product = new();

            var responseDto = await productService.GetProductByIdAsync<ResponseDto>(id, "");
            if (responseDto != null && responseDto.IsSuccess)
            {
                var result = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result));
                product = mapper.Map<ProductViewModel>(result);                
            }
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}