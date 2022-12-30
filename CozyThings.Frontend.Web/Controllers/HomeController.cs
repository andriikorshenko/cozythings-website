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
        private readonly ICartService cartService;
        private readonly IMapper mapper;

        public HomeController(
            ILogger<HomeController> logger, 
            IProductService productService, 
            ICartService cartService,
            IMapper mapper)
        {
            _logger = logger;
            this.productService = productService;
            this.cartService = cartService;
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

        [Authorize]
        [ActionName("Details")]
        [HttpPost]
        public async Task<IActionResult> DetailsPost(ProductViewModel model)
        {
            var productDto = mapper.Map<ProductDto>(model);

            var cartDto = new CartDto()
            {
                CartHeader = new CartHeaderDto()
                {
                    UserId = User.Claims.Where(x => x.Type == "sub")?.FirstOrDefault()?.Value
                }
            };

            var cartDetails = new CartDetailsDto()
            {
                Count = productDto.Count,
                ProductId = productDto.Id
            };

            var response = await productService.GetProductByIdAsync<ResponseDto>(productDto.Id, "");
            if (response != null && response.IsSuccess)
            {
                cartDetails.Product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            }
            List<CartDetailsDto> cartDetailsDtos = new();
            cartDetailsDtos.Add(cartDetails);
            cartDto.CartDetails = cartDetailsDtos;

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var addToCartResp = await cartService.AddToCardAsync<ResponseDto>(cartDto, accessToken);
            if (addToCartResp != null && addToCartResp.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
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