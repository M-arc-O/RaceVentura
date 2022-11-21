using RaceVenturaWebApp.Infrastructure.Contexts;

namespace RaceVenturaWebApp.Infrastructure;
public class UnitOfWork : IUnitOfWork
{
    private readonly RaceVenturaWebAppDbContext _dbContext;

    public UnitOfWork(RaceVenturaWebAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CommitAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
