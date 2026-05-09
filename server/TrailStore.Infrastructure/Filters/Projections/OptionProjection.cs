using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Filters.Projections;

internal sealed record OptionProjection(string Name, string Slug, int SortOrder, PreviewType? PreviewType, string? PreviewValue, OptionGroupProjection Group);