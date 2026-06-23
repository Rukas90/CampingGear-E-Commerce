namespace TrailStore.Catalog.Domain.Skus;

public sealed record SkuCode
{
    public string Value { get; }

    private SkuCode(string value) => Value = value;

    public static SkuCode Create(string value)
    {
        return new SkuCode(value.Trim().ToUpperInvariant());
    }

    public static implicit operator string(SkuCode code) => code.Value;

    public override string ToString() => Value;
}