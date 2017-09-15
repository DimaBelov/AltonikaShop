using AltonikaShop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AltonikaShop.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductController : Controller
    {
        readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_productService.GetAll());
        }
    }
}
