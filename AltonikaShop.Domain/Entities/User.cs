using CoreLib.Data.Mapping;
using CoreLib.Entities;

namespace AltonikaShop.Domain.Entities
{
    [NamedEntityDatabaseMap("user_id", "user_name")]
    public class User : NamedEntity
    {
        [DatabaseMap("user_login")]
        public string Login { get; set; }

        [DatabaseMap("user_password")]
        public string Password { get; set; }
    }
}
