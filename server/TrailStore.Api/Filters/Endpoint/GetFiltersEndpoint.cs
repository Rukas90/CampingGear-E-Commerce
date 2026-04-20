using FastEndpoints;
using TrailStore.Api.Filters.Dto;
using TrailStore.Api.Filters.Extensions;
using TrailStore.Domain.Filters;
using TrailStore.Infrastructure.Filters;

namespace TrailStore.Api.Filters.Endpoint;

public class GetFiltersEndpoint(IFiltersService filtersService) : Endpoint<FiltersRequest, CatalogFilters>
{
    public override void Configure()
    {
        Get("/api/v1/filters");
        AllowAnonymous();
    }

    public override async Task<CatalogFilters> ExecuteAsync(FiltersRequest req, CancellationToken ct)
    {
        return await filtersService.GetFilters(req.ToSpecification());
    }
}