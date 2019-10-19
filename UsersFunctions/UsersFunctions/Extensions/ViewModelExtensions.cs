using UsersFunctions.ViewModels.Data;
using UsersService.Abstractions.Models;

namespace UsersFunctions.Extensions
{
    public static class ViewModelExtensions
    {
        public static UsersViewModel MapToUsersViewModel(this User input)
        {
            return new UsersViewModel
            {
                DogeId = input.DogeId,
                Username = input.Username,
                Score = input.Score
            };
        }

        public static User MapToUser(this UsersViewModel input)
        {
            return new User
            {
                DogeId = input.DogeId,
                Username = input.Username,
                Score = input.Score
            };
        }
    }
}
