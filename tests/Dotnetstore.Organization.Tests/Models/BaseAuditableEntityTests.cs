using Dotnetstore.Organization.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Organization.Tests.Models;

public class BaseAuditableEntityTests
{
    [Fact]
    public void BaseAuditableEntity_ShouldHaveProperties()
    {
        // Arrange
        var baseAuditableEntity = typeof(BaseAuditableEntity);

        // Act
        var properties = baseAuditableEntity.GetProperties();

        // Assert
        using (new AssertionScope())
        {
            properties.Should().ContainSingle(p => p.Name == "Id");
            properties.Should().ContainSingle(p => p.Name == "CreatedAt");
            properties.Should().ContainSingle(p => p.Name == "CreatedBy");
            properties.Should().ContainSingle(p => p.Name == "UpdatedAt");
            properties.Should().ContainSingle(p => p.Name == "UpdatedBy");
            properties.Should().ContainSingle(p => p.Name == "DeletedAt");
            properties.Should().ContainSingle(p => p.Name == "DeletedBy");
            properties.Should().ContainSingle(p => p.Name == "IsDeleted");
            properties.Should().ContainSingle(p => p.Name == "IsSystem");
        }
    }
}