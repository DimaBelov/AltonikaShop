using System;
using System.Collections.Generic;
using CoreLib.Entities;

namespace AltonikaShop.Domain.Entities
{
    public class Order : IdentifiedEntity
    {
        public int? UserId { get; set; }
        
        public DateTime? CreateDate { get; set; }

        public List<OrderDetail> Details { get; set; }
    }
}
