using System;
using System.Linq;
using AltonikaShop.Application.Pagging;
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

        [HttpPost]
        public IActionResult GetAll([FromBody] PaggingOptions options)
        {
            return Json(Paginator.Page(_productService.GetAll().ToList(), options));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            if(id == null)
                throw new ArgumentNullException(nameof(id));

            return Json(_productService.GetById(id.Value));
        }
    }
}
