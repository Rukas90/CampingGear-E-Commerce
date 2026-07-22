using FastEndpoints;
using Scalar.AspNetCore;
using TrailStore.Basket.Infrastructure.Database;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Host;
using TrailStore.Identity;
using TrailStore.Identity.Infrastructure.Database;
using TrailStore.Inventory.Infrastructure.Database;
using TrailStore.Ordering.Infrastructure.Database;
using TrailStore.Payments.Infrastructure.Database;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Infrastructure.Extensions;
using TrailStore.Wishlist.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.AddProgramServices();

var app = builder.Build();

app.UseForwardedHeaders();
app.UseExceptionHandler();
app.UseCors("AllowClient");
app.UseHttpsRedirection();
app.UseResponseCompression();

app.UseIdentityModule();

app.UseOutputCache();
app.UseFastEndpoints(config => config.ConfigureAppDefaults());

app.MapGet("/", () => "Running.");
app.MapGet("/ping", () => "pong");
app.MapGet("/health", () => "ok");

if (app.Environment.IsDevelopment())
{
    await app.Services.MigrateAllAsync(
        typeof(BasketDbContext),
        typeof(CatalogDbContext),
        typeof(WishlistDbContext),
        typeof(IdentityDbContext),
        typeof(InventoryDbContext),
        typeof(OrderingDbContext),
        typeof(PaymentDbContext));
    
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();