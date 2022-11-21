using RaceVenturaWebApp.Infrastructure;
using RaceVenturaWebApp.Infrastructure.Extensions;
using RaceVenturaWebApp.Infrastructure.Repositories;
using RaceVenturaWebApp.Shared;

namespace RaceVenturaWebApp.Business;
public class BankAccountBusiness : IBankAccountBusiness
{
    private readonly IGenericRepository<Infrastructure.Entities.Race> _bankAccountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BankAccountBusiness(IGenericRepository<Infrastructure.Entities.Race> bankAccountRepository, IUnitOfWork unitOfWork)
    {
        _bankAccountRepository = bankAccountRepository;
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Race> GetBankAccounts()
    {
        return _bankAccountRepository.Get().Select(x => x.ToSharedBankAccount());
    }

    public async Task AddBankAccount(Race bankAccount)
    {
        var bankAccountEntity = new Infrastructure.Entities.Race(
            Guid.NewGuid(),
            bankAccount.Name
        );
        _bankAccountRepository.Insert(bankAccountEntity);

        await _unitOfWork.CommitAsync();
    }
}
