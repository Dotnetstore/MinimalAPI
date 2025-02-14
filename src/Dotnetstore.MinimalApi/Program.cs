using Ardalis.Result;
using Dotnetstore.MinimalApi.Extensions;
using Dotnetstore.MinimalApi.Middleware;
using Dotnetstore.Organization.Employees;
using Dotnetstore.SDK.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMinimalApi();

var app = builder.Build();

app.MapOpenApi();
app
    .UseMiddleware<ExceptionHandlingMiddleware>()
    .UseMiddleware<LoggingMiddleware>();

var scope = app.Services.CreateScope();
var employeeService = scope.ServiceProvider.GetRequiredService<IEmployeeService>();

app.MapGet("/employees", async () =>
{
    var employees = await employeeService.GetAllAsync();
    return Results.Ok(employees);
});

app.MapGet("/employees/{id:guid}", async (Guid id) =>
{
    var employee = await employeeService.GetAsync(id);
    return employee is not null ? Results.Ok(employee) : Results.NotFound();
});

app.MapPost("/employees", async (CreateEmployeeRequest employee) =>
    {
        var result = await employeeService.CreateAsync(employee);
        
         if (result.Status != ResultStatus.Ok)
         {
             return Results.BadRequest(result.Errors);
         }

         return Results.Created($"/employees/{result.Value.Id}", result.Value);
    })
    .AddEndpointFilter<CreateEmployeeRequestValidationFilter>();

app.MapPut("/employees", async (UpdateEmployeeRequest employee) =>
    {
        await employeeService.UpdateAsync(employee);
        return Results.NoContent();
    })
    .AddEndpointFilter<UpdateEmployeeRequestValidationFilter>();

app.MapDelete("/employees/{id:guid}", async (Guid id) =>
{
    var result = await employeeService.DeleteAsync(id);
    
    if (result.Status != ResultStatus.Ok)
    {
        return Results.NotFound(result.Errors);
    }
    
    return Results.NoContent();
});

app.MapGet("/employees/exceptionexample", () =>
{
    throw new Exception("An example exception");
});

app.Run();

public partial class Program;