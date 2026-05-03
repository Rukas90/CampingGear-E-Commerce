using TrailStore.Domain.Models;

namespace TrailStore.Domain.Categories;

public interface ICategoriesRepository
{
    Task<List<Category>> ListAllCategoriesAsync();
    
    Task<List<CategoryGroup>> ListAllCategoryGroupsAsync();
}