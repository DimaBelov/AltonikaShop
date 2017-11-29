namespace AltonikaShop.Domain.Entities
{
    public class UserPrice
    {
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public decimal? Price { get; set; }
    }
}
