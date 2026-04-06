namespace TrailStore.Shared.Common;

public readonly record struct Id<TType>(Guid Value)
{
    public static Id<TType> From(string guid) => new(Guid.Parse(guid));
    
    public static Id<TType> From(Guid guid) => new(guid);
    
    public static Id<TType> New() => new(Guid.NewGuid());
    
    public static IdBuilder<TType> With<T>() => new IdBuilder<TType>().With<T>();
    
    public static IdBuilder<TType> Parts(params string[] parts) => new IdBuilder<TType>().Parts(parts);
    
    public static IdBuilder<TType> Part(string value) => new IdBuilder<TType>().Part(value);
    
    public static IdBuilder<TType> Part<T>(Id<T> other) => new IdBuilder<TType>().Part(other);
    
    public static Id<TType> Empty => new(Guid.Empty);
    
    public bool IsEmpty => Value == Guid.Empty;
}