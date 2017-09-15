using System;
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
            return Json(_productService.GetAll());
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
