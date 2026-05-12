using TrailStore.Domain.Filters.Models;

namespace TrailStore.Domain.Filters.Interfaces;

public interface IFiltersService
{
    Task<CatalogFilters> GetFilters(FiltersQuery query, CancellationToken ct);
}