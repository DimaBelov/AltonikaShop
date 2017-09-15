using AltonikaShop.Application.Services.Interfaces;
using CoreLib.Data;

namespace AltonikaShop.Application.Services
{
    public class OrderService : GenericService, IOrderService
    {
        public OrderService(IGenericRepository genericRepository) : base(genericRepository)
        {
        }
    }
}
