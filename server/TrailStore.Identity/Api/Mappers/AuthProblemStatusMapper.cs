using Microsoft.Extensions.DependencyInjection;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Api.Api.Mappers;

[AppService<IProblemStatusMapper>(ServiceLifetime.Singleton)]
public class AuthProblemStatusMapper : IProblemStatusMapper
{
    public bool TryGetStatus(string code, out int status)
    {
        status = code switch
        {
            "auth.email_already_taken" => 409,
            "auth.invalid_credentials" => 401,
            "auth.refresh_token_invalid" => 401,
            "auth.refresh_token_reused" => 401,
            "auth.refresh_token_expired" => 401,
            "auth.refresh_token_not_found" => 404,
            _ => 0
        };
        return status != 0;
    }
}