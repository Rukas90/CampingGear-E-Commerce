using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Shared.Infrastructure.Extensions;

namespace TrailStore.Identity.Infrastructure.Database;

public static class IdentityContextRegistration
{
    public static void AddIdentityContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddModuleDbContext<IdentityDbContext, IIdentityUnitOfWork>(configuration, DbDefaults.DefaultSchema);
}