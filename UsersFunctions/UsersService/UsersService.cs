using DogeNetCore.DataAccess.Abstractions.UsersRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersService.Abstractions;
using UsersService.Abstractions.Models;
using UsersService.Extensions;

namespace UsersService
{
    class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository repository)
        {
            _usersRepository = repository;
        }

        public async Task AddUserAsync(User user)
        {
            await _usersRepository.AddAsync(user.MapToUsersEntity());
        }

        public async Task<User> GetUserAsync(int id)
        {
            var result = await _usersRepository.FindAsync(id);
            return result.MapToUser();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var resultSet = await _usersRepository.GetAllAsync();
            return resultSet.Select(p => p.MapToUser());
        }

        public async Task RemoveUserAsync(int id)
        {
            await _usersRepository.RemoveAsync(id);
        }
    }
}
