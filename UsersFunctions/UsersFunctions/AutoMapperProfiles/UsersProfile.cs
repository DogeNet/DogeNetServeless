using AutoMapper;
using System.Collections.Generic;
using UsersFunctions.AutoMapperProfiles.CustomResolvers;
using UsersFunctions.Commands.Abstractions.Models;
using UsersFunctions.ViewModels;

namespace UsersFunctions.AutoMapperProfiles
{
    class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<List<UserModel>, UsersViewModel>().ForMember(dest=> dest.Users, option=> option.MapFrom<UsersViewModelResolver>());
        }
    }
}
