using FastEndpoints;
using TrailStore.Api.Common.Bindings;
using TrailStore.Api.Filters.Dto;

namespace TrailStore.Api.Filters.Bindings;

public class FiltersRequestBinder : RequestBinder<FiltersRequest>
{
    public override async ValueTask<FiltersRequest> BindAsync(BinderContext ctx, CancellationToken ct)
    {
        var base_request = await base.BindAsync(ctx, ct);
        return base_request with { Option = OptionBinderHelper.ParseOptions(ctx.HttpContext) };
    }
}