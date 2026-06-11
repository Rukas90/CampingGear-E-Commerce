namespace TrailStore.Domain.Shared.Interfaces;

public interface IEntityExpirable
{
    DateTime ExpiresAt { get; set; }
    
    bool IsExpired => ExpiresAt <= DateTime.UtcNow;

    void Extend(TimeSpan duration)
    {
        ExpiresAt = DateTime.UtcNow.Add(duration);
    }
}