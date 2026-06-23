using TrailStore.Catalog.Seed;
using TrailStore.Identity.Seed;
using TrailStore.Shared.Seeding;

var builder = Host.CreateApplicationBuilder(args);

builder
    .AddIdentitySeeding()
    .AddCatalogSeeding();

var moduleArg = args.FirstOrDefault(a => a.StartsWith("--module="))?.Split('=')[1];
var clearOnly = args.Contains("clear-only");
var reseed = args.Contains("--reseed") || clearOnly;

var app = builder.Build();
var scope = app.Services.CreateScope();

var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

var allSeeders = scope.ServiceProvider.GetServices<ISeedRunner>();

var seeders = moduleArg is null
    ? allSeeders.ToArray()
    : allSeeders.Where(runner => runner.Identifier.Equals(moduleArg, StringComparison.OrdinalIgnoreCase)).ToArray();

if (moduleArg is not null && seeders.Length == 0)
{
    Console.WriteLine($"No seed runner found matching module '{moduleArg}'.");
    
    return;
}

foreach (var seeder in seeders)
{
    if (clearOnly)
    {
        await seeder.ClearAsync();
    }
    else
    {
        await seeder.RunAsync(new SeedOptions { Reseed = reseed, Logger = logger });
    }
}