using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Contracts.Skus;

public interface ISkuService
{
    Task<List<SkuSnapshot>> GetSkusFromIds(Id<SkuRef>[] ids, CancellationToken ct);
}