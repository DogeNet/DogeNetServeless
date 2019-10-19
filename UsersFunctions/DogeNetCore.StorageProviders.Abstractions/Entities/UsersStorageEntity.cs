namespace DogeNetCore.StorageProviders.Abstractions.Entities
{
    public class UsersStorageEntity : IStorageEntity<int>
    {
        public string Username { get; set; }
        public int DogeId { get; set; }
        public int Score { get; set; }

        public int Key => DogeId;
    }
}
