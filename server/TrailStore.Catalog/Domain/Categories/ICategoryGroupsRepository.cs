using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Catalog.Domain.Categories;

public interface ICategoryGroupsRepository : IReadRepository<CategoryGroup>
{
    Task<List<CategoryGroup>> ListAsync(CancellationToken ct);
}