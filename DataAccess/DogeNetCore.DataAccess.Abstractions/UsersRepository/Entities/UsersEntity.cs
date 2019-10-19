using DogeNetCore.DataAccess.Abstractions.Entities;

namespace DogeNetCore.DataAccess.Abstractions.UsersRepository.Entities
{
    public class UsersEntity : IEntity<int>
    {
        public int DogeId { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public int Key => DogeId;
    }
}
