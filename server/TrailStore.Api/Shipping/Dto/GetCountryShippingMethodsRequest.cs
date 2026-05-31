using FastEndpoints;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace TrailStore.Api.Shipping.Dto;

public class GetCountryShippingMethodsRequest
{
    [QueryParam]
    public string CountryCode { get; init; } = string.Empty;
}