using System.ComponentModel.DataAnnotations;

namespace DogeNetCore.DataAccess.Abstractions.Entities
{
    public interface IEntity<out TKey>
    {
        [Key]
        TKey Key { get; }
    }
}
