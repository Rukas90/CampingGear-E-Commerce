namespace TrailStore.Catalog.Domain.Options;

public readonly record struct OptionSelection(string GroupSlug, string ValueSlug)
{
    public bool IsValid => !string.IsNullOrEmpty(GroupSlug)
                           && !string.IsNullOrEmpty(ValueSlug);
}