using Microsoft.EntityFrameworkCore;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Ordering.Infrastructure.Database;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Ordering.Infrastructure.Shipping;

[AppService<IShippingMethodRepository>]
public sealed class ShippingMethodRepository(OrderingDbContext _context) 
    : AggregateRepository<ShippingMethod, OrderingDbContext>(_context), IShippingMethodRepository
{
    public async Task<List<ShippingMethod>> ListAvailableAsync(string countryCode, CancellationToken ct)
    {
        var methods = await ReadQuery
            .Where(m => m.Zone.CountryCodes.Any(code =>
                EF.Functions.ILike(code, countryCode)))
            .ToListAsync(ct);

        if (methods.Count != 0)
        {
            return methods;
        }

        return await ReadQuery
            .Where(m => m.Zone.Name == "Worldwide")
            .ToListAsync(ct);
    }

    protected override IQueryable<ShippingMethod> BuildAggregateQuery(DbSet<ShippingMethod> set)
        => set.Include(method => method.Zone);
}