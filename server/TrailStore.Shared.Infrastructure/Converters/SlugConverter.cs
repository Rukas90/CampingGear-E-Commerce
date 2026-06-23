using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Infrastructure.Converters;

public class SlugConverter() : ValueConverter<Slug, string>(slug => slug.ToString(),
    value => Slug.Create(value));