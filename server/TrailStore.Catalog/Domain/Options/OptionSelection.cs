using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Options;

public readonly record struct OptionSelection(Slug GroupSlug, Slug ValueSlug)
{
    public bool IsValid => !string.IsNullOrEmpty(GroupSlug)
                           && !string.IsNullOrEmpty(ValueSlug);
}