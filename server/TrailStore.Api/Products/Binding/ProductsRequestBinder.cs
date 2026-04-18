using FastEndpoints;
using TrailStore.Api.Products.Dto;

namespace TrailStore.Api.Products.Binding;

public class ProductsRequestBinder : RequestBinder<ProductsRequest>
{
    public override async ValueTask<ProductsRequest> BindAsync(BinderContext ctx, CancellationToken ct)
    {
        var base_request = await base.BindAsync(ctx, ct);

        var filter = ctx.HttpContext.Request.Query
            .Where(q => q.Key.StartsWith("filter[") && q.Key.EndsWith(']'))
            .ToDictionary(
                q => q.Key[7..^1],
                q => q.Value.ToString());

        return base_request with
        {
            Filter = filter.Count > 0 ? filter : null
        };
    }
}