using System.Linq.Expressions;
using TrailStore.Api.Categories.Dto;
using TrailStore.Domain.Models;

namespace TrailStore.Api.Categories.Mapping;

public static class CategoriesMappingSelectors
{
    public static Expression<Func<OptionGroup, OptionGroupDto>> ToGroupDto()
        => g => new OptionGroupDto
        {
            GroupId = g.Id,
            Name       = g.Name,
            Slug       = g.Slug,
            SortOrder  = g.SortOrder,
            Options    = g.Options.Select(o => new OptionDto
            {
                Id        = o.Id,
                Name         = o.Name,
                Slug         = o.Slug,
                PreviewType  = o.PreviewType,
                PreviewValue = o.PreviewValue
            }).ToArray()
        };
}