using System.Text.Json.Serialization;
using TrailStore.Api.Common.Converters;

namespace TrailStore.Api.Carts.Dto;

public class DeleteItemFromCartRequest
{
    [JsonConverter(typeof(CodeNormalizeConverter))]
    public required string Code { get; init; } 
}