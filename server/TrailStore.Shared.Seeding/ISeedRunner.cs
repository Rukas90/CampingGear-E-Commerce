using Microsoft.Extensions.Logging;

namespace TrailStore.Shared.Seeding;

public interface ISeedRunner
{
    string Identifier { get; }
    
    Task RunAsync(SeedOptions options);

    Task ClearAsync(ILogger? logger = null);
}