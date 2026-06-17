using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Domain.Abstractions;

public interface IModel<TType> : IIdentifier<TType>
{
    Id<TType> Id { get; }
}