using backend.Data;
using backend.Models;
using backend.Models.DTOs;
using backend.Repositories.GenericRepository;
using backend.Services.PostService;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.PostRepository;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(DatabaseContext dbContext) : base(dbContext) {}
    
    public List<Post> GetAllPostsWithIncludes(string include)
    {
        if (!string.IsNullOrEmpty(include))
        {
            var relationships = include.Split(',').ToList();
            foreach (var relation in relationships)
            {
                switch (relation.ToLower())
                {
                    case "category":
                        _table.Include(p => p.Category);
                        break;
                    case "user":
                        _table.Include(p => p.User);
                        break;
                    case "comments":
                        _table.Include(p => p.Comments);
                        break;
                    case "saves":
                        _table.Include(p => p.Saves);
                        break;
                }
            }
        }

        return _table.ToList();
    }
}