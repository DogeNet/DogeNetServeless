using DogeNetCore.StorageProviders.Abstractions.Entities;
using DogeNetCore.StorageProviders.AzureTableStorage.Extensions;
using Microsoft.WindowsAzure.Storage.Table;

namespace DogeNetCore.StorageProviders.AzureTableStorage.Entities
{
    public class UsersTableEntity : TableEntity
    {
        public UsersTableEntity()
        {
        }

        public UsersTableEntity(int dogeId)
        {
            DogeId = dogeId;

            PartitionKey = DogeId.GetPartitionKey().ToString();
            RowKey = DogeId.ToString();
        }

        public UsersTableEntity(UsersStorageEntity entity)
        {
            Username = entity.Username;
            DogeId = entity.DogeId;
            Score = entity.Score;

            PartitionKey = DogeId.GetPartitionKey().ToString();
            RowKey = DogeId.ToString();
        }
        public string Username { get; set; }
        public int DogeId { get; set; }
        public int Score { get; set; }
    }
}
