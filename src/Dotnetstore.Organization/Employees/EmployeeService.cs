using Ardalis.Result;
using Dotnetstore.SDK.Requests;
using Dotnetstore.SDK.Responses;

namespace Dotnetstore.Organization.Employees;

internal sealed class EmployeeService(IEmployeeRepository repository) : IEmployeeService
{
    async ValueTask<IEnumerable<EmployeeResponse>> IEmployeeService.GetAllAsync(CancellationToken cancellationToken)
    {
        var employees = await repository.GetAllAsync(cancellationToken);
        return employees.Select(e => e.ToEmployeeResponse());
    }

    async ValueTask<EmployeeResponse?> IEmployeeService.GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var employee = await repository.GetAsync(id, cancellationToken);
        return employee?.ToEmployeeResponse();
    }

    async ValueTask<Result<EmployeeResponse>> IEmployeeService.CreateAsync(CreateEmployeeRequest employee, CancellationToken cancellationToken)
    {
        var employeeToAdd = employee.ToEmployee();
        repository.Create(employeeToAdd);
        var result = await repository.SaveChangesAsync(cancellationToken);
        
        if(result < 1)
        {
            return Result<EmployeeResponse>.Error("Failed to create employee");
        }
        
        return employeeToAdd.ToEmployeeResponse();
    }

    async ValueTask IEmployeeService.UpdateAsync(UpdateEmployeeRequest employee, CancellationToken cancellationToken)
    {
        var employeeToUpdate = await repository.GetAsync(employee.Id, cancellationToken);
        if (employeeToUpdate is null)
        {
            throw new KeyNotFoundException();
        }
        
        employeeToUpdate.Name = employee.Name;
        repository.Update(employeeToUpdate);
        await repository.SaveChangesAsync(cancellationToken);
    }

    async ValueTask<Result> IEmployeeService.DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var employeeToDelete = await repository.GetAsync(id, cancellationToken);
        
        if (employeeToDelete is null)
        {
            return Result.NotFound("Employee not found");
        }
        
        repository.Delete(employeeToDelete);
        var result = await repository.SaveChangesAsync(cancellationToken);
        
        return result < 1 ? Result.Error("Failed to delete employee") : Result.Success();
    }
}