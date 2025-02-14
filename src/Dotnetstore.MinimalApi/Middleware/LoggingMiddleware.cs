namespace Dotnetstore.MinimalApi.Middleware;

internal sealed class LoggingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Request logging: {context.Request.Method}{context.Request.Path}");
        await next(context);
        Console.WriteLine($"Response logging: {context.Response.StatusCode}");
    }
}