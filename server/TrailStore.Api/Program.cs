using FastEndpoints;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TrailStore.Infrastructure.Categories;
using TrailStore.Infrastructure.Data;
using TrailStore.Infrastructure.Filters;
using TrailStore.Infrastructure.Orders;
using TrailStore.Infrastructure.Products;
using TrailStore.Infrastructure.Skus;
using TrailStore.Seed;

var builder = WebApplication.CreateBuilder(args);

var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(defaultConnectionString).WithExpressionExpanding());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ISkuRepository, SkuRepository>();
builder.Services.AddScoped<IFiltersService, FiltersService>();
builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();

builder.Services.AddFastEndpoints();
builder.Services.AddOpenApi();
builder.Services.AddAuthorization();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

var app = builder.Build();

if (args.Contains("seed"))
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    await SeedRunner.RunAsync(context, new SeedOptions { Reseed = true });
    
    return;
}

app.UseCors("AllowClient");
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();