using FastEndpoints;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TrailStore.Api;
using TrailStore.Api.Auth.Extensions;
using TrailStore.Api.Auth.Middleware;
using TrailStore.Infrastructure;
using TrailStore.Infrastructure.Data;
using TrailStore.Infrastructure.Extensions;
using TrailStore.Seed;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(defaultConnectionString).WithExpressionExpanding());

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

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(InfrastructureAssembly.Reference));

builder.Services.AddAppServicesFromAssemblies(
    InfrastructureAssembly.Reference, ApiAssembly.Reference);

builder.Services.ConfigureAppOptionsFromAssemblies(configuration,
    InfrastructureAssembly.Reference, ApiAssembly.Reference);

builder.Services.AddFastEndpoints();
builder.Services.AddOpenApi();

builder.Services.AddAppAuthentication(configuration);
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

    if (args.Contains("clear-only"))
    {
        await SeedRunner.ClearAsync(context);
    }
    else
    {
        await SeedRunner.RunAsync(context, new SeedOptions { Reseed = true });
    }
    
    return;
}

app.UseCors("AllowClient");
app.UseHttpsRedirection();
app.UseResponseCompression();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<CsrfInitializeMiddleware>();
app.UseMiddleware<CsrfValidateMiddleware>();

app.UseFastEndpoints(config =>
{
    config.Errors.UseProblemDetails();
    config.Errors.ProducesMetadataType = typeof(ProblemDetails);
    
    config.Errors.ResponseBuilder = (failures, _, statusCode) => new ProblemDetails
    {
        Status = statusCode,
        Errors = failures.Select(f => new ProblemDetails.Error
        {
            Name   = f.PropertyName,
            Code   = f.ErrorCode,
            Reason = f.ErrorMessage
        }).ToArray()
    };
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();