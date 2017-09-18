namespace AltonikaShop.Domain.Entities
{
    public class OrderDetail : BasketItem
    {
        public int? OrderId { get; set; }

        public int? ProductId { get; set; }
    }
}
