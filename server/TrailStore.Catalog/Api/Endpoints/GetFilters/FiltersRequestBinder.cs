using FastEndpoints;
using TrailStore.Catalog.Api.Bindings;

namespace TrailStore.Catalog.Api.Endpoints.GetFilters;

public class FiltersRequestBinder : RequestBinder<GetFiltersRequest>
{
    public override async ValueTask<GetFiltersRequest> BindAsync(BinderContext ctx, CancellationToken ct)
    {
        var base_request = await base.BindAsync(ctx, ct);
        return base_request with { Option = OptionBinderHelper.ParseOptions(ctx.HttpContext) };
    }
}