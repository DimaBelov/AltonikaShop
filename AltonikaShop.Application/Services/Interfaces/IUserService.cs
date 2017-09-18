using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;

namespace AltonikaShop.Application.Services.Interfaces
{
    public interface IUserService : IEntityService<User>
    {
        User Auth(User user);
    }
}
