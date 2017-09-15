using CoreLib.Data.Mapping;
using CoreLib.Entities;

namespace AltonikaShop.Domain.Entities
{
    [NamedEntityDatabaseMap("product_id", "product_name")]
    public class Product : NamedEntity
    {
        [DatabaseMap("product_description")]
        public string Description { get; set; }
    }
}
