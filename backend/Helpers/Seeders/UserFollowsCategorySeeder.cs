using backend.Data;
using backend.Models;

namespace backend.Helpers.Seeders;

public class UserFollowsCategorySeeder
{
    private readonly DatabaseContext _dbContext;

    public UserFollowsCategorySeeder(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SeedUserCategories()
    {
        if (!_dbContext.UserFollowsCategories.Any())
        {
            var userFollowsCategories = new List<UserFollowsCategory>()
            {
                new UserFollowsCategory()
                {
                    UserId = new Guid("439c82bf-f8cd-4300-a467-03a1f85a6d63"),
                    CategoryId = new Guid("72390ad3-b9e3-4f79-bd3b-f8fbe0a19388")
                },
                new UserFollowsCategory()
                {
                    UserId = new Guid("439c82bf-f8cd-4300-a467-03a1f85a6d63"),
                    CategoryId = new Guid("60f2f1e1-467b-43c9-a8fa-a9aa9560082e")
                },
                new UserFollowsCategory()
                {
                    UserId = new Guid("439c82bf-f8cd-4300-a467-03a1f85a6d63"),
                    CategoryId = new Guid("5ce2c2ec-0f4b-4540-ae7c-acbef95f0af1")
                }
            };
            
            _dbContext.UserFollowsCategories.AddRange(userFollowsCategories);
            _dbContext.SaveChanges();
        }
    }
}