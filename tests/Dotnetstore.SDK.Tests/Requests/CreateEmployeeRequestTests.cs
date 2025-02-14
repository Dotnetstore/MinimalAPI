using Dotnetstore.SDK.Requests;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.SDK.Tests.Requests;

public class CreateEmployeeRequestTests
{
    [Fact]
    public void CreateEmployeeRequest_ShouldHaveProperties()
    {
        // Arrange
        var type = typeof(CreateEmployeeRequest);

        // Act
        var properties = type.GetProperties();

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