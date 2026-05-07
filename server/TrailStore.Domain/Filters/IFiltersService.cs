namespace TrailStore.Domain.Filters;

public interface IFiltersService
{
    Task<CatalogFilters> GetFilters(FiltersQuery query);
}