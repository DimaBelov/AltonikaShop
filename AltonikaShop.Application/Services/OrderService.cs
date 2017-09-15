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

        public int Update(Order order)
        {
            return Get<int>(new OrderUpdate(order));
        }
    }
}
