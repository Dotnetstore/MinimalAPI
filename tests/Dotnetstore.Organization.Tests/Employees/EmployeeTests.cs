using Dotnetstore.Organization.Employees;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Organization.Tests.Employees;

public class EmployeeTests
{
    [Fact]
    public void Employee_ShouldHaveProperties()
    {
        // Arrange
        var employee = typeof(Employee);

        // Act
        var properties = employee.GetProperties();

        // Assert
        using (new AssertionScope())
        {
            properties.Should().ContainSingle(p => p.Name == "Name");
            properties.Should().ContainSingle(p => p.Name == "Salary");
            properties.Should().ContainSingle(p => p.Name == "Address");
            properties.Should().ContainSingle(p => p.Name == "City");
            properties.Should().ContainSingle(p => p.Name == "Region");
            properties.Should().ContainSingle(p => p.Name == "PostalCode");
            properties.Should().ContainSingle(p => p.Name == "Country");
            properties.Should().ContainSingle(p => p.Name == "Phone");
        }
    }
}