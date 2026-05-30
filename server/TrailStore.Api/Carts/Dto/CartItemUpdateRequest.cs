using System.Text.Json.Serialization;
using TrailStore.Api.Common.Converters;

namespace TrailStore.Api.Carts.Dto;

public class CartItemUpdateRequest
{
    [JsonConverter(typeof(CodeNormalizeConverter))]
    public required string Code { get; init; }
    
    public int Quantity { get; init; }
}