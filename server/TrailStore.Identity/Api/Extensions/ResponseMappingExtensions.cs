using TrailStore.Identity.Api.Common;
using TrailStore.Identity.Application.Results;

namespace TrailStore.Identity.Api.Extensions;

public static class ResponseMappingExtensions
{
    public static AccountResponse ToResponse(this UserAccountResult account)
        => new(account.Id, account.Email);
}