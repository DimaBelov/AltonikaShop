using System;
using System.Linq;
using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Domain.Entities;
using AltonikaShop.WebApi.Models;
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
        public IActionResult Update([FromBody] OrderModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return Json(_orderService.Add(new Order
            {
                UserId = model.User.Id,
                CreateDate = DateTime.Now,
                Details = model.BasketItems.Select(i => new OrderDetail
                {
                    ProductId = i.Product.Id,
                    Quantity = i.Quantity
                }).ToList()
            }));
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
