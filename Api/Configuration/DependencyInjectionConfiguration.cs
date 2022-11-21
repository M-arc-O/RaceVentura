using RaceVenturaWebApp.Business.Configuration;
using RaceVenturaWebApp.Infrastructure.Configuration;
using RaceVenturaWebApp.Infrastructure.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configuration;
public static class DependencyInjectionConfiguration
{
    public static void InitializeServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RaceVenturaWebAppDbContext>(options => 
            RaceVenturaWebAppDbContext.ConfigureDbContextOptions(options, configuration.GetValue<string>("RaceVenturaWebAppConnectionString")));

        services.AddBusinessServices();
        services.AddInfrastructureServices();
    }
}
