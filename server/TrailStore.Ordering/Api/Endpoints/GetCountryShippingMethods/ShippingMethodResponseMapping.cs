using TrailStore.Ordering.Application.Results;

namespace TrailStore.Ordering.Api.Endpoints.GetCountryShippingMethods;

public static class ShippingMethodResponseMapping
{
    public static IEnumerable<ShippingMethodResponse> ToResponses(this IEnumerable<ShippingMethodResult> methods)
        => methods.Select(ToResponse);
    
    public static ShippingMethodResponse ToResponse(this ShippingMethodResult method)
        => new()
        {
            Id = method.Id,
            Name = method.Name,
            Description = method.Description,
            FlatFee = method.FlatFee
        };
}