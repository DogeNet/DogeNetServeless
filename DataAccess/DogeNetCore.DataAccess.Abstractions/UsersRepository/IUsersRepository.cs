using DogeNetCore.DataAccess.Abstractions.UsersRepository.Entities;
using System.Threading.Tasks;

namespace DogeNetCore.DataAccess.Abstractions.UsersRepository
{
    public interface IUsersRepository: IRepository<UsersEntity, int>
    {
        Task UpdateUsername(int id, string newUsername);
        Task UpdateScore(int id, int newScore);
        Task AddScore(int id, int scoreToAdd);
    }
}
