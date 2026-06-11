using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.Shipping.Interfaces;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Shipping;

[AppService<IShippingMethodRepository>]
public sealed class ShippingMethodRepository(AppDbContext context) : IShippingMethodRepository
{
    public async Task<List<ShippingMethod>> ListAvailableAsync(string countryCode, CancellationToken ct)
    {
        var methods = await context.ShippingMethods
            .Include(m => m.Zone)
            .Where(m => m.Zone.CountryCodes.Any(code =>
                EF.Functions.ILike(code, countryCode)))
            .ToListAsync(ct);

        if (methods.Count != 0)
        {
            return methods;
        }

        return await context.ShippingMethods
            .Include(m => m.Zone)
            .Where(m => m.Zone.Name == "Worldwide")
            .ToListAsync(ct);
    }

    public Task<ShippingMethod?> FindByIdAsync(Id<ShippingMethod> id, CancellationToken ct)
    {
        return context.ShippingMethods.FirstOrDefaultAsync(method => method.Id == id, ct);
    }
}