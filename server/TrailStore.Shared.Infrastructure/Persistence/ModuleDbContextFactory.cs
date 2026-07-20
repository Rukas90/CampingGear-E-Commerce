using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TrailStore.Shared.Infrastructure.Constants;
using TrailStore.Shared.Infrastructure.Extensions;

namespace TrailStore.Shared.Infrastructure.Persistence;

public abstract class ModuleDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
    where TContext : DbContext
{
    protected abstract string Schema { get; }
    protected abstract TContext CreateContext(DbContextOptions<TContext> options);

    public TContext CreateDbContext(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<TContext>();

        optionsBuilder.UsePostgres(
            configuration.GetConnectionString("DefaultConnection"),
            npgsql => npgsql.MigrationsHistoryTable(DatabaseConstants.MigrationsHistoryTable, Schema));

        return CreateContext(optionsBuilder.Options);
    }
}