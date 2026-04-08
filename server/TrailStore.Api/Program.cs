using FastEndpoints;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TrailStore.Infrastructure.Data;
using TrailStore.Seed;

var builder = WebApplication.CreateBuilder(args);

var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(defaultConnectionString).WithExpressionExpanding());

Console.WriteLine("Starting...");

foreach (var arg in args)
{
    Console.WriteLine(arg);
}

if (args.Contains("seed"))
{
    using var scope = builder.Build().Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    await SeedRunner.RunAsync(context, new SeedOptions { Reseed = true });
    
    return;
}

builder.Services.AddFastEndpoints();
builder.Services.AddOpenApi();
builder.Services.AddAuthorization();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

var app = builder.Build();

app.UseAuthorization();

app.UseHttpsRedirection();
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();