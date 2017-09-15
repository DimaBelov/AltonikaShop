using System.Collections.Generic;

namespace AltonikaShop.Domain.Entities
{
    public class BasketItem
    {
        public Product Product { get; set; }

        public int? ProductId => Product?.Id;

        public int Quantity { get; set; }

        public static IList<string> Tvp = new List<string>
        {
            nameof(ProductId),
            nameof(Quantity)
        };
    }
}
