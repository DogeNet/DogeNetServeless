using System.Collections.Generic;
using UsersFunctions.Commands.Abstractions.Models;

namespace UsersFunctions.Commands.Abstractions
{
    public interface IGetUsersCommand
    {
        List<UserModel> GetUsers();
    }
}
