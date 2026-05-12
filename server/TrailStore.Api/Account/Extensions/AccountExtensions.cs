using System.Security.Claims;
using TrailStore.Api.Auth.Dto;

namespace TrailStore.Api.Account.Extensions;

public static class AccountExtensions
{
    public static AccountDto? ToAccountDto(this ClaimsPrincipal user)
    {
        var id = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var email = user.FindFirstValue(ClaimTypes.Email);

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(email)) return null;

        return new AccountDto(Guid.Parse(id), email);
    }
}