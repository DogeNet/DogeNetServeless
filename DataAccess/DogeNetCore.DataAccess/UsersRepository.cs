using DogeNetCore.DataAccess.Abstractions.UsersRepository;
using DogeNetCore.DataAccess.Abstractions.UsersRepository.Entities;
using DogeNetCore.DataAccess.Extensions;
using DogeNetCore.StorageProviders.Abstractions;
using DogeNetCore.StorageProviders.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogeNetCore.DataAccess
{
    class UsersRepository : IUsersRepository
    {
        private readonly IStorageProvider<UsersStorageEntity, int> _storageProvider;

        public UsersRepository(IStorageProvider<UsersStorageEntity, int> storageProvider)
        {
            _storageProvider = storageProvider;
        }
        public async Task AddAsync(UsersEntity entity)
        {
            await _storageProvider.CreateAsync(entity.MapToStorageEntity());
        }

        public async Task AddScore(int id, int scoreToAdd)
        {
            var user = await _storageProvider.GetAsync(id);
            user.Score += scoreToAdd;
            await _storageProvider.UpdateAsync(user);
        }

        public async Task<UsersEntity> FindAsync(int key)
        {
            var result = await _storageProvider.GetAsync(key);
            return result.MapToUsersEntity();
        }

        public async Task<IEnumerable<UsersEntity>> FindAsync(IEnumerable<int> keys)
        {
            throw new NotImplementedException();
        }

        //TODO: restore when functions support 2.1
        //public async Task<IEnumerable<UsersEntity>> GetAllAsync()
        //{
        //    var resultSet = new List<UsersEntity>();

        //    await foreach (var entity in _storageProvider.GetAllAsync())
        //    {
        //        resultSet.Add(entity.MapToUsersEntity());
        //    }

        //    return resultSet;
        //}

        public async Task<IEnumerable<UsersEntity>> GetAllAsync()
        {
            var resultSet = await _storageProvider.GetAllAsync();
            return resultSet.Select(p => p.MapToUsersEntity());
        }

        public async Task RemoveAsync(int key)
        {
            await _storageProvider.DeleteAsync(key);
        }

        public Task UpdateScore(int id, int newScore)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUsername(int id, string newUsername)
        {
            throw new NotImplementedException();
        }
    }
}
