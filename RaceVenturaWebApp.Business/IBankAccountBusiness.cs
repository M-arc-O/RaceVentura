using RaceVenturaWebApp.Shared;

namespace RaceVenturaWebApp.Business;
public interface IBankAccountBusiness
{
    Task AddBankAccount(Race bankAccount);
    IEnumerable<Race> GetBankAccounts();
}