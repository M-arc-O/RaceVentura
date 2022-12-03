using AutoMapper;
using RaceVenturaWebApp.Business.CQRS;
using RaceVenturaWebApp.Business.Models;
using RaceVenturaWebApp.Infrastructure.Entities;
using RaceVenturaWebApp.Infrastructure.Repositories;

namespace RaceVenturaWebApp.Business.Queries;
public class GetAllRacesQueryHandler : IHandler<GetAllRacesQuery, IEnumerable<RaceModel>>
{
    private readonly IGenericRepository<Race> _raceRepository;
    private readonly IMapper _mapper;

    public GetAllRacesQueryHandler(IGenericRepository<Race> raceRepository, IMapper mapper)
    {
        _raceRepository = raceRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RaceModel>> ExecuteAsync(GetAllRacesQuery query)
    {
        var accounts = await _raceRepository.GetAsync(x => x.UserId == query.UserId);
        return accounts.Select(x => _mapper.Map<RaceModel>(x));
    }
}
