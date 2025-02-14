using System.Collections;
using Dotnetstore.Organization.Data;

namespace Dotnetstore.Organization.Services;

internal sealed class UnitOfWork(ApplicationDataContext context) : IUnitOfWork, IDisposable
{
    private readonly ApplicationDataContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly Hashtable _repositories = new();

    IGenericRepository<T> IUnitOfWork.Repository<T>()
    {
        var type = typeof(T).Name;

        if (_repositories.ContainsKey(type)) return (IGenericRepository<T>)_repositories[type]!;
        var repositoryType = typeof(GenericRepository<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
        _repositories.Add(type, repositoryInstance);

        return (IGenericRepository<T>) _repositories[type]!;
    }
    
    async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    void IUnitOfWork.Rollback()
    {
        _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
    }
    
    public void Dispose()
    {
        _context.Dispose();
        _repositories.Clear();
    }
}