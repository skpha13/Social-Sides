using backend.Models;
using backend.Repositories.GenericRepository;

namespace backend.Repositories.CategoryRepository;

public interface ICategoryRepository : IGenericRepository<Category>
{
    DateTime? GetDateFromId(Guid id);
    List<Category> GetAllCategoriesWithIncludes(string? include);
}