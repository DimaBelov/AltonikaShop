using System.Collections.Generic;
using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;

namespace AltonikaShop.Application.Repositories.Interfaces
{
    public interface IOrderRepository : IEntityRepository<Order>
    {
        IEnumerable<Order> GetByUser(int userId);
    }
}
