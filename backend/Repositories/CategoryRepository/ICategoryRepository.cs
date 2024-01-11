using backend.Models;
using backend.Repositories.GenericRepository;

namespace backend.Repositories.CategoryRepository;

public interface ICategoryRepository : IGenericRepository<Category>
{
    List<Category> GetAllCategoriesWithIncludes(string? include);
    List<Category> GetCategoriesWithCreator(Guid userId);
}