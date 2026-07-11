using System.Security.Claims;

namespace TrailStore.Identity.Api.Endpoints.Me;

public static class AccountResponseMapping
{
    public static AccountResponse? ToAccountResponse(this ClaimsPrincipal user)
    {
        var id = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var email = user.FindFirstValue(ClaimTypes.Email);

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(email))
        {
            return null;
        }

        return new AccountResponse
        {
            Id = Guid.Parse(id),
            Email = email
        };
    }
}