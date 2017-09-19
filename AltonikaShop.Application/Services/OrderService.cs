using System.Collections.Generic;
using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AltonikaShop.Application.Services
{
    public class OrderService : EntityService<Order>, IOrderService
    {
        public OrderService(IEntityRepository<Order> repository) : base(repository)
        {
        }

        public IEnumerable<Order> GetByUser(int userId)
        {
            return Repository.GetAll(
                new Query<Order>
                {
                    IsSatisfied = order => order.UserId == userId,
                    Include = orders => orders.Include(order => order.Details)
                        .ThenInclude(d => d.Product)
                });
        }
    }
}
