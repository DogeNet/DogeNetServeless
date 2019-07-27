using AutoMapper;
using DogeNet.NetworkingTools;
using DogeNet.NetworkingTools.Abstractions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using UsersFunctions.AutoMapperProfiles;
using UsersFunctions.Commands;
using UsersFunctions.Commands.Abstractions;

[assembly: FunctionsStartup(typeof(UsersFunctions.Startup))]
namespace UsersFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ISerializer, JsonNetSerializer>();
            builder.Services.AddSingleton<IGetUsersCommand, GetUsersCommand>();
            builder.Services.AddAutoMapper(typeof(UsersProfile).Assembly);
        }
    }
}
