using AltonikaShop.Domain.Entities;
using CoreLib.Data;

namespace AltonikaShop.Application.Specifications
{
    sealed class UserAuth : DbSpecification
    {
        public UserAuth(User user)
        {
            AddParameter("@user_login", user?.Login);
            AddParameter("@user_password", user?.Password);
        }

        protected override string CreateCommandText()
        {
            return "User_Auth";
        }
    }
}
