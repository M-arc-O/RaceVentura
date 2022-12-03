using RaceVenturaWebApp.Business.Commands;
using RaceVenturaWebApp.Business.CQRS;
using RaceVenturaWebApp.Business.Models;
using RaceVenturaWebApp.Business.Queries;
using RaceVenturaWebApp.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace RaceVenturaWebApp.Business.Configuration;
public static class DependencyInjectionConfiguration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IExecutor, Executor>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IHandler<GetAllRacesQuery, IEnumerable<RaceModel>>, GetAllRacesQueryHandler>();

        services.AddScoped<IHandler<AddRaceCommand, RaceModel>, AddRaceCommandHandler>();
    }
}
