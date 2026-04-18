using FastEndpoints;
using TrailStore.Api.Categories.Dto;
using TrailStore.Api.Categories.Mapping;
using TrailStore.Domain.Options;
using TrailStore.Infrastructure.Options;

namespace TrailStore.Api.Categories.Endpoint;

public class GetCategoryProductOptions(IOptionsRepository optionsRepository) 
    : EndpointWithoutRequest<IEnumerable<OptionGroupDto>>
{
    public override void Configure()
    {
        Get("/api/v1/category/{slug}/options");
        AllowAnonymous();
    }

    public override async Task<IEnumerable<OptionGroupDto>> ExecuteAsync(CancellationToken ct)
    {
        var slug = Route<string>("slug")!;
        
        return await optionsRepository.ListAllAsync(
            specification: OptionSpecifications.Category(slug),
            selector: CategoriesMappingSelectors.ToGroupDto());
    }
}