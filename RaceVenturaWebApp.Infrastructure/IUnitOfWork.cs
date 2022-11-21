namespace RaceVenturaWebApp.Infrastructure;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}