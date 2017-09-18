using CoreLib.Entities;

namespace AltonikaShop.Domain.Entities
{
    public class User : NamedEntity
    {
        public string Login { get; set; }
        
        public string Password { get; set; }
    }
}
