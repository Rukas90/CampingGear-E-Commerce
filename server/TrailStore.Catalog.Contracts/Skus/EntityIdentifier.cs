using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Contracts.Skus;

public sealed record EntityIdentifier(string Name, Slug Slug);