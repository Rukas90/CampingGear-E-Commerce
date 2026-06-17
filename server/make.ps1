param(
    [string]$command,
    [string]$module = ""
)

$moduleArg = if ($module) { "--module=$module" } else { "" }

switch ($command) {
    "seed"        { dotnet run --project TrailStore.Seed.Console -- --reseed $moduleArg }
    "seed-clear"  { dotnet run --project TrailStore.Seed.Console -- clear-only $moduleArg }
    default       { Write-Host "Unknown command: $command. Use 'seed' or 'seed-clear', optionally with -module <name>." }
}