using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Categories.Interfaces;

public interface ICategoryGroupsRepository
{
    Task<List<CategoryGroup>> ListAsync(CancellationToken ct);
}