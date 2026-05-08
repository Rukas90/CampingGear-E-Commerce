using System.Text.Json;
using System.Text.Json.Serialization;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Common.Converters;

public class IdJsonConverter<T> : JsonConverter<Id<T>>
{
    public override Id<T> Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options) =>
        Id<T>.From(reader.GetString()!);

    public override void Write(Utf8JsonWriter writer, Id<T> value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value.ToString());
}