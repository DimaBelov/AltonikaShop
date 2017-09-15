using System.Collections.Generic;
using AltonikaShop.Domain.Entities;

namespace AltonikaShop.WebApi.Models
{
    public class OrderModel
    {
        public List<BasketItem> BasketItems { get; set; }

        public User User { get; set; }
    }
}
