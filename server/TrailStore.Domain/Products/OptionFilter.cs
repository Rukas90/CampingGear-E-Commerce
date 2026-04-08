namespace TrailStore.Domain.Products;

public readonly record struct OptionFilter(string GroupSlug, string ValueSlug)
{
    public bool IsValid => !string.IsNullOrEmpty(GroupSlug) 
                           && !string.IsNullOrEmpty(ValueSlug);
}