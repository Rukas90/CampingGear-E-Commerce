param([string]$command, [string]$name = "")

switch ($command) {
    "seed" { dotnet run --project TrailStore.Api -- seed }
    "seed c" { dotnet run --project TrailStore.Api -- seed clear-only }
}