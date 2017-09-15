using System;
using System.Collections.Generic;
using CoreLib.Data.Mapping;

namespace AltonikaShop.Domain.Entities
{
    public class Order
    {
        [DatabaseMap("order_id")]
        public int? Id { get; set; }

        [DatabaseMap("user_id")]
        public int? UserId { get; set; }

        [DatabaseMap("create_dt")]
        public DateTime? CreateDate { get; set; }

        public List<OrderDetail> Details { get; set; }
    }
}
