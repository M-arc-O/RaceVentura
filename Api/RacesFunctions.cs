using System.Net;
using AutoMapper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using RaceVenturaWebApp.Business.Commands;
using RaceVenturaWebApp.Business.CQRS;
using RaceVenturaWebApp.Business.Models;
using RaceVenturaWebApp.Business.Queries;
using RaceVenturaWebApp.Business.Services;
using RaceVenturaWebApp.Shared.Dtos;
using RaceVenturaWebApp.Shared.Models;

namespace Api
{
    public class RaceFunctions : FunctionBase
    {
        //private readonly IExecutor _excecutor;
        //private readonly IMapper _mapper;

        //public RaceFunctions(IExecutor executor, IUserService userService, IMapper mapper)
        //    : base(userService)
        //{
        //    _excecutor = executor;
        //    _mapper = mapper;
        //}

        //[Function("GetRaces")]
        //public async Task<HttpResponseData> GetRaces([HttpTrigger(AuthorizationLevel.Function, "get", Route = "race/getall")] HttpRequestData req)
        //{
        //    var response = req.CreateResponse(HttpStatusCode.OK);

        //    try
        //    {
        //        var user = await GetUser(req);
        //        var query = new GetAllRacesQuery(user.Id);
        //        var races = await _excecutor.Execute<GetAllRacesQuery, IEnumerable<RaceModel>>(query);
        //        await response.WriteAsJsonAsync(races.Select(x => _mapper.Map<RaceDto>(x)));
        //    }
        //    catch (Exception ex)
        //    {
        //        var bankAccounts = new[] { new RaceDto(Guid.NewGuid(), ex.Message) };
        //        await response.WriteAsJsonAsync(bankAccounts);
        //    }

        //    return response;
        //}

        //[Function("AddRace")]
        //public async Task<HttpResponseData> AddRace([HttpTrigger(AuthorizationLevel.Function, "post", Route = "race/create")] HttpRequestData req)
        //{
        //    var race = await req.ReadFromJsonAsync<AddRaceModel>() ?? throw new Exception();

        //    var user = await GetUser(req);

        //    var command = new AddRaceCommand(user.Id, race.Name);
        //    await _excecutor.Execute<AddRaceCommand, RaceModel>(command);

        //    var response = req.CreateResponse(HttpStatusCode.OK);

        //    return response;
        //}
    }
}
