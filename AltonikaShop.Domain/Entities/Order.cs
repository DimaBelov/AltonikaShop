using System.Collections.Generic;

namespace AltonikaShop.Domain.Entities
{
    public class Order
    {
        public List<BasketItem> BasketItems { get; set; }

        public User User { get; set; }
    }
}
