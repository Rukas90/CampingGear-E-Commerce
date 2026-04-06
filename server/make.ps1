param([string]$command, [string]$name = "")

switch ($command) {
    "seed" { dotnet run --project TrailStore.Api -- seed }
}