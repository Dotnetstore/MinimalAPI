using Dotnetstore.Organization.Data;
using Dotnetstore.Organization.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace Dotnetstore.TestHelper;

public class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddOrganization();
            
            services.RemoveDbContext<ApplicationDataContext>();
            services.AddDbContext<ApplicationDataContext>(Guid.NewGuid().ToString());
            services.EnsureDbDeleted<ApplicationDataContext>();
            services.EnsureDbCreated<ApplicationDataContext>();
        });
    }
}