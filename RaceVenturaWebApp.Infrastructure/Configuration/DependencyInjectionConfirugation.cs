using RaceVenturaWebApp.Infrastructure.Entities;
using RaceVenturaWebApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace RaceVenturaWebApp.Infrastructure.Configuration;
public static class DependencyInjectionConfirugation
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGenericRepository<Race>, GenericRepository<Race>>();
        services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
    }
}
