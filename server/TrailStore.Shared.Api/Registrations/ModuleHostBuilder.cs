using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TrailStore.Shared.Api.Registrations;

public sealed class ModuleHostBuilder(IServiceCollection services, IConfiguration configuration)
{
    private readonly List<Assembly> _apiAssemblies = [];
    
    public IServiceCollection Services { get; } = services;
    public IConfiguration Configuration { get; } = configuration;

    public void AddApiAssembly(Assembly assembly)
    {
        _apiAssemblies.Add(assembly);
    }

    public Assembly[] ApiAssemblies => _apiAssemblies.ToArray();

}