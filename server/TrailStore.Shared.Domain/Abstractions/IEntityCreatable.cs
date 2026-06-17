namespace TrailStore.Shared.Domain.Abstractions;

public interface IEntityCreatable : ITrackedEntity
{
    DateTime CreatedAt { get; set; }

    void OnCreated()
    {
        CreatedAt = DateTime.UtcNow;
    }
}