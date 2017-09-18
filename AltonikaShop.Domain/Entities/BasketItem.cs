using CoreLib.Entities;

namespace AltonikaShop.Domain.Entities
{
    public class BasketItem : IdentifiedEntity
    {
        public Product Product { get; set; }
        
        public int Quantity { get; set; }
        
    }
}
