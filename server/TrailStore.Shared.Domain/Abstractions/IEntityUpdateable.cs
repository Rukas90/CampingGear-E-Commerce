namespace TrailStore.Shared.Domain.Abstractions;

public interface IEntityUpdateable : ITrackedEntity
{
    DateTime UpdatedAt { get; set; }

    void OnUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}