using RaceVenturaWebApp.Infrastructure.Entities;

namespace RaceVenturaWebApp.Infrastructure.Extensions;
public static class RaceExtension
{
    public static Shared.Race ToSharedBankAccount(this Race from)
    {
        return new Shared.Race(from.Id, from.Name);
    }
}
