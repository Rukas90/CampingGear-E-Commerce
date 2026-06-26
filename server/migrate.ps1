param(
    [string]$command,
    [string]$module = "",
    [string]$name = "Migration"
)

$modules = @{
    "basket" = @{
        Project = "TrailStore.Basket";
        Context = "BasketDbContext";
        MigrationsDir = "Infrastructure/Database/Migrations"   }
    
    "identity" = @{ 
        Project = "TrailStore.Identity"; 
        Context = "IdentityDbContext"; 
        MigrationsDir = "Infrastructure/Database/Migrations" }
    
    "catalog" = @{ 
        Project = "TrailStore.Catalog";  
        Context = "CatalogDbContext";  
        MigrationsDir = "Infrastructure/Database/Migrations"  }
}

function Run-Migration($mod) {
    $project = $mod.Project
    $context = $mod.Context

    switch ($command) {
        "update"  {
            Write-Host "Migrating $project..."
            dotnet ef database update --project $project --context $context --startup-project TrailStore.Host
        }
        "add"      {
            Write-Host "Adding migration '$name' to $project..."
            dotnet ef migrations add $name --project $project --context $context --startup-project TrailStore.Host --output-dir $mod.MigrationsDir
        }
        "remove"   {
            Write-Host "Removing last migration from $project..."
            dotnet ef migrations remove --project $project --context $context --startup-project TrailStore.Host
        }
        "list"     {
            dotnet ef migrations list --project $project --context $context --startup-project TrailStore.Host
        }
    }
}

$validCommands = @("update", "add", "remove", "list")

if ($command -notin $validCommands) {
    Write-Host "Unknown command: '$command'. Use: $($validCommands -join ', ')"
    Write-Host "Options:"
    Write-Host "  -module <name>   Run for specific module only ($($modules.Keys -join ', '))"
    Write-Host "  -name <name>     Migration name for 'add' command (default: 'Migration')"
    exit 1
}

if ($module) {
    if (-not $modules.ContainsKey($module)) {
        Write-Host "Unknown module: '$module'. Available: $($modules.Keys -join ', ')"
        exit 1
    }
    Run-Migration $modules[$module]
} else {
    foreach ($mod in $modules.Values) {
        Run-Migration $mod
    }
}