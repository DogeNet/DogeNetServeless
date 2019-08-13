using DogeNetCore.DataAccess.Abstractions.UsersRepository.Entities;
using Microsoft.EntityFrameworkCore;

namespace DogeNetCore.DataAccess.lib.implementations.EntityFramework.UserRepository.Entities
{
    public sealed class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) :
            base(options)
        {
            Database.Migrate();
        }
        public DbSet<User> Users { get; set; }
    }
}
