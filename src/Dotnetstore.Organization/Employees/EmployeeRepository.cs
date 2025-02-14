using Dotnetstore.Organization.Services;
using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.Organization.Employees;

internal sealed class EmployeeRepository(IUnitOfWork unitOfWork) : IEmployeeRepository
{
    private IQueryable<Employee> GetBaseQuery()
    {
        return unitOfWork
            .Repository<Employee>()
            .Entities
            .AsNoTracking()
            .OrderBy(x => x.Name);
    }

    async ValueTask<IEnumerable<Employee>> IEmployeeRepository.GetAllAsync(CancellationToken cancellationToken)
    {
        var query = GetBaseQuery();
        return await query.ToListAsync(cancellationToken);
    }

    async ValueTask<Employee?> IEmployeeRepository.GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = GetBaseQuery();
        return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    void IEmployeeRepository.Create(Employee employee)
    {
        unitOfWork.Repository<Employee>().Create(employee);
    }

    void IEmployeeRepository.Update(Employee employee)
    {
        unitOfWork.Repository<Employee>().Update(employee);
    }

    void IEmployeeRepository.Delete(Employee employee)
    {
        unitOfWork.Repository<Employee>().Delete(employee);
    }

    async ValueTask<int> IEmployeeRepository.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}