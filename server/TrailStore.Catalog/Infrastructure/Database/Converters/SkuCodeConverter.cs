using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrailStore.Catalog.Domain.Skus;

namespace TrailStore.Catalog.Infrastructure.Database.Converters;

public class SkuCodeConverter() : ValueConverter<SkuCode, string>(code => code.ToString(),
    value => SkuCode.Create(value));