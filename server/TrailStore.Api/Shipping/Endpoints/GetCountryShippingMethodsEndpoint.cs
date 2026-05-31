using FastEndpoints;
using TrailStore.Api.Shipping.Dto;
using TrailStore.Api.Shipping.Mapping;
using TrailStore.Domain.Shipping.Interfaces;

namespace TrailStore.Api.Shipping.Endpoints;

public class GetCountryShippingMethodsEndpoint(IShippingMethodRepository shippingMethodRepository)
    : Endpoint<GetCountryShippingMethodsRequest, IEnumerable<ShippingMethodDto>>
{
    public override void Configure()
    {
        Get("/api/v1/shipping/methods");
        AllowAnonymous();
        Options(x => x.CacheOutput(p => p.Expire(TimeSpan.FromDays(1))));
    }

    public override async Task HandleAsync(GetCountryShippingMethodsRequest req, CancellationToken ct)
    {
        var availableMethods = await shippingMethodRepository.ListAvailableAsync(req.CountryCode, ct);
        await Send.OkAsync(availableMethods.ToDto(), ct);
    }
}