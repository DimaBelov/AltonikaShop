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

        public void Update(Order order)
        {
            Execute(new OrderUpdate(order));
        }
    }
}
