using FastEndpoints;
using TrailStore.Catalog.Application.Queries.GetFilters;
using TrailStore.Catalog.Domain.Filters;
using TrailStore.Catalog.Domain.Options;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Api.Endpoints.GetFilters;

public class GetFiltersEndpoint(GetFiltersQueryHandler query) 
    : Endpoint<GetFiltersRequest, CatalogFilters>
{
    public override void Configure()
    {
        Get("/api/v1/filters");
        AllowAnonymous();
        RequestBinder(new FiltersRequestBinder());
    }

    public override async Task HandleAsync(GetFiltersRequest req, CancellationToken ct)
    {
        var result = await query.Handle(new GetFiltersQuery(
            req.QueryBrand,
            req.QueryCategory,
            req.Brand ?? [],
            req.Category ?? [],
            req.PriceGte ?? 0m,
            req.PriceLte ?? decimal.MaxValue,
            req.Availability ?? Availability.All,
            req.Option?
                .Select(kv => new OptionSelection(Slug.Create(kv.Key), Slug.Create(kv.Value)))
                .ToArray() ?? []), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        await Send.OkAsync(result.Value, ct);
    }
}