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
        public void Update([FromBody] Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            _orderService.Update(order);
        }
    }
}
