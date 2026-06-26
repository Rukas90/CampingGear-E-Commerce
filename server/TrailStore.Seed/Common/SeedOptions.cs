namespace TrailStore.Seed.Common;

public class SeedOptions
{
    public bool Reseed { get; init; }
    public ILogger? Logger { get; init; }
}