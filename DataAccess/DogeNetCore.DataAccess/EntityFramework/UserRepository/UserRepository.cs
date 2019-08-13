using DogeNetCore.DataAccess.Abstractions.UsersRepository.Entities;
using DogeNetCore.DataAccess.lib.implementations.EntityFramework.UserRepository.Entities;
using DogeNetCore.DataAccess.Abstractions.UsersRepository;
using System.Threading.Tasks;

namespace DogeNetCore.DataAccess.EntityFramework.UserRepository
{
    public class UserRepository : BaseRepository<User, string>, IUserRepository<User>
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> UpdateUsername(string currentUsername, string newUsername)
        {
            var entity = await FindAsync(currentUsername);
            if (entity == null)
            {
                return false;
            }

            entity.Username = newUsername;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateScore(string username, int newScore)
        {
            var entity = await FindAsync(username);
            if (entity == null)
            {
                return false;
            }

            entity.Score = newScore;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddScore(string username, int scoreToAdd)
        {
            var entity = await FindAsync(username);
            if (entity == null)
            {
                return false;
            }

            entity.Score += scoreToAdd;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
