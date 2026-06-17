using LinqKit;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace TrailStore.Shared.Infrastructure.Persistence;

public static class DbContextOptionsExtensions
{
    public static void UsePostgres(
        this DbContextOptionsBuilder builder, string? connectionString, Action<NpgsqlDbContextOptionsBuilder>? npgsql = null)
        => builder.UseNpgsql(connectionString, npgsql).WithExpressionExpanding();
}