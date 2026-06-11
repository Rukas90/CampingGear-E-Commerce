namespace TrailStore.Domain.Shared.Interfaces;

public interface IEntityCreatable : ITrackedEntity
{
    DateTime CreatedAt { get; set; }

    void OnCreated()
    {
        CreatedAt = DateTime.UtcNow;
    }
}