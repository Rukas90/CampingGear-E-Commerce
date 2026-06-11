namespace TrailStore.Domain.Shared.Interfaces;

public interface IEntityExpirable
{
    DateTime? ExpiresAt { get; set; }
    
    bool IsExpired => ExpiresAt.HasValue && ExpiresAt.Value <= DateTime.UtcNow;
}