using System.ComponentModel.DataAnnotations.Schema;
using CoreLib.Entities;

namespace AltonikaShop.Domain.Entities
{
    public class OrderDetail : IdentifiedEntity
    {
        public int? OrderId { get; set; }

        public int? ProductId { get; set; }

        //[NotMapped]
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
