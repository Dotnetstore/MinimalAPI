using Dotnetstore.Organization.Models;

namespace Dotnetstore.Organization.Services;

internal interface IUnitOfWork
{
    IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    void Rollback();
}