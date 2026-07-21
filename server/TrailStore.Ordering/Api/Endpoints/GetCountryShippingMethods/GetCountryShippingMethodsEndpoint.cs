using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Ordering.Application.Queries.GetShippingMethods;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.GetCountryShippingMethods;

public sealed class GetCountryShippingMethodsEndpoint(GetShippingMethodsQueryHandler query)
    : Endpoint<GetCountryShippingMethodsRequest, IEnumerable<ShippingMethodResponse>>
{
    public override void Configure()
    {
        Get("/api/v1/shipping/methods");
        AllowAnonymous();
        Options(x => x.CacheOutput(policy => policy
            .Expire(TimeSpan.FromDays(31))
            .Tag("shipping-methods")
            .SetVaryByQuery("*")));
    }
    
    public override async Task HandleAsync(GetCountryShippingMethodsRequest req, CancellationToken ct)
    {
        var result = await query.Handle(new GetShippingMethodsQuery(req.CountryCode), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var methods = result.Value;
        
        await Send.OkAsync(methods.ToResponses(), ct);
    }
}