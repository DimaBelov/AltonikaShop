using System.Collections.Generic;
using AltonikaShop.Domain.Entities;
using CoreLib.Data;

namespace AltonikaShop.Application.Specifications
{
    sealed class OrderUpdate : DbSpecification
    {
        public OrderUpdate(IEnumerable<BasketItem> items, User user)
        {
            AddParameter("@user_id", user.Id);
            AddTableParameter("@details", items, BasketItem.Tvp);
        }

        protected override string CreateCommandText()
        {
            return "Order_Update";
        }
    }
}
