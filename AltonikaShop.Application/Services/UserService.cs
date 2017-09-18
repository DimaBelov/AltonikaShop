using System.Linq;
using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;

namespace AltonikaShop.Application.Services
{
    public class UserService : EntityService<User>, IUserService
    {
        public UserService(IEntityRepository<User> repository) : base(repository)
        {
        }

        public User Auth(User user)
        {
            return Repository.GetAll(
                new Query<User>
                {
                    IsSatisfied = u => u.Login.Equals(user.Login) && u.Password.Equals(user.Password)
                })
                .FirstOrDefault();
        }
    }
}
