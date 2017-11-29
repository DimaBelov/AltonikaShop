﻿using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;

namespace AltonikaShop.Data.Repositories.Interfaces
{
    public interface IUserRepository : IEntityRepository<User>
    {
        User Auth(User user);
    }
}
