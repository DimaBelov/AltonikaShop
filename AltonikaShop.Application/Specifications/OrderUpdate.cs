using AltonikaShop.Domain.Entities;
using CoreLib.Data;

namespace AltonikaShop.Application.Specifications
{
    sealed class OrderUpdate : DbSpecification
    {
        public OrderUpdate(Order order)
        {
            AddParameter("@user_id", order.User.Id);
            AddTableParameter("@details", order.BasketItems, BasketItem.Tvp);
        }

        protected override string CreateCommandText()
        {
            return "Order_Update";
        }
    }
}
