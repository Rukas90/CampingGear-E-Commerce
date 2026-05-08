using FastEndpoints;
using TrailStore.Api.Common;
using TrailStore.Api.Common.Bindings;
using TrailStore.Api.Products.Dto;

namespace TrailStore.Api.Products.Bindings;

public class ProductsRequestBinder : RequestBinder<ProductsRequest>
{
    public override async ValueTask<ProductsRequest> BindAsync(BinderContext ctx, CancellationToken ct)
    {
        var base_request = await base.BindAsync(ctx, ct);
        return base_request with { Option = OptionBinderHelper.ParseOptions(ctx.HttpContext) };
    }
}