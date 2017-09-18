using System.Collections.Generic;
using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;

namespace AltonikaShop.Application.Services
{
    public class OrderService : EntityService<Order>, IOrderService
    {
        public OrderService(IEntityRepository<Order> repository) : base(repository)
        {
        }

        public IEnumerable<Order> GetByUser(int userId)
        {
            return GetAll();
        }
    }
}
