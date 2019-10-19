using DogeNetCore.StorageProviders.Abstractions;
using DogeNetCore.StorageProviders.Abstractions.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DogeNetCore.StorageProviders.AzureTableStorage.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUsersAzureTableProvider(this IServiceCollection services)
        {
            services.AddOptions<AzureTableSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.Bind(settings);
                });
            return services.AddSingleton<IStorageProvider<UsersStorageEntity, int>, UsersStorageProvider>();
        }
    }
}
