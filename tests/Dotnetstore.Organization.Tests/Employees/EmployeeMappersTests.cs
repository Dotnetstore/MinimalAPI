using Dotnetstore.Organization.Employees;
using Dotnetstore.SDK.Requests;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Organization.Tests.Employees;

public class EmployeeMappersTests
{
    [Fact]
    public void ToEmployeeResponse_ShouldMapEmployeeToEmployeeResponse()
    {
        // Arrange
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            Salary = 1000,
            Address = "123 Main St",
            City = "Springfield",
            Region = "IL",
            PostalCode = "62701",
            Country = "USA",
            Phone = "555-555-5555"
        };

        // Act
        var response = employee.ToEmployeeResponse();

        // Assert
        using (new AssertionScope())
        {
            employee.Id.Should().Be(response.Id);
            employee.Name.Should().Be(response.Name);
            employee.Salary.Should().Be(response.Salary);
            employee.Address.Should().Be(response.Address);
            employee.City.Should().Be(response.City);
            employee.Region.Should().Be(response.Region);
            employee.PostalCode.Should().Be(response.PostalCode);
            employee.Country.Should().Be(response.Country);
            employee.Phone.Should().Be(response.Phone);
        }
    }
    
    [Fact]
    public void ToEmployee_ShouldMapCreateEmployeeRequestToEmployee()
    {
        // Arrange
        var request = new CreateEmployeeRequest(
            "John Doe",
            1000,
            "123 Main St",
            "Springfield",
            "IL",
            "62701",
            "USA",
            "555-555-5555");
    
        // Act
        var employee = request.ToEmployee();
    
        // Assert
        using (new AssertionScope())
        {
            employee.Name.Should().Be(request.Name);
            employee.Salary.Should().Be(request.Salary);
            employee.Address.Should().Be(request.Address);
            employee.City.Should().Be(request.City);
            employee.Region.Should().Be(request.Region);
            employee.PostalCode.Should().Be(request.PostalCode);
            employee.Country.Should().Be(request.Country);
            employee.Phone.Should().Be(request.Phone);
            employee.CreatedAt.Should().BeCloseTo(DateTimeOffset.Now, new TimeSpan(0, 0, 1));
        }
    }
}