using StackExchange.Redis;
using TrailStore.Shared.DependencyInjection;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Caching;
using IDatabase = StackExchange.Redis.IDatabase;

namespace TrailStore.Shared.Infrastructure.Caching;

[AppService<ICacheService>]
public class RedisCacheService(IConnectionMultiplexer redis) : ICacheService
{
    private readonly IDatabase database = redis.GetDatabase();
    
    public async Task<string?> GetAsync(string key) 
        => await database.StringGetAsync(key);

    public Task<bool> SetAsync(
        string key, string value, TimeSpan? expireTime = null, CacheCondition when = default)
        => SetAsync(key, value, DateTime.UtcNow.Add(expireTime ?? TimeSpan.Zero), when);
    
    public async Task<bool> SetAsync(
        string key, string value, DateTime? expireAt = null, CacheCondition when = default)
        => await database.StringSetAsync(key, value, expireAt ?? DateTime.UtcNow, GetCondition(when));

    public async Task RemoveAsync(string key) => await database.KeyDeleteAsync(key);
    
    private static ValueCondition GetCondition(CacheCondition when) 
        => when switch
    {
        CacheCondition.OnlyIfNotExists => When.NotExists,
        CacheCondition.OnlyIfExists => When.Exists,
        _ => When.Always
    };
}