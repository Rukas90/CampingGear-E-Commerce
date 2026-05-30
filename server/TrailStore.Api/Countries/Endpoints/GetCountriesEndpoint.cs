using FastEndpoints;
using TrailStore.Api.Countries.Dto;
using TrailStore.Api.Countries.Mapping;
using TrailStore.Domain.Countries.Data;

namespace TrailStore.Api.Countries.Endpoints;

public class CountriesEndpoint 
    : EndpointWithoutRequest<IEnumerable<CountryDto>>
{
    public override void Configure()
    {
        Get("/api/v1/countries");
        AllowAnonymous();
        Options(x => x.CacheOutput(p => p.Expire(TimeSpan.FromDays(1))));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(CountryRegistry.All.ToDto(), ct);
    }
}