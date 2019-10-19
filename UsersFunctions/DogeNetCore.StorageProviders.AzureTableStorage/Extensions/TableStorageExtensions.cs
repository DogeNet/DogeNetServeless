namespace DogeNetCore.StorageProviders.AzureTableStorage.Extensions
{
    public static class TableStorageExtensions
    {
        public static int GetPartitionKey(this int id)
        {
            return id % 4;
        }
    }
}
