namespace TrailStore.Catalog.Domain.Categories;

public interface ICategoryGroupsRepository
{
    Task<List<CategoryGroup>> ListAsync(CancellationToken ct);
}