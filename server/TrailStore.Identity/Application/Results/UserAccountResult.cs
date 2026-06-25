using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Results;

public record UserAccountResult(Id<User> Id, string Email);