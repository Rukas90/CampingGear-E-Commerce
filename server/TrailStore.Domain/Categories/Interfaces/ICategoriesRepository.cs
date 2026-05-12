using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Categories.Interfaces;

public interface ICategoriesRepository
{
    Task<List<Category>> ListAllCategoriesAsync(CancellationToken ct);

    Task<List<CategoryGroup>> ListAllCategoryGroupsAsync(CancellationToken ct);
}