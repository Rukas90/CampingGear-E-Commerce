namespace TrailStore.Shared.Domain.Common;

public class Slug
{
    public string Value { get; }

    protected Slug(string value) => Value = value;

    public static Slug Create(string value)
    {
        return new Slug(value.Trim().ToLowerInvariant());
    }

    public override bool Equals(object? obj)
        => obj is Slug other && Value == other.Value;

    public override int GetHashCode()
        => Value.GetHashCode();
    
    public static implicit operator string(Slug slug) => slug.Value;

    public override string ToString() => Value;
}