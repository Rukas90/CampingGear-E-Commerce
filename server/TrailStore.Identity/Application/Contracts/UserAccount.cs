using TrailStore.Identity.Api.Domain.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Api.Application.Contracts;

public record UserAccount(Id<User> Id, string Email);