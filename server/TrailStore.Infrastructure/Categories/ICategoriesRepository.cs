using TrailStore.Domain.Models;

namespace TrailStore.Infrastructure.Categories;

public interface ICategoriesRepository
{
    Task<List<Category>> ListAllAsync();
}