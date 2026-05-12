using FastEndpoints;
using TrailStore.Api.Filters.Bindings;
using TrailStore.Api.Filters.Dto;
using TrailStore.Api.Filters.Mapping;
using TrailStore.Domain.Filters.Interfaces;
using TrailStore.Domain.Filters.Models;

namespace TrailStore.Api.Filters.Endpoints;

public class GetFiltersEndpoint(IFiltersService filtersService) : Endpoint<FiltersRequest, CatalogFilters>
{
    public override void Configure()
    {
        Get("/api/v1/filters");
        AllowAnonymous();
        RequestBinder(new FiltersRequestBinder());
    }

    public override async Task<CatalogFilters> ExecuteAsync(FiltersRequest req, CancellationToken ct)
    {
        return await filtersService.GetFilters(req.ToQuery(), ct);
    }
}