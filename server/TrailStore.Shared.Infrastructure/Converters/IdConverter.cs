using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Infrastructure.Converters;

public class IdConverter<TType>()
    : ValueConverter<Id<TType>, Guid>(id => id.Value, guid => new Id<TType>(guid));