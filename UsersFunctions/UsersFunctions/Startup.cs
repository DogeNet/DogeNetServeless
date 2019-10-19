using DogeNetCore.DataAccess.Extensions;
using DogeNetCore.StorageProviders.AzureTableStorage.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using UsersService.Extensions;

[assembly: FunctionsStartup(typeof(UsersFunctions.Startup))]
namespace UsersFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;
            services.AddUsersAzureTableProvider();
            services.AddUsersRepository();
            services.AddUsersService();
        }
    }
}
