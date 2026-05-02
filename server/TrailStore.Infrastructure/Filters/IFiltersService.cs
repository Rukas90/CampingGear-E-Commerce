using TrailStore.Domain.Filters;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Filters;

public interface IFiltersService
{
    Task<CatalogFilters> GetFilters(Specification<Sku> specification);
}