using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Infrastructure.Skus;

[AppService<ISkuService>]
internal sealed class SkuService(ISkuRepository repository) : ISkuService
{
    public async Task<List<SkuSnapshot>> GetSkusFromIds(Id<SkuRef>[] ids, CancellationToken ct)
    {
        var specification = ids.Aggregate(Specification<Sku>.None,
            (spec, id) => spec.Or(SkuSpecifications.Id(Id<Sku>.From(id.Value))));

        return await repository.ListAllAsync(specification, sku => sku.ToSnapshot(), ct);
    }
}