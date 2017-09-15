using AltonikaShop.Domain.Entities;

namespace AltonikaShop.Application.Services.Interfaces
{
    public interface IOrderService
    {
        int Update(Order order);
    }
}
