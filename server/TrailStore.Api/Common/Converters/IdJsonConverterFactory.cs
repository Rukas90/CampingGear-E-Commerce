using System.Text.Json;
using System.Text.Json.Serialization;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Common.Converters;

public class IdJsonConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Id<>);

    public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options)
    {
        var innerType = type.GetGenericArguments()[0];
        var converterType = typeof(IdJsonConverter<>).MakeGenericType(innerType);
        
        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }
}