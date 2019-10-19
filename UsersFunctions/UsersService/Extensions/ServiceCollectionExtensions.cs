using Microsoft.Extensions.DependencyInjection;
using UsersService.Abstractions;

namespace UsersService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUsersService(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<IUsersService, UsersService>();
        }
    }
}
