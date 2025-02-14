using System.Net;
using System.Net.Http.Json;
using Dotnetstore.Organization.Data;
using Dotnetstore.Organization.Extensions;
using Dotnetstore.SDK.Requests;
using Dotnetstore.SDK.Responses;
using Dotnetstore.TestHelper;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace Dotnetstore.MinimalApi.Tests.Integration;

public class EmployeeEndpointTests(ApiWebApplicationFactory factory) : IClassFixture<ApiWebApplicationFactory>
{
    [Fact]
    public async Task GetAllEmployees_ReturnsSuccessStatusCode()
    {
        // Arrange
        using var client = factory.CreateClient();
        
        // Act
        var response = await client.GetAsync("/employees");
        var content = await response.Content.ReadAsStringAsync();
        var employees = JsonConvert.DeserializeObject<List<EmployeeResponse>>(content);
        
        // Assert
        using (new AssertionScope())
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            employees.Should().NotBeEmpty();
            response.EnsureSuccessStatusCode();
            employees.Should().HaveCount(1);
        }
    }
    
    [Fact]
    public async Task GetEmployeeById_ReturnsSuccessStatusCode()
    {
        // Arrange
        using var client = factory.CreateClient();
        
        // Act
        var response = await client.GetAsync("/employees/39B16AE6-683C-427E-9DB2-3EF22DB88B75");
        var content = await response.Content.ReadAsStringAsync();
        var employee = JsonConvert.DeserializeObject<EmployeeResponse>(content);
        
        // Assert
        using (new AssertionScope())
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            employee.Should().NotBeNull();
            response.EnsureSuccessStatusCode();
            employee.Id.Should().Be("39B16AE6-683C-427E-9DB2-3EF22DB88B75");
        }
    }

    [Fact]
    public async Task CreateEmployee_ReturnsSuccessStatusCode()
    {
        // Arrange
        using var client = factory.CreateClient();
        var employee = new CreateEmployeeRequest
        {
            Name = "John Doe",
            Salary = 50000,
            Address = "Testgatan 1",
            City = "Teststad",
            PostalCode = "12345",
            Country = "Testland",
            Phone = "0725060502",
            Region = "Testlän"
        };
        
        // Act
        var response = await client.PostAsJsonAsync("/employees", employee);
        
        // Assert
        using (new AssertionScope())
        {
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.EnsureSuccessStatusCode();
        }
    }
    
    [Fact]
    public async Task CreateEmployee_ReturnsBadRequestStatusCode()
    {
        // Arrange
        using var client = factory.CreateClient();
        var employee = new CreateEmployeeRequest
        {
            Name = "J",
            Salary = 50000,
            Address = "Testgatan 1",
            City = "Teststad",
            PostalCode = "12345",
            Country = "Testland",
            Phone = "0725060502",
            Region = "Testlän"
        };
        
        // Act
        var response = await client.PostAsJsonAsync("/employees", employee);
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task UpdateEmployee_ReturnsSuccessStatusCode()
    {
        // Arrange
        using var client = factory.CreateClient();
        var employee = new UpdateEmployeeRequest
        {
            Id = Guid.Parse("39B16AE6-683C-427E-9DB2-3EF22DB88B75"),
            Name = "John Doe",
            Salary = 50000,
            Address = "Testgatan 1",
            City = "Teststad",
            PostalCode = "12345",
            Country = "Testland",
            Phone = "0725060502",
            Region = "Testlän"
        };
        
        // Act
        var response = await client.PutAsJsonAsync("/employees", employee);
        
        // Assert
        using (new AssertionScope())
        {
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            response.EnsureSuccessStatusCode();
        }
    }
    
    [Fact]
    public async Task UpdateEmployee_ReturnsBadRequestStatusCode()
    {
        // Arrange
        using var client = factory.CreateClient();
        var employee = new UpdateEmployeeRequest
        {
            Id = Guid.Parse("39B16AE6-683C-427E-9DB2-3EF22DB88B75"),
            Name = "J",
            Salary = 50000,
            Address = "Testgatan 1",
            City = "Teststad",
            PostalCode = "12345",
            Country = "Testland",
            Phone = "0725060502",
            Region = "Testlän"
        };
        
        // Act
        var response = await client.PutAsJsonAsync("/employees", employee);
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task DeleteEmployee_ReturnsSuccessStatusCode()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.RemoveDbContext<ApplicationDataContext>();
                    services.AddDbContext<ApplicationDataContext>(Guid.NewGuid().ToString());
                    services.EnsureDbDeleted<ApplicationDataContext>();
                    services.EnsureDbCreated<ApplicationDataContext>();
                });
            });
        using var client = application.CreateClient();
        // Act
        var response = await client.DeleteAsync("/employees/39B16AE6-683C-427E-9DB2-3EF22DB88B75");
        
        // Assert
        using (new AssertionScope())
        {
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            response.EnsureSuccessStatusCode();
        }
    }
    
    [Fact]
    public async Task DeleteEmployee_ReturnsNotFoundStatusCode()
    {
        // Arrange
        using var client = factory.CreateClient();
        
        // Act
        var response = await client.DeleteAsync("/employees/39B16AE6-683C-427E-9DB2-3EF22DB88B76");
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
    [Fact]
    public async Task ExceptionExample_ReturnsInternalServerErrorStatusCode()
    {
        // Arrange
        using var client = factory.CreateClient();
        
        // Act
        var response = await client.GetAsync("/employees/exceptionexample");
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }
}