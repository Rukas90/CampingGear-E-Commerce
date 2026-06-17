using Microsoft.Extensions.Logging;

namespace TrailStore.Shared.Seeding;

public class SeedOptions
{
    public bool Reseed { get; init; }
    public ILogger? Logger { get; init; }
}