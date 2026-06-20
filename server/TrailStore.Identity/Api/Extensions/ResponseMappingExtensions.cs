using TrailStore.Identity.Api.Api.Common;
using TrailStore.Identity.Api.Application.Contracts;

namespace TrailStore.Identity.Api.Api.Extensions;

public static class ResponseMappingExtensions
{
    public static AccountResponse ToResponse(this UserAccount account)
        => new(account.Id, account.Email);
}