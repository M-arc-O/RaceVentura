using AutoMapper;
using RaceVenturaWebApp.Business.Models;
using RaceVenturaWebApp.Shared.Dtos;

namespace Api.MappingProfiles;
public class RaceProfiles : Profile
{
	public RaceProfiles()
	{
		CreateMap<RaceModel, RaceDto>();
	}
}
