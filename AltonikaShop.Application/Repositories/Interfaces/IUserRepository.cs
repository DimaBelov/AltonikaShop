using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;

namespace AltonikaShop.Application.Repositories.Interfaces
{
    public interface IUserRepository : IEntityRepository<User>
    {
        User Auth(User user);
    }
}
