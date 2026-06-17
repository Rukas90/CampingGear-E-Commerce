using FastEndpoints;
using Scalar.AspNetCore;
using TrailStore.Identity.Api.Registration;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Registrations;

var builder = WebApplication.CreateBuilder(args);

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

var moduleBuilder 
    = new ModuleHostBuilder(builder.Services, builder.Configuration)
        .AddIdentityModule();

builder.Services.AddFastEndpoints(options =>
{
    options.Assemblies = moduleBuilder.ApiAssemblies;
});
builder.Services.AddOutputCache();
builder.Services.AddOpenApi();

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseExceptionHandler();
app.UseCors("AllowClient");
app.UseHttpsRedirection();
app.UseResponseCompression();

app.UseAuthentication();
app.UseAuthorization();

app.UseIdentityModule();

app.UseOutputCache();
app.UseFastEndpoints(config => config.ConfigureAppDefaults());

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();