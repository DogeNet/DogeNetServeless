using System.Collections.Generic;
using UsersFunctions.Commands.Abstractions;
using UsersFunctions.Commands.Abstractions.Models;

namespace UsersFunctions.Commands
{
    public class GetUsersCommand : IGetUsersCommand
    {
        public List<UserModel> GetUsers()
        {
            return new List<UserModel> {
                new UserModel
                {
                    Username ="Toby",
                    DogeID = 1,
                    Score = 1000
                },
                new UserModel
                {
                    Username ="Andy",
                    DogeID = 2,
                    Score = 1000
                }
            };
        }
    }
}
