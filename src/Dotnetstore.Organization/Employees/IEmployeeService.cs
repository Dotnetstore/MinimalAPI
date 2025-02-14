using Ardalis.Result;
using Dotnetstore.SDK.Requests;
using Dotnetstore.SDK.Responses;

namespace Dotnetstore.Organization.Employees;

public interface IEmployeeService
{
    ValueTask<IEnumerable<EmployeeResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    
    ValueTask<EmployeeResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    
    ValueTask<Result<EmployeeResponse>> CreateAsync(CreateEmployeeRequest employee, CancellationToken cancellationToken = default);
    
    ValueTask UpdateAsync(UpdateEmployeeRequest employee, CancellationToken cancellationToken = default);
    
    ValueTask<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}