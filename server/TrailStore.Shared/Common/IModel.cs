namespace TrailStore.Shared.Common;

public interface IModel<TType> : IIdentifier<TType>
{
    Id<TType> Id { get; }
}