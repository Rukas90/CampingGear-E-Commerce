namespace TrailStore.Seed.Common;

public interface ISeedRunner
{
    string Identifier { get; }
    
    Task RunAsync(SeedOptions options);

    Task ClearAsync(ILogger? logger = null);
}