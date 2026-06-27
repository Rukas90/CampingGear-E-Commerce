namespace TrailStore.Shared.Domain.Common;

public record SessionContext<TOwner, TSession>(Id<TOwner>? OwnerId, Id<TSession>? SessionId)
{
    public bool Invalid => OwnerId is null && SessionId is null;
}