namespace DogeNetCore.StorageProviders.Abstractions.Entities
{
    public interface IStorageEntity<TKey>
    {
        TKey Key { get; }
    }
}
