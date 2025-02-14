using Dotnetstore.SDK.Requests;
using Dotnetstore.SDK.Responses;

namespace Dotnetstore.Organization.Employees;

internal static class EmployeeMappers
{
    internal static EmployeeResponse ToEmployeeResponse(this Employee employee)
    {
        return new EmployeeResponse(
            employee.Id,
            employee.Name,
            employee.Salary,
            employee.Address,
            employee.City,
            employee.Region,
            employee.PostalCode,
            employee.Country,
            employee.Phone);
    }
    
    internal static Employee ToEmployee(this CreateEmployeeRequest request)
    {
        return new Employee
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Salary = request.Salary,
            Address = request.Address,
            City = request.City,
            Region = request.Region,
            PostalCode = request.PostalCode,
            Country = request.Country,
            Phone = request.Phone,
            CreatedAt = DateTimeOffset.Now
        };
    }
}