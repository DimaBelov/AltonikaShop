using System;
using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AltonikaShop.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class OrderController: Controller
    {
        readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult Update([FromBody] Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));
            
            order.CreateDate = DateTime.Now;
            order.Details.ForEach(d => d.ProductId = d.Product.Id);
            return Json(_orderService.Add(order));
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUser(int? userId)
        {
            if(!userId.HasValue)
                throw new ArgumentNullException(nameof(userId));

            return Json(_orderService.GetByUser(userId.Value));
        }
    }
}
