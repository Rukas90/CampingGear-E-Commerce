namespace TrailStore.Shared.Common;

public interface IModel<TType>
{
    Id<TType> Id { get; }
}