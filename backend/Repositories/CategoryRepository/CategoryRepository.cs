using System.Data.Entity;
using backend.Data;
using backend.Models;
using backend.Repositories.GenericRepository;

namespace backend.Repositories.CategoryRepository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public DateTime? GetDateFromId(Guid id)
    {
        return _table
            .AsNoTracking()
            .Where(src => src.Id == id)
            .Select(src => src.DateCreated)
            .FirstOrDefault();
    }
}