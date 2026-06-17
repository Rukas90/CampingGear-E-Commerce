using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Contracts;

public record UserAccount(Id<User> Id, string Email);