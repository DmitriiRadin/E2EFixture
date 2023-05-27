using Microsoft.Extensions.DependencyInjection;

namespace E2EFixtures;

public class ClassFixture<TStartup> : IDisposable where TStartup : IStartup, new()
{
    private readonly IServiceScope _serviceScope;

    public ClassFixture()
    {
        var rootServiceProvider = E2EContainer.GetOrInit<TStartup>();
        _serviceScope = rootServiceProvider.CreateScope();
    }

    public TService GetService<TService>() where TService : notnull
    {
        return _serviceScope.ServiceProvider.GetRequiredService<TService>();
    }

    public void Dispose()
    {
        _serviceScope.Dispose();
        GC.SuppressFinalize(this);
    }
}