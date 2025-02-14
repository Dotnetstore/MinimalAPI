namespace Dotnetstore.SDK.Requests;

public record struct CreateEmployeeRequest(
    string Name,
    decimal Salary,
    string Address,
    string City,
    string? Region,
    string PostalCode,
    string Country,
    string Phone);