using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E2EFixtures.Tests;

public class TestStartup : IStartup
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    }
}