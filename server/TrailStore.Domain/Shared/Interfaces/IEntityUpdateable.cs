namespace TrailStore.Domain.Shared.Interfaces;

public interface IEntityUpdateable : ITrackedEntity
{
    DateTime UpdatedAt { get; set; }

    void OnUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}