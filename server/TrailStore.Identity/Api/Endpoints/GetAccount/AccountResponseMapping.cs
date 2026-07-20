using System.Security.Claims;
using TrailStore.Identity.Api.Common;
using TrailStore.Shared.Api.Extensions;

namespace TrailStore.Identity.Api.Endpoints.GetAccount;

public static class AccountResponseMapping
{
    public static AccountResponse? ToAccountResponse(this ClaimsPrincipal user)
    {
        var id = user.GetSubjectId();
        var email = user.GetEmail();

        if (id is null || string.IsNullOrEmpty(email))
        {
            return null;
        }

        return new AccountResponse
        {
            Id = id.Value,
            Email = email
        };
    }
}