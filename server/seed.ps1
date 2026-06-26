param(
    [string]$command,
    [string]$module = ""
)

$moduleArg = if ($module) { "--module=$module" } else { "" }

switch ($command) {
    "run"   { dotnet run --project TrailStore.Seed -- --reseed $moduleArg }
    "clear" { dotnet run --project TrailStore.Seed -- clear-only $moduleArg }
    default { Write-Host "Unknown command: $command. Use 'run' or 'clear', optionally with -module <name>." }
}