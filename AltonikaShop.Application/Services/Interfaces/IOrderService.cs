using System.Collections.Generic;
using AltonikaShop.Domain.Entities;

namespace AltonikaShop.Application.Services.Interfaces
{
    public interface IOrderService
    {
        int Update(IEnumerable<BasketItem> items, User user);

        IEnumerable<Order> GetByUser(int userId);
    }
}
