using FastEndpoints;
using Scalar.AspNetCore;
using TrailStore.Host;
using TrailStore.Identity;
using TrailStore.Shared.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddProgramServices();

var app = builder.Build();

app.UseExceptionHandler();
app.UseCors("AllowClient");
app.UseHttpsRedirection();
app.UseResponseCompression();

app.UseIdentityModule();

app.UseOutputCache();
app.UseFastEndpoints(config => config.ConfigureAppDefaults());

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();