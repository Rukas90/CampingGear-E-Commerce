param(
    [string]$command,
    [string]$module = "",
    [ValidateSet("dev", "prod")]
    [string]$env = "dev"
)

if ($env -eq "prod") {
    $env:DOTNET_ENVIRONMENT = "production"
    $env:ConnectionStrings__DefaultConnection = $env:TRAILSTORE_PROD_CONNECTION_STRING
} else {
    $env:DOTNET_ENVIRONMENT = "development"
    $env:ConnectionStrings__DefaultConnection = $env:TRAILSTORE_LOCAL_CONNECTION_STRING
}

$moduleArg = if ($module) { "--module=$module" } else { "" }

switch ($command) {
    "run"   { dotnet run --project TrailStore.Seed -- --reseed $moduleArg }
    "clear" { dotnet run --project TrailStore.Seed -- clear-only $moduleArg }
    default { Write-Host "Unknown command: $command. Use 'run' or 'clear', optionally with -module <name> -env dev|prod." }
}