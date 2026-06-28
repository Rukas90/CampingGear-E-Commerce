using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Ordering.Domain.Countries.Data;

namespace TrailStore.Ordering.Api.Endpoints.GetCountries;

public sealed class GetCountriesEndpoint
    : EndpointWithoutRequest<IEnumerable<CountryResponse>>
{
    public override void Configure()
    {
        Get("/api/v1/countries");
        AllowAnonymous();
        Options(x => x.CacheOutput(p => p.Expire(TimeSpan.FromDays(1))));
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(CountryRegistry.All.ToResponses(), ct);
    }
}