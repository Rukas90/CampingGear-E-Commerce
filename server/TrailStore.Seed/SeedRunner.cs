using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;

namespace TrailStore.Seed;

public class SeedOptions
{
    public bool Reseed { get; init; }
    public ILogger? Logger { get; init; }
}

public static class SeedRunner
{
    public static async Task RunAsync(AppDbContext context, SeedOptions? options = null)
    {
        var logger = options?.Logger;

        if (options?.Reseed ?? false)
        {
            await ClearAsync(context);
            logger?.LogInformation("Cleared seeding data.");
        }
        else if (await context.Brands.AnyAsync())
        {
            logger?.LogWarning("Already seeded. Use --reseed to force.");
            return;
        }

        var assembly = SeedAssembly.Reference;

        await context.Customers.AddRangeAsync(Discover<Customer>(assembly));
        await context.Brands.AddRangeAsync(Discover<Brand>(assembly));
        await context.CategoryGroups.AddRangeAsync(Discover<CategoryGroup>(assembly));
        await context.Categories.AddRangeAsync(Discover<Category>(assembly));
        await context.OptionGroups.AddRangeAsync(Discover<OptionGroup>(assembly));
        await context.Options.AddRangeAsync(Discover<Option>(assembly));
        await context.Products.AddRangeAsync(Discover<Product>(assembly));
        await context.ProductImages.AddRangeAsync(Discover<ProductImage>(assembly));
        await context.Skus.AddRangeAsync(Discover<Sku>(assembly));
        await context.Orders.AddRangeAsync(Discover<Order>(assembly));
        await context.Reviews.AddRangeAsync(Discover<Review>(assembly));

        await context.SaveChangesAsync();
        logger?.LogInformation("Seeding done.");
    }

    public static async Task ClearAsync(AppDbContext context)
    {
        context.Reviews.RemoveRange(context.Reviews);
        context.Orders.RemoveRange(context.Orders.Where(order =>
            context.Customers.Any(customer =>
                customer.PasswordHash == SeedDefaults.NO_LOGIN_HASH && customer.Email == order.EmailAddress)));
        context.Skus.RemoveRange(context.Skus);
        context.ProductImages.RemoveRange(context.ProductImages);
        context.Products.RemoveRange(context.Products);
        context.Options.RemoveRange(context.Options);
        context.OptionGroups.RemoveRange(context.OptionGroups);
        context.Categories.RemoveRange(context.Categories);
        context.CategoryGroups.RemoveRange(context.CategoryGroups);
        context.Brands.RemoveRange(context.Brands);
        context.Customers.RemoveRange(
            context.Customers.Where(c => c.PasswordHash == SeedDefaults.NO_LOGIN_HASH));

        await context.SaveChangesAsync();
    }

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