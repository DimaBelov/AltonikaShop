using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Application.Specifications;
using AltonikaShop.Domain.Entities;
using CoreLib.Data;

namespace AltonikaShop.Application.Services
{
    public class UserService : GenericService, IUserService
    {
        public UserService(IGenericRepository genericRepository) : base(genericRepository)
        {
        }

        public User Auth(User user)
        {
            return Get<User>(new UserAuth(user));
        }
    }
}
