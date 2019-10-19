using DogeNetCore.DataAccess.Abstractions.UsersRepository.Entities;
using DogeNetCore.StorageProviders.Abstractions.Entities;

namespace DogeNetCore.DataAccess.Extensions
{
    public static class UsersRepositoryExtensions
    {
        public static UsersStorageEntity MapToStorageEntity(this UsersEntity user)
        {
            return new UsersStorageEntity
            {
                DogeId = user.DogeId,
                Score = user.Score,
                Username = user.Username
            };
        }

        public static UsersEntity MapToUsersEntity(this UsersStorageEntity entity)
        {
            return new UsersEntity
            {
                DogeId = entity.DogeId,
                Username = entity.Username,
                Score = entity.Score
            };
        }
    }
}
