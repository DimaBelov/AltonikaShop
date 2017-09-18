using System.Collections.Generic;
using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;

namespace AltonikaShop.Application.Services.Interfaces
{
    public interface IOrderService : IEntityService<Order>
    {
        IEnumerable<Order> GetByUser(int userId);
    }
}
