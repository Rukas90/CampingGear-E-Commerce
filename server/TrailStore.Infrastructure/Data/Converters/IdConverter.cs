using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Data.Converters;

public class IdConverter<TType>()
    : ValueConverter<Id<TType>, Guid>(id => id.Value, guid => new Id<TType>(guid));