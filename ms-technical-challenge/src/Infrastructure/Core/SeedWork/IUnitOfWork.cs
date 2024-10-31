namespace SB.TechnicalChallenge.Infrastructure;
using Domain;
using Microsoft.EntityFrameworkCore.Storage;
public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : Entity;
    Task<int> SaveEntitiesAsync(CancellationToken cancellationToken);
    Task<IDbContextTransaction> BeginTransactionAsync();
    IExecutionStrategy CreateExecutionStrategy();
}
