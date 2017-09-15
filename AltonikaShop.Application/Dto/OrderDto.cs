using AltonikaShop.Domain.Entities;
using CoreLib.Data;

namespace AltonikaShop.Application.Dto
{
    class OrderDto : IDto<Order>
    {
        public Order GetEntity()
        {
            return new Order
            {

            };
        }
    }
}
