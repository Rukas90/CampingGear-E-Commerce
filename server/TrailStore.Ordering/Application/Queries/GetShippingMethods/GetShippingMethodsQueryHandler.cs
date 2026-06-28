using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Application.Results;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Queries.GetShippingMethods;

[AppService<GetShippingMethodsQueryHandler>]
public sealed class GetShippingMethodsQueryHandler(IShippingMethodRepository shippingMethodRepository)
    : IQueryHandler<GetShippingMethodsQuery, ShippingMethodResult[]>
{
    public async Task<Result<ShippingMethodResult[]>> Handle(GetShippingMethodsQuery query, CancellationToken ct)
    {
        var methods = await shippingMethodRepository.ListAvailableAsync(query.CountryCode, ct);

        return methods.Select(method => new ShippingMethodResult
        {
            Id = method.Id,
            Name = method.Name,
            Description = method.Description,
            FlatFee = method.FlatFee
        }).ToArray();
    }
}