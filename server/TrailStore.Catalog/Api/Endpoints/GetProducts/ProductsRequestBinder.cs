using FastEndpoints;
using TrailStore.Catalog.Api.Bindings;

namespace TrailStore.Catalog.Api.Endpoints.GetProducts;

public class ProductsRequestBinder : RequestBinder<GetProductsRequest>
{
    public override async ValueTask<GetProductsRequest> BindAsync(BinderContext ctx, CancellationToken ct)
    {
        var base_request = await base.BindAsync(ctx, ct);
        return base_request with { Option = OptionBinderHelper.ParseOptions(ctx.HttpContext) };
    }
}