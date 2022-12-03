using AutoMapper;
using RaceVenturaWebApp.Business.Models;
using RaceVenturaWebApp.Infrastructure.Entities;

namespace RaceVenturaWebApp.Business.MappingProfiles;
public class RaceModelProfiles : Profile
{
    public RaceModelProfiles()
    {
        CreateMap<RaceModel, Race>();
        CreateMap<Race, RaceModel>();
    }
}
