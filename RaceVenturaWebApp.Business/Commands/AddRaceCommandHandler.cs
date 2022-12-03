using AutoMapper;
using RaceVenturaWebApp.Business.CQRS;
using RaceVenturaWebApp.Business.Models;
using RaceVenturaWebApp.Infrastructure.Entities;
using RaceVenturaWebApp.Infrastructure.Repositories;

namespace RaceVenturaWebApp.Business.Commands;
public class AddRaceCommandHandler : IHandler<AddRaceCommand, RaceModel>
{
    private readonly IGenericRepository<Race> _raceRepository;
    private readonly IMapper _mapper;

    public AddRaceCommandHandler(IGenericRepository<Race> raceRepository, IMapper mapper)
    {
        _raceRepository = raceRepository;
        _mapper = mapper;
    }

    public async Task<RaceModel> ExecuteAsync(AddRaceCommand command)
    {
        var race = new Race {
            Id = Guid.NewGuid(),
            UserId = command.UserId,
            Name = command.Name
        };
        await _raceRepository.InsertAsync(race);

        return _mapper.Map<RaceModel>(race);
    }
}
