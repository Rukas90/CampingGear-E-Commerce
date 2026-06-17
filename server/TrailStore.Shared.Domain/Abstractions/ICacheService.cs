using TrailStore.Shared.Domain.Caching;

namespace TrailStore.Shared.Domain.Abstractions;

public interface ICacheService
{
    Task<string?> GetAsync(string key);
    
    Task<bool> SetAsync(
        string key, string value, TimeSpan? expireTime = null, CacheCondition when = CacheCondition.Always);
    
    Task<bool> SetAsync(
        string key, string value, DateTime? expireAt = null, CacheCondition when = CacheCondition.Always);

    Task RemoveAsync(string key);
}