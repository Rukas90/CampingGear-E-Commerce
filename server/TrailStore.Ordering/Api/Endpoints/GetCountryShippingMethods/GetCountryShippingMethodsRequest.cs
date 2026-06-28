using FastEndpoints;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace TrailStore.Ordering.Api.Endpoints.GetCountryShippingMethods;

public class GetCountryShippingMethodsRequest
{
    [QueryParam]
    public string CountryCode { get; init; } = string.Empty;
}