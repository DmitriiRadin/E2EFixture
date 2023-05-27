using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E2EFixtures;

public static class E2EContainer
{
    private static readonly ConcurrentDictionary<string, IServiceProvider> Containers = new();

    public static IServiceProvider GetOrInit<TStartup>() where TStartup : IStartup, new()
    {
        var type = typeof(TStartup);
        var key = $"{type.Assembly.FullName}{type.FullName}";

        return Containers.GetOrAdd(key, s => Init<TStartup>());
    }

    private static IServiceProvider Init<TStartup>() where TStartup : IStartup, new()
    {
        var configuration = GetConfiguration();

        var services = new ServiceCollection();
        services.AddSingleton(configuration);

        var startup = new TStartup();
        startup.Configure(services, configuration);

        return services.BuildServiceProvider();
    }

    private static IConfiguration GetConfiguration()
    {
        var configurationRoot = new ConfigurationBuilder()
            .AddJsonFile("appsettings.E2ETests.json")
            .Build();

        return configurationRoot;
    }
}