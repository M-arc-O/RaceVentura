using RaceVenturaWebApp.Business.Models;

namespace RaceVenturaWebApp.Business.Services;
public interface IUserService
{
    Task MakeSureUserExists(UserModel user);
    Task<UserModel> GetUserByProviderId(string providerId);
}
