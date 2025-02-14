using Dotnetstore.SDK.Requests;

namespace Dotnetstore.MinimalApi.Middleware;

public sealed class UpdateEmployeeRequestValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var item = context.GetArgument<UpdateEmployeeRequest>(0);

        if (item.Id == Guid.Empty)
        {
            return Results.Problem("Id must be a valid GUID", statusCode: 400);
        }
        
        switch (item.Name.Length)
        {
            case < 3:
                return Results.Problem("Name must be at least 3 characters long", statusCode: 400);
            case > 100:
                return Results.Problem("Name must be at most 100 characters long", statusCode: 400);
        }

        if (item.Salary < 0)
        {
            return Results.Problem("Salary must be greater than or equal to 0", statusCode: 400);
        }
        
        switch (item.Address.Length)
        {
            case < 3:
                return Results.Problem("Address must be at least 3 characters long", statusCode: 400);
            case > 100:
                return Results.Problem("Address must be at most 100 characters long", statusCode: 400);
        }

        switch (item.City.Length)
        {
            case < 1:
                return Results.Problem("City must be at least 1 characters long", statusCode: 400);
            case > 30:
                return Results.Problem("City must be at most 30 characters long", statusCode: 400);
        }

        if (item.Region is { Length: > 100 })
        {
            return Results.Problem("Region must be at most 100 characters long", statusCode: 400);
        }
        
        switch (item.PostalCode.Length)
        {
            case < 4:
                return Results.Problem("Postal code must be at least 4 characters long", statusCode: 400);
            case > 10:
                return Results.Problem("Postal code must be at most 10 characters long", statusCode: 400);
        }

        switch (item.Country.Length)
        {
            case < 1:
                return Results.Problem("Country must be at least 1 characters long", statusCode: 400);
            case > 30:
                return Results.Problem("Country must be at most 30 characters long", statusCode: 400);
        }

        return item.Phone.Length switch
        {
            < 1 => Results.Problem("Phone must be at least 1 characters long", statusCode: 400),
            > 30 => Results.Problem("Phone must be at most 30 characters long", statusCode: 400),
            _ => await next(context)
        };
    }
}