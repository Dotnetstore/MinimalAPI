namespace Dotnetstore.SDK.Responses;

public record struct EmployeeResponse(
    Guid Id,
    string Name,
    decimal Salary,
    string Address,
    string City,
    string? Region,
    string PostalCode,
    string Country,
    string Phone);