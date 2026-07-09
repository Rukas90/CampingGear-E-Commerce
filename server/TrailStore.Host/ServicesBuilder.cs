using FastEndpoints;
using TrailStore.Basket;
using TrailStore.Catalog;
using TrailStore.Identity;
using TrailStore.Inventory;
using TrailStore.Ordering;
using TrailStore.Payments;
using TrailStore.Shared.Api.Handlers;
using TrailStore.Shared.Api.Registrations;
using TrailStore.Shared.Infrastructure.Extensions;

namespace TrailStore.Host;

public static class ServicesBuilder
{
    public static void AddProgramServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowClient", policy =>
            {
                policy
                    .WithOrigins("http://localhost:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSharedInfrastructure(builder.Configuration);
        
        // TODO STRIPE
        
        var moduleBuilder 
            = new ModuleHostBuilder(builder.Services, builder.Configuration)
                .AddIdentityModule()
                .AddCatalogModule()
                .AddBasketModule()
                .AddOrderingModule()
                .AddInventoryModule()
                .AddPaymentsModule();

        builder.Services.AddFastEndpoints(options =>
        {
            options.Assemblies = moduleBuilder.ApiAssemblies;
        });
        builder.Services.AddOutputCache();
        builder.Services.AddOpenApi();
        
        builder.Services.AddResponseCompression(options => { options.EnableForHttps = true; });
        
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();
    }
}