using AltonikaShop.Domain.Entities;

namespace AltonikaShop.Application.Services.Interfaces
{
    public interface IUserService
    {
        User Auth(User user);
    }
}
