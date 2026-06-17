namespace TrailStore.Shared.Domain.Caching;

public enum CacheCondition : byte
{
    Always,
    OnlyIfNotExists,
    OnlyIfExists
}