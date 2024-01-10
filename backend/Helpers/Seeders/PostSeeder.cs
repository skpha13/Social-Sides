using backend.Data;
using backend.Models;

namespace backend.Helpers.Seeders;

public class PostSeeder
{
    private readonly DatabaseContext _dbContext;

    public PostSeeder(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SeedInitialPosts()
    {
        if (!_dbContext.Posts.Any())
        {
            var posts = new List<Post>
            {
                new Post()
                {
                    Id = new Guid(),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    Text = "Here you can see my cool car",
                    CategoryId = new Guid("72390ad3-b9e3-4f79-bd3b-f8fbe0a19388"),
                    UserId = new Guid("439c82bf-f8cd-4300-a467-03a1f85a6d63")
                },
                new Post()
                {
                    Id = new Guid(),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    Text = "It's my first time downloading this app and i fell in love with it!!!",
                    UserId = new Guid("439c82bf-f8cd-4300-a467-03a1f85a6d63")
                }
            };
            
            _dbContext.Posts.AddRange(posts);
            _dbContext.SaveChanges();
        }
    }
}