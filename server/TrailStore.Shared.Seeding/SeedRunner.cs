using System.Reflection;
using Microsoft.Extensions.Logging;

namespace TrailStore.Shared.Seeding;

public abstract class SeedRunner : ISeedRunner
{
    public abstract string Identifier { get; }
    
    public async Task RunAsync(SeedOptions options)
    {
        try
        {
            var logger = options.Logger;

            logger?.LogInformation("[{Identifier}] Seeding...", Identifier);

            if (options.Reseed)
            {
                Clear();

                logger?.LogInformation("[{Identifier}] Cleared seeded data.", Identifier);

            }
            else if (await IsSeededAsync())
            {
                logger?.LogInformation("[{Identifier}] Already seeded. Use --reseed to force.", Identifier);

                return;
            }

            Seed();

            logger?.LogInformation("[{Identifier}] Seeded.", Identifier);
        }
        finally
        {
            await Commit();
        }
    }

    public async Task ClearAsync(ILogger? logger = null)
    {
        logger?.LogInformation("[{Identifier}] Seeding...", Identifier);
        
        Clear();

        logger?.LogInformation("[{Identifier}] Cleared seeded data.", Identifier);

        await Commit();
    }

    protected abstract void Clear();
    
    protected abstract void Seed();
    
    protected abstract Task Commit();
    
    protected abstract Task<bool> IsSeededAsync();

    protected static IEnumerable<T> Discover<T>(Assembly assembly) where T : class
    {
        var collectionType = typeof(IEnumerable<T>);
        return assembly
            .GetTypes()
            .SelectMany(t => t.GetFields(BindingFlags.Public | BindingFlags.Static))
            .Where(f => f.GetCustomAttribute<SeededEntityAttribute>() is not null)
            .Where(f => f.FieldType == typeof(T) || collectionType.IsAssignableFrom(f.FieldType))
            .SelectMany(f =>
            {
                var value = f.GetValue(null)!;
                return value as IEnumerable<T> ?? [(T)value];
            });
    }
}