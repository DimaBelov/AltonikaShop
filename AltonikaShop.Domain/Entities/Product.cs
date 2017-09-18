using CoreLib.Entities;

namespace AltonikaShop.Domain.Entities
{
    public class Product : NamedEntity
    {
        public string Code { get; set; }

        public string Description { get; set; }
        
        public string ImageSource { get; set; }
    }
}
