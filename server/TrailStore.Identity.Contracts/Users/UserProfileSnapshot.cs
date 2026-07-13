using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Contracts.Users;

public sealed record UserProfileSnapshot(Id<UserRef> Id, string EmailAddress, string FirstName, string LastName);