using DogeNetCore.StorageProviders.Abstractions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DogeNetCore.StorageProviders.Abstractions
{
    public interface IStorageProvider<TEntity, TKey> where
        TEntity : IStorageEntity<TKey>
    {
        Task CreateAsync(UsersStorageEntity entity);
        Task<UsersStorageEntity> GetAsync(TKey id);
        //TODO: add when support for 2.1 gets added to functions
        //IAsyncEnumerable<UsersStorageEntity> GetAllAsync();
        Task<IEnumerable<UsersStorageEntity>> GetAllAsync();
        Task UpdateAsync(UsersStorageEntity entity);
        Task DeleteAsync(TKey id);
    }
}
