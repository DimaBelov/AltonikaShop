using System;
using AltonikaShop.Data.Repositories.Interfaces;
using AltonikaShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AltonikaShop.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class OrderController: Controller
    {
        readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public IActionResult Update([FromBody] Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));
            
            order.CreateDate = DateTime.Now;
            order.Details.ForEach(d => d.ProductId = d.Product.Id);
            return Json(_orderRepository.Add(order));
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUser(int? userId)
        {
            if(!userId.HasValue)
                throw new ArgumentNullException(nameof(userId));

            return Json(_orderRepository.GetByUser(userId.Value));
        }
    }
}
