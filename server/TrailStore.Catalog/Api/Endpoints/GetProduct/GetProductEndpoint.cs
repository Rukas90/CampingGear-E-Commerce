using FastEndpoints;
using TrailStore.Catalog.Api.Endpoints.GetProduct.Responses;
using TrailStore.Catalog.Application.Queries.GetProduct;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Catalog.Api.Endpoints.GetProduct;

public class GetProductEndpoint(GetProductQueryHandler query)
    : Endpoint<GetProductRequest, ProductDetailsResponse>
{
    public override void Configure()
    {
        Get("/api/v1/products/{slug}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetProductRequest req, CancellationToken ct)
    {
        var result = await query.Handle(new GetProductQuery(req.Slug), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        await Send.OkAsync(result.Value.ToResponse(), ct);
    }
}