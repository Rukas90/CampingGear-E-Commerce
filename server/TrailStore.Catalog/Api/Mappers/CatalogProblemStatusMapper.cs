using Microsoft.Extensions.DependencyInjection;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Api.Mappers;

[AppService<IProblemStatusMapper>(ServiceLifetime.Singleton)]
public class CatalogProblemStatusMapper : IProblemStatusMapper
{
    public bool TryGetStatus(string code, out int status)
    {
        status = 0;
        
        if (code.StartsWith("product."))
        {
            status = GetProductStatus(code);
            return true;
        }
        
        return false;
    }

    private static int GetProductStatus(string code)
        => code switch
        {
            "product.not_found" => 404,
            _ => 400
        };
}