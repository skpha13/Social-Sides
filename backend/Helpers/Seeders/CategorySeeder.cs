using backend.Data;
using backend.Models;

namespace backend.Helpers.Seeders;

public class CategorySeeder
{
    private readonly DatabaseContext _dbContext;

    public CategorySeeder(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SeedInitialCategories()
    {
        if (!_dbContext.Categories.Any())
        {
            var categories = new List<Category>
            {
                new Category()
                {
                    Id = new Guid("72390ad3-b9e3-4f79-bd3b-f8fbe0a19388"),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    Title = "Cars",
                    Color = "#f67a7a" 
                },
                new Category()
                {
                    Id = new Guid("a5a039b9-890a-4fa0-88c2-980f9202c512"),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    Title = "Goth",
                    Color = "#a07af6"
                },
                new Category()
                {
                    Id = new Guid("60f2f1e1-467b-43c9-a8fa-a9aa9560082e"),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    Title = "Arts",
                    Color = "#f2f67a"
                },
                new Category()
                {
                    Id = new Guid("5ce2c2ec-0f4b-4540-ae7c-acbef95f0af1"),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    Title = "Retro",
                    Color = "#7accf6"
                },
                new Category()
                {
                    Id = new Guid("72b7971e-a0b5-4b17-b308-ceb11baeb611"),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    Title = "Soft",
                    Color = "#f67ac6"
                },
                new Category()
                {
                    Id = new Guid("39d660e8-3478-45f1-a4b2-9a420f6a3ef2"),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    Title = "Vintage",
                    Color = "#7af69d"
                }
            };
            
            _dbContext.Categories.AddRange(categories);
            _dbContext.SaveChanges();
        }
    }
}