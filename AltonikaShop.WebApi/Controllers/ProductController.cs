﻿using System;
using System.Linq;
using AltonikaShop.Application.Pagging;
using AltonikaShop.Application.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AltonikaShop.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductController : Controller
    {
        readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public IActionResult GetAll([FromBody] PaggingOptions options)
        {
#if DEBUG
            //Thread.Sleep(5000);
            //throw new Exception("Test exception");
#endif
            return Json(Paginator.Page(_productRepository.GetAll().ToList(), options));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            if(id == null)
                throw new ArgumentNullException(nameof(id));

            return Json(_productRepository.Get(id.Value));
        }
    }
}
