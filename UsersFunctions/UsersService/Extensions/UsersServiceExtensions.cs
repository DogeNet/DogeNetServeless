using DogeNetCore.DataAccess.Abstractions.UsersRepository.Entities;
using UsersService.Abstractions.Models;

namespace UsersService.Extensions
{
    public static class UsersServiceExtensions
    {
        public static UsersEntity MapToUsersEntity(this User user)
        {
            return new UsersEntity
            {
                DogeId = user.DogeId,
                Username = user.Username,
                Score = user.Score
            };
        }

        public static User MapToUser(this UsersEntity usersEntity)
        {
            return new User
            {
                DogeId = usersEntity.DogeId,
                Username = usersEntity.Username,
                Score = usersEntity.Score
            };
        }

    }
}
