using System.Collections.Generic;
using AltonikaShop.Data.Repositories.Interfaces;
using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AltonikaShop.Data.Repositories
{
    public class OrderRepository : EntityRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetByUser(int userId)
        {
            return GetAll(
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

            var orderEntry = DbSet.Add(order);
            orderEntry.Entity.Details.ForEach(d => 
                Context.Entry(d.Product).State = EntityState.Detached);
            Context.SaveChanges();
            return orderEntry.Entity;
        }
    }
}
