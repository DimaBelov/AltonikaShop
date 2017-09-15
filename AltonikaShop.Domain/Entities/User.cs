using CoreLib.Data.Mapping;

namespace AltonikaShop.Domain.Entities
{
    public class User
    {
        [DatabaseMap("user_id")]
        public int? Id { get; set; }

        [DatabaseMap("user_login")]
        public string Login { get; set; }

        [DatabaseMap("user_password")]
        public string Password { get; set; }
    }
}
