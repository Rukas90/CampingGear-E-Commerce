using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using TrailStore.Shared.Domain.Caching;
using TrailStore.Shared.Infrastructure.DI;
using IDatabase = StackExchange.Redis.IDatabase;

namespace TrailStore.Shared.Infrastructure.Caching;

[AppService<IRedisCacheService>(ServiceLifetime.Singleton)]
public class RedisCacheService(IConnectionMultiplexer redis) : IRedisCacheService
{
    private readonly IDatabase database = redis.GetDatabase();

    public Task<bool> ExistsAsync(string key)
        => database.KeyExistsAsync(key);

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