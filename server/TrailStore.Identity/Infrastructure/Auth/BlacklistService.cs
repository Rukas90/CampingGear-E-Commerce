using TrailStore.Identity.Domain.Auth;
using TrailStore.Shared.Domain.Caching;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Infrastructure.Auth;

[AppService<IBlacklistService>]
public class BlacklistService(IRedisCacheService cacheService) : IBlacklistService
{
    public Task<bool> IsSessionBlacklistedAsync(string jti)
        => cacheService.ExistsAsync(CreateBlacklistKey(jti));

    public Task BlacklistSessionAsync(string jti, DateTime expireTime)
        => cacheService.SetAsync(CreateBlacklistKey(jti), "1", expireTime, CacheCondition.OnlyIfNotExists);
    
    private static string CreateBlacklistKey(string jti)
        => $"revoked-jti:{jti}";
}