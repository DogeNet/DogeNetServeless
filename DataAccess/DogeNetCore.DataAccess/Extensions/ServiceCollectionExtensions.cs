using DogeNetCore.DataAccess.Abstractions.UsersRepository;
using Microsoft.Extensions.DependencyInjection;

namespace DogeNetCore.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUsersRepository(this IServiceCollection services)
        {
            return services.AddSingleton<IUsersRepository,UsersRepository>();
        }
    }
}
