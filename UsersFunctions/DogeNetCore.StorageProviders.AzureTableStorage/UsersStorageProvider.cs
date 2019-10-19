using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogeNetCore.StorageProviders.Abstractions;
using DogeNetCore.StorageProviders.Abstractions.Entities;
using DogeNetCore.StorageProviders.AzureTableStorage.Entities;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DogeNetCore.StorageProviders.AzureTableStorage
{
    class UsersStorageProvider : IStorageProvider<UsersStorageEntity,int>
    {
        private readonly CloudStorageAccount cloudStorageAccount;
        private readonly CloudTableClient cloudTableClient;
        private readonly CloudTable usersTable;

        public UsersStorageProvider(IOptions<AzureTableSettings> tableSettings)
        {
            var connectionString = tableSettings.Value.UsersConnectionString;
            cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            usersTable = cloudTableClient.GetTableReference("Users");
        }

        public async Task CreateAsync(UsersStorageEntity entity)
        {
            await usersTable.CreateIfNotExistsAsync();
            var tableEntity = new UsersTableEntity(entity);
            var insertOperation = TableOperation.Insert(tableEntity);
            await usersTable.ExecuteAsync(insertOperation);
        }

        public async Task DeleteAsync(int id)
        {
            var tableEntity = new UsersTableEntity(id);
            var retrieveOperation = TableOperation.Retrieve<UsersTableEntity>(tableEntity.PartitionKey, tableEntity.RowKey);
            var result = await usersTable.ExecuteAsync(retrieveOperation);

            tableEntity = result.Result as UsersTableEntity;

            var deleteOperation = TableOperation.Delete(tableEntity);
            await usersTable.ExecuteAsync(deleteOperation);
        }

        public async Task<IEnumerable<UsersStorageEntity>> GetAllAsync()
        {
            TableContinuationToken token = null;
            var query = new TableQuery<UsersTableEntity>();
            var resultSet = new List<UsersStorageEntity>();

            do
            {
                var result = await usersTable.ExecuteQuerySegmentedAsync(query, token);
                resultSet.AddRange(result.Results.Select(p => new UsersStorageEntity
                {
                    DogeId = p.DogeId,
                    Username = p.Username,
                    Score = p.Score
                }));

                token = result.ContinuationToken;
            } while (token != null);

            return resultSet;
        }

        //TODO: Add when support for 2.1 in functions comes out

        //public async IAsyncEnumerable<UsersStorageEntity> GetAllAsync()
        //{
        //    TableContinuationToken token = null;
        //    var query = new TableQuery<UsersTableEntity>();
        //    do
        //    {
        //        var result = await usersTable.ExecuteQuerySegmentedAsync(query, token);

        //        foreach (var entity in result.Results)
        //        {
        //            yield return new UsersStorageEntity
        //            {
        //                DogeId = entity.DogeId,
        //                Username = entity.Username,
        //                Score = entity.Score
        //            };
        //        }
        //        token = result.ContinuationToken;
        //    } while (token != null);
        //}

        public async Task<UsersStorageEntity> GetAsync(int id)
        {
            await usersTable.CreateIfNotExistsAsync();

            var tableEntity = new UsersTableEntity(id);
            var retrieveOperation = TableOperation.Retrieve<UsersTableEntity>(tableEntity.PartitionKey,tableEntity.RowKey);
            var result = await usersTable.ExecuteAsync(retrieveOperation);

            tableEntity = result.Result as UsersTableEntity;

            return new UsersStorageEntity
            {
                DogeId = tableEntity.DogeId,
                Username = tableEntity.Username,
                Score = tableEntity.Score
            };
        }

        public async Task UpdateAsync(UsersStorageEntity entity)
        {
            await usersTable.CreateIfNotExistsAsync();
            var tableEntity = new UsersTableEntity(entity);
            var updateOperation = TableOperation.Replace(tableEntity);
            await usersTable.ExecuteAsync(updateOperation);
        }
    }
}
