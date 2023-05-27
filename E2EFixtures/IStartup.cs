using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E2EFixtures;

public interface IStartup
{
    void Configure(IServiceCollection services, IConfiguration configuration);
}