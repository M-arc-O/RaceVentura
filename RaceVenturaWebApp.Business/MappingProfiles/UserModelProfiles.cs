using AutoMapper;
using RaceVenturaWebApp.Business.Models;
using RaceVenturaWebApp.Infrastructure.Entities;

namespace RaceVenturaWebApp.Business.MappingProfiles;
public class UserModelProfiles : Profile
{
    public UserModelProfiles()
    {
        CreateMap<UserModel, User>();
        CreateMap<User, UserModel>();
    }
}
