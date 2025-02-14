using Dotnetstore.Organization.Extensions;

namespace Dotnetstore.MinimalApi.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static void AddMinimalApi(this IServiceCollection services)
    {
        services
            .AddOrganization()
            .AddOpenApi();
    }
}