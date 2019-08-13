using DogeNetCore.DataAccess.Abstractions.UsersRepository.Entities;
using System;
using System.Collections.Generic;

namespace DogeNetCore.DataAccess.lib.implementations.EntityFramework.UserRepository.Entities
{
    //For testing and debugging
    public static class UsersContextExtensions
    {
        public static void EnsureSeedDataForContext(this UserContext context)
        {
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();

            var users = new List<User>()
            {
                new User
                {
                    Id = new Guid("b77dfb03-ac54-4832-859c-95624a9c6ae8"),
                    Username = "Gary",
                    Score = 100
                },
                new User
                {
                    Id = new Guid("01625b08-1238-4a58-bfc5-283b1dbd70eb"),
                    Username = "Johnny",
                    Score = 2000
                },
                new User()
                {
                    Id = new Guid("36e93b37-beb3-4e58-813c-af7322231b7c"),
                    Username = "Nigel",
                    Score = 0
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
