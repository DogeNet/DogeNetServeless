using System.Collections.Generic;
using System.Threading.Tasks;
using UsersService.Abstractions.Models;

namespace UsersService.Abstractions
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(int Id);
        Task AddUserAsync(User user);
        Task RemoveUserAsync(int Id);       
    }
}
