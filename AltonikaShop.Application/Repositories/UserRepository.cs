﻿using System.Linq;
using AltonikaShop.Domain.Entities;
using AltonikaShop.Application.Repositories.Interfaces;
using CoreLib.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AltonikaShop.Application.Repositories
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User Auth(User user)
        {
            return GetAll(
                new Query<User>
                {
                    IsSatisfied = u => u.Login.Equals(user.Login) && u.Password.Equals(user.Password)
                })
                .FirstOrDefault();
        }
    }
}
