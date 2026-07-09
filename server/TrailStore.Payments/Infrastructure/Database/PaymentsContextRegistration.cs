using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Payments.Application.Abstractions;
using TrailStore.Shared.Infrastructure.Extensions;

namespace TrailStore.Payments.Infrastructure.Database;

public static class PaymentsContextRegistration
{
    public static void AddPaymentsContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddModuleDbContext<PaymentDbContext, IPaymentUnitOfWork>(configuration, DbDefaults.DefaultSchema);
}