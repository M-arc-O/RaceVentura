using RaceVenturaWebApp.Business.Configuration;
using RaceVenturaWebApp.Infrastructure.Configuration;
using RaceVenturaWebApp.Infrastructure.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using RaceVenturaWebApp.Business.MappingProfiles;
using Api.MappingProfiles;

namespace Api.Configuration;
public static class DependencyInjectionConfiguration
{
    public static void InitializeServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RaceVenturaWebAppDbContext>(options => 
            RaceVenturaWebAppDbContext.ConfigureDbContextOptions(options, configuration.GetValue<string>("RaceVenturaWebAppConnectionString")));

        services.AddBusinessServices();
        services.AddInfrastructureServices();

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new RaceProfiles());
            mc.AddProfile(new UserProfiles());

            mc.AddProfile(new RaceModelProfiles());
            mc.AddProfile(new UserModelProfiles());
        });

        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}
