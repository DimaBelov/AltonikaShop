using AltonikaShop.Domain.Entities;
using CoreLib.Data;

namespace AltonikaShop.Application.Specifications
{
    sealed class OrderUpdate : DbSpecification
    {
        public OrderUpdate(Order order)
        {
            
        }

        protected override string CreateCommandText()
        {
            return "Order_Update";
        }
    }
}
