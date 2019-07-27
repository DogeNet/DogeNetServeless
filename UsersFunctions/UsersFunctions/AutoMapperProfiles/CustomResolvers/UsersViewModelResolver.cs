using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using UsersFunctions.Commands.Abstractions.Models;
using UsersFunctions.ViewModels;
using UsersFunctions.ViewModels.Data;

namespace UsersFunctions.AutoMapperProfiles.CustomResolvers
{
    class UsersViewModelResolver : IValueResolver<List<UserModel>, UsersViewModel, List<User>>
    {
        public List<User> Resolve(List<UserModel> source, UsersViewModel destination, List<User> destMember, ResolutionContext context)
        {
            destMember = source.Select<UserModel,User>(userModel => new User {
                DogeID = userModel.DogeID,
                Username = userModel.Username,
                Score = userModel.Score
            }).ToList();

            return destMember;
        }
    }
}
