using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Domain.Entities;
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
            //return Json(_productService.GetAll());
            return Json(new []
            {
                new Product {Id = 1, Name = "Product1", Description = "This is a product1", ImageSource = "https://www.mirsmazok.ru/images/orig_574_1297638132arFz4e8Hrd.jpg"},
                new Product {Id = 2, Name = "Product2", Description = "This is a product2", ImageSource = "https://www.mirsmazok.ru/images/orig_574_1297638132arFz4e8Hrd.jpg"},
                new Product {Id = 3, Name = "Product3", Description = "This is a product3", ImageSource = "https://www.mirsmazok.ru/images/orig_574_1297638132arFz4e8Hrd.jpg"},
                new Product {Id = 4, Name = "Product4", Description = "This is a product4", ImageSource = "https://www.mirsmazok.ru/images/orig_574_1297638132arFz4e8Hrd.jpg"}
            });
        }
    }
}
