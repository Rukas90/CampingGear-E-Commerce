using System.Text.Json.Serialization;

namespace TrailStore.Shared.Common;

public readonly record struct Id<TType>(Guid Value)
{
    [JsonIgnore]
    public bool IsEmpty => Value == Guid.Empty;
    
    public static Id<TType> Empty => new(Guid.Empty);
    
    public static implicit operator Guid(Id<TType> id) => id.Value;
    
    public static Id<TType> From(string guid) => new(Guid.Parse(guid));
    
    public static Id<TType> From(Guid guid) => new(guid);
    
    public static Id<TType> New() => new(Guid.NewGuid());
    
    public static IdBuilder<TType> With<T>() => new IdBuilder<TType>().With<T>();
    
    public static IdBuilder<TType> Parts(params string[] parts) => new IdBuilder<TType>().Parts(parts);
    
    public static IdBuilder<TType> Part(string value) => new IdBuilder<TType>().Part(value);
    
    public static IdBuilder<TType> Part<T>(Id<T> other) => new IdBuilder<TType>().Part(other);

    public static bool TryParse(string? input, out Id<TType> output)
    {
        var success = Guid.TryParse(input, out var result);
        
        output = success ? From(result) : default;
        
        return success;
    }
    
    public override string ToString() 
        => Value.ToString();
}