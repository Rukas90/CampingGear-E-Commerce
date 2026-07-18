using System.Reflection;

namespace TrailStore.Seed.Common;

public abstract class SeedRunner : ISeedRunner
{
    public abstract string Identifier { get; }
    
    protected static Assembly ExecutingAssembly => typeof(SeedRunner).Assembly;
    
    public async Task RunAsync(SeedOptions options)
    {
        var logger = options.Logger;
        
        logger?.LogInformation("[{Identifier}] Seeding...", Identifier);

        if (options.Reseed)
        {
            await DeleteAsync();

            logger?.LogInformation("[{Identifier}] Cleared seeded data.", Identifier);

        }
        else if (await IsSeededAsync())
        {
            logger?.LogInformation("[{Identifier}] Already seeded.", Identifier);

            return;
        }

        Seed();
            
        await Commit();

        logger?.LogInformation("[{Identifier}] Seeded.", Identifier);
    }

    public async Task ClearAsync(ILogger? logger = null)
    {
        logger?.LogInformation("[{Identifier}] Seeding...", Identifier);

        await DeleteAsync();

        logger?.LogInformation("[{Identifier}] Cleared seeded data.", Identifier);
    }

    protected abstract Task DeleteAsync();
    
    protected abstract void Seed();
    
    protected abstract Task Commit();
    
    protected abstract Task<bool> IsSeededAsync();

    public static IEnumerable<T> Discover<T>(Assembly assembly) where T : class
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