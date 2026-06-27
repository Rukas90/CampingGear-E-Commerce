using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Infrastructure.Skus;

[AppService<ISkuService>]
internal sealed class SkuService(ISkuRepository repository) : ISkuService
{
    public Task<List<SkuSnapshot>> GetSkusFromIds(Id<SkuRef>[] ids, CancellationToken ct)
        => repository.ListAllAsync(BuildIdsSpecification(ids), sku => sku.ToSnapshot(), ct);
    
    private static Specification<Sku> BuildIdsSpecification(Id<SkuRef>[] ids)
        => ids.Aggregate(Specification<Sku>.None, 
            (spec, id) => spec.Or(SkuSpecifications.Id(Id<Sku>.From(id.Value))));
}