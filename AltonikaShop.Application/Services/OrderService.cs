using System;
using System.Collections.Generic;
using System.Linq;
using AltonikaShop.Application.Dto;
using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Application.Specifications;
using AltonikaShop.Domain.Entities;
using CoreLib.Data;

namespace AltonikaShop.Application.Services
{
    public class OrderService : GenericService, IOrderService
    {
        public OrderService(IGenericRepository genericRepository) : base(genericRepository)
        {
        }

        public int Update(IEnumerable<BasketItem> items, User user)
        {
            return Get<int>(new OrderUpdate(items, user));
        }

        public IEnumerable<Order> GetByUser(int userId)
        {
            return GetAll(new OrderGetByUser(userId), ReadOrders);
        }

        IEnumerable<Order> ReadOrders(IDisposable reader)
        {
            var orders = Read<Order>(reader).ToList();
            var orderDetails = Read<OrderDetailDto, OrderDetail>(reader).ToList();

            orders.ForEach(o => o.Details = orderDetails
                .Where(d => d.OrderId == o.Id).ToList());

            return orders;
        }
    }
}
