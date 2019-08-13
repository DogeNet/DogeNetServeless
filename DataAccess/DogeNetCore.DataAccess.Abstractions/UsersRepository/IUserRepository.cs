using DogeNetCore.DataAccess.Abstractions.UsersRepository.Entities;
using System.Threading.Tasks;

namespace DogeNetCore.DataAccess.Abstractions.UsersRepository
{
    public interface IUserRepository<TEntity> : IRepository<TEntity, string>
    where TEntity : User
    {
        Task<bool> UpdateUsername(string currentUsername, string newUsername);
        Task<bool> UpdateScore(string username, int newScore);
        Task<bool> AddScore(string username, int scoreToAdd);
    }
}
