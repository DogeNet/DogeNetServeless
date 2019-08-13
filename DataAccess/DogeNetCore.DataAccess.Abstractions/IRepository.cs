using DogeNetCore.DataAccess.Abstractions.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogeNetCore.DataAccess.Abstractions
{
    public interface IRepository<TEntity, in TKey> where TEntity : IEntity<TKey>
    {
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> FindAsync(TKey key);
        Task<IQueryable<TEntity>> FindAsync(IEnumerable<TKey> keys);
    }
}
