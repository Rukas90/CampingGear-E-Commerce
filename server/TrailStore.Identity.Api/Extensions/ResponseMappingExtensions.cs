using TrailStore.Identity.Api.Common;
using TrailStore.Identity.Application.Contracts;

namespace TrailStore.Identity.Api.Extensions;

public static class ResponseMappingExtensions
{
    public static AccountResponse ToResponse(this UserAccount account)
        => new(account.Id, account.Email);
}