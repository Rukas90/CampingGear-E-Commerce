using TrailStore.Domain.Models;

namespace TrailStore.Domain.Categories;

public interface ICategoriesRepository
{
    Task<List<Category>> ListAllAsync();
}