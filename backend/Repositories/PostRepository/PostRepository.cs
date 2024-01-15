using backend.Data;
using backend.Models;
using backend.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.PostRepository;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(DatabaseContext dbContext) : base(dbContext) {}
    
    public List<Post> GetAllPostsWithIncludes(string? include)
    {
        IQueryable<Post> query = _table;
        
        if (!string.IsNullOrEmpty(include))
        {
            var relationships = include.Split(',').ToList();
            foreach (var relation in relationships)
            {
                switch (relation.ToLower())
                {
                    case "category":
                        query = query.Include(p => p.Category);
                        break;
                    case "user":
                        query = query.Include(p => p.User);
                        break;
                    case "comments":
                        query = query.Include(p => p.Comments);
                        break;
                }
            }
        }

        return query.ToList();
    }

    public bool IsLikedBy(Guid userId, Guid postId)
    {
        var likedBy = _table.Where(p => p.Id == postId).Join(
            _dbContext.Likes,
            post => post.Id,
            like => like.PostId,
            (post, like) => new
            {
                UserId = like.UserId
            }).ToList();
        return likedBy.Any(src => src.UserId == userId);
    }
}