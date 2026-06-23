using FastEndpoints;
using TrailStore.Catalog.Application.Queries.GetProducts;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Catalog.Api.Endpoints.GetProducts;

public class GetProductsEndpoint(GetProductsQueryHandler query) 
    : Endpoint<GetProductsRequest, ProductSummaryResponse[]>
{
    public override void Configure()
    {
        Get("/api/v1/products");
        AllowAnonymous();
        RequestBinder(new ProductsRequestBinder());
    }

    public override async Task HandleAsync(GetProductsRequest req, CancellationToken ct)
    {
        var result = await query.Handle(new GetProductsQuery(
            req.SortBy, 
            req.Brand, 
            req.Category,
            req.Pagination, 
            req.Page, 
            req.PageSize, 
            req.PriceGte, 
            req.PriceLte, 
            req.Availability,
            req.Option, 
            req.SkuCode), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var products = result.Value;

        await Send.OkAsync(products.ToResponses(), ct);
    }
}