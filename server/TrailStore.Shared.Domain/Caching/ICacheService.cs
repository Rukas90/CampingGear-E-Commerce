namespace TrailStore.Shared.Domain.Caching;

public interface ICacheService
{
    Task<bool> ExistsAsync(string key);
    
    Task<string?> GetAsync(string key);
    
    Task<bool> SetAsync(
        string key, string value, TimeSpan? expireTime = null, CacheCondition when = CacheCondition.Always);
    
    Task<bool> SetAsync(
        string key, string value, DateTime? expireAt = null, CacheCondition when = CacheCondition.Always);

    Task RemoveAsync(string key);
}