using System.Collections.Generic;
using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AltonikaShop.Application.Services
{
    public class OrderService : EntityService<Order>, IOrderService
    {
        readonly AppDbContext _appDbContext;

        public OrderService(IEntityRepository<Order> repository, AppDbContext appDbContext) : base(repository)
        {
            _appDbContext = appDbContext;
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

        public override Order Add(Order order)
        {
            //order.Details.ForEach(d => d.Product = null);
            //return Repository.Add(order).Entity;

            var orderEntry = _appDbContext.Orders.Add(order);
            orderEntry.Entity.Details.ForEach(d => 
                _appDbContext.Entry(d.Product).State = EntityState.Detached);
            _appDbContext.SaveChanges();
            return orderEntry.Entity;
        }
    }
}
